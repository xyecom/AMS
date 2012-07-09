using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 记录虚拟帐户消费记录的实体类
    /// </summary>
    public class FictitiouConsumptionInfo
    {
        private Int64 infoId;
        private Int64 userId;
        private Decimal amount;
        private DateTime dateTime;
        private string explain;

        /// <summary>
        /// 虚拟帐户消费记录默认构造函数
        /// </summary>
        public FictitiouConsumptionInfo() { }

        /// <summary>
        /// 虚拟帐户消费记录给定值得构造函数
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
        /// 虚拟帐户消费编号
        /// </summary>
        public Int64 InfoId
        {
            set { infoId = value; }
            get { return infoId; }
        }

        /// <summary>
        /// 消费的用户编号
        /// </summary>
        public Int64 UserId
        {
            set { userId = value; }
            get { return userId; }
        }

        /// <summary>
        /// 本次虚拟帐户的消费金额
        /// </summary>
        public Decimal Amount
        {
            set { amount = value; }
            get { return amount; }
        }

        /// <summary>
        /// 本次虚拟帐户的消费时间
        /// </summary>
        public DateTime _DateTime
        {
            set { dateTime = value; }
            get { return dateTime; }
        }

        /// <summary>
        /// 本次虚拟帐户的消费说明
        /// </summary>
        public string Explain
        {
            set { explain = value; }
            get { return explain; }
        }
    }
}
