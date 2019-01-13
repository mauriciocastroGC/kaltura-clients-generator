// ===================================================================================================
//                           _  __     _ _
//                          | |/ /__ _| | |_ _  _ _ _ __ _
//                          | ' </ _` | |  _| || | '_/ _` |
//                          |_|\_\__,_|_|\__|\_,_|_| \__,_|
//
// This file is part of the Kaltura Collaborative Media Suite which allows users
// to do with audio, video, and animation what Wiki platfroms allow them to do with
// text.
//
// Copyright (C) 2006-2018  Kaltura Inc.
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
//
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
// @ignore
// ===================================================================================================
using System;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using Kaltura.Request;
using Kaltura.Types;
using Kaltura.Enums;

namespace Kaltura.Services
{
	public class SocialActionAddRequestBuilder : RequestBuilder<UserSocialActionResponse>
	{
		#region Constants
		public const string SOCIAL_ACTION = "socialAction";
		#endregion

		public SocialAction SocialAction
		{
			set;
			get;
		}

		public SocialActionAddRequestBuilder()
			: base("socialaction", "add")
		{
		}

		public SocialActionAddRequestBuilder(SocialAction socialAction)
			: this()
		{
			this.SocialAction = socialAction;
		}

		public override Params getParameters(bool includeServiceAndAction)
		{
			Params kparams = base.getParameters(includeServiceAndAction);
			if (!isMapped("socialAction"))
				kparams.AddIfNotNull("socialAction", SocialAction);
			return kparams;
		}

		public override Files getFiles()
		{
			Files kfiles = base.getFiles();
			return kfiles;
		}

		public override object Deserialize(XmlElement result)
		{
			return ObjectFactory.Create<UserSocialActionResponse>(result);
		}
		public override object DeserializeObject(object result)
		{
			return ObjectFactory.Create<UserSocialActionResponse>((IDictionary<string,object>)result);
		}
	}

	public class SocialActionDeleteRequestBuilder : RequestBuilder<IList<NetworkActionStatus>>
	{
		#region Constants
		public const string ID = "id";
		#endregion

		public string Id
		{
			set;
			get;
		}

		public SocialActionDeleteRequestBuilder()
			: base("socialaction", "delete")
		{
		}

		public SocialActionDeleteRequestBuilder(string id)
			: this()
		{
			this.Id = id;
		}

		public override Params getParameters(bool includeServiceAndAction)
		{
			Params kparams = base.getParameters(includeServiceAndAction);
			if (!isMapped("id"))
				kparams.AddIfNotNull("id", Id);
			return kparams;
		}

		public override Files getFiles()
		{
			Files kfiles = base.getFiles();
			return kfiles;
		}

		public override object Deserialize(XmlElement result)
		{
			IList<NetworkActionStatus> list = new List<NetworkActionStatus>();
			foreach(XmlElement node in result.ChildNodes)
			{
				list.Add(ObjectFactory.Create<NetworkActionStatus>(node));
			}
			return list;
		}
		public override object DeserializeObject(object result)
		{
			var list = new List<NetworkActionStatus>();
			foreach(var node in (IEnumerable<IDictionary<string,object>>)result)
			{
				list.Add(ObjectFactory.Create<NetworkActionStatus>(node));
			}
			return list;
		}
	}

	public class SocialActionListRequestBuilder : RequestBuilder<ListResponse<SocialAction>>
	{
		#region Constants
		public const string FILTER = "filter";
		public const string PAGER = "pager";
		#endregion

		public SocialActionFilter Filter
		{
			set;
			get;
		}
		public FilterPager Pager
		{
			set;
			get;
		}

		public SocialActionListRequestBuilder()
			: base("socialaction", "list")
		{
		}

		public SocialActionListRequestBuilder(SocialActionFilter filter, FilterPager pager)
			: this()
		{
			this.Filter = filter;
			this.Pager = pager;
		}

		public override Params getParameters(bool includeServiceAndAction)
		{
			Params kparams = base.getParameters(includeServiceAndAction);
			if (!isMapped("filter"))
				kparams.AddIfNotNull("filter", Filter);
			if (!isMapped("pager"))
				kparams.AddIfNotNull("pager", Pager);
			return kparams;
		}

		public override Files getFiles()
		{
			Files kfiles = base.getFiles();
			return kfiles;
		}

		public override object Deserialize(XmlElement result)
		{
			return ObjectFactory.Create<ListResponse<SocialAction>>(result);
		}
		public override object DeserializeObject(object result)
		{
			return ObjectFactory.Create<ListResponse<SocialAction>>((IDictionary<string,object>)result);
		}
	}


	public class SocialActionService
	{
		private SocialActionService()
		{
		}

		public static SocialActionAddRequestBuilder Add(SocialAction socialAction)
		{
			return new SocialActionAddRequestBuilder(socialAction);
		}

		public static SocialActionDeleteRequestBuilder Delete(string id)
		{
			return new SocialActionDeleteRequestBuilder(id);
		}

		public static SocialActionListRequestBuilder List(SocialActionFilter filter, FilterPager pager = null)
		{
			return new SocialActionListRequestBuilder(filter, pager);
		}
	}
}
