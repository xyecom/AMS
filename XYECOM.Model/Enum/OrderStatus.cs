using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Model
{
    public enum OrderStatus
    {
        /// <summary>
        /// 等待付款
        /// </summary>
        WaitingForBuyerPayment = 1,
        /// <summary>
        ///已付款，等待采购商生成提单
        /// </summary>
        WaitingBuyerGeneralDeliveryOrder = 11,
        /// <summary>
        /// 等待供应商验证提单
        /// </summary>
        WaitingSellerCheckDeliveryOrder = 12,
        /// <summary>
        /// 等待供应商发货
        /// </summary>
        WaitingSellerSendGoods = 21,
        /// <summary>
        /// 等待采购商验货
        /// </summary>
        WaitingBuyerCheckGoods = 2,
        /// <summary>
        /// 验货异议
        /// </summary>
        WaitingForBuyerCheckGoodsObjection = 4,
        /// <summary>
        /// 供应商确认收款
        /// </summary>
        WaitingForSellerConfirmCollection = 5,
        /// <summary>
        /// 已结束
        /// </summary>
        Finish = 6,
        /// <summary>
        /// 管理员锁定
        /// </summary>
        Lock = 7,
        /// <summary>
        /// 被采购商取消
        /// </summary>
        CancelByBuyer = 8,
        /// <summary>
        /// 被供应商取消
        /// </summary>
        CancelBySupplier = 9,
        /// <summary>
        /// 被管理员取消
        /// </summary>
        CancelBySystem = 10
    }
}
