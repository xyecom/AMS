using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ��վ������Ϣʵ����
    /// </summary>
    public class UserAnnounceInfo
    {
        private int _AnnounceID;

        private string _Centent;
        
        private long _UserID;

        /// <summary>
        /// �û�ID
        /// </summary>
        public long UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        /// <summary>
        /// ��վ����ID
        /// </summary>
        public int AnnounceID
        {
            get { return _AnnounceID; }
            set { _AnnounceID = value; }
        }
       
        /// <summary>
        /// ��վ��������
        /// </summary>
        public string Centent
        {
            get { return _Centent; }
            set { _Centent = value; }
        }
    }
}
