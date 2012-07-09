using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XYECOM.Configuration
{
    /// <summary>
    /// template.config 文件处理类
    /// </summary>
    public class Template : BaseConfig
    {
        private static Template instance = null;
        
        private int Id;
        private string path;

        private Template(){}

        /// <summary>
        /// 获取单态实例
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
        /// 初始化
        /// </summary>
        protected override void Init()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/Template.config"));
            Id = Convert.ToInt32(GetNodeValue(docXml, "TemplateId"));
            path = GetNodeValue(docXml, "TemplatePath");
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns>true:更新成功,false:更新失败</returns>
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
        /// 模板Id
        /// </summary>
        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }

        /// <summary>
        /// 模板路径
        /// </summary>
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
    }
}
