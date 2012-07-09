using System;
using System.Collections.Generic;
using System.Text;

using System.Web;
namespace XYECOM.Core
{
    /// <summary>
    /// 获取数据公共类
    /// </summary>
    public class XYRequest
    {
        #region 从表单获取数据
        /// <summary>
        /// 获取表单提交过来的 浮点数
        /// </summary>
        /// <param name="strName">Key </param>
        /// <param name="defValue">默认值</param>
        /// <returns>浮点数</returns>
        public static float GetFloat(string strName, float defValue)
        {
            if (GetQueryFloat(strName, defValue) == defValue)
            {
                return GetFormFloat(strName, defValue);
            }
            return GetQueryFloat(strName, defValue);
        }
        /// <summary>
        /// 获取表单提交过来的 浮点数
        /// </summary>
        /// <param name="strName">Key</param>
        /// <param name="defValue">默认值</param>
        /// <returns>浮点数</returns>
        public static float GetFormFloat(string strName, float defValue)
        {
            return Utils.StrToFloat(HttpContext.Current.Request.Form[strName], defValue);
        }

       
        /// <summary>
        /// 获取表单提交过来的 整数
        /// </summary>
        /// <param name="strName">Key</param>
        /// <param name="defValue">默认值</param>
        /// <returns>整数</returns>
        public static int GetFormInt(string strName, int defValue)
        {
            return Utils.StrToInt(HttpContext.Current.Request.Form[strName], defValue);
        }

        /// <summary>
        /// 获取表单提交过来的 长整数
        /// </summary>
        /// <param name="strName">Key</param>
        /// <param name="defValue">默认值</param>
        /// <returns>整数</returns>
        public static long GetFormInt64(string strName, int defValue)
        {
            return Utils.StrToInt64(HttpContext.Current.Request.Form[strName], defValue);
        }

        /// <summary>
        /// 获取表单提交过来的 字符串
        /// </summary>
        /// <param name="strName">字符串</param>
        /// <returns>字符串</returns>
        public static string GetFormString(string strName)
        {
            if (HttpContext.Current.Request.Form[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.Form[strName];
        }
        /// <summary>
        /// 获取表单提交过来的 整数
        /// </summary>
        /// <param name="strName">Key</param>
        /// <param name="defValue">默认值</param>
        /// <returns>整数</returns>
        public static int GetInt(string strName, int defValue)
        {
            if (GetQueryInt(strName, defValue) == defValue)
            {
                return GetFormInt(strName, defValue);
            }
            return GetQueryInt(strName, defValue);
        }
        /// <summary>
        /// 获取请求者名称
        /// </summary>
        /// <param name="strName">请求者名称</param>
        /// <returns>请求者名称</returns>
        public static string GetString(string strName)
        {
            if ("".Equals(GetQueryString(strName)))
            {
                return GetFormString(strName);
            }
            return GetQueryString(strName);
        }
        /// <summary>
        /// 获取页面名称
        /// </summary>
        /// <returns>页面名称</returns>
        public static string GetPageName()
        {
            string[] textArray = HttpContext.Current.Request.Url.AbsolutePath.Split(new char[] { '/' });
            return textArray[textArray.Length - 1].ToLower();
        }

        /// <summary>
        /// 获取float类型值
        /// </summary>
        /// <param name="strName">参数名</param>
        /// <param name="defValue">默认值</param>
        /// <returns></returns>
        public static float GetQueryFloat(string strName, float defValue)
        {
            return Utils.StrToFloat(HttpContext.Current.Request.QueryString[strName], defValue);
        }
        /// <summary>
        /// 获取请求者
        /// </summary>
        /// <param name="strName">请求信息名称</param>
        /// <param name="defValue">请求信息默认编号</param>
        /// <returns>请求者编号</returns>
        public static int GetQueryInt(string strName, int defValue)
        {
            return Utils.StrToInt(HttpContext.Current.Request.QueryString[strName], defValue);
        }
        /// <summary>
        /// 获取请求者
        /// </summary>
        /// <param name="strName">请求信息名称</param>
        /// <param name="defValue">请求信息默认编号</param>
        /// <returns>请求者编号</returns>
        public static Int64 GetQueryInt64(string strName)
        {
            return Utils.StrToInt64(HttpContext.Current.Request.QueryString[strName], 0);
        }
        /// <summary>
        /// 获取请求者的名称
        /// </summary>
        /// <param name="strName">请求者名称</param>
        /// <returns>请求者名称</returns>
        public static string GetQueryString(string strName)
        {
            if (HttpContext.Current.Request.QueryString[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.QueryString[strName].ToString().Trim();
        }
        #endregion 

        #region 获取有关客户端 IP和Url 的信息
        /// <summary>
        /// 获取客户端的 IP
        /// </summary>
        /// <returns>客户端 IP</returns>
        public static string GetIP()
        {
            string userHostAddress = string.Empty;
            userHostAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            switch (userHostAddress)
            {
                case null:
                case "":
                    userHostAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    break;
            }
            if ((userHostAddress == null) || (userHostAddress == string.Empty))
            {
                userHostAddress = HttpContext.Current.Request.UserHostAddress;
            }
            if ((userHostAddress == null) || (userHostAddress == string.Empty))
            {
                return "0.0.0.0";
            }
            return userHostAddress;
        }
        
        /// <summary>
        /// 获取当前请求的原始 Url
        /// </summary>
        /// <returns></returns>
        public static string GetRawUrl()
        {
            return HttpContext.Current.Request.RawUrl;
        }
        /// <summary>
        /// 获取对应请求者的服务器端变量
        /// </summary>
        /// <param name="strName">请求者名称</param>
        /// <returns>服务器端变量</returns>
        public static string GetServerString(string strName)
        {
            if (HttpContext.Current.Request.ServerVariables[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.ServerVariables[strName].ToString();
        }
        
        /// <summary>
        /// 获取有关当前请求的 Url
        /// </summary>
        /// <returns></returns>
        public static string GetUrl()
        {
            return HttpContext.Current.Request.Url.ToString();
        }
        /// <summary>
        /// 获取有关客户端上次请求的 Url 信息，该请求连接到当前的 Url
        /// </summary>
        /// <returns></returns>
        public static string GetUrlReferrer()
        {
            if (HttpContext.Current.Request.UrlReferrer == null)
            {
                return "";
            }
            return HttpContext.Current.Request.UrlReferrer.ToString().Trim();
        }
        #endregion        

        #region 提交类型信息
        /// <summary>
        /// 判断客户端是否 Get 提交
        /// </summary>
        /// <returns>true :表示是 get 提交</returns>
        public static bool IsGet()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("GET");
        }
        /// <summary>
        /// 判断客户端是否 Post 提交
        /// </summary>
        /// <returns>true 表示是Post提交</returns>
        public static bool IsPost()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("POST");
        }
        /// <summary>
        /// 判断是否 通过搜索引擎 提交
        /// </summary>
        /// <returns>true 表示是通过搜索引擎提交</returns>
        public static bool IsSearchEnginesGet()
        {
            string[] textArray = new string[] { "google", "yahoo", "msn", "baidu", "sogou", "sohu", "sina", "163", "lycos", "tom" };
            string text = HttpContext.Current.Request.UrlReferrer.ToString().ToLower();
            for (int i = 0; i < textArray.Length; i++)
            {
                if (text.IndexOf(textArray[i]) >= 0)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        /// <summary>
        /// 获取客户端所发送的请求 是否通过浏览器发送的
        /// </summary>
        /// <returns>true 表示该请求是通过浏览器发送</returns>
        public static bool IsBrowserGet()
        {
            string[] textArray = new string[] { "ie", "opera", "netscape", "mozilla" };
            string text = HttpContext.Current.Request.Browser.Type.ToLower();
            for (int i = 0; i < textArray.Length; i++)
            {
                if (text.IndexOf(textArray[i]) >= 0)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 保存请求文件
        /// </summary>
        /// <param name="path">文件路径</param>
        public static void SaveRequestFile(string path)
        {
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                HttpContext.Current.Request.Files[0].SaveAs(path);
            }
        }
    } 
}
