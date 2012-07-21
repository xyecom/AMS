using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model.AMS
{
    /// <summary>
    /// 抵债竞价
    /// </summary>
    public class BidInfo
    {
        /// <summary>
        /// 竞价编号
        /// </summary>
        public int BidId
        {
            get;
            set;
        }

        /// <summary>
        /// 抵债信息ID
        /// </summary>
        public int ForeclosedId
        {
            get;
            set;
        }

        /// <summary>
        /// 出价
        /// </summary>
        public decimal Price
        {
            get;
            set;
        }
        /// <summary>
        /// 出价时间
        /// </summary>
        public DateTime PriceDate
        {
            get;
            set;
        }

        /// <summary>
        /// 来自地区
        /// </summary>
        public string FromAddress
        {
            get;
            set;
        }

        /// <summary>
        /// 买家联系方式
        /// </summary>
        public string Contact
        {
            get;
            set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get;
            set;
        }
    }
}
