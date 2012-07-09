using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Configuration
{
    public class ServiceConfigInfo
    {
        private int payDateLimitForTeamBuy = 2;

        /// <summary>
        /// 团购支付期限
        /// </summary>
        public int PayDateLimitForTeamBuy
        {
            get { return payDateLimitForTeamBuy; }
            set { payDateLimitForTeamBuy = value; }
        }

        private int payDateLimitForOrder = 2;

        /// <summary>
        /// 普通订单支付期限
        /// </summary>
        public int PayDateLimitForOrder
        {
            get { return payDateLimitForOrder; }
            set { payDateLimitForOrder = value; }
        }

        
        private int checkGoodsLimitForTeamBuy = 2;
        /// <summary>
        /// 验货时间上线
        /// </summary>
        public int CheckGoodsLimitForTeamBuy
        {
            get { return checkGoodsLimitForTeamBuy; }
            set { checkGoodsLimitForTeamBuy = value; }
        }

        private int checkGoodsLimitForOrder = 2;

        public int CheckGoodsLimitForOrder
        {
            get { return checkGoodsLimitForOrder; }
            set { checkGoodsLimitForOrder = value; }
        }

        private int discussLimitForTeamBuy = 30;

        public int DiscussLimitForTeamBuy
        {
            get { return discussLimitForTeamBuy; }
            set { discussLimitForTeamBuy = value; }
        }

        private int discussLimitForOrder = 30;

        public int DiscussLimitForOrder
        {
            get { return discussLimitForOrder; }
            set { discussLimitForOrder = value; }
        }
    }
}
