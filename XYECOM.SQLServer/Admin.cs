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
    /// ϵͳ����Ա���ݴ�����
    /// </summary>
    public class Admin
    {
        /// <summary>
        /// ��ӹ���Ա��Ϣ
        /// </summary>
        /// <param name="ea">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.AdminInfo ea)
        {
            SqlParameter[] param = new SqlParameter[] 
            {                                                      
                new SqlParameter("@UM_Pwd",ea.UM_Pwd),
                new SqlParameter("@UM_Name",ea.UM_Name),
                new SqlParameter("@UR_ID",ea.UR_ID)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertAdmin", param);
        }

        /// <summary>
        /// �޸Ĺ���Ա��Ϣ
        /// </summary>
        /// <param name="ea">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.AdminInfo ea)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@UM_ID",ea.UM_ID),         
                new SqlParameter("@UM_Pwd",ea.UM_Pwd),
                new SqlParameter("@UR_ID",ea.UR_ID)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateAdmin", param);
        }

        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="UM_ID">��¼���</param>
        /// <returns>һ����¼</returns>
        public XYECOM.Model.AdminInfo GetItem(int adminId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where UM_ID=" + adminId.ToString()),
                new SqlParameter("@strTableName","b_Admin"),
                new SqlParameter("@strOrder","")
            };
            XYECOM.Model.AdminInfo info = null;
            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.AdminInfo();

                    info.UM_ID = XYECOM.Core.MyConvert.GetInt32(reader["UM_ID"].ToString());
                    info.UM_Name = reader["UM_Name"].ToString();
                    info.UM_Pwd = reader["UM_Pwd"].ToString();
                    info.UR_ID = XYECOM.Core.MyConvert.GetInt32(reader["UR_ID"].ToString());
                }
            }
            return info;
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
                new SqlParameter("@strTableName","b_Admin"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        /// <param name="UM_ID">��¼���</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(int UM_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where UM_ID="+UM_ID.ToString()),
                new SqlParameter("@strTableName","b_Admin")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }


        /// <summary>
        /// У���û��������Ƿ���ȷ
        /// </summary>
        /// <param name="UserName">�û�����</param>
        /// <param name="Password">�û�����</param>
        /// <returns>�������ʾ�û�����������ȷ��</returns>
        public int isMyUser(string UserName, string Password)
        {
            SqlParameter[] Param = new SqlParameter[] 
            { 
                new SqlParameter("@UserName",UserName),
                new SqlParameter ("@Password",Password)
            };

            object obj = XYECOM.Core.Data.SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "XYP_CheckAdmin", Param);

            if (obj == null) return 0;

            return (int)obj;
        }


        /// <summary>
        /// ͨ���û���ȡ���ݶ���
        /// </summary>
        /// <param name="userName">�û���</param>
        /// <returns>����Ա���ݶ���</returns>
        public XYECOM.Model.AdminInfo GetItem(string userName)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where UM_Name='" + userName.ToString()+"'"),
                new SqlParameter("@strTableName","b_Admin"),
                new SqlParameter("@strOrder","")
            };
            XYECOM.Model.AdminInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.AdminInfo();

                    info.UM_ID = XYECOM.Core.MyConvert.GetInt32(reader["UM_ID"].ToString());
                    info.UM_Name = reader["UM_Name"].ToString();
                    info.UM_Pwd = reader["UM_Pwd"].ToString();
                    info.UR_ID = XYECOM.Core.MyConvert.GetInt32(reader["UR_ID"].ToString());
                }
            }

            return info;
        }

    }
}
