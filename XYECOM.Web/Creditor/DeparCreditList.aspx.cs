using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using XYECOM.Core;
using System.Data;
using XYECOM.Business.AMS;

namespace XYECOM.Web.Creditor
{
    public partial class DeparCreditList : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        protected CreditInfoManager manage = new CreditInfoManager();

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
                strWhere.Append(" and (ApprovaStatus = " + state + ")");
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
                strWhere.Append(" and (Title like '%" + title + "%')");
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

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)(sender as LinkButton);
            if (linkButton != null)
            {
                int Id = MyConvert.GetInt32(linkButton.CommandArgument);
                if (Id > 0)
                {
                    int result = manage.UpdateApprovaStatusByID(Id, XYECOM.Model.CreditState.Delete);
                    if (result > 0)
                    {
                        BindData();
                    }
                }
            }
        }

        /// <summary>
        /// 发布案件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnRelease_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)(sender as LinkButton);
            if (linkButton != null)
            {
                int Id = MyConvert.GetInt32(linkButton.CommandArgument);
                if (Id > 0)
                {
                    int result = manage.UpdateApprovaStatusByID(Id, XYECOM.Model.CreditState.Null);
                    if (result > 0)
                    {
                        BindData();
                    }
                }
            }
        }

        /// <summary>
        /// 取消案件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnCancel_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)(sender as LinkButton);
            if (linkButton != null)
            {
                int Id = MyConvert.GetInt32(linkButton.CommandArgument);
                if (Id > 0)
                {
                    int result = manage.UpdateApprovaStatusByID(Id, XYECOM.Model.CreditState.Canceled);
                    if (result > 0)
                    {
                        BindData();
                    }
                }
            }
        }


        /// <summary>
        /// 关闭案件操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnClose_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)(sender as LinkButton);
            if (linkButton != null)
            {
                int Id = MyConvert.GetInt32(linkButton.CommandArgument);
                if (Id > 0)
                {
                    int result = manage.UpdateApprovaStatusByID(Id, XYECOM.Model.CreditState.CreditEnd);
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
                HiddenField hidState = (HiddenField)e.Item.FindControl("hidState");//当前案件状态
                if (hidState == null) return;

                HiddenField hidIsCreditEvaluation = (HiddenField)e.Item.FindControl("hidIsCreditEvaluation");//当前债权商是否已评价
                if (hidIsCreditEvaluation == null) return;
                bool isCreditEvaluation = MyConvert.GetBoolean(hidIsCreditEvaluation.Value);

                int stateId = MyConvert.GetInt32(hidState.Value);


                HyperLink hlUpdate = (HyperLink)e.Item.FindControl("hlUpdate");//修改债权信息
                HyperLink hlShowTender = (HyperLink)e.Item.FindControl("hlShowTender");//查看竞标
                HyperLink hlEvaluate = (HyperLink)e.Item.FindControl("hlEvaluate");//评价         
                LinkButton lbtnCancel = (LinkButton)e.Item.FindControl("lbtnCancel");//取消债权信息
                LinkButton lbtnClosed = (LinkButton)e.Item.FindControl("lbtnClosed");//关闭债权信息
                LinkButton lbtnRelease = (LinkButton)e.Item.FindControl("lbtnRelease");//发布债权信息
                LinkButton lbtnDelete = (LinkButton)e.Item.FindControl("lbtnDelete");//删除债权信息                

                Model.CreditState sta = (Model.CreditState)stateId;

                switch (sta)
                {
                    case Model.CreditState.Draft:
                        hlUpdate.Visible = true;
                        lbtnRelease.Visible = true;
                        lbtnDelete.Visible = true;
                        hlShowTender.Visible = false;
                        hlEvaluate.Visible = false;
                        lbtnCancel.Visible = false;
                        lbtnClosed.Visible = false;
                        break;
                    case Model.CreditState.Null:
                        hlUpdate.Visible = true;
                        lbtnRelease.Visible = false;
                        lbtnDelete.Visible = true;
                        hlShowTender.Visible = false;
                        hlEvaluate.Visible = false;
                        lbtnCancel.Visible = false;
                        lbtnClosed.Visible = false;
                        break;
                    case Model.CreditState.NoPass:
                        hlUpdate.Visible = true;
                        lbtnRelease.Visible = false;
                        lbtnDelete.Visible = true;
                        hlShowTender.Visible = false;
                        hlEvaluate.Visible = false;
                        lbtnCancel.Visible = false;
                        lbtnClosed.Visible = false;
                        break;
                    case Model.CreditState.Tender:
                        hlUpdate.Visible = false;
                        lbtnRelease.Visible = false;
                        lbtnDelete.Visible = false;
                        hlShowTender.Visible = true;
                        hlEvaluate.Visible = false;
                        lbtnCancel.Visible = true;
                        lbtnClosed.Visible = false;
                        break;
                    case Model.CreditState.InProgress:
                        hlUpdate.Visible = false;
                        lbtnRelease.Visible = false;
                        lbtnDelete.Visible = false;
                        hlShowTender.Visible = false;
                        hlEvaluate.Visible = false;
                        lbtnCancel.Visible = true;
                        lbtnClosed.Visible = false;
                        break;
                    case Model.CreditState.CreditConfirm:
                        hlUpdate.Visible = false;
                        lbtnRelease.Visible = false;
                        lbtnDelete.Visible = false;
                        hlShowTender.Visible = true;
                        hlEvaluate.Visible = false;
                        lbtnCancel.Visible = false;
                        lbtnClosed.Visible = true;
                        break;
                    case Model.CreditState.CreditEnd:
                        hlUpdate.Visible = false;
                        lbtnRelease.Visible = false;
                        lbtnDelete.Visible = false;
                        hlShowTender.Visible = true;
                        if (isCreditEvaluation)
                        {
                            hlEvaluate.Visible = false;
                        }
                        else
                        {
                            hlEvaluate.Visible = true;
                        }
                        lbtnCancel.Visible = false;
                        lbtnClosed.Visible = false;
                        break;
                    case Model.CreditState.Canceled:
                        hlUpdate.Visible = true;
                        lbtnRelease.Visible = true;
                        lbtnDelete.Visible = true;
                        hlShowTender.Visible = false;
                        hlEvaluate.Visible = false;
                        lbtnCancel.Visible = false;
                        lbtnClosed.Visible = false;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 根据债权信息ID获取该债权信息的投标个数
        /// </summary>
        /// <param name="CreditID"></param>
        /// <returns></returns>
        public int GetTenderCountByCreditID(object CreditID)
        {
            int id = MyConvert.GetInt32(CreditID.ToString());
            return new TenderInfoManager().GetTenderCountByCreditID(id);
        }
    }
}