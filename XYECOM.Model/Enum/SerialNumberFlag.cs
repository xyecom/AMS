using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 每个枚举最好用2个到不超过3个的大写字母表示
    /// </summary>
    public enum SerialNumberFlag
    {
        /// <summary>
        /// 订单流水号 OrderSerialNumber的简写
        /// </summary>
        OS,
        /// <summary>
        /// 平台现金账户流水号 PlatformAccount的简写
        /// </summary>
        PA,
        /// <summary>
        /// 交易流水号 DealSerialNumber 的简写
        /// </summary>
        DS,

        /// <summary>
        /// 支付产品保证金流水号 Bail的简写
        /// </summary>
        BA,
        /// <summary>
        /// 充值流水号 Bail的简写
        /// </summary>
        CA,

        /// <summary>
        /// 合同编号
        /// </summary>
        CO,

        /// <summary>
        /// 按件提成
        /// </summary>
        TE,

        /// <summary>
        /// 充值合同保证金
        /// </summary>
        CM,

        /// <summary>
        /// 团购订单流水号
        /// </summary>
        TO,
        
        /// <summary>
        /// 支付团购订单费用
        /// </summary>
        TD,

        /// <summary>
        /// 系统扣除团购订单的已付款金额
        /// </summary>
        OD

    }
}
