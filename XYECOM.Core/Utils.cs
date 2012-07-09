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
    /// ͨ�÷���
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// ���ַ�������url����
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string JSEscape(string str)
        {
            return Microsoft.JScript.GlobalObject.escape(str);
        }
        /// <summary>
        /// ���ַ�������url����
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string JSunescape(string str)
        {
            return Microsoft.JScript.GlobalObject.unescape(str);
        }
        /// <summary>
        /// У��SQL��䣬�滻" ' "�ַ�
        /// </summary>
        /// <param name="str">SQL���</param>
        /// <returns>�����滻���SQL���</returns>
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
        /// ɾ���ļ�
        /// </summary>
        /// <param name="fileFullPath">�ļ��ڷ������е�ȫ·��</param>
        /// <returns>�ɹ���ʧ�� falseΪ�ļ������ڻ���ɾ��ʧ��</returns>
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
        /// �ж��ļ��Ƿ����
        /// </summary>
        /// <param name="filename">�ļ�·��</param>
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
        /// ��ȡ���򼯲�Ʒ����
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyProductName()
        {
            return FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductName;
        }
        /// <summary>
        /// ��ȡ���򼯳���汾
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
        /// ͨ������·����ȡ����·��
        /// </summary>
        /// <param name="strPath">����·��</param>
        /// <returns></returns>
        public static string GetMapPath(string strPath)
        {
            return HttpContext.Current.Server.MapPath(strPath);
        }
        

        /// <summary>
        /// HTML����
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HtmlDecode(string str)
        {
            return HttpUtility.HtmlDecode(str);
        }

        /// <summary>
        /// HTML����
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HtmlEncode(string str)
        {
            return HttpUtility.HtmlEncode(str);
        }
        
        #region ����������ʽ
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
        /// ��ͻ�������ļ�
        /// </summary>
        /// <param name="filepath">�ļ�·��</param>
        /// <param name="filename">�ļ�����</param>
        /// <param name="filetype">�ļ�����</param>
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
        /// �ַ����ָ�
        /// </summary>
        /// <param name="strContent">ԭʼ�ַ���</param>
        /// <param name="strSplit">�ָ�����</param>
        /// <returns>�ַ�����</returns>
        public static string[] SplitString(string strContent, string strSplit)
        {
            if (strContent.IndexOf(strSplit) < 0)
            {
                return new string[] { strContent };
            }
            return Regex.Split(strContent, strSplit.Replace(".", @"\."), RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// ��ʽ���ַ��� �滻 �س����з���
        /// </summary>
        /// <param name="str">ԭʼ�ַ���</param>
        /// <returns>�滻����ַ���</returns>
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

        #region ��������ת��
        /// <summary>
        /// �ַ���ת����Ϊ Float ��
        /// </summary>
        /// <param name="strValue">�ַ���</param>
        /// <param name="defValue">Ĭ��ֵ</param>
        /// <returns>ת���õ��ĸ�����</returns>
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
        /// �ַ���ת����Ϊ Int ��
        /// </summary>
        /// <param name="strValue">�ַ���</param>
        /// <param name="defValue">Ĭ��ֵ</param>
        /// <returns>ת���õ���Int��</returns>
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
        /// �ַ���ת����Ϊ Int64 ��
        /// </summary>
        /// <param name="strValue">�ַ���</param>
        /// <param name="defValue">Ĭ��ֵ</param>
        /// <returns>ת���õ���Int��</returns>
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

        #region ��ȡ����
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

        #region �Ը����� Url ���б���
        /// <summary>
        /// �Ը����� Url ���н���
        /// </summary>
        /// <param name="str">������� Url</param>
        /// <returns>������ Url</returns>
        public static string UrlDecode(string str)
        {
            return HttpUtility.UrlDecode(str);
        }


        /// <summary>
        /// �Ը����� Url ���б���
        /// </summary>
        /// <param name="str">������Url</param>
        /// <returns>������ Url</returns>
        public static string UrlEncode(string str)
        {
            return HttpUtility.UrlEncode(str);
        }
        #endregion


        #region ��д cookie
        /// <summary>
        /// ��д cookie
        /// </summary>
        /// <param name="strName">��Ϣ����</param>
        /// <param name="strValue">��Ϣ����</param>
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
        /// д cookie
        /// </summary>
        /// <param name="strName">��Ϣ����</param>
        /// <param name="strValue">��Ϣ����</param>
        /// <param name="expires">����ʱ��</param>
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
        /// ��ȡCookie
        /// </summary>
        /// <param name="strName">Cookie����</param>
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
        /// ���Cookie
        /// </summary>
        /// <param name="strName">cookie��</param>
        /// <param name="domainName">��</param>
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
        /// ���Cookie
        /// </summary>
        /// <param name="strName">cookie��</param>
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

        #region ��дSession

        /// <summary>
        /// ����Session
        /// </summary>
        /// <param name="sessionName">session����</param>
        /// <param name="value">ֵ</param>
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
        /// ��ȡSession ֵ
        /// </summary>
        /// <param name="sessionName">session����</param>
        /// <returns></returns>
        public static object GetSessionObj(string sessionName)
        {
            return HttpContext.Current.Session[sessionName];
        }

        /// <summary>
        /// ��ȡSession ֵ
        /// </summary>
        /// <param name="sessionName">session����</param>
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
        /// ���Session
        /// </summary>
        /// <param name="sessionName">session����</param>
        public static void ClearSession(string sessionName)
        {
            HttpContext.Current.Session.Remove(sessionName);
        }

        #endregion

        /// <summary>
        /// ת���۸�
        /// </summary>
        /// <param name="P_Price">�۸�</param>
        /// <returns>�۸�</returns>
        public static string GetMoney(string P_Price)
        {
            int idex = P_Price.IndexOf(".");
            if (idex > 0 && P_Price.Length > idex + 2)
                return P_Price.Substring(0, idex + 3);
            else
                return P_Price;

        }

        #region ��ȡ�ַ���
        /// <summary>
        /// ��ȡ�ַ���
        /// </summary>
        /// <param name="length">Ҫ��ʾ���ַ�������</param>
        /// <param name="str">Ҫ�����ַ���</param>
        /// <returns>�������ַ���</returns>
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

        #region ƴ�ӱ�ǩ
        /// <summary>
        /// ƴ�ӱ�ǩ
        /// </summary>
        /// <param name="strName">����</param>
        /// <param name="strValue">ֵ</param>
        /// <returns>ƴ�Ӻõ��ַ���</returns>
        public static string LableSet(string strName, string strValue)
        {
            return "��" + strName + "$" + strValue;
        }
        #endregion

        #region ����html����
        /// <summary>
        /// ��������HTML����
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
        /// ���˲���htmlΣ�մ���
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
            // ����ע�ͺ�Script���
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
            // ʹ��MatchEvaluator��ί��
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
        /// �ַ������Ƿ��к���
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
        /// ��������ɾ���ظ�����
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
        /// ���ַ�������ת�����ԣ��Ÿ������ַ���
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
        /// �����б�����׷�Ӷ���
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
        /// ɾ�������б����Ҷ���
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
        /// ɾ�������б�ʼλ�ö���
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
        /// ɾ�������б����λ�ö���
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
        /// ��ȡ������
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
