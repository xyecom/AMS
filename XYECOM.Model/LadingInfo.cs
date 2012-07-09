using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Model
{
    public class LadingInfo
    {
        #region Data

        /// <summary>
        /// 编号
        /// </summary>
        private int id;

        /// <summary>
        /// 本次提取数量
        /// </summary>
        private decimal deliveryQuantity;

        /// <summary>
        /// 提货时间
        /// </summary>
        private DateTime deliveryTime;

        /// <summary>
        /// 送达时间
        /// </summary>
        private DateTime arrivalTime;

        /// <summary>
        /// 收货人地址
        /// </summary>
        private string address;

        /// <summary>
        /// 收货人姓名
        /// </summary>
        private string name;

        /// <summary>
        /// 收货人电话
        /// </summary>
        private string telphone;

        /// <summary>
        /// 提单密码
        /// </summary>
        private string passWord;

        /// <summary>
        /// 订单编号
        /// </summary>
        private int orderId;

        /// <summary>
        /// 配送方式
        /// </summary>
        private string deliveryType;

        /// <summary>
        /// 证件号码
        /// </summary>
        private string idNo;

        /// <summary>
        /// 车牌号
        /// </summary>
        private string vehicleLicensing;

        /// <summary>
        /// 提单编号
        /// </summary>
        private string invoiceId;


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
        /// 本次提取数量
        /// </summary>
        public decimal DeliveryQuantity
        {
            get
            {
                return this.deliveryQuantity;
            }
            set
            {
                this.deliveryQuantity = value;
            }
        }

        /// <summary>
        /// 提货时间
        /// </summary>
        public DateTime DeliveryTime
        {
            get
            {
                return this.deliveryTime;
            }
            set
            {
                this.deliveryTime = value;
            }
        }

        /// <summary>
        /// 送达时间
        /// </summary>
        public DateTime ArrivalTime
        {
            get
            {
                return this.arrivalTime;
            }
            set
            {
                this.arrivalTime = value;
            }
        }

        /// <summary>
        /// 收货人地址
        /// </summary>
        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
            }
        }

        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// 收货人电话
        /// </summary>
        public string Telphone
        {
            get
            {
                return this.telphone;
            }
            set
            {
                this.telphone = value;
            }
        }

        /// <summary>
        /// 提单密码
        /// </summary>
        public string PassWord
        {
            get
            {
                return this.passWord;
            }
            set
            {
                this.passWord = value;
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
        /// 配送方式
        /// </summary>
        public string DeliveryType
        {
            get
            {
                return this.deliveryType;
            }
            set
            {
                this.deliveryType = value;
            }
        }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string IdNo
        {
            get
            {
                return this.idNo;
            }
            set
            {
                this.idNo = value;
            }
        }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string VehicleLicensing
        {
            get
            {
                return this.vehicleLicensing;
            }
            set
            {
                this.vehicleLicensing = value;
            }
        }

        /// <summary>
        /// 提单编号
        /// </summary>
        public string InvoiceId
        {
            get
            {
                return this.invoiceId;
            }
            set
            {
                this.invoiceId = value;
            }
        }

        #endregion

        private DateTime inputDate;

        public DateTime InputDate
        {
            get { return inputDate; }
            set { inputDate = value; }
        }

        private short status;

        public short Status
        {
            get { return status; }
            set { status = value; }
        }

        public int OrderType { get; set; }
    }
}
