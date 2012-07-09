using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.Core.Data;
using XYECOM.SQLServer;
using System.Data.SqlClient;
using System.Data;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 邮件数据处理类
    /// </summary>
    public class SendEmail
    {
        /// <summary>
        /// 插入邮件记录
        /// </summary>
        /// <param name="se">数据对象</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.SendEmailInfo se)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
               new SqlParameter ("@E_title",se .E_title ),
               new SqlParameter ("@E_content",se .E_content ),
               new SqlParameter ("@U_IDS",se.U_IDS )
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertEmail", parm);
        }

        /// <summary>
        /// 删除就
        /// </summary>
        /// <param name="E_ID">记录Id</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int E_ID)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@strwhere","where E_ID="+E_ID .ToString ()),
                new SqlParameter ("@strTableName","u_SendEmail"),
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", parm);
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="se">数据对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.SendEmailInfo se)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@E_ID",se .E_ID ),
                new SqlParameter ("@E_title",se .E_title ),
                new SqlParameter ("@E_content",se .E_content )
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateSendEmail", parm);
        }

        /// <summary>
        /// 已过时,不推荐使用
        /// </summary>
        /// <param name="E_ID"></param>
        /// <returns></returns>
        public XYECOM.Model.SendEmailInfo GetItem(int E_ID)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@strWhere","where E_ID="+E_ID .ToString ()),
                new SqlParameter ("@strTableName","u_SendEmail"),
                new SqlParameter("@strOrder","")
                
            };

            XYECOM.Model.SendEmailInfo Info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", parm))
            {
                if (reader.Read())
                {
                    Info = new XYECOM.Model.SendEmailInfo();

                    Info.E_content = reader["E_content"].ToString();
                    Info.E_ID = Int32.Parse(reader["E_ID"].ToString());
                    Info.E_title = reader["E_title"].ToString();
                    Info.U_IDS = reader["U_IDS"].ToString();
                    Info.AddTime = DateTime.Parse(reader["AddTime"].ToString());
                }
            }


            return Info;
        }

        //public DataTable GetDataTable()
        //{
        //    SqlParameter[] param = new SqlParameter[] 
        //    { 
        //        new SqlParameter("@strWhere",""),
        //        new SqlParameter("@strTableName","u_SendEmail"),
        //        new SqlParameter("@strOrder","order by addtime desc")
        //    };

        //    return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        //}

        #region 删除多个邮件信息
        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="infoIds">记录Id字符串，多个用逗号隔开</param>
        /// <returns></returns>
        public int Deletes(string infoIds)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where E_ID in ("+infoIds+")"),
                new SqlParameter("@strTableName","u_SendEmail")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        #endregion
    }
}
