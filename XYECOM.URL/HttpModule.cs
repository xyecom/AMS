using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Data;
using System.Xml;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Web.SessionState;


namespace XYECOM.URL
{
    /// <summary>
    /// HTTPModule 请求接管处理类
    /// </summary>
    public class HttpModule : IHttpModule
    {
        private XYECOM.Configuration.Module moduleConfig = XYECOM.Configuration.Module.Instance;

        private XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;

        private static readonly XYECOM.Business.UserReg userRegBLL = new XYECOM.Business.UserReg();
        private static readonly XYECOM.Business.UserDomain userDomainBLL = new XYECOM.Business.UserDomain();

        public HttpModule()
        {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(this.ReUrl_BeginRequest);
        }

        public void Application_OnError(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            context.Response.Write("<html><body style=\"font-size:14px;\">");
            context.Response.Write("纵横B2B电子商务系统 Error:<br />");
            context.Response.Write("<textarea name=\"errormessage\" style=\"width:80%; height:200px; word-break:break-all\">");
            context.Response.Write(HttpUtility.HtmlEncode(context.Server.GetLastError().ToString()));
            context.Response.Write("</textarea>");
            context.Response.Write("</body></html>");
            context.Response.End();
        }

        /// <summary>
        /// 判断是不是用户绑定的顶级域名
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        private bool IsUserTopDomain(string domain)
        {
            string localDomain = webInfo.WebDomain.Replace("http://", "").Replace("/", "").Trim();

            domain = domain.Trim();

            //如果就是本站域名
            if (localDomain.Equals(domain)) return false;

            //本地纯域名，不带WWW
            string _localDomain = webInfo.GetShortDomain().ToLower().Replace("/", "");

            //访问纯域名
            string _domain = domain.Substring(domain.IndexOf('.'), domain.Length - domain.IndexOf('.')).ToLower();

            if (_localDomain.Equals(_domain)) return false;

            return true;
        }

        /// <summary>
        /// 获取主机名,先判断当前域名是否为主域名（主要解决主域名有可能为二级域名，由此而增加的二级域名判断资源消耗）
        /// </summary>
        /// <returns></returns>
        private string GetURLPrefix(string host)
        {
            if (host.StartsWith("127.") || host.StartsWith("192.") || host.StartsWith("localhost")) return "";

            string curMainDomain = XYECOM.Configuration.WebInfo.Instance.WebDomain.Replace("http://", "").Replace("/", "");

            if (host.Equals(curMainDomain)) return "";

            return host.Substring(0, host.IndexOf("."));
        }

        private void ReUrl_BeginRequest(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            //防止调用页面缓存
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            context.Response.Expires = 0;
            context.Response.CacheControl = "no-cache";

            string text = "/";
            string input = context.Request.Path.ToLower();

            string ip = XYECOM.Core.XYRequest.GetIP();

            //IP判断
            if (XYECOM.Configuration.Security.Instance._ForbidIP.Contains(ip))
            {
                context.Response.Write("-禁止访问-");
                context.Response.End();
            }

            //后台管理文件夹路径
            string adminDir = XYECOM.Configuration.WebInfo.Instance.AdminFolder.ToLower();

            //如果是管理目录或验证码文件则直接进入
            if (input.StartsWith(text + adminDir + "/"))
            {
                return;
            }

            //如果是验证码文件则直接进入
            if (input.StartsWith(text + "common/validatecode.ashx"))
            {
                return;
            }


            //如果是通用目录则直接进入
            if (input.StartsWith(text + "common/"))
            {
                return;
            }
            //系统是否在运行状态
            if (!XYECOM.Configuration.WebInfo.Instance.IsRun)
            {
                context.Response.Write(XYECOM.Configuration.WebInfo.Instance.SiteCloseTip);
                context.Response.End();
            }

            return;

            //如果是注册或登陆直接进入
            if (input.StartsWith("/login.aspx") || input.StartsWith("/register.aspx") || input.StartsWith("/getpassword.aspx") || input.StartsWith("/logout.aspx"))
            {
                return;
            }

            if (input.EndsWith(".js") || input.EndsWith(".png") || input.EndsWith(".jpeg") || input.EndsWith(".jpg") || input.EndsWith(".bmp") || input.EndsWith(".css") || input.EndsWith(".gif"))
            {
                return;
            }

            string curDomain = context.Request.Url.Authority;

            bool isTopDomain = true;
            if (curDomain.StartsWith("192.168") || curDomain.StartsWith("127.0") || curDomain.StartsWith("localhost"))
            {
                isTopDomain = false;
            }

            ///用户绑定顶级域名处理
            if (isTopDomain && IsUserTopDomain(curDomain))
            {
                Model.UserDomainInfo udInfo = userDomainBLL.GetItem(curDomain);

                if (udInfo == null || udInfo.State != XYECOM.Model.AuditingState.Passed)
                {
                    context.Response.Status = "301 Moved Permanently";
                    context.Response.AddHeader("Location", webInfo.WebDomain);
                    context.Response.End();
                    return;
                }

                string userTmpName = string.Empty;
                XYECOM.Model.UserRegInfo userRegInfo = userRegBLL.GetItem(udInfo.UserId);
                if (userRegInfo != null)
                {
                    userTmpName = userRegInfo.TemplateName;

                    if (userTmpName.IndexOf("|") != -1)
                    {
                        userTmpName = userTmpName.Split('|')[0];
                    }
                }

                if (string.IsNullOrEmpty(userTmpName))
                {
                    context.Response.Status = "301 Moved Permanently";
                    context.Response.AddHeader("Location", webInfo.WebDomain);
                    context.Response.End();
                    return;
                }


                foreach (URLPatternInfo rewrite2 in Urls.Instance.TopShopUrlItems)
                {
                    string tmpInput = input == "/" ? "/index." + webInfo.WebSuffix : input;
                    if (Regex.IsMatch(context.Request.Url.Host + tmpInput, rewrite2.Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase))
                    {
                        string queryString = Regex.Replace(context.Request.Url.Host + tmpInput, rewrite2.Pattern, rewrite2.QueryString, RegexOptions.Compiled | RegexOptions.IgnoreCase);

                        context.RewritePath(text + "aspx/" + rewrite2.Page.Insert(rewrite2.Page.LastIndexOf("/"), userTmpName), string.Empty, queryString);
                        return;
                    }
                }
            }

            if (input.StartsWith(text))
            {
                //当前模板名称
                string curTmpName = XYECOM.Configuration.Template.Instance.Path;

                //是否启用二级域名
                bool isDomain = XYECOM.Configuration.WebInfo.Instance.IsDomain;


                //是否启用地区二级域名
                bool isAreaDomain = XYECOM.Configuration.WebInfo.Instance.IsAreaDomain;

                string urlPrefix = GetURLPrefix(context.Request.Url.Host);

                if (input == text)
                {
                    context.RewritePath("/aspx/" + curTmpName + "/index." + webInfo.WebSuffix);
                    return;
                }

                //如果进入为二级域名
                if (!urlPrefix.Equals(""))
                {
                    //如果已经启用地区二级域名
                    if (isAreaDomain)
                    {
                        string customAreaFolder = "";

                        Model.AreaSiteInfo areaSiteInfo = new Business.AreaSite().GetItemByFlagName(urlPrefix);

                        if (areaSiteInfo != null)
                        {
                            if (areaSiteInfo.IsCostomTemplate) customAreaFolder = urlPrefix;

                            foreach (URLPatternInfo rewrite2 in Urls.Instance.AreaUrlItems)
                            {
                                if (Regex.IsMatch(context.Request.Url.Host + input, rewrite2.Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase))
                                {
                                    string queryString = Regex.Replace(context.Request.Url.Host + input, rewrite2.Pattern, rewrite2.QueryString, RegexOptions.Compiled | RegexOptions.IgnoreCase);

                                    context.RewritePath(text + "aspx/" + curTmpName + rewrite2.Page.Insert(rewrite2.Page.LastIndexOf("/"), customAreaFolder), string.Empty, queryString);
                                    return;
                                }
                            }
                        }
                    }



                    //如果网店已启用二级域名
                    if (isDomain)
                    {
                        string userTmpName = "";
                        if (context.Request.Url.Host.Contains("localhost")
                            || context.Request.Url.Host.Contains("127.0.0.1"))
                        {
                            userTmpName = "default";
                        }
                        else
                        {
                            XYECOM.Model.UserRegInfo userRegInfo = userRegBLL.GetItem(urlPrefix);

                            if (userRegInfo != null)
                            {
                                userTmpName = userRegInfo.TemplateName;

                                if (userTmpName.IndexOf("|") != -1)
                                    userTmpName = userTmpName.Split('|')[0];
                            }
                        }

                        if (userTmpName != "")
                        {
                            foreach (URLPatternInfo rewrite2 in Urls.Instance.ShopUrlItems)
                            {
                                if (Regex.IsMatch(context.Request.Url.Host + input, rewrite2.Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase))
                                {
                                    string queryString = Regex.Replace(context.Request.Url.Host + input, rewrite2.Pattern, rewrite2.QueryString, RegexOptions.Compiled | RegexOptions.IgnoreCase);

                                    context.RewritePath(text + "aspx/" + rewrite2.Page.Insert(rewrite2.Page.LastIndexOf("/"), userTmpName), string.Empty, queryString);
                                    return;
                                }
                            }
                        }
                    }

                }

                if (input.Substring(text.Length).IndexOf("/") == -1)
                {
                    context.RewritePath(text + "aspx/" + curTmpName + input.Substring(context.Request.Path.LastIndexOf("/")));
                    return;
                }

                if (input.StartsWith(text + "upload/"))
                {
                    context.RewritePath(input.Substring(7));
                    return;
                }


                //产品栏目，首先查看是否为自定义文件夹栏目
                if (input.StartsWith(text + "cate/"))
                {
                    foreach (URLPatternInfo rewrite2 in Urls.Instance.ProCateUrlItems)
                    {
                        if (Regex.IsMatch(context.Request.Url.Host + input, rewrite2.Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase))
                        {
                            int startIndex = 6;

                            int endIndex = input.LastIndexOf("-");

                            int length = endIndex - startIndex;

                            string proFlagName = input.Substring(startIndex, length);

                            Model.ProductTypeInfo proTypeInfo = new Business.ProductType().GetItemByFlagName(proFlagName);

                            string customFolder = "";
                            if (proTypeInfo != null && proTypeInfo.IsCustomTemplate)
                            {
                                customFolder = proFlagName;
                            }

                            string queryString = Regex.Replace(input, rewrite2.Pattern, rewrite2.QueryString, RegexOptions.Compiled | RegexOptions.IgnoreCase);

                            context.RewritePath(text + "aspx/" + curTmpName + rewrite2.Page.Insert(rewrite2.Page.LastIndexOf("/"), customFolder), string.Empty, queryString);
                            return;
                        }
                    }
                }

                if (input.StartsWith(text + "shop/"))
                {
                    string userName = "";

                    if (context.Request.QueryString["u_name"] != null)
                        userName = context.Request.QueryString["u_name"].ToString();
                    else
                        userName = input.Substring(6, input.LastIndexOf("/") - 6);

                    XYECOM.Model.UserRegInfo userRegInfo = userRegBLL.GetItem(userName);

                    string userTmpName = "default";

                    if (userRegInfo != null)
                    {
                        userTmpName = userRegInfo.TemplateName;

                        if (userTmpName.IndexOf("|") != -1)
                            userTmpName = userTmpName.Split('|')[0];
                    }

                    foreach (URLPatternInfo rewrite2 in Urls.Instance.SpUrlItems)
                    {
                        if (Regex.IsMatch(input, rewrite2.Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase))
                        {
                            string queryString = Regex.Replace(input, rewrite2.Pattern, rewrite2.QueryString, RegexOptions.Compiled | RegexOptions.IgnoreCase);

                            context.RewritePath(text + "aspx/" + rewrite2.Page.Insert(rewrite2.Page.LastIndexOf("/"), userTmpName), string.Empty, queryString);
                            return;
                        }
                    }
                    return;
                }

                //全部匹配
                foreach (URLPatternInfo rewrite2 in Urls.Instance.GeneralUrlItems)
                {
                    if (Regex.IsMatch(input, rewrite2.Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase))
                    {
                        string queryString = Regex.Replace(input, rewrite2.Pattern, rewrite2.QueryString, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                        context.RewritePath(text + "aspx/" + curTmpName + rewrite2.Page, string.Empty, queryString);
                        return;
                    }
                }

                string folderName = "";

                if (input.StartsWith(text + "area/")) folderName = "area";

                if (input.StartsWith(text + "cate/")) folderName = "cate";

                if (input.StartsWith(text + "search/")) folderName = "search";

                if (input.StartsWith(text + "creditor/")) folderName = "creditor";

                if (input.StartsWith(text + "server/")) folderName = "server";


                if (!string.IsNullOrEmpty(folderName))
                {
                    string vPath = text + "aspx/" + curTmpName + "/" + folderName + "/" + input.Substring(context.Request.Path.LastIndexOf("/"));
                    if (folderName == "creditor" || folderName == "server")
                    {
                        string filePath = context.Server.MapPath(vPath);
                        if (!System.IO.File.Exists(filePath))
                        {
                            return;
                        }
                    }
                    context.RewritePath(vPath);
                    return;
                }



                string text1 = input.Substring(text.Length, input.LastIndexOf('/') - 1);

                foreach (XYECOM.Configuration.ModuleInfo item in XYECOM.Configuration.Module.Instance.ModuleItems)
                {
                    if (Regex.IsMatch(text1, item.EName, RegexOptions.Compiled | RegexOptions.IgnoreCase))
                    {
                        context.RewritePath(text + "aspx/" + curTmpName + "/" + item.EName + "/" + input.Substring(context.Request.Path.LastIndexOf("/")));
                        return;
                    }
                }

                context.RewritePath(text + "aspx/" + curTmpName + input.Substring(context.Request.Path.LastIndexOf("/")));

                //add by botao 2010-04-21
                context.Response.Flush();
            }
        }

        public void Dispose()
        {
        }
    }
}
