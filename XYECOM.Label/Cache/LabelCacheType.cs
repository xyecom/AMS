using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 标签缓存内容类型
    /// </summary>
    public enum LabelCacheType
    {
        /// <summary>
        /// 内容标签
        /// </summary>
        ContentLabel,

        /// <summary>
        /// 分类标签
        /// </summary>
        ClassLabel,

        /// <summary>
        /// 系统标签
        /// </summary>
        SystemLabel,

        /// <summary>
        /// 分类信息统计
        /// </summary>
        ClassInfoStat,
        /// <summary>
        /// 投票标签
        /// </summary>
        PollLabel,
        /// <summary>
        /// 企业专栏标签
        /// </summary>
        PartLabel
    }
}
