using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;

namespace XYECOM.Template
{
    /// <summary>
    /// ģ���������������࣬ģ��vb������������ʹ��Сд
    /// </summary>
    public class Method
    {
        /// <summary>
        /// ���ұ߿�ʼ��ȡָ�����ȵ��ַ���
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <param name="length">����</param>
        /// <returns></returns>
        public static string right(string str, int length)
        {
            return Strings.Right(str, length);
        }

        /// <summary>
        /// ��ȡ�ַ�������
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <returns></returns>
        public static string len(string str)
        {
            return str.Length.ToString();            
        }

        /// <summary>
        /// ��ָ��λ�ÿ�ʼ��ȡָ�����ȵ��ַ�
        /// </summary>
        /// <param name="str">ԭʼ�ַ���</param>
        /// <param name="startIndex">��ʼλ��</param>
        /// <param name="length">��ȡ����</param>
        /// <returns></returns>
        public static string mid(string str, int startIndex, int length)
        {
            return Strings.Mid(str, startIndex, length);
        }

        /// <summary>
        /// ����߿�ʼ��ȡָ�����ȵ��ַ�( һ������Ϊ�����ַ� )
        /// </summary>
        /// <param name="str">ԭʼ�ַ���</param>
        /// <param name="length">��ȡ����</param>
        /// <returns></returns>
        public static string left(string str, int length)
        {
            str = XYECOM.Core.Utils.RemoveHTML(str);

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
                tempString += "��";

            return tempString;
        }

        /// <summary>
        /// ��������ؼ���
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        //public static string filter(string uid,string content)
        //{
        //    //long Id = XYECOM.Core.MyConvert.GetInt64(uid);

        //    //if (Id <= 0) return "";

        //    //Model.UserRegInfo userinfo = new Business.UserReg().GetItem(Id);

        //    //if (userinfo == null) return "";

        //    //return XYECOM.Business.FiltrateKeyWord.LeachKeyWord(userinfo.GradeId, content);

        //    return "";
        //}

        /// <summary>
        /// ��ʽ��ʱ��
        /// </summary>
        /// <param name="str">ʱ���ַ���</param>
        /// <param name="format">��ʽ�ַ���</param>
        /// <returns></returns>
        public static string formatdatetime(string str, string format)
        {
            string result = "";

            try
            {
                result = Convert.ToDateTime(str).ToString(format);
            }
            catch { }

            return result;
        }
    }
}
