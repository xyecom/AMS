using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using XYECOM.Model;
using XYECOM.Core.Data;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// ��Ѷ�������ݴ�����
    /// </summary>
    public class NewsDiscuss
    {
        #region ���������
        /// <summary>
        /// ����µ���������
        /// </summary>
        /// <param name="nd">Ҫ��ӵ����۶���</param>
        /// <param name="ndid">��������Ӻ�ı��</param>
        /// <returns>����,���ڻ����0����ӳɹ�,�������ʧ��.</returns>
        public int Insert(NewsDiscussInfo nd)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@U_ID",nd.U_ID),
                new SqlParameter("@U_Name",nd.U_Name),
                new SqlParameter("@NS_ID",nd.NS_ID),
                new SqlParameter("@ND_Content",nd.ND_Content),
                new SqlParameter("@ND_IsShow",nd.ND_IsShow),
                new SqlParameter("@IPAddress",nd.IpAddress),
                new SqlParameter("@IPIsShow",nd.IpIsShow)
            };

            int rowAffected = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertNewsDiscuss", param);

            return rowAffected;
        }
        #endregion

        #region �޸���������
        /// <summary>
        /// �޸��������۶���
        /// </summary>
        /// <param name="nd">Ҫ�޸ĵ��������۶���</param>
        /// <returns>����,���ڻ����0���޸ĳɹ�,����ʧ��</returns>
        public int Update(NewsDiscussInfo nd)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ND_ID",nd.ND_ID),
                new SqlParameter("@U_ID",nd.U_ID),
                new SqlParameter("@U_Name",nd.U_Name),
                new SqlParameter("@NS_ID",nd.NS_ID),
                new SqlParameter("@NS_Content",nd.ND_Content),
                new SqlParameter("@ND_AddTime",nd.ND_AddTime),
                new SqlParameter("@ND_IsShow",nd.ND_IsShow),
                new SqlParameter("@IPAddress",nd.IpAddress),
                new SqlParameter("@IPIsShow",nd.IpIsShow)
            };

            int rowAffected = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateNewsDiscuss", param);
            return rowAffected;
        }
        #endregion

        #region ��ȡָ���������������۵�DataTable
        /// <summary>
        /// ��ȡָ���������������۵�DataTable
        /// </summary>
        /// <param name="strWhere">ָ����Where����</param>
        /// <param name="strOrderBy">ָ����OrderBy����</param>
        /// <returns>�����������������۵�DataTable</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","n_NewsDiscuss"),
                new SqlParameter("@strOrder",strOrderBy)
            };

            return XYECOM.Core.Data.SqlHelper.GetDataTable("XYP_SelectByWhere", param);
        }
        #endregion

        #region ��ȡָ����ŵ����۶���
        /// <summary>
        /// ��ȡָ����ŵ����۶���
        /// </summary>
        /// <param name="ndid">ָ�������۱��</param>
        /// <returns>�ñ�ŵ����۶���</returns>
        public NewsDiscussInfo GetItem(Int64 ndid)
        {
            NewsDiscussInfo newsdiscuss = null;

            SqlParameter [] parm = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," Where ND_ID="+ndid.ToString()),
                new SqlParameter("@strTableName","n_NewsDiscuss"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", parm))
            {
                if (rdr.Read())
                    newsdiscuss = new NewsDiscussInfo(Convert.ToInt64(rdr["ND_ID"]),
                                                      Convert.ToInt64(rdr["U_ID"]),
                                                      rdr["U_Name"].ToString(),
                                                      Convert.ToInt64(rdr["NS_ID"]),
                                                      rdr["ND_Content"].ToString(),
                                                      Convert.ToDateTime(rdr["ND_AddTime"]),
                                                      Convert.ToBoolean(rdr["ND_IsShow"]),
                                                      rdr["IPAddress"].ToString(),
                                                      Convert.ToBoolean(rdr["IPIsShow"]));
            }

            return newsdiscuss;
        }
        #endregion

        #region ɾ��ָ����ŵ���������
        /// <summary>
        /// ɾ��ָ����ŵ���������
        /// </summary>
        /// <param name="ndids">Ҫɾ�����������۵ı��</param>
        /// <returns>����,���ڵ���0��ɾ���ɹ�,����ɾ��ʧ��.</returns>
        public int Delete(string ndids)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@strWhere","where ND_ID in ("+ndids+")"),
                new SqlParameter("@strTableName","n_NewsDiscuss")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        #endregion

        #region ���������Ƿ���ʾ
        /// <summary>
        /// ����������ʾ״̬
        /// </summary>
        /// <param name="ndid">Ҫ���ĵ����۱��</param>
        /// <param name="IsShow">Ҫ���ĵ���ʾ״̬</param>
        /// <returns>����,���ڵ���0����ĳɹ�,�������ʧ��.</returns>
        public int SetIsShow(Int64 ndid, bool IsShow)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ND_ID",ndid),
                new SqlParameter("@ND_IsShow",IsShow)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateNewsDiscussIsShow", param);
        }
        #endregion

        #region ��ȡǰn����������
        /// <summary>
        /// ��ȡǰn����������
        /// </summary>
        /// <param name="strWhere">ָ����where����</param>
        /// <param name="strOrderBy">ָ������������</param>
        /// <param name="strTableName">ָ�������ݱ�����</param>
        /// <param name="strColumuName">ָ�����ֶ�</param>
        /// <param name="TopNum">Ҫ��ȡ��ǰn����Ŀ</param>
        /// <returns>����������DataTable���͵ļ�¼</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy, string strColumuName, int TopNum)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strOrder",strOrderBy),
                new SqlParameter("@strTableName"," XYV_NewsDiscuss "),
                new SqlParameter("@strColumuName",strColumuName),
                new SqlParameter("@strTopNum",TopNum)
            };

            return XYECOM.Core.Data.SqlHelper.GetDataTable("XYP_GetTopByWhere", param);
        }
        #endregion
    }
}
