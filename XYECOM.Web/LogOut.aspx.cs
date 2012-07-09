using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYECOM.Page;

namespace XYECOM.Web
{
    public partial class LogOut : ForeBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XYECOM.Core.Utils.ClearCookie("U_Name", webInfo.CookieDomain);
            XYECOM.Core.Utils.ClearCookie("U_ID", webInfo.CookieDomain);
            //New Cookie
            XYECOM.Core.Utils.ClearCookie("UserId", webInfo.CookieDomain);
            XYECOM.Core.Utils.ClearCookie("UserType", webInfo.CookieDomain);

            XYECOM.Core.Utils.ClearCookie("sex", webInfo.CookieDomain);
            XYECOM.Core.Utils.ClearCookie("CompanyName", webInfo.CookieDomain);
            XYECOM.Core.Utils.ClearCookie("UserName", webInfo.CookieDomain);
            XYECOM.Core.Utils.ClearCookie("PassWord", webInfo.CookieDomain);
            XYECOM.Core.Utils.ClearCookie("UserLevel", webInfo.CookieDomain);
            XYECOM.Core.Utils.ClearCookie("UserLevelImg", webInfo.CookieDomain);


            //清楚 session
            XYECOM.Core.Utils.ClearSession("UserInfo");
            
            Response.Redirect("/Login.aspx");
        }
    }
}