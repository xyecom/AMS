using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XYECOM.Configuration
{
    /// <summary>
    /// Cache.config 文件处理类
    /// </summary>
    public class Cache:BaseConfig
    {
        private static Cache instance = null;

        private int timeSpan;
      
        private Cache(){}

        /// <summary>
        /// 获取单态实例
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
        /// 初始化
        /// </summary>
        protected override void Init()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/cache.config"));
            timeSpan = XYECOM.Core.MyConvert.GetInt32(GetNodeValue(docXml, "timespan"));
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns>true:更新成功,false:更新失败</returns>
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
        /// 缓存时间
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
