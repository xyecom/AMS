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
    /// ��Ѷ�������ݴ�����
    /// </summary>
    public class NewsAuthor
    {
        #region �����¼
         /// <summary>
        /// �����������߲���
         /// </summary>
         /// <param name="na">�������߶���</param>
         /// <param name="na_id">����������ߺ�ö����IDֵ</param>
         /// <returns>���֣����ڻ����0��ʾ��ӳɹ�</returns>
        public int Insert(XYECOM.Model.NewsAuthorInfo na, out int na_id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NA_ID",SqlDbType.Int),
                new SqlParameter("@NA_Name",na.NA_Name)
            };

            param[0].Direction = ParameterDirection.Output;

            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertNewsAuthor", param);

            if (param[0].Value.ToString() != null && param[0].Value.ToString() != "")
            {
                na_id = Convert.ToInt32(param[0].Value);
            }
            else
            {
                na_id = -1;
            }

            return rowAffected;
        }
        #endregion

        #region �޸�����������Ϣ
        /// <summary>
        /// �޸�����������Ϣ����
        /// </summary>
        /// <param name="na">Ҫ�޸ĵ�������Ϣ����</param>
        /// <returns>���֣����ڻ��ߵ���0��ʾ�޸ĳɹ�</returns>
        public int Update(XYECOM.Model.NewsAuthorInfo na)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NA_ID",na.NA_ID),
                new SqlParameter("@NA_Name",na.NA_Name)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateNewsAuthor", param);
        }
        #endregion

        #region ��ȡ����
        /// <summary>
        /// �õ�����ָ����������������DataTable
        /// </summary>
        /// <param name="strWhere">ָ���Ĳ�ѯ����</param>
        /// <param name="strOrderBy">ָ������������</param>
        /// <returns>����������DataTable������������Ϣ</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","n_NewsAuthor"),
                new SqlParameter("@strOrder",strOrderBy)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }
        #endregion

        #region ɾ����¼
        /// <summary>
        /// ɾ��ָ��������������Ϣ
        /// </summary>
        /// <param name="na_ids">ָ������������IDֵ</param>
        /// <returns>���֣����ڻ����0��ʾɾ���ɹ�</returns>
        public int Delete(string na_ids)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strwhere","where NA_ID in("+na_ids+")"),
                new SqlParameter("@strTableName","n_NewsAuthor")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        #endregion
    }
}
