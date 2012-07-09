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

using System.Data.SqlClient;
using XYECOM.Model;
using XYECOM.Business;
using XYECOM.Core;

public partial class xymanage_news_NewsDiscussList : XYECOM.Web.BasePage.ManagePage
{
    NewsDiscuss nDiscuss = new NewsDiscuss();
    Int64 nsid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("newscomment");
        
        btnBack.Attributes["onclick"] = "location='" + XYECOM.Core.XYRequest.GetQueryString("backURL") + "';return false;";

        if (Request.QueryString["NS_ID"] != null)
            nsid = Int64.Parse(Request.QueryString["NS_ID"]);
        if (!IsPostBack)
        {
            this.Page1.PageSize = 20;

            if (nsid != 0)
                BindData(nsid);
            else
                Alert("请先选择你要查看评论的新闻.", "NewsList.aspx");
            this.lnkDel.Attributes.Add("onclick", "javascript:return del();");            
        }
    }

    #region 绑定数据方法
    protected void BindData(Int64 nsid)
    {
        XYECOM.Business.News ns = new XYECOM.Business.News();
        string strWhere = " where NS_ID="+nsid.ToString();
        string newsname = ns.GetNewsName(nsid);
        if(string.IsNullOrEmpty(newsname))
              this.caption.InnerHtml ="对《" + newsname + "》新闻的评论";

        this.Page1.RecTotal = Function.GetRows("n_NewsDiscuss", "ND_ID", strWhere);
        DataTable dt = Function.GetPages(this.Page1.PageSize, this.Page1.CurPage, strWhere, " Order by ND_ID DESC", "n_NewsDiscuss", "ND_ID,U_ID,U_Name,NS_ID,ND_Content,ND_AddTime,ND_IsShow", "ND_ID");

        if (dt.Rows.Count > 0)
        {
            this.gvlist.DataSource = dt;
            this.gvlist.DataBind();
        }
        else
        {
            this.gvlist.DataBind();
            this.lblMessage.Text = "没有任何评论!";
        }

    }
    #endregion

    #region 删除相关评论
    protected void lnkDel_Click(object sender, EventArgs e)
    {
        string id = "";
        foreach (GridViewRow row in this.gvlist.Rows)
        {
            if (((CheckBox)(row.FindControl("chkExport"))).Checked == true)
                id += "," + this.gvlist.DataKeys[row.DataItemIndex].Value.ToString();
        }
        if (id.IndexOf(",") == 0)
            id = id.Substring(1);
        int rowAffected = nDiscuss.Delete(id);

        if (rowAffected >= 0)
        {
            Alert("删除成功.", "NewsDiscussList.aspx?NS_ID=" + nsid);
        }
        else
        {
            Alert("删除失败,可重新操作.", "NewsDiscussList.aspx?NS_ID=" + nsid);
        }
    }
    #endregion

    #region 定义分页事件
    private void Page1_PageChanged(object sender, System.EventArgs e)
    {
        BindData(nsid);
    }
    #endregion

    #region Web窗体设计器生成的代码
    protected override void OnInit(EventArgs e)
    {
        this.Load += new System.EventHandler(this.Page_Load);
        this.Page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
        base.OnInit(e);
    }
    #endregion

    #region 绑定前对部分状态进行转换
    protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
            e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

            if (e.Row.Cells[4].Text.Length > 100)
                e.Row.Cells[4].Text = XYECOM.Core.Utils.IsLength(100, e.Row.Cells[4].Text);

            LinkButton lb = (LinkButton)e.Row.Cells[6].Controls[0];
            if (lb.Text == "True")
                lb.Text = "显示";
            else
                lb.Text = "不显示";
        }
    }

    #endregion

    protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int rc = Convert.ToInt32(e.CommandArgument);
        Int64 id = Convert.ToInt32(gvlist.DataKeys[rc].Value);

        LinkButton lb = (LinkButton)gvlist.Rows[rc].Cells[6].Controls[0];
        if (e.CommandName == "SetIsShow")
        {
            if (lb.Text == "显示")
            {
                nDiscuss.SetIsShow(id, false);
            }
            else
            {
                nDiscuss.SetIsShow(id, true);
            }
        }
        this.lblMessage.Text = "";
        BindData(nsid);
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (XYECOM.Core.XYRequest.GetQueryString("backURL") != "")
        {
            this.Response.Redirect(XYECOM.Core.XYRequest.GetQueryString("backURL"));
        }
        else {
            this.Response.Redirect("NewsList.aspx");
        }
        
    } 
}
