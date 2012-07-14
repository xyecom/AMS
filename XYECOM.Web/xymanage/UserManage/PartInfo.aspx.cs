using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XYECOM.Web.xymanage.UserManage
{
    public partial class PartInfo : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("user");

            if (!IsPostBack)
            {
                long userId = XYECOM.Core.XYRequest.GetQueryInt64("partid");
                Model.UserRegInfo userInfo = new XYECOM.Business.UserReg().GetItem(userId);

                if (userInfo != null)
                {
                    lbcompanyname.InnerHtml = userInfo.LayerName;
                    linkman.InnerHtml = userInfo.PartManagerName;
                    phone.InnerHtml = userInfo.Telphone;
                    managerTel.InnerHtml = userInfo.PartManagerTel;

                    mail.InnerHtml = userInfo.Email;
                    othercontract.InnerHtml = userInfo.OtherContact;
                    area.InnerHtml = new Business.Area().GetItem(userInfo.AreaId).FullNameAll;

                    tdDescription.InnerHtml = userInfo.Description;
                }
            }
        }
    }
}