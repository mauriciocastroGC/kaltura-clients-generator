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
	public class ExportTaskAddRequestBuilder : RequestBuilder<ExportTask>
	{
		#region Constants
		public const string TASK = "task";
		#endregion

		public ExportTask Task
		{
			set;
			get;
		}

		public ExportTaskAddRequestBuilder()
			: base("exporttask", "add")
		{
		}

		public ExportTaskAddRequestBuilder(ExportTask task)
			: this()
		{
			this.Task = task;
		}

		public override Params getParameters(bool includeServiceAndAction)
		{
			Params kparams = base.getParameters(includeServiceAndAction);
			if (!isMapped("task"))
				kparams.AddIfNotNull("task", Task);
			return kparams;
		}

		public override Files getFiles()
		{
			Files kfiles = base.getFiles();
			return kfiles;
		}

		public override object Deserialize(XmlElement result)
		{
			return ObjectFactory.Create<ExportTask>(result);
		}
		public override object DeserializeObject(object result)
		{
			return ObjectFactory.Create<ExportTask>((IDictionary<string,object>)result);
		}
	}

	public class ExportTaskDeleteRequestBuilder : RequestBuilder<bool>
	{
		#region Constants
		public const string ID = "id";
		#endregion

		public long Id
		{
			set;
			get;
		}

		public ExportTaskDeleteRequestBuilder()
			: base("exporttask", "delete")
		{
		}

		public ExportTaskDeleteRequestBuilder(long id)
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
			if (result.InnerText.Equals("1") || result.InnerText.ToLower().Equals("true"))
				return true;
			return false;
		}
		public override object DeserializeObject(object result)
		{
			var resultStr = (string)result;
			if (resultStr.Equals("1") || resultStr.ToLower().Equals("true"))
				return true;
			return false;
		}
	}

	public class ExportTaskGetRequestBuilder : RequestBuilder<ExportTask>
	{
		#region Constants
		public const string ID = "id";
		#endregion

		public long Id
		{
			set;
			get;
		}

		public ExportTaskGetRequestBuilder()
			: base("exporttask", "get")
		{
		}

		public ExportTaskGetRequestBuilder(long id)
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
			return ObjectFactory.Create<ExportTask>(result);
		}
		public override object DeserializeObject(object result)
		{
			return ObjectFactory.Create<ExportTask>((IDictionary<string,object>)result);
		}
	}

	public class ExportTaskListRequestBuilder : RequestBuilder<ListResponse<ExportTask>>
	{
		#region Constants
		public const string FILTER = "filter";
		#endregion

		public ExportTaskFilter Filter
		{
			set;
			get;
		}

		public ExportTaskListRequestBuilder()
			: base("exporttask", "list")
		{
		}

		public ExportTaskListRequestBuilder(ExportTaskFilter filter)
			: this()
		{
			this.Filter = filter;
		}

		public override Params getParameters(bool includeServiceAndAction)
		{
			Params kparams = base.getParameters(includeServiceAndAction);
			if (!isMapped("filter"))
				kparams.AddIfNotNull("filter", Filter);
			return kparams;
		}

		public override Files getFiles()
		{
			Files kfiles = base.getFiles();
			return kfiles;
		}

		public override object Deserialize(XmlElement result)
		{
			return ObjectFactory.Create<ListResponse<ExportTask>>(result);
		}
		public override object DeserializeObject(object result)
		{
			return ObjectFactory.Create<ListResponse<ExportTask>>((IDictionary<string,object>)result);
		}
	}

	public class ExportTaskUpdateRequestBuilder : RequestBuilder<ExportTask>
	{
		#region Constants
		public const string ID = "id";
		public const string TASK = "task";
		#endregion

		public long Id
		{
			set;
			get;
		}
		public ExportTask Task
		{
			set;
			get;
		}

		public ExportTaskUpdateRequestBuilder()
			: base("exporttask", "update")
		{
		}

		public ExportTaskUpdateRequestBuilder(long id, ExportTask task)
			: this()
		{
			this.Id = id;
			this.Task = task;
		}

		public override Params getParameters(bool includeServiceAndAction)
		{
			Params kparams = base.getParameters(includeServiceAndAction);
			if (!isMapped("id"))
				kparams.AddIfNotNull("id", Id);
			if (!isMapped("task"))
				kparams.AddIfNotNull("task", Task);
			return kparams;
		}

		public override Files getFiles()
		{
			Files kfiles = base.getFiles();
			return kfiles;
		}

		public override object Deserialize(XmlElement result)
		{
			return ObjectFactory.Create<ExportTask>(result);
		}
		public override object DeserializeObject(object result)
		{
			return ObjectFactory.Create<ExportTask>((IDictionary<string,object>)result);
		}
	}


	public class ExportTaskService
	{
		private ExportTaskService()
		{
		}

		public static ExportTaskAddRequestBuilder Add(ExportTask task)
		{
			return new ExportTaskAddRequestBuilder(task);
		}

		public static ExportTaskDeleteRequestBuilder Delete(long id)
		{
			return new ExportTaskDeleteRequestBuilder(id);
		}

		public static ExportTaskGetRequestBuilder Get(long id)
		{
			return new ExportTaskGetRequestBuilder(id);
		}

		public static ExportTaskListRequestBuilder List(ExportTaskFilter filter = null)
		{
			return new ExportTaskListRequestBuilder(filter);
		}

		public static ExportTaskUpdateRequestBuilder Update(long id, ExportTask task)
		{
			return new ExportTaskUpdateRequestBuilder(id, task);
		}
	}
}
