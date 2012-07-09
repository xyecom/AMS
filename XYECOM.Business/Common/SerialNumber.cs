using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Business
{
    public class SerialNumber
    {
        public static string GetSerialNumber(Model.SerialNumberFlag flag)
        {
            return GetSerialNumber(flag, DateTime.Now, 32);
        }

        public static string GetSerialNumber(Model.SerialNumberFlag flag, int snLength)
        {
            return GetSerialNumber(flag, DateTime.Now, snLength);
        }


        public static string GetSerialNumber(Model.SerialNumberFlag flag, DateTime datetime, int snLength)
        {
            return GetSerialNumber(flag, datetime, string.Empty, snLength);
        }


        /// <summary>
        /// 目前所有的编号都采取默认规则。生成的编号为长度是32的前缀+时间的格式
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="datetime"></param>
        /// <param name="qianzhui"></param>
        /// <returns></returns>
        public static string GetSerialNumber(Model.SerialNumberFlag flag, DateTime datetime, string qianzhui, int snLength)
        {
            string sn = string.Empty;

            string qz = string.Empty;

            if (string.IsNullOrEmpty(qianzhui))
            {
                qz = flag.ToString().ToUpper();
            }
            else
            {
                qz = qianzhui.ToUpper();
            }

            switch (flag)
            {
                case XYECOM.Model.SerialNumberFlag.OS:
                    break;
                case XYECOM.Model.SerialNumberFlag.PA:
                    break;
                case XYECOM.Model.SerialNumberFlag.DS:
                    break;
                default:
                    break;
            }

            sn = string.Format("{0}{1}", qz, datetime.ToString("yyyyMMddhhmmssfff").PadLeft(snLength - 2, '0'));

            return sn;
        }
    }
}
