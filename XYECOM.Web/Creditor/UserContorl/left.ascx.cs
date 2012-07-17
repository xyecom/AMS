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
            if (XYECOM.Business.CheckUser.UserInfo != null)
            {
                if (XYECOM.Business.CheckUser.UserInfo.IsPrimary)
                {
                    this.hlInfo.NavigateUrl = "/Creditor/BaseEdit.aspx";
                    this.hypCredManage.Visible = true;
                    this.hypCredManage.Visible = true;
                }
                else
                {
                    this.hlInfo.NavigateUrl = "/Creditor/EditPartInfo.aspx?ac=u";
                    this.hypCredManage.Visible = false;
                    this.hypCredManage.Visible = false;
                }
            }

            //<a tabindex="1" href="/Creditor/BaseEdit.aspx">资料修改</a>
        }
    }
}