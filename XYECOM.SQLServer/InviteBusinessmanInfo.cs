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
    /// 招商加盟信息数据处理类
    /// </summary>
    public class InviteBusinessmanInfo
    {
        /// <summary>
        /// 获取指定编号的招商代理对象
        /// </summary>
        /// <param name="infoId">要获取的招商代理编号</param>
        /// <returns>该编号标示的对象</returns>
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
                    if ("全国" == info.A_Area || "" == info.A_Area)
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
                    //新增的父类属性 刘甲 2008-10-18
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
                    //新增属性
                    info.QuondamProduct = reader["S_Name"].ToString();
                    info.Support = reader["IBI_Support"].ToString();
                    info.Demand = reader["IBI_Demand"].ToString();
                    info.URL = reader["IBI_URL"].ToString();
                    //设置附件信息
                    info.AttachInfo = new Attachment().GetItems(info.InfoID, "i_invitebusinessmaninfo");
                    //Attachment.SetAttachmentInfo(info, reader);
                }
            }
            return info;
        }

        /// <summary>
        /// 添加招商信息
        /// </summary>
        /// <param name="info">实体类</param>
        /// <param name="infoId">所添加的招商信息的记录编号</param>
        /// <returns>受影响的行数</returns>
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
        /// 修改招商信息
        /// </summary>
        /// <param name="info">实体类</param>
        /// <returns>受影响的行数</returns>
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
        /// 获取满足指定条件的招商代理记录集
        /// </summary>
        /// <param name="strwhere">指定的where条件</param>
        /// <param name="strOrder">指定的order条件</param>
        /// <returns>满足条件的datatable类型的记录集</returns>
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
        /// 删除一条记录
        /// </summary>
        /// <param name="IBI_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
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
        /// 获取所有招商代理记录的DataTable类型的记录集
        /// </summary>
        /// <returns>DataTable类型的所有招商代理记录集</returns>
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
        /// 修改招商状态
        /// </summary>
        /// <param name="isPause">
        /// true:暂停招商
        /// false:招商进行中</param>
        /// <param name="IBI_ID_Scope">要修改的招商信息的编号范围,example:(1,3)</param>
        /// <returns>受影响的行数</returns>
        public int UpdateEntityState(bool isPause, string IBI_ID_Scope)
        {
            if (isPause)
                return Function.UpdateSD_Pause("i_InviteBusinessmanInfo", " where IBI_ID in (" + IBI_ID_Scope + ")", " IBI_Pause=1 ");
            else
                return Function.UpdateSD_Pause("i_InviteBusinessmanInfo", " where IBI_ID in (" + IBI_ID_Scope + ")", " IBI_Pause=0 ");
        }

        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="IBI_ID_Scope">记录编号范围</param>
        /// <returns>受影响的行数</returns>
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
        /// 对该条信息审核通过
        /// </summary>
        /// <param name="IBI_ID">在对应标中的编号</param>
        /// <param name="A_Advice"></param>
        /// <param name="A_Reason"></param>
        /// <param name="IsAudited"></param>
        /// <returns>受影响的行数</returns>
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
        /// 修改信息的审核状态
        /// </summary>
        /// <param name="IBI_ID">在对应标中的编号</param>
        /// <param name="isAudited">所在表</param>
        /// <returns>受影响的行数</returns>
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

        #region 修改推荐
        /// <summary>
        /// 更正指定编号的招商代理信息的推荐状态
        /// </summary>
        /// <param name="IBI_ID">要更改的招商代理编号</param>
        /// <param name="Vouch">要更改的状态</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int UpdateVouch(long IBI_ID, bool Vouch)
        {
            if (Vouch)
                return Function.UpdateSD_Pause("i_InviteBusinessmanInfo", " where IBI_ID =" + IBI_ID.ToString(), " IBI_Vouch=1 ");
            else
                return Function.UpdateSD_Pause("i_InviteBusinessmanInfo", " where IBI_ID =" + IBI_ID.ToString(), " IBI_Vouch=0 ");
        }
        #endregion

        #region 获取一条招商信息
        /// <summary>
        /// 获取指定编号的招商代理信息的DataTable类型数据集
        /// </summary>
        /// <param name="IBI_ID">要获取的招商代理信息编号</param>
        /// <returns>该记录的datatable类型数据集</returns>
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


        #region 批量移动
        /// <summary>
        /// 批量移动
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
