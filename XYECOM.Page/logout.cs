using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Page
{
    /// <summary>
    /// 模板 logout.htm 代码类
    /// </summary>
    public class logout : ForeBasePage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            string backUrl = XYECOM.Core.XYRequest.GetQueryString("surl");


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

            Response.Redirect(XYECOM.Core.XYRequest.GetUrlReferrer());
        }
    }
}
