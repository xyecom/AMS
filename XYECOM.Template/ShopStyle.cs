using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Web;

namespace XYECOM.Template
{
    /// <summary>
    /// ϵ������ģ����ʽ������
    /// </summary>
    public class ShopStyle
    {
        /// <summary>
        /// ��ȡָ��ģ����Ϣ
        /// </summary>
        /// <param name="styleFileFullName">��������ļ�style.xml ��Ŀ¼����</param>
        /// <returns></returns>
        public static XYECOM.Template.ShopStyleInfo GetItem(string styleFileDirName)
        {
            XYECOM.Template.ShopStyleInfo info = null;

            XmlDocument docXml = new XmlDocument();

            string fullName = System.Web.HttpContext.Current.Server.MapPath("/templates/_shop/" + styleFileDirName + "/style.xml");

            if (!File.Exists(fullName)) return info;

            try
            {
                docXml.Load(fullName);

                //IM ��ض�ȡ
                XmlNodeList nodeList = docXml.GetElementsByTagName("style");

                info = new ShopStyleInfo();
                info.DirName = styleFileDirName;
                info.Name = nodeList[0].Attributes["name"].Value;
                info.AccessStr = nodeList[0].Attributes["access"].Value;
                info.User = nodeList[0].Attributes["user"].Value;
            }
            catch { }

            return info;
        }

        /// <summary>
        /// ���������Ϣ
        /// </summary>
        /// <param name="name">����</param>
        /// <param name="info">�����Ϣ</param>
        /// <returns></returns>
        public static bool Update(string name, ShopTemplateInfo info)
        {
            if (!File.Exists(HttpContext.Current.Server.MapPath("/templates/_shop/" + name + "/style.xml")))
            {
                return false;
            }

            XmlDocument document = new XmlDocument();
            document.Load(HttpContext.Current.Server.MapPath("/templates/_shop/" + name + "/style.xml"));

            XmlElement element = document.GetElementsByTagName("style")[0] as XmlElement;
            element.SetAttribute("access", info.AccessStr);
            element.SetAttribute("user", info.User);

            try
            {
                document.Save(System.Web.HttpContext.Current.Server.MapPath("/templates/_shop/" + name + "/style.xml"));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
