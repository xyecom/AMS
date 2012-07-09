using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 联系方式控制项枚举
    /// </summary>
    public enum ContactsControlItem
    {
        /// <summary>
        /// 未知项
        /// </summary>
        Null,
        /// <summary>
        /// 供应
        /// </summary>
        SellOffer,
        /// <summary>
        /// buyoffer
        /// </summary>
        BuyOffer,
        /// <summary>
        /// 提供加工
        /// </summary>
        SellMachining,
        /// <summary>
        /// 寻求加工
        /// </summary>
        BuyMaching,
        /// <summary>
        /// 招商
        /// </summary>
        SellInvestment,
        /// <summary>
        /// 代理
        /// </summary>
        BuyInvestment,
        /// <summary>
        /// 提供服务
        /// </summary>
        SellService,
        /// <summary>
        /// 寻求服务
        /// </summary>
        BuyService,
        /// <summary>
        /// 品牌
        /// </summary>
        Brand,
        /// <summary>
        /// 人才
        /// </summary>
        Job,
        /// <summary>
        /// 企业
        /// </summary>
        Company
    }
}
