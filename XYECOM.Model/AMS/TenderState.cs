using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model.AMS
{
    public enum TenderState
    {
        /// <summary>
        /// 投标中
        /// </summary>
        Tender = 0,

        /// <summary>
        /// 中标
        /// </summary>
        Success = 1,

        /// <summary>
        /// 未中标
        /// </summary>
        Failure = -1
    }
}
