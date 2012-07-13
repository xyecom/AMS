using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace XYECOM.Web.Creditor
{
    public partial class ForeclosedList : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        protected XYECOM.Business.AMS.ForeclosedManager manage = new Business.AMS.ForeclosedManager();

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected override void BindData()
        {
            string typeName = this.droTypeName.SelectedValue;
            string title = this.txtTitle.Text.Trim();

            this.lblMessage.Text = "";

            StringBuilder strWhere = new StringBuilder(" 1=1 and (DepartmentId = " + userinfo.userid + ")");
            if (!string.IsNullOrEmpty(typeName) && typeName != "所有")
            {
                strWhere.Append(" and (ForeColseTypeName like '%" + typeName + "%')");
            }
            if (!string.IsNullOrEmpty(title))
            {
                strWhere.Append(" and (Title like '%" + title + "%')");
            }
            int totalRecord = 0;
            DataTable dt = XYECOM.Business.Utils.GetPaginationData("ForeclosedInfo", "ForeclosedId", "*", " CreateDate desc", strWhere.ToString(), this.Page1.PageSize, this.Page1.CurPage, out totalRecord);
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
    }
}