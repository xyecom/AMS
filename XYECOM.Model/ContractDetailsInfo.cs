using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Model
{
    public partial class ContractDetailsInfo
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
            
        private string title = string.Empty;

        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private decimal price;

        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        private int count;
        /// <summary>
        /// 数量
        /// </summary>
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        private decimal totalAmount;

        /// <summary>
        /// 总金额
        /// </summary>
        public decimal TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }

        private string unit = string.Empty;
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        private string remar = string.Empty;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remar
        {
            get { return remar; }
            set { remar = value; }
        }

        private int contractId;
        /// <summary>
        /// 合同编号
        /// </summary>
        public int ContractId
        {
            get { return contractId; }
            set { contractId = value; }
        }
    }
}
