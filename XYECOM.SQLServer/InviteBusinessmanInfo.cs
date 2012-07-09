using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.Core.Data;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core;


namespace XYECOM.SQLServer
{
    /// <summary>
    /// ���̼�����Ϣ���ݴ�����
    /// </summary>
    public class InviteBusinessmanInfo
    {
        /// <summary>
        /// ��ȡָ����ŵ����̴������
        /// </summary>
        /// <param name="infoId">Ҫ��ȡ�����̴�����</param>
        /// <returns>�ñ�ű�ʾ�Ķ���</returns>
        public XYECOM.Model.InviteBusinessmanInfo GetItem(int infoId)
        {

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where IBI_ID ="+infoId.ToString()),
                new SqlParameter("@strTableName","XYV_InviteBusinessmanInfo"),
                new SqlParameter("@strOrder","")
            };
            XYECOM.Model.InviteBusinessmanInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.InviteBusinessmanInfo();
                    info.InfoID = infoId;
                    info.A_Area = reader["A_Area"].ToString();

                    info.AreaName = "";
                    if ("ȫ��" == info.A_Area || "" == info.A_Area)
                    {
                        info.AreaName = info.A_Area;
                    }
                    else
                    {
                        if ("" != info.A_Area)
                        {
                            List<Model.AreaInfo> arr = new Area().GetItemsByIDs(info.A_Area);
                            bool isok = true;
                            foreach (Model.AreaInfo areainfo in arr)
                            {
                                if (isok)
                                {
                                    info.AreaName = areainfo.Name;
                                    isok = false;
                                }
                                else
                                    info.AreaName += "," + areainfo.Name;
                            }
                        }
                    }

                    if (reader["AuditingState"].ToString() != "")
                    {
                        if (reader["AuditingState"].ToString().Equals("1"))
                            info.AuditingState = XYECOM.Model.AuditingState.Passed;
                        else
                            info.AuditingState = XYECOM.Model.AuditingState.NoPass;
                    }
                    else
                    {
                        info.AuditingState = XYECOM.Model.AuditingState.Null;
                    }
                    //�����ĸ������� ���� 2008-10-18
                    info.ModuleFlag = reader["ModuleName"].ToString();
                    info.Title = reader["IBI_Title"].ToString();
                    info.PublishTime = Core.MyConvert.GetDateTime(reader["IBI_PublishDate"].ToString());
                    info.EndTime = Core.MyConvert.GetDateTime(reader["IBI_EndTime"].ToString());
                    info.InfoContent = reader["IBI_Content"].ToString();
                    info.UserID = Core.MyConvert.GetInt64(reader["U_ID"].ToString());
                    info.SortID = Core.MyConvert.GetInt64(reader["IT_ID"].ToString());
                    info.SortName = reader["IT_Name"].ToString();
                    info.HtmlPage = reader["IBI_HTMLPage"].ToString();
                    info.ClickNum = Core.MyConvert.GetInt64(reader["IBI_ClickNum"].ToString());
                    info.IsCommend = reader["IBI_Vouch"].ToString() == "1";
                    info.MessageNum = Core.MyConvert.GetInt32(reader["IBI_MessageNum"].ToString());
                    info.NotReadingNum = Core.MyConvert.GetInt32(reader["IBI_NoMessageNum"].ToString());
                    info.UseFulDate = Core.MyConvert.GetInt32(reader["IBI_EndDate"].ToString());
                    info.InfoType = Core.MyConvert.GetInt32(reader["IBI_Sign"].ToString());
                    info.FieldID = Core.MyConvert.GetInt64(reader["P_ID"].ToString());
                    info.IsPause = Core.MyConvert.GetBoolean(reader["IBI_Pause"].ToString());
                    //��������
                    info.QuondamProduct = reader["S_Name"].ToString();
                    info.Support = reader["IBI_Support"].ToString();
                    info.Demand = reader["IBI_Demand"].ToString();
                    info.URL = reader["IBI_URL"].ToString();
                    //���ø�����Ϣ
                    info.AttachInfo = new Attachment().GetItems(info.InfoID, "i_invitebusinessmaninfo");
                    //Attachment.SetAttachmentInfo(info, reader);
                }
            }
            return info;
        }

        /// <summary>
        /// ���������Ϣ
        /// </summary>
        /// <param name="info">ʵ����</param>
        /// <param name="infoId">����ӵ�������Ϣ�ļ�¼���</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.InviteBusinessmanInfo info, out int infoId)
        {
            SqlParameter[] param = new SqlParameter[] 
            {                                                      
                new SqlParameter("@IBI_ID",SqlDbType.BigInt),
                new SqlParameter("@U_ID",info.UserID),
                new SqlParameter("@IBI_Title",info.Title),
                new SqlParameter("@IBI_Content",info.InfoContent),
                new SqlParameter("@IT_ID",info.SortID),
                new SqlParameter("@A_Area",info.A_Area),
                new SqlParameter("@S_Name",info.QuondamProduct),
                new SqlParameter("@IBI_Description",""),
                new SqlParameter("@IBI_Support",info.Support),
                new SqlParameter("@IBI_Demand",info.Demand),
                new SqlParameter("@IBI_EndDate",info.UseFulDate),
                new SqlParameter("@IBI_EndTime",info.EndTime),
                new SqlParameter("@IBI_URL",info.URL),
                new SqlParameter("@IBI_Sign",info.InfoType),
                new SqlParameter("@P_ID",info.FieldID)
            };

            param[0].Direction = ParameterDirection.Output;

            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertInviteBusinessman", param);

            if (rowAffected >= 0)
            {
                if (param[0].Value != null && param[0].Value.ToString() != "")
                    infoId = Convert.ToInt32(param[0].Value.ToString());
                else
                    infoId = -1;
            }
            else
                infoId = -1;

            return rowAffected;
        }

        /// <summary>
        /// �޸�������Ϣ
        /// </summary>
        /// <param name="info">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.InviteBusinessmanInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            {                                                      
                new SqlParameter("@IBI_ID",info.InfoID),
                new SqlParameter("@U_ID",info.UserID),
                new SqlParameter("@IBI_Title",info.Title),
                new SqlParameter("@IBI_Content",info.InfoContent),
                new SqlParameter("@IT_ID",info.SortID),
                new SqlParameter ("@A_Area",info.A_Area ),
                new SqlParameter("@S_Name",info.QuondamProduct),
                new SqlParameter("@IBI_Description",""),
                new SqlParameter("@IBI_Support",info.Support),
                new SqlParameter("@IBI_Demand",info.Demand),
                new SqlParameter ("@IBI_EndDate",info.UseFulDate),
                new SqlParameter("@IBI_EndTime",info.EndTime),
                new SqlParameter("@IBI_URL",info.URL),
                new SqlParameter("@IBI_Sign",info.InfoType),
                new SqlParameter("@P_ID",info.FieldID)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateInviteBusinessman", param);
        }

        /// <summary>
        /// ��ȡ����ָ�����������̴����¼��
        /// </summary>
        /// <param name="strwhere">ָ����where����</param>
        /// <param name="strOrder">ָ����order����</param>
        /// <returns>����������datatable���͵ļ�¼��</returns>
        public DataTable GetDataTable(string strwhere, string strOrder)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strwhere),
                new SqlParameter("@strTableName","XYV_InviteBusinessmanInfo"),
                new SqlParameter("@strOrder",strOrder)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        /// <param name="IBI_ID">��¼���</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(long IBI_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where IBI_ID="+IBI_ID.ToString()),
                new SqlParameter("@strTableName","i_InviteBusinessmanInfo")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }


        /// <summary>
        /// ��ȡ�������̴����¼��DataTable���͵ļ�¼��
        /// </summary>
        /// <returns>DataTable���͵��������̴����¼��</returns>
        public DataTable GetDataTable()
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere",""),
                new SqlParameter("@strTableName","XYV_InviteBusinessmanInfo"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }

        /// <summary>
        /// �޸�����״̬
        /// </summary>
        /// <param name="isPause">
        /// true:��ͣ����
        /// false:���̽�����</param>
        /// <param name="IBI_ID_Scope">Ҫ�޸ĵ�������Ϣ�ı�ŷ�Χ,example:(1,3)</param>
        /// <returns>��Ӱ�������</returns>
        public int UpdateEntityState(bool isPause, string IBI_ID_Scope)
        {
            if (isPause)
                return Function.UpdateSD_Pause("i_InviteBusinessmanInfo", " where IBI_ID in (" + IBI_ID_Scope + ")", " IBI_Pause=1 ");
            else
                return Function.UpdateSD_Pause("i_InviteBusinessmanInfo", " where IBI_ID in (" + IBI_ID_Scope + ")", " IBI_Pause=0 ");
        }

        /// <summary>
        /// ɾ��������¼
        /// </summary>
        /// <param name="IBI_ID_Scope">��¼��ŷ�Χ</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(string IBI_ID_Scope)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where IBI_ID in (" + IBI_ID_Scope + ")"),
                new SqlParameter("@strTableName","i_InviteBusinessmanInfo")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        #region Audit Management
        /// <summary>
        /// �Ը�����Ϣ���ͨ��
        /// </summary>
        /// <param name="IBI_ID">�ڶ�Ӧ���еı��</param>
        /// <param name="A_Advice"></param>
        /// <param name="A_Reason"></param>
        /// <param name="IsAudited"></param>
        /// <returns>��Ӱ�������</returns>
        public int AddAuditState(long IBI_ID, bool IsAudited, string A_Reason, string A_Advice)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@DescTabID",IBI_ID),
                new SqlParameter("@DescTabName","i_InviteBusinessmaninfo"),
                new SqlParameter("@A_IsAudited",IsAudited),
                new SqlParameter("@A_Reason",A_Reason),
                new SqlParameter("@A_Advice",A_Advice)
            };
            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "usp_pl_AuditingAdd", param);
        }
        /// <summary>
        /// �޸���Ϣ�����״̬
        /// </summary>
        /// <param name="IBI_ID">�ڶ�Ӧ���еı��</param>
        /// <param name="isAudited">���ڱ�</param>
        /// <returns>��Ӱ�������</returns>
        public int UpdateAuditState(long IBI_ID, bool isAudited, string A_Reason, string A_Advice)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@A_isAudited",isAudited),
                new SqlParameter("@DescTabID",IBI_ID),
                new SqlParameter("@A_Reason",A_Reason),
                new SqlParameter("@A_Advice",A_Advice),
                new SqlParameter("@DescTabName","i_InviteBusinessmaninfo")
            };
            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateAuditingInfo", param);
        }
        #endregion

        #region �޸��Ƽ�
        /// <summary>
        /// ����ָ����ŵ����̴�����Ϣ���Ƽ�״̬
        /// </summary>
        /// <param name="IBI_ID">Ҫ���ĵ����̴�����</param>
        /// <param name="Vouch">Ҫ���ĵ�״̬</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��</returns>
        public int UpdateVouch(long IBI_ID, bool Vouch)
        {
            if (Vouch)
                return Function.UpdateSD_Pause("i_InviteBusinessmanInfo", " where IBI_ID =" + IBI_ID.ToString(), " IBI_Vouch=1 ");
            else
                return Function.UpdateSD_Pause("i_InviteBusinessmanInfo", " where IBI_ID =" + IBI_ID.ToString(), " IBI_Vouch=0 ");
        }
        #endregion

        #region ��ȡһ��������Ϣ
        /// <summary>
        /// ��ȡָ����ŵ����̴�����Ϣ��DataTable�������ݼ�
        /// </summary>
        /// <param name="IBI_ID">Ҫ��ȡ�����̴�����Ϣ���</param>
        /// <returns>�ü�¼��datatable�������ݼ�</returns>
        public DataTable GetDataTable(long IBI_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," where IBI_ID="+IBI_ID .ToString()),
                new SqlParameter("@strTableName","XYV_InviteBusinessmanInfo"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }
        #endregion


        #region �����ƶ�
        /// <summary>
        /// �����ƶ�
        /// </summary>
        /// <returns></returns>
        public int MoveInvestment(String strwhere, String content)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@strwhere",strwhere),
                new SqlParameter("@tablename","i_InviteBusinessmanInfo"),
                new SqlParameter("@content",content)
            };
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "usp_PublicUpdate", param);
        }

        #endregion
    }
}
