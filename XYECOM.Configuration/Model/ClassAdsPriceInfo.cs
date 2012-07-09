using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Configuration
{
    /// <summary>
    /// 分类黄金广告位置
    /// </summary>
    public  class ClassAdsPriceInfo
    {
        private int step;
        /// <summary>
        /// 广告的位置
        /// </summary>
        public int Step
        {
            get { return step; }
            set { step = value; }
        }
        private double price;
        /// <summary>
        /// 广告的价钱
        /// </summary>
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
