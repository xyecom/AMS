using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Model
{
    public enum ContractStatus
    {
        /// <summary>
        /// 等待供应商确认
        /// </summary>
        WaitingForSellerConfirm,
        /// <summary>
        /// 等待供应商再次确认
        /// </summary>
        WaitingForSellerConfirmAgain,
        /// <summary>
        /// 等待采购商编辑
        /// </summary>
        WaitingForBuyerEdit,
        /// <summary>
        /// 合同关闭
        /// </summary>
        Closed,
        /// <summary>
        /// 生效的合同
        /// </summary>
        Effective,

        /// <summary>
        /// 锁定状态
        /// </summary>
        Lock
    }
}
