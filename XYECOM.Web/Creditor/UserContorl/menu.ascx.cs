using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XYECOM.Web.Creditor.UserContorl
{
    public partial class menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.liPart.Visible = false;
            if (XYECOM.Business.CheckUser.UserInfo != null)
            {
                if (XYECOM.Business.CheckUser.UserInfo.IsPrimary && XYECOM.Business.CheckUser.UserInfo.UserType == Model.UserType.CreditorEnterprise)
                {
                    this.liPart.Visible = true;

                    string sql = "select layername,u_id from u_user where CompanyId=" + XYECOM.Business.CheckUser.UserInfo.userid + " and isprimary = 0";
                    DataTable dt = XYECOM.Core.Data.SqlHelper.ExecuteTable(sql);

                    this.rptPart.DataSource = dt;
                    this.rptPart.DataBind();

                }
            }
        }
    }
}