using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 排名信息实体类
    /// </summary>
    public class RankingInfo
    {
        private int rankingId;

        /// <summary>
        /// 排名信息id
        /// </summary>
        public int RankingId
        {
            get { return rankingId; }
            set { rankingId = value; }
        }

        private long keyId;
        /// <summary>
        /// 关键字Id
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

        private string infoIds;
        /// <summary>
        /// 展示信息Id集合
        /// </summary>
        public string InfoIds
        {
            get { return infoIds; }
            set { infoIds = value; }
        }

        private DateTime beginTime;
        /// <summary>
        /// 信息开始展示时间
        /// </summary>
        public DateTime BeginTime
        {
            get { return beginTime; }
            set { beginTime = value; }
        }

        private DateTime endTime;
        /// <summary>
        /// 信息展示结束时间
        /// </summary>
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        private decimal amount;
        /// <summary>
        /// 支付金额
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

        /// <summary>
        /// 获取信息Id
        /// </summary>
        /// <param name="moduleName">模块Id</param>
        /// <returns></returns>
        public long GetInfoId(string moduleName)
        {
            if (string.IsNullOrEmpty(infoIds)) return 0;

            string[] ids = infoIds.Split('|');

            foreach (string s in ids)
            {
                string[] _t = s.Split(':');

                if (_t.Length != 2) continue;

                if (_t[0].Equals(moduleName))
                    return Core.MyConvert.GetInt64(_t[1].ToString());
            }

            return 0;
        }
    }
}
