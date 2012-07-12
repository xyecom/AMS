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
        #region �ϴ��ļ�����ı���
        /// <summary>
        /// ����
        /// </summary>
        public string tablename = "";
        /// <summary>
        /// �޸�����ʱ�Ѿ��ϴ����ļ�id
        /// </summary>
        public string ids = "";
        /// <summary>
        /// �޸�����ʱ�Ѿ��ϴ����ļ�·��
        /// </summary>
        public string files = "";
        /// <summary>
        /// �������ϴ����ٸ��ļ�
        /// </summary>
        public string maxamount = "0";
        /// <summary>
        /// �Ƿ��ˮӡ
        /// </summary>
        public string iswatermark = "false";
        #endregion

        private float m_processtime;
        private float m_starttick;
        /// <summary>
        /// ��վȫ��������Ϣ
        /// </summary>
        protected internal XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;
        /// <summary>
        /// SEO������Ϣ
        /// </summary>
        protected internal XYECOM.Configuration.SEO SEO = XYECOM.Configuration.SEO.Instance;
        /// <summary>
        /// ��վȫ��������Ϣ��ģ��ר�ã�
        /// </summary>
        protected internal XYECOM.Template.WebConfigInfo config = new WebConfigInfo();
        /// <summary>
        /// ��վȫ��ģ��������Ϣ
        /// </summary>
        protected internal XYECOM.Configuration.Module moduleConfig = XYECOM.Configuration.Module.Instance;

        //���ʼ�¼
        protected internal XYECOM.Business.PageRecordManager PageRecordBLL = new Business.PageRecordManager();
        /// <summary>
        /// ��ҵ��Ϣ��ϸҳ������ӵ�ַ
        /// </summary>
        protected string infourl = "";


        protected string infoimg = "";

        protected internal Template.PageSEOInfo seo = new XYECOM.Template.PageSEOInfo();

        protected internal XYECOM.Template.PageInfo pageinfo = new XYECOM.Template.PageInfo();

        protected internal int templateid;

        protected internal StringBuilder XYBody = new StringBuilder();

        protected internal string SYS_NOIMAGE_PATH = "";


        /// <summary>
        /// ���ñ���������ģ����÷���ʹ��
        /// </summary>
        protected DataTable data = null;
        protected DataTable data1 = null;
        protected string str = "";
        protected string str1 = "";
        protected Model.GeneralUserInfo tempuser = null;

        protected string[] array = null;

        #region ��ʼ��
        /// <summary>
        /// ��ʼ��
        /// </summary>
        public BasePage()
        {
            //��ʼ����վ����������Ϣ
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


            //����һ��ֵ�Ƿ񻺳���������ڴ���������ҳ����䷢��

            HttpContext.Current.Response.BufferOutput = false;

            //��ȡ�Ƴ�������Ϣ�ľ���ʱ��
            HttpContext.Current.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);

            //��Expire HTTP��ͷ����Ϊ����ʱ��
            HttpContext.Current.Response.Cache.SetExpires(DateTime.Now.AddDays(-1));

            //��������������ҳ����֮ǰ�ķ�����
            HttpContext.Current.Response.Expires = 0;

            HttpContext.Current.Response.CacheControl = "no-cache";

            //��Cache����Ϊ������
            HttpContext.Current.Response.Cache.SetNoStore();

            pageinfo.IsPost = XYECOM.Core.XYRequest.IsPost();
            pageinfo.IsGet = XYECOM.Core.XYRequest.IsGet();
        }
        #endregion

        #region ��ʼ��Ӧ�ó���ȫ��������(ģ��ר��)
        /// <summary>
        /// ��ʼ��Ӧ�ó���ȫ��������(ģ��ר��)
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

        #region ҳ���ʼ��
        protected override void OnInit(EventArgs e)
        {
            this.m_processtime = (Environment.TickCount - this.m_starttick) / 1000f;
            base.OnInit(e);
        }
        #endregion

        #region ��ͻ��˷���Javascript�ű�
        /// <summary>
        /// ��ͻ��˷���Javascript�ű�
        /// </summary>
        /// <param name="script">javascript�ű�����</param>
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

        #region ��ȡģ��·��
        /// <summary>
        /// ��ȡģ��·��
        /// </summary>
        public string Templatepath
        {
            get { return config.TemplatePath; }
        }
        #endregion

        #region ���ݱ�ǩ����HTML�ű�
        /// <summary>
        /// ���ݱ�ǩ����HTML�ű�
        /// </summary>
        /// <param name="strlabelName">��ǩ��</param>
        /// <returns>string HTML�ű�</returns>
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

                    //��ʱ����
                    //������ⲿ������ı��ǩ�����ʶ��
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

                        //��ǩ�ⲿ����
                        contentLabelManager.OuterParameter.AreaId = pageinfo.OuterAreaId;
                        contentLabelManager.OuterParameter.TradeId = pageinfo.OuterTradeId;
                        contentLabelManager.OuterParameter.ProTypeId = pageinfo.OuterProTypeId;
                        contentLabelManager.OuterParameter.OrderStr = pageinfo.OuterOrderStr;
                        
                        if (contentLabelManager.LabelContentType == XYECOM.Label.ContentLabelType.Pagination)
                        {
                            //��ҳ��ǩ��Ҫ�Ĳ���
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
                WriteLog("��ǩ��������", lex);
            }
            catch (Exception ex)
            {
                strHTML.Append("���ı�ǩ��������!");
                WriteLog("��ǩ�������� ", ex);
            }
            finally
            {
                pageinfo.PageSize = 0;
            }

            return strHTML.ToString();
        }
        #endregion

        #region ��ʾ�Զ����ֶ���Ϣ
        /// <summary>
        /// ��ʾ�Զ����ֶ���Ϣ
        /// </summary>
        /// <param name="pt_id">��Ʒ�����</param>
        /// <param name="m_id">ģ����</param>
        /// <param name="infoid">�û���Ϣ���Id</param>
        /// <returns>�Զ����ֶ���Ϣ</returns>
        public string GetFiledInnerHTML(long pt_id, string m_id, long infoid)
        {
            return string.Empty;
        }
        #endregion

        #region �жϰ�Ȩ
        /// <summary>
        /// �жϰ�Ȩ
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

        #region ������

        protected override void OnError(EventArgs e)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("UserError");

            log.Error("", Server.GetLastError());
            Response.Redirect("/error.htm");
            base.OnError(e);
        }
        /// <summary>
        /// д��־
        /// </summary>
        /// <param name="message">��־��Ϣ</param>
        /// <param name="ex">��ʾӦ�ó�����ִ���ڼ䷢���Ĵ���</param>
        protected virtual void WriteLog(string message, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("UserError");

            log.Error(message, ex);
        }
        #endregion

        #region ��ȡģ�����ҳ���ӵ�ַ
        /// <summary>
        /// ��ȡģ�����ҳ���ӵ�ַ
        /// tc 2008-11-4
        /// </summary>
        /// <param name="moduleName">ģ��Ӣ������</param>
        /// <returns>ģ����ҳ���ӵ�ַ</returns>
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

        #region ��ȡģ�����������
        /// <summary>
        /// ��ȡģ�����������(�����̶�ģ��)
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <returns>ģ�����������</returns>
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
                        value = "��ҵչ��";
                        break;
                    case "brand":
                        value = "��ҵƷ��";
                        break;
                    case "company":
                        value = "��ҵ����";
                        break;
                    case "news":
                        value = "��ҵ��Ѷ";
                        break;
                    default:
                        value = "";
                        break;
                }
            }
            return value;
        }
        #endregion

        #region ��ȡ��������
        /// <summary>
        /// ��ȡ�������� Tc 2008-10-31
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <returns>��������</returns>
        protected DataTable GetExpressMessage(string moduleName)
        {
            int topNumber = XYECOM.Core.MyConvert.GetInt32(webInfo.SystemMessageNumber.ToString());

            if (topNumber <= 0) return new DataTable();

            //�������ֶ�Ϊ����
            DataTable table = XYECOM.Core.Function.GetDataTableForTop(topNumber, "Body,ID,ModuleName,Body as SM_Title,Id as SM_ID,ModuleName as SM_Type", "XY_ExpressMessage", " where moduleName='general' or ModuleName='" + moduleName + "'", "");

            return table;
        }
        #endregion

        #region ��ҳ����

        /// <summary>
        /// ��ҳ����
        /// </summary>
        /// <param name="PageIndex">�ڼ�ҳ</param>
        /// <param name="HTML">ҳ��</param>
        /// <param name="Count">�ܹ�������</param>
        /// <param name="PageSize">ÿҳ����������</param>
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
                            this.pageinfo.FirstPage = "<a href=" + HTML + "-1." + config.Suffix + ">��ҳ</a>";
                        }
                        else
                        {
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.FirstPage = "<a href=" + HTML + "&pageindex=1>��ҳ</a>";
                            }
                            else
                            {
                                this.pageinfo.FirstPage = "<a href=" + HTML + "?pageindex=1>��ҳ</a>";
                            }
                        }
                    }
                    else
                    {
                        this.pageinfo.FirstPage = "��ҳ";
                    }
                    if (pageinfo.PageIndex == pageinfo.PageCount)
                    {
                        this.pageinfo.LastPage = "βҳ";
                    }
                    else
                    {
                        if (config.BogusStatic)
                        {
                            this.pageinfo.LastPage = "<a href=" + HTML + "-" + pageinfo.PageCount + "." + config.Suffix + ">βҳ</a>";
                        }
                        else
                        {
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.LastPage = "<a href=" + HTML + "&pageindex=" + pageinfo.PageCount + ">βҳ</a>";
                            }
                            else
                            {
                                this.pageinfo.LastPage = "<a href=" + HTML + "?pageindex=" + pageinfo.PageCount + ">βҳ</a>";
                            }
                        }
                    }
                    if (PageIndex >= pageinfo.PageCount && PageIndex != 1)
                    {
                        this.pageinfo.NextPage = "��һҳ";
                        if (config.BogusStatic)
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "-" + (PageIndex - 1) + "." + config.Suffix + ">��һҳ</a>";
                        }
                        else
                        {
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.PreviousPage = "<a href=" + HTML + "&pageindex=" + (PageIndex - 1) + ">��һҳ</a>";
                            }
                            else
                            {
                                this.pageinfo.PreviousPage = "<a href=" + HTML + "?pageindex=" + (PageIndex - 1) + ">��һҳ</a>";
                            }
                        }
                    }
                    else if (PageIndex <= 1 && PageIndex != pageinfo.PageCount)
                    {
                        this.pageinfo.PreviousPage = "��һҳ";
                        if (config.BogusStatic)
                        {
                            this.pageinfo.NextPage = "<a href=" + HTML + "-" + (PageIndex + 1) + "." + config.Suffix + ">��һҳ</a>";
                        }
                        else
                        {
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.NextPage = "<a href=" + HTML + "&pageindex=" + (PageIndex + 1) + ">��һҳ</a>";
                            }
                            else
                            {
                                this.pageinfo.NextPage = "<a href=" + HTML + "?pageindex=" + (PageIndex + 1) + ">��һҳ</a>";
                            }
                        }
                    }
                    else if (PageIndex > 1 && PageIndex < pageinfo.PageCount)
                    {
                        if (config.BogusStatic)
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "-" + (PageIndex - 1) + "." + config.Suffix + ">��һҳ</a>";
                            this.pageinfo.NextPage = "<a href=" + HTML + "-" + (PageIndex + 1) + "." + config.Suffix + ">��һҳ</a>";
                        }
                        else
                        {
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.NextPage = "<a href=" + HTML + "&pageindex=" + (PageIndex + 1) + ">��һҳ</a>";
                            }
                            else
                            {
                                this.pageinfo.NextPage = "<a href=" + HTML + "?pageindex=" + (PageIndex + 1) + ">��һҳ</a>";
                            }
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.PreviousPage = "<a href=" + HTML + "&pageindex=" + (PageIndex - 1) + ">��һҳ</a>";
                            }
                            else
                            {
                                this.pageinfo.PreviousPage = "<a href=" + HTML + "?pageindex=" + (PageIndex - 1) + ">��һҳ</a>";
                            }
                        }
                    }
                    else
                    {
                        this.pageinfo.PreviousPage = "��һҳ";
                        this.pageinfo.NextPage = "��һҳ";
                    }
                }
                else if ((Count % PageSize) > 0)
                {
                    this.pageinfo.PageCount = (Count / PageSize) + 1;
                    if (pageinfo.PageIndex != 1)
                    {
                        if (config.BogusStatic)
                        {
                            this.pageinfo.FirstPage = "<a href=" + HTML + "-1." + config.Suffix + ">��ҳ</a>";
                        }
                        else
                        {
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.FirstPage = "<a href=" + HTML + "&pageindex=1>��ҳ</a>";
                            }
                            else
                            {
                                this.pageinfo.FirstPage = "<a href=" + HTML + "?pageindex=1>��ҳ</a>";
                            }
                        }
                    }
                    else
                    {
                        this.pageinfo.FirstPage = "��ҳ";
                    }
                    if (pageinfo.PageIndex == pageinfo.PageCount)
                    {
                        this.pageinfo.LastPage = "βҳ";
                    }
                    else
                    {
                        if (config.BogusStatic)
                        {
                            this.pageinfo.LastPage = "<a href=" + HTML + "-" + pageinfo.PageCount + "." + config.Suffix + ">βҳ</a>";
                        }
                        else
                        {
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.LastPage = "<a href=" + HTML + "&pageindex=" + pageinfo.PageCount + ">βҳ</a>";
                            }
                            else
                            {
                                this.pageinfo.LastPage = "<a href=" + HTML + "?pageindex=" + pageinfo.PageCount + ">βҳ</a>";
                            }
                        }
                    }
                    if (PageIndex >= pageinfo.PageCount && PageIndex != 1)
                    {
                        this.pageinfo.NextPage = "��һҳ";
                        if (config.BogusStatic)
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "-" + (PageIndex - 1) + "." + config.Suffix + ">��һҳ</a>";
                        }
                        else
                        {
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.PreviousPage = "<a href=" + HTML + "&pageindex=" + (PageIndex - 1) + ">��һҳ</a>";
                            }
                            else
                            {
                                this.pageinfo.PreviousPage = "<a href=" + HTML + "?pageindex=" + (PageIndex - 1) + ">��һҳ</a>";
                            }
                        }
                    }
                    else if (PageIndex <= 1 && PageIndex != pageinfo.PageCount)
                    {
                        this.pageinfo.PreviousPage = "��һҳ";
                        if (config.BogusStatic)
                        {
                            this.pageinfo.NextPage = "<a href=" + HTML + "-" + (PageIndex + 1) + "." + config.Suffix + ">��һҳ</a>";
                        }
                        else
                        {
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.NextPage = "<a href=" + HTML + "&pageindex=" + (PageIndex + 1) + ">��һҳ</a>";
                            }
                            else
                            {
                                this.pageinfo.NextPage = "<a href=" + HTML + "?pageindex=" + (PageIndex + 1) + ">��һҳ</a>";
                            }
                        }
                    }
                    else if (PageIndex > 1 && PageIndex < pageinfo.PageCount)
                    {
                        if (config.BogusStatic)
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "-" + (PageIndex - 1) + "." + config.Suffix + ">��һҳ</a>";
                            this.pageinfo.NextPage = "<a href=" + HTML + "-" + (PageIndex + 1) + "." + config.Suffix + ">��һҳ</a>";
                        }
                        else
                        {
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.NextPage = "<a href=" + HTML + "&pageindex=" + (PageIndex + 1) + ">��һҳ</a>";
                            }
                            else
                            {
                                this.pageinfo.NextPage = "<a href=" + HTML + "?pageindex=" + (PageIndex + 1) + ">��һҳ</a>";
                            }
                            if (HTML.IndexOf("?") > 0)
                            {
                                this.pageinfo.PreviousPage = "<a href=" + HTML + "&pageindex=" + (PageIndex - 1) + ">��һҳ</a>";
                            }
                            else
                            {
                                this.pageinfo.PreviousPage = "<a href=" + HTML + "?pageindex=" + (PageIndex - 1) + ">��һҳ</a>";
                            }
                        }
                    }
                    else
                    {
                        this.pageinfo.PreviousPage = "��һҳ";
                        this.pageinfo.NextPage = "��һҳ";
                    }
                }

            }
            else
            {
                this.pageinfo.FirstPage = "��ҳ";
                this.pageinfo.PreviousPage = "��һҳ";
                this.pageinfo.NextPage = "��һҳ";
                this.pageinfo.LastPage = "βҳ";
            }
        }
        #endregion

        #region �����ɹ�ҳ����ת����ʾ

        /// <summary>
        /// ��ת����Ϣ��ʾҳ��
        /// </summary>
        /// <param name="msgText">��ʾ��Ϣ</param>
        /// <param name="gotoSeconds">��ת����</param>
        /// <param name="gotoUrl">��ʾ��Ϻ��Զ���ת����ҳ���ַ</param>
        protected void GotoMsgBoxPage(string msgText, int gotoSeconds, string gotoUrl)
        {
            pageinfo.PageError = 1;
            pageinfo.MsgboxText = msgText + " (" + gotoSeconds + "���ҳ�潫�Զ���ת)";
            pageinfo.MsgboxText = msgText;
            pageinfo.Meta += "<meta http-equiv=refresh content=\"" + gotoSeconds + "; url=" + gotoUrl + "\"> ";
            pageinfo.MsgboxURL = gotoUrl;
        }

        protected void GotoMsgBoxPageForDynamicPage(string msgText, int gotoSeconds, string gotoUrl)
        {
            pageinfo.PageError = 1;
            pageinfo.MsgboxText = msgText + " (" + gotoSeconds + "���ҳ�潫�Զ���ת)";
            pageinfo.MsgboxText = msgText;
            pageinfo.Meta += "<meta http-equiv=refresh content=\"" + gotoSeconds + "; url=" + gotoUrl + "\"> ";
            pageinfo.MsgboxURL = gotoUrl;
            string html = @"<html xmlns='http://www.w3.org/1999/xhtml'>
                            <head>
                            <title>��Ϣ��ʾ</title>
                            " + pageinfo.Meta + @"
                            <link rel='stylesheet' href='/templates/default/css/global.css' type=\text/css\ media=\screen\ />
                                <style type='text/css'>
                                    #sysMsgbox .msg{ font-family:'΢���ź�','����'; font-size:18px;}
                                    #sysMsgbox{ font-size:14px; width:100%; text-align:center; background-color:#f2f2f2; height:100%;}
                                    #sysMsgbox ul{ width:500px; margin:0 auto;margin-top:50px;  border:1px solid #ddd; background-color:#fff; padding:10px;}
                                    #sysMsgbox ul li{ text-align:left; font-size:14px; padding:8px;}
                                    #sysMsgbox ul li a{ font-size:14px;}

                                    #syslogout .msg{ font-family:'΢���ź�','����'; font-size:18px;}
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
                                     <li><a href='#' onclick='history.back();'>���ؼ�������</a></li>
                                    <li><a href='/'>������ҳ</a> | <a href='#' onclick='window.close();'>�رձ�ҳ</a></li>
                                </ul>
                                <div id='r_f'>2012��@Copyright����Ȩ���С�</div>
                            </div>

                            </body>
                            </html>";
            Response.Clear();
            Response.Write(html);
            Response.End();

        }

        /// <summary>
        /// ��ת����Ϣ��ʾҳ��
        /// </summary>
        /// <param name="msgText">��ʾ��Ϣ</param>
        /// <param name="gotoUrl">��ʾ��Ϻ��Զ���ת����ҳ���ַ</param>
        protected void GotoMsgBoxPage(string msgText, string gotoUrl)
        {
            pageinfo.PageError = 1;
            pageinfo.MsgboxText = msgText + " (5 ���ҳ�潫�Զ���ת)";
            pageinfo.Meta += "<meta http-equiv=refresh content=\"5; url=" + gotoUrl + "\"> ";
            pageinfo.MsgboxURL = gotoUrl;
        }

        /// <summary>
        /// ��ת����Ϣ��ʾҳ��
        /// </summary>
        /// <param name="msgText">��ʾ��Ϣ</param>
        protected void GotoMsgBoxPage(string msgText)
        {
            string backUrl = webInfo.WebDomain;

            try
            {
                backUrl = Request.UrlReferrer.AbsoluteUri;
            }
            catch { }

            pageinfo.PageError = 1;
            pageinfo.MsgboxText = msgText + "(5 ���ҳ�潫�Զ���ת)";
            pageinfo.Meta += "<meta http-equiv=refresh content=\"5; url=" + backUrl + "\"> ";
            pageinfo.MsgboxURL = backUrl;
        }

        /// <summary>
        /// ֱ����ת
        /// </summary>
        /// <param name="gotoUrl">��תҳ��������ַ</param>
        protected void GotoPage(string gotoUrl)
        {
            System.Web.HttpContext.Current.Response.Redirect(gotoUrl);
        }
        #endregion

        #region ������ɺ��js��ʾ
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
        /// js��ʾ
        /// </summary>
        /// <param name="msg">��Ϣ</param>
        /// <param name="url">��ת��ַ</param>
        /// <param name="autoClose">�Ƿ��Զ��ر�</param>
        /// <param name="action">��ʾ��Ϻ���õĺ��������</param>
        protected void Alert(string msg, string url, bool autoClose, string action)
        {
            if (!action.Equals("")) action = action + ";";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "01", "<script>sAlert(\"" + msg + "\",\"" + url + "\"," + autoClose.ToString().ToLower() + ");" + action + "</script>");
        }
        #endregion

        /// <summary>
        /// ��֤��֤��ķ���
        /// </summary>
        /// <param name="code">��֤��</param>
        /// <returns>�Ƿ���ȷ</returns>
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
        /// ��ȡ��Ϣ�����ӵ�ַ
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="infoTypeId">��Ϣ����Id</param>
        /// <param name="infoId">��ϢId</param>
        /// <param name="htmlpage">�Ƿ��о�̬ҳ��</param>
        /// <returns>��Ϣ�ĵ�ַ����</returns>
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
        /// ��ȡ��Ϣ�����ӵ�ַ
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="infoTypeId">��Ϣ�����Id</param>
        /// <param name="infoId">��ҵ�û���Ϣ</param>
        /// <param name="htmlpage"></param>
        /// <returns></returns>
        protected string GetInfoUrl(object moduleName, object infoTypeId, object infoId, object htmlpage)
        {
            if (null == moduleName || null == infoTypeId || null == infoId || null == htmlpage)
                return "";

            return GetInfoUrl(moduleName.ToString(), infoTypeId.ToString(), infoId.ToString(), htmlpage.ToString());
        }

        /// <summary>
        /// ��ȡ��Ϣ��Ĭ��ͼƬ
        /// </summary>
        /// <param name="descTabName">Ŀ�������</param>
        /// <param name="infoId">�û���ҵ��Ϣ���</param>
        /// <returns>Ĭ��ͼƬ</returns>
        protected virtual string GetInfoImgHref(string descTabName, long infoId)
        {
            XYECOM.Model.AttachmentItem item = Business.Attachment.GetAttachmentItem(descTabName);

            return Business.Attachment.GetInfoDefaultImgHref(item, infoId);
        }

        /// <summary>
        /// ��ȡ��Ϣ����ͼƬ������������ʽ����
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="infoId">��ϢId</param>
        /// <returns>��Ϣ����ͼƬ(������ʽ����)</returns>
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

        #region ���� �û����ĵ�½�û���ȫ�ֶ���

        /// <summary>
        /// �Ƿ��½ ��½Ϊtrueδ��½Ϊfalse
        /// </summary>
        protected bool islogin
        {
            get
            {
                return XYECOM.Business.CheckUser.CheckUserLogin();
            }
        }

        /// <summary>
        /// �û����ĵ�½�û���ȫ�ֶ���
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
        /// ���س���Ϊ����һ���б�1Ϊ���⣬2Ϊ���ӣ�3ΪͼƬ·��
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
        /// ��ȡ����״ֵ̬
        /// </summary>
        /// <param name="status">����״ֵ̬</param>
        /// <param name="isBuyer">�Ƿ��ǲɹ��� �ɹ���true ����Ӧ��false</param>
        /// <returns></returns>
        protected string GetStatus(int status, bool isBuyer)
        {
            string statu = string.Empty;

            Model.OrderStatus os = (Model.OrderStatus)status;
            switch (os)
            {
                case XYECOM.Model.OrderStatus.WaitingForBuyerPayment:
                    statu = isBuyer ? "�ȴ�֧��" : "�ȴ��ɹ��̸���";
                    break;
                case XYECOM.Model.OrderStatus.WaitingSellerSendGoods:
                    statu = isBuyer ? "�ȴ���Ӧ�̷���" : "�ɹ����Ѹ���뷢��";
                    break;
                case XYECOM.Model.OrderStatus.WaitingBuyerCheckGoods:
                    statu = isBuyer ? "��Ӧ���ѷ����������" : "�ѷ����ȴ��ɹ������";
                    break;
                case XYECOM.Model.OrderStatus.WaitingBuyerGeneralDeliveryOrder:
                    statu = isBuyer ? "�����ᵥ" : "�ȴ��ɹ��������ᵥ";
                    break;
                case XYECOM.Model.OrderStatus.WaitingForBuyerCheckGoodsObjection:
                    statu = isBuyer ? "�������" : "�ɹ����������";
                    break;
                case XYECOM.Model.OrderStatus.Finish:
                    statu = isBuyer ? "��Ӧ����ȷ���տ�������" : "�������";
                    break;
                case XYECOM.Model.OrderStatus.WaitingSellerCheckDeliveryOrder:
                    statu = isBuyer ? "�ȴ���Ӧ����֤�ᵥ" : "��֤�ᵥ";
                    break;
                case XYECOM.Model.OrderStatus.WaitingForSellerConfirmCollection:
                    statu = isBuyer ? "�ȴ���Ӧ��ȷ���տ�" : "��ȷ���տ�";
                    break;
                case Model.OrderStatus.Lock:
                    statu = "�ö������ֽ��׳�ͻ���ѱ�����Ա����";
                    break;
                case XYECOM.Model.OrderStatus.CancelByBuyer:
                    statu = "�������ɹ���ȡ��";
                    break;
                case XYECOM.Model.OrderStatus.CancelBySupplier:
                    statu = "��������Ӧ��ȡ��";
                    break;
                case XYECOM.Model.OrderStatus.CancelBySystem:
                    statu = "����������Աȡ��";
                    break;
            }
            return statu;
        }
    }
}
