using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 注册用户返回值类型枚举
    /// </summary>
    public enum ResisterUserReturnValue
    {
        /// <summary>
        /// 注册失败
        /// </summary>
        Failed,
        /// <summary>
        /// 注册失败，有户名已经被占用
        /// </summary>
        UserNameExists,
        /// <summary>
        /// 注册失败，邮箱已经被占用
        /// </summary>
        EmailExists,
        /// <summary>
        /// 注册失败，使用了禁止注册的用户名
        /// </summary>
        ForbidName,
        /// <summary>
        /// 注册成功
        /// </summary>
        Success,
        /// <summary>
        /// 注册成功，但邮件发送失败
        /// </summary>
        SendEmailFailed,
        /// <summary>
        /// 禁止注册
        /// </summary>
        ForbidRegister,
        PartNameExists
    }
}
