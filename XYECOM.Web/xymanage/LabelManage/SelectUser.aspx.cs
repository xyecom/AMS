using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XYECOM.Web.xymanage.LabelManage
{
    public partial class SelectUser : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void BindData()
        {
            string name = this.txtName.Text.Trim();
            int totalRecord = 0;
            string strWhere = "";

            if (!string.IsNullOrEmpty(name)) 
            {
                strWhere = " u_name like '" + name + "%' or u_email like '" + name + "%' or ui_name like '" + name + "%'";
            }
            DataTable dt = XYECOM.Business.Utils.GetPaginationData("u_user inner join u_userinfo on u_user.u_id=u_userinfo.u_id", "u_user.u_id", "u_user.u_id,u_name,u_email,ui_name", "u_user.u_id desc", strWhere, this.Page1.PageSize, this.Page1.CurPage, out totalRecord);

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