using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using XYECOM.Model;

namespace XYECOM.Web.xymanage.News
{
    public partial class AddNewsInfoList : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected override void BindData()
        {
            string name = this.txtName.Text.Trim();
            int totalRecord = 0;
            string strWhere = "";
            string PorductTypeId = hidTypeId.Value;

            if (PorductTypeId !="")
            {
                strWhere = " (UI_Name like '%" + name + "%' or U_Name like '%" + name + "%' or SD_Title like '%" + name + "%') and PT_ID=" + PorductTypeId;
            }
            else if(!string.IsNullOrEmpty(name))
            {
                strWhere = " UI_Name like '%" + name + "%' or U_Name like '%" + name + "%' or SD_Title like '%" + name + "%'";
            }

            DataTable dt = XYECOM.Business.Utils.GetPaginationData("xyv_Supply", "SD_ID", "SD_ID,PT_Name,SD_Title,UI_Name,U_Name", "SD_ID desc", strWhere, this.Page1.PageSize, this.Page1.CurPage, out totalRecord);

            this.txtName.Text = "";
            this.Page1.RecTotal = totalRecord;

            this.rptList.DataSource = dt;
            this.rptList.DataBind();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Page1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

    }
}