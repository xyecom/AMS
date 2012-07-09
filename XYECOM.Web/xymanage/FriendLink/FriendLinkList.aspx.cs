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

public partial class xymanage_FriendLink_FriendLinkList : XYECOM.Web.BasePage.ManagePage
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

        if (!IsPostBack)
        {            
            this.lnkDel.Attributes.Add("onclick", "javascript:return del();");
            this.page1.PageSize = 10;            
        }
    }
    #endregion 

    #region 定义数据绑定方法
     /// <summary>
    /// 定义数据绑定方法
     /// </summary>
    protected override void BindData()
    {
        string strWhere = " where FS_PID=0";
        XYECOM.Business.FriendLinkSort fl = new XYECOM.Business.FriendLinkSort();

        if (XYECOM.Core.XYRequest.GetQueryString("FS_PID") != "")
        {
            strWhere = " where FS_PID=" + XYECOM.Core.XYRequest.GetQueryString("FS_PID");
            //this.title.InnerHtml = fl.GetFriendLinkName(XYECOM.Core.XYRequest.GetQueryInt("FS_PID",0)) + "链接类别列表";
            this.lnkAdd.Text = "返回";
            //this.lnkA.Visible = true;
        }
        this.page1.RecTotal = Function.GetRows("b_FriendLinkSort", "FS_ID", strWhere);
        DataTable dt = Function.GetPages(this.page1.PageSize, this.page1.CurPage, strWhere, "Order by FS_ID DESC", "b_FriendLinkSort", "FS_ID,FS_Name,FS_PID,FS_Alt", "FS_ID");

        if (dt.Rows.Count > 0)
        {
            this.gvlist.DataSource = dt;
            this.gvlist.DataBind();
        }
        else
        {
            this.gvlist.DataBind();
            this.lblMessage.Text = "没有相关信息";
        }
    }
    #endregion

    #region 定义删除事件
     /// <summary>
     /// 定义删除事件
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
    protected void lnkDel_Click(object sender, EventArgs e)
    {
        string ids = "";
        XYECOM.Business.FriendLinkSort fs = new XYECOM.Business.FriendLinkSort();
        foreach (GridViewRow row in this.gvlist.Rows)
        {
            if (((CheckBox)(row.FindControl("chkExport"))).Checked == true)
                ids += "," + this.gvlist.DataKeys[row.DataItemIndex].Value.ToString();
        }

        if (ids.IndexOf(",") == 0)
            ids = ids.Substring(1);

        int SonNum = fs.GetSonType(ids);
        if (SonNum <= 0)
        {
            int rowAff = fs.Delete(ids);

            if (rowAff >= 0)
            {
                Response.Redirect("FriendLinkList.aspx");
            }
            else
            {
                Alert("删除成功！","FriendLinkList.aspx");
            }
        }
        else
        {
            Alert("该类别下面还有子类别,请先删除子类别！");
        }
    }
    #endregion

    #region  定义返回方法
     /// <summary>
    /// 定义数据绑定方法
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["FS_PID"] != null)
        {
            Alert("", "FriendLinkList.aspx?FS_ID=" + Request.QueryString["FS_PID"].ToString() + "");
        }
        else
        {
            Response.Redirect("FriendLinkTypeAdd.aspx");
        }
    }
    #endregion

    #region 定义分页事件
     /// <summary>
     /// 定义分页事件方法
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
        this.page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
        base.OnInit(e);
    }
    #endregion


    protected void lnkA_Click(object sender, EventArgs e)
    {
        Alert("", "FriendLinkTypeAdd.aspx?FS_ID=" + Request.QueryString["FS_PID"].ToString() + "&Type=0");
    }

    protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
            e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");
        }
    }

}
