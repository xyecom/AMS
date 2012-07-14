using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XYECOM.Web.Server
{
    public partial class UpLoadPicture  : XYECOM.Web.AppCode.UserCenter.Server
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void BindData()
        {
            this.udPic.InfoID = userinfo.userid;//XYECOM.Model.AttachmentItem
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            this.udPic.InfoID = userinfo.userid;
            this.udPic.Update();
        }
    }
}