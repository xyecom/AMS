using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using XYECOM.Core.XML;

namespace XYECOM.Configuration
{
    public class ClassAds : BaseConfig
    {
       
        private int number;

        private static ClassAds instance = null;
        /// <summary>
        /// ÿҳ���ĸ���
        /// </summary>
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        private bool isInherit;
        /// <summary>
        /// �����Ƿ�̳���ʾ����Ĺ��
        /// </summary>
        public bool IsInherit
        {
            get { return isInherit; }
            set { isInherit = value; }
        }

        private List<ClassAdsPriceInfo> ClassAdsPrice = new List<ClassAdsPriceInfo>();

         
        /// <summary>
        /// ����ƽ�����Ϣ
        /// </summary>
        public List<ClassAdsPriceInfo> listClassAdsPrice
        {
            get { return ClassAdsPrice; }
            set { ClassAdsPrice = value; }
        }
        public  ClassAds() { }

        public static ClassAds Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        instance = new ClassAds();
                    }
                }
                return instance;
            }
        }

        protected override void Init()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/ClassAds.config"));

            number = XYECOM.Core.MyConvert.GetInt32(GetNodeValue(docXml, "Number"));
            isInherit = XYECOM.Core.MyConvert.GetBoolean(GetNodeValue(docXml, "IsInherit"));
            //IM ��ض�ȡ
            XmlElement ele = (XmlElement)docXml.GetElementsByTagName("Price")[0];

            ClassAdsPriceInfo info = null;

            XmlNodeList list = ele.GetElementsByTagName("Item");

            for (int i = 0; i < list.Count; i++)
            {
                info =new ClassAdsPriceInfo();
                info.Step = XYECOM.Core.MyConvert.GetInt32(list[i].Attributes["Step"].Value);
                info.Price =XYECOM.Core.MyConvert.GetDouble(list[i].Attributes["Price"].Value);
                

                ClassAdsPrice.Add(info);
            }
        }

        public override bool Update()
        {
            XmlDocument docXml = new XmlDocument();

            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/ClassAds.config"));
        
            SetNodeValue(docXml, "Number", Number);
            SetNodeValue(docXml, "IsInherit", IsInherit);
            
            XmlElement ele = (XmlElement)docXml.GetElementsByTagName("Price")[0];
            
            ele.RemoveAll();
            
            XmlNode Item = null;

            foreach (ClassAdsPriceInfo info in ClassAdsPrice)
            {
                Item = XMLUtil.AppendElement(ele, "Item");
                XMLUtil.SetAttribute(Item, "Step", info.Step.ToString());
                XMLUtil.SetAttribute(Item, "Price", info.Price.ToString());
            }
            try
            {
                docXml.Save(System.Web.HttpContext.Current.Server.MapPath("/Config/ClassAds.config"));
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                instance =new ClassAds();
            }
        }
        /// <summary>
        /// ���ݷ���ļ������ع��۸�
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public double GetClassAdsPriceByStep(int step)
        {
            foreach (ClassAdsPriceInfo info in ClassAdsPrice)
            {
                if (info.Step == step) return info.Price;
            }

            return 0.0;
        }
        /// <summary>
        /// ���ؼ���
        /// </summary>
        /// <returns></returns>
        public List<ClassAdsPriceInfo> GetList()
        {
            return ClassAdsPrice;
        }

        public bool UpdatePriceForStep(int step, double price)
        {
            bool isUpdate = false;

            foreach (ClassAdsPriceInfo info in ClassAdsPrice)
            {
                if (info.Step == step)
                { 
                    info.Price = price;
                    isUpdate = true;
                }
            }

            if (!isUpdate)
            {
                ClassAdsPriceInfo newPrice = new ClassAdsPriceInfo();
                newPrice.Step = step;
                newPrice.Price = price;

                ClassAdsPrice.Add(newPrice);
            }
            return isUpdate;
        }
    }
}
