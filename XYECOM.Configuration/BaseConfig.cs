using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace XYECOM.Configuration
{
    /// <summary>
    /// 配置文件处理抽象基类
    /// </summary>
    public abstract class BaseConfig
    {
        protected static object lockHelper = new object();

        /// <summary>
        /// 构造方法
        /// </summary>
        protected BaseConfig()
        {
            Init();
        }

        #region 抽象方法
        /// <summary>
        /// 配置信息初始化
        /// </summary>
        protected abstract void Init();

        /// <summary>
        /// 配置信息更新
        /// </summary>
        /// <returns></returns>
        public abstract bool Update();

        #endregion

        /// <summary>
        /// 配置信息刷新
        /// </summary>
        public void Refresh()
        {
            Init();
        }

        #region 错误日志记录
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="ex">异常对象</param>
        protected void WirteLog(string message, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("Error");
            log.Error(message, ex);
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="ex">异常对象</param>
        protected void WirteLog(Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("Error");
            log.Error("", ex);
        }
        #endregion 

        #region 通用方法
        /// <summary>
        /// 获取节点值
        /// </summary>
        /// <param name="xml">XmlDocument 对象</param>
        /// <param name="nodeName">节点名称</param>
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
        /// 获取节点值
        /// </summary>
        /// <param name="xml">XmlElement 对象</param>
        /// <param name="nodeName">节点名称</param>
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
        /// 设置节点值
        /// </summary>
        /// <param name="xml">XmlDocument 对象</param>
        /// <param name="nodeName">节点名称</param>
        /// <param name="value">值</param>
        protected void SetNodeValue(XmlDocument xml, string nodeName, string value)
        {
            XmlNodeList list = xml.GetElementsByTagName(nodeName);
            if (list.Count > 0)
                list[0].InnerText = value;
        }

        /// <summary>
        /// 设置节点值
        /// </summary>
        /// <param name="xml">XmlElement 对象</param>
        /// <param name="nodeName">节点名称</param>
        /// <param name="value">值</param>
        protected void SetNodeValue(XmlElement xml, string nodeName, string value)
        {
            XmlNodeList list = xml.GetElementsByTagName(nodeName);
            if (list.Count > 0)
                list[0].InnerText = value;
        }

        /// <summary>
        /// 设置节点值
        /// </summary>
        /// <param name="xml">XmlDocument 对象</param>
        /// <param name="nodeName">节点名称</param>
        /// <param name="value">值</param>
        protected void SetNodeValue(XmlDocument xml, string nodeName, int value)
        {
            XmlNodeList list = xml.GetElementsByTagName(nodeName);
            if (list.Count > 0)
                list[0].InnerText = value.ToString();
        }

        /// <summary>
        /// 设置节点值
        /// </summary>
        /// <param name="xml">XmlDocument 对象</param>
        /// <param name="nodeName">节点名称</param>
        /// <param name="value">值</param>
        protected void SetNodeValue(XmlDocument xml, string nodeName, float value)
        {
            XmlNodeList list = xml.GetElementsByTagName(nodeName);
            if (list.Count > 0)
                list[0].InnerText = value.ToString();
        }

        /// <summary>
        /// 设置节点值
        /// </summary>
        /// <param name="xml">XmlDocument 对象</param>
        /// <param name="nodeName">节点名称</param>
        /// <param name="value">值</param>
        protected void SetNodeValue(XmlDocument xml, string nodeName, bool value)
        {
            XmlNodeList list = xml.GetElementsByTagName(nodeName);
            if (list.Count > 0)
                list[0].InnerText = value.ToString();
        }

        /// <summary>
        /// 设置节点值
        /// </summary>
        /// <param name="xml">XmlDocument 对象</param>
        /// <param name="nodeName">节点名称</param>
        /// <param name="value">值</param>
        protected void SetNodeValue(XmlDocument xml, string nodeName, decimal value)
        {
            XmlNodeList list = xml.GetElementsByTagName(nodeName);
            if (list.Count > 0)
                list[0].InnerText = value.ToString();
        }
        #endregion
    }
}
