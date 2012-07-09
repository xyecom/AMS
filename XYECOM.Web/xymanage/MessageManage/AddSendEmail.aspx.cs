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
using System.Net.Mail;
using System.Net;
using XYECOM.Core;
using XYECOM.Business;

public partial class xymanage_MessageManage_AddSendEmail : XYECOM.Web.BasePage.ManagePage
{
    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("email");

        if (!Page.IsPostBack)
        {
            this.Button2.Attributes.Add("onclick", "javascript:return EmailAdd();");            
        }
    }
    #endregion 
    
    #region 发送电子邮件
    protected void Button2_Click2(object sender, EventArgs e)
    {

        string UG_IDS = "";
       
        string h = "";
        String c = "";
        String isAll = this.personall.Value;
        DataTable dt2 = new DataTable();
        if (!isAll.Equals("1"))
        {
            foreach (GridViewRow gv in gvlist.Rows)
            {
                if (((CheckBox)(gv.FindControl("chkExport"))).Checked == true)
                {
                    h += "," + gvlist.DataKeys[gv.DataItemIndex].Value.ToString();
                }
            }
        }
        

        if (isAll.Equals("1"))
        {
            dt2 = Function.GetDataTable(" where 1=1 ", "", " XYV_individual");
        }
        else {
            if(h.Length > 0)
                dt2 = Function.GetDataTable(" where U_ID  in (" + h.Substring(1) + ")", "", " XYV_individual");
        }
        
        if (dt2.Rows.Count > 0)
        {
            for (int t = 0; t < dt2.Rows.Count; t++)
            {  
                str = this.lbcontent.Value.Replace("{loginname}", dt2.Rows[t]["U_Name"].ToString()).Replace("{username}", dt2.Rows[t]["UI_Name"].ToString()).Replace("{userid}", dt2.Rows[t]["U_ID"].ToString());
                XYECOM.Business.Utils.SendMail(dt2.Rows[t]["U_Email"].ToString(),this.lbtitle.Text, str);
            }
        }

        foreach (GridViewRow gv in GridView1.Rows)
        {
            if (((CheckBox)(gv.FindControl("chkExport1"))).Checked == true)
            {
                c += "," + GridView1.DataKeys[gv.DataItemIndex].Value.ToString();
            }
        }
        if (c.Length > 0)
        {
            DataTable dt3 = Function.GetDataTable(" where U_ID  in (" + c.Substring(1) + ")", "", " XYV_UserInfo");
            if (dt3.Rows.Count > 0)
            {

                for (int t = 0; t < dt3.Rows.Count; t++)
                {
                    str = this.lbcontent.Value.Replace("{loginname}", dt3.Rows[t]["U_Name"].ToString()).Replace("{username}", dt3.Rows[t]["UI_Name"].ToString()).Replace("{userid}", dt3.Rows[t]["U_ID"].ToString());
                    XYECOM.Business.Utils.SendMail(dt3.Rows[t]["U_Email"].ToString(), this.lbtitle.Text,str) ;
                }
            }
        }

        XYECOM.Business.SendEmail ee = new XYECOM.Business.SendEmail();
        XYECOM.Model.SendEmailInfo se = new XYECOM.Model.SendEmailInfo();
        se.E_title = this.lbtitle.Text;
        se.E_content = str;

        se.U_IDS = UG_IDS;
        int y = 0;
        string url = "SendEmail.aspx";
        y = ee.Insert(se);
        
        if (y >= 0)
        {
            Alert("发送成功！", url);
        }
        else
        {
            Alert("发送失败！", url);
        }
    }
    #endregion

    #region 翻页相关
    private void Page1_PageChanged(object sender, EventArgs e)
    {
        gvlistDataBind();
        this.ClientScript.RegisterStartupScript(GetType(), "01", "<script>person();</script>");
    }

    private void Page2_PageChanged(object sender, EventArgs e)
    {
        CompanyDataBind();
        this.ClientScript.RegisterStartupScript(GetType(), "01", "<script>company();</script>");
    }

    #endregion

    protected void Button3_Click1(object sender, EventArgs e)
    {
        this.Response.Redirect("SendEmail.aspx");
    } 

    protected void Button3_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("SendEmail.aspx");
    }

    #region Web 窗体设计器生成的代码
    override protected void OnInit(EventArgs e)
    {
        this.Load += new System.EventHandler(this.Page_Load);
        this.Page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
        this.Page2.PageChanged += new xymanage_UserControl_page.EventHandler(Page2_PageChanged);
        base.OnInit(e);
    }  
   #endregion

    #region 企业绑定
    private void CompanyDataBind()
    {
        this.Label1.Text = "";
        string strWhere = " UserAuditingState = 1 ";

        if (this.txtcompany.Text != "")
            strWhere += " and (UI_Name like '%" + this.txtcompany.Text + "%'  or U_Name like '%" + this.txtcompany.Text + "%' ) and UI_Name <>'' ";
        else
            strWhere += " and UI_Name=null";

        this.Page2.PageSize = 10;

        int totalRecord = 0;

        DataTable dt = XYECOM.Business.Utils.GetPaginationData("XYV_userinfo", "U_ID", "U_ID,UI_Name", "U_ID desc", strWhere, this.Page2.PageSize, this.Page2.CurPage, out totalRecord);

        this.Page2.RecTotal = totalRecord;

        if (dt.Rows.Count > 0)
        {
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }
        else
        {
            this.Label1.Text = "没有查询结果";
            this.GridView1.DataBind();
        }
    }
    #endregion

    #region 个人信息绑定
    private void gvlistDataBind()
    {
        this.lblMessage.Text = "";
        string strWhere = " UserAuditingState=1 ";
        string uname = this.txtperson.Text;
        if (uname != "")
            strWhere += " and (UI_Name like '%" + uname + "%' or U_Name like '%" + uname + "%') and UI_Name<>''";
        else
            strWhere += " and 1<>1";

        this.Page1.PageSize = 10;
        
        int totalRecord = 0;

        DataTable dt = XYECOM.Business.Utils.GetPaginationData("XYV_individual", "U_ID", "U_ID,UI_Name,U_Name", "U_ID desc", strWhere, this.Page1.PageSize, this.Page1.CurPage, out totalRecord);

        this.Page1.RecTotal = totalRecord;

        if (dt.Rows.Count > 0)
        {
            this.gvlist.DataSource = dt;
            this.gvlist.DataBind();
        }
        else
        {
            this.lblMessage.Text = "没有查询结果";
            this.gvlist.DataBind();
        }
    }
    #endregion

    #region 个人搜索
    /// <summary>
    /// 个人搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnperson_Click(object sender, EventArgs e)
    {
        if (this.txtperson.Text != "")
        {
            this.gvlistDataBind();
        }
        else {
            this.lblMessage.Text = "请输入查询条件！";
        }
        
        this.ClientScript.RegisterStartupScript(GetType(), "01", "<script>person();</script>");
    }
    #endregion

    #region 企业搜索
    /// <summary>
    /// 企业搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        if (this.txtcompany.Text != "")
        {
            CompanyDataBind();
        }
        else {
            this.Label1.Text = "请输入查询条件！";
        }
        this.ClientScript.RegisterStartupScript(GetType(), "01", "<script>company();rbtchanage(1)</script>");
    }
    #endregion
}

          