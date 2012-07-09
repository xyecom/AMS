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
    /// ��ǩ�������ݴ�����
    /// </summary>
    public class LabelType
    {
        #region ��ӱ�ǩ���
        /// <summary>
        /// ��ӱ�ǩ���
        /// </summary>
        /// <param name="elt">��ǩ������������</param>
        /// <returns>���֡�����0��ʾ��ӳɹ�</returns>
        public int Insert(XYECOM.Model.LabelTypeInfo elt)
        {
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@LT_Name",elt.LT_Name),
                new SqlParameter("@LT_ParentID",elt.LT_ParentID),
                new SqlParameter("@LT_Remark",elt.LT_Remark),

            };

            int err = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[XYP_InsertLabelType]", parm);

            return err;
        }
        #endregion

        #region �޸ı�ǩ���
        /// <summary>
        /// �޸ı�ǩ���
        /// </summary>
        /// <param name="elt">��ǩ������������</param>
        /// <returns>���֡�����0��ʾ�޸ĳɹ�</returns>
        public int Update(XYECOM.Model.LabelTypeInfo elt)
        {
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@LT_ID",elt.LT_ID),
                new SqlParameter("@LT_Name",elt.LT_Name),
                new SqlParameter("@LT_ParentID",elt.LT_ParentID),
                new SqlParameter("@LT_Remark",elt.LT_Remark),

            };

            int err = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[XYP_UpdateLabelType]", parm);

            return err;
        }
        #endregion

        #region ɾ����ǩ���
        /// <summary>
        /// ɾ����ǩ���
        /// </summary>
        /// <param name="LT_ID">��ǩ�����</param>
        /// <returns></returns>
        public int Delete(int LT_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where LT_ID="+LT_ID.ToString()),
                new SqlParameter("@strTableName","b_LabelType")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        #endregion

        #region ��ȡ��ǩ���
        /// <summary>
        /// ��ȡָ���������
        /// </summary>
        /// <param name="LT_ID">�����</param>
        /// <returns>�������</returns>
        public string GetLTName(int LT_ID)
        {
            string  elt = "";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where LT_ID=" + LT_ID.ToString()),
                new SqlParameter("@strTableName","b_LabelType"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure,"XYP_SelectByWhere", param))
            {
                if (dr.Read())
                {
                    elt = dr["LT_Name"].ToString();
                }
            }

            return elt;
        }

        /// <summary>
        /// ��ȡָ�������Ϣ
        /// </summary>
        /// <param name="LT_ID">�����</param>
        /// <returns>�����Ϣ</returns>
        public XYECOM.Model.LabelTypeInfo GetItem(int LT_ID)
        {
            XYECOM.Model.LabelTypeInfo elt = null;

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where LT_ID=" + LT_ID.ToString()),
                new SqlParameter("@strTableName","b_LabelType"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure,"XYP_SelectByWhere", param))
            {                   
                if (dr.Read())
                {
                    elt = new XYECOM.Model.LabelTypeInfo();

                    elt.LT_ID = LT_ID;
                    elt.LT_Name = dr["LT_Name"].ToString();
                    elt.LT_Remark = dr["LT_Remark"].ToString();
                }
            }
               
            return elt;
        }

        /// <summary>
        /// ��ȡָ�������������Ϣ
        /// </summary>
        /// <param name="strWhere">ɸѡ����</param>
        /// <returns>�����Ϣ��</returns>
        public DataTable GetDataTable(string strWhere)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","b_LabelType"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", param);
        }
        #endregion
    }
}
