﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：FieldInfo.autogenerated.cs
// author: wangzhen
// create date：2011-5-11 12:15:17
//
//------------------------------------------------------------------------------
using System;
namespace XYECOM.Model
{
	public partial class FieldInfo
	{
		#region Data

		/// <summary>
		/// 
		/// </summary>
		private int _id;
		
		/// <summary>
		/// 
		/// </summary>
		private int _productTypeId;
		
		/// <summary>
		/// 
		/// </summary>
		private string _eName;
		
		/// <summary>
		/// 
		/// </summary>
		private string _cName;
		
		/// <summary>
		/// 
		/// </summary>
		private string _type;
		
		/// <summary>
		/// 
		/// </summary>
		private string _description;
		
		/// <summary>
		/// 
		/// </summary>
		private string _defaultValue;
		
		/// <summary>
		/// 
		/// </summary>
		private string _initValue;
		
		/// <summary>
		/// 
		/// </summary>
		private bool _isRequire;
		
		/// <summary>
		/// 
		/// </summary>
		private string _inputModel;
		
		/// <summary>
		/// 
		/// </summary>
		private ProductTypeInfo productType;
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			get 
			{
				return this._id;
			}
			set 
			{
				this._id = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int ProductTypeId
		{
			get 
			{
				return this._productTypeId;
			}
			set 
			{
				this._productTypeId = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string EName
		{
			get 
			{
				return this._eName;
			}
			set 
			{
				this._eName = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CName
		{
			get 
			{
				return this._cName;
			}
			set 
			{
				this._cName = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Type
		{
			get 
			{
				return this._type;
			}
			set 
			{
				this._type = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			get 
			{
				return this._description;
			}
			set 
			{
				this._description = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string DefaultValue
		{
			get 
			{
				return this._defaultValue;
			}
			set 
			{
				this._defaultValue = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string InitValue
		{
			get 
			{
				return this._initValue;
			}
			set 
			{
				this._initValue = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool IsRequire
		{
			get 
			{
				return this._isRequire;
			}
			set 
			{
				this._isRequire = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string InputModel
		{
			get 
			{
				return this._inputModel;
			}
			set 
			{
				this._inputModel = value;
			}
		}
	
		/// <summary>
		/// 
		/// </summary>
		public virtual ProductTypeInfo ProductType
		{
			get
			{
				return this.productType;
			}
			set
			{
				this.productType = value;
			}
			
		}
		#endregion
	}
} 

