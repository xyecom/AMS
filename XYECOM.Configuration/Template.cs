using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XYECOM.Configuration
{
    /// <summary>
    /// template.config �ļ�������
    /// </summary>
    public class Template : BaseConfig
    {
        private static Template instance = null;
        
        private int Id;
        private string path;

        private Template(){}

        /// <summary>
        /// ��ȡ��̬ʵ��
        /// </summary>
        public static Template Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        instance = new Template();
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
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/Template.config"));
            Id = Convert.ToInt32(GetNodeValue(docXml, "TemplateId"));
            path = GetNodeValue(docXml, "TemplatePath");
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <returns>true:���³ɹ�,false:����ʧ��</returns>
        public override bool  Update()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/Template.config"));
            SetNodeValue(docXml, "TemplateId", Id);
            SetNodeValue(docXml, "TemplatePath", path);
            try
            {
                docXml.Save(System.Web.HttpContext.Current.Server.MapPath("/Config/Template.config"));
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Refresh();
            }
        }

        /// <summary>
        /// ģ��Id
        /// </summary>
        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }

        /// <summary>
        /// ģ��·��
        /// </summary>
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
    }
}
