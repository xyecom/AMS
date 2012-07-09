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
namespace XYECOM.Web.xymanage.Ranking
{
    public partial class RanKingUserList : XYECOM.Web.BasePage.ManagePage
    {
        protected string backURL1 = "";

        protected string backURL2 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("custom");

            this.Page1.PageSize = 20;

            this.btnDelete.Attributes.Add("onclick", "javascript:return del();");

            if (!IsPostBack)
            {
                SetValueByquery(Page1, "page");
                SetValueByquery(txtkey, "keyword");
            }
        }
        protected override void BindData()
        {
            backURL = XYECOM.Core.Utils.JSEscape("RankingUserList.aspx?keyword=" + txtkey.Text.Trim() +
               "&page=" + Page1.CurPage.ToString());

            backURL1 = XYECOM.Core.Utils.JSEscape("../Ranking/RankingUserList.aspx?keyword=" + txtkey.Text.Trim() +
               "&page=" + Page1.CurPage.ToString());

            string strwhere = "1=1";
            //标题
            if (this.txtkey.Text.Trim() != "")
            {
                strwhere += " and title like '%" + this.txtkey.Text.Trim() + "%' ";
            }

            int totalRecord = 0;
            DataTable dt = XYECOM.Business.Utils.GetPaginationData("XY_RanKingUserInfo", "InfoId", "InfoId,UserId,RankingId,ModuleName,Title,[Desc],Link,ImageUrl,IsHasImage,AuditingState,Rank", " InfoId desc ", strwhere, Page1.PageSize, this.Page1.CurPage, out totalRecord);

            this.Page1.RecTotal = totalRecord;

            if (dt.Rows.Count > 0)
            {
                this.gvList.DataSource = dt;
                this.gvList.DataBind();
            }
            else
            {
                this.gvList.DataBind();
            }
        }


        protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
                e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

                LinkButton LB = (LinkButton)e.Row.Cells[7].Controls[0];
                string LS = LB.Text.Trim();
                if (LS == "-1")
                {
                    LB.Text = "未审核";
                }
                else if (LS == "0")
                {
                    LB.Text = "审核未通过";
                }
                else
                {
                    LB.Text = "审核通过";
                }
            }
        }

        protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int iRowNo = Convert.ToInt32(e.CommandArgument);
            int infoID = Convert.ToInt32(this.gvList.DataKeys[iRowNo].Value);

            if (e.CommandName == "shenhe")
            {
                LinkButton linkBtn = (LinkButton)this.gvList.Rows[iRowNo].Cells[7].Controls[0];

                XYECOM.Business.Auditing auditingBLL = new XYECOM.Business.Auditing();

                if (linkBtn.Text == "审核通过")
                {
                    int j = auditingBLL.UpdatesAuditing(infoID, "XY_RankingUserInfo", XYECOM.Model.AuditingState.NoPass);
                }
                else if (linkBtn.Text == "审核未通过" || linkBtn.Text == "未审核")
                {
                    int t = auditingBLL.UpdatesAuditing(infoID, "XY_RankingUserInfo", XYECOM.Model.AuditingState.Passed);
                }

                this.BindData();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Business.RanKingUserInfo BLL = new XYECOM.Business.RanKingUserInfo();

            foreach (GridViewRow GR in this.gvList.Rows)
            {
                if (((CheckBox)(GR.FindControl("chkExport"))).Checked == true)
                {
                    string id = gvList.DataKeys[GR.DataItemIndex].Value.ToString();

                    int _Id = Core.MyConvert.GetInt32(id);

                    if (_Id <= 0) continue;

                    BLL.Delete(_Id);
                }
            }

            BindData();
        }

    }
}
