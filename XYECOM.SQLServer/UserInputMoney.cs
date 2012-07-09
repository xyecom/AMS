using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.Core.Data;
using System.Data.SqlClient;
using System.Data;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 用户充值数据处理类
    /// </summary>
    public class UserInputMoney
    {
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="ei">数据对象</param>
        /// <returns>影响行数</returns>
        public int Insert(XYECOM.Model.UserInputMoneyInfo ei)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@UM_ID",ei.UM_ID),
                new SqlParameter ("@U_ID",ei.U_ID ),
                new SqlParameter ("@FT_ID",ei.FT_ID ),
                new SqlParameter ("@IM_Count",ei.IM_Count ),
                new SqlParameter ("@PM_ID",ei.PM_ID ),
                new SqlParameter ("@OrderID",ei.OrderID),
                new SqlParameter ("@PlatformFlag",ei.PlatformFlag)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_InsertInputMoneyInfo", parm);
        }

        //public  DataTable GetDataTable(long IM_ID)
        //{
        //    SqlParameter[] param = new SqlParameter[] 
        //    { 
        //        new SqlParameter("@strWhere"," where IM_ID="+IM_ID .ToString ()),
        //        new SqlParameter("@strTableName","u_InputMoneyInfo"),
        //        new SqlParameter("@strOrder","")
        //    };

        //    return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", param);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool CheckOrder(string orderID, long userId)
        {
            int result = (int)XYECOM.Core.Data.SqlHelper.ExecuteScalar("select count(IM_ID) from u_InputMoneyInfo where OrderID='" + orderID + "' and U_id = " + userId + " and OrderID <> '' and PlatformFlag <> ''");
            return result > 0;
        }
    }
}

