using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using XYECOM.Business;
using XYECOM.Model;

public partial class xymanage_news_ChargeNewsSetList : XYECOM.Web.BasePage.ManagePage
{
    protected string backURL2 = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("chargenews");


        if (!IsPostBack)
        {
            DataBindClumn();

            this.lnkDel.Attributes.Add("onclick", "javascript:return del();");

            if (XYECOM.Core.XYRequest.GetQueryInt("page", 0) > 0)
                page1.PageSize = XYECOM.Core.XYRequest.GetQueryInt("page", 0);
            if (!XYECOM.Core.XYRequest.GetQueryString("type").Equals(""))
                ddlType.SelectedValue = XYECOM.Core.XYRequest.GetQueryString("type");
            SetValueByquery(txtPageSize, "pagesize");
            SetValueByquery(txtdays, "isdays");
            SetValueByquery(cbdays, "cbday", "1");
        }
    }

    #region 绑定栏目下拉列表

    protected void DataBindClumn()
    {
        //this.ddcolumn.Items.Clear();
        //ListItem itemdf = new ListItem("请选择栏目", "-1");
        //this.ddcolumn.Items.Add(itemdf);
        //List<ListItem> items = _BindData(0, "|-");

        //foreach (ListItem item in items)
        //{
        //    this.ddcolumn.Items.Add(item);
        //}
    }

    private List<ListItem> _BindData(long parentID, string splitStr)
    {
        XYECOM.Business.XYClass BLL = new XYClass();

        List<ListItem> listItems = new List<ListItem>();
        List<XYECOM.Model.XYClassInfo> infos = XYECOM.Business.XYClass.GetSubItems("news", parentID);

        foreach (XYECOM.Model.XYClassInfo info in infos)
        {
            listItems.Add(new ListItem(splitStr + info.ClassName, info.ClassId.ToString()));

            if (XYECOM.Business.XYClass.IsHasSubClass("news", info.ClassId))
                listItems.AddRange(_BindData(info.ClassId, "　" + splitStr));
        }

        return listItems;
    }

    #endregion


    #region 定义页面数据绑定事件
    /// <summary>
    /// 定义页面数据绑定事件
    /// </summary>
    protected override void BindData()
    {
        string ps = this.txtPageSize.Text.Trim();
        int pagesize = 20;
        if (!string.IsNullOrEmpty(ps))
        {
            int p = XYECOM.Core.MyConvert.GetInt32(ps);
            if (p > 5)
            {
                pagesize = p;
            }
        }
        this.page1.PageSize = pagesize;

        //设置编辑或查看评论后要返回当前页面的状态
        backURL = XYECOM.Core.Utils.JSEscape("ChargeNewsSetList.aspx?page=" + page1.CurPage.ToString() + "&NewsType=" + ddlType.SelectedValue + "&KeyWord=" + txtkeyword.Text.Trim() + "&Column=" + this.hidTypeId.Value + "&pagesize=" + txtPageSize.Text + "&isdays=" + txtdays.Text + "&cbday=" + cbdays.Checked.ToString().ToLower());
        backURL2 = XYECOM.Core.Utils.JSEscape("ChargeNewsSetList.aspx?page=" + page1.CurPage.ToString() + "&NewsType=" + ddlType.SelectedValue + "&KeyWord=" + txtkeyword.Text.Trim() + "&Column=" + this.hidTypeId.Value + "&pagesize=" + txtPageSize.Text + "&isdays=" + txtdays.Text + "&cbday=" + cbdays.Checked.ToString().ToLower());

        string strWhere = " IsChargeNews = 1 ";
        if (this.ddlType.SelectedValue != "0")
            strWhere += "and NS_Type=" + this.ddlType.SelectedValue;
        if (Request.QueryString["NT_ID"] != null)
            strWhere += "and NT_ID=" + int.Parse(Request.QueryString["NT_ID"].ToString());
        if (this.txtkeyword.Text != "")
            strWhere += " and NS_NewsName like '%" + this.txtkeyword.Text + "%'";
        if (!string.IsNullOrEmpty(this.hidTypeId.Value) && this.hidTypeId.Value != "-1")
            strWhere += " and (NT_ID = '" + this.hidTypeId.Value + "' or PATINDEX('" + this.hidTypeId.Value + ",%',NT_ID) <>0 or PATINDEX('%," + this.hidTypeId.Value + ",%',NT_ID) <>0 or PATINDEX('%," + this.hidTypeId.Value + "',NT_ID) <>0) ";

        if (this.txtauthor.Text != "")
        {
            strWhere += " and NS_NewsAuthor like '%" + this.txtauthor.Text + "%'";
        }

        if (this.ddlState.SelectedValue != "-1")
        {
            strWhere += " and " + this.ddlState.SelectedValue;
        }

        if (this.cbIsFlag.Checked)
        {
            strWhere += " and NS_IsCommand = 1";
        }

        if (this.cbIsDiscuss.Checked)
        {
            strWhere += " and NS_IsDiscuss = 1";
        }

        if (this.cbIsTop.Checked)
        {
            strWhere += " and NS_IsTop = 1";
        }

        if (this.cbIsHot.Checked)
        {
            strWhere += " and NS_IsHot = 1";
        }

        if (this.cbIsSlide.Checked)
        {
            strWhere += " and NS_IsSlide = 1";
        }

        if (this.txtnewskeywords.Text != "")
        {
            strWhere += " and NS_KeyWord like '%" + this.txtnewskeywords.Text + "%'";
        }

        string begindate = this.bgdate.Value;
        string enddate = this.egdate.Value;
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

        if (begindate != "" && enddate != "")
            strWhere += " and (NS_AddTime between '" + begindate + "' and '" + enddate + "')";



        if (this.txtdays.Text != "" && this.cbdays.Checked)
        {
            strWhere += " and datediff(day,NS_AddTime,getdate())<=" + (XYECOM.Core.MyConvert.GetInt32(this.txtdays.Text) - 1) + " and datediff(day,NS_AddTime,getdate())>=0 ";
        }

        int totalRecord = 0;

        DataTable news = XYECOM.Business.Utils.GetPaginationData("XYV_News", "NS_ID", "NS_ID,NS_NewsName,NS_Type,NS_Count,NT_ID,AuditingState,NS_IsCommand,NS_HTMLPage,NT_TempletFolderAddress", "NS_ID desc", strWhere, XYECOM.Core.MyConvert.GetInt32(this.txtPageSize.Text), this.page1.CurPage, out totalRecord);

        this.page1.RecTotal = totalRecord;

        if (news.Rows.Count > 0)
        {
            this.gvlist.DataSource = news;
            this.gvlist.DataBind();
        }
        else
        {
            this.gvlist.DataBind();
            this.lblMessage.Text = "没有相关新闻!";
        }
    }
    #endregion

    #region 绑定新闻类型
    public string IsType(string type)
    {
        if (type == "1")
        {
            return "<img src='../images/text.gif' alt='普通新闻' />";
        }
        else if (type == "2")
        {
            return "<img src='../images/picture.gif' alt='图片新闻' />";
        }
        else
        {
            return "<img src='../images/blend.gif' alt='标题新闻' />";
        }
    }
    #endregion

    #region 在数据绑定前进行新闻类型和审核状态转换
    /// <summary>
    /// 在数据绑定前进行新闻类型和审核状态转换
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
            e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

            LinkButton lb = (LinkButton)e.Row.Cells[6].Controls[0];
            if (lb.Text == "1")
                lb.Text = "通过审核";
            else if (lb.Text == "0")
                lb.Text = "未通过审核";

            LinkButton LB = (LinkButton)e.Row.Cells[5].Controls[0];
            if (LB.Text == "True")
                LB.Text = "推荐";
            else if (LB.Text == "False")
                LB.Text = "不推荐";
        }
    }
    #endregion

    #region 栏目名称
    /// <summary>
    /// 得到新闻栏目名称
    /// </summary>
    /// <param name="ntid"></param>
    /// <returns></returns>
    protected string GetTitlsName(object ntid)
    {
        string temp = "";
        XYECOM.Business.NewsTitles nt = new XYECOM.Business.NewsTitles();
        if (ntid != null && ntid.ToString() != "")
        {
            string[] arr = ntid.ToString().Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                XYECOM.Model.NewsTitlesInfo info = nt.GetItem(XYECOM.Core.MyConvert.GetInt32(arr[i]));

                if (info == null) continue;

                temp += i > 0 ? "," : "";
                temp += info.Name;
            }
        }
        return temp;
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
        InitializeComponent();
        base.OnInit(e);
    }

    private void InitializeComponent()
    {
        this.Load += new System.EventHandler(this.Page_Load);
        this.page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
    }

    #endregion

    #region 定义页面内响应事件
    /// <summary>
    /// 定义页面内响应事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        XYECOM.Business.Auditing audBLL = new Auditing();

        int row = Convert.ToInt32(e.CommandArgument);
        Int64 id = Convert.ToInt64(this.gvlist.DataKeys[row][0].ToString());

        LinkButton lb = (LinkButton)this.gvlist.Rows[row].Cells[6].Controls[0];
        LinkButton LB = (LinkButton)this.gvlist.Rows[row].Cells[5].Controls[0];
        XYECOM.Business.News ne = new XYECOM.Business.News();


        if (e.CommandName == "ChangeAuditing")
        {
            if (lb.Text == "通过审核")
            {
                audBLL.UpdatesAuditing(id, "n_news", XYECOM.Model.AuditingState.NoPass);
            }
            else if (lb.Text == "未通过审核")
            {
                audBLL.UpdatesAuditing(id, "n_news", XYECOM.Model.AuditingState.Passed);
            }
        }

        if (e.CommandName == "ChangeCommand")
        {
            if (LB.Text == "推荐")
            {
                ne.UpdateForCommand(id, false);
            }
            else if (LB.Text == "不推荐")
            {
                ne.UpdateForCommand(id, true);
            }
        }
        BindData();
    }
    #endregion

    protected string GetHref(string newsId, string folder)
    {
        folder = folder.Trim();
        if (!folder.Equals("")) folder = folder + "/";

        if (webInfo.IsBogusStatic)
            return webInfo.WebDomain + "news/" + folder + "content-" + newsId + "." + webInfo.WebSuffix;
        else
            return webInfo.WebDomain + "news/" + folder + "content." + webInfo.WebSuffix + "?ns_id=" + newsId;
    }

    #region 定义单击删除按钮事件
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
        ChargeNewsSet ct = new ChargeNewsSet();
        int rowAff = ct.Delete(id);
        if (rowAff < 0)
        {
            Alert("删除失败,可重新操作。");
        }
        BindData();
    }
    #endregion

    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.page1.CurPage = 1;
        lblMessage.Text = "";
        this.BindData();
    }

    #region 定义过滤字查询事件
    protected void btnFind_Click(object sender, EventArgs e)
    {
        this.page1.CurPage = 1;
        lblMessage.Text = "";
        this.BindData();
    }
    #endregion

}
