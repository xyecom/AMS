using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Xml;
using System.IO;

namespace XYECOM.Template
{
    /// <summary>
    /// ����ģ�������Ϣ������
    /// </summary>
    public class ShopAbout
    {
        /// <summary>
        /// ��ȡָ��ģ����Ϣ
        /// </summary>
        /// <param name="temppath">��վģ������</param>
        /// <param name="name">ģ������</param>
        /// <returns>ģ����Ϣ���������</returns>
        public static XYECOM.Template.ShopAboutInfo GetItem(string aboutFileFullName)
        {
            XYECOM.Template.ShopAboutInfo info = null;

            if (File.Exists(aboutFileFullName +  "/about.xml"))
            {
                XmlDocument document = new XmlDocument();
                document.Load(aboutFileFullName + "/about.xml");

                foreach (XmlNode node2 in document.SelectSingleNode("about").ChildNodes)
                {
                    XmlAttribute _Name = node2.Attributes["name"];
                    XmlAttribute _CName = node2.Attributes["cname"];
                    XmlAttribute _Access = node2.Attributes["access"];
                    XmlAttribute _User = node2.Attributes["user"];
                    XmlAttribute _Author = node2.Attributes["author"];
                    XmlAttribute _CreateDate = node2.Attributes["createdate"];
                    XmlAttribute _Version = node2.Attributes["ver"];
                    XmlAttribute _Copyright = node2.Attributes["copyright"];

                    if (_Name != null 
                        && _CName != null 
                        && _Access != null
                        && _User != null
                        && _Author != null
                        && _CreateDate != null
                        && _Version != null
                        && _Copyright != null)
                    {
                        info = new XYECOM.Template.ShopAboutInfo(
                            _Name.Value, 
                            _CName.Value, 
                            _Access.Value, 
                            _User.Value, 
                            _Author.Value, 
                            _CreateDate.Value,
                            _Version.Value, 
                            _Copyright.Value,
                             "");
                    }
                }
            }

            return info;
        }

        /// <summary>
        /// ����ģ�������Ϣ
        /// </summary>
        /// <param name="name">ģ������</param>
        /// <param name="info">����ģ����Ϣ</param>
        /// <returns></returns>
        public static bool Update(string name, ShopTemplateInfo info)
        {
            return Update(name, (ShopAboutInfo)info);
        }

        /// <summary>
        /// ����ģ�������Ϣ
        /// </summary>
        /// <param name="name">ģ������</param>
        /// <param name="ShopAboutInfo">����ģ�������Ϣ</param>
        /// <returns></returns>
        public static bool Update(string name, ShopAboutInfo info)
        {
            if (!File.Exists(HttpContext.Current.Server.MapPath("/templates/_shop/" + name + "/about.xml")))
            {
                return false;
            }

            XmlDocument document = new XmlDocument();
            document.Load(HttpContext.Current.Server.MapPath("/templates/_shop/" + name + "/about.xml"));

            XmlElement element = document.GetElementsByTagName("template")[0] as XmlElement;
            element.SetAttribute("access", info.AccessStr);
            element.SetAttribute("user",info.User);

            try
            {
                document.Save(System.Web.HttpContext.Current.Server.MapPath("/templates/_shop/" + name + "/about.xml"));
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// ��ȡ��ǰѡ��ģ����Ϣ
        /// </summary>
        /// <returns></returns>
        public XYECOM.Template.ShopAboutInfo GetUserCurTempInfo(string userTemplateName)
        {
            string curTempName = userTemplateName.Replace("|", "/");

            string webPath = "/templates/_shop/" + curTempName;

            string tempPath = System.Web.HttpContext.Current.Server.MapPath(webPath);

            XYECOM.Template.ShopAboutInfo shopAbout = XYECOM.Template.ShopAbout.GetItem(tempPath);

            if (shopAbout == null)
            {
                webPath = "/templates/_shop/default";

                tempPath = System.Web.HttpContext.Current.Server.MapPath(tempPath);

                shopAbout = XYECOM.Template.ShopAbout.GetItem(tempPath);
            }

            shopAbout.Image = webPath + "/about.gif";

            return shopAbout;
        }
    }
}
