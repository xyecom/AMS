using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Service
{
    public class ServiceConfig
    {
        private static double _orderScanHz = 5;
        /// <summary>
        /// 普通订单扫描频率
        /// </summary>
        public static double OrderScanHz
        {
            get { return ServiceConfig._orderScanHz; }
            set { ServiceConfig._orderScanHz = value; }
        }
        private static double _teamOrderScanHz = 5;
        /// <summary>
        /// 团购订单扫描频率
        /// </summary>
        public static double TeamOrderScanHz
        {
            get { return ServiceConfig._teamOrderScanHz; }
            set { ServiceConfig._teamOrderScanHz = value; }
        }
        private static double _contractScanHz = 5;
        /// <summary>
        /// 合同交易扫描频率
        /// </summary>
        public static double ContractScanHz
        {
            get { return ServiceConfig._contractScanHz; }
            set { ServiceConfig._contractScanHz = value; }
        }
    }
}
