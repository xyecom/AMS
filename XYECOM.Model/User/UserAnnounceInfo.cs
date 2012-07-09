using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 网站公告信息实体类
    /// </summary>
    public class UserAnnounceInfo
    {
        private int _AnnounceID;

        private string _Centent;
        
        private long _UserID;

        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        /// <summary>
        /// 网站公告ID
        /// </summary>
        public int AnnounceID
        {
            get { return _AnnounceID; }
            set { _AnnounceID = value; }
        }
       
        /// <summary>
        /// 网站公告内容
        /// </summary>
        public string Centent
        {
            get { return _Centent; }
            set { _Centent = value; }
        }
    }
}
