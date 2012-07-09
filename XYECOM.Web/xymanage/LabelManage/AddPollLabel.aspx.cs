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
    public partial class AddPollLabel : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("label");
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string labelName = "XY_POLL_" + txtName.Text.Trim();
            string title = this.txtTitle.Text.Trim();

            Model.PollInfo poll = new XYECOM.Model.PollInfo();
            Business.Poll pollBLL = new XYECOM.Business.Poll();

            poll.LabelName = labelName;
            poll.Title = title;
            poll.Mode = XYECOM.Model.PollMode.Single;

            if (rdoCheck.Checked) poll.Mode = XYECOM.Model.PollMode.Check;

            int lastPollId = 0;

            pollBLL.Insert(poll, out lastPollId);

            int optionTotal = Core.MyConvert.GetInt32(this.OptionTotal.Value);

            Business.PollOption optionBLL = new XYECOM.Business.PollOption();
            Model.PollOptionInfo optionInfo = null;

            for (int i = 1; i <= optionTotal; i++)
            {
                string option = XYECOM.Core.XYRequest.GetFormString("option" + i).Trim();

                if (string.IsNullOrEmpty(option)) continue;

                optionInfo = new XYECOM.Model.PollOptionInfo();
                optionInfo.Option = option;
                optionInfo.PollId = lastPollId;

                optionBLL.Insert(optionInfo);
            }

            Response.Redirect("PollLabelList.aspx");
        }
    }
}
