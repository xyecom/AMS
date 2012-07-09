using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    #region ��̬ҳ��������Ϣ���ݿ������
    /// <summary>
    /// ��̬ҳ��������Ϣ���ݿ⴦����
    /// </summary>
    public class HTMLPageSet
    {
        #region ��Ӿ�̬ҳ��������Ϣ
        /// <summary>
        /// ��Ӿ�̬ҳ��������Ϣ
        /// </summary>
        /// <param name="ehps">��̬ҳ��������Ϣ���������</param>
        /// <returns>���֡�����0��ʾ���óɹ�</returns>
        public int Insert(XYECOM.Model.HtmlPageSetInfo ehps)
        {
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@HPS_Index",ehps.HPS_Index),
                new SqlParameter("@HPS_Indextime",ehps.HPS_Indextime),
                new SqlParameter("@HPS_Supply",ehps.HPS_Supply ),
                new SqlParameter("@HPS_Supplytime",ehps.HPS_Supplytime),
                new SqlParameter("@HPS_Demand",ehps.HPS_Demand),
                new SqlParameter("@HPS_Demandtime",ehps.HPS_Demandtime),
                new SqlParameter("@HPS_Business",ehps.HPS_Bussiness),
                new SqlParameter("@HPS_Businesstime",ehps.HPS_Bussinesstime),
                new SqlParameter("@HPS_Engage",ehps.HPS_Engage),
                new SqlParameter("@HPS_Engagetime",ehps.HPS_Engagetime),
                new SqlParameter("@HPS_Corporation",ehps.HPS_Corporation),
                new SqlParameter("@HPS_Corporationtime",ehps.HPS_Corporationtime),
                new SqlParameter("@HPS_Address",ehps.HPS_Address),
                new SqlParameter("@HPS_Addresstime",ehps.HPS_Addresstime)                 
            };
            int err = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[XYP_InsertHTMLPageSet]", parm);

            return err;
        }
        #endregion

        #region �޸ľ�̬ҳ��������Ϣ
        /// <summary>
        /// �޸ľ�̬ҳ��������Ϣ
        /// </summary>
        /// <param name="ehps">��̬ҳ��������Ϣ���������</param>
        /// <returns>���֡�����0��ʾ�޸ĳɹ�</returns>
        public int Update(XYECOM.Model.HtmlPageSetInfo ehps)
        {
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@HPS_ID",ehps.HPS_ID),
                new SqlParameter("@HPS_Index",ehps.HPS_Index),
                new SqlParameter("@HPS_Indextime",ehps.HPS_Indextime),
                new SqlParameter("@HPS_Supply",ehps.HPS_Supply ),
                new SqlParameter("@HPS_Supplytime",ehps.HPS_Supplytime),
                new SqlParameter("@HPS_Demand",ehps.HPS_Demand),
                new SqlParameter("@HPS_Demandtime",ehps.HPS_Demandtime),
                new SqlParameter("@HPS_Business",ehps.HPS_Bussiness),
                new SqlParameter("@HPS_Businesstime",ehps.HPS_Bussinesstime),
                new SqlParameter("@HPS_Engage",ehps.HPS_Engage),
                new SqlParameter("@HPS_Engagetime",ehps.HPS_Engagetime),
                new SqlParameter("@HPS_Corporation",ehps.HPS_Corporation),
                new SqlParameter("@HPS_Corporationtime",ehps.HPS_Corporationtime),
                new SqlParameter("@HPS_Address",ehps.HPS_Address),
                new SqlParameter("@HPS_Addresstime",ehps.HPS_Addresstime)                 
            };
            int err = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateHTMLPageSet", parm);

            return err;
        }
        #endregion

        #region ��ȡ��̬ҳ��������Ϣ
        /// <summary>
        /// ��ȡ��̬ҳ��������Ϣ
        /// </summary>
        /// <param name="strWhere">��ѯ����</param>
        /// <param name="strOrderBy">��������</param>
        /// <returns>DataTable���ݼ�</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","b_HTMLPageSet"),
                new SqlParameter("@strOrder",strOrderBy)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", param);
        }
        #endregion
    }
    #endregion
}
