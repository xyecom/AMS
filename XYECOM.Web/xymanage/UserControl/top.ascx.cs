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

public partial class xymanage_UserControl_top : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["A_Name"] != null && Session["A_Name"].ToString() != "")
            {
                this.lblAdminName.Text = Session["A_Name"].ToString();
            }
        }
    }
}
