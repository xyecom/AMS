using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XYECOM.Web.Server
{
    public partial class BaseEdit : XYECOM.Web.AppCode.UserCenter.Server
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
            this.txtLayerName.Text = this.userinfo.LayerName;

            this.ddlSex.SelectedValue = (this.userinfo.Sex ? 1 : 0).ToString();
            this.txtLayerId.Text = this.userinfo.LayerId;
            this.txtIdNumber.Text = this.userinfo.IdNumber;

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

            this.userinfo.LayerName = this.txtLayerName.Text;
            this.userinfo.Sex = this.ddlSex.SelectedValue != "0";
            this.userinfo.LayerId = this.txtLayerId.Text;
            this.userinfo.IdNumber = this.txtIdNumber.Text;

            XYECOM.Business.UserInfo userInfoBll = new Business.UserInfo();

            int result = userInfoBll.UpdateBaseInfo(userinfo);
            if (result > 0)
            {
                GotoMsgBoxPageForDynamicPage("保存成功！", 1, "/Server/BaseEdit.aspx");
                return;
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('保存失败，请重试！');", true);
            }
        }
    }
}