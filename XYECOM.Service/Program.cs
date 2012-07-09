using System;
using System.Collections.Generic;

using System.ServiceProcess;
using System.Text;
using System.Configuration;

namespace XYECOM.Service
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            //string serviceFileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            double chz = XYECOM.Core.MyConvert.GetDouble(ConfigurationManager.AppSettings["ContractScanHz"]);
            ServiceConfig.ContractScanHz = chz;
            double ohz = XYECOM.Core.MyConvert.GetDouble(ConfigurationManager.AppSettings["OrderScanHz"]);
            ServiceConfig.OrderScanHz = ohz;
            double thz = XYECOM.Core.MyConvert.GetDouble(ConfigurationManager.AppSettings["TeamOrderScanHz"]);
            ServiceConfig.TeamOrderScanHz = thz;

            ServiceUtil.Info("获取配置信息：【ContractScanHz:" + chz + "】【OrderScanHz:" + ohz + "】【TeamOrderScanHz:" + thz + "】");
            
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new YijiaService() 
			};
            ServiceBase.Run(ServicesToRun);
        }
    }
}
