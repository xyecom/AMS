using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 缓存值类型枚举
    /// </summary>
    public enum CacheValueType
    {
        /// <summary>
        /// 表类型
        /// </summary>
        Table,
        /// <summary>
        /// 对象类型
        /// </summary>
        Object,
        /// <summary>
        /// 数据行类型
        /// </summary>
        DataRow,
        /// <summary>
        /// int 类型
        /// </summary>
        Int,
        /// <summary>
        /// 字符串类型
        /// </summary>
        String,
        /// <summary>
        /// bool类型
        /// </summary>
        Bool
    }
}
