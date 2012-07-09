using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 投诉枚举(订单，合同，团购)
    /// </summary>
    public enum Complaint
    {
        /// <summary>
        /// 订单
        /// </summary> 
        ComplaintOrder = 0,


        /// <summary>
        /// 合同
        /// </summary> 
        ComplaintContract = 1,


        /// <summary>
        /// 团购
        /// </summary> 
        ComplaintTeam = 2
    }
}
