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

namespace XYECOM.Web.xymanage.Interface
{
    public partial class IM : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("interface");
        }

        protected override void BindData()
        {
            this.txtName.Text = XYECOM.Configuration.FreeCode.Instance.IM.Name;
            this.txtCode.Text = XYECOM.Configuration.FreeCode.Instance.IM.Code;

            if (XYECOM.Configuration.FreeCode.Instance.IM.IsEnabled)
                this.rdoEnabled.Checked = true;
            else
                this.rdoDisabled.Checked = true;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            XYECOM.Configuration.FreeCode.Instance.IM.Name = this.txtName.Text.Trim();
            XYECOM.Configuration.FreeCode.Instance.IM.Code = this.txtCode.Text.Trim();

            if (this.rdoEnabled.Checked)
                XYECOM.Configuration.FreeCode.Instance.IM.IsEnabled = true;
            else
                XYECOM.Configuration.FreeCode.Instance.IM.IsEnabled = false;

            XYECOM.Configuration.FreeCode.Instance.Update();
        }
    }
}
