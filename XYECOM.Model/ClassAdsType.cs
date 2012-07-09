using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    public enum ClassAdsState
    {
        /// <summary>
        /// 全部
        /// </summary>
        All,
        /// <summary>
        /// 展示中（已经开始展示）
        /// </summary>
        OnView,
        /// <summary>
        /// 有效的（包括已经开始展示的和还未开始的）
        /// </summary>
        Valid,
        /// <summary>
        /// 已过期（展示结束）
        /// </summary>
        HasExpired,
        /// <summary>
        /// 还未开始
        /// </summary>
        NotStarted
    }
}
