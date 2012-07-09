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
public partial class xymanage_basic_Role : XYECOM.Web.BasePage.ManagePage
{
    #region 页面加载
    string url = "Role.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("sysadmin");
        if (!IsPostBack)
        {
            
            this.Page1.PageSize = 10;
            gvDataBaind();
            this.btnOk.Attributes.Add("onclick", "javascript:return roleadd();");
            this.Button2.Attributes.Add("onclick", "javascript:return roleedit();");
        }
    }
    #endregion

    #region 绑定数据
    private void gvDataBaind()
    {
        string strwhere = "";
        string orderby = "";
        this.Page1.RecTotal = Function.GetRows("b_Role", "UR_ID", "");
        DataTable dt;
        dt = Function.GetPages(this.Page1.PageSize, this.Page1.CurPage, strwhere, orderby, "b_Role", " * ", " UR_ID ");
        if (dt.Rows.Count > 0)
        {
            this.lblMessage.Text = "";
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

    #region Web 窗体设计器生成的代码
    override protected void OnInit(EventArgs e)
    {
        this.Load += new System.EventHandler(this.Page_Load);
        this.Page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
        base.OnInit(e);
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

    #region 翻页
    private void Page1_PageChanged(object sender, EventArgs e)
    {
        gvDataBaind();
    }
   #endregion 

    #region 添加
    protected void btnOk_ServerClick(object sender, EventArgs e)
    {
        XYECOM.Business.Role r = new XYECOM.Business.Role();
        XYECOM.Model.RoleInfo er = new XYECOM.Model.RoleInfo();
        er.UR_Name = this.txtName.Text;
        
        int err = r.Insert(er);
        if (err == -1)
        {
            Alert("该记录已存在！请重新输入信息！", url);
        }
        else if (err == -2)
        {
            Alert("添加失败！", url);
        }
        else
        {
            gvDataBaind();
        }
    }
    #endregion

    #region 删除
    protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            XYECOM.Business.Role r = new XYECOM.Business.Role();

            int err = r.Delete(Convert.ToInt32(gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString()));
            if (err == -2)
            {
                Alert("删除失败！", url);
            }
            else
            {
                gvDataBaind();
            }
        }
        else if (e.CommandName == "up")
        {

            XYECOM.Business.Role r = new XYECOM.Business.Role();
            this.key.Value = "2";
            this.hidUR_ID.Value = gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            XYECOM.Model.RoleInfo Info = r.GetItem(Convert.ToInt32(gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString()));
            if (null != Info)
            {
                this.TextBox1.Text = Info.UR_Name;
            }

            r = null;
        }
    }
    #endregion

    #region 翻页
    protected void gvlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lblMessage.Text = "";
        gvlist.PageIndex = e.NewPageIndex;
        this.gvDataBaind();
    }
    #endregion

    #region 修改角色信息
    protected void Button2_Click(object sender, EventArgs e)
    {

        XYECOM.Business.Role r = new XYECOM.Business.Role();
        XYECOM.Model.RoleInfo er = new XYECOM.Model.RoleInfo();
        er.UR_ID = Convert.ToInt16(this.hidUR_ID.Value);
        er.UR_Name = this.TextBox1.Text;
        int i = 0;
        i = r.Update(er);
        if (i >= 0)
        {
            this.ClientScript.RegisterClientScriptBlock(GetType(), "01", "<script>location.href='"+url+"';</script>");
            gvDataBaind();
        }
        else
        {
            Alert("修改失败！", url);
        }
    }
    #endregion
}
