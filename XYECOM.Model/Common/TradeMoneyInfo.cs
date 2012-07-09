using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Model
{
    public class TradeMoneyInfo
    {
        #region 付款截止天数
        int paymentday;

        public int Paymentday
        {
            get { return paymentday; }
            set { paymentday = value; }
        }
        #endregion

        #region 验货,验票,评价
        int checkProductDeadline;
        /// <summary>
        /// 验货截止天数
        /// </summary>
        public int CheckProductDeadline
        {
            get { return checkProductDeadline; }
            set { checkProductDeadline = value; }
        }
        int checkTicketDeadline;
        /// <summary>
        /// 验票截止天数
        /// </summary>
        public int CheckTicketDeadline
        {
            get { return checkTicketDeadline; }
            set { checkTicketDeadline = value; }
        }

        /// <summary>
        /// 验货成功后,返回金额百分比
        /// </summary>
        public decimal CheckProductBackPercentage
        {
            get;
            set;
        }
        /// <summary>
        /// 验票成功后,返回金额百分比
        /// </summary>
        public decimal CheckTicketBackPercentage
        {
            get;
            set;
        }

        /// <summary>
        /// 评价截止天数
        /// </summary>
        public int AssessDeadline
        {
            get;
            set;
        }

        #endregion

        #region CFCA 在线网银

        string institutionID;
        /// <summary>
        /// 机构编号
        /// </summary>
        public string InstitutionID
        {
            get { return institutionID; }
            set { institutionID = value; }
        }

        //string webDomain;
        ///// <summary>
        ///// 网站域名
        ///// </summary>
        //public string WebDomain
        //{
        //    get { return webDomain; }
        //    set { webDomain = value; }
        //}

        #endregion

        #region 采购信息报价失效天数
        int quoteTime;

        public int QuoteTime
        {
            get { return quoteTime; }
            set { quoteTime = value; }
        }

        #endregion

        #region 积分

        int integral;
        /// <summary>
        /// 积分
        /// </summary>
        public int Integral
        {
            get { return integral; }
            set { integral = value; }
        }

        #endregion

        #region 付货截止天数
        int _CheckDeliveryDeadline;
        /// <summary>
        /// 检查付货截止天数
        /// </summary>
        public int CheckDeliveryDeadline
        {
            get { return _CheckDeliveryDeadline; }
            set { _CheckDeliveryDeadline = value; }
        }
        #endregion

        #region 邮寄票据截止天数

        int _CheckInvoiceDeadline;
        /// <summary>
        /// 检查邮寄票据截止天数
        /// </summary>
        public int CheckInvoiceDeadline
        {
            get { return _CheckInvoiceDeadline; }
            set { _CheckInvoiceDeadline = value; }
        }

        #endregion

        private decimal contractMargin;

        /// <summary>
        /// 发布大宗产品需要交纳的合同保证金
        /// </summary>
        public decimal ContractMargin
        {
            get { return contractMargin; }
            set { contractMargin = value; }
        }
    }
}
