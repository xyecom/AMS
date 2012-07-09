using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;
using XYECOM.Core;


namespace XYECOM.SQLServer
{
    /// <summary>
    /// ����Ա��ɫ���ݴ�����
    /// </summary>
    public class Role
    {
        /// <summary>
        /// ��ӽ�ɫ
        /// </summary>
        /// <param name="er">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.RoleInfo er)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@value",er.UR_Name),
                new SqlParameter("@TableName","b_Role")
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertRole", param);          
        }
        
        /// <summary>
        /// �޸Ľ�ɫ��Ϣ
        /// </summary>
        /// <param name="er">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.RoleInfo er)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@ID",er.UR_ID),
                new SqlParameter("@value",er.UR_Name),
                new SqlParameter("@TableName","b_Role")
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_Update", param);
        }

        /// <summary>
        /// ɾ����ɫ
        /// </summary>
        /// <param name="UR_ID">��ɫ���</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(int UR_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where UR_ID="+UR_ID.ToString()),
                new SqlParameter("@strTableName","b_Role")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
       
        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="UR_ID">��¼���</param>
        /// <returns>һ����¼</returns>
        public XYECOM.Model.RoleInfo GetItem(int UR_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where UR_ID=" + UR_ID.ToString()),
                new SqlParameter("@strTableName","b_Role"),
                new SqlParameter("@strOrder","")
            };

            XYECOM.Model.RoleInfo Info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader( CommandType.StoredProcedure,"XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    Info = new XYECOM.Model.RoleInfo();

                    Info.UR_ID = short.Parse(reader["UR_ID"].ToString());
                    Info.UR_Name = reader["UR_Name"].ToString();
                }
            }

            return Info;
        }
        
        /// <summary>
        /// ��ȡ���м�¼
        /// </summary>
        /// <returns>��¼��</returns>
        public DataTable GetDataTable()
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere",""),
                new SqlParameter("@strTableName","b_Role"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", param);
        }        
    }
}
