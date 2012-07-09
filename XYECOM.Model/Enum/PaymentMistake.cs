using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 是否支付密码正确枚举
    /// </summary>
    public enum PaymenMistake
    {
        /// <summary>
        /// 正确
        /// </summary>
        DisMistake,

        /// <summary>
        /// 错误
        /// </summary>
        /// 
        Mistake,

        /// <summary>
        /// 无状态
        /// </summary>
        /// 
        Normal,

        /// <summary>
        /// 锁定中
        /// </summary>
        /// 
        YesLock,

        /// <summary>
        /// 未锁定
        /// </summary>
        /// 
        NoLock

    }
}
