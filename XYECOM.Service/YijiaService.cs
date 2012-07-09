using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.IO;

namespace XYECOM.Service
{
    public partial class YijiaService : ServiceBase
    {
        public YijiaService()
        {
            InitializeComponent();
        }

        Thread[] thredInfo = null;

        protected override void OnStart(string[] args)
        {
            ServiceUtil.Info(string.Format("服务于【{0}】Starting", DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff")));
            isPause = false;
            thredInfo = new Thread[] 
            { 
                new Thread(new ThreadStart(Contract_Process)),
                new Thread(new ThreadStart(TeamOrder_Process)),
                new Thread(new ThreadStart(Order_Process)) 
            };

            for (int i = 0; i < thredInfo.Length; i++)
            {
                thredInfo[i].Start();
                System.Threading.Thread.Sleep(1);
            }
            ServiceUtil.Info(string.Format("服务于【{0}】Start Successfull", DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff")));
        }

        protected override void OnStop()
        {
            ServiceUtil.Info(string.Format("服务于【{0}】Starting to EndState", DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff")));
            isPause = true;
            for (int i = 0; i < thredInfo.Length; i++)
            {
                thredInfo[i].Abort();
                System.Threading.Thread.Sleep(1);
            }
            ServiceUtil.Info(string.Format("服务于【{0}】 to EndState successfull", DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff")));
        }

        bool isPause = false;

        public void Contract_Process()
        {
            ServiceUtil.Info(string.Format("【合同】{0} Begin", DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff")));
            while (!isPause)
            {
                try
                {
                    new Contract().Process();
                }
                catch (Exception ex)
                {
                    ServiceUtil.Error("CT:" + ex.Message, ex);
                }

                System.Threading.Thread.Sleep((int)ServiceConfig.ContractScanHz * 1000 * 60);
            }
            ServiceUtil.Info(string.Format("【合同】{0} End", DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff")));
        }

        public void TeamOrder_Process()
        {
            ServiceUtil.Info(string.Format("【团购】{0} Begin", DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff")));
            while (!isPause)
            {
                try
                {
                    new TeamOrder().Process();
                }
                catch (Exception ex)
                {
                    ServiceUtil.Error("TB:" + ex.Message, ex);
                }

                System.Threading.Thread.Sleep((int)ServiceConfig.TeamOrderScanHz * 1000 * 60);
            }
            ServiceUtil.Info(string.Format("【团购】{0} End", DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff")));
        }

        public void Order_Process()
        {
            ServiceUtil.Info(string.Format("【订单】{0} Begin", DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff")));
            while (!isPause)
            {
                
                try
                {
                    new Order().Process();
                }
                catch (Exception ex)
                {
                    ServiceUtil.Error("OD:" + ex.Message, ex);
                }                
                System.Threading.Thread.Sleep((int)ServiceConfig.OrderScanHz * 1000 * 60);
            }
            ServiceUtil.Info(string.Format("【订单】{0} End", DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff")));
        }
    }
}
