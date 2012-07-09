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
using XYECOM.Core;
using XYECOM.Business;

public partial class xymanage_FriendLink_List : XYECOM.Web.BasePage.ManagePage
{
    #region 定义页面加载事件
     /// <summary>
    /// 定义页面加载事件
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e) 
	{
        CheckRole("friendlink");
    }
    #endregion

	#region 定义数据绑定事件
     /// <summary>
     /// 定义数据绑定事件
     /// </summary>
    protected override void BindData()
	{
        if (XYECOM.Core.XYRequest.GetQueryInt("page", 0) > 0)
            this.Page1.CurPage = XYECOM.Core.XYRequest.GetQueryInt("page", 0);

        if (XYECOM.Core.XYRequest.GetQueryString("State") != "" && XYECOM.Core.XYRequest.GetQueryString("State") != "-1")
            this.LinkType.SelectedValue = XYECOM.Core.XYRequest.GetQueryString("state");

        this.lnkDel.Attributes.Add("onclick", "javascript:return del();");

        this.Page1.PageSize = 50;

        //设置编辑或查看后要返回当前页面的状态
        backURL = XYECOM.Core.Utils.JSEscape("page=" + Page1.CurPage.ToString() + "&State=" + LinkType.SelectedValue);

		string strWhere = " where 1=1 ";

		if (this.LinkType.SelectedValue != "-1") 
			strWhere += "and FL_Type=" + this.LinkType.SelectedValue;
		this.Page1.RecTotal = Function.GetRows("XYV_FriendLink","FL_ID", strWhere);
        DataTable dt = Function.GetPages(this.Page1.PageSize, this.Page1.CurPage, strWhere, "Order by FL_ID DESC", "XYV_FriendLink", "FL_ID,FL_Type,FL_Font,FL_URL,FL_Alt,FL_Flag,FL_IsCommend,FS_ID,FS_Name", "FL_ID");

		if (dt.Rows.Count > 0) 
		{
			this.gvList.DataSource = dt;
			this.gvList.DataBind();
		}
		else 
		{
			this.gvList.DataBind();
			this.lblMessage.Text = "没有相关信息！";
		}
	}
	#endregion

    #region 数据绑定前对行指定数据进行转换
    /// <summary>
	/// 数据绑定前对行指定数据进行转换
	/// </summary>
    /// <param name="sender">激发事件对象</param>
    /// <param name="e">响应对象集</param>
	protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e) 
	{
		if (e.Row.RowType == DataControlRowType.DataRow) 
		{
            e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
            e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

            if (e.Row.Cells[5].Text.Length > 20)
                e.Row.Cells[5].Text = XYECOM.Core.Utils.IsLength(20, e.Row.Cells[5].Text);

			LinkButton LB = (LinkButton)e.Row.Cells[7].Controls[0];

            if (LB.Text == "True")
            {
                LB.Text = CHECK_IMG_URL;
                LB.ToolTip = DISPLAY_TOOLTIP;
            }
            else if (LB.Text == "False")
            {
                LB.Text = UNCHECK_IMG_URL;
                LB.ToolTip = UNDISPLAY_TOOLTIP;
            }

            LB = (LinkButton)e.Row.Cells[8].Controls[0];

            if (LB.Text == "True")
            {
                LB.Text =  CHECK_IMG_URL;
                LB.ToolTip = COMMEND_TOOLTIP;
            }
            else if (LB.Text == "False")
            {
                LB.Text = UNCHECK_IMG_URL;
                LB.ToolTip = UNCOMMEND_TOOLTIP;
            }
		}

	}
	#endregion

	#region 单击激发推荐和审查
	/// <summary>
	/// 单击激发推荐和审核状态的转变
	/// </summary>
    /// <param name="sender">激发事件对象</param>
    /// <param name="e">响应对象集</param>
    protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        short IRowNow = Convert.ToInt16(e.CommandArgument);
        short ID = Convert.ToInt16(gvList.DataKeys[IRowNow].Value);
        XYECOM.Business.FriendLink fl = new XYECOM.Business.FriendLink();

        if (e.CommandName == "ChangeFlag")
        {
            LinkButton LB = (LinkButton)gvList.Rows[IRowNow].Cells[7].Controls[0];
            if (LB.ToolTip == DISPLAY_TOOLTIP)
                fl.UpdateForFlag(ID, false);
            else if (LB.ToolTip == UNDISPLAY_TOOLTIP)
                fl.UpdateForFlag(ID, true);
        }

        if (e.CommandName == "SetCommend")
        {
            LinkButton LB = (LinkButton)gvList.Rows[IRowNow].Cells[8].Controls[0];

            if (LB.ToolTip == COMMEND_TOOLTIP)
                fl.UpdateIsCommend(ID, false);
            else if (LB.ToolTip == UNCOMMEND_TOOLTIP)
                fl.UpdateIsCommend(ID, true);
        }

        lblMessage.Text = "";
        BindData();
    }
	#endregion

	#region 删除选择项
     /// <summary>
     /// 单击删除按钮操作
     /// </summary>
     /// <param name="sender">激发事件对象</param>
     /// <param name="e">响应对象集</param>
    protected void lnkDel_Click1(object sender, EventArgs e)
    {
        string id = "";
        XYECOM.Business.FriendLink fl = new XYECOM.Business.FriendLink();
        foreach (GridViewRow row in this.gvList.Rows)
        {
            if (((CheckBox)(row.FindControl("chkExport"))).Checked == true)
                id += "," + this.gvList.DataKeys[row.DataItemIndex].Value.ToString();
        }
        if (id.IndexOf(",") == 0)
            id = id.Substring(1);
        int rowAffected = fl.Delete(id);

        if (rowAffected < 0)
        {
            Alert("删除失败,可重新操作.", "List.aspx");
        }
        BindData();
    }
	#endregion

	#region 添加新链接
	/// <summary>
	/// 单击添加新链接按钮操作
	/// </summary>
	/// <param name="sender">激发事件对象</param>
	/// <param name="e">响应对象集</param>
	protected void lnkAdd_Click1(object sender, EventArgs e) 
	{
		Response.Redirect("AddNewLink.aspx");
	}
	#endregion

	#region 查询
    /// <summary>
	/// 查询操作
	/// </summary>
	/// <param name="sender">激发事件对象</param>
	/// <param name="e">响应对象集</param>
	protected void btnFind_Click(object sender, EventArgs e) 
	{
		this.Page1.CurPage = 1;
		lblMessage.Text = "";
		this.BindData();
	}
	#endregion

    #region 定义分页事件
     /// <summary>
     /// 定义分页事件
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
    private void Page1_PageChanged(object sender, System.EventArgs e)
    {
        BindData();
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

    #region 根据链接类型显示相应图标
    /// <summary>
    /// 根据链接类型显示相应图标
    /// </summary>
    /// <param name="type">该链接的类型</param>
    /// <returns>相应图标的DIV层</returns>
    public string GetPic(string type)
    {
        if (type == "False")
        {
            return "<div align=center><img src='../images/text.gif' alt='文字链接' /></div>";
        }
        else
        {
            return "<div align=center><img src='../images/picture.gif' alt='图片链接' /></div>";
        }
    }
    #endregion
}
