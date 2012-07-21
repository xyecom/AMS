using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XYECOM.Web.Creditor
{
    public partial class BaseEdit : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void BindData()
        {
            if (!userinfo.IsPrimary)
            {
                GotoMsgBoxPageForDynamicPage("您不是主账户用户，不能修改公司信息！", 1, "/Creditor/Index.aspx");
                return;
            }
            this.txtAddress.Text = this.userinfo.Address;
            this.txtArea.Text = this.userinfo.AreaName;
            this.txtCompanyName.Text = this.userinfo.CompanyName;
            this.txtEmail.Text = this.userinfo.Email;
            this.txtIntroduction.Text = this.userinfo.Description;
            this.txtOtherContact.Text = this.userinfo.OtherContact;
            this.txtTelphone.Text = this.userinfo.Telphone;
            this.txtUserName.Text = this.userinfo.LoginName;
            this.txtLinkMan.Text = this.userinfo.LinkMan;
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            this.userinfo.Address = this.txtAddress.Text;
            this.userinfo.AreaName = this.txtArea.Text;
            this.userinfo.CompanyName = this.txtCompanyName.Text;
            this.userinfo.Email = this.txtEmail.Text;
            this.userinfo.Description = this.txtIntroduction.Text;
            this.userinfo.OtherContact = this.txtOtherContact.Text;
            this.userinfo.Telphone = this.txtTelphone.Text;
            this.userinfo.LoginName = this.txtUserName.Text;
            this.userinfo.LinkMan = this.txtLinkMan.Text;

            this.userinfo.LayerId = string.Empty;
            this.userinfo.IdentityNumber = string.Empty;

            XYECOM.Business.UserInfo userInfoBll = new Business.UserInfo();

            int result = userInfoBll.UpdateBaseInfo(userinfo);
            if (result > 0)
            {
                GotoMsgBoxPageForDynamicPage("保存成功！", 1, "/Creditor/BaseEdit.aspx");
                return;
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('保存失败，请重试！');", true);
                //this.Page.RegisterClientScriptBlock("alert",

            }
        }
    }
}