using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 用户等级当前状态枚举
    /// </summary>
    public enum UserGradeState
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal,
        /// <summary>
        /// 需要提醒
        /// </summary>
        Remind,
        /// <summary>
        /// 已经降级
        /// </summary>
        Degrade
    }
}
