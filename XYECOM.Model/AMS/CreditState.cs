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
        Draft =0,

        /// <summary>
        /// 未审核
        /// </summary>
        Null =-1,

        /// <summary>
        /// 审核未通过
        /// </summary>
        NoPass = 1,

        /// <summary>
        /// 投标中
        /// </summary>
        Tender =2,

        /// <summary>
        /// 案件进行中
        /// </summary>
        InProgress = 3,

        /// <summary>
        /// 服务商案件完成等待债权人确认
        /// </summary>
        CreditConfirm = 4,

        /// <summary>
        ///案件结束
        /// </summary>
        CreditEnd = 5,

        /// <summary>
        /// 债权人取消案件
        /// </summary>
        Canceled= 6,

        /// <summary>
        /// 已删除
        /// </summary>
        Delete = 7
    }
}
