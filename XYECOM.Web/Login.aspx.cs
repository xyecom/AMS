using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYECOM.Page;

namespace XYECOM.Web
{
    public partial class Login : ForeBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = this.txtUserName.Value.Trim();
            string password = this.txtPassWord.Value.Trim();
            string code = this.txtCode.Text.Trim().ToLower();

            if (Core.Utils.GetSession("VNum") == null || Core.Utils.GetSession("VNum") == "")
            {
                lblMessage.Text = "验证码已过期！";
                return;
            }

            if (txtCode.Text.Trim().ToLower() != Core.Utils.GetSession("VNum").ToLower())
            {
                lblMessage.Text = "验证码错误！";
                return;
            }
            XYECOM.Business.UserReg userRegBLL = new XYECOM.Business.UserReg();

            XYECOM.Model.UserRegInfo userInfo = userRegBLL.Login(userName, password, true);
            if (userInfo == null)
            {
                GotoMsgBoxPageForDynamicPage("用户名或密码错误", 1, "/login.aspx");
                return;
            }

            string gotoUrl = string.Empty;
            Model.UserType userType = (Model.UserType)userInfo.UserType;
            switch (userType)
            {
                case XYECOM.Model.UserType.CreditorEnterprise:
                case XYECOM.Model.UserType.CreditorIndividual:
                    gotoUrl = "/Creditor/index.aspx";
                    break;
                case XYECOM.Model.UserType.Layer:
                case XYECOM.Model.UserType.NotLayer:
                    gotoUrl = "Server/index.aspx";
                    break;
            }
            GotoMsgBoxPageForDynamicPage("登陆成功！", 1, gotoUrl);
        }
    }
}