using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using XYECOM.Core.Data;
using XYECOM.SQLServer;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 用户汇款数据处理类
    /// </summary>
    public class UserRemit
    {
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns></returns>
        public int Insert(XYECOM.Model.UserRemitInfo info)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@R_Name",info.R_Name ),
            new SqlParameter ("@R_Email",info.R_Email ),
            new SqlParameter ("@R_Tephone",info.R_Tephone ),
            new SqlParameter ("@R_Time",info.R_Time ),
            new SqlParameter ("@R_Bank",info.R_Bank ),
            new SqlParameter ("@R_Account",info.R_Account ),
            new SqlParameter ("@R_CAccount",info.R_CAccount ),
            new SqlParameter ("@R_RName",info.R_RName ),
            new SqlParameter ("@R_Money",info.R_Money ),
            new SqlParameter ("@U_ID",info.U_ID )
           };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertUserRemit", parm);
        }

        //public DataTable GetDataTable(int  R_ID)
        //{
        //    SqlParameter[] param = new SqlParameter[] 
        //    { 
        //        new SqlParameter("@strWhere",""),
        //        new SqlParameter("@strTableName","XYV_Remit"),
        //        new SqlParameter("@strOrder","")
        //    };

        //    return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", param);   
        //}

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="R_ID">记录Id</param>
        /// <returns></returns>
        public XYECOM.Model.UserRemitInfo GetItem(int R_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where R_ID=" + R_ID.ToString()),
                new SqlParameter("@strTableName","XYV_Remit"),
                new SqlParameter("@strOrder","")
            };

            XYECOM.Model.UserRemitInfo info = null;

            using(SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure,"XYP_SelectByWhere", param))
            {
                if (dr.Read())
                { 
                    info = new XYECOM.Model.UserRemitInfo();
                    info.R_Account = dr["R_Account"].ToString();
                    info.R_Bank = dr["R_Bank"].ToString();
                    info.R_CAccount = dr["R_CAccount"].ToString();
                    info.R_Email = dr["R_Email"].ToString();   
                    info.R_ID = int.Parse(dr["R_ID"].ToString());
                    info.R_Money = decimal.Parse(dr["R_Money"].ToString());
                    info.R_Name = dr["R_Name"].ToString();
                    info.R_RName = dr["R_RName"].ToString();
                    info.R_Tephone = dr["R_Tephone"].ToString();
                    info.R_Time = DateTime.Parse(dr["R_Time"].ToString());
                    info.U_ID = Int64.Parse(dr["U_ID"].ToString());
                    info.R_IsPay = bool.Parse(dr["R_IsPay"].ToString());

                    if(dr["AuditingState"].ToString().Equals("1"))
                        info.AuditingState = XYECOM.Model.AuditingState.Passed;
                    else if(dr["AuditingState"].ToString().Equals("0"))
                        info.AuditingState = XYECOM.Model.AuditingState.NoPass;
                    else
                        info.AuditingState = XYECOM.Model.AuditingState.Null;
                }
            }
            return info;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="R_ID">记录Id</param>
        /// <returns></returns>
        public int Delete(int R_ID)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@strwhere","where R_ID="+R_ID.ToString()),
                new SqlParameter("@strTableName","u_Remit")                           
            };
            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", parm);
        }

        /// <summary>
        /// 删除多个汇款确认信息
        /// </summary>
        /// <param name="R_ID"></param>
        /// <returns></returns>
        public int Deletes(string R_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where R_ID in ("+R_ID+")"),
                new SqlParameter("@strTableName","u_Remit")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// 更新用户帐户金额
        /// </summary>
        /// <param name="U_ID">用户Id</param>
        /// <param name="Money">变动金额</param>
        /// <returns></returns>
        public int UpdateMoney(long U_ID, Decimal Money)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@U_ID", U_ID),
                new SqlParameter("@Money",Money)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdaeAccountMoney", param);   
        }

        /// <summary>
        /// 修改是否充值状态
        /// </summary>
        /// <param name="R_ID">记录Id</param>
        /// <returns></returns>
        public int UpdateIsPay(long R_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@R_ID", R_ID)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_UpdateRemit", param);
        }

        /// <summary>
        /// 扣除用户的诚信指数
        /// </summary>
        /// <param name="U_ID"></param>
        /// <param name="Money"></param>
        /// <returns></returns>
        public int DeductFaithMongy(long U_ID,int Money)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@U_ID", U_ID),
                new SqlParameter("@Money",Money)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdaeAccountMoney", param);
        }
    }
}
