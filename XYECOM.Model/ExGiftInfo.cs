using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    public class ExGiftInfo
    {
        int exId;
        /// <summary>
        /// 兑换记录编号
        /// </summary>
        public int ExId
        {
            get { return exId; }
            set { exId = value; }
        }
        int gId;
        /// <summary>
        /// 礼品编号
        /// </summary>
        public int GId
        {
            get { return gId; }
            set { gId = value; }
        }
        int userId;
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        int number;
        /// <summary>
        /// 兑换数量
        /// </summary>
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        DateTime exTime;
        /// <summary>
        /// 兑换时间
        /// </summary>
        public DateTime ExTime
        {
            get { return exTime; }
            set { exTime = value; }
        }
        int state;
        /// <summary>
        /// 兑换状态
        /// </summary>
        public int State
        {
            get { return state; }
            set { state = value; }
        }
    }
}
