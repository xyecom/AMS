using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.Caching;
using XYECOM.Model;

namespace XYECOM.Page.shop
{

    public class ShopBasePage : BasePage
    {
        //�����ؼ���
        protected string keyword = string.Empty;

        protected string userName = "";

        protected string infotype = "company";

        protected string infoid = "";

        protected string infolilstlink = "";

        protected string year = "";
        protected string linktype = "";

        protected XYECOM.Model.GeneralUserInfo shopuserinfo = new XYECOM.Model.GeneralUserInfo();

        protected XYECOM.Configuration.Shop shopConfig = XYECOM.Configuration.Shop.Instance;

        protected bool isTopDomain = false;

        protected string userTopDomain = "";


        protected override void OnLoad(EventArgs e)
        {
            XYECOM.Model.UserRegInfo userRegInfo = null;
            string userName = XYECOM.Core.XYRequest.GetQueryString("u_name");
            string userTopDomain = string.Empty;
            if (!string.IsNullOrEmpty(userName))
            {
                userRegInfo = new XYECOM.Business.UserReg().GetItem(userName);
            }
            else if (!string.IsNullOrEmpty((userTopDomain = XYECOM.Core.XYRequest.GetQueryString("udomain"))))
            {
                isTopDomain = true;

                XYECOM.Model.UserDomainInfo udInfo = new Business.UserDomain().GetItem(userTopDomain);

                if (udInfo == null)
                {
                    GotoMsgBoxPage("��������", "/index." + config.suffix);
                    return;
                }

                userRegInfo = new XYECOM.Business.UserReg().GetItem(udInfo.UserId);
            }
            else
            {
                GotoMsgBoxPage("��������", "/index." + config.suffix);
                return;
            }

            if (userRegInfo == null || userRegInfo.AuditingState != XYECOM.Model.AuditingState.Passed)
            {
                GotoMsgBoxPage("�û������ڻ�δ�����ͨ����", "/index." + config.suffix);
                return;
            }

            shopuserinfo = Business.CheckUser.GetUserInfo(userRegInfo);

            Model.UserAnnounceInfo announce = new Business.UserAnnounce().GetItem(userRegInfo.UserId);

            if (announce != null) shopuserinfo.shopannounce = announce.Centent;

            shopuserinfo.banner = Business.Attachment.GetInfoDefaultImgHref(XYECOM.Model.AttachmentItem.Banner, userRegInfo.UserId, "");

            shopuserinfo.logo = Business.Attachment.GetInfoDefaultImgHref(XYECOM.Model.AttachmentItem.Logo, userRegInfo.UserId, "");
            year = shopuserinfo.years;

            IList<string> list = GetSlidesByUserId(shopuserinfo.userid);
            if (list.Count > 0)
            {
                SlidesImages = list[2];
                SlidesLinks = list[1];
                SlidesTitles = list[0];
            }

            Model.AttachmentInfo info = XYECOM.Business.Attachment.GetItemInfoOfVideo(shopuserinfo.userid);

            if (info != null)
            {
                flvpath = info.FullPath;
            }
            base.OnLoad(e);
        }

        /// <summary>
        /// ����SEO
        /// </summary>
        protected virtual XYECOM.Model.UserSEOFlag UserSeoFlg
        {
            get
            {
                return XYECOM.Model.UserSEOFlag.Index;
            }
        }

        #region ��ʼ����Ϣ�б��������
        /// <summary>
        /// ��ʼ����Ϣ�б�����
        /// </summary>
        /// <param name="currentModuleName">ģ������</param>
        protected void InitInfoLinkList(string currentModuleName)
        {
            StringBuilder menuHTML = new StringBuilder("");

            string parentName = "";
            foreach (XYECOM.Configuration.ModuleInfo info in moduleConfig.ModuleItems)
            {
                if (info.State == false) continue;
                if (info.EName == "offer" || info.EName == "venture") continue;

                parentName = info.EName;
                if (!info.PEName.Equals("")) parentName = info.PEName;

                if (info.EName.Equals(currentModuleName))
                {
                    menuHTML.Append("<li>");
                    menuHTML.Append(info.CName);
                    menuHTML.Append("</li>");
                }
                else
                {
                    menuHTML.Append("<li><a href='");
                    menuHTML.Append(GetListLink(parentName, info.EName));
                    menuHTML.Append("'>");
                    menuHTML.Append("").Append(info.CName);
                    menuHTML.Append("</a></li>");
                }
            }

            pageinfo.InfoListLink = menuHTML.ToString();
        }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="parentModuleName">��ģ������</param>
        /// <param name="moduleName">ģ������</param>
        /// <returns>����</returns>
        private string GetListLink(string parentModuleName, string moduleName)
        {
            string href = "";
            if (!parentModuleName.Equals(""))
            {
                if (webInfo.IsDomain)
                {
                    href = parentModuleName + "." + webInfo.WebSuffix;
                    if (!parentModuleName.Equals(moduleName)) href += "?ename=" + moduleName;
                }
                else
                    if (webInfo.IsBogusStatic)
                    {
                        href = webInfo.WebDomain + "shop/" + shopuserinfo.loginname + "/" + parentModuleName + "." + webInfo.WebSuffix;
                        if (!parentModuleName.Equals(moduleName)) href += "?ename=" + moduleName;
                    }
                    else
                    {
                        href = webInfo.WebDomain + "shop/" + parentModuleName + "." + webInfo.WebSuffix + "?u_name=" + shopuserinfo.loginname;
                        if (!parentModuleName.Equals(moduleName)) href += "&ename=" + moduleName;
                    }
            }


            return href;
        }
        #endregion

        /// <summary>
        /// ��ȡģ������
        /// </summary>
        /// <param name="defaultModuleName">Ĭ��ģ������</param>
        /// <returns>ģ������</returns>
        protected string GetCurrentModuleName(string defaultModuleName)
        {
            string url = System.Web.HttpContext.Current.Request.RawUrl;
            string value = defaultModuleName;

            if (url.Contains("ename="))
            {
                value = url.Substring(url.IndexOf("ename=") + 6);
            }
            return value;
        }

        #region ������ҳ����÷���

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <returns>��������</returns>
        protected DataTable GetLink()
        {
            XYECOM.Business.UserFirendLink link = new XYECOM.Business.UserFirendLink();

            return link.GetDataTable(shopuserinfo.userid);
        }

        /// <summary>
        /// ��ȡָ��ģ����ָ������������
        /// (�ֶι̶�Ϊ��infoid,infoTitle,infoFlag,htmlPage,isHasimage)
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="topNumber">��������(1��100)</param>
        /// <returns>ָ��ģ����ָ������������</returns>
        protected DataTable GetData(string moduleName, int topNumber)
        {
            return GetData(moduleName, topNumber, "sell");
        }

        /// <summary>
        /// ��ȡָ��ģ����ָ������������
        /// (�ֶι̶�Ϊ��infoid,infoTitle,infoFlag,htmlPage,isHasimage)
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="topNumber">��������(1��100)</param>
        /// <param name="typeFlag">�����ʾ���̶��ֶ�(��:sell,��:buy)</param>
        /// <returns>ָ��ģ����ָ������������</returns>
        protected DataTable GetData(string moduleName, int topNumber, string typeFlag)
        {
            if (string.IsNullOrEmpty(moduleName)) return new DataTable();

            moduleName = moduleName.Trim();

            if (moduleName.Equals("")) return new DataTable();

            if (topNumber <= 0) topNumber = 10;

            if (topNumber > 100) topNumber = 100;

            return Business.XYInfo.GetDataByModuleAndUserId(moduleName, shopuserinfo.userid, topNumber, typeFlag);
        }

        #region ��ȡ��Ϣ�����ӵ�ַ
        /// <summary>
        /// ��ȡ��Ϣ�����ӵ�ַ(����Ʒ�ƣ�֤���б������б��˲��б�)
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="infoId">��ϢId</param>
        /// <param name="htmlpage">�Ƿ��о�̬ҳ��</param>
        /// <returns>��Ϣ�����ӵ�ַ</returns>
        protected string GetInfoUrl(string moduleName, string infoId, string htmlpage)
        {
            if (string.IsNullOrEmpty(htmlpage))
            {
                string bogusStaticUrl2 = shopuserinfo.domain + "{0}-{1}." + webInfo.WebSuffix;
                return string.Format(bogusStaticUrl2, moduleName, infoId);
            }
            else
            {
                return shopuserinfo.domain + htmlpage;
            }
        }

        /// <summary>
        /// ��ȡ��Ϣ�����ӵ�ַ
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="infoId">��Ϣ���</param>
        /// <param name="htmlpage">�Ƿ��о�̬ҳ��</param>
        /// <returns>��Ϣ�����ӵ�ַ</returns>
        protected string GetInfoUrl(object moduleName, object infoId, object htmlpage)
        {
            if (null == moduleName || null == infoId || null == htmlpage) return "";

            return GetInfoUrl(moduleName.ToString(), infoId.ToString(), htmlpage.ToString());
        }

        /// <summary>
        /// ��ȡ��Ϣ�����ӵ�ַ
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="infoId">��Ϣ���</param>
        /// <returns>��Ϣ�����ӵ�ַ</returns>
        protected string GetInfoUrl(object moduleName, object infoId)
        {
            if (null == moduleName || null == infoId) return "";

            return GetInfoUrl(moduleName.ToString(), infoId.ToString(), "");
        }

        #endregion

        /// <summary>
        /// ��ȡ��Ϣ��Ĭ��ͼƬ
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="infoId">��Ϣ���</param>
        /// <returns>Ĭ��ͼƬ</returns>
        protected string GetInfoImgHref(object moduleName, object infoId)
        {
            long _InfoId = Core.MyConvert.GetInt64(infoId.ToString());

            if (_InfoId <= 0) return "";

            string descTabName = Business.Attachment.GetDescTabNameByModuleName(moduleName.ToString());

            if (descTabName.Equals("")) return "";

            return base.GetInfoImgHref(descTabName.ToString(), _InfoId);
        }

        #endregion

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <returns>����</returns>
        protected string GetLinkPrefix()
        {
            return shopuserinfo.domain;
        }


        protected string SlidesTitles = string.Empty;
        protected string SlidesLinks = string.Empty;
        protected string SlidesImages = string.Empty;

        protected string flvpath = string.Empty;
    }
}
