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
        //搜索关键字
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
                    GotoMsgBoxPage("域名错误！", "/index." + config.suffix);
                    return;
                }

                userRegInfo = new XYECOM.Business.UserReg().GetItem(udInfo.UserId);
            }
            else
            {
                GotoMsgBoxPage("参数错误！", "/index." + config.suffix);
                return;
            }

            if (userRegInfo == null || userRegInfo.AuditingState != XYECOM.Model.AuditingState.Passed)
            {
                GotoMsgBoxPage("用户不存在或未被审核通过！", "/index." + config.suffix);
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
        /// 网店SEO
        /// </summary>
        protected virtual XYECOM.Model.UserSEOFlag UserSeoFlg
        {
            get
            {
                return XYECOM.Model.UserSEOFlag.Index;
            }
        }

        #region 初始化信息列表链接相关
        /// <summary>
        /// 初始化信息列表链接
        /// </summary>
        /// <param name="currentModuleName">模块名称</param>
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
        /// 获取连接
        /// </summary>
        /// <param name="parentModuleName">父模块名称</param>
        /// <param name="moduleName">模块名称</param>
        /// <returns>连接</returns>
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
        /// 获取模块名称
        /// </summary>
        /// <param name="defaultModuleName">默认模块名称</param>
        /// <returns>模块名称</returns>
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

        #region 供网店页面调用方法

        /// <summary>
        /// 获取友情链接
        /// </summary>
        /// <returns>用情连接</returns>
        protected DataTable GetLink()
        {
            XYECOM.Business.UserFirendLink link = new XYECOM.Business.UserFirendLink();

            return link.GetDataTable(shopuserinfo.userid);
        }

        /// <summary>
        /// 读取指定模块下指定条数的数据
        /// (字段固定为：infoid,infoTitle,infoFlag,htmlPage,isHasimage)
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <param name="topNumber">调用条数(1～100)</param>
        /// <returns>指定模块下指定条数的数据</returns>
        protected DataTable GetData(string moduleName, int topNumber)
        {
            return GetData(moduleName, topNumber, "sell");
        }

        /// <summary>
        /// 读取指定模块下指定条数的数据
        /// (字段固定为：infoid,infoTitle,infoFlag,htmlPage,isHasimage)
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <param name="topNumber">调用条数(1～100)</param>
        /// <param name="typeFlag">供求表示，固定字段(供:sell,求:buy)</param>
        /// <returns>指定模块下指定条数的数据</returns>
        protected DataTable GetData(string moduleName, int topNumber, string typeFlag)
        {
            if (string.IsNullOrEmpty(moduleName)) return new DataTable();

            moduleName = moduleName.Trim();

            if (moduleName.Equals("")) return new DataTable();

            if (topNumber <= 0) topNumber = 10;

            if (topNumber > 100) topNumber = 100;

            return Business.XYInfo.GetDataByModuleAndUserId(moduleName, shopuserinfo.userid, topNumber, typeFlag);
        }

        #region 获取信息的连接地址
        /// <summary>
        /// 获取信息的连接地址(网店品牌，证书列表，新闻列表，人才列表)
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <param name="infoId">信息Id</param>
        /// <param name="htmlpage">是否有静态页面</param>
        /// <returns>信息的链接地址</returns>
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
        /// 获取信息的链接地址
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <param name="infoId">信息编号</param>
        /// <param name="htmlpage">是否有静态页面</param>
        /// <returns>信息的链接地址</returns>
        protected string GetInfoUrl(object moduleName, object infoId, object htmlpage)
        {
            if (null == moduleName || null == infoId || null == htmlpage) return "";

            return GetInfoUrl(moduleName.ToString(), infoId.ToString(), htmlpage.ToString());
        }

        /// <summary>
        /// 获取信息的链接地址
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <param name="infoId">信息编号</param>
        /// <returns>信息的链接地址</returns>
        protected string GetInfoUrl(object moduleName, object infoId)
        {
            if (null == moduleName || null == infoId) return "";

            return GetInfoUrl(moduleName.ToString(), infoId.ToString(), "");
        }

        #endregion

        /// <summary>
        /// 获取信息的默认图片
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <param name="infoId">信息编号</param>
        /// <returns>默认图片</returns>
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
        /// 获取连接
        /// </summary>
        /// <returns>链接</returns>
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
