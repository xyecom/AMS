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
using XYECOM.Core;
using XYECOM.Business;

public partial class xymanage_LabelManage_LabelTypeList : XYECOM.Web.BasePage.ManagePage
{
    public string LT_ParentID = "0";

    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("label");

        if (!IsPostBack)
        {
            this.Page1.PageSize = 20;
            gvlistDataBind();
        }
    }
    #endregion

    #region 绑定数据
    private void gvlistDataBind()
    {
        this.lblMessage.Text = "";
        string strWhere = " where LT_ParentID=0 ";
        string strOrder = " order by LT_ID DESC ";
        string strTableName = "b_LabelType";
        if (XYRequest.GetQueryString("LT_ParentID") != "")
        {
            strWhere = " where LT_ParentID=" + XYRequest.GetQueryString("LT_ParentID");
            LT_ParentID = XYRequest.GetQueryString("LT_ParentID");
        }


        this.Page1.RecTotal = Function.GetRows(strTableName, "LT_ID", strWhere);

        DataTable dt = Function.GetPages(this.Page1.PageSize, this.Page1.CurPage, strWhere, strOrder, strTableName, " * ", "LT_ID");
        if (dt.Rows.Count > 0)
        {
            this.gvList.DataSource = dt;
            this.gvList.DataBind();
        }
        else
        {
            this.gvList.DataBind();
            this.lblMessage.Text = "没有相关记录";
        }
    }
    #endregion

    #region 绑定序号
    protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //判断是否数据行
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
            e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");
        }
    }
    #endregion

    #region 删除
    protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strurl = "";

        XYECOM.Business.LabelType lt = new XYECOM.Business.LabelType();

        if (this.Request.QueryString["LT_ParentID"] != null)
            strurl = "?LT_ParentID=" + this.Request.QueryString["LT_ParentID"].ToString();
        int err = lt.Delete(Convert.ToInt32(gvList.DataKeys[e.RowIndex].Value.ToString()));
        if (err > 0)
        {
            Alert("标签类别删除成功！", "LabelTypeList.aspx" + strurl);
        }
        else
        {
            Alert("标签类别删除失败！请稍后再试！", "LabelTypeList.aspx" + strurl);
        }
    }
    #endregion

    #region Web 窗体设计器生成的代码
    override protected void OnInit(EventArgs e)
    {
        this.Load += new System.EventHandler(this.Page_Load);
        this.Page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
        base.OnInit(e);
    }
    #endregion

    #region 翻页
    void Page1_PageChanged(object sender, EventArgs e)
    {
        this.gvlistDataBind();
    }
    #endregion
}
