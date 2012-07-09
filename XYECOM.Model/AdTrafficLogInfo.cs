using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 广告访问日志信息实体类
    /// </summary>
    public class AdTrafficLogInfo
    {
        private long _logId;
        private DateTime _date;
        private long _adid;
        private string _iP;


        /// <summary>
        /// 日志ID
        /// </summary>
        public long LogId
        {
            get { return _logId; }
            set { _logId = value; }
        }
        
        /// <summary>
        /// 广告ID
        /// </summary>
        public long Adid
        {
            get { return _adid; }
            set { _adid = value; }
        }
        
        /// <summary>
        /// 来源IP
        /// </summary>
        public string IP
        {
            get { return _iP; }
            set { _iP = value; }
        }
        
        /// <summary>
        /// 点击时间
        /// </summary>
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
    }
}
