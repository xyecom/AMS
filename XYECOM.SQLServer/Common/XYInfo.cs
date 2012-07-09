using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 商业信息数据处理通用类
    /// </summary>
    public class XYInfo
    {
        /// <summary>
        /// 刷新信息
        /// </summary>
        /// <param name="infoType">信息类型</param>
        /// <param name="moduleName">模块名称</param>
        /// <param name="userId">用户Id</param>
        /// <param name="infoId">信息Id</param>
        /// <param name="addWebMoneyCount">刷新信息给用户新增的虚拟币个数</param>
        /// <returns></returns>
        public string RefreshInfo(XYECOM.Model.InfoType infoType, string moduleName, long userId, long infoId, decimal addWebMoneyCount)
        {
            string infoTypeStr = "";
            string result = "";

            if (infoType == XYECOM.Model.InfoType.Offer) infoTypeStr = "offer";
            if (infoType == XYECOM.Model.InfoType.Venture) infoTypeStr = "venture";
            if (infoType == XYECOM.Model.InfoType.Investment) infoTypeStr = "investment";
            if (infoType == XYECOM.Model.InfoType.Service) infoTypeStr = "service";
            if (infoType == XYECOM.Model.InfoType.Exhibition) infoTypeStr = "exhibition";
            if (infoType == XYECOM.Model.InfoType.Job) infoTypeStr = "job";
            if (infoType == XYECOM.Model.InfoType.Brand) infoTypeStr = "brand";
            if (infoType == XYECOM.Model.InfoType.News) infoTypeStr = "news";

            SqlParameter[] param = new SqlParameter[] 
            {                                                      
                new SqlParameter("@ModuleName",moduleName),
                new SqlParameter("@InfoType",infoTypeStr),
                new SqlParameter("@InfoId",infoId),
                new SqlParameter("@UserId",userId),
                new SqlParameter("@AddWebMoneyCount",addWebMoneyCount),
                new SqlParameter("@Result",SqlDbType.NVarChar,100)
            };

            param[5].Direction = ParameterDirection.Output;

            XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_RefreshInfo", param);

            if (param[5].Value != null) result = param[5].Value.ToString();

            return result;
        }

        /// <summary>
        /// 获取相关信息
        /// </summary>
        /// <param name="tableInfo">分类表信息</param>
        /// <param name="moduleName">模块名称</param>
        /// <param name="userID">用户ID</param>
        /// <param name="topNumber">读取条数</param>
        /// <returns></returns>
        public DataTable GetAboutInfo(Model.XYClassTableInfo tableInfo, XYECOM.Configuration.ModuleInfo module, long userId, int topNumber,long curInfoId)
        {
            string colums = "";
            string where = "";
            string order = "";

            if (module.EName.Equals("offer") || module.PEName.Equals("offer"))
            {
                colums = "SD_ID as infoID,SD_Title as infoTitle,sd_HTMLPage as htmlPage";
                where = "SD_Flag = 1 and U_ID=" + userId + " and AuditingState = 1 and ModuleName='" + module.EName + "' and SD_ID <>" + curInfoId;
                order = "SD_ID desc";
            }

            if (module.EName.Equals("venture") || module.PEName.Equals("venture"))
            {
                colums = "SD_ID as infoId,SD_Title as InfoTitle,sd_HTMLPage as htmlPage";
                where = "SD_Flag = 1 and U_ID=" + userId + " and AuditingState = 1 and ModuleName='" + module.EName + "' and SD_ID <>" + curInfoId;
                order = "SD_ID desc";
            }

            if (module.EName.Equals("investment") || module.PEName.Equals("investment"))
            {
                colums = "IBI_ID as infoID,IBI_Title as infoTitle,IBI_HTMLPage  as htmlPage";
                where = "IBI_Sign = 1 and U_ID=" + userId + " and AuditingState = 1  and ModuleName='" + module.EName + "' and IBI_ID <>" + curInfoId;
                order = "IBI_ID desc";
            }

            if (module.EName.Equals("service") || module.PEName.Equals("service"))
            {
                colums = "S_ID as infoId,S_Title as InfoTitle,S_HTMLPage  as HTMLPage";
                where = "S_Flag = 1 and U_ID=" + userId + " and AuditingState = 1  and ModuleName='" + module.EName + "' and s_ID <> " + curInfoId;
                order = "S_ID desc";
            }
            
            return Utils.ExecuteTable(tableInfo.InfoTableName, colums, where,order, topNumber);
        }

        /// <summary>
        /// 关键词排名服务使用
        /// 通过关键字自动匹配信息
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="moduleName">模块名称</param>
        /// <param name="parentModuleName">父模块名称</param>
        /// <param name="userId">用户Id</param>
        /// <param name="sellFlags">【供】信息标识Id</param>
        /// <returns></returns>
        public DataTable AutomatchInfoByKeyword(string keyword, string moduleName, string parentModuleName, long userId, string sellFlags)
        {
            SqlParameter[] param = new SqlParameter[] 
            {                                                      
                new SqlParameter("@keyword",keyword),
                new SqlParameter("@UserId",userId),
                new SqlParameter("@Module",moduleName),
                new SqlParameter("@ParentModule",parentModuleName),
                new SqlParameter("@SellFlag",sellFlags)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_AutomatchInfoByKeyword", param);
        }

        /// <summary>
        /// 获取指定Id的信息
        /// </summary>
        /// <param name="tableInfo">表信息</param>
        /// <param name="module">模块信息</param>
        /// <param name="infoId">信息Id</param>
        /// <returns></returns>
        public DataTable GetDataById(Model.XYClassTableInfo tableInfo, XYECOM.Configuration.ModuleInfo module, long infoId)
        {
            string colums = "";
            string where = "";
            string order = "";

            if (module.EName.Equals("offer") || module.PEName.Equals("offer"))
            {
                colums = "SD_ID as infoID,SD_Title as InfoTitle,SD_Flag as infoFlag";
                where = "SD_ID=" + infoId;
            }

            if (module.EName.Equals("venture") || module.PEName.Equals("venture"))
            {
                colums = "SD_ID as infoID,SD_Title as InfoTitle,SD_Flag as infoFlag ";
                where = "SD_ID = " + infoId;
            }

            if (module.EName.Equals("investment") || module.PEName.Equals("investment"))
            {
                colums = "IBI_ID as infoId,IBI_Title as infoTitle,IBI_Sign as infoFlag";
                where = "IBI_ID =" + infoId;
            }

            if (module.EName.Equals("service") || module.PEName.Equals("service"))
            {
                colums = "S_ID as infoID,S_Title as infoTitle,S_Flag as infoFlag";
                where = "S_ID =" + infoId;
            }

            return Utils.ExecuteTable(tableInfo.InfoTableName, colums, where, order,0);
        }


        /// <summary>
        /// 获取指定模块下指定条数的信息
        /// 供网店调用数据使用
        /// </summary>
        /// <param name="tableInfo">表信息</param>
        /// <param name="module">模块信息</param>
        /// <param name="userId">用户Id</param>
        /// <param name="topNumber">调用条数</param>
        /// <param name="flagIds">类型标识Id集合</param>
        /// <returns></returns>
        public DataTable GetDataByModuleAndUserId(Model.XYClassTableInfo tableInfo, XYECOM.Configuration.ModuleInfo module, long userId,int topNumber,string flagIds)
        {
            string colums = "";
            string where = "";
            string order = "";

            if (module.EName.Equals("offer") || module.PEName.Equals("offer"))
            {
                colums = "SD_ID as infoID,SD_Title as InfoTitle,SD_Flag as infoFlag,SD_HTMLPage as htmlPage,isHasimage,sd_publishDate  as addtime";
                
                where = "AuditingState = 1 and SD_IsSupply='1' and ModuleName='" + module.EName + "' and U_ID =" + userId + " and SD_EndDate > '" + DateTime.Now + "' ";
                if(!flagIds.Equals("")) where += " and sd_flag in ("+flagIds+")";
                
                order = "sd_publishdate desc";
            }

            if (module.EName.Equals("venture") || module.PEName.Equals("venture"))
            {
                colums = "SD_ID as infoID,SD_Title as InfoTitle,SD_Flag as infoFlag,SD_HTMLPage as htmlPage,isHasimage,sd_publishDate  as addtime";
                where = "AuditingState = 1 and SD_IsSupply='1' and ModuleName='" + module.EName + "' and U_ID =" + userId + " and SD_EndDate > '" + DateTime.Now + "' and sd_flag in(" + flagIds + ") ";
                if(!flagIds.Equals("")) where += " and sd_flag in ("+flagIds+")";

                order = "sd_publishdate desc";
            }

            if (module.EName.Equals("investment") || module.PEName.Equals("investment"))
            {
                colums = "IBI_ID as infoId,IBI_Title as infoTitle,IBI_Sign as infoFlag,IBI_HTMLPage as htmlPage,isHasimage,ibi_publishdate  as addtime";
                where = "AuditingState = 1 and IBI_Pause = '1' and ModuleName='" + module.EName + "' and U_ID =" + userId + " and IBI_EndTime > '" + DateTime.Now + "' ";
                if(!flagIds.Equals("")) where += " and IBI_Sign in ("+flagIds+")";

                order = "ibi_publishdate desc";
            }

            if (module.EName.Equals("service") || module.PEName.Equals("service"))
            {
                colums = "S_ID as infoID,S_Title as infoTitle,S_Flag as infoFlag,S_HTMLPage as htmlPage,isHasimage,s_addtime as addtime";
                where = "AuditingState = 1 and S_Pause = '1' and ModuleName='" + module.EName + "' and U_ID =" + userId + " and S_EndTime > '" + DateTime.Now + "' ";
                if (!flagIds.Equals("")) where += " and S_Flag in (" + flagIds + ")";

                order = "s_addtime desc";
            }

            return Utils.ExecuteTable(tableInfo.InfoTableName, colums, where, order,topNumber);
        }

        /// <summary>
        /// 获取用户最新数据
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <param name="userId"></param>
        /// <param name="isCommend"></param>
        /// <returns></returns>
        public DataTable GetUserLastData(string moduleName, long userId, int isCommend)
        {
            string cmdText = __GetCmdText(moduleName, userId, isCommend);

            if (cmdText.Equals("")) return new DataTable();

            DataTable table = new DataTable();

            table.Columns.Add(new DataColumn("InfoId"));
            table.Columns.Add(new DataColumn("Title"));

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(cmdText))
            {
                DataRow row = null;

                while (reader.Read())
                {
                    row = table.NewRow();

                    row["InfoId"] = XYECOM.Core.MyConvert.GetInt64(reader[0].ToString());
                    row["Title"] = reader.GetString(1);

                    table.Rows.Add(row);
                }
            }

            return table;
        }
        private string __GetCmdText(string moduleName, long userId, int isCommend)
        {
            string cmdText = "";

            Configuration.ModuleInfo module = Configuration.Module.Instance.GetItem(moduleName);

            if (module == null)
            {
                if (moduleName.Equals("news"))
                {
                    cmdText = "select N_ID,N_Title From u_news where AuditingState = 1 and u_id = " + userId;

                    cmdText += " order by N_ID desc";
                }
            }
            else
            {
                if (module.EName.Equals("offer") || module.PEName.Equals("offer"))
                {
                    cmdText = "select SD_ID,SD_Title From xyv_supply where UserAuditingState=1 and AuditingState = 1 and SD_IsSupply = 1 and U_ID = " + userId + " and moduleName='" + moduleName + "'";

                    if (isCommend >= 0) cmdText += " and SD_Vouch =" + isCommend;

                    cmdText += " order by SD_PublishDate desc";
                }

                if (module.EName.Equals("venture") || module.PEName.Equals("venture"))
                {
                    cmdText = "select SD_ID,SD_Title From xyv_Demand where UserAuditingState=1 and AuditingState = 1 and SD_IsSupply = 1 and U_Id =" + userId + " and moduleName='" + moduleName + "'";

                    if (isCommend >= 0) cmdText += " and SD_Vouch =" + isCommend;

                    cmdText += " order by SD_PublishDate desc";
                }

                if (module.EName.Equals("investment") || module.PEName.Equals("investment"))
                {
                    cmdText = "select  IBI_ID,IBI_Title From xyv_InviteBusinessmanInfo where UserAuditingState=1 and AuditingState = 1 and IBI_Pause = 1 And U_ID=" + userId + " and moduleName='" + moduleName + "'";

                    if (isCommend >= 0) cmdText += " and IBI_Vouch =" + isCommend;

                    cmdText += " order by IBI_PublishDate desc";
                }

                if (module.EName.Equals("service") || module.PEName.Equals("service"))
                {
                    cmdText = "select  S_ID,S_Title From xyv_ServiceInfo where UserAuditingState=1 and AuditingState = 1 and S_Pause = 1 and u_id=" + userId + " and moduleName='" + moduleName + "'";

                    if (isCommend >= 0) cmdText += " and S_Vouch =" + isCommend;

                    cmdText += " order by S_AddTime desc";
                }
            }


            return cmdText;
        }
    }
}
