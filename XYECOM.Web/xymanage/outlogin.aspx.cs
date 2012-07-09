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
using XYECOM.Core;

public partial class xymanage_outlogin : XYECOM.Web.BasePage.ManagePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["A_Name"] = null;
        Session["UM_ID"] = null;

        Utils.ClearCookie("AdminId", webInfo.CookieDomain);
        Utils.ClearCookie("AdminName", webInfo.CookieDomain);

        Utils.ClearCookie("A_Name", webInfo.CookieDomain);
        Utils.ClearCookie("U_ID", webInfo.CookieDomain);
        Utils.ClearCookie("sex", webInfo.CookieDomain);
        Utils.ClearCookie("CompanyName", webInfo.CookieDomain);
        Utils.ClearCookie("U_Name", webInfo.CookieDomain);
        this.Response.Redirect("login.aspx");
    }
}
