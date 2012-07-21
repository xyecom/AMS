using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYECOM.Page;

namespace XYECOM.Web
{
    public partial class Activation : ForeBasePage
    {
        protected string usernames = string.Empty;
        protected string usermail = string.Empty;
        protected string useractivation = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (XYECOM.Core.XYRequest.GetQueryString("c").ToString() != "")
            {
                string code = XYECOM.Core.XYRequest.GetQueryString("c");

                XYECOM.Business.UserReg userRegBLL = new XYECOM.Business.UserReg();

                XYECOM.Model.UserRegInfo info = userRegBLL.GetUserCode(code);
                if (info != null)
                {
                    //已经激活
                    usernames = info.LoginName;
                    usermail = info.Email;
                    if (info.IsActivation)
                    {
                        useractivation = "用户已经激活！";
                    }
                    else
                    {
                        if (userRegBLL.UserActivation(code) > 0)
                        {
                            useractivation = "激活成功！";
                        }
                    }
                }
                else
                {
                    useractivation = "激活码不存在！请验证您的url是否正确！";
                }
            }
            else
            {
                useractivation = "激活码不存在！请验证您的url是否正确！";
            }
            this.lblUserName.Text = usernames;
            this.lblEmail.Text = usermail;
            this.lblResult.Text = useractivation;
        }
    }
}