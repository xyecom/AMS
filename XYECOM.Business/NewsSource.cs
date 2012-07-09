using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Xml;

namespace XYECOM.Business
{
    /// <summary>
    /// 新闻源保存业务类
    /// </summary>
    public class NewsSource
    {
        XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;

        static readonly string SYS_NOIMAGE_PATH = "/Common/Images/DefaultImg.gif";

        private static readonly XYECOM.SQLServer.NewsSource DAL = new XYECOM.SQLServer.NewsSource();
        static XmlDocument fileListDoc = null;
        static string fileListPath = "";
        static NewsSource() 
        {
            if (fileListDoc == null) 
            {
                fileListDoc = new XmlDocument();
            }
            fileListPath = System.Web.HttpContext.Current.Server.MapPath(XYECOM.Model.NewsSourceInfo.FilePath);
            if (!File.Exists(fileListPath))
            {
                fileListDoc.AppendChild(fileListDoc.CreateElement("FileList"));
            }
            else 
            {
                fileListDoc.Load(fileListPath);
            }
        }

        /// <summary>
        /// 往现有的XmlDocument对象中添加一条新闻
        /// </summary>
        /// <param name="doc">文档对象</param>
        /// <param name="source">新闻实体</param>
        private void AppendNews(XmlDocument doc, XYECOM.Model.NewsSourceInfo source) 
        {
            XmlElement root = doc.DocumentElement;

            XmlElement item = doc.CreateElement("item");
            XmlElement link = doc.CreateElement("link");
            link.InnerText = GetNewsUrl(source);
            item.AppendChild(link);
            XmlElement title = doc.CreateElement("title");
            title.InnerText = source.Title;
            item.AppendChild(title);
            XmlElement text = doc.CreateElement("text");
            XmlCDataSection content = doc.CreateCDataSection(XYECOM.Business.FiltrateKeyWord.LeachKeyWord(XYECOM.Core.Utils.RemoveHTML(source.Content)).Replace("&nbsp;", "").Replace("&ldquo;", "").Replace("&rdquo;", "").Replace("&hellip;", "").Replace("&mdash;", "").Replace("&rsquo;", "").Replace("&lsquo;", "").Replace("&shy;", ""));
            text.AppendChild(content);
            item.AppendChild(text);

            AppendImageElements(doc, item, source);
            
            XmlElement category = doc.CreateElement("category");
            category.InnerText = source.CategoryName;
            item.AppendChild(category);
            XmlElement pubDate = doc.CreateElement("pubDate");
            pubDate.InnerText = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            item.AppendChild(pubDate);

            root.AppendChild(item);

        }

        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="doc">文档对象</param>
        /// <param name="item">新闻实体对应的元素</param>
        /// <param name="news">新闻实体对象</param>
        private void AppendImageElements(XmlDocument doc,XmlElement item, XYECOM.Model.NewsSourceInfo news)
        {
            string imagepath = "{NS:XY_PicPath}";
            if (news.IsHasImage != 0)
            {
                string imgUrl = Business.Attachment.GetInfoDefaultImgHref(XYECOM.Model.AttachmentItem.News, news.NewsId);

                imagepath = imagepath.Replace("{NS:XY_PicPath}", imgUrl);
            }
            else
            {
                imagepath = imagepath.Replace("{NS:XY_PicPath}", webInfo.WebDomain + SYS_NOIMAGE_PATH);
            }


            XmlElement image = doc.CreateElement("image");
            image.InnerText = imagepath;
            item.AppendChild(image);
        }

        /// <summary>
        /// 根据条件获取数据
        /// </summary>
        /// <param name="count">返回最大条数</param>
        /// <param name="newstypeId">栏目编号</param>
        /// <param name="today">是否只包含今天</param>
        /// <returns>符合条件的所有实体</returns>
        private IList<XYECOM.Model.NewsSourceInfo> GetList(int count, string newstypeId, bool today)
        {
            return DAL.GetList(count, newstypeId, today);
        }

        /// <summary>
        /// 获取该新闻实体的链接地址
        /// </summary>
        /// <param name="news">新闻实体</param>
        /// <returns>链接地址</returns>
        private string GetNewsUrl(XYECOM.Model.NewsSourceInfo news)
        {
            string allDomainName = "";
            string url = "";

            string subChannelFolder = news.TempletFolderAddress;

            if (!subChannelFolder.Equals(""))
            {
                subChannelFolder = subChannelFolder + "/";
            }

            if (news.DomainName != "")
            {
                allDomainName = webInfo.GetSubDomain(news.DomainName);
            }

            if ((int)news.Type == 3)
            {
                if (news.HeadlineNewsUrl != "")
                {
                    url = news.HeadlineNewsUrl;
                }
                else
                {
                    if (webInfo.IsBogusStatic)
                    {
                        if (webInfo.IsNewsDomain && news.DomainName != "")
                        {
                            url = allDomainName + "content-" + news.NewsId + "." + webInfo.WebSuffix;
                        }
                        else
                        {
                            url = webInfo.WebDomain + "news/" + subChannelFolder + "content-" + news.NewsId + "." + webInfo.WebSuffix;
                        }
                    }
                    else
                    {
                        if (webInfo.IsNewsDomain && news.DomainName != "")
                        {
                            url = allDomainName + "content." + webInfo.WebSuffix + "?ns_id=" + news.NewsId;
                        }
                        else
                        {
                            url = webInfo.WebDomain + "news/" + subChannelFolder + "content." + webInfo.WebSuffix + "?ns_id=" + news.NewsId;
                        }
                    }

                }
            }
            else
            {
                if (news.HTMLPage != "")
                {
                    url = webInfo.WebDomain + news.HTMLPage;
                }
                else
                {
                    if (webInfo.IsBogusStatic)
                    {
                        if (webInfo.IsNewsDomain && news.DomainName != "")
                        {
                            url = allDomainName + "content-" + news.NewsId + "." + webInfo.WebSuffix;
                        }
                        else
                        {
                            url = webInfo.WebDomain + "news/" + subChannelFolder + "content-" + news.NewsId + "." + webInfo.WebSuffix;
                        }
                    }
                    else
                    {
                        if (webInfo.IsNewsDomain && news.DomainName != "")
                        {
                            url = allDomainName + "content." + webInfo.WebSuffix + "?ns_id=" + news.NewsId;
                        }
                        else
                        {
                            url = webInfo.WebDomain + "news/" + subChannelFolder + "content." + webInfo.WebSuffix + "?ns_id=" + news.NewsId;
                        }
                    }
                }
            }

            return url;
        }

        /// <summary>
        /// 生成新闻源XML文件
        /// </summary>
        /// <param name="info">实体</param>        
        public int GeneralNewsSourceXML(Model.NewsFileProperty info)
        {
            string fullPath = System.Web.HttpContext.Current.Server.MapPath(info.VirtualPath);

            try
            {
                XmlDocument doc = new XmlDocument();

                AppendRootAndDeclare(doc, info.UpdatePeri, info.WebMaster, info.DomainName);

                IList<XYECOM.Model.NewsSourceInfo> list = GetList((info.Count > 100 ? 100 : info.Count), info.NewsTypeId, info.OnlyToday == "1" ? true : false);
                foreach (XYECOM.Model.NewsSourceInfo news in list)
                {
                    AppendNews(doc, news);
                }

                //判断目录是否存在，根据输入创建对应目录。
                FileInfo fileinfo = new FileInfo(fullPath);

                if (!fileinfo.Directory.Exists) 
                {
                    fileinfo.Directory.Create();
                }
                //更新XMl文件内容
                doc.Save(fullPath);
                //生成XML文件属性文件
                GeneralXmlProperties(fullPath, info);
                
                //如果不存在该节点，则保存至FileList.xml
                if (!FileListExistsPhysicalPath(fullPath) && File.Exists(fullPath))
                {
                    Save(fullPath, info.VirtualPath);
                }
                
                return 1;
            }
            catch (Exception ex)
            {   
                //错误
                return 0;
            }       
        }
   
        /// <summary>
        /// 生成新闻源属性文件
        /// </summary>
        /// <param name="info">新闻源属性</param>
        private void GeneralXmlProperties(string fullPath, Model.NewsFileProperty info)
        {
            FileInfo fileInfo = new FileInfo(fullPath);
            if (fileInfo.Exists)
            {
                XmlDocument doc = new XmlDocument();
                XmlElement root = doc.CreateElement("root");

                XmlAttribute attr = null;

                attr = doc.CreateAttribute("OnlyToday");
                attr.Value = info.OnlyToday;
                root.Attributes.Append(attr);

                attr = doc.CreateAttribute("NewsTypeId");
                attr.Value = info.NewsTypeId;
                root.Attributes.Append(attr);

                attr = doc.CreateAttribute("Count");
                attr.Value = info.Count.ToString();
                root.Attributes.Append(attr);

                attr = doc.CreateAttribute("WebMaster");
                attr.Value = info.WebMaster;
                root.Attributes.Append(attr);

                attr = doc.CreateAttribute("UpdatePeri");
                attr.Value = info.UpdatePeri;
                root.Attributes.Append(attr);

                attr = doc.CreateAttribute("DomainName");
                attr.Value = info.DomainName;
                root.Attributes.Append(attr);


                attr = doc.CreateAttribute("VirtualPath");
                attr.Value = info.VirtualPath;
                root.Attributes.Append(attr);


                doc.AppendChild(root);

                string newPath = fileInfo.FullName.Replace(fileInfo.Extension, ".properties");

                doc.Save(newPath);
            }
        }

        /// <summary>
        /// 保存虚拟路径和物理路径
        /// </summary>
        /// <param name="physical">物理路径</param>
        /// <param name="vpath">虚拟路径</param>
        private void Save(string physical, string vpath)
        {   
            XmlElement root = null;

            root = fileListDoc.DocumentElement;

            FileInfo fileInfo = new FileInfo(physical);

            string newPath = fileInfo.FullName.Replace(fileInfo.Extension, ".properties");

            XmlElement file = fileListDoc.CreateElement("File");
            root.AppendChild(file);

            XmlElement physicalPath = fileListDoc.CreateElement("PhysicalPath");
            physicalPath.InnerText = physical;
            XmlElement virtualPath = fileListDoc.CreateElement("VirtualPath");
            virtualPath.InnerText = vpath;
            XmlElement propertiesPath = fileListDoc.CreateElement("PropertiesPath");
            propertiesPath.InnerText = newPath;

            file.AppendChild(physicalPath);
            file.AppendChild(virtualPath);
            file.AppendChild(propertiesPath);

            fileListDoc.Save(fileListPath);

        }

        /// <summary>
        /// 添加根节点和文档声明部分
        /// </summary>
        /// <param name="doc">文档对象</param>
        /// <param name="peri">更新周期</param>
        /// <param name="webemail">网站管理员Email</param>
        /// <param name="domainName">网站域名信息</param>
        private void AppendRootAndDeclare(XmlDocument doc, string peri, string webemail, string domainName)
        {
            XmlDeclaration declartion = doc.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);
            doc.AppendChild(declartion);
            XmlElement document = doc.CreateElement("document");
            doc.AppendChild(document);
            
            XmlElement webSite = doc.CreateElement("webSite");
            webSite.InnerText = string.IsNullOrEmpty(domainName) ? webInfo.WebDomain : domainName;
            document.AppendChild(webSite);
            XmlElement webMaster = doc.CreateElement("webMaster");
            webMaster.InnerText = webemail;
            document.AppendChild(webMaster);
            XmlElement updatePeri = doc.CreateElement("updatePeri");
            updatePeri.InnerText = string.IsNullOrEmpty(peri) ? "15" : peri;
            document.AppendChild(updatePeri);
        
        }

        /// <summary>
        /// 判断FileList文件中是否包含/File/PhysicalPath节点值为physicalPath的节点
        /// </summary>
        /// <param name="physicalPath">物理路径</param>
        /// <returns>存在true.不存在false</returns>
        protected bool FileListExistsPhysicalPath(string physicalPath) 
        {
            XmlElement root = fileListDoc.DocumentElement;
            return root.SelectSingleNode("//File[PhysicalPath=\"" + physicalPath + "\"]") == null ? false : true;
        }

        /// <summary>
        /// 根据物理路径删除单个新闻源文件
        /// </summary>
        /// <param name="physicalPath">物理路径</param>
        public void DeleteFile(string physicalPath)
        {
            XmlElement root = fileListDoc.DocumentElement;
            XmlNode node = root.SelectSingleNode("//File[PhysicalPath=\"" + physicalPath + "\"]");

            if (node != null)
            {
                root.RemoveChild(node);
                fileListDoc.Save(fileListPath);
            }

            FileInfo fileInfo = new FileInfo(physicalPath);

            if (fileInfo.Exists)
            {
                string propertiesPath = fileInfo.FullName.Replace(fileInfo.Extension, ".properties");
                fileInfo.Delete();

                fileInfo = new FileInfo(propertiesPath);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
            }
        }

        /// <summary>
        /// 更新新闻源XML文件
        /// </summary>
        public void AutoUpdateXml()
        {
            XmlNodeList nodelist = fileListDoc.DocumentElement.SelectNodes("//File");
            foreach (XmlNode node in nodelist)
            {
                FileInfo fileInfo = new FileInfo(node["PhysicalPath"].InnerText);
                if (fileInfo.Exists)
                {
                    string[] files = { node["PhysicalPath"].InnerText, node["PropertiesPath"].InnerText };
                    UpdateNewsXml(files);
                }
            }
        }

        /// <summary>
        /// 更新单个新闻源
        /// </summary>
        /// <param name="files">物理文件路径，0为物理路径，1为属性文件</param>
        public bool UpdateNewsXml(string[] files)
        {
            if (files.Length == 2)
            {
                Model.NewsFileProperty info = AnalyzePropertyFile(files[1]);
                if (info != null)
                {
                    GeneralNewsSourceXML(info);

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 根据新闻源属性文件，解析出对应的类
        /// </summary>
        /// <param name="propertyFilePath"></param>
        /// <returns></returns>
        public Model.NewsFileProperty AnalyzePropertyFile(string propertyFilePath) 
        {
            FileInfo fileinfo = new FileInfo(propertyFilePath);
            Model.NewsFileProperty info = null;
            if (fileinfo.Exists)
            {
                info = new XYECOM.Model.NewsFileProperty();

                XmlDocument doc = new XmlDocument();
                doc.Load(propertyFilePath);

                XmlElement root = doc.DocumentElement;

                info.Count = XYECOM.Core.MyConvert.GetInt32(root.Attributes["Count"].Value);
                info.DomainName = root.Attributes["DomainName"].Value;
                info.NewsTypeId = root.Attributes["NewsTypeId"].Value;
                info.OnlyToday = root.Attributes["OnlyToday"].Value;
                info.UpdatePeri = root.Attributes["UpdatePeri"].Value;
                info.VirtualPath = root.Attributes["VirtualPath"].Value;
                info.WebMaster = root.Attributes["WebMaster"].Value;                
            }
            return info;
        }

        /// <summary>
        /// 获取新闻源文件列表
        /// </summary>
        /// <returns>新闻源文件集合</returns>
        public IList<XYECOM.Model.NewsFile> GetList() 
        {
            IList<XYECOM.Model.NewsFile> list = new List<XYECOM.Model.NewsFile>();

            if (File.Exists(fileListPath))
            {
                XmlElement root =fileListDoc.DocumentElement;

                XmlNodeList nodeList = root.SelectNodes("//File");

                foreach (XmlNode node in nodeList)
                {
                    list.Add(new XYECOM.Model.NewsFile(node.ChildNodes[0].InnerText, node.ChildNodes[1].InnerText, node.ChildNodes[2].InnerText));
                }
            }
            return list;
        }
    }
}
