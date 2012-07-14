using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XYECOM.Web.Creditor
{
    public partial class EditPartInfo : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        XYECOM.Business.UserReg userRegBll = new Business.UserReg();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void BindData()
        {
            Model.UserRegInfo info = null;
            string ac = Core.XYRequest.GetQueryString("ac").ToLower();

            if (ac == "u")
            {
                if (userinfo.IsPrimary)
                {
                    long infoId = Core.XYRequest.GetQueryInt64("PartId");
                    info = userRegBll.GetItem(infoId);
                }
                else
                {
                    info = userRegBll.GetItem(userinfo.userid);
                }

                if (info == null)
                {
                    GotoMsgBoxPageForDynamicPage("部门信息不存在或您无权操作该部门信息！", 1, userinfo.IsPrimary ? "/Creditor/Index.aspx" : "/Creditor/PartIndex.aspx");
                    return;
                }

                this.hidPartId.Value = info.UserId.ToString();

                this.txtDescription.Text = info.Description;
                this.txtEmail.Text = info.Email;
                this.txtOtherContact.Text = info.OtherContact;
                this.txtPartManagerName.Text = info.PartManagerName;
                this.txtPartManagerTel.Text = info.PartManagerTel;
                this.txtPartName.Text = info.LayerName;
                this.txtLinkManTel.Text = info.Telphone;

                this.txtLoginName.Text = info.LoginName;
                this.txtLoginName.Enabled = false;
            }
            else
            {
                if (!userinfo.IsPrimary)
                {
                    GotoMsgBoxPageForDynamicPage("您没有权限添加部门！", 1, "/Creditor/Index.aspx");
                    return;
                }
            }

            this.lblAddress.Text = this.userinfo.Address;
            this.lblArea.Text = this.userinfo.AreaName;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string hidUserId = this.hidPartId.Value;
            Model.UserRegInfo regInfo = new Model.UserRegInfo();

            regInfo.Description = this.txtDescription.Text;
            regInfo.Email = this.txtEmail.Text;
            regInfo.OtherContact = this.txtOtherContact.Text;
            regInfo.PartManagerName = this.txtPartManagerName.Text;
            regInfo.PartManagerTel = this.txtPartManagerTel.Text;
            regInfo.LayerName = this.txtPartName.Text;
            regInfo.CompanyId = userinfo.CompanyId;
            regInfo.UserType = (int)userinfo.UserType;
            regInfo.AreaId = userinfo.AreaId;
            regInfo.Telphone = this.txtLinkManTel.Text;
            string message = string.Empty;

            if (string.IsNullOrEmpty(hidUserId))
            {
                //add
                regInfo.LoginName = this.txtLoginName.Text;
                regInfo.IsPrimary = false;
                regInfo.Password = Core.SecurityUtil.MD5("000000", XYECOM.Configuration.Security.Instance.Md5value);
                Model.ResisterUserReturnValue returnvalue = userRegBll.AddPart(regInfo);

                switch (returnvalue)
                {
                    case XYECOM.Model.ResisterUserReturnValue.Failed:
                        message = "添加失败！";
                        break;
                    case XYECOM.Model.ResisterUserReturnValue.UserNameExists:
                        message = "登录名重复！";
                        break;
                    case XYECOM.Model.ResisterUserReturnValue.EmailExists:
                        message = "Email重复！";
                        break;
                    case XYECOM.Model.ResisterUserReturnValue.ForbidName:
                        message = "禁用登录名！";
                        break;
                    case XYECOM.Model.ResisterUserReturnValue.PartNameExists:
                        message = "部门名称重复！";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                //edit                                
                regInfo.UserId = Core.MyConvert.GetInt32(hidUserId);
                int result = userRegBll.UpdatePartInfo(regInfo);

                if (result < 1)
                {
                    message = "修改失败！";
                }
            }

            if (string.IsNullOrEmpty(message))
            {
                GotoMsgBoxPageForDynamicPage("", 1, "/Creditor/PartList.aspx");
                return;
            }
            else
            {
                GotoMsgBoxPageForDynamicPage("", 1, "/Creditor/EditPartInfo.aspx");
                return;
            }
        }
    }
}