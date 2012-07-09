using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Model
{
    public partial class ContractInfo
    {
        private int id;

        /// <summary>
        /// 主键
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int sellerId;

        /// <summary>
        /// 卖家编号
        /// </summary>
        public int SellerId
        {
            get { return sellerId; }
            set { sellerId = value; }
        }
        private int buyerId;

        /// <summary>
        /// 买家编号
        /// </summary>
        public int BuyerId
        {
            get { return buyerId; }
            set { buyerId = value; }
        }

        private decimal freightFee;

        /// <summary>
        /// 运费金额
        /// </summary>
        public decimal FreightFee
        {
            get { return freightFee; }
            set { freightFee = value; }
        }

        private DateTime contractPeriod;

        /// <summary>
        /// 合同有效期
        /// </summary>
        public DateTime ContractPeriod
        {
            get { return contractPeriod; }
            set { contractPeriod = value; }
        }

        private decimal margin;

        /// <summary>
        /// 违约保证金
        /// </summary>
        public decimal Margin
        {
            get { return margin; }
            set { margin = value; }
        }

        private decimal totalAmount;

        /// <summary>
        /// 合同总金额
        /// </summary>
        public decimal TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }

        private DateTime publishDate;

        /// <summary>
        /// 发起时间
        /// </summary>
        public DateTime PublishDate
        {
            get { return publishDate; }
            set { publishDate = value; }
        }

        private DateTime effectDate;

        /// <summary>
        /// 生效时间
        /// </summary>
        public DateTime EffectDate
        {
            get { return effectDate; }
            set { effectDate = value; }
        }

        private decimal amount;

        /// <summary>
        /// 买家支付的总金额
        /// </summary>
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private decimal discount;

        /// <summary>
        /// 优惠额度
        /// </summary>
        public decimal Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        private string payMoney = string.Empty;

        /// <summary>
        /// 货款支付期限
        /// </summary>
        public string PayMoney
        {
            get { return payMoney; }
            set { payMoney = value; }
        }

        private string delivery = string.Empty;

        /// <summary>
        /// 交货期限
        /// </summary>
        public string Delivery
        {
            get { return delivery; }
            set { delivery = value; }
        }

        private string contractDefault = string.Empty;

        /// <summary>
        /// 违约约定
        /// </summary>
        public string ContractDefault
        {
            get { return contractDefault; }
            set { contractDefault = value; }
        }

        private int freihgtCommitment;

        /// <summary>
        /// 违约运费承担方
        /// </summary>
        public int FreightCommitment
        {
            get { return freihgtCommitment; }
            set { freihgtCommitment = value; }
        }

        private string addedContent = string.Empty;
        /// <summary>
        /// 补充内容
        /// </summary>
        public string AddedContent
        {
            get { return addedContent; }
            set { addedContent = value; }
        }

        private int state;

        /// <summary>
        /// 合同状态
        /// </summary>
        public int State
        {
            get { return (int)conState; }
        }

        private XYECOM.Model.ContractStatus conState;

        public XYECOM.Model.ContractStatus ConState
        {
            get { return conState; }
            set { conState = value; }
        }

        private bool isOnline;

        /// <summary>
        /// 是否是在线合同
        /// </summary>
        public bool IsOnline
        {
            get { return isOnline; }
            set { isOnline = value; }
        }

        private int initiator;
        /// <summary>
        /// 合同发起方 值1为买家发起的合同 ，0为卖家发起的合同
        /// </summary>
        public int Initiator
        {
            get { return initiator; }
            set { initiator = value; }
        }


        private List<ContractDetailsInfo> conDetails = new List<ContractDetailsInfo>();
        /// <summary>
        /// 产品明细集合
        /// </summary>
        public List<ContractDetailsInfo> ConDetails
        {
            get { return conDetails; }
            set { conDetails = value; }
        }

        private string contractNumber = string.Empty;

        /// <summary>
        /// 合同号
        /// </summary>
        public string ContractNumber
        {
            get { return contractNumber; }
            set { contractNumber = value; }
        }

        private bool isLock;

        /// <summary>
        /// 是否已锁定
        /// </summary>
        public bool IsLock
        {
            get { return isLock; }
            set { isLock = value; }
        }

        private DateTime lockDate;

        /// <summary>
        /// 锁定时间
        /// </summary>
        public DateTime LockDate
        {
            get { return lockDate; }
            set { lockDate = value; }
        }

        private DateTime closeDate;

        /// <summary>
        /// 关闭时间
        /// </summary>
        public DateTime CloseDate
        {
            get { return closeDate; }
            set { closeDate = value; }
        }
    }
}
