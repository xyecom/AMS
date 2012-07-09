using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
public partial class xymanage_UserControl_page : System.Web.UI.UserControl
{

    //声明翻页事件
    public delegate void EventHandler(object sender, EventArgs e);
    public event EventHandler PageChanged;
    protected virtual void OnPageChanged(object sender, EventArgs e)
    {
        if (PageChanged != null)
        {
            PageChanged(sender, e);
        }
    }

    private void Page_Load(object sender, System.EventArgs e)
    {
        if (!this.IsPostBack)
        {
            // 初始化当前为第一页
            this.ViewState["CurPage"] = 1;
            this.PagerBind();
        }
    }

    #region Web 窗体设计器生成的代码
    override protected void OnInit(EventArgs e)
    {
        this.Load += new System.EventHandler(this.Page_Load);

        this.btn_pagefirst.Click += new System.EventHandler(PageButtonClick);

        this.btn_pageprev.Click += new System.EventHandler(this.PageButtonClick);
        this.btn_pagenext.Click += new System.EventHandler(this.PageButtonClick);
        this.btn_pagelast.Click += new System.EventHandler(this.PageButtonClick);

        this.txtToPage.Attributes.Add("onkeypress", "if(event.keyCode==13)btnToPage.onclick();");

        base.OnInit(e);
    }
    #endregion

    #region DividePage控件使用帮助及参数说明
    /*
		本控件带有三个自定义属性和一个方法.具体如下:
		属性:
		 RecTotal 记录总数 默认值:0
		 PageSize 每页记录数 默认值:0
		 CurPage  当前页  默认值:0
		方法:
		 PagerBind 绑定当前自定义控件,如不绑定,该控件则不能显示到页面上
		*/
    #endregion

    #region 公用用参数传递
    public int RecTotal //记录总数
    {
        get
        {
            if (ViewState["RecTotal"] == null)
                return 0;
            else
                return (int)ViewState["RecTotal"];
        }
        set
        {
            ViewState["RecTotal"] = value;
            this.PagerBind();
        }
    }

    public int PageSize //每页记录数
    {
        get
        {
            if (ViewState["PageSize"] == null)
                return 1;
            else
                return (int)ViewState["PageSize"];
        }
        set { ViewState["PageSize"] = value; }
    }

    public int CurPage //当前页
    {
        get
        {
            int value = 0;
            if (ViewState["CurPage"] != null)
                value = (int)ViewState["CurPage"];

            if (value <= 0) return 1;

            return value;
        }
        set
        {
            ViewState["CurPage"] = value;
        }
    }
    private int PageTotal
    {
        get
        {
            if (ViewState["PageTotal"] == null)
                return 0;
            else
                return (int)ViewState["PageTotal"];
        }
        set
        {
            ViewState["PageTotal"] = value;
        }
    }

    //显示模式 simple:简单模式,normal：正常模式
    private string mode = "normal";
    public string Mode
    {
        set { mode = value; }
        get { return mode; }
    }
    #endregion

    #region 相关方法及事件
    private void PagerBind()
    {
        PageTotal = (RecTotal % PageSize > 0) ? RecTotal / PageSize + 1 : RecTotal / PageSize;//页总数
        //lbl_pagecount.Text=PageTotal.ToString();

        if (mode.Equals("normal"))
            this.lbl_PageInfo.Text = "共有记录&nbsp;" + RecTotal.ToString() + "&nbsp;条&nbsp;每页&nbsp;" + PageSize.ToString() + "&nbsp;条";
        else
            this.lbl_PageInfo.Text = "" + RecTotal.ToString() + "条";

        if (CurPage > PageTotal)
        {
            this.CurPage--;
        }
        if (this.ViewState["CurPage"] == null)
        {
            this.ViewState["CurPage"] = 1;
        }
        ViewState["CurrPage"] = ((int)ViewState["CurPage"]);
        this.txtToPage.Text = CurPage.ToString();//当前页
        btn_pagefirst.Enabled = true;
        btn_pageprev.Enabled = true;
        btn_pagenext.Enabled = true;
        btn_pagelast.Enabled = true;

        if (CurPage == 1)//判断是否为首页
        {
            btn_pagefirst.Enabled = false;
            btn_pageprev.Enabled = false;
            btn_pagenext.Enabled = true;
            btn_pagelast.Enabled = true;
        }
        if (CurPage == PageTotal)
        {
            btn_pagefirst.Enabled = true;
            btn_pageprev.Enabled = true;
            btn_pagenext.Enabled = false;
            btn_pagelast.Enabled = false;
        }
        if ((PageTotal - 1) <= 0)
        {
            btn_pagefirst.Enabled = false;
            btn_pageprev.Enabled = false;
            btn_pagenext.Enabled = false;
            btn_pagelast.Enabled = false;
        }

        if (mode.Equals("simple"))
        {
            btn_pagefirst.Text = "|<";
            btn_pageprev.Text = "<";
            btn_pagenext.Text = ">";
            btn_pagelast.Text = ">|";
        }
    }

    void PageButtonClick(object sender, EventArgs e)
    {
        //获得LinkButton的参数值
        string strArg = ((LinkButton)sender).CommandName;
        switch (strArg)
        {
            case ("next"): //下页
                ViewState["CurPage"] = (int)ViewState["CurPage"] + 1;
                break;
            case ("previous"): //上页
                ViewState["CurPage"] = (int)ViewState["CurPage"] - 1;
                break;
            case ("last"): //末页
                ViewState["CurPage"] = (int)ViewState["PageTotal"];
                break;
            default: //首页 
                ViewState["CurPage"] = 1;
                break;
        }
        this.PagerBind();
        OnPageChanged(sender, e);
    }

    #endregion

    protected void btnToPage_Click(object sender, EventArgs e)
    {
        int toPage = 0;
        Int32.TryParse(this.txtToPage.Text.Trim(), out toPage);

        if (toPage <= 0) return;

        if (toPage > PageTotal) toPage = PageTotal;

        if (toPage == CurPage) return;

        ViewState["CurPage"] = toPage;

        this.CurPage = toPage;

        this.PagerBind();

        OnPageChanged(sender, e);
    }
}
