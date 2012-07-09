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
using XYECOM.Business;
using XYECOM.Core;
using System.Data.SqlClient;

public partial class xymanage_basic_SendEmail : XYECOM.Web.BasePage.ManagePage
{
    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("email");

        if (!Page.IsPostBack)
        {
            this.Page1.PageSize = 20;
            this.Button1.Attributes.Add("onclick", "javascript:return del();");
            dvDataBind();
        }
    }
    #endregion

    #region 绑定数据
    private void dvDataBind()
    {
        string strTableName = "u_SendEmail";
        this.lblMessage.Text = "";
        string strWhere = "";
        string strOrder = " order by AddTime desc ";
        this.Page1.RecTotal = Function.GetRows(strTableName, "E_ID", strWhere);
        DataTable dt = Function.GetPages(this.Page1.PageSize, this.Page1.CurPage, strWhere, strOrder, strTableName, " * ", "E_ID");
        if (dt.Rows.Count > 0)
        {
            this.gvlist.DataSource = dt;
            this.gvlist.DataBind();
        }
        else
        {
            this.lblMessage.Text = "没有相关记录";
            this.gvlist.DataBind();
        }
    }
    #endregion

    #region 删除发生出去的电子邮件
    protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            SendEmail se = new SendEmail();
            int i = 0;

            i = se.Delete(Convert.ToInt32(this.gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString()));
            string url = "SendEmail.aspx";
            if (i >= 0)
            {
                Alert("删除成功！", url);
                dvDataBind();
            }
            else
            {
                Alert("删除失败！", url);
            }
        }
    }
    #endregion

    #region 绑定数据行初始化

    protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
            e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");
        }
    }
    #endregion

    #region 分页
    private void Page1_PageChanged(object sender, System.EventArgs e)
    {
        dvDataBind();
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

    #region 删除多条记录
    protected void Button1_Click(object sender, EventArgs e)
    {
        string ids = "";
        XYECOM.Business.SendEmail se = new XYECOM.Business.SendEmail();
        foreach (GridViewRow GR in this.gvlist.Rows)
        {
            if (((CheckBox)(GR.FindControl("chkExport"))).Checked == true)
            {
                ids += "," + this.gvlist.DataKeys[GR.DataItemIndex].Value.ToString();
            }
        }
        if (ids.IndexOf(",") == 0)
        {
            ids = ids.Substring(1);
            int i = 0;
            i = se.Deletes(ids);
            string url = "SendEmail.aspx";
            if (i >= 0)
            {
                XYECOM.Business.Admin ad = new XYECOM.Business.Admin();
                XYECOM.Model.AdminInfo ea = new XYECOM.Model.AdminInfo();

                Alert("删除成功！", url);
                dvDataBind();
            }
            else
            {
                Alert("删除失败！", url);
            }
        }
    }
    #endregion 
}
