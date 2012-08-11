using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XYECOM.Web.Creditor
{
    public partial class ParDetail : XYECOM.Web.AppCode.UserCenter.Creditor
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

                this.labDescription.Text = info.Description;
                this.labEmail.Text = info.Email;
                this.labOtherContact.Text = info.OtherContact;
                this.labPartManagerName.Text = info.PartManagerName;
                this.labPartManagerTel.Text = info.PartManagerTel;
                this.labPartName.Text = info.LayerName;
                this.labLinkManTel.Text = info.Telphone;
                this.labLoginName.Text = info.LoginName;
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
    }
}