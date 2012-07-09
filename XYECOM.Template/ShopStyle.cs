using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Web;

namespace XYECOM.Template
{
    /// <summary>
    /// 系列网店模板样式处理类
    /// </summary>
    public class ShopStyle
    {
        /// <summary>
        /// 获取指定模板信息
        /// </summary>
        /// <param name="styleFileFullName">风格描述文件style.xml 的目录名称</param>
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

                //IM 相关读取
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
        /// 更新相关信息
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="info">相关信息</param>
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
