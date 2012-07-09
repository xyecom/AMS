using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Web;
using System.IO;

namespace XYECOM.Configuration
{
    /// <summary>
    /// web.config 文件处理类
    /// </summary>
    public class WebConfig
    {
        /// <summary>
        /// 更新位扩展名
        /// </summary>
        /// <param name="suffix">伪扩展名</param>
        public static void UpdateWebConfigForSuffix(string suffix)
        {
            int num = 0;
            XmlDocument domWebConfig = new XmlDocument();
            if (File.Exists(HttpContext.Current.Server.MapPath("/web.config")))
            {
                domWebConfig.Load(HttpContext.Current.Server.MapPath("/web.config"));

                XmlNodeList xnl = domWebConfig.SelectSingleNode("configuration").ChildNodes;

                int hcount = 0;
                int bcount = 0;
                bool IsUpdate = false;
                foreach (XmlNode xn in xnl)
                {
                    if (xn.NodeType == XmlNodeType.Element)
                    {
                        XmlElement xe = (XmlElement)xn;
                        if (xe.Name == "system.web")
                        {
                            XmlNode bxn = null;
                            XmlNodeList xnl1 = xn.ChildNodes;

                            #region
                            foreach (XmlNode xn1 in xnl1)
                            {
                                if (xn1.NodeType == XmlNodeType.Element)
                                {
                                    XmlElement xe1 = (XmlElement)xn1;
                                    #region
                                    if (xe1.Name == "httpHandlers")
                                    {
                                        XmlNode xnc = xn1.FirstChild;
                                        XmlElement xlec = (XmlElement)xnc;

                                        if (xlec.Name == "add")
                                        {
                                            xlec.SetAttribute("path", "*." + suffix);
                                            IsUpdate = true;
                                        }
                                        hcount++;
                                    }
                                    #endregion
                                    #region
                                    if (xe1.Name == "compilation")
                                    {
                                        bxn = xn1;
                                        XmlNodeList xnlc1 = xn1.ChildNodes;
                                        foreach (XmlNode xnc1 in xnlc1)
                                        {
                                            XmlElement xec1 = (XmlElement)xnc1;
                                            if (xec1.Name == "buildProviders")
                                            {
                                                XmlNode xncc = xnc1.FirstChild;
                                                XmlElement xlecc = (XmlElement)xncc;

                                                if (xlecc.Name == "add")
                                                {
                                                    xlecc.SetAttribute("extension", "." + suffix);
                                                    IsUpdate = true;
                                                }

                                                bcount++;
                                            }
                                        }
                                        bcount++;
                                    }
                                    #endregion
                                }
                            }
                            #endregion
                            
                            #region
                            if (hcount == 0)
                            {
                                XmlElement nxh = domWebConfig.CreateElement("httpHandlers");

                                XmlElement nxhc = domWebConfig.CreateElement("add");
                                nxhc.SetAttribute("path", "*." + suffix);
                                nxhc.SetAttribute("verb", "*");
                                nxhc.SetAttribute("type", "System.Web.UI.PageHandlerFactory");
                                nxh.AppendChild(nxhc);
                                xn.AppendChild(nxh);
                                IsUpdate = true;
                            }
                            #endregion
                            
                            #region
                            if (bcount == 0)
                            {
                                XmlElement nxh = domWebConfig.CreateElement("compilation");

                                XmlElement nxhc = domWebConfig.CreateElement("buildProviders");

                                XmlElement nxhcc = domWebConfig.CreateElement("add");
                                nxhcc.SetAttribute("extension", "." + suffix);
                                nxhcc.SetAttribute("type", "System.Web.Compilation.PageBuildProvider");
                                nxhc.AppendChild(nxhcc);
                                nxh.AppendChild(nxhc);
                                xn.AppendChild(nxh);
                                IsUpdate = true;
                            }
                            else if (bcount == 1)
                            {

                                XmlElement nxhc = domWebConfig.CreateElement("buildProviders");

                                XmlElement nxhcc = domWebConfig.CreateElement("add");
                                nxhcc.SetAttribute("extension", "." + suffix);
                                nxhcc.SetAttribute("type", "System.Web.Compilation.PageBuildProvider");
                                nxhc.AppendChild(nxhcc);
                                bxn.AppendChild(nxhc);
                                IsUpdate = true;
                            }
                            #endregion
                        }
                    }

                    if (IsUpdate)
                    {
                        domWebConfig.Save(HttpContext.Current.Server.MapPath("/web.config"));
                        num++;
                    }
                }
            }
            if (num == 0)
                throw new Exception("修改网站配置文件失败！没有相应的节点！");
        }
    }
}
