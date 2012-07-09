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

public partial class xymanage_basic_ModeList :XYECOM.Web.BasePage.ManagePage
{
    string url = "Modelist.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("businessmode");

        if (!Page.IsPostBack)
        {
            this.Page1.PageSize = 20;
            Modelist();
        }
    }

    #region  绑定数据
    private void Modelist()
    {
        string strwhere = "";
        string orderby = "";
        this.Page1.RecTotal = Function.GetRows("b_Mode", "M_ID", "");
        DataTable dt;
        dt = Function.GetPages(this.Page1.PageSize, this.Page1.CurPage, strwhere, orderby, "b_Mode ", " * ", " M_ID ");
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

    #region 翻页
    private void Page1_PageChanged(object sender, EventArgs e)
    {
        this.Modelist();
    }
    #endregion

    #region 添加
    protected void btnOk_ServerClick1(object sender, EventArgs e)
    {
        if(this.txtName.Text ==""){
            Alert("经营模式类别不能为空");
            return;
        }
        XYECOM.Model.ModeInfo em = new XYECOM.Model.ModeInfo();
        XYECOM.Business.Mode m = new XYECOM.Business.Mode();
        em.M_Type =this.txtName.Text;
        int i = 0;
        i = m.Insert(em);
        if (i == 1)
        {
            Response.Redirect(url);
        }
        else if (i == -1)
        {
            Alert("该记录已经存在，请重新输入！", url);
            Modelist();
        }
        else
        {
            Alert("添加失败！", url);
        }
    }
    #endregion

    #region 修改
    protected void Submit1_ServerClick(object sender, EventArgs e)
    {
        XYECOM.Model.ModeInfo em = new XYECOM.Model.ModeInfo();
        XYECOM.Business.Mode m = new XYECOM.Business.Mode();

        em.M_Type = this.uname.Text;
        em .M_ID =Convert.ToInt32(this.value.Value);

        int i = 0;
        i = m.Update(em);
        
        if (i == 1)
        {
            Response.Redirect(url);
            Modelist();
        }
        else
        {
            Alert("修改失败！", url);
        }
    }
    #endregion

    #region 删除
    protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            XYECOM.Business.Mode m = new XYECOM.Business.Mode();
            
            int id = Int32.Parse(gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
            int i = m.Delete(id);
            if (i == 1)
            {
                Modelist();
            }
            else
            {
                Alert("删除失败！", url);
            }
        }
        else if (e.CommandName == "up")
        {
            XYECOM.Business.Mode m = new XYECOM.Business.Mode();
            XYECOM.Model.ModeInfo em = new XYECOM.Model.ModeInfo();
            this.key.Value = "2";
            em=m .GetItem (Int32.Parse(gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString()));
            this.value.Value = gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            this .uname .Text  = em .M_Type .ToString ();
        }
    }
    #endregion 

    #region 序号
    protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
            e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

            e.Row.Cells[3].Attributes.Add("onclick", "return confirm('确定删除吗？');"); 
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
}
