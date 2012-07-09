using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Model
{
    public enum FreightType
    {
        /// <summary>
        /// 卖家支付运费
        /// </summary>
        SellerPayment = 1,

        /// <summary>
        /// 买家支付运费
        /// </summary>
        BuyerPayment = 2,

        /// <summary>
        /// 买家自提货
        /// </summary>
        SelfDelivery = 4,

        /// <summary>
        /// 自提或者买家支付运费
        /// </summary>
        BuyerPayAndSelfDelivery = 6
    }
}
