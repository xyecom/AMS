using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XYECOM.Web.Creditor.UserContorl
{
    public partial class left : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.liPart.Visible = false;
            if (XYECOM.Business.CheckUser.UserInfo != null)
            {
                if (XYECOM.Business.CheckUser.UserInfo.IsPrimary)
                {
                    this.hlInfo.NavigateUrl = "/Creditor/BaseEdit.aspx";
                    this.liCredManage.Visible = true;
                    this.liForeManage.Visible = true;
                    if (XYECOM.Business.CheckUser.UserInfo.UserType == Model.UserType.CreditorEnterprise)
                    {
                        this.liPart.Visible = true;
                    }
                }
                else
                {                    
                    this.hlInfo.NavigateUrl = "/Creditor/EditPartInfo.aspx?ac=u";
                    this.liForeManage.Visible = false;
                    this.liCredManage.Visible = false;
                }
            }
        }
    }
}