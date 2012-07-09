using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace XYECOM.Core
{
    /// <summary>
    /// �ʼ�����ģ�崦����
    /// </summary>
    public  class TemplateEmail
    {
        /// <summary>
        /// ��ȡ�ʼ�����
        /// </summary>
        /// <param name="str">����</param>
        /// <param name="strName">�滻ֵ</param>
        /// <param name="templatename">ģ��·��</param>
        /// <returns> �����ʼ�����</returns>
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
                    return "��������Ӧ";
                }
            }
            else
            {
                return "ģ�岻����,ģ���ļ�����Ϊ��";
            }
        }
        /// <summary>
        /// ��ȡģ������
        /// </summary>
        /// <param name="templetePath">ģ��·��</param>
        /// <returns></returns>
        public static string GetTemplateContent(string templetePath)
        {
            string templeteContent = "";
            if (String.IsNullOrEmpty(templetePath) || !System.IO.File.Exists(Utils.GetMapPath(templetePath)))
                return "-1";// "ģ�岻����"
            try
            {
                templeteContent = System.IO.File.ReadAllText(Utils.GetMapPath(templetePath), System.Text.Encoding.Default);
                if (String.IsNullOrEmpty(templeteContent))
                    return "-2";// "ģ���ļ�����Ϊ�գ�"
            }
            catch (Exception ex)
            {
                throw ex;
                    //return "-3";// "�ڶ�ȡģ���ļ��Ƿ����쳣" 
            }
            return templeteContent;
        }
    }
}
