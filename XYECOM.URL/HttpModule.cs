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

            if (input.StartsWith(text + "case/"))
            {
                return;
            }
            //系统是否在运行状态
            if (!XYECOM.Configuration.WebInfo.Instance.IsRun)
            {
                context.Response.Write(XYECOM.Configuration.WebInfo.Instance.SiteCloseTip);
                context.Response.End();
            }

            if (text == input)
            {
                context.RewritePath("/index.aspx");
                return;
            }

            //如果是注册或登陆直接进入
            if (input.StartsWith("/login.aspx") || input.StartsWith("/register.aspx") || input.StartsWith("/getpassword.aspx") || input.StartsWith("/logout.aspx") || input.StartsWith("/creditor/") || input.StartsWith("/server/"))
            {
                return;
            }

            if (input.EndsWith(".js") || input.EndsWith(".png") || input.EndsWith(".jpeg") || input.EndsWith(".jpg") || input.EndsWith(".bmp") || input.EndsWith(".css") || input.EndsWith(".gif"))
            {
                return;
            }

            string curDomain = context.Request.Url.Authority;

            if (input.StartsWith(text))
            {
                //当前模板名称
                string curTmpName = XYECOM.Configuration.Template.Instance.Path;

                string urlPrefix = GetURLPrefix(context.Request.Url.Host);

                if (input == text)
                {

                    return;
                }

                if (input.Substring(text.Length).IndexOf("/") == -1)
                {

                    return;
                }

                if (input.StartsWith(text + "upload/"))
                {
                    context.RewritePath(input.Substring(7));
                    return;
                }

                //地区频道
                if (input.StartsWith(text + "area/"))
                {
                    foreach (URLPatternInfo rewrite2 in Urls.Instance.AreaUrlItems)
                    {
                        if (Regex.IsMatch(context.Request.Url.Host + input, rewrite2.Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase))
                        {
                            int startIndex = 6;

                            int endIndex = input.LastIndexOf("-");

                            int length = endIndex - startIndex;

                            string areaFlagName = input.Substring(startIndex, length);

                            Model.AreaSiteInfo areaSiteInfo = new Business.AreaSite().GetItemByFlagName(areaFlagName);

                            string customAreaFolder = "";
                            if (areaSiteInfo != null && areaSiteInfo.IsCostomTemplate)
                            {
                                customAreaFolder = areaFlagName;
                            }

                            string queryString = Regex.Replace(input, rewrite2.Pattern, rewrite2.QueryString, RegexOptions.Compiled | RegexOptions.IgnoreCase);

                            context.RewritePath(text + "aspx/" + curTmpName + rewrite2.Page.Insert(rewrite2.Page.LastIndexOf("/"), customAreaFolder), string.Empty, queryString);
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

                //context.RewritePath(text + "aspx/" + curTmpName + input.Substring(context.Request.Path.LastIndexOf("/")));

                //add by botao 2010-04-21
                //context.Response.Flush();
                return;
            }
        }

        public void Dispose()
        {
        }
    }
}
