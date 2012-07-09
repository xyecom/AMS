using System;
using System.Collections.Generic;

using System.Text;
using XYECOM.Model;

namespace XYECOM.Model
{
    //可序列化类
    [Serializable]
    /// <summary>
    /// 网银支付相关信息对象
    /// </summary>
    public class PaymentInformation
    {
        /// <summary>
        /// 机构编号
        /// </summary>
        public string InstitutionID{ get;set;}

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 支付流水号(32位)
        /// </summary>
        public string PayMentNo { get; set; }

        /// <summary>
        /// 订单总金额
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// 付款者名称
        /// </summary>
        public string PayerName { get; set; }

        /// <summary>
        /// 资金用途
        /// </summary>
        public PaymentPurposes Usage { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 接收处理类URL
        /// </summary>
        public string NotificationURL { get; set; }

        /// <summary>
        /// 收款方
        /// </summary>
        public string Payees { get; set; }

        public PaymentInformation(string institutionID, string order, string paymentNo, long amount, string payerName, PaymentPurposes usage, string remark, string notificationURL, string payees) 
        {
            this.InstitutionID =institutionID;
            this.OrderNo = order;
            this.PayMentNo = paymentNo;
            this.Amount = amount;
            this.PayerName = payerName;
            this.Usage = usage;
            this.Remark = remark;
            this.NotificationURL = notificationURL;
            this.Payees = payees;
        }
    }
}
