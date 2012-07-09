//------------------------------------------------------------------------------
//
// file name：MeasuringUnitManager.cs
// author: wangzhen
// create date：2011-3-28 12:25:36
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// Business logic for dbo.XY_MeasuringUnit.
    /// </summary>
    public partial class MeasuringUnitManager
    {
        private XYECOM.SQLServer.MeasuringUnitAccess unitDAL = new SQLServer.MeasuringUnitAccess();
        /// <summary>
        /// 根据分类编号获取与该分类相关的计量单位集合（王振添加 3011-03-31）
        /// </summary>
        /// <param name="proTypeId">分类编号</param>
        /// <returns>计量单位</returns>
        public DataTable GetUnitByProdTypId(int proTypeId)
        {
            if (proTypeId < 0)
            {
                return null;
            }
            return unitDAL.GetUnitByProdTypId(proTypeId);
        }
    }
}

