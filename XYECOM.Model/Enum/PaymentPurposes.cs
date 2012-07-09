using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// CFCA支付时,资金的用途
    /// </summary>
    public enum PaymentPurposes
    {
        /// <summary>
        /// 平台充值
        /// </summary>
        Recharge = 1,

        /// <summary>
        /// 挂牌时,支付保证金充值
        /// </summary>
        Listing_Margin = 2,

        /// <summary>
        /// 报价时(供应商),支付保证金充值
        /// </summary>
        Quote_Margin = 3,

        /// <summary>
        /// 购买产品时,支付保证金
        /// </summary>
        Buy_Margin = 4,

        /// <summary>
        /// 竞价时(采购商),支付保证金
        /// </summary>
        Bidding_Margin = 5,

        /// <summary>
        /// 购买产品时,支付全额货款
        /// </summary>
        Buy_AllMoney = 6

    }
}
