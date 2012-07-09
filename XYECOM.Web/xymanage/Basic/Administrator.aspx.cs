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
using XYECOM.Core;
using XYECOM.Business;
using System.IO;

public partial class xymanage_basic_Administrator : XYECOM.Web.BasePage.ManagePage
{
    string url = "Administrator.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("sysadmin");

        if (!Page.IsPostBack)
        {
            this.Page1.PageSize = 10;
            this.btnOk.Attributes.Add("onclick", "javascript:return AdminAdd();");
            this.Submit1.Attributes.Add("onclick", "javascript:return  AdminEdit();");
            this.addListBind();
            ListBind();
        }

    }

    #region
    private void addListBind()
    {
        Role rl = new Role();

        this.ddlRose.DataSource = rl.GetDataTable();
        this.ddlRose.DataTextField = "UR_Name";
        this.ddlRose.DataValueField = "UR_ID";
        this.ddlRose.DataBind();
        this.ddlRose.Items.Insert(0, new ListItem("----请选择角色----", "-1"));

        this.ddlUpdate.DataSource = rl.GetDataTable();
        this.ddlUpdate.DataTextField = "UR_Name";
        this.ddlUpdate.DataValueField = "UR_ID";
        this.ddlUpdate.DataBind();
        this.ddlUpdate.Items.Insert(0, new ListItem("----请选择角色----", "-1"));

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

    #region Web 窗体设计器生成的代码
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
        //
        InitializeComponent();
        this.Page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
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
        ListBind();
    }
    #endregion

    #region 绑定数据
    private void ListBind()
    {
        string strwhere = "";
        string orderby = "";
        this.Page1.RecTotal = Function.GetRows("b_Admin", "UM_ID", "");
        DataTable dt;
        dt = Function.GetPages(this.Page1.PageSize, this.Page1.CurPage, strwhere, orderby, "b_Admin ", " * ", " UM_ID ");
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

    #region 修改管理员信息
    protected void Submit1_ServerClick(object sender, EventArgs e)
    {
        this.key.Value = "2";

        XYECOM.Business.Admin adminBLL = new XYECOM.Business.Admin();
        XYECOM.Model.AdminInfo adminInfo = new XYECOM.Model.AdminInfo();
        XYECOM.Business.Log l = new XYECOM.Business.Log();
        XYECOM.Model.LogInfo el = new XYECOM.Model.LogInfo();

        adminInfo = adminBLL.GetItem(Convert.ToInt32(this.value.Value));

        adminInfo.UR_ID = Convert.ToInt32(this.ddlUpdate.SelectedValue.ToString());
        adminInfo.UM_ID = Convert.ToInt32(this.value.Value);


        if (adminInfo.UM_Pwd != XYECOM.Core.SecurityUtil.MD5(this.txtYuanPwd.Text.Trim(), XYECOM.Configuration.Security.Instance.Md5value))
        {
            Alert("原密码不正确！", url);
            return;
        }

        if (this.txtNewPwd.Text.Trim() != this.txtOKpwd.Text.Trim())
        {
            Alert("两次密码输入不一致！", url);
            return;
        }

        adminInfo.UM_Pwd = XYECOM.Core.SecurityUtil.MD5(this.txtNewPwd.Text.Trim(), XYECOM.Configuration.Security.Instance.Md5value);


        int i = adminBLL.Update(adminInfo);

        if (i == 1)
        {
            el.L_Title = "管理员管理";
            el.L_Content = "修改管理员信息成功";
            el.L_MF = "系统信息设置";
            
            {
                el.UM_ID = AdminId;
            }
            l.Insert(el);
            Alert("修改成功！", url);
        }
        else
        {
            Alert("修改失败！", url);
        }
    }
    #endregion

    #region 添加管理员信息
    protected void btnOk_ServerClick1(object sender, EventArgs e)
    {
        XYECOM.Business.Log l = new XYECOM.Business.Log();
        XYECOM.Model.LogInfo el = new XYECOM.Model.LogInfo();
        XYECOM.Model.AdminInfo ea = new XYECOM.Model.AdminInfo();
        XYECOM.Business.Admin ad = new XYECOM.Business.Admin();
        ea.UM_Name = this.txtName.Text;
        ea.UM_Pwd = XYECOM.Core.SecurityUtil.MD5(this.txtPwd.Text.Trim(), XYECOM.Configuration.Security.Instance.Md5value);
        ea.UR_ID = Convert.ToInt32(this.ddlRose.SelectedValue.ToString());
        int i = 0;
        i = ad.Insert(ea);
        if (i == 1)
        {
            el.L_Title = "管理员管理";
            el.L_Content = "添加管理员信息成功";
            el.L_MF = "系统信息设置";
            
            {
                el.UM_ID = AdminId;
            }
            l.Insert(el);
            Reload();
            //string url = "Administrator.aspx";                
            //this.ClientScript.RegisterClientScriptBlock(GetType(), "01", "<script>alertmsg(\"添加成功！\",\"" + url + "\")</script>");
        }
        else if (i == -1)
        {
            el.L_Title = "管理员管理";
            el.L_Content = "该记录已经存在，请重新输入";
            el.L_MF = "系统信息设置";
            
            {
                el.UM_ID = AdminId;
            }
            l.Insert(el);
            Alert("该记录已经存在，请重新输入！", url);
        }
        else
        {
            el.L_Title = "管理员管理";
            el.L_Content = "添加管理员信息";
            el.L_MF = "系统信息设置";
            
            {
                el.UM_ID = AdminId;
            }
            l.Insert(el);
            Alert("添加失败！", url);
        }
    }
    #endregion

    #region 删除管理员信息
    protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {

            XYECOM.Model.AdminInfo ea = new XYECOM.Model.AdminInfo();
            XYECOM.Business.Admin ad = new XYECOM.Business.Admin();
            XYECOM.Business.Log l = new XYECOM.Business.Log();
            XYECOM.Model.LogInfo el = new XYECOM.Model.LogInfo();
            int i = 0;
            int id = Int32.Parse(gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
            if (id == AdminId)
            {
                string url = "Administrator.aspx";
                this.ClientScript.RegisterClientScriptBlock(GetType(), "01", "<script>alertmsg(\"您不能删除自己！\",\"" + url + "\")</script>");
            }
            else
            {
                el.L_Title = "管理员管理";
                el.L_MF = "系统信息设置";
                
                {
                        el.UM_ID = AdminId;
                }

                this.key.Value = "3";
                i = ad.Delete(id);
                if (i == 1)
                {
                    el.L_Content = "删除管理员信息成功";
                    Response.Redirect(url);
                }
                else
                {
                    el.L_Content = "删除管理员信息失败";                    
                    Alert("删除失败！", url);
                }
                l.Insert(el);
            }
        }
        else if (e.CommandName == "up")
        {
            this.key.Value = "2";
            XYECOM.Business.Admin ad = new XYECOM.Business.Admin();
            XYECOM.Model.AdminInfo ea = new XYECOM.Model.AdminInfo();
            ea = ad.GetItem(Int32.Parse(gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString()));
            this.value.Value = gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            this.txtName1.Text = ea.UM_Name;
            this.ddlUpdate.SelectedValue = ea.UR_ID.ToString();
        }
    }
    #endregion
}




