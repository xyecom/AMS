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

public partial class xymanage_basic_Server : XYECOM.Web.BasePage.ManagePage
{
    #region 
    string url = "Server.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("basic");
        if (!Page.IsPostBack)
        {
            InitPage();

            this.Page1.PageSize = 10;
            this.btnOk.Attributes.Add("onclick", "javascript:return ServerAdd();");
            this.btupdate.Attributes.Add("onclick", "javascript:return ServerEdit();");
            ServerDataList();
        }
    }

    private void InitPage()
    {
        lbServerPath.Text = Server.MapPath("/");
        serverpath.Text = lbServerPath.Text + @"upload\";
        lbHttpPath.Text = "http://" + Request.Url.Host + "/";
        serversul.Text = lbHttpPath.Text + "upload/";
    }
    #endregion

    #region Web 窗体设计器生成的代码
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    ///		设计器支持所需的方法 - 不要使用代码编辑器
    ///		修改此方法的内容。
    /// </summary>


    private void InitializeComponent()
    {
        this.Load += new System.EventHandler(this.Page_Load);
        this.Page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
    }
       #endregion

    #region 翻页
    private void Page1_PageChanged(object sender, EventArgs e)
    {
        ServerDataList();
    }
   #endregion 

    #region 绑定数据
    private void ServerDataList()
    {
        string strwhere = "";
        this.lblMessage.Text = "";
        string orderby = "";
        this.Page1.RecTotal = Function.GetRows("b_Server", "S_ID", "");
        DataTable dt;
        dt= Function.GetPages(this.Page1.PageSize, this.Page1.CurPage, strwhere, orderby, "b_Server ", " * ", " S_ID ");
        if (dt.Rows.Count > 0)
        {
            this.gvlist.DataSource = dt;
            this.DataBind();
        }
        else
        {
            this.lblMessage.Text = "没有相关记录";
            this.DataBind();
        }
    }
    #endregion 

    #region 删除操作
    protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            Server s = new Server();
            int s_id = Convert.ToInt32(this.gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
            if (!(s.IsUsed(s_id))) {
                int i = 0;
                i = s.Delete(s_id);
                if (i >= 0)
                {
                    Reload();
                }
            }
            else
            {
                Alert("服务器目录已有相关资源，不能删除!", url);
            }
        }
        else if (e.CommandName == "up")
        {
            XYECOM.Model.ServerInfo es = new XYECOM.Model.ServerInfo();
            XYECOM.Business.Server s = new XYECOM.Business.Server();

            this.key.Value = "2";
            this.S_ID.Value = this.gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

            es = s.GetItem(Convert.ToInt32(this.gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString()));

            this.txtname1.Text = es.S_Name.ToString();
            this.serverpath1.Text = es.S_Path.ToString(); ;
            this.serversul1.Text = es.S_URL.ToString();
        }
    }
    #endregion 

    #region 修改服务器
    protected void Submit1_ServerClick(object sender, EventArgs e)
    {
        XYECOM.Business.Server s = new XYECOM.Business.Server();
        XYECOM.Model.ServerInfo es = new XYECOM.Model.ServerInfo();

        es.S_ID = Convert.ToInt32(this.S_ID.Value);
        es.S_Name = this.txtname1.Text;
        es.S_Path = this.serverpath1.Text;
        es.S_URL = this.serversul1.Text;
        int i = 0;
        i = s.Update(es);
        if (i >= 0)
        {
            Reload();            
        }
        else
        {
            Alert("修改失败！", url);
        }
    }
    #endregion 

    #region 添加服务器
    protected void btnOk_ServerClick(object sender, EventArgs e)
    {
        XYECOM.Business.Server s = new XYECOM.Business.Server();
        XYECOM.Model.ServerInfo es = new XYECOM.Model.ServerInfo();

        es.S_Name = this.txtName.Text;
        es.S_Path = this.serverpath.Text;
        es.S_URL = this.serversul.Text;
        if (this.lbimage.Checked == true)
        {
            es.S_Flag = false;
        }
        if (this.lbwenzi.Checked == true)
        {
            es.S_Flag = true;
        }
        if (this.rbyes.Checked == true)
        {
            es.S_IsCurrent = true;
        }
        if (this.rbno.Checked == true)
        {
            es.S_IsCurrent = false;
        }
        int i = 0;
        i = s.Insert(es);
        if (i >= 0)
        {
            this.key.Value = "3";
            Reload();
        }
        else
        {
            Alert("添加失败！", url);
        }
    }
    #endregion

    protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
            e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

            if (e.Row.Cells[5].Text== "True")
            {
                e.Row.Cells[5].Text = "文件";
            }
            else 
            {
               e.Row.Cells[5].Text = "图片";
            }    
        }
    }

    protected void lbtnChecked_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;

        int ID = int.Parse(lbtn.CommandArgument.ToString());
        new XYECOM.Business.Server().UpdateIsCurrent(ID);
        
        ServerDataList();
    }

    protected void btnCanel_Click(object sender, EventArgs e)
    {
        this.key.Value = "1";
    }
}
