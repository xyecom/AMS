using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using XYECOM.Core.XML;

namespace XYECOM.Configuration
{
    /// <summary>
    /// seo.config �ļ�������
    /// </summary>
    public class SEO:BaseConfig
    {
        private bool isAppendWebName;

        private static SEO instance = null;

        private List<SEOInfo> indexPageSEO = new List<SEOInfo>();
        private List<SEOInfo> listPageSEO = new List<SEOInfo>();
        private List<SEOInfo> infoPageSEO = new List<SEOInfo>();

        private SEO()
        {
        }

        /// <summary>
        /// ��ȡ��̬ʵ��
        /// </summary>
        public static SEO Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        instance = new SEO();
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
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/seo.config"));

            isAppendWebName = XYECOM.Core.MyConvert.GetBoolean(GetNodeValue(docXml, "appendWebName"));

            //IM ��ض�ȡ
            XmlElement ele = (XmlElement)docXml.GetElementsByTagName("indexpage")[0];
            
            SEOInfo info = null;

            XmlNodeList list = ele.GetElementsByTagName("page");

            for (int i = 0; i < list.Count; i++)
            {
                info = new SEOInfo();
                info.ModuleName = list[i].Attributes["modulename"].Value;
                info.Title = list[i].Attributes["title"].Value;
                info.Description = list[i].Attributes["description"].Value;
                info.Keywords = list[i].Attributes["keywords"].Value;
                info.IsRobots = XYECOM.Core.MyConvert.GetBoolean(list[i].Attributes["isrobots"].Value);

                indexPageSEO.Add(info);
            }

            ele = (XmlElement)docXml.GetElementsByTagName("listpage")[0];
            list = ele.GetElementsByTagName("page");

            for (int i = 0; i < list.Count; i++)
            {
                info = new SEOInfo();

                info.ModuleName = list[i].Attributes["modulename"].Value;
                info.Title = list[i].Attributes["title"].Value;
                info.Description = list[i].Attributes["description"].Value;
                info.Keywords = list[i].Attributes["keywords"].Value;
                info.IsMatch = XYECOM.Core.MyConvert.GetBoolean(list[i].Attributes["ismatch"].Value);

                listPageSEO.Add(info);
            }

            ele = (XmlElement)docXml.GetElementsByTagName("infopage")[0];
            list = ele.GetElementsByTagName("page");

            for (int i = 0; i < list.Count; i++)
            {
                info = new SEOInfo();

                info.ModuleName = list[i].Attributes["modulename"].Value;
                info.Title = list[i].Attributes["title"].Value;
                info.Description = list[i].Attributes["description"].Value;
                info.Keywords = list[i].Attributes["keywords"].Value;
                info.IsMatch = XYECOM.Core.MyConvert.GetBoolean(list[i].Attributes["ismatch"].Value);

                infoPageSEO.Add(info);
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <returns>true:���³ɹ�,false:����ʧ��</returns>
        public override bool Update()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/seo.config"));

            SetNodeValue(docXml, "appendWebName", IsAppendWebName);

            XmlElement ele = (XmlElement)docXml.GetElementsByTagName("indexpage")[0];
            ele.RemoveAll();
            XmlNode page = null;

            foreach(SEOInfo info in indexPageSEO)
            {
                page = XMLUtil.AppendElement(ele, "page");
                XMLUtil.SetAttribute(page, "modulename", info.ModuleName);
                XMLUtil.SetAttribute(page, "title", info.Title);
                XMLUtil.SetAttribute(page, "description", info.Description);
                XMLUtil.SetAttribute(page, "keywords", info.Keywords);
                XMLUtil.SetAttribute(page, "isrobots", info.IsRobots.ToString());
            }

            ele = (XmlElement)docXml.GetElementsByTagName("listpage")[0];
            ele.RemoveAll();

            foreach (SEOInfo info in listPageSEO)
            {
                page = XMLUtil.AppendElement(ele, "page");
                XMLUtil.SetAttribute(page, "modulename", info.ModuleName);
                XMLUtil.SetAttribute(page, "title", info.Title);
                XMLUtil.SetAttribute(page, "description", info.Description);
                XMLUtil.SetAttribute(page, "keywords", info.Keywords);
                XMLUtil.SetAttribute(page, "ismatch", info.IsMatch.ToString());
            }

            ele = (XmlElement)docXml.GetElementsByTagName("infopage")[0];
            ele.RemoveAll();

            foreach (SEOInfo info in infoPageSEO)
            {
                page = XMLUtil.AppendElement(ele, "page");
                XMLUtil.SetAttribute(page, "modulename", info.ModuleName);
                XMLUtil.SetAttribute(page, "title", info.Title);
                XMLUtil.SetAttribute(page, "description", info.Description);
                XMLUtil.SetAttribute(page, "keywords", info.Keywords);
                XMLUtil.SetAttribute(page, "ismatch", info.IsMatch.ToString());
            }

            try
            {
                docXml.Save(System.Web.HttpContext.Current.Server.MapPath("/Config/seo.config"));
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                instance = new SEO();
            }
        }

        /// <summary>
        /// �Ƿ��ڸ���֮��׷����վ����
        /// </summary>
        public bool IsAppendWebName
        {
            get { return isAppendWebName; }
            set { isAppendWebName = value; }
        }

        /// <summary>
        /// ��ҳ���ü���
        /// </summary>
        public List<SEOInfo> IndexPageSEO
        {
            get { return indexPageSEO; }
            set { indexPageSEO = value; }
        }

        /// <summary>
        /// �б�ҳ���ü���
        /// </summary>
        public List<SEOInfo> ListPageSEO
        {
            get { return listPageSEO; }
            set { listPageSEO = value; }
        }

        /// <summary>
        /// ��Ϣҳ�����ü���
        /// </summary>
        public List<SEOInfo> InfoPageSEO
        {
            get { return infoPageSEO; }
            set { infoPageSEO = value; }
        }

        /// <summary>
        /// ��ȡ��ҳseo��Ϣ
        /// </summary>
        /// <param name="moduleName"></param>
        /// <returns></returns>
        public SEOInfo GetIndexPageSEO(string moduleName)
        {
            foreach (SEOInfo info in indexPageSEO)
            {
                if (info.ModuleName.Equals(moduleName)) return info;
            }
            return null;
        }

        /// <summary>
        /// ��ȡ�б�ҳseo��Ϣ
        /// </summary>
        /// <param name="moduleName"></param>
        /// <returns></returns>
        public SEOInfo GetListPageSEO(string moduleName)
        {
            foreach (SEOInfo info in listPageSEO)
            {
                if (info.ModuleName.Equals(moduleName)) return info;
            }
            return null;
        }

        /// <summary>
        /// ��ȡ��Ϣҳseo��Ϣ
        /// </summary>
        /// <param name="moduleName"></param>
        /// <returns></returns>
        public SEOInfo GetInfoPageSEO(string moduleName)
        {
            foreach (SEOInfo info in infoPageSEO)
            {
                if (info.ModuleName.Equals(moduleName)) return info;
            }
            return null;
        }
    }
}
