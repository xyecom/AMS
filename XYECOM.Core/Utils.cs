using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Web;
using System.Web.UI;
using Microsoft.VisualBasic;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Net;

namespace XYECOM.Core
{
    /// <summary>
    /// 通用方法
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// 对字符串进行url编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string JSEscape(string str)
        {
            return Microsoft.JScript.GlobalObject.escape(str);
        }
        /// <summary>
        /// 对字符串进行url解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string JSunescape(string str)
        {
            return Microsoft.JScript.GlobalObject.unescape(str);
        }
        /// <summary>
        /// 校验SQL语句，替换" ' "字符
        /// </summary>
        /// <param name="str">SQL语句</param>
        /// <returns>经过替换后的SQL语句</returns>
        public static string ChkSQL(string str)
        {
            if (str == null)
            {
                return "";
            }
            str = str.Replace("'", "''");
            return str;
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileFullPath">文件在服务器中的全路径</param>
        /// <returns>成功或失败 false为文件不存在或者删除失败</returns>
        public static bool DeleteFile(string fileFullPath)
        {
            if (File.Exists(fileFullPath))
            {
                try
                {
                    File.Delete(fileFullPath);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns
        [DllImport("dbgHelp", SetLastError = true)]
        private static extern bool MakeSureDirectoryPathExists(string name);
        public static bool CreateDir(string name)
        {
            return MakeSureDirectoryPathExists(name);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CutString(string str, int startIndex, int length)
        {
            if (startIndex >= 0)
            {
                if (length < 0)
                {
                    length = length * -1;
                    if (startIndex - length < 0)
                    {
                        length = startIndex;
                        startIndex = 0;
                    }
                    else
                    {
                        startIndex = startIndex - length;
                    }
                }

                if (startIndex > str.Length) return "";
            }
            else
            {
                if (length < 0) return "";

                if (length + startIndex > 0)
                {
                    length = length + startIndex;
                    startIndex = 0;
                }
                else
                {
                    return "";
                }
            }

            if (str.Length - startIndex < length)
            {
                length = str.Length - startIndex;
            }

            return str.Substring(startIndex, length);
        }

        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="filename">文件路径</param>
        /// <returns></returns>
        public static bool FileExists(string filename)
        {
            return File.Exists(filename);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static string[] FindNoUTF8File(string Path)
        {
            StringBuilder builder = new StringBuilder();
            FileInfo[] files = new DirectoryInfo(Path).GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Extension.ToLower().Equals(".htm"))
                {
                    FileStream sbInputStream = new FileStream(files[i].FullName, FileMode.Open, FileAccess.Read);
                    bool flag = IsUTF8(sbInputStream);
                    sbInputStream.Close();
                    if (!flag)
                    {
                        builder.Append(files[i].FullName);
                        builder.Append("\r\n");
                    }
                }
            }
            return SplitString(builder.ToString(), "\r\n");
        }

        /// <summary>
        /// 获取程序集产品名称
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyProductName()
        {
            return FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductName;
        }
        /// <summary>
        /// 获取程序集程序版本
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyVersion()
        {
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            return string.Format("{0}.{1}.{2}", versionInfo.FileMajorPart, versionInfo.FileMinorPart, versionInfo.FileBuildPart);
        }
                
        public static string GetDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        
        public static int GetInArrayID(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (caseInsensetive)
                {
                    if (strSearch.ToLower() == stringArray[i].ToLower())
                    {
                        return i;
                    }
                }
                else if (strSearch == stringArray[i])
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 通过虚拟路径获取物理路径
        /// </summary>
        /// <param name="strPath">虚拟路径</param>
        /// <returns></returns>
        public static string GetMapPath(string strPath)
        {
            return HttpContext.Current.Server.MapPath(strPath);
        }
        

        /// <summary>
        /// HTML解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HtmlDecode(string str)
        {
            return HttpUtility.HtmlDecode(str);
        }

        /// <summary>
        /// HTML编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HtmlEncode(string str)
        {
            return HttpUtility.HtmlEncode(str);
        }
        
        #region 运用正则表达式
        public static bool IsBase64String(string str)
        {
            return Regex.IsMatch(str, @"[A-Za-z0-9\+\/\=]");
        }
        public static bool IsImgFilename(string filename)
        {
            if (filename.EndsWith(".") || (filename.IndexOf(".") == -1))
            {
                return false;
            }
            string text = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
            return ((((text == "jpg") || (text == "jpeg")) || ((text == "png") || (text == "bmp"))) || (text == "gif"));
        }

        public static bool IsIP(string ip)
        {
            return new Regex(@"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$").IsMatch(ip);
        }

        public static bool IsNumber(string strNumber)
        {
            return new Regex(@"^\d+$").IsMatch(strNumber);
        }
        public static bool IsFloat(string strNumber)
        {
            return new Regex(@"^\d+\.{0,1}\d*$").IsMatch(strNumber);
        }

        public static bool IsNumberArray(string[] strNumber)
        {
            if (strNumber == null)
            {
                return false;
            }
            if (strNumber.Length < 1)
            {
                return false;
            }
            foreach (string text in strNumber)
            {
                if (!IsNumber(text))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        public static bool IsTime(string timeval)
        {
            return Regex.IsMatch(timeval, "^((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?)$");
        }

        private static bool IsUTF8(FileStream sbInputStream)
        {
            bool flag = true;
            long length = sbInputStream.Length;
            byte num2 = 0;
            for (int i = 0; i < length; i++)
            {
                byte num3 = (byte)sbInputStream.ReadByte();
                if ((num3 & 0x80) != 0)
                {
                    flag = false;
                }
                if (num2 == 0)
                {
                    if (num3 >= 0x80)
                    {
                        do
                        {
                            num3 = (byte)(num3 << 1);
                            num2 = (byte)(num2 + 1);
                        }
                        while ((num3 & 0x80) != 0);
                        num2 = (byte)(num2 - 1);
                        if (num2 == 0)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    if ((num3 & 0xc0) != 0x80)
                    {
                        return false;
                    }
                    num2 = (byte)(num2 - 1);
                }
            }
            if (num2 > 0)
            {
                return false;
            }
            if (flag)
            {
                return false;
            }
            return true;
        }

        public static bool IsValidEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        #endregion
        
        /// <summary>
        /// 向客户端输出文件
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <param name="filename">文件名称</param>
        /// <param name="filetype">文件类型</param>
        public static void ResponseFile(string filepath, string filename, string filetype)
        {
            HttpResponse response = HttpContext.Current.Response;
            Stream stream = null;
            byte[] buffer = new byte[0x2710];
            try
            {
                stream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
                long length = stream.Length;
                response.ContentType = filetype;
                response.AddHeader("Content-Disposition", "attachment; filename=" + UrlEncode(filename.Trim()));
                while (length > 0)
                {
                    if (response.IsClientConnected)
                    {
                        int count = stream.Read(buffer, 0, 0x2710);
                        response.OutputStream.Write(buffer, 0, count);
                        response.Flush();
                        buffer = new byte[0x2710];
                        length -= count;
                    }
                    else
                    {
                        length = -1;
                    }
                }
            }
            catch (Exception exception)
            {
                response.Write("Error : " + exception.Message);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            response.End();
        }

        /// <summary>
        /// 字符串分割
        /// </summary>
        /// <param name="strContent">原始字符串</param>
        /// <param name="strSplit">分隔符号</param>
        /// <returns>字符数组</returns>
        public static string[] SplitString(string strContent, string strSplit)
        {
            if (strContent.IndexOf(strSplit) < 0)
            {
                return new string[] { strContent };
            }
            return Regex.Split(strContent, strSplit.Replace(".", @"\."), RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 格式化字符串 替换 回车换行符号
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>替换后的字符串</returns>
        public static string StrFormat(string str)
        {
            if (str == null)
            {
                return "";
            }
            str = str.Replace("\r\n", "<br />");
            str = str.Replace("\n", "<br />");
            return str;
        }

        #region 数据类型转换
        /// <summary>
        /// 字符串转换成为 Float 型
        /// </summary>
        /// <param name="strValue">字符串</param>
        /// <param name="defValue">默认值</param>
        /// <returns>转换得到的浮点数</returns>
        public static float StrToFloat(object strValue, float defValue)
        {
            if ((strValue == null) || (strValue.ToString().Length > 10))
            {
                return defValue;
            }
            float num = defValue;
            if ((strValue != null) && new Regex(@"^([-]|[0-9])[0-9]*(\.\w*)?$").IsMatch(strValue.ToString().Trim()))
            {
                num = Convert.ToSingle(strValue);
            }
            return num;
        }
        /// <summary>
        /// 字符串转换成为 Int 型
        /// </summary>
        /// <param name="strValue">字符串</param>
        /// <param name="defValue">默认值</param>
        /// <returns>转换得到的Int数</returns>
        public static int StrToInt(object strValue, int defValue)
        {
            if ((strValue == null) || (strValue.ToString().Length > 9))
            {
                return defValue;
            }
            int num = defValue;
            if ((strValue != null) && new Regex("^([-]|[0-9])[0-9]*$").IsMatch(strValue.ToString().Trim()))
            {
                num = Convert.ToInt32(strValue);
            }
            return num;
        }
        /// <summary>
        /// 字符串转换成为 Int64 型
        /// </summary>
        /// <param name="strValue">字符串</param>
        /// <param name="defValue">默认值</param>
        /// <returns>转换得到的Int数</returns>
        public static Int64 StrToInt64(object strValue, int defValue)
        {
            if ((strValue == null) || (strValue.ToString().Length > 9))
            {
                return defValue;
            }
            Int64 num = defValue;
            if ((strValue != null) && new Regex("^([-]|[0-9])[0-9]*$").IsMatch(strValue.ToString().Trim()))
            {
                num = Convert.ToInt64(strValue);
            }
            return num;
        }
        #endregion

        #region 获取年数
        public static string GetYear(DateTime begin, DateTime end)
        {
            string year = "";

            if (end.Year == begin.Year)
            {
                if (end.Month == begin.Month)
                {
                    if (end.Day - begin.Day > 0)
                        year = "1";
                    else
                        year = "0";
                }
                else
                {
                    if (end.Month - begin.Month > 0)
                    {

                        year = "1";

                    }
                    else
                    {
                        if (end.Day - begin.Day > 0)
                            year = "1";
                        else
                            year = "0";
                    }
                }
            }
            else
            {
                if (end.Year - begin.Year > 0)
                {
                    if (end.Month == begin.Month)
                    {
                        if (end.Day - begin.Day > 0)
                            year = Convert.ToString(end.Year - begin.Year + 1);
                        else
                            year = Convert.ToString(end.Year - begin.Year);
                    }
                    else
                    {
                        if (end.Day - begin.Day > 0)
                            year = Convert.ToString(end.Year - begin.Year + 1);
                        else
                            year = Convert.ToString(end.Year - begin.Year);
                    }
                }
                else
                {
                    year = "0";
                }
            }

            return year;
        }
        #endregion

        #region 对给定的 Url 进行编码
        /// <summary>
        /// 对给定的 Url 进行解码
        /// </summary>
        /// <param name="str">编码过的 Url</param>
        /// <returns>解码后的 Url</returns>
        public static string UrlDecode(string str)
        {
            return HttpUtility.UrlDecode(str);
        }


        /// <summary>
        /// 对给定的 Url 进行编码
        /// </summary>
        /// <param name="str">给定的Url</param>
        /// <returns>编码后的 Url</returns>
        public static string UrlEncode(string str)
        {
            return HttpUtility.UrlEncode(str);
        }
        #endregion


        #region 读写 cookie
        /// <summary>
        /// 读写 cookie
        /// </summary>
        /// <param name="strName">信息名称</param>
        /// <param name="strValue">信息内容</param>
        public static void WriteCookie(string strName, string strValue, string domain)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            if (!String.IsNullOrEmpty(domain)) cookie.Domain = domain;
            strValue = JSEscape(strValue);
            cookie.Value = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        /// <summary>
        /// 写 cookie
        /// </summary>
        /// <param name="strName">信息名称</param>
        /// <param name="strValue">信息内容</param>
        /// <param name="expires">过期时间</param>
        public static void WriteCookie(string strName, string strValue, int expires, string domain)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            if (!String.IsNullOrEmpty(domain)) cookie.Domain = domain;
            cookie.Value = JSEscape(strValue);
            cookie.Expires = DateTime.Now.AddHours(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 读取Cookie
        /// </summary>
        /// <param name="strName">Cookie名称</param>
        /// <returns></returns>
        public static string GetCookie(string strName)
        {
            if ((HttpContext.Current.Request.Cookies != null) && (HttpContext.Current.Request.Cookies[strName] != null))
            {
                string value = HttpContext.Current.Request.Cookies[strName].Value.ToString();

                return JSunescape(value);
            }
            return "";
        }

        /// <summary>
        /// 清空Cookie
        /// </summary>
        /// <param name="strName">cookie名</param>
        /// <param name="domainName">域</param>
        public static void ClearCookie(string strName, string domainName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];

            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddYears(-1);
                cookie.Values.Clear();
                if (!domainName.Trim().Equals("")) cookie.Domain = domainName;
                HttpContext.Current.Response.SetCookie(cookie);
            }
        }

        /// <summary>
        /// 清空Cookie
        /// </summary>
        /// <param name="strName">cookie名</param>
        public static void ClearCookie(string strName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];

            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddYears(-1);
                cookie.Values.Clear();
                HttpContext.Current.Response.SetCookie(cookie);
            }
        }
        #endregion

        #region 读写Session

        /// <summary>
        /// 设置Session
        /// </summary>
        /// <param name="sessionName">session名称</param>
        /// <param name="value">值</param>
        public static void SetSession(string sessionName, object value)
        {
            if (null == HttpContext.Current.Session[sessionName])
            {
                HttpContext.Current.Session.Add(sessionName, value);
            }
            else
            {
                HttpContext.Current.Session[sessionName] = value;
            }
        }

        /// <summary>
        /// 获取Session 值
        /// </summary>
        /// <param name="sessionName">session名称</param>
        /// <returns></returns>
        public static object GetSessionObj(string sessionName)
        {
            return HttpContext.Current.Session[sessionName];
        }

        /// <summary>
        /// 获取Session 值
        /// </summary>
        /// <param name="sessionName">session名称</param>
        /// <returns></returns>
        public static string GetSession(string sessionName)
        {
            object val = GetSessionObj(sessionName);
            if (null == val)
                return "";
            else
                return val.ToString();
        }

        /// <summary>
        /// 清除Session
        /// </summary>
        /// <param name="sessionName">session名称</param>
        public static void ClearSession(string sessionName)
        {
            HttpContext.Current.Session.Remove(sessionName);
        }

        #endregion

        /// <summary>
        /// 转换价格
        /// </summary>
        /// <param name="P_Price">价格</param>
        /// <returns>价格</returns>
        public static string GetMoney(string P_Price)
        {
            int idex = P_Price.IndexOf(".");
            if (idex > 0 && P_Price.Length > idex + 2)
                return P_Price.Substring(0, idex + 3);
            else
                return P_Price;

        }

        #region 截取字符串
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="length">要显示的字符串长度</param>
        /// <param name="str">要检测的字符串</param>
        /// <returns>检测过的字符串</returns>
        public static string IsLength(int length, string str)
        {
            str = RemoveHTML(str);

            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(str);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }

                try
                {
                    tempString += str.Substring(i, 1);
                }
                catch
                {
                    break;
                }

                if (tempLen > length)
                    break;
            }
            byte[] mybyte = System.Text.Encoding.Default.GetBytes(str);
            if (mybyte.Length > length)
                tempString += "";

            return tempString;
        }
        #endregion

        #region 拼接标签
        /// <summary>
        /// 拼接标签
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <returns>拼接好的字符串</returns>
        public static string LableSet(string strName, string strValue)
        {
            return "┆" + strName + "$" + strValue;
        }
        #endregion

        #region 过滤html代码
        /// <summary>
        /// 过滤所有HTML代码
        /// </summary>
        /// <param name="strHTML"></param>
        /// <returns></returns>
        public static string RemoveHTML(string html)
        {
            //html = FilterScript(html);

            //html = FilterAHrefScript(html);

            //html = FilterSrc(html);

            //html = FilterInclude(html);

            //html = FilterObject(html);

            //html = FilterIframe(html);

            //html = FilterFrameset(html);

            html = FilterHtml(html);

            return html;

        }
        /// <summary>
        /// 过滤部分html危险代码
        /// </summary>
        /// <param name="strHTML"></param>
        /// <returns></returns>
        public static string RemoveHTMLForEditor(string html)
        {
            html = FilterScript(html);

            html = FilterAHrefScript(html);

            html = FilterSrc(html);

            //html = FilterInclude(html);

            //html = FilterObject(html);

            html = FilterIframe(html);

            html = FilterFrameset(html);

            return html;
        }

        public static string FilterScript(string content)
        {
            string commentPattern = @"(?'comment'<!--.*?--[ \n\r]*>)";
            string embeddedScriptComments = @"(\/\*.*?\*\/|\/\/.*?[\n\r])";
            string scriptPattern = String.Format(@"(?'script'<[ \n\r]*script[^>]*>(.*?{0}?)*<[ \n\r]*/script[^>]*>)", embeddedScriptComments);
            // 包含注释和Script语句
            string pattern = String.Format(@"(?s)({0}|{1})", commentPattern, scriptPattern);

            return StripScriptAttributesFromTags(Regex.Replace(content, pattern, string.Empty, RegexOptions.IgnoreCase));
        }

        private static string StripScriptAttributesFromTags(string content)
        {
            string eventAttribs = @"on(blur|c(hange|lick)|dblclick|focus|keypress|(key|mouse)(down|up)|(un)?load
                            |mouse(move|o(ut|ver))|reset|s(elect|ubmit))";

            string pattern = String.Format(@"(?inx)
                \<(\w+)\s+
                    (
                        (?'attribute'
                        (?'attributeName'{0})\s*=\s*
                        (?'delim'['""]?)
                        (?'attributeValue'[^'"">]+)
                        (\3)
                    )
                    |
                    (?'attribute'
                        (?'attributeName'href)\s*=\s*
                        (?'delim'['""]?)
                        (?'attributeValue'javascript[^'"">]+)
                        (\3)
                    )
                    |
                    [^>]
                )*
            \>", eventAttribs);
            Regex re = new Regex(pattern);
            // 使用MatchEvaluator的委托
            return re.Replace(content, new MatchEvaluator(StripAttributesHandler));
        }


        private static string StripAttributesHandler(Match m)
        {
            if (m.Groups["attribute"].Success)
            {
                return m.Value.Replace(m.Groups["attribute"].Value, "");
            }
            else
            {
                return m.Value;
            }
        }

        private static string FilterAHrefScript(string content)
        {
            string newstr = FilterScript(content);
            string regexstr = @" href[ ^=]*= *[\s\S]*script *:";
            return Regex.Replace(newstr, regexstr, string.Empty, RegexOptions.IgnoreCase);
        }

        private static string FilterSrc(string content)
        {
            string newstr = FilterScript(content);
            string regexstr = @" src *= *['""]?[^\.]+\.(js|vbs|asp|aspx|php|jsp)['""]";
            return Regex.Replace(newstr, regexstr, @"", RegexOptions.IgnoreCase);
        }

        private static string FilterInclude(string content)
        {
            string newstr = FilterScript(content);
            string regexstr = @"<[\s\S]*include *(file|virtual) *= *[\s\S]*\.(js|vbs|asp|aspx|php|jsp)[^>]*>";
            return Regex.Replace(newstr, regexstr, string.Empty, RegexOptions.IgnoreCase);
        }

        private static string FilterObject(string content)
        {
            string regexstr = @"(?i)<Object([^>])*>(\w|\W)*</Object([^>])*>";
            return Regex.Replace(content, regexstr, string.Empty, RegexOptions.IgnoreCase);
        }

        private static string FilterIframe(string content)
        {
            string regexstr = @"(?i)<Iframe([^>])*>(\w|\W)*</Iframe([^>])*>";
            return Regex.Replace(content, regexstr, string.Empty, RegexOptions.IgnoreCase);
        }

        private static string FilterFrameset(string content)
        {
            string regexstr = @"(?i)<Frameset([^>])*>(\w|\W)*</Frameset([^>])*>";
            return Regex.Replace(content, regexstr, string.Empty, RegexOptions.IgnoreCase);
        }

        private static string FilterHtml(string content)
        {
            string newstr = FilterScript(content);
            string regexstr = @"<[^>]*>";
            return Regex.Replace(newstr, regexstr, string.Empty, RegexOptions.IgnoreCase);
        }

        #endregion

        /// <summary>
        /// 字符串中是否还有汉字
        /// </summary>
        /// <param name="testString"></param>
        /// <returns></returns>
        public static bool IsIncludeChineseCode(string testString)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(testString, @"[\u4e00-\u9fa5]+"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 从数组中删除重复的项
        /// tc 08-11-18 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] RepaceSpilthItem(string[] str)
        {
            System.Collections.ArrayList list = new System.Collections.ArrayList();

            string tempStr = "";

            foreach (string s in str)
            {
                tempStr = s.ToLower();

                if (list.Contains(tempStr)) continue;

                list.Add(tempStr);
            }

            return (string[])list.ToArray(typeof(string));
        }

        /// <summary>
        /// 把字符串数组转换成以，号隔开的字符串
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string ArrayToString(string[] strs)
        {
            string result = "";

            foreach (string s in strs)
            {
                result += "," + s;
            }

            return result.Substring(1);
        }

        /// <summary>
        /// 分类列表左右追加逗号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string AppendComma(string s)
        {
            if (!s.StartsWith(","))
                s = "," + s;

            if (!s.EndsWith(","))
                s = s + ",";

            s = s.Replace(",,", ",");

            return s;
        }

        /// <summary>
        /// 删除分类列表左右逗号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string RemoveComma(string s)
        {
            s = s.Replace(",,", ",");

            if (s.StartsWith(",")) s = s.Substring(1);

            if (s.EndsWith(",")) s = s.Substring(0, s.Length - 1);

            return s;
        }

        /// <summary>
        /// 删除分类列表开始位置逗号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string RemoveStartComma(string s)
        {
            s = s.Replace(",,", ",");

            if (s.StartsWith(",")) s = s.Substring(1);

            return s;
        }

        /// <summary>
        /// 删除分类列表结束位置逗号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string RemoveEndComma(string s)
        {
            s = s.Replace(",,", ",");

            if (s.EndsWith(",")) s = s.Substring(0, s.Length - 1);

            return s;
        }

        /// <summary>
        /// 获取主机名
        /// </summary>
        /// <returns></returns>
        public static string GetDomainHost()
        {
            string host = "";
            string currentFullHost = HttpContext.Current.Request.Params["HTTP_HOST"].ToString();
            if (currentFullHost.Contains("localhost")
                || currentFullHost.Contains("127.0.0.1"))
            {
                host = "0.0.1";
            }
            else
            {
                host = HttpContext.Current.Request.Params["HTTP_HOST"].Substring(HttpContext.Current.Request.Params["HTTP_HOST"].IndexOf('.'));
            }
            return host;
        }
    }
}
