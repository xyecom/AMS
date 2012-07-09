using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XYECOM.Configuration
{
    /// <summary>
    /// payment.config �����ļ�������
    /// </summary>
    public class Payment:BaseConfig
    {
        private AlipayInfo alipayInfo = null;
        private ChinaBankInfo chinaBankInfo = null;
        private _99BillInfo ___99BillInfo = null;

        private static volatile Payment instance = null;

        private Payment()
        {
        }

        /// <summary>
        /// ��ȡ��̬ʵ��
        /// </summary>
        public static Payment Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        instance = new Payment();
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// ��ʼ��
        /// </summary>
        protected override void Init()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/payment.config"));

            //֧������ض�ȡ
            XmlElement ele = (XmlElement)docXml.GetElementsByTagName("Alipay")[0];
            alipayInfo = new AlipayInfo();
            alipayInfo.IsEnabled = XYECOM.Core.MyConvert.GetBoolean(ele.GetAttribute("enabled").ToString());
            alipayInfo.Service = GetNodeValue(ele, "service");
            alipayInfo.Partner = GetNodeValue(ele, "partner");
            alipayInfo.InputCharset = GetNodeValue(ele, "inputcharset");
            alipayInfo.Email = GetNodeValue(ele, "email");
            alipayInfo.SecurityCode = GetNodeValue(ele, "securitycode");
            
            //����������ض�ȡ
            ele = (XmlElement)docXml.GetElementsByTagName("ChinaBank")[0];
            chinaBankInfo = new ChinaBankInfo();
            chinaBankInfo.IsEnabled = XYECOM.Core.MyConvert.GetBoolean(ele.GetAttribute("enabled").ToString());
            chinaBankInfo.V_Mid = GetNodeValue(ele, "v_mid");
            chinaBankInfo.Key = GetNodeValue(ele, "key");

            //��Ǯ��ض�ȡ
            ele = (XmlElement)docXml.GetElementsByTagName("_99Bill")[0];
            ___99BillInfo = new _99BillInfo();
            ___99BillInfo.IsEnabled = XYECOM.Core.MyConvert.GetBoolean(ele.GetAttribute("enabled").ToString());
            ___99BillInfo.Merchant_Id = GetNodeValue(ele, "merchant_id");
            ___99BillInfo.Merchant_Key = GetNodeValue(ele, "merchant_key");
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <returns>true:���³ɹ�,false:����ʧ��</returns>
        public override bool Update()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/payment.config"));

            //֧���� ���д��
            XmlElement ele = (XmlElement)docXml.GetElementsByTagName("Alipay")[0];
            ele.SetAttribute("enabled", alipayInfo.IsEnabled.ToString());
            SetNodeValue(ele, "service", alipayInfo.Service);
            SetNodeValue(ele, "partner", alipayInfo.Partner);
            SetNodeValue(ele, "inputcharset", alipayInfo.InputCharset);
            SetNodeValue(ele, "email", alipayInfo.Email);
            SetNodeValue(ele, "securitycode", alipayInfo.SecurityCode);

            ele = (XmlElement)docXml.GetElementsByTagName("ChinaBank")[0];
            ele.SetAttribute("enabled", chinaBankInfo.IsEnabled.ToString());
            SetNodeValue(ele, "v_mid", chinaBankInfo.V_Mid);
            SetNodeValue(ele, "key", chinaBankInfo.Key);

            ele = (XmlElement)docXml.GetElementsByTagName("_99Bill")[0];
            ele.SetAttribute("enabled", ___99BillInfo.IsEnabled.ToString());
            SetNodeValue(ele, "merchant_id", ___99BillInfo.Merchant_Id);
            SetNodeValue(ele, "merchant_key", ___99BillInfo.Merchant_Key);

            try
            {
                docXml.Save(System.Web.HttpContext.Current.Server.MapPath("/Config/payment.config"));
                instance = new Payment();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// ֧����������Ϣ
        /// </summary>
        public AlipayInfo AlipayInfo
        {
            get { return alipayInfo; }
            set { alipayInfo = value; }
        }

        /// <summary>
        /// ��������������Ϣ
        /// </summary>
        public ChinaBankInfo ChinaBankInfo
        {
            get { return chinaBankInfo; }
            set { chinaBankInfo = value; }
        }

        /// <summary>
        /// ��Ǯ������Ϣ
        /// </summary>
        public _99BillInfo __99BillInfo
        {
            get { return ___99BillInfo; }
            set { ___99BillInfo = value; }
        }
    }
}
