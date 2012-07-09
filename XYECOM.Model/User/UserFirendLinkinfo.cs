using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// �û���������ʵ����
    /// </summary>
    public class UserFirendLinkinfo
    {
        private int _LinkId;        
        private string _Url;       
        private string _LogoUrl;   
        private string _SiteName;   
        private long _UserID;       

        /// <summary>
        /// ����ID
        /// </summary>
        public int LinkId
        {
            get { return _LinkId; }
            set { _LinkId = value; }
        }
        
        /// <summary>
        /// ���ӵ�ַ
        /// </summary>
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
        
        /// <summary>
        /// ��վLogo
        /// </summary>
        public string LogoUrl
        {
            get { return _LogoUrl; }
            set { _LogoUrl = value; }
        }
        
        /// <summary> 
        /// ��վ����
        /// </summary>
        public string SiteName
        {
            get { return _SiteName; }
            set { _SiteName = value; }
        }

        /// <summary>
        /// �û�ID
        /// </summary>
        public long UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
    }
}
