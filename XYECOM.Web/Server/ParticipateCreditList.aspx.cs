using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using XYECOM.Core;
using System.Data;
using XYECOM.Model.AMS;
using XYECOM.Business.AMS;

namespace XYECOM.Web.Server
{
    public partial class ParticipateCreditList : XYECOM.Web.AppCode.UserCenter.Server
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected override void BindData()
        {
            this.lblMessage.Text = "";
            string title = this.txtTitle.Text.Trim();
            string begindate = this.bgdate.Value;
            string enddate = this.egdate.Value;
            int state = MyConvert.GetInt32(this.drpState.SelectedValue);
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
            StringBuilder strWhere = new StringBuilder(" 1=1 and LayerId = " + userinfo.userid);
            //开始日期
            if (begindate != "")
            {
                strWhere.Append(" and (TenderDate >= '" + begindate + "')");
            }
            //结束日期
            if (enddate != "")
            {
                strWhere.Append(" and (TenderDate <= '" + enddate + "')");
            }
            if (!string.IsNullOrEmpty(title))
            {
                strWhere.Append(" and CreditInfoId in (select creditId from dbo.CreditInfo where Title like '%" + title + "%')");
            }
            if (state == -2)
            {
                strWhere.Append(" and  CreditInfoId in (select creditId from dbo.CreditInfo where ApprovaStatus !=7)");
            }
            else
            {
                strWhere.Append(" and  CreditInfoId in (select creditId from dbo.CreditInfo where ApprovaStatus = " + state + ")");                
            }
            int totalRecord = 0;
            DataTable dt = XYECOM.Business.Utils.GetPaginationData("TenderInfo", "TenderId", "*", " TenderDate desc", strWhere.ToString(), this.Page1.PageSize, this.Page1.CurPage, out totalRecord);
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

        /// <summary>
        /// 根据债权ID获取债权信息
        /// </summary>
        /// <param name="credID"></param>
        /// <returns></returns>
        public CreditInfo GetCreditInfoByCredID(object credID)
        {
            int id = XYECOM.Core.MyConvert.GetInt32(credID.ToString());
            CreditInfo info = new CreditInfo();
            if (id <= 0)
            {
                return info;
            }
            return new CreditInfoManager().GetCreditInfoById(id);
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
        /// 根据债权编号获取债权状态
        /// </summary>
        /// <param name="credID"></param>
        /// <returns></returns>
        protected string GetApprovaStatus(object credID)
        {
            int id = MyConvert.GetInt32(credID.ToString());
            CreditInfo info = this.GetCreditInfoByCredID(id);
            int stateId = MyConvert.GetInt32(info.ApprovaStatus.ToString());
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

        /// <summary>
        /// 获取投标状态
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        protected string GetTenderState(object stateId)
        {
            Model.AMS.TenderState sta = (Model.AMS.TenderState)stateId;
            string name = "";
            switch (sta)
            {
                case TenderState.Failure:
                    name = "未中标";
                    break;
                case TenderState.Success:
                    name = "中标";
                    break;
                case TenderState.Tender:
                    name = "投标中";
                    break;
            }
            return name;
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hidTenderId = (HiddenField)e.Item.FindControl("hidTenderId");//当前投标编号
                if (hidTenderId == null) return;
                int tenderId = MyConvert.GetInt32(hidTenderId.Value);
                TenderInfo tenderInfo = new TenderInfoManager().GetTenderInfoByID(tenderId);
                if (tenderInfo == null)
                {
                    return;
                }

                if (tenderInfo.IsSuccess != (int)TenderState.Success)
                {
                    return;
                }

                HiddenField hidCreditId = (HiddenField)e.Item.FindControl("hidCreditInfoId");//当前案件编号
                if (hidCreditId == null) return;
                int creditId = MyConvert.GetInt32(hidCreditId.Value);
                CreditInfo info = new CreditInfoManager().GetCreditInfoById(creditId);

                int stateId = info.ApprovaStatus;
                HyperLink hlEvaluate = (HyperLink)e.Item.FindControl("hlEvaluate");//评价          

                LinkButton lbtnCreditConfirm = (LinkButton)e.Item.FindControl("lbtnCreditConfirm");//服务商确认案件完成          

                Model.CreditState sta = (Model.CreditState)stateId;
                if (sta == Model.CreditState.CreditEnd && !info.IsServerEvaluation)
                {
                    hlEvaluate.Visible = true;
                }
                else
                {
                    hlEvaluate.Visible = false;
                }
                if (sta == Model.CreditState.InProgress)
                {
                    lbtnCreditConfirm.Visible = true;
                }
                else
                {
                    lbtnCreditConfirm.Visible = false;
                }
            }
        }

        /// <summary>
        /// 服务商确认案件完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnCreditConfirm_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)(sender as LinkButton);
            if (linkButton != null)
            {
                int Id = XYECOM.Core.MyConvert.GetInt32(linkButton.CommandArgument);
                if (Id > 0)
                {
                    CreditInfoManager credManage = new CreditInfoManager();
                    int result = credManage.UpdateApprovaStatusByID(Id, XYECOM.Model.CreditState.CreditConfirm);
                    if (result > 0)
                    {
                        BindData();
                    }
                }
            }
        }

    }
}