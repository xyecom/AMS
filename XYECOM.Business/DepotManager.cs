//------------------------------------------------------------------------------
//
// file name：DepotManager.cs
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
    /// Business logic for dbo.XY_Depot.
    /// </summary>
    public partial class DepotManager
    {
        private XYECOM.SQLServer.DepotAccess depotDAL = new SQLServer.DepotAccess();

        /// <summary>
        /// 根据用户编号获取该用户的仓库信息 （王振添加 2011-03-31）
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>仓库信息</returns>
        public DataTable GetDepotByUserId(int userId)
        {
            if (userId < 0)
            {
                return null;
            }
            return depotDAL.GetDepotByUserId(userId);
        }
    }
}

