using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ��¼�����ʻ����Ѽ�¼��ʵ����
    /// </summary>
    public class FictitiouConsumptionInfo
    {
        private Int64 infoId;
        private Int64 userId;
        private Decimal amount;
        private DateTime dateTime;
        private string explain;

        /// <summary>
        /// �����ʻ����Ѽ�¼Ĭ�Ϲ��캯��
        /// </summary>
        public FictitiouConsumptionInfo() { }

        /// <summary>
        /// �����ʻ����Ѽ�¼����ֵ�ù��캯��
        /// </summary>
        /// <param name="fcid"></param>
        /// <param name="uid"></param>
        /// <param name="fccount"></param>
        /// <param name="fctime"></param>
        /// <param name="fcexplain"></param>
        public FictitiouConsumptionInfo(Int64 infoId, Int64 userId, Decimal amount, DateTime dateTime, string explain)
        {
            this.infoId = infoId;
            this.userId = userId;
            this.amount = amount;
            this.dateTime = dateTime;
            this.explain = explain;
        }

        /// <summary>
        /// �����ʻ����ѱ��
        /// </summary>
        public Int64 InfoId
        {
            set { infoId = value; }
            get { return infoId; }
        }

        /// <summary>
        /// ���ѵ��û����
        /// </summary>
        public Int64 UserId
        {
            set { userId = value; }
            get { return userId; }
        }

        /// <summary>
        /// ���������ʻ������ѽ��
        /// </summary>
        public Decimal Amount
        {
            set { amount = value; }
            get { return amount; }
        }

        /// <summary>
        /// ���������ʻ�������ʱ��
        /// </summary>
        public DateTime _DateTime
        {
            set { dateTime = value; }
            get { return dateTime; }
        }

        /// <summary>
        /// ���������ʻ�������˵��
        /// </summary>
        public string Explain
        {
            set { explain = value; }
            get { return explain; }
        }
    }
}
