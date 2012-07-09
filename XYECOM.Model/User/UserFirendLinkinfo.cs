using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 用户友情链接实体类
    /// </summary>
    public class UserFirendLinkinfo
    {
        private int _LinkId;        
        private string _Url;       
        private string _LogoUrl;   
        private string _SiteName;   
        private long _UserID;       

        /// <summary>
        /// 链接ID
        /// </summary>
        public int LinkId
        {
            get { return _LinkId; }
            set { _LinkId = value; }
        }
        
        /// <summary>
        /// 链接地址
        /// </summary>
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
        
        /// <summary>
        /// 网站Logo
        /// </summary>
        public string LogoUrl
        {
            get { return _LogoUrl; }
            set { _LogoUrl = value; }
        }
        
        /// <summary> 
        /// 网站名称
        /// </summary>
        public string SiteName
        {
            get { return _SiteName; }
            set { _SiteName = value; }
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
    }
}
