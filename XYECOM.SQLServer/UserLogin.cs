using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.Core.Data;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core;


namespace XYECOM.SQLServer
{
    /// <summary>
    /// �û���¼��־���ݴ�����
    /// </summary>
    public class UserLogin
    {
        /// <summary>
        /// ����û���¼��Ϣ
        /// </summary>
        /// <param name="el">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.UserLoginInfo el)
        {
            SqlParameter[] param = new SqlParameter[] 
            {                                                      
                new SqlParameter("@U_Id",el.UserId),
                new SqlParameter("@FirstLoginDate",el.FirstLoginDate),
                new SqlParameter("@RegIP",el.RegIP),
                new SqlParameter("@LastLoginDate",el.LastLoginDate),
                new SqlParameter("@LastLoginIP",el.LastLoginIP),
                new SqlParameter("@LoginNum",el.LoginNum) 
		
            };

            string sql = "INSERT INTO XY_UserLoginLog (";
            sql += "U_Id,";
            sql += "FirstLoginDate,";
            sql += "RegIP,";
            sql += "LastLoginDate,";
            sql += "LastLoginIP,";
            sql += "LoginNum) values (";
            sql += "@U_Id,";
            sql += "@FirstLoginDate,";
            sql += "@RegIP,";
            sql += "@LastLoginDate,";
            sql += "@LastLoginIP,";
            sql += "@LoginNum)";

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        /// <summary>
        /// ��ȡ�û��ȼ���Ϣ
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <returns>���ݶ���</returns>
        public Model.UserLoginInfo GetItem(long userId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where U_ID=" + userId.ToString()),
                new SqlParameter("@strTableName","XY_UserLoginLog"),
                new SqlParameter("@strOrder","")
            };

            XYECOM.Model.UserLoginInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.UserLoginInfo();
                    info.UserId = userId;
                    info.FirstLoginDate = reader["FirstLoginDate"].ToString();
                    info.LastLoginDate = reader["LastLoginDate"].ToString();
                    info.LoginNum = Core.MyConvert.GetInt32(reader["Loginnum"].ToString());
                    info.RegIP = reader["regIP"].ToString();
                    info.LastLoginIP = reader["LastLoginIP"].ToString();
                    info.Id = Core.MyConvert.GetInt32(reader["UL_ID"].ToString());
                }
            }

            return info;
        }

        /// <summary>
        /// ��ȡĳ�û���¼��������Ϣ
        /// </summary>
        /// <param name="U_ID">�û����</param>
        /// <returns>��¼��</returns>
        public DataTable GetDataTable(long U_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where U_ID=" + U_ID.ToString()),
                new SqlParameter("@strTableName","XY_UserLoginLog"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }

        /// <summary>
        /// ��ȡ�û���¼��Ϣ
        /// </summary>
        /// <param name="U_ID">�û�Id</param>
        /// <param name="dt">����</param>
        /// <param name="IP">IP</param>
        /// <returns></returns>
        public DataTable GetDataTable(long U_ID, string dt, string IP)
        {
            string WhereClause = "where 1=1";

            if (U_ID.ToString() != "")
            {
                WhereClause += " and U_ID='" + U_ID.ToString() + "'";
            }
            if (dt.ToString() != "")
            {
                WhereClause += " and FirstLoginDate ='" + dt + "'";
            }
            if (IP.ToString() != "")
            {
                WhereClause += " and RegIP ='" + IP.ToString() + "'";
            }

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere",WhereClause),
                new SqlParameter("@strTableName","XY_UserLoginLog"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }

        /// <summary>
        /// ��ȡĳ�û���¼��½����[��������]���޻�Ծ��������ã�
        /// </summary>
        /// <param name="strWhere">strwhere��������</param>
        /// <returns>��¼��</returns>
        public string GetUserLoginNumByDate(string strWhere)
        {
            string num = "";
            string sql = "select count(1) from XY_UserLoginLog " + strWhere;
            num = XYECOM.Core.Data.SqlHelper.ExecuteScalar(sql).ToString();
            return num;

        }

        /// <summary>
        /// ��ȡĳ�û���¼��½����[��������]����Ծ������
        /// </summary>
        /// <param name="where">strwhere��������</param>
        /// <returns>��¼��</returns>
        public DataTable GetUserLoginNumsByDate(string where)
        {
            string sql = string.Format(@"select t.u_id,t.ug_id,t.u_name,t.ui_Name,t.ui_homepage,max(t.LastLoginDate) as LastLoginDate,count(t.u_id) as LoginNum 
                           from (select u_user.u_id,u_user.ug_id,u_user.u_name,UserAuditingState,ui_homepage,ui_Name,LastLoginDate from xy_userloginlog inner join u_user on 
                           xy_userloginlog.u_id = u_user.u_id inner join u_userinfo on u_user.u_id=u_userinfo.u_id {0}) as t 
                           group by t.u_id,t.u_name,t.ui_Name,t.ug_id,t.ui_homepage order by LoginNum Desc,LastLoginDate Desc", where);
            return XYECOM.Core.Data.SqlHelper.ExecuteTable(sql);
        }
    }
}
