//------------------------------------------------------------------------------
//
// file name：FieldManager.cs
// author: wangzhen
// create date：2011-3-29 16:07:07
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// Business logic for dbo.XY_Field.
    /// </summary>
    public partial class FieldManager
    {
        /// <summary>
        /// 根据类别编号和所在模板获取自定义字段信息
        /// </summary>
        /// <param name="typeID">类别编号</param>        
        /// <returns>自定义字段信息</returns>
        public IList<Model.FieldValueInfo> GetItems(int typeID)
        {
            if (typeID < 1)
            {
                return new List<Model.FieldValueInfo>();
            }

            return access.GetItems(typeID);
        }

           /// <summary>
        /// 根据产品分类id获取相关的自定义属性
        /// </summary>
        /// <param name="pt_id">产品分类id</param>
        /// <returns></returns>
        public IList<Model.FieldValueInfo> GetFieldValueForPtid(int pt_id)
        {
            return access.GetFieldValueForPtid(pt_id);
        }
    }
}

