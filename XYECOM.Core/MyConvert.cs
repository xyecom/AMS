using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Core
{
    /// <summary>
    /// ��������ת��ͨ����
    /// </summary>
    public class MyConvert
    {
        /// <summary>
        /// ת������Int32���� ת��ʧ�ܷ���0
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int GetInt32(string num)
        {
            int number = 0;
            if (!string.IsNullOrEmpty(num))
            {
                num = num.Trim();
                int.TryParse(num, out number);
            }

            return number;
        }

        /// <summary>
        /// ת������Int16���� ת��ʧ�ܷ���0
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static short GetInt16(string num)
        {
            short number = 0;
            if (!string.IsNullOrEmpty(num))
            {
                num = num.Trim();
                short.TryParse(num, out number);
            }

            return number;
        }

        /// <summary>
        /// ת������Int64���� ת��ʧ�ܷ���0
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static long GetInt64(string num)
        {
            long number = 0;
            if (!string.IsNullOrEmpty(num))
            {
                num = num.Trim();
                long.TryParse(num, out number);
            }
            return number;
        }

        /// <summary>
        /// ת������Boolean���� ת��ʧ�ܷ��� false
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool GetBoolean(string value)
        {
            bool _value = false;
            bool.TryParse(value, out _value);

            return _value;
        }

        /// <summary>
        /// ת������Double���� ת��ʧ�ܷ��� 0
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static double GetDouble(string num)
        {
            double value = 0;
            if (!string.IsNullOrEmpty(num))
            {
                num = num.Trim();
                double.TryParse(num, out value);
            }
            return value;
        }

        /// <summary>
        /// ת������Decimal���� ת��ʧ�ܷ��� 0
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static decimal GetDecimal(string num)
        {
            decimal value = decimal.Zero;
            if (!string.IsNullOrEmpty(num))
            {
                num = num.Trim();
                decimal.TryParse(num, out value);
            }
            return value;
        }

        /// <summary>
        /// ת������float���� ת��ʧ�ܷ��� 0
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static float GetFloat(string num)
        {
            float value = 0;
            if (!string.IsNullOrEmpty(num))
            {
                num = num.Trim();
                float.TryParse(num, out value);
            }
            return value;
        }

        /// <summary>
        /// ת������DateTime���� ת��ʧ�ܷ��ص�ǰʱ��
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(string value)
        {
            DateTime _value = DateTime.Now;
            if (!string.IsNullOrEmpty(value))
            {
                value = value.Trim();
                DateTime.TryParse(value, out _value);
            }
            return _value;
        }
    }
}
