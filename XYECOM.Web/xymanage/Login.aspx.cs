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

namespace XYECOM.Web.xymanage
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, ImageClickEventArgs e)
        {
            string userName = this.txtUserName.Text.Trim();
            string password = this.txtPassWord.Text.Trim();
            string code = this.txtCode.Text.Trim().ToLower();

            if (userName == "" || password == "" || code == "")
            {
                this.ClientScript.RegisterClientScriptBlock(GetType(), "01", "<script>alertmsg(\"用户名、密码、验证码必须填写！ \")</script>");
                return;
            }

            if (Core.Utils.GetSession("VNum") == null || Core.Utils.GetSession("VNum") == "")
            {
                this.ClientScript.RegisterClientScriptBlock(GetType(), "01", "<script>alertmsg(\"验证码过期！ \")</script>");
                return;
            }

            if (txtCode.Text.Trim().ToLower() != Core.Utils.GetSession("VNum").ToLower())
            {
                this.ClientScript.RegisterClientScriptBlock(GetType(), "01", "<script>alertmsg(\"验证码错误！ \")</script>");
                return;
            }

            XYECOM.Business.Admin adminBLL = new XYECOM.Business.Admin();
            int err = adminBLL.isMyUser(txtUserName.Text.Trim(), XYECOM.Core.SecurityUtil.MD5(txtPassWord.Text.Trim(), XYECOM.Configuration.Security.Instance.Md5value));

            if (err > 0)
            {
                XYECOM.Model.AdminInfo adminInfo = adminBLL.GetItem(this.txtUserName.Text.Trim());

                Session.Add("UM_ID", adminInfo.UM_ID);
                Session.Add("A_Name", userName);
                Session.Add("AdminName", userName);

                ////用cookie 加密存储
                XYECOM.Core.Utils.WriteCookie("AdminId", XYECOM.Core.SecurityUtil.AESEncrypt(adminInfo.UM_ID.ToString(), XYECOM.Configuration.Security.Instance.AESKey), "");
                XYECOM.Core.Utils.WriteCookie("AdminName", XYECOM.Core.SecurityUtil.AESEncrypt(userName, XYECOM.Configuration.Security.Instance.AESKey), "");
                XYECOM.Core.Utils.WriteCookie("AdminPwd", adminInfo.UM_Pwd, "");
                XYECOM.Core.Utils.WriteCookie("AdminExpires", XYECOM.Core.SecurityUtil.AESEncrypt(DateTime.Now.AddMinutes(30).ToLongTimeString(), XYECOM.Configuration.Security.Instance.AESKey), "");

                // 登陆日志
                XYECOM.Model.LogInfo el = new XYECOM.Model.LogInfo();
                XYECOM.Business.Log l = new XYECOM.Business.Log();
                el.L_Title = "登陆日志管理";
                el.L_Content = "管理员登陆信息";
                el.L_MF = "登陆日志管理";
                el.UM_ID = adminInfo.UM_ID;
                l.Insert(el);
                Response.Redirect("default.htm");
            }
            else
            {
                this.ClientScript.RegisterClientScriptBlock(GetType(), "01", "<script>alertmsg(\"用户名或者密码错误！  \")</script>");
            }
        }
    }
}
