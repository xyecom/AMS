using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model.AMS
{
    /// <summary>
    /// 投标信息
    /// </summary>
    public class TenderInfo
    {
        /// <summary>
        /// 投标编号
        /// </summary>
        public int TenderId
        {
            get;
            set;
        }

        /// <summary>
        /// 律师编号
        /// </summary>
        public int LayerId
        {
            get;
            set;
        }

        /// <summary>
        /// 债权信息编号
        /// </summary>
        public int CreditInfoId
        {
            get;
            set;
        }

        /// <summary>
        /// 留言
        /// </summary>
        public string Message
        {
            get;
            set;
        }

        /// <summary>
        /// 投标时间
        /// </summary>
        public DateTime TenderDate
        {
            get;
            set;
        }

        /// <summary>
        /// 是否已中标
        /// </summary>
        public int IsSuccess
        {
            get;
            set;
        }
    }
}
