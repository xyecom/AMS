using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ��������־��Ϣʵ����
    /// </summary>
    public class AdTrafficLogInfo
    {
        private long _logId;
        private DateTime _date;
        private long _adid;
        private string _iP;


        /// <summary>
        /// ��־ID
        /// </summary>
        public long LogId
        {
            get { return _logId; }
            set { _logId = value; }
        }
        
        /// <summary>
        /// ���ID
        /// </summary>
        public long Adid
        {
            get { return _adid; }
            set { _adid = value; }
        }
        
        /// <summary>
        /// ��ԴIP
        /// </summary>
        public string IP
        {
            get { return _iP; }
            set { _iP = value; }
        }
        
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
    }
}
