using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 排名日志信息实体类
    /// </summary>
    public class RankingLogInfo
    {
        private int logId;
        /// <summary>
        /// 日志信息Id
        /// </summary>
        public int LogId
        {
            get { return logId; }
            set { logId = value; }
        }

        private long keyId;
        /// <summary>
        /// 关键词Id
        /// </summary>
        public long KeyId
        {
            get { return keyId; }
            set { keyId = value; }
        }

        private long userId;
        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private DateTime beginTime;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginTime
        {
            get { return beginTime; }
            set { beginTime = value; }
        }

        private DateTime endTime;
        /// <summary>
        /// 排名结束时间
        /// </summary>
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        private decimal amount;
        /// <summary>
        /// 用户为排名支付的金额
        /// </summary>
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private short rank;
        /// <summary>
        /// 名次
        /// </summary>
        public short Rank
        {
            get { return rank; }
            set { rank = value; }
        }
    }
}
