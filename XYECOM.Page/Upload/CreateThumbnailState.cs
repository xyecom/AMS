using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Page.Upload
{
    /// <summary>
    ///枚举
    /// </summary>
    public enum CreateThumbnailState
    {
        /// <summary>
        /// 尺寸出现错误
        /// </summary>
        DimensionError,
        /// <summary>
        /// 图像太小，copy原文件过去
        /// </summary>
        DimensionSmall,
        /// <summary>
        /// 生成成功
        /// </summary>
        Succeed,
        /// <summary>
        /// 文件不存在
        /// </summary>
        NotFound
    }
}
