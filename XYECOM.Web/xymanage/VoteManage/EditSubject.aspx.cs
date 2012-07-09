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
    public partial class EditSubject1 : XYECOM.Web.BasePage.ManagePage
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



            int subjectId = XYECOM.Core.XYRequest.GetQueryInt("subjectId", 0);

            if (subjectId <= 0)
            {
                Alert("非法参数！", backURL);
            }

            Model.VoteSubjectInfo subject = new Business.VoteSubject().GetItem(subjectId);

            if (subject == null) Alert("调查问题信息不存在或已被删除！", backURL);

            txtSubject.Text = subject.Subject;
            rdolstType.SelectedValue = subject.StrType;

            if (subject.StrType.Equals("select") || subject.StrType.Equals("mselect"))
            {
                this.pnlOptions.Visible = true;

                this.rdolstType.Items[0].Enabled = false;
                this.rdolstType.Items[1].Enabled = false;


                InitOption(subjectId);
            }
            else
            {
                this.rdolstType.Items[2].Enabled = false;
                this.rdolstType.Items[3].Enabled = false;

                this.pnlOptions.Visible = false;
            }
        }

        private void InitOption(int subjectId)
        {
            System.Collections.Generic.List<Model.VoteOptionsInfo> list = new Business.VoteOptions().GetItemsBySubjectId(subjectId);

            Table t = new Table();

            t.ID = "tablePollOption";
            t.Attributes.Add("class", "PollTable");

            TableRow row = new TableRow();
            TableCell cell = new TableCell();

            //row.Attributes.Add("class", "t");

            int i = 1;
            foreach (XYECOM.Model.VoteOptionsInfo option in list)
            {
                row = new TableRow();

                cell = new TableCell();
                cell.Text = i + ".";

                row.Cells.Add(cell);

                cell = new TableCell();
                //Option Body
                HtmlTextArea txt = new HtmlTextArea();
                txt.Rows = 2;
                txt.Cols = 60;
                txt.ID = "option" + i;
                txt.Value = option.Text;
                cell.Controls.Add(txt);
                //Option Id
                HtmlInputHidden hidden = new HtmlInputHidden();
                hidden.ID = "option_id_" + i;
                hidden.Value = option.OptionId.ToString();
                cell.Controls.Add(hidden);

                row.Cells.Add(cell);

                cell = new TableCell();
                cell.ID = "tdDel_" + i;

                if (i == list.Count && i != 1)
                    cell.Attributes.Add("style", "display:;");
                else
                    cell.Attributes.Add("style", "display:none;");

                cell.Text = "<a href=\"#\" onclick=\"DeletePollOption(" + i + ");DeleteServerOption('" + option.OptionId + "');\"><img src=\"../images/delete1.gif\" alt=\"删除\" border=\"0\"/></a>";

                row.Cells.Add(cell);

                t.Rows.Add(row);
                i++;
            }

            this.OptionTotal.Value = list.Count.ToString();
            phOptions.Controls.Add(t);
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            int subjectId = XYECOM.Core.XYRequest.GetQueryInt("subjectId", 0);

            backURL = XYECOM.Core.XYRequest.GetString("backURL1");

            if (subjectId <= 0)
            {
                Alert("非法参数！", backURL);
            }

            Model.VoteSubjectInfo subject = new Business.VoteSubject().GetItem(subjectId);

            if (subject==null)
            {
                Alert("异常失败！", backURL);
            }

            subject.Subject = this.txtSubject.Text.Trim();
            subject.StrType = this.rdolstType.SelectedValue;

            int j = new Business.VoteSubject().Update(subject);

            string option = "";
            int optionId = 0;

            int total = XYECOM.Core.MyConvert.GetInt32(this.OptionTotal.Value.ToString());

            Business.VoteOptions opBLL = new XYECOM.Business.VoteOptions();
            Model.VoteOptionsInfo optionInfo = null;

            for (int i = 1; i <= total; i++)
            {
                option = XYECOM.Core.XYRequest.GetFormString("option" + i).Trim();

                if (string.IsNullOrEmpty(option)) continue;

                optionId = XYECOM.Core.XYRequest.GetInt("option_id_" + i, 0);

                if (optionId > 0)
                {
                    if (this.rdolstType.SelectedValue.Equals("text") || this.rdolstType.SelectedValue.Equals("mtext"))
                    {
                        opBLL.Delete(optionId);
                        continue;
                    }

                    optionInfo = opBLL.GetItem(optionId);

                    if (optionInfo != null)
                    {
                        optionInfo.Text = option;
                        opBLL.Update(optionInfo);
                    }
                    else
                    {
                        optionInfo = new XYECOM.Model.VoteOptionsInfo();
                        optionInfo.Text = option;
                        optionInfo.SubjectId = subjectId;

                        opBLL.Insert(optionInfo);
                    }

                }
                else
                {
                    if (this.rdolstType.SelectedValue.Equals("text") || this.rdolstType.SelectedValue.Equals("mtext"))
                    {
                        continue;
                    }

                    optionInfo = new XYECOM.Model.VoteOptionsInfo();
                    optionInfo.Text = option;
                    optionInfo.SubjectId = subjectId;

                    opBLL.Insert(optionInfo);
                }
            }

            string delIds = this.DelOptionIds.Value.ToString();
            string[] ids = delIds.Split(',');

            foreach (string id in ids)
            {
                int _Id = Core.MyConvert.GetInt32(id);

                if (_Id <= 0) continue;

                opBLL.Delete(_Id);
            }

            Alert("修改成功！", backURL, true);
        }

        protected void rdolstType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = this.rdolstType.SelectedValue.Trim();

            if (type.Equals("select") || type.Equals("mselect"))
            {
                this.pnlOptions.Visible = true;

                int subjectId = XYECOM.Core.XYRequest.GetQueryInt("subjectId", 0);

                InitOption(subjectId);
            }
            else
            {
                this.pnlOptions.Visible = false;
            }
        }
    }
}
