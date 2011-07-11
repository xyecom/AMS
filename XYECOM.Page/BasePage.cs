using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Globalization;
using XYECOM.Template;
using System.Text.RegularExpressions;

namespace XYECOM.Page
{
    public class BasePage : System.Web.UI.Page
    {
        #region 上传文件所需的变量
        /// <summary>
        /// 表名
        /// </summary>
        public string tablename = "";
        /// <summary>
        /// 修改数据时已经上传的文件id
        /// </summary>
        public string ids = "";
        /// <summary>
        /// 修改数据时已经上传的文件路径
        /// </summary>
        public string files = "";
        /// <summary>
        /// 最大可以上传多少个文件
        /// </summary>
        public string maxamount = "0";
        /// <summary>
        /// 是否打水印
        /// </summary>
        public string iswatermark = "false";
        #endregion

        private float m_processtime;
        private float m_starttick;
        /// <summary>
        /// 网站全局配置信息
        /// </summary>
        protected internal XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;
        /// <summary>
        /// SEO配置信息
        /// </summary>
        protected internal XYECOM.Configuration.SEO SEO = XYECOM.Configuration.SEO.Instance;
        /// <summary>
        /// 网站全局配置信息（模板专用）
        /// </summary>
        protected internal XYECOM.Template.WebConfigInfo config = new WebConfigInfo();
        /// <summary>
        /// 网站全局模块配置信息
        /// </summary>
        protected internal XYECOM.Configuration.Module moduleConfig = XYECOM.Configuration.Module.Instance;

        //访问记录
        protected internal XYECOM.Business.PageRecordManager PageRecordBLL = new Business.PageRecordManager();
        /// <summary>
        /// 商业信息详细页面的连接地址
        /// </summary>
        protected string infourl = "";


        protected string infoimg = "";

        protected internal Template.PageSEOInfo seo = new XYECOM.Template.PageSEOInfo();

        protected internal XYECOM.Template.PageInfo pageinfo = new XYECOM.Template.PageInfo();

        protected internal int templateid;

        protected internal StringBuilder XYBody = new StringBuilder();

        protected internal string SYS_NOIMAGE_PATH = "";


        /// <summary>
        /// 共用表格变量，供模板调用方法使用
        /// </summary>
        protected DataTable data = null;
        protected DataTable data1 = null;
        protected string str = "";
        protected string str1 = "";
        protected Model.GeneralUserInfo tempuser = null;

        protected string[] array = null;

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public BasePage()
        {
            //初始化网站基本配置信息
            InitConfig();

            pageinfo.Meta = "";//<meta http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\" /> \n 
            pageinfo.PageTitle = string.Empty;
            pageinfo.PageError = 0;

            this.pageinfo.MsgboxText = "";
            this.pageinfo.MsgboxURL = "";
            this.pageinfo.PageIndex = 1;
            this.pageinfo.PageSize = 0;
            this.pageinfo.PreviousPage = "";
            this.pageinfo.PageCount = 0;

            this.pageinfo.TotalRecord = 0;

            this.pageinfo.LastPage = "";
            this.pageinfo.FirstPage = "";
            this.pageinfo.NextPage = "";
            this.pageinfo.NumPage = "";
            this.pageinfo.BarFlag = "1";
            this.m_starttick = 0;

            SYS_NOIMAGE_PATH = Business.CheckUser.SYS_NOIMAGE_PATH;

            pageinfo.IsCopyright = true;

            pageinfo.DomainHost = XYECOM.Core.Utils.GetDomainHost();


            //设置一个值是否缓冲输出，并在处理完整个页面后将其发送

            HttpContext.Current.Response.BufferOutput = false;

            //获取移初缓存信息的绝对时间
            HttpContext.Current.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);

            //将Expire HTTP标头设置为绝对时间
            HttpContext.Current.Response.Cache.SetExpires(DateTime.Now.AddDays(-1));

            //设置浏览器缓存的页过期之前的分钟数
            HttpContext.Current.Response.Expires = 0;

            HttpContext.Current.Response.CacheControl = "no-cache";

            //将Cache设置为不缓存
            HttpContext.Current.Response.Cache.SetNoStore();

            pageinfo.IsPost = XYECOM.Core.XYRequest.IsPost();
            pageinfo.IsGet = XYECOM.Core.XYRequest.IsGet();
        }
        #endregion

        #region 初始化应用程序全局配置类(模板专用)
        /// <summary>
        /// 初始化应用程序全局配置类(模板专用)
        /// </summary>
        private void InitConfig()
        {
            config.WebName = webInfo.WebName;
            config.WebURL = webInfo.WebDomain;
            config.WebLogo = webInfo.WebLogo;
            config.TemplatePath = XYECOM.Configuration.Template.Instance.Path;
            config.TemplateId = XYECOM.Configuration.Template.Instance.ID;
            config.Suffix = webInfo.WebSuffix;
            config.PasswordKey = XYECOM.Configuration.Security.Instance.PasswordKey;
            config.IsDomain = webInfo.IsDomain;
            config.BogusStatic = webInfo.IsBogusStatic;
            config.DateType = webInfo.InfoEndTimeType;
            config.RegMode = webInfo.RegisterMode;
            config.WebMoneyName = webInfo.WebMoneyName;
            config.UploadImageTypes = webInfo.UploadFileType;
            config.UploadImageSize = (int)webInfo.UploadFileSize;
            config.IssueInfoAddWebMoney = (int)webInfo.IssueInfoAddWebMoney;
            config.RefreshInfoAddWebMoney = (int)webInfo.RefreshInfoAddWebMoney;
            config.DefaultWebMoney = webInfo.UserDefaultWebMoney;
            config.LoginAddScore = webInfo.LoginAddScore;
            config.LoginAddWebMondy = (int)webInfo.LoginAddWebMoney;
            config.WebMasterEmail = webInfo.Email;
            config.CanChooseTradeNumber = webInfo.CanChooseTradeNumber;
        }
        #endregion

        #region 页面初始化
        protected override void OnInit(EventArgs e)
        {
            this.m_processtime = (Environment.TickCount - this.m_starttick) / 1000f;
            base.OnInit(e);
        }
        #endregion

        #region 向客户端发送Javascript脚本
        /// <summary>
        /// 向客户端发送Javascript脚本
        /// </summary>
        /// <param name="script">javascript脚本语言</param>
        public void WriteJavaScript(string script, bool end)
        {
            Response.Write("<script Language=\"Javascript\">");
            Response.Write(script);
            Response.Write("</");
            Response.Write("script>");
            if (end)
                Response.End();
        }
        #endregion

        #region 获取模板路径
        /// <summary>
        /// 获取模板路径
        /// </summary>
        public string Templatepath
        {
            get { return config.TemplatePath; }
        }
        #endregion

        #region 根据标签生成HTML脚本
        /// <summary>
        /// 根据标签生成HTML脚本
        /// </summary>
        /// <param name="strlabelName">标签名</param>
        /// <returns>string HTML脚本</returns>
        public string XYECOMCreateHTML(string strlabelName)
        {
            StringBuilder strHTML = new StringBuilder("");

            try
            {
                strlabelName = strlabelName.Trim().ToLower();

                if (strlabelName == "xy_copyright")
                {
                    strHTML.Append("<a href=\"http://www.xyecom.com\" target=\"_blank\">XYECS!B2B</a>");
                }
                else
                {
                    XYECOM.Label.LabelType labelType = XYECOM.Label.LabelManger.GetLabelType(strlabelName);

                    XYECOM.Label.LabelManger manager = null;

                    XYECOM.Label.ContentLabelManager contentLabelManager = null;

                    string resultHTML = "";

                    string cacheLabelName = "";

                    //临时方法
                    //如果有外部参数则改变标签缓存标识名
                    cacheLabelName = strlabelName;

                    if ((labelType == XYECOM.Label.LabelType.ContentLabel || labelType == XYECOM.Label.LabelType.ClassLabel)
                        && pageinfo.OuterAreaId > 0)
                        cacheLabelName = cacheLabelName + "_area_" + pageinfo.OuterAreaId;

                    if ((labelType == XYECOM.Label.LabelType.ContentLabel || labelType == XYECOM.Label.LabelType.ClassLabel)
                        && pageinfo.OuterTradeId > 0)
                        cacheLabelName = cacheLabelName + "_trade_" + pageinfo.OuterTradeId;

                    string cacheObj = null;

                    if (labelType == XYECOM.Label.LabelType.ContentLabel)
                        cacheObj = XYECOM.Label.LabelCache.GetCache(cacheLabelName, XYECOM.Label.LabelCacheType.ContentLabel);
                    else if (labelType == XYECOM.Label.LabelType.ClassLabel)
                        cacheObj = XYECOM.Label.LabelCache.GetCache(strlabelName, XYECOM.Label.LabelCacheType.ClassLabel);
                    else if (labelType == XYECOM.Label.LabelType.PollLabel)
                        cacheObj = XYECOM.Label.LabelCache.GetCache(strlabelName, XYECOM.Label.LabelCacheType.PollLabel);
                    else
                        cacheObj = XYECOM.Label.LabelCache.GetCache(strlabelName, XYECOM.Label.LabelCacheType.SystemLabel);

                    if (cacheObj != null) return cacheObj;


                    if (labelType == XYECOM.Label.LabelType.ContentLabel)
                    {
                        contentLabelManager = new XYECOM.Label.ContentLabelManager().GetInstance(strlabelName);

                        //标签外部参数
                        contentLabelManager.OuterParameter.AreaId = pageinfo.OuterAreaId;
                        contentLabelManager.OuterParameter.TradeId = pageinfo.OuterTradeId;
                        contentLabelManager.OuterParameter.ProTypeId = pageinfo.OuterProTypeId;
                        contentLabelManager.OuterParameter.OrderStr = pageinfo.OuterOrderStr;
                        
                        if (contentLabelManager.LabelContentType == XYECOM.Label.ContentLabelType.Pagination)
                        {
                            //分页标签需要的参数
                            contentLabelManager.PageIndex = pageinfo.PageIndex;
                            contentLabelManager.PageSize = pageinfo.PageSize;
                            contentLabelManager.CustomPageSize = pageinfo.CustomPageSize;
                            contentLabelManager.PageURL = pageinfo.PageURL;
                            contentLabelManager.StrPageSearchWhere = pageinfo.StrPageSeachWhere;
                            contentLabelManager.IsPlatForm = pageinfo.isplatform;
                        }

                        resultHTML = contentLabelManager.CreateHTML();

                        if (contentLabelManager.LabelContentType == XYECOM.Label.ContentLabelType.Pagination)
                        {
                            pageinfo.PageCount = contentLabelManager.PageCount;
                            pageinfo.NextPage = contentLabelManager.NextPage;
                            pageinfo.TotalRecord = contentLabelManager.TotalRecord;
                            pageinfo.NumPage = contentLabelManager.NumPage;
                            pageinfo.PreviousPage = contentLabelManager.PreviousPage;
                            pageinfo.FirstPage = contentLabelManager.FirstPage;
                            pageinfo.LastPage = contentLabelManager.LastPage;
                        }


                        if (!(contentLabelManager.LabelContentType == XYECOM.Label.ContentLabelType.Ranking
                            || contentLabelManager.LabelContentType == XYECOM.Label.ContentLabelType.Pagination))
                        {
                            XYECOM.Label.LabelCache.InsertCache(cacheLabelName, resultHTML, XYECOM.Label.LabelCacheType.ContentLabel);
                        }

                    }

                    if (labelType == XYECOM.Label.LabelType.ClassLabel)
                    {
                        manager = XYECOM.Label.ClassLabelManager.GetInstance(strlabelName);

                        manager.OuterParameter.AreaId = pageinfo.OuterAreaId;
                        manager.OuterParameter.TradeId = pageinfo.OuterTradeId;

                        resultHTML = manager.CreateHTML();

                        XYECOM.Label.LabelCache.InsertCache(cacheLabelName, resultHTML, XYECOM.Label.LabelCacheType.ClassLabel);
                    }

                    if (labelType == XYECOM.Label.LabelType.SystemLabel)
                    {
                        manager = XYECOM.Label.SystemLabelManager.GetInstance(strlabelName);
                        resultHTML = manager.CreateHTML();

                        XYECOM.Label.LabelCache.InsertCache(strlabelName, resultHTML, XYECOM.Label.LabelCacheType.SystemLabel);
                    }

                    if (labelType == XYECOM.Label.LabelType.PollLabel)
                    {
                        manager = XYECOM.Label.PollLabelManager.GetInstance(strlabelName);
                        resultHTML = manager.CreateHTML();

                        XYECOM.Label.LabelCache.InsertCache(strlabelName, resultHTML, XYECOM.Label.LabelCacheType.PollLabel);
                    }
                    
                    return resultHTML;
                }
            }
            catch (XYECOM.Core.LabelException lex)
            {
                strHTML.Append(lex.Message);
                WriteLog("标签解析错误", lex);
            }
            catch (Exception ex)
            {
                strHTML.Append("您的标签设置有误!");
                WriteLog("标签解析错误 ", ex);
            }
            finally
            {
                pageinfo.PageSize = 0;
            }

            return strHTML.ToString();
        }
        #endregion

        #region 显示自定义字段信息
        /// <summary>
        /// 显示自定义字段信息
        /// </summary>
        /// <param name="pt_id">产品类别编号</param>
        /// <param name="m_id">模块编号</param>
        /// <param name="infoid">用户信息编号Id</param>
        /// <returns>自定义字段信息</returns>
        public string GetFiledInnerHTML(long pt_id, string m_id, long infoid)
        {
            return string.Empty;
        }
        #endregion

        #region 判断版权
        /// <summary>
        /// 判断版权
        /// </summary>
        /// <returns></returns>
        public string IsCopyright()
        {
            if (!pageinfo.IsCopyright)
                return "<script>window.location.href=\"" + config.WebURL + "Copyright.htm\";</script>";
            else
                return "";
        }
        #endregion

        #region 错误处理

        protected override void OnError(EventArgs e)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("UserError");

            log.Error("", Server.GetLastError());
            Response.Redirect("/error.htm");
            base.OnError(e);
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="ex">标示应用程序在执行期间发生的错误</param>
        protected virtual void WriteLog(string message, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("UserError");

            log.Error(message, ex);
        }
        #endregion

        #region 获取模块的首页链接地址
        /// <summary>
        /// 获取模块的首页链接地址
        /// tc 2008-11-4
        /// </summary>
        /// <param name="moduleName">模块英文名称</param>
        /// <returns>模块首页链接地址</returns>
        protected string GetModuleIndexPageURL(string moduleName)
        {
            string value = "";

            XYECOM.Configuration.ModuleInfo moduleInfo = moduleConfig.GetItem(moduleName);

            if (moduleInfo != null)
            {
                value = webInfo.WebDomain + moduleInfo.SEName + "/";

            }
            else
            {
                switch (moduleName)
                {
                    case "exhibition":
                        value = webInfo.WebDomain + "exhibition/";
                        break;
                    case "brand":
                        value = webInfo.WebDomain + "brand/";
                        break;
                    case "company":
                        value = webInfo.WebDomain + "company/";
                        break;
                    case "news":
                        value = webInfo.WebDomain + "news/";
                        break;
                    default:
                        value = "";
                        break;
                }
            }
            return value;
        }
        #endregion

        #region 获取模块的中文名称
        /// <summary>
        /// 获取模块的中文名称(包括固定模块)
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <returns>模块的中文名称</returns>
        protected virtual string GetModuleCNName(string moduleName)
        {
            string value = "";

            XYECOM.Configuration.ModuleInfo moduleInfo = moduleConfig.GetItem(moduleName);

            if (moduleInfo != null)
            {
                value = XYECOM.Configuration.Module.Instance.GetItem(moduleName).CName;
            }
            else
            {
                switch (moduleName)
                {
                    case "exhibition":
                        value = "行业展会";
                        break;
                    case "brand":
                        value = "行业品牌";
                        break;
                    case "company":
                        value = "企业导航";
                        break;
                    case "news":
                        value = "行业资讯";
                        break;
                    default:
                        value = "";
                        break;
                }
            }
            return value;
        }
        #endregion

        #region 获取快速留言
        /// <summary>
        /// 获取快速留言 Tc 2008-10-31
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <returns>快速留言</returns>
        protected DataTable GetExpressMessage(string moduleName)
        {
            int topNumber = XYECOM.Core.MyConvert.GetInt32(webInfo.SystemMessageNumber.ToString());

            if (topNumber <= 0) return new DataTable();

            //保留老字段为兼容
            DataTable table = XYECOM.Core.Function.GetDataTableForTop(topNumber, "Body,ID,ModuleName,Body as SM_Title,Id as SM_ID,ModuleName as SM_Type", "XY_ExpressMessage", " where moduleName='general' or ModuleName='" + moduleName + "'", "");

            return table;
        }
        #endregion

        #region 分页方法

        /// <summary>
        /// 分页方法
        /// </summary>
        /// <param name="PageIndex">第几页</param>
        /// <param name="HTML">页面</param>
        /// <param name="Count">总共多少条</param>
        /// <param name="PageSize">每页多少条数据</param>
        protected virtual void SetPagination(int PageIndex, string HTML, int Count, int PageSize)
        {
            if (Count > 0)
            {
                if ((Count % PageSize) == 0)
                {
                    this.pageinfo.PageCount = (Count / PageSize);
                    if (pageinfo.PageIndex != 1)
                    {
                        if (config.BogusStatic)
                        {
                            this.pageinfo.FirstPage = "<a href=" + HTML + "-1." + config.Suffix + ">首页</a>";
                        }
                        else
                        {
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.FirstPage = "<a href=" + HTML + "&pageindex=1>首页</a>";
                            }
                            else
                            {
                                this.pageinfo.FirstPage = "<a href=" + HTML + "?pageindex=1>首页</a>";
                            }
                        }
                    }
                    else
                    {
                        this.pageinfo.FirstPage = "首页";
                    }
                    if (pageinfo.PageIndex == pageinfo.PageCount)
                    {
                        this.pageinfo.LastPage = "尾页";
                    }
                    else
                    {
                        if (config.BogusStatic)
                        {
                            this.pageinfo.LastPage = "<a href=" + HTML + "-" + pageinfo.PageCount + "." + config.Suffix + ">尾页</a>";
                        }
                        else
                        {
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.LastPage = "<a href=" + HTML + "&pageindex=" + pageinfo.PageCount + ">尾页</a>";
                            }
                            else
                            {
                                this.pageinfo.LastPage = "<a href=" + HTML + "?pageindex=" + pageinfo.PageCount + ">尾页</a>";
                            }
                        }
                    }
                    if (PageIndex >= pageinfo.PageCount && PageIndex != 1)
                    {
                        this.pageinfo.NextPage = "下一页";
                        if (config.BogusStatic)
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "-" + (PageIndex - 1) + "." + config.Suffix + ">上一页</a>";
                        }
                        else
                        {
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.PreviousPage = "<a href=" + HTML + "&pageindex=" + (PageIndex - 1) + ">上一页</a>";
                            }
                            else
                            {
                                this.pageinfo.PreviousPage = "<a href=" + HTML + "?pageindex=" + (PageIndex - 1) + ">上一页</a>";
                            }
                        }
                    }
                    else if (PageIndex <= 1 && PageIndex != pageinfo.PageCount)
                    {
                        this.pageinfo.PreviousPage = "上一页";
                        if (config.BogusStatic)
                        {
                            this.pageinfo.NextPage = "<a href=" + HTML + "-" + (PageIndex + 1) + "." + config.Suffix + ">下一页</a>";
                        }
                        else
                        {
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.NextPage = "<a href=" + HTML + "&pageindex=" + (PageIndex + 1) + ">下一页</a>";
                            }
                            else
                            {
                                this.pageinfo.NextPage = "<a href=" + HTML + "?pageindex=" + (PageIndex + 1) + ">下一页</a>";
                            }
                        }
                    }
                    else if (PageIndex > 1 && PageIndex < pageinfo.PageCount)
                    {
                        if (config.BogusStatic)
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "-" + (PageIndex - 1) + "." + config.Suffix + ">上一页</a>";
                            this.pageinfo.NextPage = "<a href=" + HTML + "-" + (PageIndex + 1) + "." + config.Suffix + ">下一页</a>";
                        }
                        else
                        {
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.NextPage = "<a href=" + HTML + "&pageindex=" + (PageIndex + 1) + ">下一页</a>";
                            }
                            else
                            {
                                this.pageinfo.NextPage = "<a href=" + HTML + "?pageindex=" + (PageIndex + 1) + ">下一页</a>";
                            }
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.PreviousPage = "<a href=" + HTML + "&pageindex=" + (PageIndex - 1) + ">上一页</a>";
                            }
                            else
                            {
                                this.pageinfo.PreviousPage = "<a href=" + HTML + "?pageindex=" + (PageIndex - 1) + ">上一页</a>";
                            }
                        }
                    }
                    else
                    {
                        this.pageinfo.PreviousPage = "上一页";
                        this.pageinfo.NextPage = "下一页";
                    }
                }
                else if ((Count % PageSize) > 0)
                {
                    this.pageinfo.PageCount = (Count / PageSize) + 1;
                    if (pageinfo.PageIndex != 1)
                    {
                        if (config.BogusStatic)
                        {
                            this.pageinfo.FirstPage = "<a href=" + HTML + "-1." + config.Suffix + ">首页</a>";
                        }
                        else
                        {
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.FirstPage = "<a href=" + HTML + "&pageindex=1>首页</a>";
                            }
                            else
                            {
                                this.pageinfo.FirstPage = "<a href=" + HTML + "?pageindex=1>首页</a>";
                            }
                        }
                    }
                    else
                    {
                        this.pageinfo.FirstPage = "首页";
                    }
                    if (pageinfo.PageIndex == pageinfo.PageCount)
                    {
                        this.pageinfo.LastPage = "尾页";
                    }
                    else
                    {
                        if (config.BogusStatic)
                        {
                            this.pageinfo.LastPage = "<a href=" + HTML + "-" + pageinfo.PageCount + "." + config.Suffix + ">尾页</a>";
                        }
                        else
                        {
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.LastPage = "<a href=" + HTML + "&pageindex=" + pageinfo.PageCount + ">尾页</a>";
                            }
                            else
                            {
                                this.pageinfo.LastPage = "<a href=" + HTML + "?pageindex=" + pageinfo.PageCount + ">尾页</a>";
                            }
                        }
                    }
                    if (PageIndex >= pageinfo.PageCount && PageIndex != 1)
                    {
                        this.pageinfo.NextPage = "下一页";
                        if (config.BogusStatic)
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "-" + (PageIndex - 1) + "." + config.Suffix + ">上一页</a>";
                        }
                        else
                        {
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.PreviousPage = "<a href=" + HTML + "&pageindex=" + (PageIndex - 1) + ">上一页</a>";
                            }
                            else
                            {
                                this.pageinfo.PreviousPage = "<a href=" + HTML + "?pageindex=" + (PageIndex - 1) + ">上一页</a>";
                            }
                        }
                    }
                    else if (PageIndex <= 1 && PageIndex != pageinfo.PageCount)
                    {
                        this.pageinfo.PreviousPage = "上一页";
                        if (config.BogusStatic)
                        {
                            this.pageinfo.NextPage = "<a href=" + HTML + "-" + (PageIndex + 1) + "." + config.Suffix + ">下一页</a>";
                        }
                        else
                        {
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.NextPage = "<a href=" + HTML + "&pageindex=" + (PageIndex + 1) + ">下一页</a>";
                            }
                            else
                            {
                                this.pageinfo.NextPage = "<a href=" + HTML + "?pageindex=" + (PageIndex + 1) + ">下一页</a>";
                            }
                        }
                    }
                    else if (PageIndex > 1 && PageIndex < pageinfo.PageCount)
                    {
                        if (config.BogusStatic)
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "-" + (PageIndex - 1) + "." + config.Suffix + ">上一页</a>";
                            this.pageinfo.NextPage = "<a href=" + HTML + "-" + (PageIndex + 1) + "." + config.Suffix + ">下一页</a>";
                        }
                        else
                        {
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.NextPage = "<a href=" + HTML + "&pageindex=" + (PageIndex + 1) + ">下一页</a>";
                            }
                            else
                            {
                                this.pageinfo.NextPage = "<a href=" + HTML + "?pageindex=" + (PageIndex + 1) + ">下一页</a>";
                            }
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.PreviousPage = "<a href=" + HTML + "&pageindex=" + (PageIndex - 1) + ">上一页</a>";
                            }
                            else
                            {
                                this.pageinfo.PreviousPage = "<a href=" + HTML + "?pageindex=" + (PageIndex - 1) + ">上一页</a>";
                            }
                        }
                    }
                    else
                    {
                        this.pageinfo.PreviousPage = "上一页";
                        this.pageinfo.NextPage = "下一页";
                    }
                }

            }
            else
            {
                this.pageinfo.FirstPage = "首页";
                this.pageinfo.PreviousPage = "上一页";
                this.pageinfo.NextPage = "下一页";
                this.pageinfo.LastPage = "尾页";
            }
        }
        #endregion

        #region 操作成功页面跳转及提示

        /// <summary>
        /// 调转到信息提示页面
        /// </summary>
        /// <param name="msgText">提示信息</param>
        /// <param name="gotoSeconds">跳转秒数</param>
        /// <param name="gotoUrl">提示完毕后自动跳转到的页面地址</param>
        protected void GotoMsgBoxPage(string msgText, int gotoSeconds, string gotoUrl)
        {
            pageinfo.PageError = 1;
            pageinfo.MsgboxText = msgText + " (" + gotoSeconds + "秒后页面将自动跳转)";
            pageinfo.MsgboxText = msgText;
            pageinfo.Meta += "<meta http-equiv=refresh content=\"" + gotoSeconds + "; url=" + gotoUrl + "\"> ";
            pageinfo.MsgboxURL = gotoUrl;
        }

        protected void GotoMsgBoxPageForDynamicPage(string msgText, int gotoSeconds, string gotoUrl)
        {
            pageinfo.PageError = 1;
            pageinfo.MsgboxText = msgText + " (" + gotoSeconds + "秒后页面将自动跳转)";
            pageinfo.MsgboxText = msgText;
            pageinfo.Meta += "<meta http-equiv=refresh content=\"" + gotoSeconds + "; url=" + gotoUrl + "\"> ";
            pageinfo.MsgboxURL = gotoUrl;
            string html = @"<html xmlns='http://www.w3.org/1999/xhtml'>
                            <head>
                            <title>消息提示</title>
                            " + pageinfo.Meta + @"
                            <link rel='stylesheet' href='/templates/default/css/global.css' type=\text/css\ media=\screen\ />
                                <style type='text/css'>
                                    #sysMsgbox .msg{ font-family:'微软雅黑','宋体'; font-size:18px;}
                                    #sysMsgbox{ font-size:14px; width:100%; text-align:center; background-color:#f2f2f2; height:100%;}
                                    #sysMsgbox ul{ width:500px; margin:0 auto;margin-top:50px;  border:1px solid #ddd; background-color:#fff; padding:10px;}
                                    #sysMsgbox ul li{ text-align:left; font-size:14px; padding:8px;}
                                    #sysMsgbox ul li a{ font-size:14px;}

                                    #syslogout .msg{ font-family:'微软雅黑','宋体'; font-size:18px;}
                                    #syslogout{ font-size:14px; width:100%; text-align:center; background-color:#f2f2f2; height:100%;}
                                    #syslogout ul{ width:500px; border:1px solid #ddd; background-color:#fff; padding:10px;
	                                    margin:0 auto;margin-top:50px; 
	                                    }
                                    #syslogout ul li{ text-align:left; font-size:14px; padding:8px;}
                                    #syslogout ul li a{ font-size:14px;}
                                </style>
                            </head>
                            <body style='background-color:#f2f2f2'>

                            <div id='sysMsgbox'>
                                <ul>
                                    <li class='msg'>" + pageinfo.MsgboxText + @"</li>
                                    <li><a href='" + pageinfo.MsgboxURL + @"'>" + pageinfo.MsgboxURL + @"</a></li>
                                     <li><a href='#' onclick='history.back();'>返回继续操作</a></li>
                                    <li><a href='/'>返回首页</a> | <a href='#' onclick='window.close();'>关闭本页</a></li>
                                </ul>
                                <div id='r_f'>2012　@Copyright　版权所有　</div>
                            </div>

                            </body>
                            </html>";
            Response.Clear();
            Response.Write(html);
            Response.End();

        }

        /// <summary>
        /// 调转到信息提示页面
        /// </summary>
        /// <param name="msgText">提示信息</param>
        /// <param name="gotoUrl">提示完毕后自动跳转到的页面地址</param>
        protected void GotoMsgBoxPage(string msgText, string gotoUrl)
        {
            pageinfo.PageError = 1;
            pageinfo.MsgboxText = msgText + " (5 秒后页面将自动跳转)";
            pageinfo.Meta += "<meta http-equiv=refresh content=\"5; url=" + gotoUrl + "\"> ";
            pageinfo.MsgboxURL = gotoUrl;
        }

        /// <summary>
        /// 调转到信息提示页面
        /// </summary>
        /// <param name="msgText">提示信息</param>
        protected void GotoMsgBoxPage(string msgText)
        {
            string backUrl = webInfo.WebDomain;

            try
            {
                backUrl = Request.UrlReferrer.AbsoluteUri;
            }
            catch { }

            pageinfo.PageError = 1;
            pageinfo.MsgboxText = msgText + "(5 秒后页面将自动跳转)";
            pageinfo.Meta += "<meta http-equiv=refresh content=\"5; url=" + backUrl + "\"> ";
            pageinfo.MsgboxURL = backUrl;
        }

        /// <summary>
        /// 直接跳转
        /// </summary>
        /// <param name="gotoUrl">跳转页面完整地址</param>
        protected void GotoPage(string gotoUrl)
        {
            System.Web.HttpContext.Current.Response.Redirect(gotoUrl);
        }
        #endregion

        #region 操作完成后的js提示
        protected void Alert(string msg)
        {
            Alert(msg, "");
        }

        protected void Alert(string msg, string url)
        {
            Alert(msg, url, false);
        }

        protected void Alert(string msg, string url, bool autoClose)
        {
            this.ClientScript.RegisterClientScriptBlock(GetType(), "01", "<script>sAlert(\"" + msg + "\",\"" + url + "\"," + autoClose.ToString().ToLower() + ")</script>");
        }

        /// <summary>
        /// js提示
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="url">跳转地址</param>
        /// <param name="autoClose">是否自动关闭</param>
        /// <param name="action">提示完毕后调用的函数或过程</param>
        protected void Alert(string msg, string url, bool autoClose, string action)
        {
            if (!action.Equals("")) action = action + ";";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "01", "<script>sAlert(\"" + msg + "\",\"" + url + "\"," + autoClose.ToString().ToLower() + ");" + action + "</script>");
        }
        #endregion

        /// <summary>
        /// 验证验证码的方法
        /// </summary>
        /// <param name="code">验证码</param>
        /// <returns>是否正确</returns>
        protected bool CheckCode(string code)
        {
            if (string.IsNullOrEmpty(code) || code.Equals("")) return false;

            if (XYECOM.Core.Utils.GetSession("VNum").ToLower() == code.ToLower())
            {
                XYECOM.Core.Utils.ClearSession("VNum");
                return true;
            }

            return false;
        }

        /// <summary>
        /// 获取信息的连接地址
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <param name="infoTypeId">信息类型Id</param>
        /// <param name="infoId">信息Id</param>
        /// <param name="htmlpage">是否有静态页面</param>
        /// <returns>信息的地址连接</returns>
        protected virtual string GetInfoUrl(string moduleName, string infoTypeId, string infoId, string htmlpage)
        {
            string url = webInfo.WebDomain + "search/{0}.aspx?flag={1}&infoid={2}";
            string bogusStaticUrl = webInfo.WebDomain + "search/{0}-{1}-{2}." + webInfo.WebSuffix;

            string strInfoType = "sell";

            List<XYECOM.Configuration.ModuleItemInfo> list = moduleConfig.GetItem(moduleName).Item;

            foreach (XYECOM.Configuration.ModuleItemInfo info in list)
            {
                if (info.ID.ToString().Equals(infoTypeId))
                {
                    if (info.InfoType == XYECOM.Configuration.InfoType.Sell)
                        strInfoType = "sell";
                    else
                        strInfoType = "buy";

                    break;
                }
            }
            if (htmlpage == "")
            {
                if (webInfo.IsBogusStatic)
                    return string.Format(bogusStaticUrl, strInfoType, moduleName, infoId);

                return string.Format(url, strInfoType, moduleName, infoId);
            }
            else
            {
                return webInfo.WebDomain + "" + htmlpage;
            }
        }
        /// <summary>
        /// 获取信息的链接地址
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <param name="infoTypeId">信息类别编号Id</param>
        /// <param name="infoId">企业用户信息</param>
        /// <param name="htmlpage"></param>
        /// <returns></returns>
        protected string GetInfoUrl(object moduleName, object infoTypeId, object infoId, object htmlpage)
        {
            if (null == moduleName || null == infoTypeId || null == infoId || null == htmlpage)
                return "";

            return GetInfoUrl(moduleName.ToString(), infoTypeId.ToString(), infoId.ToString(), htmlpage.ToString());
        }

        /// <summary>
        /// 获取信息的默认图片
        /// </summary>
        /// <param name="descTabName">目标表名称</param>
        /// <param name="infoId">用户企业信息编号</param>
        /// <returns>默认图片</returns>
        protected virtual string GetInfoImgHref(string descTabName, long infoId)
        {
            XYECOM.Model.AttachmentItem item = Business.Attachment.GetAttachmentItem(descTabName);

            return Business.Attachment.GetInfoDefaultImgHref(item, infoId);
        }

        /// <summary>
        /// 获取信息所有图片，并以数组形式返回
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <param name="infoId">信息Id</param>
        /// <returns>信息所有图片(数组形式返回)</returns>
        protected string[] GetImages(object moduleName, object infoId)
        {
            if (moduleName == null || infoId == null) return new string[] { };

            string descTabName = Business.Attachment.GetDescTabNameByModuleName(moduleName.ToString());

            if (descTabName.Equals("")) return new string[] { };

            long _infoId = Core.MyConvert.GetInt64(infoId.ToString());

            List<Model.AttachmentInfo> infos = new Business.Attachment().GetItems(_infoId, descTabName);

            string temp = "";

            foreach (Model.AttachmentInfo info in infos)
            {
                if (temp.Equals(""))
                    temp = info.Server.S_URL + info.At_Path;
                else
                    temp += "|" + info.Server.S_URL + info.At_Path;
            }

            return temp.Split('|');
        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsPostBack)
            {
                BindData();
            }
        }
        protected string FormatDate(object scDate)
        {
            string sc = string.Empty;
            if (scDate == null || string.IsNullOrEmpty(scDate.ToString()))
            {
                return string.Empty;
            }

            sc = scDate.ToString();
            DateTime resultDate;
            bool flag = DateTime.TryParse(sc, out resultDate);

            if (flag)
            {
                return resultDate.ToString("yyyy-MM-dd");
            }

            return string.Empty;

        }
        protected virtual void BindData()
        {

        }

        #region 属性 用户中心登陆用户的全局对象

        /// <summary>
        /// 是否登陆 登陆为true未登陆为false
        /// </summary>
        protected bool islogin
        {
            get
            {
                return XYECOM.Business.CheckUser.CheckUserLogin();
            }
        }

        /// <summary>
        /// 用户中心登陆用户的全局对象
        /// </summary>
        protected internal virtual XYECOM.Model.GeneralUserInfo userinfo
        {
            get
            {
                return Business.CheckUser.UserInfo;
            }
        }
        #endregion
        /// <summary>
        /// 返回长度为三的一个列表，1为标题，2为连接，3为图片路径
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        protected IList<string> GetSlidesByUserId(int userId)
        {
            IList<string> list = new List<string>();

            XYECOM.Business.SlidesManager slidesManager = new Business.SlidesManager();

            DataTable table = slidesManager.SelectByUserId(userId);

            StringBuilder titles = new StringBuilder();
            StringBuilder images = new StringBuilder();
            StringBuilder links = new StringBuilder();

            int index = 0;
            foreach (DataRow row in table.Rows)
            {
                if (index < webInfo.SlidesCount)
                {
                    titles.Append(row["SlidesTitle"]);
                    titles.Append("|");
                    string image = XYECOM.Business.Attachment.GetInfoDefaultImgHref(Model.AttachmentItem.Slides, XYECOM.Core.MyConvert.GetInt32(row["Id"].ToString()));
                    images.Append(image);
                    images.Append("|");
                    links.Append(row["Link"]);
                    links.Append("|");
                }
                index++;
            }
            if (titles.Length > 0)
            {
                list.Add(titles.Remove(titles.Length - 1, 1).ToString());
                list.Add(links.Remove(links.Length - 1, 1).ToString());
                list.Add(images.Remove(images.Length - 1, 1).ToString());
            }

            return list;
        }


        protected string FormatMoney(object scMoney)
        {
            string sc = string.Empty;
            if (scMoney == null || string.IsNullOrEmpty(scMoney.ToString()))
            {
                return string.Empty;
            }

            sc = scMoney.ToString();

            decimal resultMoney;
            bool flag = decimal.TryParse(sc, out resultMoney);

            if (flag)
            {
                return resultMoney.ToString("f2");
            }

            return string.Empty;
        }

        /// <summary>
        /// 获取订单状态值
        /// </summary>
        /// <param name="status">订单状态值</param>
        /// <param name="isBuyer">是否是采购商 采购商true ，供应商false</param>
        /// <returns></returns>
        protected string GetStatus(int status, bool isBuyer)
        {
            string statu = string.Empty;

            Model.OrderStatus os = (Model.OrderStatus)status;
            switch (os)
            {
                case XYECOM.Model.OrderStatus.WaitingForBuyerPayment:
                    statu = isBuyer ? "等待支付" : "等待采购商付款";
                    break;
                case XYECOM.Model.OrderStatus.WaitingSellerSendGoods:
                    statu = isBuyer ? "等待供应商发货" : "采购商已付款，请发货";
                    break;
                case XYECOM.Model.OrderStatus.WaitingBuyerCheckGoods:
                    statu = isBuyer ? "供应商已发货，请验货" : "已发货等待采购商验货";
                    break;
                case XYECOM.Model.OrderStatus.WaitingBuyerGeneralDeliveryOrder:
                    statu = isBuyer ? "生成提单" : "等待采购商生成提单";
                    break;
                case XYECOM.Model.OrderStatus.WaitingForBuyerCheckGoodsObjection:
                    statu = isBuyer ? "验货异议" : "采购商验货异议";
                    break;
                case XYECOM.Model.OrderStatus.Finish:
                    statu = isBuyer ? "供应商已确认收款，交易完成" : "交易完成";
                    break;
                case XYECOM.Model.OrderStatus.WaitingSellerCheckDeliveryOrder:
                    statu = isBuyer ? "等待供应商验证提单" : "验证提单";
                    break;
                case XYECOM.Model.OrderStatus.WaitingForSellerConfirmCollection:
                    statu = isBuyer ? "等待供应商确认收款" : "待确认收款";
                    break;
                case Model.OrderStatus.Lock:
                    statu = "该订单出现交易冲突，已被管理员锁定";
                    break;
                case XYECOM.Model.OrderStatus.CancelByBuyer:
                    statu = "订单被采购商取消";
                    break;
                case XYECOM.Model.OrderStatus.CancelBySupplier:
                    statu = "订单被供应商取消";
                    break;
                case XYECOM.Model.OrderStatus.CancelBySystem:
                    statu = "订单被管理员取消";
                    break;
            }
            return statu;
        }
    }
}
