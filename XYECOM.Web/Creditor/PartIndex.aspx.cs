using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace XYECOM.Web.Creditor
{
    public partial class PartIndex : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page1_PageChanged(object sender, System.EventArgs e)
        {
            this.BindZqInfo();
        }

        protected override void BindData()
        {
            BindOtherInfo();
            BindZqInfo();
        }

        void BindOtherInfo()
        {
            this.ltlFzeEmail.Text = userinfo.Email;
            this.ltlFzeTel.Text = userinfo.Telphone;
            this.ltlFzr.Text = userinfo.PartManagerName;
            this.ltlPaartName.Text = userinfo.LayerName;
        }


        void BindZqInfo()
        {
            this.lblMessage.Text = "";
            string arrears = this.ddlState.SelectedValue;
            string title = this.txtKey.Value.Trim();
            StringBuilder strWhere = new StringBuilder(" 1=1");

            if (!string.IsNullOrEmpty(title))
            {
                strWhere.Append(" and (Title like '%" + title + "%')");
            }

            if (!string.IsNullOrEmpty(arrears))
            {
                strWhere.Append(" and (ApprovaStatus=" + arrears + ")");
            }

            int totalRecord = 0;
            DataTable dt = XYECOM.Business.Utils.GetPaginationData("CreditInfo", "CreditId", "*", " CreateDate desc", strWhere.ToString(), this.page1.PageSize, this.page1.CurPage, out totalRecord);
            this.page1.RecTotal = totalRecord;
            if (totalRecord <= this.page1.PageSize)
            {
                this.page1.Visible = false;
            }
            if (totalRecord > 0)
            {
                this.dlCreditList.DataSource = dt;
                this.dlCreditList.DataBind();
            }
            else
            {
                this.lblMessage.Text = "没有相关信息记录";
                this.page1.Visible = false;

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindZqInfo();
        }
    }
}