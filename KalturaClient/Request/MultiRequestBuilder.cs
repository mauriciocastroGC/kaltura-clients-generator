﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Kaltura.Request
{
    public class MultiRequestBuilder : BaseRequestBuilder<List<object>>
    {
        private List<IRequestBuilder> requests = new List<IRequestBuilder>();

        public IRequestBuilder this[int index]   // Indexer declaration
        {
            get
            {
                if (index < 1 || index > requests.Count)
                    return null;
                else
                    return requests[index - 1];
            }
        }

        public MultiRequestBuilder()
            : base("multirequest")
        {
        }

        public MultiRequestBuilder(params IRequestBuilder[] requestBuilders)
            : this()
        {
            foreach(IRequestBuilder requestBuilder in requestBuilders)
            {
                Add(requestBuilder);
            }
        }

        public override BaseRequestBuilder<List<object>> Build(Client client)
        {
            base.Build(client);
            foreach(IRequestBuilder request in requests)
            {
                request.Boundary = this.Boundary;
            }
            return this;
        }

        public override MultiRequestBuilder Add(IRequestBuilder requestBuilder)
        {
            requests.Add(requestBuilder);
            requestBuilder.MultiRequestIndex = requests.Count;
            return this;
        }

        public override void OnComplete(object response, Exception error)
        {
            List<object> responses = (List<object>)response;
            for (int i = 0; i < responses.Count; i++)
            {
                if (responses[i] is APIException)
                {
                    requests[i].OnComplete(null, (APIException) responses[i]);
                }
                else
                {
                    requests[i].OnComplete(responses[i], null);
                }
            }

            base.OnComplete(response, error);
        }

        public override Params getParameters(bool includeServiceAndAction)
        {
            Params kparams = base.getParameters(false);

            foreach (IRequestBuilder request in requests)
            {
                Params requestParams = new Params();
                requestParams.Add(request.MultiRequestIndex.ToString(), request.getParameters(true));
                kparams.Add(requestParams);
            }

            return kparams;
        }

        public override Files getFiles()
        {
            Files kfiles = base.getFiles();

            foreach (IRequestBuilder request in requests)
            {
                foreach (KeyValuePair<string, Stream> file in request.getFiles())
                {
                    kfiles.Add(request.MultiRequestIndex + ":" + file.Key, file.Value);
                }
            }

            return kfiles;
        }

        public override object Deserialize(XmlElement results)
        {
            List<object> responses = new List<object>();

            foreach (XmlElement result in results.ChildNodes)
            {
                object response = GetAPIError(result);
                if (response == null)
                {
                    IRequestBuilder request = requests[responses.Count];
                    response = request.Deserialize(result);
                }

                responses.Add(response);
            }

            return responses;
        }

        public override object DeserializeObject(object results)
        {
            List<object> responses = new List<object>();

            foreach (var result in (List<Dictionary<string,object>>)results)
            {
                //TODO: see if error and return
                var request = requests[responses.Count];
                var response = request.DeserializeObject(result);

                responses.Add(response);
            }

            return responses;
        }
    }
}
