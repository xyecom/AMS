using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XYECOM.Web.Other.UserContorl
{
    public partial class ModifyPwd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!XYECOM.Business.CheckUser.CheckUserLogin())
            {
                Response.Redirect("/Login.aspx");
                return;
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            XYECOM.Business.UserReg userRegBLL = new XYECOM.Business.UserReg();

            Model.GeneralUserInfo guInfo = XYECOM.Business.CheckUser.UserInfo;


            string oldPwd = Core.SecurityUtil.MD5(this.txtOldPwd.Text, XYECOM.Configuration.Security.Instance.Md5value);
            Model.UserRegInfo regInfo = userRegBLL.GetItem(guInfo.LoginName, oldPwd);
            if (regInfo == null)
            {
                //密码错误
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('密码错误，请重试！');", true);
                return;
            }

            int num = userRegBLL.UpdatePassWord(guInfo.userid, Core.SecurityUtil.MD5(this.txtNewPwd.Text, XYECOM.Configuration.Security.Instance.Md5value));
            this.txtNewPwd.Text = string.Empty;
            this.txtNewPwd1.Text = string.Empty;
            this.txtOldPwd.Text = string.Empty;
            if (num > 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('保存成功，重新登录！');location.href='/LogOut.aspx';", true);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('保存失败，请重试！');", true);
            }
        }
    }
}