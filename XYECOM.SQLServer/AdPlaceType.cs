using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using XYECOM.Core.Data;
using XYECOM.Core;

namespace XYECOM.SQLServer
{

     /// <summary>
     /// ���λ��𹤳���
     /// </summary>
    public class AdPlaceType
    {
        public AdPlaceType() { }
        
        #region ���һ�����λ���
         /// <summary>
         /// ��ӹ��λ���
         /// </summary>
         /// <param name="at">���λ���ʵ����</param>
         /// <param name="at_id">�����ʵ�����IDֵ</param>
         /// <returns>����,����0��ʾ��ӳɹ�</returns>
        public int Insert(XYECOM.Model.AdPlaceTypeInfo at, out int at_id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@AT_ID",SqlDbType.Int),
                new SqlParameter("@AT_Name",at.AT_Name),
                new SqlParameter("@AT_PID",at.AT_PID),
                new SqlParameter("@AT_Alt",at.AT_Alt)
            };

            param[0].Direction = ParameterDirection.Output;

            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertAdPlaceType", param);

            if (param[0].Value.ToString() != null && param[0].Value.ToString() != "")
            {
                at_id = Convert.ToInt32(param[0].Value);
            }
            else
                at_id = -1;

            return rowAffected;
        }
        #endregion

        #region �޸�ָ�����λ�����Ϣ
         /// <summary>
         /// �޸�ָ�����λ�����Ϣ
         /// </summary>
         /// <param name="at">Ҫ�޸ĵ�ָ�����λ����</param>
        /// <returns>���֣����ڻ����0��ʾ�޸ĳɹ�</returns>
        public int Update(XYECOM.Model.AdPlaceTypeInfo at)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@AT_ID",at.AT_ID),
                new SqlParameter("@AT_Name",at.AT_Name),
                new SqlParameter("@AT_PID",at.AT_PID),
                new SqlParameter("@AT_Alt",at.AT_Alt)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateAdPlaceType", param);
        }
        #endregion

        #region ɾ��ָ�����λ�����Ϣ
         /// <summary>
         /// ɾ��ָ���Ĺ��λ�����Ϣ
         /// </summary>
         /// <param name="at_ids">Ҫɾ���Ĺ��λ���ID��</param>
         /// <returns>���֣����ڻ����0��ɾ���ɹ�</returns>
        public int Delete(string at_ids)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere","where AT_ID in("+at_ids+")"),
                new SqlParameter("@strTableName","b_AdPlaceType")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        #endregion

        #region �жϸ���������Ƿ��������
        /// <summary>
        /// ����ID�ж�Ҫɾ����������Ƿ��������
        /// </summary>
        /// <param name="at_ids">ָ����IDֵ</param>
        /// <returns>����,����0��ʾ���������,����0��ʾ�������</returns>
        public int GetSonType(string at_ids)
        {
            string strWhere = "where AT_PID in("+at_ids+")";
            string strTableName = "b_AdPlaceType";

            return Function.GetRows(strTableName, "AT_ID", strWhere);
        }
        #endregion

        #region ���ָ���Ĺ��λ����DataTable
        /// <summary>
         /// ���ָ����DataTable���͵Ĺ��λ���
         /// </summary>
         /// <param name="strWhere">ָ���Ĺ��λ���</param>
        /// <param name="strOrderBy">ָ���Ĺ��λ��������Ϣ</param>
         /// <returns>DataTable���͵����������Ĺ��λ�����Ϣ</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","b_AdPlaceType"),
                new SqlParameter("@strOrder",strOrderBy)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", param);
        }
        #endregion
        
        #region ���ݹ��λ���ID��ȡ�ù��λ��������
        /// <summary>
        /// ���ݹ��λID��ȡ�ù��λ������
         /// </summary>
         /// <param name="atid">���λID</param>
         /// <returns>�ù��λID��Ӧ�Ĺ��λ����</returns>
        public string GetAdPlaceTypeName(int atid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere","where AT_ID="+atid.ToString()),
                new SqlParameter("@strTableName","b_AdPlaceType"),
                new SqlParameter("@strOrder","")
            };
            string AdPlaceTypeName = "";
            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure,"XYP_SelectByWhere", param))
            {
                if (dr.Read())
                {
                    AdPlaceTypeName = dr["AT_Name"].ToString();
                }
            }
            return AdPlaceTypeName;
        }
        #endregion

        #region ���ݹ�������ID��ȡ�ù������������
        /// <summary>
        /// ���ݹ��λID��ȡ�ù��λ������
        /// </summary>
        /// <param name="atid">���λID</param>
        /// <returns>�ù��λID��Ӧ�Ĺ��λ����</returns>
        public string GetAdPlaceTypeNames(int atid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere","where AP_ID="+atid.ToString()),
                new SqlParameter("@strTableName","b_AdPlaceInfo"),
                new SqlParameter("@strOrder","")
            };
            string AdPlaceTypeName = "";
            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure,"XYP_SelectByWhere", param))
            {
                if (dr.Read())
                {
                    AdPlaceTypeName = dr["AP_Name"].ToString();
                }
            }
            return AdPlaceTypeName;
        }
        #endregion
    }

}
