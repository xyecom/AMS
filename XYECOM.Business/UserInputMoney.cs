using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// 用户充值记录业务类
    /// </summary>
    public class UserInputMoney
    {
        private static readonly XYECOM.SQLServer.UserInputMoney DAL = new XYECOM.SQLServer.UserInputMoney();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ei">实体对象</param>
        /// <returns>-3表示订单已经处理过</returns>
        public int Insert(XYECOM.Model.UserInputMoneyInfo ei)
        {
            if (!DAL.CheckOrder(ei.OrderID,ei.U_ID))
                return DAL.Insert(ei);
            else
                return -3;
        }
    }
}

