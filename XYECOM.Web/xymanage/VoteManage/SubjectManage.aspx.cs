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
    public partial class SubjectManage : XYECOM.Web.BasePage.ManagePage
    {
        private int voteId;

        protected string backURL1 = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("vote");
        }

        protected override void BindData()
        {

            this.page1.PageSize = 20;
            this.btndelete.Attributes.Add("onclick", "javascript:return del();");

            voteId = XYECOM.Core.XYRequest.GetQueryInt("VoteId", 0);

            if (voteId <= 0)
            {
                Alert("非法参数！", "List.aspx");
            }

            Model.VoteInfo vote = new Business.Vote().GetItem(voteId);

            if (vote == null)
            {
                Alert("所属调查不存在或已经被删除！", "list.aspx");
            }

            this.lblVoteTitle.Text = vote.Title;

            backURL = XYECOM.Core.XYRequest.GetString("backURL");

            if (backURL.Equals("")) backURL = "list.aspx";

            //设置编辑或查看后要返回当前页面的状态
            backURL1 = XYECOM.Core.Utils.JSEscape("SubjectManage.aspx?VoteId=" + voteId + "&page=" + page1.CurPage.ToString());

            int totalRecord = 0;

            DataTable dt = XYECOM.Business.Utils.GetPaginationData("XY_VoteSubject", "SubjectId", "SubjectId,Subject,Type", "SubjectId Desc", "voteId=" + voteId, this.page1.PageSize, this.page1.CurPage, out totalRecord);

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

        protected string GetTypeName(string type)
        {
            if (type.Equals("text")) return "单行文本";

            if (type.Equals("mtext")) return "多行文本";

            if (type.Equals("select")) return "单选列表";

            if (type.Equals("mselect")) return "多选列表";

            return "";
        }

        protected string GetOptions(string type, string _subjectId)
        {
            if (type.Equals("text") || type.Equals("mtext")) return "----";

            int subjectId = Core.MyConvert.GetInt32(_subjectId);

            if (subjectId <= 0) return "----";

            System.Collections.Generic.List<Model.VoteOptionsInfo> options = new Business.VoteOptions().GetItemsBySubjectId(subjectId);

            System.Text.StringBuilder body = new System.Text.StringBuilder("");

            foreach (Model.VoteOptionsInfo option in options)
            {
                body.Append(option.Text);
                body.Append("<br/>");
            }

            return body.ToString();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Business.VoteSubject DAL = new XYECOM.Business.VoteSubject();

            foreach (GridViewRow row in this.gvList.Rows)
            {
                if (((CheckBox)(row.FindControl("chkExport"))).Checked == true)
                {
                    DAL.Delete(Convert.ToInt32(gvList.DataKeys[row.DataItemIndex].Value.ToString()));
                }
            }

            BindData();
        }

        protected int VoteId
        {
            get
            {
                return voteId;
            }
        }
    }
}
