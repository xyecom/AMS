using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using XYECOM.Core;
using System.Data;

namespace XYECOM.Web.Creditor
{
    public partial class CreditInfoList : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        protected XYECOM.Business.AMS.CreditInfoManager manage = new Business.AMS.CreditInfoManager();

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected override void BindData()
        {
            this.lblMessage.Text = "";
            int state = MyConvert.GetInt32(this.drpState.SelectedValue);
            string title = this.txtTitle.Text.Trim();
            string begindate = this.bgdate.Value;
            string enddate = this.egdate.Value;
            try
            {
                DateTime bgdate = Convert.ToDateTime(begindate);
            }
            catch (Exception)
            {
                begindate = "";
            }
            try
            {
                DateTime eddate = Convert.ToDateTime(enddate);
            }
            catch (Exception)
            {
                enddate = "";
            }
            StringBuilder strWhere = new StringBuilder(" 1=1 and (DepartId = " + userinfo.userid + ")");
            if (state == -2)
            {
                strWhere.Append(" and ( ApprovaStatus ! =7)");
            }
            else
            {
                strWhere.Append(" and (ApprovaStatus = )" + state);
            }

            //开始日期
            if (begindate != "")
            {
                strWhere.Append(" and (CreateDate >= '" + begindate + "')");
            }
            //结束日期
            if (enddate != "")
            {
                strWhere.Append(" and (CreateDate <= '" + enddate + "')");
            }

            if (!string.IsNullOrEmpty(title))
            {
                strWhere.Append(" and (Title Title '%" + title + "%')");
            }
            int totalRecord = 0;
            DataTable dt = XYECOM.Business.Utils.GetPaginationData("CreditInfo", "CreditId", "*", " CreateDate desc", strWhere.ToString(), this.Page1.PageSize, this.Page1.CurPage, out totalRecord);
            this.Page1.RecTotal = totalRecord;

            if (dt.Rows.Count > 0)
            {
                this.rptList.DataSource = dt;
                this.rptList.DataBind();
            }
            else
            {
                this.lblMessage.Text = "没有相关信息记录";
                this.rptList.DataBind();
            }
        }

        #region 分页相关代码

        protected void Page1_PageChanged(object sender, System.EventArgs e)
        {
            this.BindData();
        }
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)(sender as LinkButton);
            if (linkButton != null)
            {
                int Id = XYECOM.Core.MyConvert.GetInt32(linkButton.CommandArgument);
                if (Id > 0)
                {
                    int result = new Business.AMS.ForeclosedManager().Delete(Id);
                    if (result > 0)
                    {
                        BindData();
                    }
                }
            }
        }

        public string GetEndDate(object endDate)
        {
            DateTime date = XYECOM.Core.MyConvert.GetDateTime(endDate.ToString());
            if (date.CompareTo(DateTime.Now) < 0)
            {
                return "已过期";
            }
            else
            {
                return date.ToString("yyyy-MM-dd");
            }
        }

        protected void lbtnClose_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)(sender as LinkButton);
            if (linkButton != null)
            {
                int Id = XYECOM.Core.MyConvert.GetInt32(linkButton.CommandArgument);
                if (Id > 0)
                {
                    int result = new Business.AMS.ForeclosedManager().ClosedByID(Id);
                    if (result > 0)
                    {
                        BindData();
                    }
                }
            }
        }
        protected string GetApprovaStatus(object state)
        {
            int stateId = MyConvert.GetInt32(state.ToString());
            Model.CreditState sta = (Model.CreditState)stateId;
            string name = "";
            switch (sta)
            {
                case XYECOM.Model.CreditState.Draft:
                    name = "草稿";
                    break;
                case XYECOM.Model.CreditState.Null:
                    name = "未审核";
                    break;
                case XYECOM.Model.CreditState.NoPass:
                    name = "审核未通过";
                    break;
                case XYECOM.Model.CreditState.Tender:
                    name = "投标中";
                    break;
                case XYECOM.Model.CreditState.InProgress:
                    name = "案件进行中";
                    break;
                case XYECOM.Model.CreditState.CreditConfirm:
                    name = "服务商案件完成等待债权人确认";
                    break;
                case XYECOM.Model.CreditState.CreditEnd:
                    name = "案件结束";
                    break;
                case XYECOM.Model.CreditState.Canceled:
                    name = "债权人取消案件";
                    break;
            }
            return name;
        }
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hidInfoId = (HiddenField)e.Item.FindControl("hidInfoId");//当前案件编号
                if (hidInfoId == null) return;
                int creditId = MyConvert.GetInt32(hidInfoId.Value);

                HiddenField hidState = (HiddenField)e.Item.FindControl("hidState");//当前案件状态
                if (hidState == null) return;
                int stateId = MyConvert.GetInt32(hidState.Value);

                HyperLink hlPayment = (HyperLink)e.Item.FindControl("hlPayment");//立即支付
                HyperLink hlDeliveryOrder = (HyperLink)e.Item.FindControl("hlDeliveryOrder");//生成提单
                HyperLink hlInspectionObjection = (HyperLink)e.Item.FindControl("hlInspectionObjection");//验货异议
                HyperLink hlOrderDiscuss = (HyperLink)e.Item.FindControl("hlOrderDiscuss");//评价
                HyperLink hlInspectionConfirm = (HyperLink)e.Item.FindControl("hlInspectionConfirm");//验货确认
                LinkButton lbtnCancel = (LinkButton)e.Item.FindControl("lbtnCancel");//取消订单
                HyperLink hlLogisticsInfo = (HyperLink)e.Item.FindControl("hlLogisticsInfo");//查看物流信息
                HyperLink hlFeedback = (HyperLink)e.Item.FindControl("hlFeedback");//投诉

                Model.CreditState sta = (Model.CreditState)stateId;

                switch (sta)
                {
                    case XYECOM.Model.OrderStatus.WaitingForBuyerPayment:

                        lbtnCancel.Visible = true;

                        hlDeliveryOrder.Visible = false;
                        hlInspectionObjection.Visible = false;
                        hlFeedback.Visible = false;
                        hlOrderDiscuss.Visible = false;
                        hlInspectionConfirm.Visible = false;
                        hlLogisticsInfo.Visible = false;
                        break;
                    case XYECOM.Model.OrderStatus.WaitingBuyerCheckGoods:
                        hlPayment.Visible = false;
                        lbtnCancel.Visible = false;

                        hlDeliveryOrder.Visible = false;
                        hlInspectionObjection.Visible = true;
                        hlFeedback.Visible = true;
                        hlOrderDiscuss.Visible = false;
                        hlInspectionConfirm.Visible = true;
                        hlLogisticsInfo.Visible = true;
                        break;
                    case XYECOM.Model.OrderStatus.WaitingBuyerGeneralDeliveryOrder:
                        hlPayment.Visible = false;
                        lbtnCancel.Visible = false;
                        hlLogisticsInfo.Visible = false;
                        hlDeliveryOrder.Visible = true;
                        hlInspectionObjection.Visible = false;
                        hlFeedback.Visible = false;
                        hlOrderDiscuss.Visible = false;
                        hlInspectionConfirm.Visible = false;
                        break;
                    case XYECOM.Model.OrderStatus.WaitingSellerCheckDeliveryOrder:
                        hlPayment.Visible = false;
                        lbtnCancel.Visible = false;

                        hlDeliveryOrder.Visible = false;

                        hlInspectionObjection.Visible = false;
                        hlFeedback.Visible = false;
                        hlOrderDiscuss.Visible = false;
                        hlInspectionConfirm.Visible = false;

                        hlLogisticsInfo.Visible = false;
                        break;
                    case XYECOM.Model.OrderStatus.WaitingSellerSendGoods:
                        hlPayment.Visible = false;
                        lbtnCancel.Visible = false;

                        hlDeliveryOrder.Visible = false;
                        hlInspectionObjection.Visible = false;
                        hlFeedback.Visible = false;
                        hlOrderDiscuss.Visible = false;
                        hlInspectionConfirm.Visible = false;
                        hlLogisticsInfo.Visible = false;
                        break;
                    case XYECOM.Model.OrderStatus.WaitingForBuyerCheckGoodsObjection:
                        hlPayment.Visible = false;
                        lbtnCancel.Visible = false;

                        hlDeliveryOrder.Visible = false;
                        hlInspectionObjection.Visible = false;
                        hlFeedback.Visible = false;
                        hlOrderDiscuss.Visible = false;
                        hlInspectionConfirm.Visible = true;
                        hlLogisticsInfo.Visible = true;
                        break;
                    case XYECOM.Model.OrderStatus.WaitingForSellerConfirmCollection:
                        hlPayment.Visible = false;
                        lbtnCancel.Visible = false;
                        hlLogisticsInfo.Visible = true;
                        hlDeliveryOrder.Visible = false;
                        hlInspectionObjection.Visible = false;
                        hlFeedback.Visible = false;
                        hlOrderDiscuss.Visible = true;
                        hlInspectionConfirm.Visible = false;
                        break;
                    case XYECOM.Model.OrderStatus.Finish:
                        hlLogisticsInfo.Visible = true;
                        hlPayment.Visible = false;
                        lbtnCancel.Visible = false;

                        hlDeliveryOrder.Visible = false;
                        hlInspectionObjection.Visible = false;
                        hlFeedback.Visible = false;
                        hlOrderDiscuss.Visible = true;
                        hlInspectionConfirm.Visible = false;
                        break;
                    case XYECOM.Model.OrderStatus.Lock:
                    case XYECOM.Model.OrderStatus.CancelByBuyer:
                    case XYECOM.Model.OrderStatus.CancelBySupplier:
                    case XYECOM.Model.OrderStatus.CancelBySystem:
                        hlLogisticsInfo.Visible = false;
                        hlPayment.Visible = false;
                        lbtnCancel.Visible = false;

                        hlDeliveryOrder.Visible = false;
                        hlInspectionObjection.Visible = false;
                        hlFeedback.Visible = false;
                        hlOrderDiscuss.Visible = false;
                        hlInspectionConfirm.Visible = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}