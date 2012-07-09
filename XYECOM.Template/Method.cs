using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;

namespace XYECOM.Template
{
    /// <summary>
    /// 模板制作公开方法类，模拟vb方法，方法名使用小写
    /// </summary>
    public class Method
    {
        /// <summary>
        /// 从右边开始截取指定长度的字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string right(string str, int length)
        {
            return Strings.Right(str, length);
        }

        /// <summary>
        /// 获取字符串长度
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string len(string str)
        {
            return str.Length.ToString();            
        }

        /// <summary>
        /// 从指定位置开始截取指定长度的字符
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="length">截取长度</param>
        /// <returns></returns>
        public static string mid(string str, int startIndex, int length)
        {
            return Strings.Mid(str, startIndex, length);
        }

        /// <summary>
        /// 从左边开始截取指定长度的字符( 一个汉字为两个字符 )
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <param name="length">截取长度</param>
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
                tempString += "…";

            return tempString;
        }

        /// <summary>
        /// 过滤特殊关键字
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
        /// 格式化时间
        /// </summary>
        /// <param name="str">时间字符串</param>
        /// <param name="format">格式字符串</param>
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
