using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XYECOM.Core.XML
{
    public class XMLUtil
    {
        private XMLUtil()
        {
        }

        public static XmlNode AppendElement(XmlNode node, string newElementName)
        {
            return AppendElement(node, newElementName, null);
        }

        public static XmlNode AppendElement(XmlNode node, string newElementName, string innerValue)
        {
            XmlNode node2;
            if (node is XmlDocument)
            {
                node2 = node.AppendChild(((XmlDocument) node).CreateElement(newElementName));
            }
            else
            {
                node2 = node.AppendChild(node.OwnerDocument.CreateElement(newElementName));
            }
            if (innerValue != null)
            {
                node2.AppendChild(node.OwnerDocument.CreateTextNode(innerValue));
            }
            return node2;
        }

        public static XmlAttribute CreateAttribute(XmlDocument xmlDocument, string name, string value)
        {
            XmlAttribute attribute = xmlDocument.CreateAttribute(name);
            attribute.Value = value;
            return attribute;
        }

        public static void SetAttribute(XmlNode node, string attributeName, string attributeValue)
        {
            if (node.Attributes[attributeName] != null)
            {
                node.Attributes[attributeName].Value = attributeValue;
            }
            else
            {
                node.Attributes.Append(CreateAttribute(node.OwnerDocument, attributeName, attributeValue));
            }
        }

        #region 通用方法
        public static string GetNodeValue(XmlDocument xml, string nodeName)
        {
            XmlNodeList list = xml.GetElementsByTagName(nodeName);
            if (list.Count > 0)
                return list[0].InnerText.Trim();
            else
                return "";
        }

        public static string GetNodeValue(XmlElement xml, string nodeName)
        {
            XmlNodeList list = xml.GetElementsByTagName(nodeName);
            if (list.Count > 0)
                return list[0].InnerText.Trim();
            else
                return "";
        }


        public static void SetNodeValue(XmlDocument xml, string nodeName, string value)
        {
            XmlNodeList list = xml.GetElementsByTagName(nodeName);
            if (list.Count > 0)
                list[0].InnerText = value;
        }

        public static void SetNodeValue(XmlElement xml, string nodeName, string value)
        {
            XmlNodeList list = xml.GetElementsByTagName(nodeName);
            if (list.Count > 0)
                list[0].InnerText = value;
        }

        public static void SetNodeValue(XmlDocument xml, string nodeName, int value)
        {
            XmlNodeList list = xml.GetElementsByTagName(nodeName);
            if (list.Count > 0)
                list[0].InnerText = value.ToString();
        }

        public static void SetNodeValue(XmlDocument xml, string nodeName, float value)
        {
            XmlNodeList list = xml.GetElementsByTagName(nodeName);
            if (list.Count > 0)
                list[0].InnerText = value.ToString();
        }

        public static void SetNodeValue(XmlDocument xml, string nodeName, bool value)
        {
            XmlNodeList list = xml.GetElementsByTagName(nodeName);
            if (list.Count > 0)
                list[0].InnerText = value.ToString();
        }

        public static void SetNodeValue(XmlDocument xml, string nodeName, decimal value)
        {
            XmlNodeList list = xml.GetElementsByTagName(nodeName);
            if (list.Count > 0)
                list[0].InnerText = value.ToString();
        }
        #endregion
    }
}
