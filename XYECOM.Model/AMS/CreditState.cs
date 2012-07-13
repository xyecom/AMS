using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 债权信息状态
    /// </summary>
    public enum CreditState
    {
        /// <summary>
        /// 草稿
        /// </summary>
        Draft,

        /// <summary>
        /// 未审核
        /// </summary>
        Null,

        /// <summary>
        /// 审核未通过
        /// </summary>
        NoPass,

        /// <summary>
        /// 投标中
        /// </summary>
        Tender,

        /// <summary>
        /// 案件进行中
        /// </summary>
        InProgress,

        /// <summary>
        /// 服务商案件完成等待债权人确认
        /// </summary>
        CreditConfirm,

        /// <summary>
        ///案件结束
        /// </summary>
        CreditEnd,

        /// <summary>
        /// 债权人取消案件
        /// </summary>
        Canceled
    }
}
