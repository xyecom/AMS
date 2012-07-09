using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XYECOM.Configuration
{
    /// <summary>
    /// 静态页面相关配置（html.config）
    /// </summary>
    public class HTML : BaseConfig
    {
        private static HTML instance = null;

        private HTMLSaveMode __HTMLSaveMode;

        /// <summary>
        /// 存放模式
        /// </summary>
        public HTMLSaveMode _HTMLSaveMode
        {
            get { return __HTMLSaveMode; }
            set { __HTMLSaveMode = value; }
        }

        private string baseDirName;
        /// <summary>
        /// 统一存放基础目录名称
        /// </summary>
        public string BaseDirName
        {
            get { return baseDirName; }
            set { baseDirName = value; }
        }

        private string path;
        /// <summary>
        /// 路径格式
        /// </summary>
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        private string fileName;
        /// <summary>
        /// 文件名称格式
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        private HTML()
        {
        }

        /// <summary>
        /// 获取单态实例
        /// </summary>
        public static HTML Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        instance = new HTML();
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
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/HTML.config"));
            __HTMLSaveMode = GetNodeValue(docXml, "SaveMode").ToLower().Equals("default")?HTMLSaveMode.Default: HTMLSaveMode.Unify;
            baseDirName = GetNodeValue(docXml, "BaseDirName");
            path = GetNodeValue(docXml, "Path");
            fileName = GetNodeValue(docXml, "FileName");
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns>true:更新成功,false:更新失败</returns>
        public override bool Update()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/HTML.config"));
            SetNodeValue(docXml, "SaveMode", __HTMLSaveMode == HTMLSaveMode.Default?"default":"unify");
            SetNodeValue(docXml, "BaseDirName", baseDirName);
            SetNodeValue(docXml, "Path",path);
            SetNodeValue(docXml, "FileName", fileName);

            try
            {
                docXml.Save(System.Web.HttpContext.Current.Server.MapPath("/Config/HTML.config"));
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                instance = new HTML();
            }
        }
    }

    /// <summary>
    /// 静态页面存放模式枚举
    /// </summary>
    public enum HTMLSaveMode
    {
        /// <summary>
        /// 默认模式(将静态页面按模块存放到各文件夹下)
        /// </summary>
        Default,
        /// <summary>
        /// 统一存放模式(将静态页面统一存放，按模块名称分文件夹存放)
        /// </summary>
        Unify
    }
}
