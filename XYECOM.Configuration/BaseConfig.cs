using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace XYECOM.Configuration
{
    /// <summary>
    /// �����ļ�����������
    /// </summary>
    public abstract class BaseConfig
    {
        protected static object lockHelper = new object();

        /// <summary>
        /// ���췽��
        /// </summary>
        protected BaseConfig()
        {
            Init();
        }

        #region ���󷽷�
        /// <summary>
        /// ������Ϣ��ʼ��
        /// </summary>
        protected abstract void Init();

        /// <summary>
        /// ������Ϣ����
        /// </summary>
        /// <returns></returns>
        public abstract bool Update();

        #endregion

        /// <summary>
        /// ������Ϣˢ��
        /// </summary>
        public void Refresh()
        {
            Init();
        }

        #region ������־��¼
        /// <summary>
        /// д��־
        /// </summary>
        /// <param name="message">��Ϣ</param>
        /// <param name="ex">�쳣����</param>
        protected void WirteLog(string message, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("Error");
            log.Error(message, ex);
        }

        /// <summary>
        /// д��־
        /// </summary>
        /// <param name="ex">�쳣����</param>
        protected void WirteLog(Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("Error");
            log.Error("", ex);
        }
        #endregion 

        #region ͨ�÷���
        /// <summary>
        /// ��ȡ�ڵ�ֵ
        /// </summary>
        /// <param name="xml">XmlDocument ����</param>
        /// <param name="nodeName">�ڵ�����</param>
        /// <returns></returns>
        protected string GetNodeValue(XmlDocument xml, string nodeName)
        {
            XmlNodeList list = xml.GetElementsByTagName(nodeName);
            if (list.Count > 0)
                return list[0].InnerText.Trim();
            else
                return "";
        }

        /// <summary>
        /// ��ȡ�ڵ�ֵ
        /// </summary>
        /// <param name="xml">XmlElement ����</param>
        /// <param name="nodeName">�ڵ�����</param>
        /// <returns></returns>
        protected string GetNodeValue(XmlElement xml, string nodeName)
        {
            XmlNodeList list = xml.GetElementsByTagName(nodeName);
            if (list.Count > 0)
                return list[0].InnerText.Trim();
            else
                return "";
        }

        /// <summary>
        /// ���ýڵ�ֵ
        /// </summary>
        /// <param name="xml">XmlDocument ����</param>
        /// <param name="nodeName">�ڵ�����</param>
        /// <param name="value">ֵ</param>
        protected void SetNodeValue(XmlDocument xml, string nodeName, string value)
        {
            XmlNodeList list = xml.GetElementsByTagName(nodeName);
            if (list.Count > 0)
                list[0].InnerText = value;
        }

        /// <summary>
        /// ���ýڵ�ֵ
        /// </summary>
        /// <param name="xml">XmlElement ����</param>
        /// <param name="nodeName">�ڵ�����</param>
        /// <param name="value">ֵ</param>
        protected void SetNodeValue(XmlElement xml, string nodeName, string value)
        {
            XmlNodeList list = xml.GetElementsByTagName(nodeName);
            if (list.Count > 0)
                list[0].InnerText = value;
        }

        /// <summary>
        /// ���ýڵ�ֵ
        /// </summary>
        /// <param name="xml">XmlDocument ����</param>
        /// <param name="nodeName">�ڵ�����</param>
        /// <param name="value">ֵ</param>
        protected void SetNodeValue(XmlDocument xml, string nodeName, int value)
        {
            XmlNodeList list = xml.GetElementsByTagName(nodeName);
            if (list.Count > 0)
                list[0].InnerText = value.ToString();
        }

        /// <summary>
        /// ���ýڵ�ֵ
        /// </summary>
        /// <param name="xml">XmlDocument ����</param>
        /// <param name="nodeName">�ڵ�����</param>
        /// <param name="value">ֵ</param>
        protected void SetNodeValue(XmlDocument xml, string nodeName, float value)
        {
            XmlNodeList list = xml.GetElementsByTagName(nodeName);
            if (list.Count > 0)
                list[0].InnerText = value.ToString();
        }

        /// <summary>
        /// ���ýڵ�ֵ
        /// </summary>
        /// <param name="xml">XmlDocument ����</param>
        /// <param name="nodeName">�ڵ�����</param>
        /// <param name="value">ֵ</param>
        protected void SetNodeValue(XmlDocument xml, string nodeName, bool value)
        {
            XmlNodeList list = xml.GetElementsByTagName(nodeName);
            if (list.Count > 0)
                list[0].InnerText = value.ToString();
        }

        /// <summary>
        /// ���ýڵ�ֵ
        /// </summary>
        /// <param name="xml">XmlDocument ����</param>
        /// <param name="nodeName">�ڵ�����</param>
        /// <param name="value">ֵ</param>
        protected void SetNodeValue(XmlDocument xml, string nodeName, decimal value)
        {
            XmlNodeList list = xml.GetElementsByTagName(nodeName);
            if (list.Count > 0)
                list[0].InnerText = value.ToString();
        }
        #endregion
    }
}
