using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 用户支付错误密码实体
    /// </summary>
    public class PaymentPassWordMistake
    {
        private int userId;
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }


        private DateTime lockTime;
        /// <summary>
        /// 锁定时间Id
        /// </summary>
        public DateTime LockTime
        {
            get { return lockTime; }
            set { lockTime = value; }
        }

        private int mistakeNum;
        /// <summary>
        /// 错误次数
        /// </summary>
        public int MistakeNum
        {
            get { return mistakeNum; }
            set { mistakeNum = value; }
        }
    }
}
