using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using XYECOM.Core.Data;
using XYECOM.SQLServer;
using System.Data;
using XYECOM.Core;


namespace XYECOM.SQLServer
{
    /// <summary>
    /// ��վ�������ݴ�����
    /// </summary>
    public class UserAnnounce
    {
        /// <summary>
        /// ����һ�����߸���һ����վ���������
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertAndUpdate(XYECOM.Model.UserAnnounceInfo info)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Centent",info.Centent),
                new SqlParameter("@UserID",info.UserID)
            };
            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertAndUpdateUserAnnounce", parm);
        }
        /// <summary>
        /// ��ѯ��վ����
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Model.UserAnnounceInfo GetItem(long userId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," where UserID="+userId .ToString ()),
                new SqlParameter("@strTableName","XY_UserAnnounce"),
                new SqlParameter("@strOrder","")
            };
            XYECOM.Model.UserAnnounceInfo info = null;
            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.UserAnnounceInfo();
                    info.AnnounceID = Core.MyConvert.GetInt32(reader["AnnounceID"].ToString());
                    info.Centent = reader["Centent"].ToString();
                    info.UserID = Convert.ToInt32(reader["UserID"].ToString());
                   
                }
            }
            return info;
        }

        
        /// <summary>
        /// ɾ����վ���������
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public int Delete(string infoId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where AnnounceID="+infoId),
                new SqlParameter("@strTableName","XY_UserAnnounce")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        /// <summary>
        /// ��ȡ��վ�����б�
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="strOrderBy"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","XY_UserAnnounce"),
                new SqlParameter("@strOrder",strOrderBy)
            };
            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }
    }
}