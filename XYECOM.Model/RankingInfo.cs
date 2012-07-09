using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ������Ϣʵ����
    /// </summary>
    public class RankingInfo
    {
        private int rankingId;

        /// <summary>
        /// ������Ϣid
        /// </summary>
        public int RankingId
        {
            get { return rankingId; }
            set { rankingId = value; }
        }

        private long keyId;
        /// <summary>
        /// �ؼ���Id
        /// </summary>
        public long KeyId
        {
            get { return keyId; }
            set { keyId = value; }
        }

        private long userId;
        /// <summary>
        /// �û�Id
        /// </summary>
        public long UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private string infoIds;
        /// <summary>
        /// չʾ��ϢId����
        /// </summary>
        public string InfoIds
        {
            get { return infoIds; }
            set { infoIds = value; }
        }

        private DateTime beginTime;
        /// <summary>
        /// ��Ϣ��ʼչʾʱ��
        /// </summary>
        public DateTime BeginTime
        {
            get { return beginTime; }
            set { beginTime = value; }
        }

        private DateTime endTime;
        /// <summary>
        /// ��Ϣչʾ����ʱ��
        /// </summary>
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        private decimal amount;
        /// <summary>
        /// ֧�����
        /// </summary>
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private short rank;
        /// <summary>
        /// ����
        /// </summary>
        public short Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        /// <summary>
        /// ��ȡ��ϢId
        /// </summary>
        /// <param name="moduleName">ģ��Id</param>
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
