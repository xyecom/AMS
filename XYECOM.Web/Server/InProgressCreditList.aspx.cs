using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using XYECOM.Core;
using System.Data;

namespace XYECOM.Web.Server
{
    public partial class InProgressCreditList : XYECOM.Web.AppCode.UserCenter.Server
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected override void BindData()
        {
            this.lblMessage.Text = "";
            string title = this.txtTitle.Text.Trim();
            string arrears = this.drpArrears.SelectedValue;
            StringBuilder strWhere = new StringBuilder(" 1=1 and (AreaId = " + userinfo.AreaId + ")");
            if (arrears != "所有")
            {
                if (arrears == "小于1万")
                {
                    strWhere.Append(" and ( Arrears <=10000)");
                }
                else if (arrears == "大于1万小于5万")
                {
                    strWhere.Append(" and (Arrears<=50000 and Arrears>=10000)");
                }
                else if (arrears == "大于5万小于10万")
                {
                    strWhere.Append(" and (Arrears<=100000 and Arrears>=50000)");
                }
                else if (arrears == "大于10万")
                {
                    strWhere.Append(" and (Arrears>=100000)");
                }
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
    }
}