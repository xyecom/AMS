using System;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

namespace XYECOM.Plugin.DZ
{
    public enum DNTDBType
    { 
        SQLServer,
        Access
    }

    /// <summary>
    /// BBS.config 配置文件处理类
    /// </summary>
    public class Config:XYECOM.Configuration.BaseConfig
    {
        private static Config instance = null;

        private string _BBSVersion = string.Empty;
        private bool _IsEnabled;
        private string _CookieDomain = string.Empty;
        private string _PasswordKey = string.Empty;
        private string _BBSURL = string.Empty;
        private DNTDBType _DBType = DNTDBType.SQLServer;
        private string _ConnString = string.Empty;
        private string _DNTTablePrefix = string.Empty;

        private string _DBDefaultDateTime = string.Empty;

        private Config()
        {
        }

        public static Config Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        instance = new Config();
                    }
                }

                return instance;
            }
        }

        protected override void Init()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/BBS.config"));
            _BBSVersion = GetNodeValue(docXml, "BBSVersion");
            _IsEnabled = Convert.ToBoolean(GetNodeValue(docXml, "Enabled"));
            _CookieDomain = GetNodeValue(docXml, "CookieDomain");
            _PasswordKey = GetNodeValue(docXml, "PasswordKey");

            _BBSURL = GetNodeValue(docXml, "BBSURL");
            _DBType = GetNodeValue(docXml, "DBType").ToLower().Equals("sqlserver")? DNTDBType.SQLServer: DNTDBType.Access;
            _ConnString = GetNodeValue(docXml, "ConnectionString");
            _DNTTablePrefix = GetNodeValue(docXml, "DNTTablePrefix");
        }

        public override bool Update()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/BBS.config"));
            SetNodeValue(docXml, "BBSVersion", _BBSVersion);
            SetNodeValue(docXml, "Enabled", _IsEnabled.ToString());
            SetNodeValue(docXml, "CookieDomain", _CookieDomain);
            SetNodeValue(docXml, "PasswordKey", _PasswordKey);
            SetNodeValue(docXml, "BBSURL", _BBSURL);
            SetNodeValue(docXml, "DBType", _DBType == DNTDBType.SQLServer?"SQLServer":"Access");
            SetNodeValue(docXml, "ConnectionString", _ConnString);
            SetNodeValue(docXml, "DNTTablePrefix", _DNTTablePrefix);

            try
            {
                docXml.Save(System.Web.HttpContext.Current.Server.MapPath("/Config/BBS.config"));
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                instance = new Config();
            }
        }

        public string BBSVersion
        {
            get { return _BBSVersion; }
            set { _BBSVersion = value; }
        }

        public bool IsEnabled
        {
            get { return _IsEnabled; }
            set { _IsEnabled = value; }
        }

        public string CookieDomain
        {
            get { return _CookieDomain; }
            set { _CookieDomain = value; }
        }

        public string PasswordKey
        {
            get { return _PasswordKey; }
            set { _PasswordKey = value; }
        }

        public string BBSURL
        {
            get { return _BBSURL; }
            set { _BBSURL = value; }
        }

        public DNTDBType DBType
        {
            get { return _DBType; }
            set { _DBType = value; }
        }

        public string ConnString
        {
            get { return _ConnString; }
            set { _ConnString = value; }
        }

        public string DNTTablePrefix
        {
            get { return _DNTTablePrefix; }
            set { _DNTTablePrefix = value; }
        }

        public string DBDefaultDateTime
        {
            get 
            {
                if (this._DBType == DNTDBType.Access) return "Now()";
                return "GetDate()";
            }
        }
      
    }
}

