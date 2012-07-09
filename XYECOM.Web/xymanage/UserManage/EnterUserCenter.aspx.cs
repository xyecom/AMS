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

namespace XYECOM.Web.xymanage.UserManage
{
    public partial class EnterUserCenter : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("user");

            if (!Page.IsPostBack)
            {
                if (Core.XYRequest.GetQueryInt64("U_ID") >0)
                {
                    Enter(Core.XYRequest.GetQueryInt64("U_ID"));
                }
            }
        }

        private void Enter(long userId)
        {
            Logout();

            XYECOM.Model.UserRegInfo userInfo = new Business.UserReg().GetItem(userId);

            if (userInfo == null) return;

            XYECOM.Core.Utils.WriteCookie("U_ID", userInfo.UserId.ToString(),webInfo.CookieDomain);

            //---------------------新Cookie--------------------------------------
            XYECOM.Core.Utils.WriteCookie("UserId", userInfo.UserId.ToString(), webInfo.CookieDomain);
            //用户所在组
            XYECOM.Core.Utils.WriteCookie("UserGradeId", userInfo.GradeId.ToString(), webInfo.CookieDomain);
            //---------------------------------------------------------------------

            string strUserType = "user";
            
            XYECOM.Core.Utils.WriteCookie("U_Name", userInfo.LoginName.ToString(), webInfo.CookieDomain);
            XYECOM.Core.Utils.WriteCookie("UserName", userInfo.LoginName.ToString(), webInfo.CookieDomain);
            XYECOM.Core.Utils.WriteCookie("PassWord", userInfo.Password, webInfo.CookieDomain);
            XYECOM.Core.Utils.WriteCookie("UserType", strUserType, webInfo.CookieDomain);

            Response.Redirect(webInfo.WebDomain + "user/index." + webInfo.WebSuffix);
        }

        private void Logout()
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
        }
    }
}
