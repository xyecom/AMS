using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;
using XYECOM.SQLServer;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 用户帐户数据处理类
    /// </summary>
    public class UserAccount
    {
        /// <summary>
        /// 删除账户就
        /// </summary>
        /// <param name="UGR_ID">记录Id</param>
        /// <returns>影响行数</returns>
        public int DeleteAcount(int UGR_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where UGR_ID=" + UGR_ID.ToString()),
                new SqlParameter("@strTableName","u_Account"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("XYP_SelectByWhere", param);
        }

        /// <summary>
        /// 获取指定用户的所有的账户信息
        /// </summary>
        /// <param name="U_ID">用户id</param>
        /// <returns>记录表对象</returns>
        public DataTable GetDataTable(long U_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," where U_ID="+U_ID .ToString ()),
                new SqlParameter("@strTableName","XYV_Acount"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", param);
        }

        /// <summary>
        /// 返回指定用户的帐户信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public Model.UserAccountInfo GetItem(long userId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where U_ID=" + userId.ToString()),
                new SqlParameter("@strTableName","u_Account"),
                new SqlParameter("@strOrder","")
            };

            Model.UserAccountInfo info = null;
            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader( CommandType.StoredProcedure,"XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.UserAccountInfo();

                    info.U_ID = Core.MyConvert.GetInt64(reader["U_ID"].ToString());
                    info.UGR_ID = Core.MyConvert.GetInt32(reader["UGR_ID"].ToString());
                    info.UGR_LeftMoney = Core.MyConvert.GetDecimal(reader["UGR_LeftMoney"].ToString());
                    info.UGR_Money = Core.MyConvert.GetDecimal(reader["UGR_Money"].ToString());
                }
            }
            return info;
        }

        #region 剩余的钱给用户入账户
        /// <summary>
        /// 给用户帐户充值
        /// </summary>
        /// <param name="U_ID">用户Id</param>
        /// <param name="Money">充值金额</param>
        /// <returns>影响行数</returns>
        public int AddAccountMoney(long U_ID, decimal Money)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@U_ID", U_ID),
                new SqlParameter("@Money",Money)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_UpdateAccountMoney", param);
        }
        #endregion

        #region 扣除用户账户金额
        /// <summary>
        /// 用户账户支出扣除相应金额
        /// </summary>
        /// <param name="U_ID">用户Id</param>
        /// <param name="Money">消费金额</param>
        /// <returns>影响行数</returns>
        public int DeductAccountMoney(long U_ID, decimal Money)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@U_ID", U_ID),
                new SqlParameter("@Money",Money)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_UpdateDeductAccountMoney", param);
        }
        #endregion
    
    }
}
