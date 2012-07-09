using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;
using XYECOM.Core;

namespace XYECOM.SQLServer
{

    #region ��淽��������
    /// <summary>
    /// ƽ̨������ݴ�����
    /// </summary>
    public class Ad
    {
        /// <summary>
        /// ��ӹ������Ϣ
        /// </summary>
        /// <param name="ad">Ҫ��ӵĹ��������</param>
        /// <returns>���֣����ڻ����0����ӳɹ�</returns>
        public int Insert(XYECOM.Model.AdInfo ad, out int AD_ID)
        {
            SqlParameter[] param = new SqlParameter[]
			{
				new SqlParameter("@AD_ID",SqlDbType.BigInt),
				new SqlParameter("@AD_Name",ad.AD_Name),
				new SqlParameter("@AP_ID",ad.AP_ID),
				new SqlParameter("@AD_LinkURL",ad.AD_LinkURL),
				new SqlParameter("@AD_Type",ad.AD_Type),
				new SqlParameter("@AD_OpenType",ad.AD_OpenType),
				new SqlParameter("@AD_NoteText",ad.AD_NoteText),
				new SqlParameter("@AD_PicURL",ad.AD_PicURL),
				new SqlParameter("@AD_Alt",ad.AD_Alt),
                new SqlParameter("@AD_Width",ad.AD_Width),
                new SqlParameter("@AD_High",ad.AD_High),
                new SqlParameter("@AD_Letter",ad.AD_Letter),
                new SqlParameter("@AD_Font",ad.AD_Font),
                new SqlParameter("@AD_Size",ad.AD_Size),
                new SqlParameter("@AD_Color",ad.AD_Color),
                new SqlParameter("@AD_JSname",ad.AD_JSname),
                new SqlParameter("@AD_CodeContent",ad.AD_CodeContent),
                new SqlParameter("@Ad_StartDate",ad.Ad_StartDate),
                new SqlParameter("@Ad_EndDate",ad.Ad_EndDate)
        	};

            param[0].Direction = ParameterDirection.Output;
            int row = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertAdInfo", param);

            if (param[0].Value != null && param[0].Value.ToString() != "")
            {
                AD_ID = Convert.ToInt32(param[0].Value);
            }
            else
                AD_ID = -1;

            return row;
        }
        /// <summary>
        /// �޸�ָ���Ĺ������Ϣ����
        /// </summary>
        /// <param name="ad">��Ҫ�޸ĵĹ��������</param>
        /// <returns>���֣����ڻ����0����ӳɹ�</returns>
        public int Update(XYECOM.Model.AdInfo ad)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@AD_ID",ad.AD_ID),
                new SqlParameter("@AD_Name",ad.AD_Name),
                new SqlParameter("@AP_ID",ad.AP_ID),
                new SqlParameter("@AD_LinkURL",ad.AD_LinkURL),
                new SqlParameter("@AD_Type",ad.AD_Type),
                new SqlParameter("@AD_OpenType",ad.AD_OpenType),
                new SqlParameter("@AD_NoteText",ad.AD_NoteText),
                new SqlParameter("@AD_PicURL",ad.AD_PicURL),
                new SqlParameter("@AD_Alt",ad.AD_Alt),
                new SqlParameter("@AD_Width",ad.AD_Width),
                new SqlParameter("@AD_High",ad.AD_High),
                new SqlParameter("@AD_Letter",ad.AD_Letter),
                new SqlParameter("@AD_Font",ad.AD_Font),
                new SqlParameter("@AD_Size",ad.AD_Size),
                new SqlParameter("@AD_Color",ad.AD_Color),
                new SqlParameter("@AD_JSname",ad.AD_JSname),
                new SqlParameter("@AD_CodeContent",ad.AD_CodeContent),
                new SqlParameter("@Ad_EndDate",ad.Ad_EndDate)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateAdInfo", param);
        }
        /// <summary>
        /// ɾ��ָ���Ĺ��
        /// </summary>
        /// <param name="adid">ָ�����ı��</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(string adid)
        {
            SqlParameter[] param = new SqlParameter[]
			{
				new SqlParameter("@strwhere","where AD_ID in ("+adid+")"),
				new SqlParameter("@strTableName","b_AdInfo")
			};

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        /// <summary>
        /// �õ�ָ��������DataTable���͵Ĺ��
        /// </summary>
        /// <param name="strWhere">ָ����where��ѯ����</param>
        /// <param name="strOrderBy">ָ������������</param>
        /// <returns>����������DataTable���͵Ĺ���¼</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            SqlParameter[] param = new SqlParameter[]
			{
				new SqlParameter("@strWhere",strWhere),
				new SqlParameter("@strTableName","XYV_AdInfo"),
				new SqlParameter("@strOrder",strOrderBy)
			};

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", param);
        }
        /// <summary>
        /// ����ָ�������������״̬
        /// </summary>
        /// <param name="AP_ID">ָ�����λ��ID</param>
        /// <param name="AP_IsUse">Ҫ���ĵĹ��λ״̬</param>
        /// <returns>���֣����ڻ����0����ĳɹ�</returns>
        public int UpdateForIsUse(string AD_IDs, bool AD_Isuse)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@AD_IDs",AD_IDs),
                new SqlParameter("@AD_Isuse",AD_Isuse)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateAdForIsUse", param);
        }



    }

    #endregion
}