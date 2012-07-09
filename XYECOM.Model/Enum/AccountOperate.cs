using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Model
{
    public enum AccountOperate
    {
        /// <summary>
        /// 充值
        /// </summary>
        InputMoney,

        /// <summary>
        /// 支付订单
        /// </summary>
        PayOrders,

        /// <summary>
        /// 支付产品保证金
        /// </summary>
        PaySupMargin,

        /// <summary>
        /// 支付合同保证金
        /// </summary>
        PayContractMargin,

        /// <summary>
        /// 采购商确认订单，将货款和运费打入卖家平台账户
        /// </summary>
        SellerCollection,

        /// <summary>
        /// 释放产品保证金
        /// </summary>
        ReleaseMargin,

        /// <summary>
        /// 释放大宗保证金
        /// </summary>
        ReleaseConMargin,

        /// <summary>
        /// 按件提成
        /// </summary>
        Ticheng,

        /// <summary>
        /// 充值合同保证金
        /// </summary>
        ContractMargin,

        /// <summary>
        /// 团购已结束N天，未支付全款，系统将已付款扣除至平台账户
        /// </summary>
        TeamOrderDeduction,

        /// <summary>
        /// 申请退款操作
        /// </summary>
        Refund

    }
}
