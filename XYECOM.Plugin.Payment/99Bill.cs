using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

namespace XYECOM.Plugin.Payment
{
    /// <summary>
    /// 块钱接口处理类
    /// </summary>
    public class _99Bill
    {
        private static string _PayUrl = "https://www.99bill.com/gateway/recvMerchantInfoAction.htm";

        private static string merchant_id = "";    //商户Id
        private static string merchant_key = "";   //商户密钥
        private static string inputCharset = "";   //1代表UTF-8; 2代表GBK; 3代表gb2312
        private static string version = "";        //网关版本.固定值,本代码版本号固定为v2.0
        private static string signType = "";       //签名类型.固定值；1代表MD5签名
        private static string language = "";       //语言种类.固定选择值，1代表中文；2代表英文，默认值为1
        private static string payerContactType = "";   //支付人联系方式类型.固定选择值，只能选择1，1代表Email
        private static string payType = "";        /*支付方式.固定选择值
                                                     只能选择00、10、11、12、13、14
                                                     00：组合支付（网关支付页面显示快钱支持的各种支付方式，推荐使用）
                                                     10：银行卡支付（网关支付页面只显示银行卡支付）.
                                                     11：电话银行支付（网关支付页面只显示电话支付）.
                                                     12：快钱账户支付（网关支付页面只显示快钱账户支付）.
                                                     13：线下支付（网关支付页面只显示线下支付方式）.
                                                     14：B2B支付（网关支付页面只显示B2B支付，但需要向快钱申请开通才能使用）*/

        private static string pid = "";            //快钱的合作伙伴的账户号，合作伙伴在快钱的用户编号
        private static string redoFlag = "";       /*同一订单禁止重复提交标志,固定选择值： 1、0
                                             1代表同一订单号只允许提交1次；
                                             0表示同一订单号在没有支付成功的前提下可重复提交多次。
                                             默认为0建议实物购物车结算类商户采用0；虚拟产品类商户采用1*/

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
        /// <param name="pageUrl">接受支付结果的页面地址</param>
        /// <param name="payerName">支付人姓名</param>
        /// <param name="payerContact">支付人联系方式，只能选择Email或手机号</param>
        /// <param name="orderId">商户订单号，由字母、数字、或[-][_]组成</param>
        /// <param name="orderAmount">订单金额，以分为单位，必须是整型数字，比方2，代表0.02元</param>
        /// <param name="productName">商品名称</param>
        /// <param name="productNum">商品数量</param>
        /// <param name="ext1">扩展字段1，在支付结束后原样返回给商户</param>
        /// <param name="ext2">扩展字段2，在支付结束后原样返回给商户</param>
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
            //form += "<input type=\"submit\" id=\"btnok\" value=\"提交\">\r\n";
            form += "</form>";

            form += "<script language=\"javascript\">kqPay.submit();</script>";
            form +=  "</body></html>";

            return form;

        }

        /// <summary>
        /// 将变量值不为空的参数组成字符串
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
        /// 订单提交时间，14位数字。年[4位]月[2位]日[2位]时[2位]分[2位]秒[2位]
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
