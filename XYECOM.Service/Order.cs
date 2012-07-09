using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace XYECOM.Service
{
    public class Order : BaseService
    {
        private XYECOM.Business.OrderManager orderManager = new Business.OrderManager();
        private XYECOM.Business.AccountManager accountManager = new Business.AccountManager();
        private XYECOM.Business.AccountDetailsManager detailBLL = new Business.AccountDetailsManager();
        private XYECOM.Business.OrderEvaluationManage orderEvaluationManage = new Business.OrderEvaluationManage();        

        /// <summary>
        /// 逾期将要取消的订单操作
        /// </summary>
        /// <param name="isPause"></param>
        private void WillBeCancel()
        {
            ServiceUtil.Debug("开始执行逾期将要取消的订单操作");

            //获取超过支付期限的普通订单编号
            DataTable willBeCancel = orderManager.SelectWillBeCancel();

            foreach (DataRow row in willBeCancel.Rows)
            {                
                //获取符合条件的合同编号
                int orderId = XYECOM.Core.MyConvert.GetInt32(row["Id"].ToString());
                ServiceUtil.Info("操作逾期将要取消的小额订单(编号" + orderId+")");
                try
                {
                    //修改合同状态为，系统取消
                    orderManager.UpdateStatusById(orderId, Model.OrderStatus.CancelBySystem);
                    //其他操作
                    System.Threading.Thread.Sleep(5);
                }
                catch (Exception ep)
                {
                    ServiceUtil.Error("ERROR:Cancel订单编号为：" + orderId, ep);
                }
            }
            ServiceUtil.Debug("执行结束逾期将要取消的订单操作");
        }

        /// <summary>
        /// 逾期将要自动完成的订单操作
        /// </summary>
        /// <param name="isPause"></param>
        private void WillBeFinish()
        {
            ServiceUtil.Debug("开始执行逾期将要自动完成的订单操作");
            //获取确认收款时间已经到达的订单
            DataTable willBeFinish = orderManager.SelectWillBeFinished();

            foreach (DataRow row in willBeFinish.Rows)
            {
                //获取符合条件的合同编号
                int orderId = XYECOM.Core.MyConvert.GetInt32(row["Id"].ToString());
                ServiceUtil.Info("操作逾期将要自动完成的小额订单(编号" + orderId+")");
                try
                {
                    //修改合同状态为，系统取消
                    orderManager.UpdateStatusById(orderId, Model.OrderStatus.Finish);
                    //其他操作
                    System.Threading.Thread.Sleep(5);
                }
                catch (Exception ep)
                {
                    ServiceUtil.Error("ERROR:Finish订单编号为：" + orderId, ep);
                }
            }
            ServiceUtil.Debug("执行结束逾期将要自动完成的订单操作");
        }

        /// <summary>
        /// 逾期未验货的订单。
        /// </summary>
        /// <param name="isPause"></param>
        private void WillBeCheckGoods()
        {
            ServiceUtil.Debug("开始执行验货截至日已经到达的订单");
            //获取验货截至日已经到达的订单
            DataTable checkGoodsHasFinshed = orderManager.SelectCheckGoodsHasFinshed();

            foreach (DataRow row in checkGoodsHasFinshed.Rows)
            {
                //获取符合条件的订单编号
                int orderId = XYECOM.Core.MyConvert.GetInt32(row["Id"].ToString());

                ServiceUtil.Info("操作验货截至日已经到达的小额订单(编号" + orderId+")");
                try
                {
                    //=========================                   
                    //修改订单状态为等待供应商收款，释放保证金等操作。。。
                    orderManager.UpdateStatusById(orderId, Model.OrderStatus.WaitingForSellerConfirmCollection);
                    //=========================
                    //其他操作
                    System.Threading.Thread.Sleep(5);
                }
                catch (Exception ep)
                {
                    ServiceUtil.Error("ERROR:CheckGoods订单编号：" + orderId + ".", ep);
                }
            }
            ServiceUtil.Debug("执行结束验货截至日已经到达的订单");
        }

        /// <summary>
        /// 逾期未评价的订单。
        /// </summary>
        /// <param name="isPause"></param>
        private void WillBeDiscuss()
        {
            ServiceUtil.Debug("开始执行逾期未评价的订单");
            //获取评价时间已经到达的订单
            DataTable discussHasFinished = orderManager.DiscussHasFinished();

            foreach (DataRow row in discussHasFinished.Rows)
            {
                //获取评价时间已经到达的订单编号
                int orderId = XYECOM.Core.MyConvert.GetInt32(row["Id"].ToString());

                ServiceUtil.Info("操作逾期未评价的小额订单(编号" + orderId+")");
                Model.OrderInfo orderInfo = orderManager.GetItem(orderId);
                try
                {
                    Model.OrderEvaluationInfo oeInfo = new Model.OrderEvaluationInfo();
                    oeInfo.Deliverygrade = 5;
                    oeInfo.Evaluation = "供应商服务很好，产品也跟描述的一直，发货很及时，以后继续合作";
                    oeInfo.Evaluationtime = DateTime.Now;
                    oeInfo.OrderId = orderId;
                    oeInfo.Productsgrade = 5;
                    oeInfo.Servicegrade = 5;
                    oeInfo.UserId = orderInfo.BuyerId;
                    //默认好评
                    orderEvaluationManage.Insert(oeInfo);
                    //增加用户信用积分
                    new XYECOM.Business.CreditLeavlManager().AddCreditIntegral(orderInfo.SellerId, 1);
                    //其他操作
                    System.Threading.Thread.Sleep(5);
                }
                catch (Exception ep)
                {
                    ServiceUtil.Error("ERROR:Discuss订单编号为：" + orderId, ep);
                }
            }
            ServiceUtil.Debug("执行结束逾期未评价的订单");
        }

        /// <summary>
        /// 抽象方法的实现
        /// </summary>
        /// <param name="isPause"></param>
        public override void Process()
        {
            System.Threading.Thread cancel = new System.Threading.Thread(new System.Threading.ThreadStart(WillBeCancel));
            //cancel.Name = "cancel";
            System.Threading.Thread willBeCheckGoods = new System.Threading.Thread(new System.Threading.ThreadStart(WillBeCheckGoods));
            //willBeCheckGoods.Name = "willBeCheckGoods";
            System.Threading.Thread willBeDiscuss = new System.Threading.Thread(new System.Threading.ThreadStart(WillBeDiscuss));
            //willBeDiscuss.Name = "willBeDiscuss";
            System.Threading.Thread willBeFinish = new System.Threading.Thread(new System.Threading.ThreadStart(WillBeFinish));
            //willBeFinish.Name = "willBeFinish";

            System.Threading.Thread[] ts = new System.Threading.Thread[] { cancel, willBeCheckGoods, willBeDiscuss, willBeFinish };

            foreach (System.Threading.Thread td in ts)
            {
                try
                {
                    td.Start();
                }
                catch (Exception ex)
                {
                    ServiceUtil.Error("ERROR:处理小额订单信息" + td.Name, ex);
                }
            }
        }
    }
}
