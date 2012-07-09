using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 广告类型枚举
    /// </summary>
    public enum AdType:short
    {
        /// <summary>
        /// 文字广告
        /// </summary>
        Text = 1,
        /// <summary>
        /// 图片广告
        /// </summary>
        Image,
        /// <summary>
        /// Flash广告
        /// </summary>
        Flash,
        /// <summary>
        /// 代码广告
        /// </summary>
        Code
    }
}
