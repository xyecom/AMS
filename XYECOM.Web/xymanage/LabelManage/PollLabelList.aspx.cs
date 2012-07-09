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
    public partial class PollLabelList : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("label");

            if (!IsPostBack)
            {
                this.page1.PageSize = 20;
                this.btndelete.Attributes.Add("onclick", "javascript:return del();");
            }
        }


        protected override void BindData()
        {
            //设置编辑或查看后要返回当前页面的状态
            backURL = XYECOM.Core.Utils.JSEscape("PollLabelList.aspx?page=" + page1.CurPage.ToString());

            int totalRecord =0;

            DataTable dt = XYECOM.Business.Utils.GetPaginationData("XY_Poll", "PollId", "PollId,LabelName,title,Mode", "PollId Desc", "", this.page1.PageSize, this.page1.CurPage, out totalRecord);

            this.page1.RecTotal  = totalRecord;

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

                e.Row.Cells[2].Text = "{" + e.Row.Cells[2].Text + "}";
            }
        }

        protected void Page1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Business.Poll DAL = new XYECOM.Business.Poll();

            foreach (GridViewRow row in this.gvList.Rows)
            {
                if (((CheckBox)(row.FindControl("chkExport"))).Checked == true)
                {
                    DAL.Delete(Convert.ToInt32(gvList.DataKeys[row.DataItemIndex].Value.ToString()));
                }
            }

            BindData();
        }

        protected string GetViewHref(string pollId)
        {
            return webInfo.WebDomain + "poll." + webInfo.WebSuffix + "?pollid=" + pollId;
        }
    }
}
