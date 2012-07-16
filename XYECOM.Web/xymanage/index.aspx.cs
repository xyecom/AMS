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

public partial class xymanage_index : XYECOM.Web.BasePage.ManagePage
{
    public string strSform = "";
    protected int UserNew, LinkNew, SuppyNew, LoginLogoNew, OperLogoNew;

    private string JSEscape(string str)
    {
        return Microsoft.JScript.GlobalObject.escape(str);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {           
            this.Button3.Attributes.Add("onclick", "javascript:return getmodulename();");

            getmodulelist();
            getrlelist();
            GetDate();
        }
    }

    #region 模板名称
    private void getmodulelist()
    {
        DataTable dt;
        XYECOM.Business.Template tf = new XYECOM.Business.Template();
        dt =tf.GetAllTemplateList(XYECOM.Core.Utils.GetMapPath("../templates"));
        this.ddmodulelist.DataSource = dt;
        this.ddmodulelist.DataTextField = "T_Path";
        this.ddmodulelist.DataValueField = "T_ID";
        this.ddmodulelist.DataBind();
        ddmodulelist.SelectedValue = template.Path;
    }
    #endregion

    #region 获取角色
    private void getrlelist()
    {
        XYECOM.Business.Role rl = new Role();
        this.ddlpogroem.DataSource = rl.GetDataTable();
        this.ddlpogroem.DataTextField = "UR_Name";
        this.ddlpogroem.DataValueField = "UR_ID";
        this .ddlpogroem .DataBind ();
    }
    #endregion 

    private void GetDate()
    {
        this.LinkNew = Function.GetRows("b_FriendLink", "FL_ID", "where  datediff(d,FL_AddDate,getdate())<=1");
        this.UserNew = Function.GetRows("u_User", "U_ID", "where datediff(d,U_RegDate,getdate())<=1");
        this.SuppyNew = Function.GetRows("i_Supply", "SD_ID", "where datediff(d,SD_PublishDate,getdate())<=1");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("/xymanage/TemplatesManage/TemplatesTree.aspx?path=" + ddmodulelist.SelectedItem.Text + "&T_ID=" + ddmodulelist.SelectedValue);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("/xymanage/UserManage/UserListManger.aspx?username=" + this.lbusrname.Text);
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
       Response.Redirect("/xymanage/basic/UserPopedom.aspx?UR_ID=" + this.ddlpogroem .SelectedValue);
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        if (this.ddlbusiness.SelectedValue == "1")
        {
            Response.Redirect("/xymanage/Supply/list.aspx");
        }
        if (this.ddlbusiness.SelectedValue == "2")
        {
            Response.Redirect("/xymanage/Demand/list.aspx");
        }
        if (this.ddlbusiness.SelectedValue == "3")
        {
            Response.Redirect("/xymanage/InviteBusinessman/InfoList.aspx");
        }
        if (this.ddlbusiness.SelectedValue == "4")
        {
            Response.Redirect("/xymanage/Surrogate/ServiceList.aspx");

        }
        if (this.ddlbusiness.SelectedValue == "5")
        {
            Response.Redirect("/xymanage/ShowInfoManage/ShowInfoList.aspx");
        }
        if (this.ddlbusiness.SelectedValue == "6")
        {
            Response.Redirect("/xymanage/BrandManage/BranList.aspx");
        }
        if (this.ddlbusiness.SelectedValue == "7")
        {
            Response.Redirect("/xymanage/engaggeinfo/list.aspx");
        }
    }
}
