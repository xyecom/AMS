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
    public partial class VoteResult : XYECOM.Web.BasePage.ManagePage
    {
        protected System.Data.DataTable subject = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void BindData()
        {
            int voteId = XYECOM.Core.XYRequest.GetQueryInt("VoteId", 0);

            if (voteId <= 0)
            {
                Alert("非法参数！", "List.aspx");
            }

            Model.VoteInfo vote = new Business.Vote().GetItem(voteId);

            if (vote == null)
            {
                Alert("所属调查不存在或已经被删除！", "list.aspx");
            }

            backURL = XYECOM.Core.XYRequest.GetString("backURL");

            this.lblVoteTitle.Text = vote.Title;

            subject = Business.Utils.ExecuteTable("XY_VoteSubject", "*", "VoteId=" + voteId, "SubjectId asc", 0);
        }

        protected System.Data.DataTable GetTexts(string subjectId)
        {
            int subject = Core.MyConvert.GetInt32(subjectId);

            if (subject <= 0) return new DataTable();

            System.Data.DataTable table = Business.Utils.ExecuteTable("XY_VoteText", "*", "SubjectId=" + subjectId, "textId desc", 10);

            return table;
        }

        protected System.Data.DataTable GetOptions(string subjectId,out int voteTotalNumber)
        {
            int subject = Core.MyConvert.GetInt32(subjectId);

            voteTotalNumber = 0;

            if (subject <= 0) return new DataTable();

            System.Data.DataTable table=  Business.Utils.ExecuteTable("XY_VoteOptions", "*", "SubjectId=" + subjectId, "optionId asc", 0);


            foreach (System.Data.DataRow row in table.Rows)
            { 
                voteTotalNumber += Core.MyConvert.GetInt32(row["VoteTotal"].ToString());
            }

            System.Data.DataColumn column = new DataColumn("percent");

            table.Columns.Add(column);

            foreach (System.Data.DataRow row in table.Rows)
            {
                int voteTotal = Core.MyConvert.GetInt32(row["voteTotal"].ToString());

                if (voteTotal == 0)
                {
                    row["percent"] = 0;
                    continue;
                }

                row["percent"] = (((voteTotal * 1.0) / voteTotalNumber) * 100).ToString("0.00");
            }

            return table;
        }
    }
}
