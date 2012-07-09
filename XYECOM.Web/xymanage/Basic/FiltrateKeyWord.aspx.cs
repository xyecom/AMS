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

public partial class xymanage_basic_FiltrateKeyWord : XYECOM.Web.BasePage.ManagePage
{
    #region
    string url = "FiltrateKeyWord.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {

        CheckRole("filterkeyword");
        if (!IsPostBack)
        {
            
            this.Page1.PageSize = 10;
            gvDataBaind();
            this.btnOk.Attributes.Add("onclick", "javascript:return keywordadd();");
            this.Button2.Attributes.Add("onclick", "javascript:return keywordedit();");
            this.btndelete.Attributes.Add("onclick", "javascript:return del();");
        }
    }
    #endregion

    #region 绑定数据
    private void gvDataBaind()
    {
        string strWhere = "";
        string strOrder = " ";
        string strTableName = "b_FiltrateKeyWord";
        this.Page1.PageSize = 20;
        this.Page1.RecTotal = Function.GetRows(strTableName, "FKW_ID", strWhere);
        DataTable dt = Function.GetPages(this.Page1.PageSize, this.Page1.CurPage, strWhere, strOrder, strTableName, " * ", "FKW_ID");
        if (dt.Rows.Count > 0)
        {
            this.lblMessage.Text = "";
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

    #region 添加
    protected void btnOk_ServerClick(object sender, EventArgs e)
    {
        XYECOM.Model.FiltrateKeyWordInfo efkw = new XYECOM.Model.FiltrateKeyWordInfo();
        XYECOM.Business.FiltrateKeyWord fkw = new XYECOM.Business.FiltrateKeyWord();
        XYECOM.Business.Log l = new XYECOM.Business.Log();
        XYECOM.Model.LogInfo el = new XYECOM.Model.LogInfo();
        efkw.FKW_Name = this.txtName.Text;
        XYECOM.Model.AdminInfo ea = new XYECOM.Model.AdminInfo();
        XYECOM.Business.Admin ad = new XYECOM.Business.Admin();
        int err = 0;
        string str = this.txtName.Text.Trim();
        string[] st = str.Split(',');
        for (int i = 0; i < st.Length; i++)
        {
            efkw.FKW_Name = st[i].ToString();
            err = fkw.Insert(efkw);
        }
        if (err == -1)
        {
            el.L_Title = "过滤字管理";
            el.L_Content = "添加过滤字信息";
            el.L_MF = "系统信息设置";
            
            {
                el.UM_ID = AdminId;
            }
            l.Insert(el);
            Alert("该记录已存在！请重新输入信息！", url);
        }
        else if (err == -2)
        {
            el.L_Title = "过滤字管理";
            el.L_Content = "该记录已存在！请重新输入信息";
            el.L_MF = "系统信息设置";
            
            {
                el.UM_ID = AdminId;
            }
            Alert("添加失败！", url);
        }
        else
        {
            el.L_Title = "过滤字管理";
            el.L_Content = "添加过滤字信息成功";
            el.L_MF = "系统信息设置";
            
            {
                el.UM_ID = AdminId;
            }
            l.Insert(el);
            Alert("添加成功！", url);
        }
    }
    #endregion

    #region 删除
    protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "up")
        {
            FiltrateKeyWord fkw = new FiltrateKeyWord();
            this.key.Value = "2";
            this.va.Value = gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            XYECOM.Model.FiltrateKeyWordInfo Info = fkw.GetItem(Convert.ToInt32(gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString()));
            if (null != Info)
            {
                this.TextBox1.Text = Info.FKW_Name;
            }
        }
    }
    #endregion

    #region 分页
    private void Page1_PageChanged(object sender, System.EventArgs e)
    {

        gvDataBaind();
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

    protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
            e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");
        }
    }

    #region 过滤字修改
    protected void Button2_Click(object sender, EventArgs e)
    {
        XYECOM.Model.FiltrateKeyWordInfo efkw = new XYECOM.Model.FiltrateKeyWordInfo();
        XYECOM.Business.FiltrateKeyWord fkw = new XYECOM.Business.FiltrateKeyWord();
        efkw.FKW_ID = Convert.ToInt32(this.va.Value);
        efkw.FKW_Name = this.TextBox1.Text;
        int i = 0;
        i = fkw.Update(efkw);
        if (i >= 0)
        {
            Alert("修改成功！", url);
        }
        else
        {
            Alert("修改失败！", url);
        }
    }
    #endregion

    #region 删除多条
    protected void btndelete_Click(object sender, EventArgs e)
    {
        string ids = "";
        foreach (GridViewRow row in this.gvlist.Rows)
        {
            if (((CheckBox)(row.FindControl("chkExport"))).Checked == true)
                ids += "," + this.gvlist.DataKeys[row.DataItemIndex].Value.ToString();
        }
        if (ids.IndexOf(",") == 0)
            ids = ids.Substring(1);

        XYECOM.Business.FiltrateKeyWord fkw = new XYECOM.Business.FiltrateKeyWord();
        int err = 0;
        err = fkw.Deletes(ids);
        if (err == -2)
        {
            Alert("删除失败！", url);
            this.ClientScript.RegisterClientScriptBlock(GetType(), "01", "<script>alertmsg(\"\",\"" + url + "\")</script>");
        }
        else
        {
            Alert("删除成功！", url);
        }
    }
    #endregion
}
