using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 联系方式控制返回值枚举
    /// </summary>
    public enum ContactsControlRetrunValue : short
    {
        /// <summary>
        /// 不能查看
        /// </summary>
        CanNotSee = -1,
        /// <summary>
        /// 已登录，但权限太低，不能查看
        /// </summary>
        PopedomTooLow,
        /// <summary>
        /// 可以查看
        /// </summary>
        CanSee,
        /// <summary>
        /// 未知
        /// </summary>
        Null
    }
}
