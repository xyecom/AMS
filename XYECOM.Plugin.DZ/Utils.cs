namespace XYECOM.Plugin.DZ
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Reflection;
    using System.Diagnostics;
    using System.Web;

    /// <summary>
    /// 通用方法类
    /// </summary>
    internal class Utils
    {
        public const string ASSEMBLY_VERSION = "2.1.0202";
  
        #region For 2.1
        internal static string MD5(string str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);
            bytes = new MD5CryptoServiceProvider().ComputeHash(bytes);
            string str2 = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                str2 = str2 + bytes[i].ToString("x").PadLeft(2, '0');
            }
            return str2;
        }

        public static string HtmlDecode(string str)
        {
            return System.Web.HttpUtility.HtmlDecode(str);
        }

        public static string HtmlEncode(string str)
        {
            return System.Web.HttpUtility.HtmlEncode(str);
        }


        public static string SetCookiePassword(string password, string key)
        {
            return DES.Encode(password, key);
        }

        public static string UrlEncode(string str)
        {
            return HttpUtility.UrlEncode(str);
        }

        public static string UrlDecode(string str)
        {
            return HttpUtility.UrlDecode(str);
        }

        public static void WriteUserCookie(UserInfo userInfo)
        {
            if (userInfo != null)
            {
                HttpCookie cookie = new HttpCookie("dnt");
                cookie.Values["userid"] = userInfo.Uid.ToString();
                cookie.Values["password"] = Utils.UrlEncode(SetCookiePassword(userInfo.Password, Config.Instance.PasswordKey));

                cookie.Values["tpp"] = userInfo.Tpp.ToString();
                cookie.Values["ppp"] = userInfo.Ppp.ToString();
                cookie.Values["pmsound"] = userInfo.Pmsound.ToString();

                cookie.Values["invisible"] = userInfo.Invisible;
                cookie.Values["referer"] = "index.aspx";
                cookie.Values["sigstatus"] = userInfo.Sigstatus.ToString();
                cookie.Values["expires"] = "0";

                string str2 = Config.Instance.CookieDomain;
                if (((str2 != string.Empty) && (HttpContext.Current.Request.Url.Host.IndexOf(str2) > -1)) && IsValidDomain(HttpContext.Current.Request.Url.Host))
                {
                    cookie.Domain = str2;
                }
                HttpContext.Current.Response.AppendCookie(cookie);
                if (userInfo.TemplateId > 0)
                {
                    Utils.WriteCookie(Utils.GetTemplateCookieName(), userInfo.TemplateId.ToString(), 0xf423f);
                }
            }
        }

        public static void ClearUserCookie()
        {
            ClearUserCookie("dnt");
        }

        public static void ClearUserCookie(string cookieName)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Values.Clear();
            cookie.Expires = DateTime.Now.AddYears(-1);
            string str = Config.Instance.CookieDomain;

            HttpContext.Current.Response.AppendCookie(new HttpCookie("host", HttpContext.Current.Request.Url.Host));
            if (((str != string.Empty) && (HttpContext.Current.Request.Url.Host.IndexOf(str) > -1)) && IsValidDomain(HttpContext.Current.Request.Url.Host))
            {
                cookie.Domain = str;
            }
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static bool IsValidDomain(string host)
        {
            Regex regex = new Regex(@"^\d+$");
            if (host.IndexOf(".") == -1)
            {
                return false;
            }
            return !regex.IsMatch(host.Replace(".", string.Empty));
        }

        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            cookie.Expires = DateTime.Now.AddMinutes((double)expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static string GetTemplateCookieName()
        {
            return "dnttemplateid_2_1_0202";
        }

        public static string GetSubString(string p_SrcString, int p_Length, string p_TailString)
        {
            return GetSubString(p_SrcString, 0, p_Length, p_TailString);
        }

        public static string GetSubString(string p_SrcString, int p_StartIndex, int p_Length, string p_TailString)
        {
            string str = p_SrcString;
            if (Regex.IsMatch(p_SrcString, "[ࠀ-一]+") || Regex.IsMatch(p_SrcString, "[가-힣]+"))
            {
                if (p_StartIndex >= p_SrcString.Length)
                {
                    return "";
                }
                return p_SrcString.Substring(p_StartIndex, ((p_Length + p_StartIndex) > p_SrcString.Length) ? (p_SrcString.Length - p_StartIndex) : p_Length);
            }
            if (p_Length < 0)
            {
                return str;
            }
            byte[] bytes = Encoding.Default.GetBytes(p_SrcString);
            if (bytes.Length <= p_StartIndex)
            {
                return str;
            }
            int length = bytes.Length;
            if (bytes.Length > (p_StartIndex + p_Length))
            {
                length = p_Length + p_StartIndex;
            }
            else
            {
                p_Length = bytes.Length - p_StartIndex;
                p_TailString = "";
            }
            int num2 = p_Length;
            int[] numArray = new int[p_Length];
            byte[] destinationArray = null;
            int num3 = 0;
            for (int i = p_StartIndex; i < length; i++)
            {
                if (bytes[i] > 0x7f)
                {
                    num3++;
                    if (num3 == 3)
                    {
                        num3 = 1;
                    }
                }
                else
                {
                    num3 = 0;
                }
                numArray[i] = num3;
            }
            if ((bytes[length - 1] > 0x7f) && (numArray[p_Length - 1] == 1))
            {
                num2 = p_Length + 1;
            }
            destinationArray = new byte[num2];
            Array.Copy(bytes, p_StartIndex, destinationArray, 0, num2);
            return (Encoding.Default.GetString(destinationArray) + p_TailString);
        }



        #endregion

        public static string GetUserIP()
        { 
            return System.Web.HttpContext.Current.Request.UserHostAddress;
        }

    }
}

