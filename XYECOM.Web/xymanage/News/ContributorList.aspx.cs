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

using System.Data.SqlClient;
using XYECOM.Core;
using XYECOM.Business;

public partial class xymanage_news_ContributorList : XYECOM.Web.BasePage.ManagePage
{
    protected string backURL2 = "";

    #region 页面加载事件
    /// <summary>
    /// 页面加载事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("news");
        if (this.txtPageSize.Text != "")
        {
            this.page1.PageSize = XYECOM.Core.MyConvert.GetInt32(this.txtPageSize.Text);
        }
        else
        {
            this.page1.PageSize = 20;
        }
        if (!IsPostBack)
        {
            #region 设置初始值

            DataBindClumn();
            DataBindMove();
            int page = XYECOM.Core.XYRequest.GetQueryInt("page", 0);
            string NewsType = XYECOM.Core.XYRequest.GetQueryString("NewsType");
            string KeyWord = XYECOM.Core.XYRequest.GetQueryString("KeyWord");
            string Column = XYECOM.Core.XYRequest.GetQueryString("Column");

            if (page > 0) page1.CurPage = page;

            if (!string.IsNullOrEmpty(NewsType)) ddlType.SelectedValue = NewsType;

            if (!string.IsNullOrEmpty(KeyWord)) txtkeyword.Text = KeyWord;

            if (!string.IsNullOrEmpty(Column)) this.hidTypeId.Value = Column;

            if (XYECOM.Core.XYRequest.GetQueryString("IsAuditing") != "")
            {
                this.ddlState.SelectedValue = XYECOM.Core.XYRequest.GetQueryString("IsAuditing");
            }
            SetValueByquery(txtPageSize, "pagesize");
            SetValueByquery(txtdays, "isdays");
            SetValueByquery(cbdays, "cbday", "1");
            #endregion

            this.lnkDel.Attributes.Add("onclick", "javascript:return del();");
            btnCreateHtml.Attributes.Add("onclick", "javascript:return ChkSelete();");
            btnDelHtml.Attributes.Add("onclick", "javascript:return ChkSelete();");
            btnSetChargeNews.Attributes.Add("onclick", "javascript:return ChkSelete();");
            //ddlMove.Attributes.Add("onchange", "javascript:if(!ChkSelete())return;");
            btnMove.OnClientClick = "javascript:return ChkSelete();";
        }

        backURL2 = XYECOM.Core.Utils.JSEscape("ContributorList.aspx?page=" + page1.CurPage.ToString() + "&NewsType=" + ddlType.SelectedValue + "&KeyWord=" + txtkeyword.Text.Trim() + "&Column=" + this.hidTypeId.Value + "&IsAuditing=" + this.ddlState.SelectedValue + "&pagesize=" + txtPageSize.Text + "&isdays=" + txtdays.Text + "&cbday=" + cbdays.Checked.ToString().ToLower());
    }
    #endregion

    #region 数据绑定
    /// <summary>
    /// 定义数据绑定事件
    /// </summary>
    protected override void BindData()
    {
        //设置编辑或查看评论后要返回当前页面的状态
        backURL = XYECOM.Core.Utils.JSEscape("ContributorList.aspx?page=" + page1.CurPage.ToString() + "&NewsType=" + ddlType.SelectedValue + "&KeyWord=" + txtkeyword.Text.Trim() + "&Column=" + this.hidTypeId.Value + "&IsAuditing=" + this.ddlState.SelectedValue + "&pagesize=" + txtPageSize.Text + "&isdays=" + txtdays.Text + "&cbday=" + cbdays.Checked.ToString().ToLower());


        string strWhere = " 1=1 and IsChargeNews = 0 ";

        if (this.ddlType.SelectedValue != "0")
            strWhere += "and NS_Type=" + this.ddlType.SelectedValue;

        if (Request.QueryString["NT_ID"] != null)
            strWhere += "and NT_ID=" + int.Parse(Request.QueryString["NT_ID"].ToString());

        if (this.txtkeyword.Text != "")
            strWhere += " and NS_NewsName like '%" + this.txtkeyword.Text + "%'";

        if (!string.IsNullOrEmpty(this.hidTypeId.Value) && this.hidTypeId.Value != "-1")
            strWhere += " and (" + XYECOM.Business.Utils.GetNewsChannelQueryWhere(XYECOM.Core.MyConvert.GetInt32(this.hidTypeId.Value)) + ")";

        if (this.txtauthor.Text != "")
        {
            strWhere += " and NS_NewsAuthor like '%" + this.txtauthor.Text + "%'";
        }

        if (this.txtdays.Text != "" && this.cbdays.Checked)
        {
            strWhere += " and datediff(day,NS_AddTime,getdate())<=" + (XYECOM.Core.MyConvert.GetInt32(this.txtdays.Text) - 1) + " and datediff(day,NS_AddTime,getdate())>=0 ";
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


        strWhere += " and Contributor not in (0)";

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

        int totalRecord = 0;

        DataTable news = XYECOM.Business.Utils.GetPaginationData("XYV_News", "NS_ID", "NS_ID,NS_NewsName,NS_TitleStyle,NS_Type,NS_Count,NT_ID,AuditingState,NS_IsCommand,NS_HTMLPage,Contributor,NT_TempletFolderAddress", "NS_ID desc", strWhere, XYECOM.Core.MyConvert.GetInt32(this.txtPageSize.Text), this.page1.CurPage, out totalRecord);

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

    #region 定义删除新闻事件
    protected void lnkDel_Click(object sender, EventArgs e)
    {
        string id = "";
        XYECOM.Business.News en = new XYECOM.Business.News();
        foreach (GridViewRow row in this.gvlist.Rows)
        {
            if (((CheckBox)(row.FindControl("chkExport"))).Checked == true)
                id += "," + this.gvlist.DataKeys[row.DataItemIndex].Value.ToString();
        }

        if (id.IndexOf(",") == 0)
            id = id.Substring(1);

        int rowAffected = en.Delete(id);

        if (rowAffected >= 0)
        {
        }
        else
        {
            Alert("删除失败,可重新操作.");
        }
        BindData();
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

            LinkButton lb = (LinkButton)e.Row.Cells[7].Controls[0];
            if (lb.Text == "1")
                lb.Text = "通过审核";
            else if (lb.Text == "0")
                lb.Text = "未通过审核";

            LinkButton LB = (LinkButton)e.Row.Cells[6].Controls[0];
            if (LB.Text == "True")
                LB.Text = "推荐";
            else if (LB.Text == "False")
                LB.Text = "不推荐";
        }
    }
    #endregion

    #region 定义审核状态转换事件
    protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        XYECOM.Business.Auditing audBLL = new Auditing();

        int row = Convert.ToInt32(e.CommandArgument);
        Int64 id = Convert.ToInt64(this.gvlist.DataKeys[row][0].ToString());

        LinkButton lb = (LinkButton)this.gvlist.Rows[row].Cells[7].Controls[0];
        LinkButton LB = (LinkButton)this.gvlist.Rows[row].Cells[6].Controls[0];
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

    #region 定义过滤字查询事件
    protected void btnFind_Click(object sender, EventArgs e)
    {
        this.page1.CurPage = 1;
        lblMessage.Text = "";
        this.BindData();
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
            string _tyids = XYECOM.Core.Utils.RemoveComma(ntid.ToString());

            string[] arr = _tyids.Split(',');
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

    #region 更改新闻栏目
    protected string ChangeNewTitle(object nsid)
    {
        string url = "";
        if (nsid.ToString() != null && nsid.ToString() != "")
            url = "AddNews.aspx?id=" + nsid.ToString();
        return url;
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

    #region 返回企业类型和名称

    protected string Link(string id)
    {
        if (id == "-1")
        {
            return "游客";
        }

        XYECOM.Business.UserReg urBLL = new UserReg();
        XYECOM.Model.UserRegInfo urinfo = new XYECOM.Model.UserRegInfo();

        urinfo = urBLL.GetItem(XYECOM.Core.MyConvert.GetInt64(id));

        if (urinfo == null)
        {
            return "用户已删除";
        }

        return "<a href='../UserManage/UserInfo.aspx?U_ID=" + id + "&backURL=../news/ContributorList.aspx'>" + urinfo.LoginName + "</a><br/>(企业会员)";

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
            CreateHTML(j, "news", "news");
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
            DeleteHTML(j, "news", "news");
            Alert("已加入删除页面任务列表！");
        }
    }

    #region 绑定转移栏目下拉列表

    protected void DataBindMove()
    {
        //this.ddlMove.Items.Clear();
        //ListItem itemdf = new ListItem("批量转移到", "-1");
        //this.ddlMove.Items.Add(itemdf);
        //List<ListItem> items = _BindData(0, "|-");

        //foreach (ListItem item in items)
        //{
        //    this.ddlMove.Items.Add(item);
        //}
    }

    #endregion

    #region 批量转移资讯

    protected void ddlMove_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion

    protected void btnSetChargeNews_Click(object sender, EventArgs e)
    {
        string j = "";

        foreach (GridViewRow GR in this.gvlist.Rows)
        {
            if (((CheckBox)(GR.FindControl("chkExport"))).Checked == true)
            {
                j += "" == j ? "" : "|";
                j += gvlist.DataKeys[GR.DataItemIndex].Value.ToString();
            }
        }
        if ("" != j)
        {
            backURL2 = XYECOM.Core.Utils.JSEscape("ContributorList.aspx?page=" + page1.CurPage.ToString() + "&NewsType=" + ddlType.SelectedValue + "&KeyWord=" + txtkeyword.Text.Trim() + "&Column=" + this.hidTypeId.Value);
            Response.Redirect("ChargeNewsSetInfo.aspx?NS_ID=" + j + "&backURL=" + backURL2);
            BindData();
        }
    }

    protected void btnnew20_Click(object sender, EventArgs e)
    {
        this.ddlState.SelectedIndex = -1;
        BindData();
    }

    #region 批量审核
    /// <summary>
    /// 批量审核
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAuditing_Click(object sender, EventArgs e)
    {
        long newsId = 0;
        XYECOM.Business.Auditing audBLL = new Auditing();

        foreach (GridViewRow GR in this.gvlist.Rows)
        {
            if (((CheckBox)(GR.FindControl("chkExport"))).Checked == true)
            {
                newsId = XYECOM.Core.MyConvert.GetInt64(gvlist.DataKeys[GR.DataItemIndex].Value.ToString());

                if (newsId <= 0) continue;

                audBLL.UpdatesAuditing(newsId, "n_news", XYECOM.Model.AuditingState.Passed);
            }
        }

        BindData();
    }
    #endregion

    protected void btnSetTitleStyle_Click(object sender, EventArgs e)
    {
        string j = "";

        foreach (GridViewRow GR in this.gvlist.Rows)
        {
            if (((CheckBox)(GR.FindControl("chkExport"))).Checked == true)
            {
                j += "" == j ? "" : "|";
                j += gvlist.DataKeys[GR.DataItemIndex].Value.ToString();
            }
        }

        if ("" != j)
        {
            Response.Redirect("SetTitleStyle.aspx?NS_ID=" + j + "&backURL=" + backURL2);
        }
    }

    protected void btnMove_Click(object sender, EventArgs e)
    {
        String num = "";

        String content = "NT_ID='" + XYECOM.Core.Utils.AppendComma(this.typeId.Value) + "'";
        XYECOM.Business.News news = new XYECOM.Business.News();

        foreach (GridViewRow GR in this.gvlist.Rows)
        {
            if (((CheckBox)(GR.FindControl("chkExport"))).Checked == true)
            {
                num += "," + gvlist.DataKeys[GR.DataItemIndex].Value.ToString();
            }
        }
        if (num.IndexOf(',') == 0)
        {
            num = num.Substring(1);
            String strwhere = "where NS_ID in (" + num + ")";
            news.MoveNews(strwhere, content);
            BindData();
        }
    }
}
