//------------------------------------------------------------------------------
//
// file name：BrandManager.cs
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
    /// Business logic for dbo.XY_Brand.
    /// </summary>
    public partial class BrandManager
    {
        private XYECOM.SQLServer.BrandAccess brandDAL = new SQLServer.BrandAccess();

        /// <summary>
        /// 根据分类编号获取与该分类相关的品牌集合（王振添加 2011-03-31）
        /// </summary>
        /// <param name="proTypeId">分类ID</param>
        /// <returns>品牌集合</returns>
        public DataTable GetBrandByProdTypeId(int proTypeId)
        {
            if (proTypeId < 0)
            {
                return null;
            }
            return brandDAL.GetBrandByProdTypeId(proTypeId);
        }
    }
}

