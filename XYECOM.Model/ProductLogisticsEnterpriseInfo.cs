//------------------------------------------------------------------------------
//
// file name：ProductLogisticsEnterpriseInfo.cs
// author: wangzhen
// create date：2011-3-29 16:07:06
//
//------------------------------------------------------------------------------
using System;
namespace XYECOM.Model
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public partial class ProductLogisticsEnterpriseInfo
	{
        private string _typeName = string.Empty;

        public string TypeName
        {
            get { return _typeName; }
            set { _typeName = value; }
        }

        public int IsSelected { get; set; }
	}
}
