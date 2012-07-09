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

public partial class xymanage_news_UserForChargedNews :XYECOM.Web.BasePage.ManagePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("chargenews");
    }

    /// <summary>
    /// 对数据进行绑定
    /// </summary>
    protected override void BindData()
    {
        string strWhere = " where 1=1";
        if (this.tbnewstitle.Value.Trim() != "")
            strWhere += " and NS_NewsName like '%" + this.tbnewstitle.Value.Trim() + "%'";
        if (this.tbcompanyname.Value.Trim() != "")
            strWhere += " and UI_Name like '%" + this.tbcompanyname.Value.Trim() + "%'";
        this.page1.RecTotal = XYECOM.Core.Function.GetRows("XYV_ChargedNews", "CI_ID", strWhere);
        DataTable dt = XYECOM.Core.Function.GetPages(this.page1.PageSize, this.page1.CurPage, strWhere, " Order by CI_ID desc", " XYV_ChargedNews", " * ", "CI_ID");
        if (dt.Rows.Count > 0)
        {
            this.lblMessage.Text = "";
            this.gvlist.DataSource = dt;
            this.gvlist.DataBind();
        }
        else
        {
            this.lblMessage.Text = "没有相关信息";
            this.gvlist.DataBind();
        }
    }

    #region 对添加时间进行转换
    /// <summary>
    /// 对添加时间进行转换
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    protected string GetDateTime(string date)
    {
        if (string.IsNullOrEmpty(date))
            return "";

        return Convert.ToDateTime(date).ToShortDateString();
    }
    #endregion

    #region 绑定
    protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
            e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");
        }
    }

    #endregion

    protected string GetNewsType(string nstype)
    {
        string type = "";
        if (string.IsNullOrEmpty(nstype))
            type = "";


        switch (nstype)
        {
            case "1":
                type = "普通新闻";
                break;
            case "2":
                type = "图片新闻";
                break;
            case "3":
                type = "标题新闻";
                break;
        }
        return type;
    }

    #region 定义分页事件
    private void Page1_PageChanged(object sender, System.EventArgs e)
    {
        BindData();
    }
    #endregion

    #region Web窗体设计器生成的代码
    protected override void OnInit(EventArgs e)
    {
        InitializeCulture();
        //this.page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
        base.OnInit(e);
    }
    private void InitializeComponent()
    {
        this.Load += new EventHandler(this.Page_Load);
        this.page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
    }
    #endregion

    #region  查询
    protected void find_Click(object sender, EventArgs e)
    {
        this.page1.CurPage = 1;
        this.BindData();
    }
    #endregion
}
