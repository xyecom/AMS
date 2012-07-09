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
    public partial class List : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("vote");

            if (!IsPostBack)
            {
                this.page1.PageSize = 20;
                this.btndelete.Attributes.Add("onclick", "javascript:return del();");
            }
        }

        protected override void BindData()
        {
            //设置编辑或查看后要返回当前页面的状态
            backURL = XYECOM.Core.Utils.JSEscape("List.aspx?page=" + page1.CurPage.ToString());

            int totalRecord = 0;

            DataTable dt = XYECOM.Business.Utils.GetPaginationData("XY_Vote", "VoteId", "VoteId,Title,[Desc],UserType", "VoteId Desc", "", this.page1.PageSize, this.page1.CurPage, out totalRecord);

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

        /// <summary>
        /// 获取预览地址
        /// </summary>
        /// <param name="voteId"></param>
        /// <returns></returns>
        protected string GetViewHref(string voteId)
        {
            return webInfo.WebDomain + "vote." + webInfo.WebSuffix + "?voteid=" + voteId;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Business.Vote DAL = new XYECOM.Business.Vote();

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
