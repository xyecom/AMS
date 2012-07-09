using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace XYECOM.Web.xymanage.LabelManage
{
    public partial class EditPollLabel : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("label");

            if (!IsPostBack)
            {
                int pollId = XYECOM.Core.XYRequest.GetQueryInt("pollId", 0);

                if (pollId > 0)
                {
                    BindData(pollId);
                }
            }
        }

        private void BindData(int pollId)
        {
            Model.PollInfo poll = new Business.Poll().GetItem(pollId);

            if (poll == null) return;

            this.txtName.Text = poll.LabelName.Replace("XY_POLL_","");
            this.txtTitle.Text = poll.Title;

            if (poll.Mode == XYECOM.Model.PollMode.Single)
                this.rdoSingle.Checked = true;
            else
                this.rdoCheck.Checked = true;

            List<Model.PollOptionInfo> infos = new Business.PollOption().GetItems(poll.PollId);

            InitOption(infos);
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (!XYECOM.Core.XYRequest.IsPost()) return;

            int pollId = XYECOM.Core.XYRequest.GetQueryInt("pollId", 0);

            if (pollId <= 0) return;

            Business.Poll pollBLL = new XYECOM.Business.Poll();
            Model.PollInfo poll = pollBLL.GetItem(pollId);

            if (poll == null) return;

            poll.LabelName = "XY_POLL_" + this.txtName.Text.Trim();
            poll.Title = this.txtTitle.Text.Trim();
            poll.Mode = XYECOM.Model.PollMode.Single;
            if (rdoCheck.Checked) poll.Mode = XYECOM.Model.PollMode.Check;

            pollBLL.Update(poll);


            int total = XYECOM.Core.MyConvert.GetInt32(this.OptionTotal.Value.ToString());

            Business.PollOption opBLL = new XYECOM.Business.PollOption();
            Model.PollOptionInfo optionInfo = null;

            string option = "" ;
            int optionId = 0;
            for (int i = 1; i <= total; i++)
            {
                option = XYECOM.Core.XYRequest.GetFormString("option" + i).Trim();

                if (string.IsNullOrEmpty(option)) continue;

                optionId = XYECOM.Core.XYRequest.GetInt("option_id_" + i,0);

                if (optionId > 0)
                {
                    optionInfo = opBLL.GetItem(optionId);

                    if (optionInfo != null)
                    {
                        optionInfo.Option = option;
                        opBLL.Update(optionInfo);
                    }
                    else
                    {
                        optionInfo = new XYECOM.Model.PollOptionInfo();
                        optionInfo.Option = option;
                        optionInfo.PollId = poll.PollId;

                        opBLL.Insert(optionInfo);
                    }

                }
                else
                {
                    optionInfo = new XYECOM.Model.PollOptionInfo();
                    optionInfo.Option = option;
                    optionInfo.PollId = poll.PollId;

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

            Alert("ÐÞ¸Ä³É¹¦£¡", "PollLabelList.aspx",true);
        }

        private void InitOption(List<XYECOM.Model.PollOptionInfo> infos)
        {
            Table t = new Table();

            t.ID = "tablePollOption";
            t.Attributes.Add("class", "PollTable");

            TableRow row = new TableRow();
            TableCell cell = new TableCell();

            //row.Attributes.Add("class", "t");

            int i = 1;
            foreach (XYECOM.Model.PollOptionInfo option in infos)
            {
                row = new TableRow();

                cell = new TableCell();
                cell.Text = i+ ".";

                row.Cells.Add(cell);

                cell = new TableCell();
                //Option Body
                HtmlTextArea txt = new HtmlTextArea();
                txt.Rows = 2;
                txt.Cols = 60;
                txt.ID = "option" + i;
                txt.Value = option.Option;
                cell.Controls.Add(txt);
                //Option Id
                HtmlInputHidden hidden = new HtmlInputHidden();
                hidden.ID = "option_id_" + i;
                hidden.Value = option.OptionId.ToString();
                cell.Controls.Add(hidden);

                row.Cells.Add(cell);

                cell = new TableCell();
                cell.ID = "tdDel_" +i;

                if (i == infos.Count && i != 1)
                    cell.Attributes.Add("style", "display:;");
                else
                    cell.Attributes.Add("style", "display:none;");

                cell.Text = "<a href=\"#\" onclick=\"DeletePollOption(" + i + ");DeleteServerOption('"+option.OptionId+"');\"><img src=\"../images/delete1.gif\" alt=\"É¾³ý\" border=\"0\"/></a>";

                row.Cells.Add(cell);

                t.Rows.Add(row);
                i++;
            }

            this.OptionTotal.Value = infos.Count.ToString();
            phMain.Controls.Add(t);
        }
    }
}
