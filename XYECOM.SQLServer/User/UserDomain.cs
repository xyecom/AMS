using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace XYECOM.SQLServer
{
    /// <summary>
    /// ���궥���������ݴ�����
    /// </summary>
    public class UserDomain:DataCache
    {
        /// <summary>
        /// ����(����)
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Update(Model.UserDomainInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            {                                                      
                new SqlParameter("@UserId",info.UserId),
                new SqlParameter("@Domain",info.Domain),
                new SqlParameter("@ICPInfo",info.ICPInfo),
                new SqlParameter("@AuditingState",info.IntState)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateUserDomain", param);
        }

        /// <summary>
        /// ��ȡָ���û�Id��������Ϣ
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <returns></returns>
        public Model.UserDomainInfo GetItem(long userId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where UserId=" + userId),
                new SqlParameter("@strTableName","XY_UserDomain"),
                new SqlParameter("@strOrder","")
            };

            XYECOM.Model.UserDomainInfo info = null;
            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info= new XYECOM.Model.UserDomainInfo();

                    info.InfoId = XYECOM.Core.MyConvert.GetInt64(reader["InfoId"].ToString()); ;
                    info.UserId = XYECOM.Core.MyConvert.GetInt64(reader["UserId"].ToString());
                    info.Domain = reader["Domain"].ToString();
                    info.ICPInfo = reader["ICPInfo"].ToString();
                    info.IntState = XYECOM.Core.MyConvert.GetInt16(reader["AuditingState"].ToString());
                }
            }
            return info;
        }

        /// <summary>
        /// ��ȡָ����������Ϣ
        /// </summary>
        /// <param name="domain">����</param>
        /// <returns></returns>
        public Model.UserDomainInfo GetItem(string domain)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where Domain='" + domain + "'"),
                new SqlParameter("@strTableName","XY_UserDomain"),
                new SqlParameter("@strOrder","")
            };

            XYECOM.Model.UserDomainInfo info = null;
            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.UserDomainInfo();

                    info.InfoId = XYECOM.Core.MyConvert.GetInt64(reader["InfoId"].ToString()); ;
                    info.UserId = XYECOM.Core.MyConvert.GetInt64(reader["UserId"].ToString());
                    info.Domain = reader["Domain"].ToString();
                    info.ICPInfo = reader["ICPInfo"].ToString();
                    info.IntState = XYECOM.Core.MyConvert.GetInt16(reader["AuditingState"].ToString());
                }
            }
            return info;
        }

        /// <summary>
        /// ɾ��ָ���û��Ķ���������Ϣ
        /// </summary>
        /// <param name="userId">�û�id</param>
        /// <returns></returns>
        public int Delete(long userId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where UserId="+userId),
                new SqlParameter("@strTableName","XY_UserDomain")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
    
        /// <summary>
        /// 
        /// </summary>
        public override string  SQL_Get_All
        {
	        get { return "select * from XY_UserDomain"; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int Deletes(string ids)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where InfoId in (" + ids + ")"),
                new SqlParameter("@strTableName","XY_UserDomain")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
    }
}
