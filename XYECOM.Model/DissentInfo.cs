using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 实体类Dissent的摘要说明。
    /// </summary>
    public class DissentInfo
    {
        #region Data

        /// <summary>
        /// 编号
        /// </summary>
        private int id;

        /// <summary>
        /// 订单编号
        /// </summary>
        private int orderId;

        /// <summary>
        /// 异议类型
        /// </summary>
        private string dissentType;

        /// <summary>
        /// 描述
        /// </summary>
        private string description;

        /// <summary>
        /// 退款金额
        /// </summary>
        private decimal refundMoney;

        /// <summary>
        /// 货物票据
        /// </summary>
        private string goodsOrInvoice;

        /// <summary>
        /// 时间
        /// </summary>
        private DateTime insertTime;

        /// <summary>
        /// 订单类型（1为团购订单）
        /// </summary>
        private int orderType;

        #endregion

        #region Properties

        /// <summary>
        /// 编号
        /// </summary>
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// 订单编号
        /// </summary>
        public int OrderId
        {
            get
            {
                return this.orderId;
            }
            set
            {
                this.orderId = value;
            }
        }

        /// <summary>
        /// 异议类型
        /// </summary>
        public string DissentType
        {
            get
            {
                return this.dissentType;
            }
            set
            {
                this.dissentType = value;
            }
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        /// <summary>
        /// 退款金额
        /// </summary>
        public decimal RefundMoney
        {
            get
            {
                return this.refundMoney;
            }
            set
            {
                this.refundMoney = value;
            }
        }

        /// <summary>
        /// 货物票据
        /// </summary>
        public string GoodsOrInvoice
        {
            get
            {
                return this.goodsOrInvoice;
            }
            set
            {
                this.goodsOrInvoice = value;
            }
        }

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime InsertTime
        {
            get
            {
                return this.insertTime;
            }
            set
            {
                this.insertTime = value;
            }
        }

        public int OrderType
        {
            get { return orderType; }
            set { orderType = value; }
        }
        #endregion
    }
}
