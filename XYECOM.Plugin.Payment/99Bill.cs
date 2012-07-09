using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

namespace XYECOM.Plugin.Payment
{
    /// <summary>
    /// ��Ǯ�ӿڴ�����
    /// </summary>
    public class _99Bill
    {
        private static string _PayUrl = "https://www.99bill.com/gateway/recvMerchantInfoAction.htm";

        private static string merchant_id = "";    //�̻�Id
        private static string merchant_key = "";   //�̻���Կ
        private static string inputCharset = "";   //1����UTF-8; 2����GBK; 3����gb2312
        private static string version = "";        //���ذ汾.�̶�ֵ,������汾�Ź̶�Ϊv2.0
        private static string signType = "";       //ǩ������.�̶�ֵ��1����MD5ǩ��
        private static string language = "";       //��������.�̶�ѡ��ֵ��1�������ģ�2����Ӣ�ģ�Ĭ��ֵΪ1
        private static string payerContactType = "";   //֧������ϵ��ʽ����.�̶�ѡ��ֵ��ֻ��ѡ��1��1����Email
        private static string payType = "";        /*֧����ʽ.�̶�ѡ��ֵ
                                                     ֻ��ѡ��00��10��11��12��13��14
                                                     00�����֧��������֧��ҳ����ʾ��Ǯ֧�ֵĸ���֧����ʽ���Ƽ�ʹ�ã�
                                                     10�����п�֧��������֧��ҳ��ֻ��ʾ���п�֧����.
                                                     11���绰����֧��������֧��ҳ��ֻ��ʾ�绰֧����.
                                                     12����Ǯ�˻�֧��������֧��ҳ��ֻ��ʾ��Ǯ�˻�֧����.
                                                     13������֧��������֧��ҳ��ֻ��ʾ����֧����ʽ��.
                                                     14��B2B֧��������֧��ҳ��ֻ��ʾB2B֧��������Ҫ���Ǯ���뿪ͨ����ʹ�ã�*/

        private static string pid = "";            //��Ǯ�ĺ��������˻��ţ���������ڿ�Ǯ���û����
        private static string redoFlag = "";       /*ͬһ������ֹ�ظ��ύ��־,�̶�ѡ��ֵ�� 1��0
                                             1����ͬһ������ֻ�����ύ1�Σ�
                                             0��ʾͬһ��������û��֧���ɹ���ǰ���¿��ظ��ύ��Ρ�
                                             Ĭ��Ϊ0����ʵ�ﹺ�ﳵ�������̻�����0�������Ʒ���̻�����1*/

        static _99Bill()
        {
            merchant_id = XYECOM.Configuration.Payment.Instance.__99BillInfo.Merchant_Id;
            merchant_key = XYECOM.Configuration.Payment.Instance.__99BillInfo.Merchant_Key;

            inputCharset = "1";
            version = "v2.0";
            signType = "1";
            language = "1";
            payerContactType = "1";
            payType = "00";
            pid = "";
            redoFlag = "1";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageUrl">����֧�������ҳ���ַ</param>
        /// <param name="payerName">֧��������</param>
        /// <param name="payerContact">֧������ϵ��ʽ��ֻ��ѡ��Email���ֻ���</param>
        /// <param name="orderId">�̻������ţ�����ĸ�����֡���[-][_]���</param>
        /// <param name="orderAmount">�������Է�Ϊ��λ���������������֣��ȷ�2������0.02Ԫ</param>
        /// <param name="productName">��Ʒ����</param>
        /// <param name="productNum">��Ʒ����</param>
        /// <param name="ext1">��չ�ֶ�1����֧��������ԭ�����ظ��̻�</param>
        /// <param name="ext2">��չ�ֶ�2����֧��������ԭ�����ظ��̻�</param>
        /// <returns></returns>
        public static string CreateUrl(
            string pageUrl,
            string payerName,
            string payerContact,
            string orderId, //
            string orderAmount,//
            string productName,
            string productNum,
            string ext1,
            string ext2)
        {

            string orderTime = GetOrderTime();
            
            String signMsgVal = "";
            signMsgVal = appendParam(signMsgVal, "inputCharset", inputCharset);
            signMsgVal = appendParam(signMsgVal, "pageUrl", pageUrl);
            signMsgVal = appendParam(signMsgVal, "bgUrl", "");
            signMsgVal = appendParam(signMsgVal, "version", version);
            signMsgVal = appendParam(signMsgVal, "language", language);
            signMsgVal = appendParam(signMsgVal, "signType", signType);
            signMsgVal = appendParam(signMsgVal, "merchantAcctId", merchant_id);
            signMsgVal = appendParam(signMsgVal, "payerName", payerName);
            signMsgVal = appendParam(signMsgVal, "payerContactType", payerContactType);
            signMsgVal = appendParam(signMsgVal, "payerContact", payerContact);
            signMsgVal = appendParam(signMsgVal, "orderId", orderId);
            signMsgVal = appendParam(signMsgVal, "orderAmount", orderAmount);
            signMsgVal = appendParam(signMsgVal, "orderTime", orderTime);
            signMsgVal = appendParam(signMsgVal, "productName", productName);
            signMsgVal = appendParam(signMsgVal, "productNum", productNum);
            signMsgVal = appendParam(signMsgVal, "productId", "");
            signMsgVal = appendParam(signMsgVal, "productDesc", "");
            signMsgVal = appendParam(signMsgVal, "ext1", ext1);
            signMsgVal = appendParam(signMsgVal, "ext2", ext2);
            signMsgVal = appendParam(signMsgVal, "payType", payType);
            signMsgVal = appendParam(signMsgVal, "bankId", "");
            signMsgVal = appendParam(signMsgVal, "redoFlag", redoFlag);
            signMsgVal = appendParam(signMsgVal, "pid", pid);
            signMsgVal = appendParam(signMsgVal, "key", merchant_key);

           
            String signMsg = GetMD5(signMsgVal);
            string form = "<html>\r\n"
                + "<body>\r\n";
            form += "<form name=\"kqPay\" id=\"kqPay\" method=\"post\" action=\"" + _PayUrl + "\"/>\r\n";
            form += "<input type=\"hidden\" name=\"inputCharset\"  id=\"inputCharset\"  value=\"" + inputCharset + "\"/>\r\n";
            form += "<input type=\"hidden\" name=\"bgUrl\"  id=\"bgUrl\" />\r\n";
            form += "<input type=\"hidden\" name=\"pageUrl\"  id=\"pageUrl\" value=\"" + pageUrl + "\"/>\r\n";
            form += "<input type=\"hidden\" name=\"version\"  id=\"version\" value=\"" + version + "\"/>\r\n";
            form += "<input type=\"hidden\" name=\"language\"  id=\"language\" value=\"" + language + "\"/>\r\n";
            form += "<input type=\"hidden\" name=\"signType\" id=\"signType\" value=\"" + signType + "\"/>\r\n";
            form += "<input type=\"hidden\" name=\"signMsg\"  id=\"signMsg\"  value=\"" + signMsg + "\"/>\r\n";
            form += "<input type=\"hidden\" name=\"merchantAcctId\" id=\"merchantAcctId\"  value=\"" + merchant_id + "\"/>\r\n";
            form += "<input type=\"hidden\" name=\"payerName\" id=\"payerName\"  value=\"" + payerName + "\"/>\r\n";
            form += "<input type=\"hidden\" name=\"payerContactType\"  id=\"payerContactType\"  value=\"" + payerContactType + "\"/>\r\n";
            form += "<input type=\"hidden\" name=\"payerContact\" id=\"payerContact\"  value=\"" + payerContact + "\"/>\r\n";
            form += "<input type=\"hidden\" name=\"orderId\"  id=\"orderId\" value=\"" + orderId + "\"/>\r\n";
            form += "<input type=\"hidden\" name=\"orderAmount\" id=\"orderAmount\" value=\"" + orderAmount + "\"/>\r\n";
            form += "<input type=\"hidden\" name=\"orderTime\" id=\"orderTime\"  value=\"" + orderTime + "\"/>\r\n";
            form += "<input type=\"hidden\" name=\"productName\" id=\"productName\"  value=\"" + productName + "\"/>\r\n";
            form += "<input type=\"hidden\" name=\"productNum\" id=\"productNum\"  value=\"" + productNum + "\"/>\r\n";
            form += "<input type=\"hidden\" name=\"productId\" id=\"productId\"  value=\"\"/>\r\n";
            form += "<input type=\"hidden\" name=\"productDesc\" id=\"productDesc\"  value=\"\"/>\r\n";
            form += "<input type=\"hidden\" name=\"ext1\" id=\"ext1\"  value=\"" + ext1 + "\"/>\r\n";
            form += "<input type=\"hidden\" name=\"ext2\" id=\"ext2\"  value=\"" + ext2 + "\"/>\r\n";
            form += "<input type=\"hidden\" name=\"payType\" id=\"payType\"  value=\"" + payType + "\"/>\r\n";
            form += "<input type=\"hidden\" name=\"bankId\" id=\"bankId\"  value=\"\"/>\r\n";
            form += "<input type=\"hidden\" name=\"redoFlag\" id=\"redoFlag\"  value=\"" + redoFlag + "\"/>\r\n";
            form += "<input type=\"hidden\" name=\"pid\" id=\"pid\"  value=\"" + pid + "\"/>\r\n";
            //form += "<input type=\"submit\" id=\"btnok\" value=\"�ύ\">\r\n";
            form += "</form>";

            form += "<script language=\"javascript\">kqPay.submit();</script>";
            form +=  "</body></html>";

            return form;

        }

        /// <summary>
        /// ������ֵ��Ϊ�յĲ�������ַ���
        /// </summary>
        /// <param name="returnStr"></param>
        /// <param name="paramId"></param>
        /// <param name="paramValue"></param>
        /// <returns></returns>
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

        /// <summary>
        /// �����ύʱ�䣬14λ���֡���[4λ]��[2λ]��[2λ]ʱ[2λ]��[2λ]��[2λ]
        /// </summary>
        /// <returns></returns>
        public static string GetOrderTime()
        {
            return DateTime.Now.ToString("yyyyMMddhhmmss");
        }

        public static string GetMD5(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5").ToUpper();
        }
    }
}
