using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace XYECOM.Service
{
    public class TeamOrder : BaseService
    {
        private XYECOM.Business.TeamBuyOrderManager teamBuyOrderManager = new Business.TeamBuyOrderManager();
        private XYECOM.Business.OrderEvaluationManage orderEvaluationManage = new Business.OrderEvaluationManage();
        private XYECOM.Business.CreditLeavlManager userRegManage = new Business.CreditLeavlManager();

        /// <summary>
        /// 团购结束N(N可配置)天后且该团购信息已成团未支付（未支付全款）的订单（平台将扣除已支付金额，同时取消订单）
        /// </summary>
        /// <param name="isPause"></param>
        private void WillBeCancel()
        {
            ServiceUtil.Debug("开始执行团购结束N(N可配置)天后且该团购信息已成团未支付（未支付全款）的订单");
            XYECOM.Business.AccountManager accountManager = new Business.AccountManager();

            //获取平台现金账户信息
            XYECOM.Model.AccountInfo yijiaAccount = accountManager.GetItem("ShanDongYiJia");
            if (yijiaAccount == null)
            {
                return;
            }

            List<XYECOM.Model.TeamBuyOrderInfo> list = teamBuyOrderManager.GetEndBuy();
            foreach (XYECOM.Model.TeamBuyOrderInfo teamOrder in list)
            {
                ServiceUtil.Info("操作团购结束N(N可配置)天后且该团购信息已成团未支付（未支付全款）的订单(编号" + teamOrder.Id + ")");
                try
                {
                    //获取从未支付过的团购订单信息
                    if (teamOrder.Amount == 0)
                    {
                        teamBuyOrderManager.UpdateStatusById(teamOrder.Id, XYECOM.Model.OrderStatus.CancelBySystem);
                    }

                    //获取已支付预付金，但未支付全款的团购订单信息
                    if (teamOrder.Amount > 0)
                    {
                        //将已付款打入商城账户
                        int i = accountManager.IncreaseOrDecrease(yijiaAccount.Id, teamOrder.Amount, 2);
                        if (i > 0)
                        {
                            //增加一次商城扣除已付款的明细记录
                            Model.AccountDetailsInfo DeductionMargin = new Model.AccountDetailsInfo();
                            DeductionMargin.AccountId = yijiaAccount.Id;
                            DeductionMargin.IsOnline = false;
                            DeductionMargin.Operate = (int)XYECOM.Model.AccountOperate.TeamOrderDeduction;
                            DeductionMargin.OperateDate = DateTime.Now;
                            DeductionMargin.OperateDescription = "商城于【" + DateTime.Now + "】扣除团购订单【" + teamOrder.OrderSerialNumber + "】已付款金额【" + teamOrder.Amount + "】元";
                            DeductionMargin.InputMoney = teamOrder.Amount;
                            DeductionMargin.CashAccount = teamOrder.DealSerialNumber;
                            DeductionMargin.SerialNumber = XYECOM.Business.SerialNumber.GetSerialNumber(XYECOM.Model.SerialNumberFlag.OD);
                            new Business.AccountDetailsManager().Insert(DeductionMargin);

                            //给采购商发站内信告知已付金额已被扣除
                            string title = "扣除团购订单已支付金额";
                            string content = "您的团购订单" + teamOrder.OrderSerialNumber + "因逾期不支付，系统已扣除已支付金额" + teamOrder.Amount + "元";
                            ServiceUtil.SenMessage(title, content, teamOrder.BuyerId);

                            //扣除已付款余额后进行修改团购订单支付状态已经该团购信息参团人数，销售数量
                            int j = teamBuyOrderManager.TuiKouMoney(teamOrder.Id, teamOrder.Quantity, teamOrder.TeamBuyId);
                            if (j > 0)
                            {
                                //取消订单
                                teamBuyOrderManager.UpdateStatusById(teamOrder.Id, XYECOM.Model.OrderStatus.CancelBySystem);
                            }
                        }
                    }
                    //其他操作
                    System.Threading.Thread.Sleep(5);
                }
                catch (Exception ep)
                {
                    ServiceUtil.Error("CancelBySystem团购订单编号：" + teamOrder.OrderSerialNumber + ".", ep);
                }
            }
            ServiceUtil.Debug("执行结束团购结束N(N可配置)天后且该团购信息已成团未支付（未支付全款）的订单");
        }

        /// <summary>
        /// 团购结束（N）天后且该团购信息未成团（及购买人数未到达成团人数时）系统自动退款给采购商，同时取消订单
        /// </summary>
        private void WillUnpairedgroup() 
        {
            ServiceUtil.Debug("开始执行团购结束（N）天后且该团购信息未成团（及购买人数未到达成团人数时）系统自动退款给采购商，同时取消订单");
            List<XYECOM.Model.TeamBuyOrderInfo> list = teamBuyOrderManager.GetEndUnpairedgroup();
            foreach (XYECOM.Model.TeamBuyOrderInfo teamOrder in list)
            {
                ServiceUtil.Info("操作团购结束（N）天后且该团购信息未成团（及购买人数未到达成团人数时）系统自动退款给采购商，同时取消订单(编号" + teamOrder.Id + ")");
                try
                {
                    teamBuyOrderManager.CancelOrderById(teamOrder.Id, null);
                }
                catch (Exception ep)
                {
                    ServiceUtil.Error("CancelBySystem团购订单编号：" + teamOrder.OrderSerialNumber + ".", ep);
                }
            }
            ServiceUtil.Debug("执行结束团购结束（N）天后且该团购信息未成团（及购买人数未到达成团人数时）系统自动退款给采购商，同时取消订单");
        }

        /// <summary>
        /// 团购订单采购商已付款等待供应商确认收款N天后，系统自动修改订单状态为供应商已收款
        /// </summary>
        /// <param name="isPause"></param>
        private void WillBeFinish()
        {
            ServiceUtil.Debug("开始执行团购订单采购商已付款等待供应商确认收款N天后，系统自动修改订单状态为供应商已收款");
            //获取确认收款时间已经到达的订单
            DataTable willBeFinish = teamBuyOrderManager.SelectWillBeFinished();

            foreach (DataRow row in willBeFinish.Rows)
            {                
                //获取符合条件的合同编号
                int orderId = XYECOM.Core.MyConvert.GetInt32(row["Id"].ToString());
                ServiceUtil.Info("操作团购订单采购商已付款等待供应商确认收款N天后，系统自动修改订单状态为供应商已收款(编号" + orderId + ")");
                try
                {
                    //修改合同状态为，已完成
                    teamBuyOrderManager.UpdateStatusById(orderId, Model.OrderStatus.Finish);
                    //其他操作
                    System.Threading.Thread.Sleep(5);
                }
                catch (Exception ep)
                {
                    ServiceUtil.Error("Finish团购订单编号为：" + orderId, ep);
                }
            }
            ServiceUtil.Debug("执行结束团购订单采购商已付款等待供应商确认收款N天后，系统自动修改订单状态为供应商已收款");
        }

        /// <summary>
        /// 当供应商已发货N天后采购商不确认收货的团购订单，系统自动修改订单状态为采购商已确认收货
        /// </summary>
        /// <param name="isPause"></param>
        private void WillBeCheckGoods()
        {
            ServiceUtil.Debug("开始执行当供应商已发货N天后采购商不确认收货的团购订单，系统自动修改订单状态为采购商已确认收货");
            //获取验货截至日已经到达的订单
            DataTable checkGoodsHasFinshed = teamBuyOrderManager.SelectCheckGoodsHasFinshed();

            foreach (DataRow row in checkGoodsHasFinshed.Rows)
            {                
                //获取符合条件的订单编号
                int orderId = XYECOM.Core.MyConvert.GetInt32(row["Id"].ToString());
                ServiceUtil.Info("操作当供应商已发货N天后采购商不确认收货的团购订单，系统自动修改订单状态为采购商已确认收货(编号" + orderId + ")");
                try
                {

                    teamBuyOrderManager.UpdateStatusById(orderId, XYECOM.Model.OrderStatus.WaitingForSellerConfirmCollection);

                    //其他操作
                    System.Threading.Thread.Sleep(5);
                }
                catch (Exception ep)
                {
                    ServiceUtil.Error("ERROR:CheckGoods订单编号：" + orderId + ".", ep);
                }
            }
            ServiceUtil.Debug("执行结束当供应商已发货N天后采购商不确认收货的团购订单，系统自动修改订单状态为采购商已确认收货");
        }

        /// <summary>
        /// 当团购订单已结束或等待供应商确认收款N天后采购商为评价，系统默认为好评
        /// </summary>
        /// <param name="isPause"></param>
        private void WillBeDiscuss()
        {
            ServiceUtil.Debug("开始执行当团购订单已结束或等待供应商确认收款N天后采购商为评价，系统默认为好评");
            //获取评价时间已经到达的订单
            DataTable discussHasFinished = teamBuyOrderManager.DiscussHasFinished();

            foreach (DataRow row in discussHasFinished.Rows)
            {
                //获取评价时间已经到达的订单编号
                int orderId = XYECOM.Core.MyConvert.GetInt32(row["Id"].ToString());
                ServiceUtil.Info("操作当团购订单已结束或等待供应商确认收款N天后采购商为评价，系统默认为好评(编号" + orderId + ")");
                Model.TeamBuyOrderInfo orderInfo = teamBuyOrderManager.GetItem(orderId);
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
                    oeInfo.OrderType = 1;
                    //默认好评
                    orderEvaluationManage.Insert(oeInfo);
                    //增加用户信用积分
                    userRegManage.AddCreditIntegral(orderInfo.SellerId, 1);
                    //其他操作
                    System.Threading.Thread.Sleep(5);
                }
                catch (Exception ep)
                {
                    ServiceUtil.Error("Discuss团购订单编号为：" + orderId, ep);
                }
            }
            ServiceUtil.Debug("执行结束当团购订单已结束或等待供应商确认收款N天后采购商为评价，系统默认为好评");
        }

        /// <summary>
        /// 抽象方法的实现
        /// </summary>
        /// <param name="isPause"></param>
        public override void Process()
        {
            System.Threading.Thread cancel = new System.Threading.Thread(new System.Threading.ThreadStart(WillBeCancel));
            //cancel.Name = "cancel_Team";
            System.Threading.Thread willBeCheckGoods = new System.Threading.Thread(new System.Threading.ThreadStart(WillBeCheckGoods));
            //willBeCheckGoods.Name = "willBeCheckGoods_Team";
            System.Threading.Thread willBeDiscuss = new System.Threading.Thread(new System.Threading.ThreadStart(WillBeDiscuss));
            //willBeDiscuss.Name = "willBeDiscuss_Team";
            System.Threading.Thread willBeFinish = new System.Threading.Thread(new System.Threading.ThreadStart(WillBeFinish));
            //willBeFinish.Name = "willBeFinish_Team";
            System.Threading.Thread willUnpairedgroup = new System.Threading.Thread(new System.Threading.ThreadStart(WillUnpairedgroup));
            //willBeFinish.Name = "willUnpairedgroup_Team";
            System.Threading.Thread[] ts = new System.Threading.Thread[] { cancel, willBeCheckGoods, willBeDiscuss, willBeFinish, willUnpairedgroup };

            foreach (System.Threading.Thread td in ts)
            {
                try
                {
                    td.Start();
                }
                catch (Exception ex)
                {
                    ServiceUtil.Error("ERROR:处理团购订单信息" + td.Name, ex);
                }
            }
        }
    }
}
