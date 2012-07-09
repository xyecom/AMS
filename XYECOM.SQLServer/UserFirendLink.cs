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
    /// �û������������ݴ�����
    /// </summary>
    public class UserFirendLink
    {
        #region �����������
        /// <summary>
        /// ����һ���������ӵ�����
        /// </summary>
        /// <param name="info">���ݶ���</param>
        /// <returns>Ӱ������</returns>
        public int Insert(XYECOM.Model.UserFirendLinkinfo info)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Url",info.Url),
                new SqlParameter("@LogoUrl",info.LogoUrl),
                new SqlParameter("@SiteName",info.SiteName),
                new SqlParameter("@UserID",info.UserID),
            };
            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertUserFriendLink", parm);
        }
        #endregion

        #region ��ѯ��������

        #region ��������ѯ��������

        /// <summary>
        /// ��������ѯ��������������
        /// </summary>
        /// <param name="userId">�û�id</param>
        /// <returns>���ݶ���</returns>
        public Model.UserFirendLinkinfo GetItem(long userId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," where UserID="+userId .ToString ()),
                new SqlParameter("@strTableName","XY_UserFirendLink"),
                new SqlParameter("@strOrder","")
            };
            XYECOM.Model.UserFirendLinkinfo info = null;
            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                { 
                    info = new XYECOM.Model.UserFirendLinkinfo();
                    info.LinkId = Core.MyConvert.GetInt32(reader["LinkId"].ToString());
                    info.Url = reader["Url"].ToString();
                    info.LogoUrl = reader["LogoUrl"].ToString();
                    info.SiteName =reader["SiteName"].ToString();
                    info.UserID = Core.MyConvert.GetInt64(reader["UserID"].ToString());
                }   
            }
            return info;
        }
        #endregion

        #region ��linkID��ѯ��������
        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="linkid">���Ӽ�¼Id</param>
        /// <returns>���ݶ���</returns>
        public Model.UserFirendLinkinfo GetItem(int linkid)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," where linkid="+linkid.ToString ()),
                new SqlParameter("@strTableName","XY_UserFirendLink"),
                new SqlParameter("@strOrder","")
            };
            XYECOM.Model.UserFirendLinkinfo info = null;
            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.UserFirendLinkinfo();
                    info.LinkId = Core.MyConvert.GetInt32(reader["LinkId"].ToString());
                    info.Url = reader["Url"].ToString();
                    info.LogoUrl = reader["LogoUrl"].ToString();
                    info.SiteName = reader["SiteName"].ToString();
                    info.UserID = Core.MyConvert.GetInt64(reader["UserID"].ToString());
                }
            }
            return info;
        }
        #endregion

        #region ��UserID��ѯ��������
        /// <summary>
        /// ��ȡ���������б�
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <returns></returns>
        public DataTable GetDataTable(long userId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere","where userId=" + userId),
                new SqlParameter("@strTableName","XY_UserFirendLink"),
                new SqlParameter("@strOrder","order by linkId desc")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }
        #endregion

        #endregion

        #region �޸���������
        /// <summary>
        /// �����������ӵ�����
        /// </summary>
        /// <param name="info">���ݶ���</param>
        /// <returns></returns>
        public int Update(XYECOM.Model.UserFirendLinkinfo info)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@LinkId",info.LinkId),
                new SqlParameter ("@Url",info.Url),
                new SqlParameter ("@LogoUrl",info.LogoUrl),
                new SqlParameter ("@SiteName",info.SiteName),
                new SqlParameter ("UserID",info.UserID),
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateUserFriendLink", parm);
        }
        #endregion

        #region ɾ����������
        /// <summary>
        /// ɾ���������ӵ�����
        /// </summary>
        /// <param name="LinkId">��¼id�ַ���������ö��Ÿ���</param>
        /// <returns>Ӱ������</returns>
        public int Delete(string linkId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where LinkId in ("+linkId+")"),
                new SqlParameter("@strTableName","XY_UserFirendLink")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        #endregion
    }
}
