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
    public partial class DraftCreditList : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        protected CreditInfoManager manage = new CreditInfoManager();
        protected TenderInfoManager tenderManage = new TenderInfoManager();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected override void BindData()
        {
            this.lblMessage.Text = "";
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
            StringBuilder strWhere = new StringBuilder(" 1=1 and (DepartId = " + userinfo.userid + ") and (ApprovaStatus = 0)");

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
                        tenderManage.DeleteByCreID(Id);
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
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbtnRelease = (LinkButton)e.Item.FindControl("lbtnRelease");//发布债权信息

                if (userinfo.IsReal)
                {
                    lbtnRelease.Visible = true;
                }
                else
                {
                    lbtnRelease.Visible = false;
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