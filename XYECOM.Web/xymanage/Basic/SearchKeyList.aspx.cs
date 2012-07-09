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
using System.IO;
public partial class xymanage_basic_SearchKeyList : XYECOM.Web.BasePage.ManagePage
{
    #region 页面加载事件
    /// <summary>
    /// 页面加载事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("hotkeyword");        
    }
    #endregion

    #region 绑定GridView的数据
    /// <summary>
    /// 绑定要GridView的数据源
    /// </summary>
    protected override void BindData()
    {
        this.lnkDel.Attributes.Add("onclick", "javascript:return del();");
        this.page1.PageSize = 20;

        BindModuleList();

        if (XYECOM.Core.XYRequest.GetQueryInt("page", 0) > 0)
            page1.CurPage = XYECOM.Core.XYRequest.GetQueryInt("page", 0);

        if (!XYECOM.Core.XYRequest.GetQueryString("type").Equals(""))
            ddlModules.Text = XYECOM.Core.XYRequest.GetQueryString("type");

        if (!XYECOM.Core.XYRequest.GetQueryString("isCommend").Equals(""))
        {
            ddlIsRanking.Text = XYECOM.Core.XYRequest.GetQueryString("isCommend");
        }

        if (!XYECOM.Core.XYRequest.GetQueryString("isRanking").Equals(""))
        {
            ddlIsRanking.Text = XYECOM.Core.XYRequest.GetQueryString("isRanking");
        }

        if (XYECOM.Core.XYRequest.GetQueryString("order").ToLower().Equals("numberofsearchs"))
            ddlOrderType.Text = XYECOM.Core.XYRequest.GetQueryString("order");

        if (!XYECOM.Core.XYRequest.GetQueryString("key").Equals(""))
            txtKey.Text = XYECOM.Core.XYRequest.GetQueryString("key");

        backURL = XYECOM.Core.Utils.JSEscape("SearchKeyList.aspx?page=" + page1.CurPage.ToString() 
            + "&type=" + ddlModules.Text.Trim()
            + "&isCommend=" + ddlIsCommend.SelectedValue
            + "&isRanking=" + ddlIsRanking.SelectedValue
            + "&order=" + this.ddlOrderType.SelectedValue 
            + "&key=" + this.txtKey.Text.Trim());

        string strWhere = "1=1";
        string orderFieldName = "SK_ID";

        if (this.ddlModules.SelectedValue != "-1")
            strWhere += " and SK_Sort= '" + this.ddlModules.SelectedValue.Trim() + "'";

        if (this.ddlIsCommend.SelectedValue != "")
        {
            if (this.ddlIsCommend.SelectedValue == "true")
                strWhere += " and SK_IsCommend ='1'";
            else
                strWhere += " and SK_IsCommend ='0'";
        }

        if (this.ddlIsRanking.SelectedValue != "")
        {
            if (this.ddlIsRanking.SelectedValue == "true")
                strWhere += " and SK_IsRanking ='1'";
            else
                strWhere += " and SK_IsRanking ='0'";  
        }

        if (!txtKey.Text.Trim().Equals(""))
            strWhere += " and SK_Name like '%" + txtKey.Text.Trim().Replace("'", "") + "%'";

        if (this.ddlOrderType.SelectedValue.ToLower().Equals("numberofsearchs"))
            orderFieldName = "sk_count";

        int seraCount = XYECOM.Core.MyConvert.GetInt32(ddlSearCount.SelectedValue);
        if (seraCount != -1)
        {
            if (seraCount == 20)
            {
                strWhere += " and SK_Count>=1 and SK_Count<=20";
            }
            if (seraCount == 40)
            {
                strWhere += " and SK_Count>=21 and SK_Count<=40";
            }
            if (seraCount == 60)
            {
                strWhere += " and SK_Count>=41 and SK_Count<=60";
            }
            if (seraCount == 61)
            {
                strWhere += " and SK_Count>=61";
            }
        }

        int totalRecord = 0;

        DataTable dt = XYECOM.Business.Utils.GetPaginationData("b_SearchKey", "SK_ID", "SK_ID,SK_Name,SK_Sort,SK_Count,SK_IsCommend,SK_IsRanking,SK_AddTime,SK_LastSearchTime", orderFieldName + " desc", strWhere, this.page1.PageSize, this.page1.CurPage, out totalRecord);

        this.page1.RecTotal = totalRecord;

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


    private void BindModuleList()
    {
        this.ddlModules.Items.Clear();
        foreach (ListItem item in GetAllModules(true))
        {
            this.ddlModules.Items.Add(item);
        }
        this.ddlModules.Items.Insert(0, new ListItem("请选择模块", "-1"));
        this.ddlModules.SelectedIndex = 0;
    }

    #region 单击删除事件
    /// <summary>
    /// 单击删除事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkDel_Click(object sender, EventArgs e)
    {
        XYECOM.Business.SearchKey SK = new XYECOM.Business.SearchKey();

        string id = "";
        foreach (GridViewRow row in this.gvlist.Rows)
        {
            if (((CheckBox)(row.FindControl("chkExport"))).Checked == true)
                id += "," + this.gvlist.DataKeys[row.DataItemIndex].Value.ToString();
        }

        if (id.IndexOf(",") == 0)
            id = id.Substring(1);
        int rowAff = SK.Delete(id);

        BindData();

        if (rowAff < 0)
        {
            Alert("删除失败,可重新操作");
        }
    }
    #endregion

    #region 定义GridView内响应事件
    /// <summary>
    /// 定义GridView内响应事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int RowNow = Convert.ToInt32(e.CommandArgument);
        Int64 keyId = Convert.ToInt64(gvlist.DataKeys[RowNow].Value);

        if (keyId <= 0) return;

        XYECOM.Business.SearchKey BLL = new XYECOM.Business.SearchKey();
        XYECOM.Model.SearchKeyInfo info = BLL.GetItem(keyId);

        if (info == null) return;

        if (e.CommandName == "SetIsCommend")
        {
            LinkButton lb = (LinkButton)gvlist.Rows[RowNow].Cells[7].Controls[0];
            if (lb.ToolTip == COMMEND_TOOLTIP)
            {
                info.SK_IsCommend = false;
            }
            else if (lb.ToolTip == UNCOMMEND_TOOLTIP)
            {
                info.SK_IsCommend = true;
            }

            BLL.Update(info);
        }

        if (e.CommandName == "SetIsRanking")
        {
            LinkButton lb = (LinkButton)gvlist.Rows[RowNow].Cells[8].Controls[0];
            if (lb.ToolTip == COMMEND_TOOLTIP)
            {
                info.SK_IsRanking = false;
            }
            else if (lb.ToolTip == UNCOMMEND_TOOLTIP)
            {
                info.SK_IsRanking = true;
            }

            BLL.Update(info);
        }

        BindData();
    }
    #endregion

    #region 定义数据绑定前转换事件
    /// <summary>
    /// 定义数据绑定前转换事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
            e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

            if (e.Row.Cells[2].Text.Length > 14)
                e.Row.Cells[2].Text = XYECOM.Core.Utils.IsLength(14, e.Row.Cells[2].Text);

            LinkButton lb = (LinkButton)e.Row.Cells[7].Controls[0];
            if (lb.Text.ToLower() == "true")
            {
                lb.Text = CHECK_IMG_URL;
                lb.ToolTip = COMMEND_TOOLTIP;
            }
            else
            {
                lb.Text = UNCHECK_IMG_URL;
                lb.ToolTip = UNCOMMEND_TOOLTIP;
            }

            lb = (LinkButton)e.Row.Cells[8].Controls[0];
            if (lb.Text.ToLower() == "true")
            {
                lb.Text = CHECK_IMG_URL;
                lb.ToolTip = COMMEND_TOOLTIP;
            }
            else
            {
                lb.Text = UNCHECK_IMG_URL;
                lb.ToolTip = UNCOMMEND_TOOLTIP;
            }
        }
    }
    #endregion

    #region 定义分页事件
    /// <summary>
    /// 定义分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page1_PageChanged(object sender, System.EventArgs e)
    {
        BindData();
    }
    #endregion

    #region 热词编号转换为热词类型
    /// <summary>
    /// 热词编号转换为热词类型
    /// </summary>
    /// <param name="sktype">热词编号</param>
    /// <returns>该编号对应类型</returns>
    protected string GetType(string sktype)
    {
        if (string.IsNullOrEmpty(sktype))
            return "";

        return GetModuleCNName(sktype);
    }
    #endregion

    #region 添加新的关键字
    protected void btadd_ServerClick(object sender, EventArgs e)
    {
        this.ClientScript.RegisterClientScriptBlock(GetType(), "01", "<script>window.location.href(\"SearchKeyInfo.aspx\")</script>");
    }
    #endregion

    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.page1.CurPage = 1;
        lblMessage.Text = "";
        this.BindData();
    }

  

    protected void btnDownload_Click(object sender, EventArgs e)
    {

        backURL = XYECOM.Core.Utils.JSEscape("SearchKeyList.aspx?page=" + page1.CurPage.ToString()
          + "&type=" + ddlModules.Text.Trim()
          + "&isCommend=" + ddlIsCommend.SelectedValue
          + "&isRanking=" + ddlIsRanking.SelectedValue
          + "&order=" + this.ddlOrderType.SelectedValue
          + "&key=" + this.txtKey.Text.Trim());

        string strWhere = "1=1";
        string orderFieldName = "SK_Count desc";

        if (this.ddlModules.SelectedValue != "-1")
            strWhere += " and SK_Sort= '" + this.ddlModules.SelectedValue.Trim() + "'";

        if (this.ddlIsCommend.SelectedValue != "")
        {
            if (this.ddlIsCommend.SelectedValue == "true")
                strWhere += " and SK_IsCommend ='1'";
            else
                strWhere += " and SK_IsCommend ='0'";
        }

        if (this.ddlIsRanking.SelectedValue != "")
        {
            if (this.ddlIsRanking.SelectedValue == "true")
                strWhere += " and SK_IsRanking ='1'";
            else
                strWhere += " and SK_IsRanking ='0'";
        }

        if (!txtKey.Text.Trim().Equals(""))
            strWhere += " and SK_Name like '%" + txtKey.Text.Trim().Replace("'", "") + "%'";

        if (this.ddlOrderType.SelectedValue.ToLower().Equals("numberofsearchs"))
            orderFieldName = "sk_count";


        DataTable dt = XYECOM.Business.Utils.ExecuteTable("b_SearchKey", "SK_Name,SK_Sort= CASE SK_Sort when 'offer' then '供求信息' when 'brand' then '行业品牌' when 'news' then '行业资讯' when 'job' then '人才招聘' when 'company' then '企业导航' when 'investment' then '招商信息信息' when 'venture' then '投融资信息' else '' end,SK_Count,SK_AddTime,SK_LastSearchTime", strWhere, orderFieldName, 20);
        //---------------------------------------
        StringWriter sw = new StringWriter();
        GridView dv = new GridView();
        dv.DataSource = dt;
        dt.Columns["SK_Name"].ColumnName = "热词名称";
        dt.Columns["SK_Sort"].ColumnName = "所属模块";
        dt.Columns["SK_Count"].ColumnName = "搜索次数";
        dt.Columns["SK_AddTime"].ColumnName = "录入时间";
        dt.Columns["SK_LastSearchTime"].ColumnName = "最后搜索时间";
        dv.DataBind();
        dv.AllowPaging = true;
        Response.ClearContent();
      
        Response.AppendHeader("Content-Disposition", "attachment;filename=KeyWords_" + DateTime.Now.ToShortDateString().ToString() + ".xls");
       
        //Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/excel";
        Response.Write("<meta http-equiv=Content-Type content=\"text/html; charset=GB2312\">");
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        dv.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
       
    }
    /// <summary>
    /// 搜索次数归零
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        XYECOM.Business.SearchKey BLL = new XYECOM.Business.SearchKey();
      foreach (GridViewRow row in this.gvlist.Rows)
        {
            if (((CheckBox)(row.FindControl("chkExport"))).Checked == true)
            {
              int  id=XYECOM.Core.MyConvert.GetInt32( this.gvlist.DataKeys[row.DataItemIndex].Value.ToString());
              XYECOM.Model.SearchKeyInfo info = BLL.GetItem(id);
              info.SK_Count = 0;
              BLL.Update(info);
            }
        }
       BindData();
    }
}
