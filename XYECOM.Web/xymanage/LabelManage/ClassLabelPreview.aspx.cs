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
    public partial class ClassLabelPreview : XYECOM.Web.BasePage.ManagePage
    {
        private int labelId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("label");
            if (!IsPostBack)
            {
                InitPage();
            }
        }

        private void InitPage()
        {
            if (Request.QueryString["id"] == null)
            {
                this.lblMessage.Text = "无效参数";
                Response.End();
            }

            Int32.TryParse(Request.QueryString["id"].ToString(), out labelId);

            if (labelId == 0)
            {
                this.lblMessage.Text = "无效参数";
                Response.End();
            }

            XYECOM.Model.ClassLabelInfo info = new Business.ClassLabel().GetItem(labelId);

            lblBody.InnerHtml = XYECOM.Label.ClassLabelManager.GetInstance(info.Name).CreateHTML();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClassLabelList.aspx");
        }
    }
}
