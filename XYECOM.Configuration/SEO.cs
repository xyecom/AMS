using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using XYECOM.Core.XML;

namespace XYECOM.Configuration
{
    /// <summary>
    /// seo.config 文件处理类
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
        /// 获取单态实例
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
        /// 初始化
        /// </summary>
        protected override void Init()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/seo.config"));

            isAppendWebName = XYECOM.Core.MyConvert.GetBoolean(GetNodeValue(docXml, "appendWebName"));

            //IM 相关读取
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
        /// 更新
        /// </summary>
        /// <returns>true:更新成功,false:更新失败</returns>
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
        /// 是否在各项之后追加网站名称
        /// </summary>
        public bool IsAppendWebName
        {
            get { return isAppendWebName; }
            set { isAppendWebName = value; }
        }

        /// <summary>
        /// 首页设置集合
        /// </summary>
        public List<SEOInfo> IndexPageSEO
        {
            get { return indexPageSEO; }
            set { indexPageSEO = value; }
        }

        /// <summary>
        /// 列表页设置集合
        /// </summary>
        public List<SEOInfo> ListPageSEO
        {
            get { return listPageSEO; }
            set { listPageSEO = value; }
        }

        /// <summary>
        /// 信息页面设置集合
        /// </summary>
        public List<SEOInfo> InfoPageSEO
        {
            get { return infoPageSEO; }
            set { infoPageSEO = value; }
        }

        /// <summary>
        /// 获取首页seo信息
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
        /// 获取列表页seo信息
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
        /// 获取信息页seo信息
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
