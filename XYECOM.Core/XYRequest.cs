using System;
using System.Collections.Generic;
using System.Text;

using System.Web;
namespace XYECOM.Core
{
    /// <summary>
    /// ��ȡ���ݹ�����
    /// </summary>
    public class XYRequest
    {
        #region �ӱ���ȡ����
        /// <summary>
        /// ��ȡ���ύ������ ������
        /// </summary>
        /// <param name="strName">Key </param>
        /// <param name="defValue">Ĭ��ֵ</param>
        /// <returns>������</returns>
        public static float GetFloat(string strName, float defValue)
        {
            if (GetQueryFloat(strName, defValue) == defValue)
            {
                return GetFormFloat(strName, defValue);
            }
            return GetQueryFloat(strName, defValue);
        }
        /// <summary>
        /// ��ȡ���ύ������ ������
        /// </summary>
        /// <param name="strName">Key</param>
        /// <param name="defValue">Ĭ��ֵ</param>
        /// <returns>������</returns>
        public static float GetFormFloat(string strName, float defValue)
        {
            return Utils.StrToFloat(HttpContext.Current.Request.Form[strName], defValue);
        }

       
        /// <summary>
        /// ��ȡ���ύ������ ����
        /// </summary>
        /// <param name="strName">Key</param>
        /// <param name="defValue">Ĭ��ֵ</param>
        /// <returns>����</returns>
        public static int GetFormInt(string strName, int defValue)
        {
            return Utils.StrToInt(HttpContext.Current.Request.Form[strName], defValue);
        }

        /// <summary>
        /// ��ȡ���ύ������ ������
        /// </summary>
        /// <param name="strName">Key</param>
        /// <param name="defValue">Ĭ��ֵ</param>
        /// <returns>����</returns>
        public static long GetFormInt64(string strName, int defValue)
        {
            return Utils.StrToInt64(HttpContext.Current.Request.Form[strName], defValue);
        }

        /// <summary>
        /// ��ȡ���ύ������ �ַ���
        /// </summary>
        /// <param name="strName">�ַ���</param>
        /// <returns>�ַ���</returns>
        public static string GetFormString(string strName)
        {
            if (HttpContext.Current.Request.Form[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.Form[strName];
        }
        /// <summary>
        /// ��ȡ���ύ������ ����
        /// </summary>
        /// <param name="strName">Key</param>
        /// <param name="defValue">Ĭ��ֵ</param>
        /// <returns>����</returns>
        public static int GetInt(string strName, int defValue)
        {
            if (GetQueryInt(strName, defValue) == defValue)
            {
                return GetFormInt(strName, defValue);
            }
            return GetQueryInt(strName, defValue);
        }
        /// <summary>
        /// ��ȡ����������
        /// </summary>
        /// <param name="strName">����������</param>
        /// <returns>����������</returns>
        public static string GetString(string strName)
        {
            if ("".Equals(GetQueryString(strName)))
            {
                return GetFormString(strName);
            }
            return GetQueryString(strName);
        }
        /// <summary>
        /// ��ȡҳ������
        /// </summary>
        /// <returns>ҳ������</returns>
        public static string GetPageName()
        {
            string[] textArray = HttpContext.Current.Request.Url.AbsolutePath.Split(new char[] { '/' });
            return textArray[textArray.Length - 1].ToLower();
        }

        /// <summary>
        /// ��ȡfloat����ֵ
        /// </summary>
        /// <param name="strName">������</param>
        /// <param name="defValue">Ĭ��ֵ</param>
        /// <returns></returns>
        public static float GetQueryFloat(string strName, float defValue)
        {
            return Utils.StrToFloat(HttpContext.Current.Request.QueryString[strName], defValue);
        }
        /// <summary>
        /// ��ȡ������
        /// </summary>
        /// <param name="strName">������Ϣ����</param>
        /// <param name="defValue">������ϢĬ�ϱ��</param>
        /// <returns>�����߱��</returns>
        public static int GetQueryInt(string strName, int defValue)
        {
            return Utils.StrToInt(HttpContext.Current.Request.QueryString[strName], defValue);
        }
        /// <summary>
        /// ��ȡ������
        /// </summary>
        /// <param name="strName">������Ϣ����</param>
        /// <param name="defValue">������ϢĬ�ϱ��</param>
        /// <returns>�����߱��</returns>
        public static Int64 GetQueryInt64(string strName)
        {
            return Utils.StrToInt64(HttpContext.Current.Request.QueryString[strName], 0);
        }
        /// <summary>
        /// ��ȡ�����ߵ�����
        /// </summary>
        /// <param name="strName">����������</param>
        /// <returns>����������</returns>
        public static string GetQueryString(string strName)
        {
            if (HttpContext.Current.Request.QueryString[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.QueryString[strName].ToString().Trim();
        }
        #endregion 

        #region ��ȡ�йؿͻ��� IP��Url ����Ϣ
        /// <summary>
        /// ��ȡ�ͻ��˵� IP
        /// </summary>
        /// <returns>�ͻ��� IP</returns>
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
        /// ��ȡ��ǰ�����ԭʼ Url
        /// </summary>
        /// <returns></returns>
        public static string GetRawUrl()
        {
            return HttpContext.Current.Request.RawUrl;
        }
        /// <summary>
        /// ��ȡ��Ӧ�����ߵķ������˱���
        /// </summary>
        /// <param name="strName">����������</param>
        /// <returns>�������˱���</returns>
        public static string GetServerString(string strName)
        {
            if (HttpContext.Current.Request.ServerVariables[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.ServerVariables[strName].ToString();
        }
        
        /// <summary>
        /// ��ȡ�йص�ǰ����� Url
        /// </summary>
        /// <returns></returns>
        public static string GetUrl()
        {
            return HttpContext.Current.Request.Url.ToString();
        }
        /// <summary>
        /// ��ȡ�йؿͻ����ϴ������ Url ��Ϣ�����������ӵ���ǰ�� Url
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

        #region �ύ������Ϣ
        /// <summary>
        /// �жϿͻ����Ƿ� Get �ύ
        /// </summary>
        /// <returns>true :��ʾ�� get �ύ</returns>
        public static bool IsGet()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("GET");
        }
        /// <summary>
        /// �жϿͻ����Ƿ� Post �ύ
        /// </summary>
        /// <returns>true ��ʾ��Post�ύ</returns>
        public static bool IsPost()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("POST");
        }
        /// <summary>
        /// �ж��Ƿ� ͨ���������� �ύ
        /// </summary>
        /// <returns>true ��ʾ��ͨ�����������ύ</returns>
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
        /// ��ȡ�ͻ��������͵����� �Ƿ�ͨ����������͵�
        /// </summary>
        /// <returns>true ��ʾ��������ͨ�����������</returns>
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
        /// ���������ļ�
        /// </summary>
        /// <param name="path">�ļ�·��</param>
        public static void SaveRequestFile(string path)
        {
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                HttpContext.Current.Request.Files[0].SaveAs(path);
            }
        }
    } 
}
