using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.IO;
using System.Net;

namespace XYECOM.Plugin.Payment
{
    /// <summary>
    /// 网银在线接口处理类
    /// </summary>
    public class ChinaBank
    {
        private static string _PayUrl = "https://pay3.chinabank.com.cn/PayGate";
        private static string key = "";    //商户密钥
        private static string v_mid = "";  //商户号

        static ChinaBank()
        {
            v_mid = XYECOM.Configuration.Payment.Instance.ChinaBankInfo.V_Mid;
            key = XYECOM.Configuration.Payment.Instance.ChinaBankInfo.Key;
        }

        /// <summary>
        /// 获取访问ＵＲＬ
        /// </summary>
        /// <param name="v_oid">订单号</param>
        /// <param name="v_amount">金额</param>
        /// <param name="v_moneytype">货币类型(CNY:人民币)</param>
        /// <param name="v_url">返回地址</param>
        /// <param name="remark1"></param>
        /// <param name="remark2"></param>
        /// <returns></returns>
        public static string CreateUrl(
            string v_oid,
            string v_amount,
            string v_moneytype,
            string v_url,
            string remark1,
            string remark2)
        {
            string text = v_amount + v_moneytype + v_oid + v_mid + v_url + key;

            string v_md5info = GetMD5(text);

            //string data = "v_oid=" + v_oid 
            //            + "&v_amount=" + v_amount 
            //            + "&v_moneytype=" + v_moneytype
            //            + "&v_url=" + v_url
            //            + "&v_mid=" + v_mid
            //            + "&v_md5info=" + v_md5info;


            string form = "<html><body>"
                        + "<form action=\"" + _PayUrl + "\" method=\"post\" id=\"formPayByChinabank\" name=\"formPayByChinabank\">"
                        +"<input type=\"hidden\" name=\"v_md5info\" size=\"100\" value=\"" + v_md5info + "\">"
                        + "<input type=\"hidden\" name=\"v_mid\" value=\"" + v_mid + "\">"
                        + "<input type=\"hidden\" name=\"v_oid\" value=\"" + v_oid + "\">"
                        + "<input type=\"hidden\" name=\"v_amount\" value=\"" + v_amount + "\">"
                        + "<input type=\"hidden\" name=\"v_moneytype\" value=\"" + v_moneytype + "\">"
                        + "<input type=\"hidden\" name=\"v_url\" value=\"" + v_url + "\">"
                        +"<input type=\"hidden\" name=\"remark1\" value=\"\">"
                        +"<input type=\"hidden\" name=\"remark2\" value=\"\">"
                        + "</form>"
                        +""
                        + "<script language=\"javascript\">formPayByChinabank.submit();</script>"
                        +"</body></html>";

            return form;
        }

        public static string GetMD5(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5").ToUpper();
        }

        private string PostData(string url, string data, string encode)
        {
            CookieContainer cc = new CookieContainer();
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.CookieContainer = cc;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            Stream requestStream = request.GetRequestStream();
            byte[] byteArray = Encoding.UTF8.GetBytes(data);
            requestStream.Write(byteArray, 0, byteArray.Length);
            requestStream.Close();

            return "";
            //HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //Uri responseUri = response.ResponseUri;
            //Stream receiveStream = response.GetResponseStream();
            //StreamReader readStream = new StreamReader(receiveStream, System.Text.Encoding.GetEncoding(encode));
            //string result = readStream.ReadToEnd();
            //return result;
        }
    }
}
