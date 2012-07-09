//------------------------------------------------------------------------------
//
// file name：FieldValueManager.cs
// author: wangzhen
// create date：2011-3-29 16:07:07
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace XYECOM.Business
{
    /// <summary>
    /// Business logic for dbo.XY_FieldValue.
    /// </summary>
    public partial class FieldValueManager
    {
        private XYECOM.SQLServer.FieldValueAccess DAL = new SQLServer.FieldValueAccess();
        
        /// <summary>
        /// 根据产品编号删除分类属性值 (王振添加 2011-04-01)
        /// </summary>
        /// <param name="proId">产品编号</param>
        /// <returns>受影响的行数</returns>
        public int DeleteFieldValueByProductId(int proId)
        {
            if (proId < 0)
            {
                return 0;
            }
            return DAL.DeleteFieldValueByProductId(proId);
        }
    }
}

