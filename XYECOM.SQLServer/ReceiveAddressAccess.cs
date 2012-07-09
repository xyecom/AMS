//------------------------------------------------------------------------------
//
// file name：XY_ReceiveAddressAccessor.cs
// author: wangzhen
// create date：2011-3-29 16:07:06
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using XYECOM.Core.Data;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// Data accessor of ReceiveAddressAccess
    /// </summary>
    public partial class ReceiveAddressAccess
    {
        public DataTable Select(int userId)
        {
            string sql = "select * from XY_ReceiveAddress where UserId=" + userId;
            return SqlHelper.ExecuteTable(sql);
        }

        /// <summary>
        /// 根据收货地址获取给收货地址在订单中使用的个数
        /// </summary>
        /// <param name="receid">收货地址</param>
        /// <returns>在订单中使用的次数</returns>
        public int GetReceCountToOrderByreceId(int receid)
        {
            string sql = "select count(*) from xy_order where ReceiveAddressId = "+receid+"";
            return (int)SqlHelper.ExecuteScalar(sql);
        }
    }
}
