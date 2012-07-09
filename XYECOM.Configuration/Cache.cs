using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XYECOM.Configuration
{
    /// <summary>
    /// Cache.config �ļ�������
    /// </summary>
    public class Cache:BaseConfig
    {
        private static Cache instance = null;

        private int timeSpan;
      
        private Cache(){}

        /// <summary>
        /// ��ȡ��̬ʵ��
        /// </summary>
        public static Cache Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        instance = new Cache();
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
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/cache.config"));
            timeSpan = XYECOM.Core.MyConvert.GetInt32(GetNodeValue(docXml, "timespan"));
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <returns>true:���³ɹ�,false:����ʧ��</returns>
        public override bool Update()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/cache.config"));
            SetNodeValue(docXml, "timespan", timeSpan.ToString());

            try
            {
                docXml.Save(System.Web.HttpContext.Current.Server.MapPath("/Config/cache.config"));
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                instance = new Cache();
            }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public int TimeSpan
        {
            get 
            {
                if (timeSpan < 0) timeSpan = 0;

                return timeSpan; 
            }
            set { timeSpan = value; }
        }
    }
}
