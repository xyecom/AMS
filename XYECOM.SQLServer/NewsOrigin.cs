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
    /// ��Ѷ��Դ���ݴ�����
    /// </summary>
    public class NewsOrigin
    {
        #region ���������Դ
        /// <summary>
        /// ���������Դ��Ϣ
        /// </summary>
        /// <param name="no">Ҫ��ӵ�������Դ����</param>
        /// <param name="no_id">��ӳɹ����������Դ�����ڱ��е�IDֵ</param>
        /// <returns>���֣����ڻ����0����ӳɹ�</returns>
        public int Insert(XYECOM.Model.NewsOriginInfo no, out int no_id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NO_ID",SqlDbType.Int),
                new SqlParameter("@NO_Name",no.NO_Name)
            };

            param[0].Direction = ParameterDirection.Output;
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertNewsOrigin", param);

            if (param[0].Value.ToString() != "" && param[0].Value.ToString() != null)
            {
                no_id = Convert.ToInt32(param[0].Value);
            }
            else
            {
                no_id = -1;
            }
            return rowAffected;
        }
        #endregion

        #region �޸�ָ����������Դ
        /// <summary>
        /// �޸�ָ����������Դ��Ϣ
        /// </summary>
        /// <param name="no">Ҫ�޸ĵ�������Դ��Ϣ����</param>
        /// <returns>���֣����ڻ����0���޸ĳɹ�</returns>
        public int Update(XYECOM.Model.NewsOriginInfo no)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NO_ID",no.NO_ID),
                new SqlParameter("@NO_Name",no.NO_Name)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateNewsOrigin", param);
        }
        #endregion

        #region �õ�����������������Դ��ϢDataTable�б�
        /// <summary>
        /// �õ�����������������Դ��Ϣ����
        /// </summary>
        /// <param name="strWhere">ָ����Where��ѯ����</param>
        /// <param name="strOrderBy">ָ������������</param>
        /// <returns>����������������Դ��Ϣ����</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","n_NewsOrigin"),
                new SqlParameter("@strOrder",strOrderBy)
            };
            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }
        #endregion

        #region ɾ��ָ����������Դ��Ϣ����
        /// <summary>
        /// ɾ��ָ����������Դ��Ϣ
        /// </summary>
        /// <param name="no_ids">ָ����������Դ��Ϣ����IDֵ</param>
        /// <returns>���֣����ڻ����0��ɾ���ɹ�</returns>
        public int Delete(string no_ids)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strwhere","where NO_ID in ("+no_ids+")"),
                new SqlParameter("@strTableName","n_NewsOrigin")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("ups_DeleteByWhere", param);
        }
        #endregion
    }
}
