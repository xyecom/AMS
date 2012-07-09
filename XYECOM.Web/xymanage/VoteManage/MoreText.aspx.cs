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
    public partial class MoreText : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("vote");
        }

        protected override void BindData()
        {
            this.page1.PageSize = 50;
            this.btndelete.Attributes.Add("onclick", "javascript:return del();");

            int subjectId = XYECOM.Core.XYRequest.GetQueryInt("subjectId", 0);

            if (subjectId <= 0)
            {
                Alert("非法参数！");
            }

            Model.VoteSubjectInfo subject = new Business.VoteSubject().GetItem(subjectId);

            if (subject == null)
            {
                Alert("问题不存在或已经被删除！");
            }

            Model.VoteInfo vote = new Business.Vote().GetItem(subject.VoteId);

            if (vote == null)
            {
                Alert("所属调查不存在或已经被删除！");
            }

            this.lblVoteTitle.Text = vote.Title;
            this.lblSubjectText.Text = subject.Subject;

            int totalRecord = 0;

            DataTable dt = XYECOM.Business.Utils.GetPaginationData("XY_VoteText", "TextId", "TextId,Body", "TextId Desc", "SubjectId=" + subjectId, this.page1.PageSize, this.page1.CurPage, out totalRecord);

            this.page1.RecTotal = totalRecord;

            if (dt.Rows.Count > 0)
            {
                this.gvList.DataSource = dt;
                this.gvList.DataBind();
            }
            else
            {
                this.gvList.DataBind();
                this.lblMessage.Text = "没有相关信息";
            }
        }

        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
                e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Business.VoteText DAL = new XYECOM.Business.VoteText();

            foreach (GridViewRow row in this.gvList.Rows)
            {
                if (((CheckBox)(row.FindControl("chkExport"))).Checked == true)
                {
                    DAL.Delete(Convert.ToInt32(gvList.DataKeys[row.DataItemIndex].Value.ToString()));
                }
            }

            BindData();
        }
    }
}
