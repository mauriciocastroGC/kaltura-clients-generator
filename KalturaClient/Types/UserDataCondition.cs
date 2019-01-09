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
using Kaltura.Enums;
using Kaltura.Request;

namespace Kaltura.Types
{
	public class UserDataCondition : BaseSegmentCondition
	{
		#region Constants
		public const string FIELD = "field";
		public const string VALUE = "value";
		#endregion

		#region Private Fields
		private string _Field = null;
		private string _Value = null;
		#endregion

		#region Properties
		public string Field
		{
			get { return _Field; }
			set 
			{ 
				_Field = value;
				OnPropertyChanged("Field");
			}
		}
		public string Value
		{
			get { return _Value; }
			set 
			{ 
				_Value = value;
				OnPropertyChanged("Value");
			}
		}
		#endregion

		#region CTor
		public UserDataCondition()
		{
		}

		public UserDataCondition(XmlElement node) : base(node)
		{
			foreach (XmlElement propertyNode in node.ChildNodes)
			{
				switch (propertyNode.Name)
				{
					case "field":
						this._Field = propertyNode.InnerText;
						continue;
					case "value":
						this._Value = propertyNode.InnerText;
						continue;
				}
			}
		}

		public UserDataCondition(IDictionary<string,object> data) : base(data)
		{
			    this._Field = data.TryGetValueSafe<string>("field");
			    this._Value = data.TryGetValueSafe<string>("value");
		}
		#endregion

		#region Methods
		public override Params ToParams(bool includeObjectType = true)
		{
			Params kparams = base.ToParams(includeObjectType);
			if (includeObjectType)
				kparams.AddReplace("objectType", "KalturaUserDataCondition");
			kparams.AddIfNotNull("field", this._Field);
			kparams.AddIfNotNull("value", this._Value);
			return kparams;
		}
		protected override string getPropertyName(string apiName)
		{
			switch(apiName)
			{
				case FIELD:
					return "Field";
				case VALUE:
					return "Value";
				default:
					return base.getPropertyName(apiName);
			}
		}
		#endregion
	}
}

