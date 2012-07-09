using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 关键字排名标签接口
    /// </summary>
    public interface IKeyRank
    {
        /// <summary>
        /// 排名关键字ID
        /// </summary>
        long RankKeyId { get;set;}

        /// <summary>
        /// 当前模块名称
        /// </summary>
        string ModuleName { get;set;}
    }
}
