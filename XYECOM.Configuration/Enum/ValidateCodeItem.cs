using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Configuration
{
    /// <summary>
    /// 验证码项枚举
    /// </summary>
    public enum ValidateCodeItem
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        Register,
        /// <summary>
        /// 用户登录
        /// </summary>
        Login,
        /// <summary>
        /// 资讯评论
        /// </summary>
        Comment,
        /// <summary>
        /// 商业信息留言
        /// </summary>
        Message,
        /// <summary>
        /// 下订单
        /// </summary>
        MakeTheOrder,
        /// <summary>
        /// 快速发布信息
        /// </summary>
        QuickPost
    }
}
