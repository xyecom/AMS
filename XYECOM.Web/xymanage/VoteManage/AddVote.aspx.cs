using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace XYECOM.Web.xymanage.VoteManage
{
    public partial class AddVote : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("vote");
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string desc = txtDesc.Text.Trim();

            if (string.IsNullOrEmpty(title))
            {
                Alert("调查标题不能为空!");
            }

            Model.VoteInfo info = new XYECOM.Model.VoteInfo();

            info.Title = title;
            info.Desc = desc;
            info.UserType = this.rdolstUserType.SelectedValue;
            info.StartTime = Core.MyConvert.GetDateTime(Request.Params["txtStartTime"]);
            info.EndTime = Core.MyConvert.GetDateTime(Request.Params["txtEndTime"]);

            if (info.StartTime.CompareTo(info.EndTime) >= 0 || info.EndTime.CompareTo(DateTime.Now) <=0)
            {
                Alert("结束时间必须在开始时间之后且要大于当天！");
                return;
            }

            int i = new Business.Vote().Insert(info);

            if (i <= 0)
                Alert("添加失败！");

            Response.Redirect("list.aspx");
        }
    }
}
