using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Configuration
{
    /// <summary>
    /// 排名价格信息实体类
    /// </summary>
    public class RankingPriceInfo
    {
        private short rank;
        /// <summary>
        /// 名次
        /// </summary>
        public short Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        private int price;
        /// <summary>
        /// 价格
        /// </summary>
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
