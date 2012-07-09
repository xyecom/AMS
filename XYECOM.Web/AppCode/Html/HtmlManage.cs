using System;
using System.Threading;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;

namespace XYECOM.Web.Html
{
    public class HtmlManage
    {
        public static List<HtmlInfo> TaskList = new List<HtmlInfo>();
        public static int HtmlCount = 0;
        public static int HtmlCurrent = 0;
        private static Thread t;
        private static XYECOM.Configuration.WebInfo WebConfig = XYECOM.Configuration.WebInfo.Instance;
        private static log4net.ILog log = log4net.LogManager.GetLogger("ManageError");

        /// <summary>
        /// 开始执行生成静态页面
        /// </summary>
        public static void Start()
        {
            if (null == t)
            {
                t = new Thread(new ThreadStart(TStart));
                t.Start();
            }
            else if (t.ThreadState == ThreadState.Stopped)
            {
                t = new Thread(new ThreadStart(TStart));
                t.Start();
            }
            //TStart();
        }

        private static void TStart()
        {
            for (int i = 0; i < TaskList.Count; i = 0)
            {
                Html(TaskList[i]);
                TaskList.Remove(TaskList[i]);
            }
        }

        private static void Html(HtmlInfo info)
        {
            switch (info.PageType.ToLower())
            {
                case "default":
                    DefaultPage(info);
                    break;
                case "module":
                    ModulePage(info);
                    break;
                case "othermodule":
                    OtherModulePage(info);
                    break;
                case "news":
                    NewsPage(info);
                    break;
                case "newstitle":
                    NewsTitlePage(info);
                    break;
            }
        }

        #region 栏目首页
        private static void DefaultPage(HtmlInfo info)
        {
            HtmlCount = 0;
            HtmlCurrent = 0;
            if (info.IsDel)
                DeleteFile("" == info.PageModule ? "index." + WebConfig.StaticPageSuffix : info.PageModule + "/" + "index." + WebConfig.StaticPageSuffix);
            else
                CreateHTMLPage(WebConfig.WebDomain + info.PageHttpURL, "/" + info.PageModule + "/", "index." + WebConfig.StaticPageSuffix);
        }
        #endregion

        #region 商业信息
        private static void ModulePage(HtmlInfo info)
        {
            string strViewTableName = "";
            string strTableName = "";
            string strTimeField = "";
            string strPIDField = "";
            string strIDField = "";
            string strHtmlPageField = "";
            string strFlagField = "";
            string strWhere = "";
            string moduleName = "";

            HtmlCount = 0;
            HtmlCurrent = 0;

            XYECOM.Configuration.ModuleInfo moduleInfo = XYECOM.Configuration.Module.Instance.GetItem(info.PageModule);

            moduleName = moduleInfo.PEName;
            if ("" == moduleName)
            {
                moduleName = moduleInfo.EName;
            }

            switch (moduleName)
            {
                case "offer":
                    strViewTableName = "XYV_supply";
                    strTableName = "i_Supply";
                    strTimeField = "SD_PublishDate";
                    strPIDField = "PT_ID";
                    strIDField = "SD_ID";
                    strHtmlPageField = "SD_HTMLPage";
                    strFlagField = "SD_Flag";
                    break;
                case "venture":
                    strViewTableName = "XYV_Demand";
                    strTableName = "i_Demand";
                    strTimeField = "SD_PublishDate";
                    strPIDField = "TypeId";
                    strIDField = "SD_ID";
                    strHtmlPageField = "SD_HTMLPage";
                    strFlagField = "SD_Flag";
                    break;
                case "investment":
                    strViewTableName = "XYV_InviteBusinessmanInfo";
                    strTableName = "i_InviteBusinessmanInfo";
                    strTimeField = "IBI_PublishDate";
                    strPIDField = "IT_ID";
                    strIDField = "IBI_ID";
                    strHtmlPageField = "IBI_HTMLPage";
                    strFlagField = "IBI_Sign";
                    break;
                case "service":
                    strViewTableName = "XYV_ServiceInfo";
                    strTableName = "i_ServiceInfo";
                    strTimeField = "S_AddTime";
                    strPIDField = "ST_ID";
                    strIDField = "S_ID";
                    strHtmlPageField = "S_HTMLPage";
                    strFlagField = "S_Flag";
                    break;
                case "buy":
                    strViewTableName = "i_SupplyBuy";
                    strTableName = "i_SupplyBuy";
                    strTimeField = "PublishDate";
                    strPIDField = "";
                    strIDField = "SD_ID";
                    strHtmlPageField = "S_HTMLPage";

                    break;
            }
            if (moduleName == "buy")
            {
                strWhere = " where 1=1 ";
            }
            else
            {
                strWhere = "where moduleName='" + info.PageModule + "' ";
            }


            if ("" != info.PageBeginTime && "" != info.PageEndTime)
                strWhere += " and " + strTimeField + " between '" + info.PageBeginTime + "' and '" + info.PageEndTime + "' ";
            else if ("" != info.PageBeginTime)
                strWhere += " and " + strTimeField + " > '" + info.PageBeginTime + "' ";
            else if ("" != info.PageEndTime)
                strWhere += " and " + strTimeField + " < '" + info.PageEndTime + "'";

            if ("" != info.PageClassID && "0" != info.PageClassID)
                strWhere += " and " + strPIDField + "=" + info.PageClassID + " ";

            if (info.NewOnly && !info.IsDel)
                strWhere += " and isnull(" + strHtmlPageField + ",'') = '' ";

            if (!info.InfoIdList.Equals(""))
                strWhere += " and " + strIDField + " in (" + info.InfoIdList + ")";

            DataTable dt = XYECOM.Core.Data.SqlHelper.SelectByWhere(strViewTableName, strWhere, "");

            HtmlCount = dt.Rows.Count;


            string fileName = "";   //文件名称
            string filePath = "";   //文件路径

            string oldHtmlPageName = "";    //原静态页面名称


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                fileName = "";
                filePath = "";

                string fileExtName = "";
                string HttpURL = "";
                bool isdel = false;

                oldHtmlPageName = dt.Rows[i][strHtmlPageField].ToString().Trim();

                if (oldHtmlPageName != "")
                {
                    string[] temp = oldHtmlPageName.Split('/');

                    fileName = temp[temp.Length - 1];
                    filePath = oldHtmlPageName.Replace(fileName, "");

                    //fileName = dt.Rows[i][strHtmlPageField].ToString().Split('/')[1];
                    fileExtName = fileName.Split('.')[1].ToString();
                    //名称，不包含后缀
                    fileName = fileName.Split('.')[0].ToString();
                    //删除原文件
                    isdel = DeleteFile(dt.Rows[i][strHtmlPageField].ToString());
                }

                if (filePath.Equals(""))
                {
                    filePath = GetHTMLSavePath(moduleInfo.SEName, dt.Rows[i][strTimeField].ToString());
                }

                if (fileName.Equals(""))
                {
                    //按配置规则获取新名称
                    fileName = GetHTMLSaveName(dt.Rows[i][strIDField].ToString(), dt.Rows[i][strTimeField].ToString());
                }
                if (moduleName == "buy")
                {
                    HttpURL = WebConfig.WebDomain + "search/" + "buyinfo" + "." + WebConfig.WebSuffix + "?sdid=" + dt.Rows[i][strIDField].ToString();
                }
                else
                {
                    HttpURL = WebConfig.WebDomain + "search/" + moduleInfo.GetInfoType(XYECOM.Core.MyConvert.GetInt32(dt.Rows[i][strFlagField].ToString())) + "." + WebConfig.WebSuffix + "?flag=" + moduleInfo.EName + "&infoid=" + dt.Rows[i][strIDField].ToString();
                }
                if (info.IsDel)
                {
                    if (isdel)
                        UpdateColumuByWhere(strHtmlPageField, "", " where " + strIDField + "=" + dt.Rows[i][strIDField].ToString(), strTableName);
                }
                else
                {
                    bool isCreate = CreateHTMLPage(HttpURL, filePath, fileName + "." + WebConfig.StaticPageSuffix);
                    if (isCreate)
                    {
                        if (fileExtName != WebConfig.StaticPageSuffix)
                            UpdateColumuByWhere(strHtmlPageField, filePath.Substring(1) + "/" + fileName + "." + WebConfig.StaticPageSuffix, " where " + strIDField + "=" + dt.Rows[i][strIDField].ToString(), strTableName);
                    }
                }
                HtmlCurrent++;

                System.Threading.Thread.Sleep(100);
            }
        }
        #endregion

        #region 品牌 人才 网店
        private static void OtherModulePage(HtmlInfo info)
        {
            string strViewTableName = "";
            string strTableName = "";
            string strTimeField = "";
            string strPIDField = "";
            string strIDField = "";
            string strHtmlPageField = "";

            string strWhere = "";

            HtmlCount = 0;
            HtmlCurrent = 0;

            switch (info.PageModule)
            {
                case "job":
                    strViewTableName = "XYV_Engageinfo";
                    strTableName = "i_engageinfo";
                    strTimeField = "EI_AddDate";
                    strPIDField = "P_ID";
                    strIDField = "EI_ID";
                    strHtmlPageField = "EI_HTMLPage";
                    break;
                case "company":
                    strViewTableName = "XYV_UserInfo";
                    strTableName = "u_User";
                    strTimeField = "U_RegDate";
                    strPIDField = "UT_ID";
                    strIDField = "U_ID";
                    strHtmlPageField = "U_HTMLPage";
                    break;
                case "exhibition":
                    strViewTableName = "XYV_ShowInfo";
                    strTableName = "XY_ShowInfo";
                    strTimeField = "addInfoTime";
                    strPIDField = "typeid";
                    strIDField = "id";
                    strHtmlPageField = "HtmlPage";
                    break;
                case "resume":
                    strViewTableName = "XYV_Individual";
                    strTableName = "u_Resume";
                    strTimeField = "RE_Adddate";
                    strIDField = "U_ID";
                    strHtmlPageField = "RE_HtmlPage";
                    break;
            }

            strWhere = "";
            if ("" != info.PageBeginTime && "" != info.PageEndTime)
                strWhere += " and " + strTimeField + " between '" + info.PageBeginTime + "' and '" + info.PageEndTime + "' ";
            else if ("" != info.PageBeginTime)
                strWhere += " and " + strTimeField + " > '" + info.PageBeginTime + "' ";
            else if ("" != info.PageEndTime)
                strWhere += " and " + strTimeField + " < '" + info.PageEndTime + "'";

            if ("" != info.PageClassID && "0" != info.PageClassID)
                strWhere += " and " + strPIDField + "=" + info.PageClassID + " ";

            if (info.NewOnly && !info.IsDel)
                strWhere += " and isnull(" + strHtmlPageField + ",'') = '' ";

            if (!info.InfoIdList.Equals(""))
                strWhere += " and " + strIDField + " in (" + info.InfoIdList + ")";

            if ("" == strWhere)
            {
                if ("company" == info.PageModule)
                    strWhere = " where U_Flag=1 ";
            }
            else
                strWhere = " where 1=1 " + strWhere;


            DataTable dt = XYECOM.Core.Data.SqlHelper.SelectByWhere(strViewTableName, strWhere, "");

            HtmlCount = dt.Rows.Count;

            string fileName = "";   //文件名称
            string filePath = "";   //文件路径

            string oldHtmlPageName = "";    //原静态页面名称

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                fileName = "";
                filePath = "";

                string fileExtName = "";
                string HttpURL = "";
                bool isdel = false;

                oldHtmlPageName = dt.Rows[i][strHtmlPageField].ToString();

                if (oldHtmlPageName != "")
                {
                    string[] temp = oldHtmlPageName.Split('/');

                    fileName = temp[temp.Length - 1];
                    filePath = oldHtmlPageName.Replace(fileName, "");

                    fileExtName = fileName.Split('.')[1].ToString();
                    //名称，不包含后缀
                    fileName = fileName.Split('.')[0].ToString();
                    //删除原文件
                    isdel = DeleteFile(dt.Rows[i][strHtmlPageField].ToString());
                }

                if (filePath.Equals(""))
                {
                    filePath = GetHTMLSavePath(info.PageModule, dt.Rows[i][strTimeField].ToString());
                }

                if (fileName.Equals(""))
                {
                    //按配置规则获取新名称
                    fileName = GetHTMLSaveName(dt.Rows[i][strIDField].ToString(), dt.Rows[i][strTimeField].ToString());
                }


                if ("brand" == info.PageModule)
                {
                    HttpURL = WebConfig.WebDomain + "brand/info." + WebConfig.WebSuffix + "?infoid=" + dt.Rows[i][strIDField].ToString();
                }
                else if ("job" == info.PageModule)
                {
                    if (WebConfig.IsDomain)
                    {
                        string subDomain = WebConfig.GetSubDomain(dt.Rows[i]["U_Name"].ToString());

                        HttpURL = subDomain + "job-" + dt.Rows[i][strIDField].ToString() + "." + WebConfig.WebSuffix;
                    }
                    else
                    {
                        HttpURL = WebConfig.WebDomain + "shop/" + dt.Rows[i]["U_Name"].ToString() + "/job." + WebConfig.WebSuffix + "?ei_id=" + dt.Rows[i][strIDField].ToString();
                    }
                }
                else if ("resume" == info.PageModule)
                {
                    HttpURL = WebConfig.WebDomain + "job/resume." + WebConfig.WebSuffix + "?id=" + dt.Rows[i][strIDField].ToString();
                }
                else if ("company" == info.PageModule)
                {
                    if (WebConfig.IsDomain)
                    {
                        string subDomain = WebConfig.GetSubDomain(dt.Rows[i]["U_Name"].ToString());

                        HttpURL = subDomain + "index." + WebConfig.WebSuffix;
                    }
                    else
                    {
                        HttpURL = WebConfig.WebDomain + "shop/" + dt.Rows[i]["U_Name"].ToString() + "/index." + WebConfig.WebSuffix;
                    }
                }
                else if ("exhibition" == info.PageModule)
                {
                    HttpURL = WebConfig.WebDomain + "exhibition/info." + WebConfig.WebSuffix + "?infoid=" + dt.Rows[i][strIDField].ToString();
                }

                if (info.IsDel)
                {
                    if (isdel)
                        UpdateColumuByWhere(strHtmlPageField, "", " where " + strIDField + "=" + dt.Rows[i][strIDField].ToString(), strTableName);
                }
                else
                {
                    bool isCreate = CreateHTMLPage(HttpURL, filePath, fileName + "." + WebConfig.StaticPageSuffix);
                    if (isCreate)
                    {
                        if (fileExtName != WebConfig.StaticPageSuffix)
                            UpdateColumuByWhere(strHtmlPageField, filePath.Substring(1) + "/" + fileName + "." + WebConfig.StaticPageSuffix, " where " + strIDField + "=" + dt.Rows[i][strIDField].ToString(), strTableName);
                    }
                }
                HtmlCurrent++;

                System.Threading.Thread.Sleep(100);
            }
        }
        #endregion

        #region 资讯
        private static void NewsPage(HtmlInfo info)
        {
            string strViewTableName = "XYV_News";
            string strTableName = "n_News";
            string strTimeField = "NS_AddTime";
            string strIDField = "NS_ID";
            string strHtmlPageField = "NS_HTMLPage";

            HtmlCount = 0;
            HtmlCurrent = 0;

            string strWhere = " where AuditingState = 1 ";

            if ("" != info.PageBeginTime && "" != info.PageEndTime)
                strWhere += " and " + strTimeField + " between '" + info.PageBeginTime + "' and '" + info.PageEndTime + "' ";
            else if ("" != info.PageBeginTime)
                strWhere += " and " + strTimeField + " > '" + info.PageBeginTime + "' ";
            else if ("" != info.PageEndTime)
                strWhere += " and " + strTimeField + " < '" + info.PageEndTime + "'";

            if ("" != info.PageClassID)
                strWhere += " and (NT_ID = '" + info.PageClassID + "' or PATINDEX('" + info.PageClassID + ",%',NT_ID) <>0 or PATINDEX('%," + info.PageClassID + ",%',NT_ID) <>0 or PATINDEX('%," + info.PageClassID + "',NT_ID) <>0) ";

            if (info.NewOnly && !info.IsDel)
                strWhere += " and isnull(" + strHtmlPageField + ",'') = '' ";

            if (!info.InfoIdList.Equals(""))
                strWhere += " and " + strIDField + " in (" + info.InfoIdList + ")";



            DataTable dt = XYECOM.Core.Data.SqlHelper.SelectByWhere(strViewTableName, strWhere, "");

            HtmlCount = dt.Rows.Count;

            string fileName = "";   //文件名称
            string filePath = "";   //文件路径

            string oldHtmlPageName = "";    //原静态页面名称


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                fileName = "";
                filePath = "";

                string fileExtName = "";
                string HttpURL = "";
                bool isdel = false;

                oldHtmlPageName = dt.Rows[i][strHtmlPageField].ToString().Trim();

                if (oldHtmlPageName != "")
                {
                    string[] temp = oldHtmlPageName.Split('/');

                    fileName = temp[temp.Length - 1];
                    filePath = oldHtmlPageName.Replace(fileName, "");

                    fileExtName = fileName.Split('.')[1].ToString();
                    //名称，不包含后缀
                    fileName = fileName.Split('.')[0].ToString();
                    //删除原文件
                    isdel = DeleteFile(dt.Rows[i][strHtmlPageField].ToString());
                }

                if (filePath.Equals(""))
                {
                    filePath = GetHTMLSavePath("news", dt.Rows[i][strTimeField].ToString());
                }

                if (fileName.Equals(""))
                {
                    //按配置规则获取新名称
                    fileName = GetHTMLSaveName(dt.Rows[i][strIDField].ToString(), dt.Rows[i][strTimeField].ToString());
                }

                string subChannelFolder = "";

                subChannelFolder = dt.Rows[i]["NT_TempletFolderAddress"].ToString().Trim();

                if (!subChannelFolder.Equals("")) subChannelFolder = subChannelFolder + "/";

                HttpURL = WebConfig.WebDomain + "news/" + subChannelFolder + "content." + WebConfig.WebSuffix + "?ns_id=" + dt.Rows[i][strIDField].ToString();

                if (info.IsDel)
                {
                    if (isdel)
                        UpdateColumuByWhere(strHtmlPageField, "", " where " + strIDField + "=" + dt.Rows[i][strIDField].ToString(), strTableName);
                }
                else
                {
                    bool isCreate = CreateHTMLPage(HttpURL, filePath, fileName + "." + WebConfig.StaticPageSuffix);
                    if (isCreate)
                    {
                        if (fileExtName != WebConfig.StaticPageSuffix)
                            UpdateColumuByWhere(strHtmlPageField, filePath.Substring(1) + "/" + fileName + "." + WebConfig.StaticPageSuffix, " where " + strIDField + "=" + dt.Rows[i][strIDField].ToString(), strTableName);
                    }
                }
                HtmlCurrent++;

                System.Threading.Thread.Sleep(100);
            }
        }
        #endregion

        #region 资讯栏目
        private static void NewsTitlePage(HtmlInfo info)
        {
            string strTableName = "n_NewsTitleInfo";
            string strWhere = "";
            string strSD_IDs = "";
            string strsavepath = "";
            string strfilename = "";
            string strtemppath = "";
            int pagecount = 1;

            HtmlCount = 0;
            HtmlCurrent = 0;

            if (info.PageClassID == "")
            {
                strWhere = " where 1=1 ";
            }
            else
            {
                strWhere = " where NT_ID=" + info.PageClassID;
            }

            if (!info.InfoIdList.Equals(""))
                strWhere += " and NT_ID in (" + info.InfoIdList + ")";

            DataTable dt = XYECOM.Core.Data.SqlHelper.SelectByWhere(strTableName, strWhere, "");

            HtmlCount = dt.Rows.Count;

            XYECOM.Model.LabelInfo el = new XYECOM.Model.LabelInfo();
            XYECOM.Business.Label lb = new XYECOM.Business.Label();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tmppath = dt.Rows[i]["NT_EnName"].ToString().Replace(" ", "");

                if (info.IsDel)
                {
                    UpdateColumuByWhere("NT_HTMLPage", "", " where NT_ID=" + dt.Rows[i]["NT_ID"].ToString(), strTableName);

                    if (Directory.Exists(GetServerPath("/news/" + tmppath)))
                    {
                        Directory.Delete(GetServerPath("/news/" + tmppath), true);
                    }

                    continue;
                }

                try
                {
                    if (dt.Rows[i]["NT_TempletFolderAddress"].ToString() == "")
                        strtemppath = "news/channel.htm";
                    else
                    {
                        strtemppath = "/news/" + dt.Rows[i]["NT_TempletFolderAddress"].ToString() + "/channel.htm";
                    }

                    StreamReader sr = new StreamReader(GetServerPath("/templates/" + XYECOM.Configuration.Template.Instance.Path + "/" + strtemppath), System.Text.Encoding.Default);
                    string strContent = sr.ReadToEnd();
                    sr.Close();


                    string strMatch = "";
                    string strLableID = "";
                    System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex("{XY_.*?}");

                    System.Text.RegularExpressions.MatchCollection m = r.Matches(strContent);

                    foreach (System.Text.RegularExpressions.Match mt in m)
                    {
                        strMatch = mt.Value;

                        strMatch = strMatch.Replace("{", "").Replace("}", "");
                        el = lb.GetItem(strMatch.Substring(LabelPrefix.Length));
                        if (el != null)
                        {
                            strMatch = el.LabelContent.Substring(1);

                            strMatch = strMatch.Remove(strMatch.Length - 1, 1);

                            string[] strs = strMatch.Split('┆');

                            strLableID = strs[0].Split('$')[1].ToString();

                            if (strLableID == "NewsPageList")
                                pagecount = Convert.ToInt32(strs[1].Split('$')[1].ToString());
                        }
                    }

                    string where = " where AuditingState = 1 ";
                    int channelId = Core.MyConvert.GetInt32(dt.Rows[i]["NT_ID"].ToString());
                    where += " and (" + Business.Utils.GetNewsChannelQueryWhere(channelId) + ") ";

                    int count = GetRecordCount("n_news", "NS_ID", where);
                    if (count > 0)
                    {
                        int pagesize = 0;
                        if ((count % pagecount) == 0)
                            pagesize = count / pagecount;
                        else
                            pagesize = count / pagecount + 1;

                        for (int j = 0; j < pagesize; j++)
                        {
                            string nexthtml = "";
                            string previoushtml = "";

                            if (j + 2 <= pagesize)
                                nexthtml = "/news/" + tmppath + "/index_" + (j + 2) + "." + WebConfig.StaticPageSuffix;
                            if (j - 1 > 0)
                                previoushtml = "/news/" + tmppath + "/index_" + j + "." + WebConfig.StaticPageSuffix;
                            else
                                previoushtml = "/news/" + tmppath + "/index." + WebConfig.StaticPageSuffix;
                            if (j > 0)
                                strfilename = "index_" + (j + 1) + "." + WebConfig.StaticPageSuffix;
                            else
                                strfilename = "index." + WebConfig.StaticPageSuffix;

                            strsavepath = "news/" + tmppath + "/" + strfilename;

                            //不为删除操作 则生成静态页面
                            if (!info.IsDel)
                            {
                                string folderName = "";
                                if (dt.Rows[i]["NT_TempletFolderAddress"].ToString().Trim() != "") folderName = dt.Rows[i]["NT_TempletFolderAddress"].ToString().Trim() + "/";

                                bool isCreate = CreateHTMLPage(WebConfig.WebDomain + "news/" + folderName + "channel." + WebConfig.WebSuffix + "?pageindex=" + (j + 1) + "&nt_id=" + dt.Rows[i]["NT_ID"].ToString() + "&next=" + nexthtml + "&previous=" + previoushtml + "&url=/news/" + tmppath + "/index" + "&htmlsuffix=" + WebConfig.StaticPageSuffix, "news/" + tmppath, strfilename);

                                if (!isCreate)
                                {
                                    strSD_IDs += "," + dt.Rows[i]["NT_ID"].ToString();
                                }
                            }
                        }

                        UpdateColumuByWhere("NT_HTMLPage", "news/" + tmppath + "/index." + WebConfig.StaticPageSuffix, " where NT_ID=" + dt.Rows[i]["NT_ID"].ToString(), strTableName);

                    }
                }
                catch (Exception ex)
                {
                    log4net.LogManager.GetLogger("ManageError").Error("生成资讯栏目静态页面出错！", ex);
                }
                HtmlCurrent++;

                System.Threading.Thread.Sleep(100);
            }
        }
        #endregion

        #region 删除文件

        private static bool DeleteFile(string strFilePath)
        {
            string ServerPath = "/" + strFilePath;

            ServerPath = GetServerPath(ServerPath.Replace("//", "/"));
            try
            {
                if (File.Exists(ServerPath))
                {
                    File.Delete(ServerPath);
                }
                return true;
            }
            catch (Exception ex)
            {
                log.Error("删除文件出错。文件地址：" + ServerPath, ex);
                return false;
            }
        }
        #endregion


        #region 标签前缀
        public static string LabelPrefix
        {
            get { return "XY_"; }
        }
        #endregion

        #region 生成静态页面
        /// <summary>
        /// 生成静态页面
        /// </summary>
        /// <param name="moduleName">栏目名称</param>
        /// <param name="strhttpurl">访问页面地址</param>
        /// <param name="strfilename">生成文件名</param>
        /// <returns>是否成功</returns>
        private static bool CreateHTMLPage(string pageURL, string filePath, string fileName)
        {
            try
            {
                string serverPath = "";

                serverPath = GetServerPath(filePath);

                if (!Directory.Exists(serverPath))
                {
                    Directory.CreateDirectory(serverPath);
                }

                if (File.Exists(serverPath + "\\" + fileName))
                {
                    File.Delete(serverPath + "\\" + fileName);
                }

                string cFetchStr = "";
                HttpWebRequest httpRequest;

                httpRequest = (HttpWebRequest)WebRequest.Create(pageURL);
                httpRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 2.0.50727; .NET CLR 2.0.50727)";
                httpRequest.Accept = "*/*";
                HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                System.Text.Encoding strCoding = System.Text.Encoding.Default;
                StreamReader sResponseStream = new StreamReader(httpResponse.GetResponseStream(), strCoding);
                cFetchStr = sResponseStream.ReadToEnd();
                httpResponse.Close();
                sResponseStream.Close();
                System.IO.StreamWriter s;
                s = new StreamWriter((System.IO.Stream)File.OpenWrite(serverPath + "\\" + fileName), System.Text.Encoding.GetEncoding("gb2312"));

                s.WriteLine(cFetchStr); // 生成文件

                s.Flush();
                s.Close();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("生成静态页面出错。请求页面地址：" + pageURL, ex);
                return false;
            }
        }
        #endregion


        static XYECOM.Configuration.HTML cfgHTML = XYECOM.Configuration.HTML.Instance;

        /// <summary>
        /// 获取静态静态页面完整路径
        /// </summary>
        /// <param name="moduleName"></param>
        /// <param name="infoId"></param>
        /// <param name="infoPublishTime"></param>
        /// <returns></returns>
        public static string GetHTMLSavePath(string moduleName, string infoPublishTime)
        {
            string basePath = moduleName;

            if (cfgHTML._HTMLSaveMode == XYECOM.Configuration.HTMLSaveMode.Unify)
                basePath = cfgHTML.BaseDirName + "/" + basePath;

            string cFolder = ReplaceTimeAndRand(infoPublishTime, cfgHTML.Path, "");

            string tempPath = "/" + basePath + "/" + cFolder;

            return tempPath.Replace(@"\", "/").Replace(@"\\", "/").Replace("//", "/");
        }

        public static string GetHTMLSaveName(string infoId, string infoPublishTime)
        {
            string cFileName = ReplaceTimeAndRand(infoPublishTime, cfgHTML.FileName, infoId);

            return cFileName;
        }

        private static string ReplaceTimeAndRand(string baseTime, string sourceTime, string infoId)
        {
            DateTime time = XYECOM.Core.MyConvert.GetDateTime(baseTime);

            string tempStr = sourceTime;

            tempStr = tempStr.Replace("@yyyy", time.ToString("yyyy"));
            tempStr = tempStr.Replace("@MM", time.ToString("MM"));
            tempStr = tempStr.Replace("@dd", time.ToString("dd"));
            tempStr = tempStr.Replace("@HH", time.ToString("HH"));
            tempStr = tempStr.Replace("@mm", time.ToString("mm"));
            tempStr = tempStr.Replace("@ss", time.ToString("ss"));
            tempStr = tempStr.Replace("@fff", time.ToString("fff"));

            tempStr = tempStr.Replace("@Id", infoId);

            Regex r = new Regex(@"@Rand\((\d)\)");

            MatchCollection ms = r.Matches(tempStr);

            int randSize = 0;

            if (ms.Count > 0)
            {
                randSize = XYECOM.Core.MyConvert.GetInt32(ms[0].Groups[1].ToString());

                tempStr = tempStr.Replace(ms[0].Groups[0].ToString(), GetRandNumberStr(randSize));
            }

            return tempStr;
        }

        private static string GetRandNumberStr(int size)
        {
            Random rand = new Random();

            string result = "";

            for (int i = 0; i < size; i++)
            {
                result += rand.Next(10).ToString();
            }

            return result;
        }

        #region 数据库方法
        public static int UpdateColumuByWhere(string strColumuName, string strColumuValue, string strWhere, string strTableName)
        {
            int rows;
            try
            {
                SqlParameter[] parameters =	
                {
                    new SqlParameter("@TableName",SqlDbType.VarChar, 100),
                    new SqlParameter("@ColumuName",SqlDbType.VarChar,100),
                    new SqlParameter("@ColumuValue",SqlDbType.VarChar,500),
                    new SqlParameter("@StrWhere",SqlDbType.VarChar,500)
                };
                parameters[0].Value = strTableName;
                parameters[1].Value = strColumuName;
                parameters[2].Value = "'" + strColumuValue + "'";
                parameters[3].Value = strWhere;

                rows = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "usp_updatecolumubywhere", parameters);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                rows = 0;
            }
            return rows;
        }

        public static int GetRecordCount(string strTable, string strField, string strWhere)
        {
            int result = 0;

            SqlParameter[] parameters =	
				{
					new SqlParameter("@strTable",SqlDbType.VarChar),
					new SqlParameter("@strField",SqlDbType.VarChar),
					new SqlParameter("@strWhere",SqlDbType.VarChar),
                    new SqlParameter("@strCount",SqlDbType.BigInt),
				};
            parameters[0].Value = strTable;
            parameters[1].Value = strField;
            parameters[2].Value = strWhere;
            parameters[3].Direction = ParameterDirection.Output;

            result = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_GetRecordCount", parameters);
            if (parameters[3] != null)
                result = Convert.ToInt32(parameters[3].Value.ToString());
            return result;
        }
        #endregion

        #region 获取文件服务器地址
        public static string RootPath()
        {
            return RootPath("/");
        }

        public static string RootPath(string filePath)
        {
            string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            string separator = Path.DirectorySeparatorChar.ToString();
            rootPath = rootPath.Replace("/", separator);
            if (filePath != null)
            {
                filePath = filePath.Replace("/", separator);
                if (((filePath.Length > 0) && filePath.StartsWith(separator)) && rootPath.EndsWith(separator))
                {
                    rootPath = rootPath + filePath.Substring(1);
                }
                else
                {
                    rootPath = rootPath + filePath;
                }
            }
            return rootPath;
        }

        public static string PhysicalPath(string path)
        {
            return (RootPath().TrimEnd(new char[] { Path.DirectorySeparatorChar })
               + Path.DirectorySeparatorChar.ToString() + path.TrimStart(new char[] { Path.DirectorySeparatorChar }));
        }

        public static string GetServerPath(string path)
        {
            HttpContext context = HttpContext.Current;
            if (context != null)
            {
                return context.Server.MapPath(path);
            }
            return PhysicalPath(path.Replace("/", Path.DirectorySeparatorChar.ToString()).Replace("~", ""));
        }
        #endregion
    }
}
