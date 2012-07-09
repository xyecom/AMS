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
    public partial class EditVote : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("vote");
        }

        protected override void BindData()
        {
            int voteId = XYECOM.Core.XYRequest.GetQueryInt("voteid", 0);

            backURL = XYECOM.Core.XYRequest.GetString("backURL");

            if (backURL.Equals("")) backURL = "list.aspx";

            if (voteId <= 0)
            {
                Alert("非法参数！", backURL);
            }

            Model.VoteInfo vote = new Business.Vote().GetItem(voteId);

            if (vote == null) Alert("指定调查不存在或已被删除！", backURL);

            this.txtTitle.Text = vote.Title;
            this.txtDesc.Text = vote.Desc;
            this.rdolstUserType.SelectedValue = vote.UserType;
            this.txtStartTime.Text = vote.StartTime.ToString("yyyy-MM-dd");
            this.txtEndTime.Text = vote.EndTime.ToString("yyyy-MM-dd");
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            int voteId = XYECOM.Core.XYRequest.GetQueryInt("voteid", 0);

            backURL = XYECOM.Core.XYRequest.GetString("backURL");

            if (backURL.Equals("")) backURL = "list.aspx";

            if (voteId <= 0)
            {
                Alert("非法参数！", backURL);
            }

            Model.VoteInfo info = new Business.Vote().GetItem(voteId);

            if (info == null) Alert("指定调查不存在或已被删除！", backURL);

            string title = txtTitle.Text.Trim();
            string desc = txtDesc.Text.Trim();

            if (string.IsNullOrEmpty(title))
            {
                Alert("调查标题不能为空!");
            }

            info.Title = title;
            info.Desc = desc;
            info.UserType = this.rdolstUserType.SelectedValue;
            info.StartTime = Core.MyConvert.GetDateTime(Request.Params["txtStartTime"]);
            info.EndTime = Core.MyConvert.GetDateTime(Request.Params["txtEndTime"]);
            if (info.StartTime.CompareTo(info.EndTime) >= 0)
            {
                Alert("结束时间必须在开始时间之后且要大于当天！");
                return;
            }

            int i = new Business.Vote().Update(info);

            if (i <= 0)
                Alert("修改失败！", backURL, true);

            Alert("修改成功！", backURL, true);
        }
    }
}
