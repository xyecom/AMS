using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;

namespace XYECOM.Plugin.Payment
{
    /// <summary>
    /// ֧�����ӿڴ�����
    /// </summary>
    public class Alipay
    {
        private static string payUrl = "https://www.alipay.com/cooperate/gateway.do?";
        private static string inputCharset = "gb2312";
        private static string service = "";
        private static string partner = "";
        private static string sign_type = "";
        private static string seller_email = "";
        private static string key = "";

        static Alipay()
        {
            inputCharset = XYECOM.Configuration.Payment.Instance.AlipayInfo.InputCharset;
            service = XYECOM.Configuration.Payment.Instance.AlipayInfo.Service;
            partner = XYECOM.Configuration.Payment.Instance.AlipayInfo.Partner;
            sign_type = "MD5";
            seller_email = XYECOM.Configuration.Payment.Instance.AlipayInfo.Email;
            key = XYECOM.Configuration.Payment.Instance.AlipayInfo.SecurityCode;
        }

        /// <summary>
        /// ��ASP���ݵ�MD5�����㷨
        /// </summary>
        public static string GetMD5(string s, string _input_charset)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(s));
            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }

        public static string[] BubbleSort(string[] r)
        {
            int i, j; //������־ 
            string temp;

            bool exchange;

            for (i = 0; i < r.Length; i++) //�����R.Length-1������ 
            {
                exchange = false; //��������ʼǰ��������־ӦΪ��

                for (j = r.Length - 2; j >= i; j--)
                {
                    if (System.String.CompareOrdinal(r[j + 1], r[j]) < 0)��//��������
                    {
                        temp = r[j + 1];
                        r[j + 1] = r[j];
                        r[j] = temp;

                        exchange = true; //�����˽������ʽ�������־��Ϊ�� 
                    }
                }

                if (!exchange) //��������δ������������ǰ��ֹ�㷨 
                {
                    break;
                }
            }
            return r;
        }

        /// <summary>
        /// ��������գң�
        /// </summary>
        /// <param name="out_trade_no"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        /// <param name="show_url"></param>
        /// <param name="return_url"></param>
        /// <param name="notify_url"></param>
        /// <param name="logistics_type"></param>
        /// <param name="logistics_fee"></param>
        /// <param name="logistics_payment"></param>
        /// <param name="logistics_type_1"></param>
        /// <param name="logistics_fee_1"></param>
        /// <param name="logistics_payment_1"></param>
        /// <param name="payment_type"></param>
        /// <returns></returns>
        public static string CreateUrl(
            string out_trade_no,
            string subject,
            string body,
            string quantity,
            string price,
            string show_url,
            string return_url,
            string notify_url,
            string logistics_type,
            string logistics_fee,
            string logistics_payment,
            string logistics_type_1,
            string logistics_fee_1,
            string logistics_payment_1,
            string payment_type
            )
        {

            int i;

            String signMsgVal = "";
            signMsgVal = appendParam(signMsgVal, "service", service);
            signMsgVal = appendParam(signMsgVal, "partner", partner);
            signMsgVal = appendParam(signMsgVal, "subject", subject);
            signMsgVal = appendParam(signMsgVal, "body", body);
            signMsgVal = appendParam(signMsgVal, "out_trade_no", out_trade_no);
            signMsgVal = appendParam(signMsgVal, "price", price);
            signMsgVal = appendParam(signMsgVal, "show_url", show_url);
            signMsgVal = appendParam(signMsgVal, "quantity", quantity);
            signMsgVal = appendParam(signMsgVal, "seller_email", seller_email);
            signMsgVal = appendParam(signMsgVal, "notify_url", notify_url);
            signMsgVal = appendParam(signMsgVal, "return_url", return_url);
            signMsgVal = appendParam(signMsgVal, "logistics_type", logistics_type);
            signMsgVal = appendParam(signMsgVal, "logistics_fee", logistics_fee);
            signMsgVal = appendParam(signMsgVal, "logistics_payment", logistics_payment);
            signMsgVal = appendParam(signMsgVal, "logistics_type_1", logistics_type_1);
            signMsgVal = appendParam(signMsgVal, "logistics_fee_1", logistics_fee_1);
            signMsgVal = appendParam(signMsgVal, "logistics_payment_1", logistics_payment_1);
            signMsgVal = appendParam(signMsgVal, "payment_type", payment_type);

            //�������飻
            string[] Oristr = signMsgVal.Split('&');

            //��������
            string[] Sortedstr = BubbleSort(Oristr);


            //�����md5ժҪ�ַ��� ��

            StringBuilder prestr = new StringBuilder();

            for (i = 0; i < Sortedstr.Length; i++)
            {
                if (i == Sortedstr.Length - 1)
                {
                    prestr.Append(Sortedstr[i]);

                }
                else
                {
                    prestr.Append(Sortedstr[i] + "&");
                }
            }

            prestr.Append(key);

            //����Md5ժҪ��
            string sign = GetMD5(prestr.ToString(), inputCharset);

            //����֧��Url��
            StringBuilder parameter = new StringBuilder();
            parameter.Append(payUrl);
            for (i = 0; i < Sortedstr.Length; i++)
            {
                parameter.Append(Sortedstr[i] + "&");
            }

            parameter.Append("sign=" + sign + "&sign_type=" + sign_type);


            //����֧��Url��
            return parameter.ToString();
        }

        //���ܺ�����������ֵ��Ϊ�յĲ�������ַ���
        public static String appendParam(String returnStr, String paramId, String paramValue)
        {
            if (returnStr != "")
            {
                if (paramValue != "")
                {
                    returnStr += "&" + paramId + "=" + paramValue;
                }
            }
            else
            {
                if (paramValue != "")
                {
                    returnStr = paramId + "=" + paramValue;
                }
            }

            return returnStr;
        }

        //��ȡԶ�̷�����ATN���
        public static String Get_Http(String a_strUrl, int timeout)
        {
            string strResult;
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(a_strUrl);
                myReq.Timeout = timeout;
                HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
                Stream myStream = HttpWResp.GetResponseStream();
                StreamReader sr = new StreamReader(myStream, Encoding.Default);
                StringBuilder strBuilder = new StringBuilder();
                while (-1 != sr.Peek())
                {
                    strBuilder.Append(sr.ReadLine());
                }

                strResult = strBuilder.ToString();
            }
            catch (Exception exp)
            {

                strResult = "����" + exp.Message;
            }

            return strResult;
        }

        /// <summary>
        /// ���鷵�ؽ��
        /// </summary>
        /// <returns></returns>
        public static bool CheckPayResult()
        {
            string alipayNotifyURL = "https://www.alipay.com/cooperate/gateway.do?service=notify_verify&partner=" + partner + "&notify_id=" + XYECOM.Core.XYRequest.GetQueryString("notify_id");

            string responseTxt = Get_Http(alipayNotifyURL, 120000);
            //*********************************************************************************************
            int i;

            // Get names of all forms into a string array.
            String[] requestarr = System.Web.HttpContext.Current.Request.QueryString.AllKeys;



            //��������
            string[] Sortedstr = BubbleSort(requestarr);

            //�����md5ժҪ�ַ��� ��

            StringBuilder prestr = new StringBuilder();

            for (i = 0; i < Sortedstr.Length; i++)
            {
                if (XYECOM.Core.XYRequest.GetQueryString(Sortedstr[i]) != "" && Sortedstr[i] != "sign" && Sortedstr[i] != "sign_type" && Sortedstr[i] != "tool")
                {
                    if (i == Sortedstr.Length - 1)
                    {
                        prestr.Append(Sortedstr[i] + "=" + XYECOM.Core.XYRequest.GetQueryString(Sortedstr[i]));

                    }
                    else
                    {

                        prestr.Append(Sortedstr[i] + "=" + XYECOM.Core.XYRequest.GetQueryString(Sortedstr[i]) + "&");
                    }
                }
            }

            prestr.Append(key);

            //����Md5ժҪ��
            string mysign = GetMD5(prestr.ToString(),inputCharset);


            string sign = XYECOM.Core.XYRequest.GetQueryString("sign");
                        
            return mysign == sign && responseTxt == "true";
        }
    }
}
