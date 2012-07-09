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

namespace XYECOM.Web.xymanage.LabelManage
{
    public partial class PartLabelView : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("label");
        }

        protected override void BindData()
        {
            int partId = XYECOM.Core.MyConvert.GetInt32(XYECOM.Core.XYRequest.GetQueryString("partid"));

            if (partId <= 0)
            {
                lblBody.InnerText = "无效参数！";
                return;
            }

            Model.PartLabelInfo partInfo = new Business.PartLabel().GetItem(partId);

            if (partInfo == null)
            {
                lblBody.InnerText = "专栏不存在！";
                return;
            }

            XYECOM.Label.LabelManger manager = XYECOM.Label.PartLabelManager.GetInstance(partInfo.LabelName);

            XYECOM.Label.PartLabelManager partManager = (XYECOM.Label.PartLabelManager)manager;

            lblBody.InnerHtml = partManager.CreateHTMLForTest();
        }
    }
}
