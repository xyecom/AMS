using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XYECOM.Configuration
{
    /// <summary>
    /// shop.config �ļ�������
    /// </summary>
    public class Shop:BaseConfig
    {
        private static Shop instance = null;

        private int indexNewProNumber;
        private int indexOfferNumber;
        private int productPageSize;
        private int infoPageSize;
        private int newsPageSize;
        private int brandPageSize;
        private int jobPageSize;

        private Shop()
        {
        }

        /// <summary>
        /// ��ȡ��̬ʵ��
        /// </summary>
        public static Shop Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        instance = new Shop();
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
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/Shop.config"));
            indexNewProNumber = Core.MyConvert.GetInt32(GetNodeValue(docXml, "IndexNewProNumber"));
            indexOfferNumber = Core.MyConvert.GetInt32(GetNodeValue(docXml, "IndexOfferNumber"));
            productPageSize = Core.MyConvert.GetInt32(GetNodeValue(docXml, "ProductPageSize"));
            infoPageSize = Core.MyConvert.GetInt32(GetNodeValue(docXml, "InfoPageSize"));
            newsPageSize = Core.MyConvert.GetInt32(GetNodeValue(docXml, "NewsPageSize"));
            brandPageSize = Core.MyConvert.GetInt32(GetNodeValue(docXml, "BrandPageSize"));
            jobPageSize = Core.MyConvert.GetInt32(GetNodeValue(docXml, "JobPageSize"));
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <returns>true:���³ɹ�,false:����ʧ��</returns>
        public override bool Update()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/Shop.config"));
            SetNodeValue(docXml, "IndexNewProNumber", indexNewProNumber);
            SetNodeValue(docXml, "IndexOfferNumber", indexOfferNumber);
            SetNodeValue(docXml, "ProductPageSize", productPageSize);
            SetNodeValue(docXml, "InfoPageSize", infoPageSize);
            SetNodeValue(docXml, "NewsPageSize", newsPageSize);
            SetNodeValue(docXml, "BrandPageSize", brandPageSize);
            SetNodeValue(docXml, "JobPageSize", jobPageSize);

            try
            {
                docXml.Save(System.Web.HttpContext.Current.Server.MapPath("/Config/Shop.config"));
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                instance = new Shop();
            }
        }

        /// <summary>
        /// ������ҳ�²�Ʒ��������
        /// </summary>
        public int IndexNewProNumber
        {
            get
            {
                if (indexNewProNumber <= 0) return 1;

                return indexNewProNumber; 
            }
            set { indexNewProNumber = value; }
        }

        /// <summary>
        /// ������ҳ�Ƽ�������Ϣ��������
        /// </summary>
        public int IndexOfferNumber
        {
            get 
            {
                if (indexOfferNumber <= 0) return 1;

                return indexOfferNumber; 
            }
            set { indexOfferNumber = value; }
        }

        /// <summary>
        /// ��Ʒչʾҳÿҳ����
        /// </summary>
        public int ProductPageSize
        {
            get 
            {
                if (productPageSize <= 0) return 1;

                return productPageSize; 
            }
            set { productPageSize = value; }
        }

        /// <summary>
        /// �̻�ҳÿҳ����
        /// </summary>
        public int InfoPageSize
        {
            get 
            {
                if (infoPageSize <= 0) return 1;

                return infoPageSize; 
            }
            set { infoPageSize = value; }
        }

        /// <summary>
        /// ��ҵ����չʾÿҳ����
        /// </summary>
        public int NewsPageSize
        {
            get 
            {
                if (newsPageSize <= 0) return 1;
                return newsPageSize; 
            }
            set { newsPageSize = value; }
        }

        /// <summary>
        /// Ʒ��չʾÿҳ����
        /// </summary>
        public int BrandPageSize
        {
            get 
            {
                if (brandPageSize <= 0) return 1;
                return brandPageSize; 
            }
            set { brandPageSize = value; }
        }

        /// <summary>
        /// ��Ƹÿҳչʾ����
        /// </summary>
        public int JobPageSize
        {
            get 
            {
                if (jobPageSize <= 0) return 1;
                return jobPageSize; 
            }
            set { jobPageSize = value; }
        }
    }
}
