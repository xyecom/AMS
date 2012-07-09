using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ������־��Ϣʵ����
    /// </summary>
    public class RankingLogInfo
    {
        private int logId;
        /// <summary>
        /// ��־��ϢId
        /// </summary>
        public int LogId
        {
            get { return logId; }
            set { logId = value; }
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

        private DateTime beginTime;
        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        public DateTime BeginTime
        {
            get { return beginTime; }
            set { beginTime = value; }
        }

        private DateTime endTime;
        /// <summary>
        /// ��������ʱ��
        /// </summary>
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        private decimal amount;
        /// <summary>
        /// �û�Ϊ����֧���Ľ��
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
    }
}
