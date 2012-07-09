using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// �û��������ݴ�����
    /// </summary>
    public class UserData
    {
        #region IUserData ��Ա

        /// <summary>
        /// �����¼
        /// </summary>
        /// <param name="userdata">�û����ݶ���</param>
        /// <returns>Ӱ������</returns>
        public int Insert(XYECOM.Model.UserData userdata)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@uid",userdata.Uid),
                new SqlParameter("@companyids",userdata.Companyids)
            };
            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertUserData", parm);
        }

        /// <summary>
        /// ���¾�·
        /// </summary>
        /// <param name="userdata">���ݶ���</param>
        /// <returns>Ӱ������</returns>
        public int Update(XYECOM.Model.UserData userdata)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@uid",userdata.Uid),
                new SqlParameter("@companyids",userdata.Companyids)
            };
            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateUserData", parm);
        }

        /// <summary>
        /// ��ȡ�û�����
        /// </summary>
        /// <param name="uid">�û�id</param>
        /// <returns>Ӱ������</returns>
        public XYECOM.Model.UserData GetItem(Int64 uid)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@strwhere"," where uid="+ uid),
                new SqlParameter ("@strTableName","xy_userdata"),
                new SqlParameter ("@strOrder","")
            };

            Model.UserData info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", parm))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.UserData();

                    info.Id = XYECOM.Core.MyConvert.GetInt32(reader["id"].ToString());

                    info.Uid = XYECOM.Core.MyConvert.GetInt32(reader["uid"].ToString());

                    info.Companyids = reader["companyids"].ToString();
                }
            }
            return info;
        }

        #endregion
    } 
}
