//------------------------------------------------------------------------------
//
// file name：CreditLeavlManager.cs
// author: wangzhen
// create date：2011-5-31 12:06:01
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace XYECOM.Business
{
    /// <summary>
    /// Business logic for dbo.XY_CreditLeavl.
    /// </summary>
    public partial class CreditLeavlManager
    {
        /// <summary>
        /// 获取最后一个信用区间
        /// </summary>
        /// <returns></returns>
        public Model.CreditLeavlInfo GetLastItem()
        {
            return access.GetLastItem();
        }

        /// <summary>
        /// 根据一个具体的分值，获取该分值所属的信用区间
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public Model.CreditLeavlInfo GetItemByPoint(decimal points)
        {
            return access.GetItemByPoint(points);
        }

        /// <summary>
        /// 增加指定用户的信用积分，为负数时，减去相应积分
        /// </summary>
        /// <param name="increa"></param>
        /// <returns></returns>
        public int AddCreditIntegral(int userId, decimal increa)
        {
            if (increa != 0)
            {
                return access.AddCreditIntegral(userId, increa);
            }
            return 0;
        }
    }
}

