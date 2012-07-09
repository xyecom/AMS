using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XYECOM.Configuration
{
    /// <summary>
    /// FreeCode.config �����ļ�������
    /// </summary>
    public class FreeCode:BaseConfig
    {
        private static FreeCode instance = null;

        /// <summary>
        /// IM
        /// </summary>
        private IMInfo _IM = new IMInfo();

        private FreeCode() 
        {
        }

        /// <summary>
        /// ��ȡ��̬ʵ��
        /// </summary>
        public static FreeCode Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        instance = new FreeCode();        
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
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/FreeCode.config"));

            //IM ��ض�ȡ
            XmlElement imEle = (XmlElement)docXml.GetElementsByTagName("IM")[0];
            _IM.Name = GetNodeValue(imEle, "Name");
            _IM.IsEnabled = XYECOM.Core.MyConvert.GetBoolean(GetNodeValue(imEle, "Enabled"));
            _IM.Code = GetNodeValue(imEle,"Code");
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <returns>true:���³ɹ�,false:����ʧ��</returns>
        public override bool Update()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/FreeCode.config"));

            //IM ���д��
            XmlElement imEle = (XmlElement)docXml.GetElementsByTagName("IM")[0];
            SetNodeValue(imEle,"Name",_IM.Name);
            SetNodeValue(imEle, "Code", _IM.Code);
            SetNodeValue(imEle, "Enabled",_IM.IsEnabled.ToString());
            try
            {

                docXml.Save(System.Web.HttpContext.Current.Server.MapPath("/Config/FreeCode.config"));
                instance = new FreeCode();
                return true;
            }
            catch{ 
                return false;
            }
        }

        /// <summary>
        /// IM ��Ϣ
        /// </summary>
        public IMInfo IM
        {
            get { return _IM; }
        }
    }
}
