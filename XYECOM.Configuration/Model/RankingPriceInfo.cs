using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Configuration
{
    /// <summary>
    /// �����۸���Ϣʵ����
    /// </summary>
    public class RankingPriceInfo
    {
        private short rank;
        /// <summary>
        /// ����
        /// </summary>
        public short Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        private int price;
        /// <summary>
        /// �۸�
        /// </summary>
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
