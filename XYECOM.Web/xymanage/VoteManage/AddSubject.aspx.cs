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
    public partial class AddSubject : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("vote");
        }

        protected override void BindData()
        {
            int voteId = XYECOM.Core.XYRequest.GetQueryInt("voteid", 0);

            backURL = XYECOM.Core.XYRequest.GetString("backURL1");

            if (backURL.Equals("")) backURL = "list.aspx";

            if (voteId <= 0)
            {
                Alert("非法参数！", backURL);
            }

            Model.VoteInfo vote = new Business.Vote().GetItem(voteId);

            if (vote == null) Alert("指定调查不存在或已被删除！", backURL);

            this.lblVoteTitle.Text = vote.Title;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            int voteId = XYECOM.Core.XYRequest.GetQueryInt("voteid", 0);

            backURL = XYECOM.Core.XYRequest.GetString("backURL1");

            if (voteId <= 0)
            {
                Alert("非法参数！", backURL);
            }

            Model.VoteSubjectInfo subject = new XYECOM.Model.VoteSubjectInfo();

            subject.Subject = this.txtSubject.Text.Trim();
            subject.StrType = this.rdolstType.SelectedValue;
            subject.VoteId = voteId;

            int subjectId = 0;

            new Business.VoteSubject().Insert(subject, out subjectId);

            if (subjectId > 0)
            {
                int optionTotal = Core.MyConvert.GetInt32(this.OptionTotal.Value);

                Business.VoteOptions optionBLL = new XYECOM.Business.VoteOptions();
                Model.VoteOptionsInfo optionInfo = null;

                for (int i = 1; i <= optionTotal; i++)
                {
                    string option = XYECOM.Core.XYRequest.GetFormString("option" + i).Trim();

                    if (string.IsNullOrEmpty(option)) continue;

                    optionInfo = new XYECOM.Model.VoteOptionsInfo();
                    optionInfo.Text = option;
                    optionInfo.SubjectId = subjectId;
                    optionInfo.VoteTotal = 0;

                    optionBLL.Insert(optionInfo);
                }
            }

            Response.Redirect(backURL);
        }

        protected void rdolstType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = this.rdolstType.SelectedValue.Trim();

            if (type.Equals("select") || type.Equals("mselect"))
            {
                this.pnlOptions.Visible = true;
            }
            else
            {
                this.pnlOptions.Visible = false;
            }
        }
    }
}
