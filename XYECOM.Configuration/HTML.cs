using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XYECOM.Configuration
{
    /// <summary>
    /// ��̬ҳ��������ã�html.config��
    /// </summary>
    public class HTML : BaseConfig
    {
        private static HTML instance = null;

        private HTMLSaveMode __HTMLSaveMode;

        /// <summary>
        /// ���ģʽ
        /// </summary>
        public HTMLSaveMode _HTMLSaveMode
        {
            get { return __HTMLSaveMode; }
            set { __HTMLSaveMode = value; }
        }

        private string baseDirName;
        /// <summary>
        /// ͳһ��Ż���Ŀ¼����
        /// </summary>
        public string BaseDirName
        {
            get { return baseDirName; }
            set { baseDirName = value; }
        }

        private string path;
        /// <summary>
        /// ·����ʽ
        /// </summary>
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        private string fileName;
        /// <summary>
        /// �ļ����Ƹ�ʽ
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
        /// ��ȡ��̬ʵ��
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
        /// ��ʼ��
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
        /// ����
        /// </summary>
        /// <returns>true:���³ɹ�,false:����ʧ��</returns>
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
    /// ��̬ҳ����ģʽö��
    /// </summary>
    public enum HTMLSaveMode
    {
        /// <summary>
        /// Ĭ��ģʽ(����̬ҳ�水ģ���ŵ����ļ�����)
        /// </summary>
        Default,
        /// <summary>
        /// ͳһ���ģʽ(����̬ҳ��ͳһ��ţ���ģ�����Ʒ��ļ��д��)
        /// </summary>
        Unify
    }
}
