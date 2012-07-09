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

public partial class xymanage_ShowInfoManage_ShowInfoList : XYECOM.Web.BasePage.ManagePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("exhibition");

        if (!IsPostBack)
        {
            SetValueByquery(page1, "page");
            SetValueByquery(txtKeyword, "keyword");
            SetValueByquery(hidTypeId, "typeid");
            SetValueByquery(txtBeginDate, "begindate");
            SetValueByquery(txtEndDate, "enddate");            
            SetValueByquery(rblIsCommend, "iscommend");
            SetValueByquery(rdolistShowType, "showtype");

            this.page1.PageSize = 20;

            this.lnkDel.Attributes.Add("onclick", "javascript:return del()");
            btnCreateHtml.Attributes.Add("onclick", "javascript:return ChkSelete();");
            btnDelHtml.Attributes.Add("onclick", "javascript:return ChkSelete();");
        }
    }

    #region 数据绑定事件
    protected override void BindData()
    {
        //设置编辑或查看后要返回当前页面的状态
        backURL = XYECOM.Core.Utils.JSEscape(
            "ShowInfoList.aspx?"+
            "&page=" + page1.CurPage.ToString() +
            "&keyWord=" + txtKeyword.Text.Trim() +
            "&typeid=" + hidTypeId.Value.Trim() +
            "&begindate=" + txtBeginDate.Text.Trim() +
            "&enddate=" + txtEndDate.Text.Trim() +
            "&showtype=" + rdolistShowType.SelectedValue +
            "&iscommend=" + rblIsCommend.Text.Trim() + "");

        //判断时间是否符合标准
        string begindate = txtBeginDate.Text.Trim();
        string enddate = txtEndDate.Text.Trim();
        try
        {
            DateTime bgdate = Convert.ToDateTime(begindate);
        }
        catch (Exception)
        {
            begindate = "";
        }
        try
        {
            DateTime eddate = Convert.ToDateTime(enddate);
        }
        catch (Exception)
        {
            enddate = "";
        }




        string strwhere = "1=1 ";
        this.lblMessage.Text = "";

        //标题
        if (this.txtKeyword.Text.Trim() != "")
        {
            strwhere += " and  infotitle like '%" + this.txtKeyword.Text.Trim() + "%' ";
        }
        //类别
        if (hidTypeId.Value.Trim() != "")
        {
            strwhere += " and  typeid = " + hidTypeId.Value.Trim() + " ";
        }

        //开始日期
        if (txtBeginDate.Text.Trim() != "")
        {
            strwhere += " and  SD_PublishDate >= '" + begindate + "' ";
        }
        //结束日期
        if (txtEndDate.Text.Trim() != "")
        {
            strwhere += " and SD_PublishDate <= '" + enddate + "' ";
        }

        //是否推荐
        if (rblIsCommend.Text.Trim() != "-1")
        {
            strwhere += " and IsCommend = " + rblIsCommend.Text.Trim();
        }

        if (!rdolistShowType.SelectedValue.Equals("所有"))
        {
            if (rdolistShowType.SelectedValue.Equals("国内展")) strwhere += " and type ='国内展' ";

            if (rdolistShowType.SelectedValue.Equals("国外展")) strwhere += " and type ='国外展' ";
        }

        int totalRecord = 0;

        DataTable dt = XYECOM.Business.Utils.GetPaginationData("XYV_ShowInfo", "id", "id,infotitle,IsCommend,addInfoTime,HtmlPage", "id desc", strwhere, this.page1.PageSize, this.page1.CurPage, out totalRecord);

        this.page1.RecTotal = totalRecord;

        if (dt.Rows.Count > 0)
        {
            this.gvlist.DataSource = dt;
            this.gvlist.DataBind();
        }
        else
        {
            this.lblMessage.Text = "没有相关信息";
            dt.Rows.Add(dt.NewRow());
            gvlist.DataSource = dt;
            this.gvlist.DataBind();
            int coulumnCount = gvlist.Rows[0].Cells.Count;
            gvlist.Rows[0].Cells.Clear();
            gvlist.Rows[0].Cells.Add(new TableCell());
        }
    }
    #endregion

    #region 单击删除事件
    protected void lnkDel_Click(object sender, EventArgs e)
    {
        XYECOM.Business.Show cp = new XYECOM.Business.Show();
        string ids = "";
        foreach (GridViewRow row in this.gvlist.Rows)
        {
            if (((CheckBox)(row.FindControl("chkExport"))).Checked == true)
            {
                if (ids.Equals(""))
                {
                    ids += this.gvlist.DataKeys[row.DataItemIndex].Value.ToString();
                }
                else
                {
                    ids += "," + this.gvlist.DataKeys[row.DataItemIndex].Value.ToString();
                }
            }
        }
        //if (ids.IndexOf(",") == 0)
        //    ids.Substring(1);

        int rowAffected = cp.Delete(ids);
        if (rowAffected < 0)
        {
            Alert("删除失败,可重新操作.");
        }
        BindData();
    }
    #endregion

    #region gridview控件内响应事件
    protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        XYECOM.Business.Show cp = new XYECOM.Business.Show();
        int row = Convert.ToInt32(e.CommandArgument); //获取行号
        Int64 CIID = Convert.ToInt64(gvlist.DataKeys[row].Value); //获取展会信息的编号
        
        string title = "";
        if (gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)]["Infotitle"].ToString() != "")
        {
            title = gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)]["Infotitle"].ToString();
        }
        if (e.CommandName == "SetCommend")
        {
            int rowAffter = 0;
            LinkButton LB = (LinkButton)gvlist.Rows[row].Cells[4].Controls[0];
            if (LB.Text == "推荐")
                rowAffter = cp.SetIsCommend(CIID, false);
            else if (LB.Text == "不推荐")
                rowAffter = cp.SetIsCommend(CIID, true);

            if (rowAffter < 0)
            {
                Alert("抱歉,第" + row + "行的推荐状态更改失败,可重新操作.");
            }
        }
        BindData();
    }
    #endregion

    #region 点击查询按钮事件
    protected void btFind_Click(object sender, EventArgs e)
    {
        this.page1.CurPage = 1;
        lblMessage.Text = "";
        this.BindData();
    }
    #endregion

    #region 定义分页事件
    private void Page1_PageChanged(object sender, System.EventArgs e)
    {
        BindData();
    }
    #endregion

    #region Web窗体设计器生成的代码
    protected override void OnInit(EventArgs e)
    {
        this.Load += new EventHandler(this.Page_Load);
        this.page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
        base.OnInit(e);
    }
    #endregion


    #region gridview控件绑定数据事件
    protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
            e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

            LinkButton LB = (LinkButton)e.Row.Cells[4].Controls[0];

            if (LB.Text.ToLower() == "true")
                LB.Text = "推荐";
            else if (LB.Text.ToLower() == "false")
                LB.Text = "不推荐";
        }
    }
    #endregion

   
    protected void btnCreateHtml_Click(object sender, EventArgs e)
    {
        string j = "";

        foreach (GridViewRow GR in this.gvlist.Rows)
        {
            if (((CheckBox)(GR.FindControl("chkExport"))).Checked == true)
            {
                j += "" == j ? "" : ",";
                j += gvlist.DataKeys[GR.DataItemIndex].Value.ToString();
            }
        }
        if ("" != j)
        {
            CreateHTML(j, "othermodule", "exhibition");
            Alert("已加入生成页面任务列表！");
        }
    }

    protected void btnDelHtml_Click(object sender, EventArgs e)
    {
        string j = "";

        foreach (GridViewRow GR in this.gvlist.Rows)
        {
            if (((CheckBox)(GR.FindControl("chkExport"))).Checked == true)
            {
                j += "" == j ? "" : ",";
                j += gvlist.DataKeys[GR.DataItemIndex].Value.ToString();
            }
        }
        if ("" != j)
        {
            DeleteHTML(j, "othermodule", "exhibition");

            Alert("已加入删除页面任务列表！");
        }
        Response.Redirect(backURL);
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        Response.Redirect("ShowAdd.aspx");
    }

    protected override string GetInfoUrl(string staticPage, string infoId)
    {
        //htmlPage
        //id
        if (string.IsNullOrEmpty(staticPage)) 
        {
            if (webInfo.IsBogusStatic)
                return webInfo.WebDomain + "exhibition/info-" + infoId + "." + webInfo.WebSuffix;
            else
                return webInfo.WebDomain + "exhibition/info." + webInfo.WebSuffix + "?infoid=" + infoId;
        }
        else 
        {
            return webInfo.WebDomain + staticPage;
        }
    }
}
