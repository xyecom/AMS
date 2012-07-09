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
    /// ��ǩ��Ϣ���ݿ⴦����
    /// </summary>
    public class Label : DataCache
    {
        #region ��ӱ�ǩ��Ϣ
        /// <summary>
        /// ��ӱ�ǩ��Ϣ
        /// </summary>
        /// <param name="info">��ǩ��Ϣ���������</param>
        /// <returns>���֡�����0��ʾ��ӳɹ�</returns>
        public int Insert(XYECOM.Model.LabelInfo info)
        {
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@L_Name",info.LabelName),
                new SqlParameter("@L_CName",info.LabelCName),
                new SqlParameter("@LT_ID",info.LabelTypeId),
                new SqlParameter("@L_TableName",info.LabelTableName),
                new SqlParameter("@L_Content",info.LabelContent),
                new SqlParameter("@L_StyleHead",info.LabelStyleHead),
                new SqlParameter("@L_StyleContent",info.LabelStyleContent),
                new SqlParameter("@L_StyleFooter",info.LabelStyleFooter),
                new SqlParameter("@membership",info.LabelRangeData),
                new SqlParameter("@labelDescription",info.LabelDescription)
            };

            int err = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[XYP_InsertLabel]", parm);

            UpdateCache();

            return err;
        }
        #endregion

        #region �޸ı�ǩ��Ϣ
        /// <summary>
        /// �޸ı�ǩ��Ϣ
        /// </summary>
        /// <param name="el">��ǩ��Ϣ���������</param>
        /// <returns>���֡�����0��ʾ��ӳɹ�</returns>
        public int Update(XYECOM.Model.LabelInfo info)
        {
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@L_ID",info.Id),
                new SqlParameter("@L_Name",info.LabelName),
                new SqlParameter("@L_CName",info.LabelCName),
                new SqlParameter("@LT_ID",info.LabelTypeId),
                new SqlParameter("@L_TableName",info.LabelTableName),
                new SqlParameter("@L_Content",info.LabelContent),
                new SqlParameter("@L_StyleHead",info.LabelStyleHead),
                new SqlParameter("@L_StyleContent",info.LabelStyleContent),
                new SqlParameter("@L_StyleFooter",info.LabelStyleFooter),
                new SqlParameter("@membership",info.LabelRangeData),
                new SqlParameter("@labelDescription",info.LabelDescription)
            };

            int err = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[XYP_UpdateLabel]", parm);

            UpdateCache();

            return err;
        }
        #endregion

        #region ɾ����ǩ��Ϣ
        /// <summary>
        /// ɾ����ǩ��Ϣ
        /// </summary>
        /// <param name="L_ID">��ǩ���</param>
        /// <returns>���֡�����0��ʾɾ���ɹ�</returns>
        public int Delete(long labelId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where L_ID="+labelId.ToString()),
                new SqlParameter("@strTableName","b_Label")
            };

            int result = XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);

            UpdateCache();

            return result;
        }

        /// <summary>
        /// ɾ�������ǩ��Ϣ
        /// </summary>
        /// <param name="labelIds">��ǩId�������Ÿ���</param>
        /// <returns>��Ӱ������</returns>
        public int Delete(string labelIds)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where L_ID in ( "+labelIds + " )"),
                new SqlParameter("@strTableName","b_Label")
            };

            int result = XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);

            UpdateCache();

            return result;
        }
        #endregion

        #region ��ȡ��ǩ��Ϣ

        /// <summary>
        /// ��ȡָ����ǩ���Ƶı�ǩ����
        /// </summary>
        /// <param name="labelName">��ǩ����</param>
        /// <returns>��ǩ����</returns>
        public XYECOM.Model.LabelInfo GetItem(string labelName)
        {
            XYECOM.Model.LabelInfo info = null;

            Object obj = GetCache();

            if (obj != null)
            {
                DataTable table = (DataTable)obj;

                DataRow[] rows = table.Select("l_Name ='" + labelName + "'");

                if (rows != null && rows.Length > 0)
                {
                    info = new XYECOM.Model.LabelInfo();

                    info.LabelName = rows[0]["L_Name"].ToString();
                    info.LabelCName = rows[0]["L_CName"].ToString();
                    info.Id = Convert.ToInt64(rows[0]["L_ID"].ToString());
                    info.LabelTableName = rows[0]["L_TableName"].ToString();
                    info.LabelTypeId = Convert.ToInt32(rows[0]["LT_ID"].ToString());
                    info.LabelContent = rows[0]["L_Content"].ToString();
                    info.LabelStyleHead = rows[0]["L_StyleHead"].ToString();
                    info.LabelStyleContent = rows[0]["L_StyleContent"].ToString();
                    info.LabelStyleFooter = rows[0]["L_StyleFooter"].ToString();

                    info.LabelDescription = rows[0]["LabelDescription"].ToString();
                    string labelData = rows[0]["Membership"].ToString().Trim(); ;
                    if (!string.IsNullOrEmpty(labelData))
                    {
                        string[] ar = labelData.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                        if (ar.Length == 2)
                        {
                            info.LabelRange = (Model.LabelRange)Enum.Parse(typeof(Model.LabelRange), ar[0]);
                            info.GroupIdOrUserId = ar[1];
                        }
                    }
                }
            }

            return info;
        }

        /// <summary>
        /// ��ȡָ����ǩId�ı�ǩ����
        /// </summary>
        /// <param name="labelId">��ǩId</param>
        /// <returns>��ǩ����</returns>
        public XYECOM.Model.LabelInfo GetItem(long labelId)
        {
            XYECOM.Model.LabelInfo info = null;

            Object obj = GetCache();

            if (obj != null)
            {
                DataTable table = (DataTable)obj;

                DataRow[] rows = table.Select("l_ID =" + labelId + "");

                if (rows != null && rows.Length > 0)
                {
                    info = new XYECOM.Model.LabelInfo();

                    info.LabelName = rows[0]["L_Name"].ToString();
                    info.LabelCName = rows[0]["L_CName"].ToString();
                    info.Id = Convert.ToInt64(rows[0]["L_ID"].ToString());
                    info.LabelTableName = rows[0]["L_TableName"].ToString();
                    info.LabelTypeId = Convert.ToInt32(rows[0]["LT_ID"].ToString());
                    info.LabelContent = rows[0]["L_Content"].ToString();
                    info.LabelStyleHead = rows[0]["L_StyleHead"].ToString();
                    info.LabelStyleContent = rows[0]["L_StyleContent"].ToString();
                    info.LabelStyleFooter = rows[0]["L_StyleFooter"].ToString();
                    info.LabelDescription = rows[0]["LabelDescription"].ToString();
                    string labelData = rows[0]["Membership"].ToString().Trim(); ;
                    if (!string.IsNullOrEmpty(labelData))
                    {
                        string[] ar = labelData.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                        if (ar.Length == 2)
                        {
                            info.LabelRange = (Model.LabelRange)Enum.Parse(typeof(Model.LabelRange), ar[0]);
                            info.GroupIdOrUserId = ar[1];
                        }
                    }
                }
            }

            return info;
        }
        #endregion

        public override string SQL_Get_All
        {
            get { return "select * from b_label"; }
        }
    }
}
