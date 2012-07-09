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

public partial class xymanage_MessageManage_SendMessageAdd : XYECOM.Web.BasePage.ManagePage
{
    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("sysmessage");

        if (!IsPostBack)
        {
            this.Button2.Attributes.Add("onclick","javascript:return messageadd();");            
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
            strWhere += " and (UI_Name like '%" + uname + "%' or U_Name like '%" + uname + "%') and UI_Name<>'' ";
        else
            strWhere += " and 1<>1 ";
        
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

    #region 发送短信
    protected void Button2_Click(object sender, EventArgs e)
    {
        XYECOM.Model.MessageInfo ems = new XYECOM.Model.MessageInfo();
        Message ms = new Message();
        ems.M_Content = this.lbcontent.Value;
        ems.M_Email = "";
        ems.M_SenderType = "user";
        ems.M_UserName = "";
        ems.M_Moblie = "";
        ems.M_Adress ="";
        ems.M_CompanyName ="";
        ems.M_FHM ="";
        ems.M_HasReply =false ;
        ems.M_PHMa ="";
        ems.M_RContent ="";
        ems.M_RecverType ="administrator";
        ems.M_Restore =false ;
        ems.M_RTitle ="";
        ems.M_Sex =false ;
        ems.M_Title =this.lbtitle.Text ;
        ems.M_UserType =false ;
        
        string ug_ids = "";
         
        ems.U_ID=-1;
        //给用户组发
      
        if (ug_ids.IndexOf(",") == 0)
            ug_ids = ug_ids.Substring(1);

        if (ug_ids.Length > 0)
        {
            DataTable dt = Function.GetDataTable(" where UG_ID in (" + ug_ids + ")", " order by U_ID desc ", "XYV_UserInfo");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ems.UR_ID = Convert.ToInt64(dt.Rows[i]["U_ID"].ToString());
                ems.M_Content = this.lbcontent.Value.Replace("{loginname}", dt.Rows[i]["U_Name"].ToString()).Replace("{username}", dt.Rows[i]["UI_Name"].ToString()).Replace("{userid}", dt.Rows[i]["U_ID"].ToString());
                ms.Insert(ems);
            }
        }
        //查询个人
        String p = "";
        String isAll = this.personall.Value;
        DataTable dt3 = new DataTable();
        if (!isAll.Equals("1"))
        {
            foreach (GridViewRow row in this.gvlist.Rows)
            {
                if (((CheckBox)(row.FindControl("chkExport"))).Checked == true)
                {
                    p += "," + gvlist.DataKeys[row.DataItemIndex].Value.ToString();
                }
            }
        }
       
        if (isAll.Equals("1"))
        {
            dt3 = Function.GetDataTable(" where 1=1 ", "", " XYV_individual");
        }
        else {
            if(p.Length > 0)
            dt3 = Function.GetDataTable(" where U_ID  in (" + p.Substring(1) + ")", "", " XYV_individual");
        }
        if (dt3.Rows.Count > 0)
        {
            for (int t = 0; t < dt3.Rows.Count; t++)
            {
                ems.UR_ID = Convert.ToInt64(dt3.Rows[t]["U_ID"].ToString());
                ems.M_Content = this.lbcontent.Value.Replace("{loginname}", dt3.Rows[t]["U_Name"].ToString()).Replace("{username}", dt3.Rows[t]["UI_Name"].ToString()).Replace("{userid}", dt3.Rows[t]["U_ID"].ToString());
                ms.Insert(ems);
            }
        }
        //查询企业
        String c = "";
        foreach(GridViewRow row in this.GridView1.Rows){
            if (((CheckBox)(row.FindControl("chkExport1"))).Checked == true)
            {
                c += "," + GridView1.DataKeys[row.DataItemIndex].Value.ToString();
            }
        }

        if (c.Length > 0)
        {
            DataTable dt2 = Function.GetDataTable(" where U_ID  in (" + c.Substring(1) + ")", "", " xyv_userinfo");
            if (dt2.Rows.Count > 0)
            {
                for (int t = 0; t < dt2.Rows.Count; t++)
                {
                    ems.UR_ID = Convert.ToInt64(dt2.Rows[t]["U_ID"].ToString());
                    ems.M_Content = this.lbcontent.Value.Replace("{loginname}", dt2.Rows[t]["U_Name"].ToString()).Replace("{username}", dt2.Rows[t]["UI_Name"].ToString()).Replace("{userid}", dt2.Rows[t]["U_ID"].ToString());
                    ms.Insert(ems);
                }
            }
        }
        Alert("发送成功！", "SendMessageList.aspx");
    }
    #endregion

    #region Web 窗体设计器生成的代码
    override protected void OnInit(EventArgs e)
    {
        this.Load += new System.EventHandler(this.Page_Load);
        this.Page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
        this.Page2.PageChanged += new xymanage_UserControl_page.EventHandler(Page2_PageChanged);
        base.OnInit(e);
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
            this.Label1.Text = "请输入查询条件";
        }
        this.ClientScript.RegisterStartupScript(GetType(), "01", "<script>company();rbtchanage(1)</script>");
    }
    #endregion

    #region 企业绑定
    private void CompanyDataBind() {
        this.Label1.Text = "";
        string strWhere = " UserAuditingState = 1 ";

        if (this.txtcompany.Text != "")
            strWhere += " and (UI_Name like '%" + this.txtcompany.Text + "%' or U_Name like '%" + this.txtcompany.Text + "%') and UI_Name<>'' ";
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

}
