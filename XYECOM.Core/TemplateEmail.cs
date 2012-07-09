using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace XYECOM.Core
{
    /// <summary>
    /// 邮件短信模板处理类
    /// </summary>
    public  class TemplateEmail
    {
        /// <summary>
        /// 获取邮件内容
        /// </summary>
        /// <param name="str">参数</param>
        /// <param name="strName">替换值</param>
        /// <param name="templatename">模板路径</param>
        /// <returns> 返回邮件内容</returns>
        public static string GetContent(string[] str, string[] strName, string templetePath)
        {
            string content = GetTemplateContent(templetePath);
            if (content != "-1" || content != "-2")
            {
                StringBuilder strBuilder = new StringBuilder(content.ToLower());
                if (str.Length == strName.Length)
                {
                    for (int i=0; i < str.Length; i++)
                    {
                        strBuilder.Replace(strName[i].ToLower(), str[i]);
                    }
                    return strBuilder.ToString();
                }
                else
                {
                    return "参数不对应";
                }
            }
            else
            {
                return "模板不存在,模板文件内容为空";
            }
        }
        /// <summary>
        /// 获取模板内容
        /// </summary>
        /// <param name="templetePath">模板路径</param>
        /// <returns></returns>
        public static string GetTemplateContent(string templetePath)
        {
            string templeteContent = "";
            if (String.IsNullOrEmpty(templetePath) || !System.IO.File.Exists(Utils.GetMapPath(templetePath)))
                return "-1";// "模板不存在"
            try
            {
                templeteContent = System.IO.File.ReadAllText(Utils.GetMapPath(templetePath), System.Text.Encoding.Default);
                if (String.IsNullOrEmpty(templeteContent))
                    return "-2";// "模板文件内容为空！"
            }
            catch (Exception ex)
            {
                throw ex;
                    //return "-3";// "在读取模板文件是发生异常" 
            }
            return templeteContent;
        }
    }
}
