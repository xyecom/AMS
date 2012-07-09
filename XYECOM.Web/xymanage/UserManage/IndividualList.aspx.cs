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

public partial class xymanage_UserManage_IndividualList : XYECOM.Web.BasePage.ManagePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("individual");
        if (this.txtPageSize.Text != "")
        {
            this.Page1.PageSize = XYECOM.Core.MyConvert.GetInt32(this.txtPageSize.Text);
        }
        else
        {
            this.Page1.PageSize = 20;
        }
        if (!IsPostBack)
        {
            if (XYECOM.Core.XYRequest.GetQueryInt("page", 0) > 0)
                this.Page1.CurPage = XYECOM.Core.XYRequest.GetQueryInt("page", 0);
            if (XYECOM.Core.XYRequest.GetQueryString("name") != "")
            {
                this.txtName.Text = XYECOM.Core.XYRequest.GetQueryString("name");
            }
            if (XYECOM.Core.XYRequest.GetQueryString("city") != "")
            {
                this.areatypeid.Value = XYECOM.Core.XYRequest.GetQueryString("city");
            }
            if (XYECOM.Core.XYRequest.GetQueryString("bgdata") != "")
            {
                this.bgdate.Value = XYECOM.Core.XYRequest.GetQueryString("bgdata");
            }
            if (XYECOM.Core.XYRequest.GetQueryString("enddata") != "")
            {
                this.egdate.Value = XYECOM.Core.XYRequest.GetQueryString("enddata");
            }
            SetValueByquery(txtPageSize, "pagesize");
            SetValueByquery(txtdays, "isdays");
            SetValueByquery(cbdays, "cbday", "1");

            this.Button1.Attributes.Add("onclick", "javascript:return del();");
        }
    }

    #region 绑定数据
    protected override void BindData()
    {
        //设置编辑或查看后要返回当前页面的状态
        backURL = XYECOM.Core.Utils.JSEscape("IndividualList.aspx?page=" + Page1.CurPage.ToString() + "&name=" + this.txtName.Text + "&city=" + this.areatypeid.Value + "&bgdata=" + this.bgdate.Value + "&enddata=" + this.egdate.Value + "&pagesize=" + txtPageSize.Text + "&isdays=" + txtdays.Text + "&cbday=" + cbdays.Checked.ToString().ToLower());

        this.lblMessage.Text = "";

        string strWhere = " 1=1 ";

        if (this.txtName.Text != "")
        {
            strWhere += " and U_Name like '%" + this.txtName.Text + "%'";
        }

        if (this.tdcharacter.SelectedValue != "-1")
        {
            strWhere += " and UI_Sex=" + this.tdcharacter.SelectedValue;
        }

        if (this.areatypeid.Value != "")
        {
            strWhere += " and Area_ID=" + this.areatypeid.Value;
        }

        string begindate = this.bgdate.Value;
        string enddate = this.egdate.Value;
        try
        {
            DateTime bgdate = Convert.ToDateTime(begindate);
        }
        catch (Exception)
        {
            begindate = "";
        }
        try
        {
            DateTime eddate = Convert.ToDateTime(enddate);
        }
        catch (Exception)
        {
            enddate = "";
        }




        if (begindate != "" && enddate != "")
        {
            strWhere += " and (U_RegDate between '" + begindate + "' and '" + enddate + "')";
        }
        if (this.txtdays.Text != "" && this.cbdays.Checked)
        {
            strWhere += " and datediff(day,U_RegDate,getdate())<=" + (XYECOM.Core.MyConvert.GetInt32(this.txtdays.Text) - 1) + " and datediff(day,U_RegDate,getdate())>=0 ";
        }

        int totalRecord = 0;

        DataTable dt = XYECOM.Business.Utils.GetPaginationData("XYV_Individual", "U_ID", "U_ID,U_Name,UI_Name,UI_Sex,Telephone,U_RegDate,U_Email,UserAuditingState", "U_ID desc", strWhere, this.Page1.PageSize, this.Page1.CurPage, out totalRecord);

        this.Page1.RecTotal = totalRecord;

        if (dt.Rows.Count > 0)
        {
            this.gvlist.DataSource = dt;
            this.gvlist.DataBind();
        }
        else
        {
            this.lblMessage.Text = "没有相关信息记录";
            this.gvlist.DataBind();
        }
    }
    #endregion

    #region 个人会员审核
    protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int u_id = 0;

        int iRowNo = Convert.ToInt32(e.CommandArgument);
        u_id = Convert.ToInt32(this.gvlist.DataKeys[iRowNo].Value);

        string U_Name = this.gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)]["U_Name"].ToString();
        long U_ID = 0;
        string Email = "";
        string title = "";

        if (gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)]["U_ID"].ToString() != "")
        {
            U_ID = Convert.ToInt64(gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)]["U_ID"].ToString());
        }
        if (gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)]["U_Email"].ToString() != "")
        {
            Email = gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)]["U_Email"].ToString();
        }
        if (gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)]["UI_Name"].ToString() != "")
        {
            title = gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)]["UI_Name"].ToString();
        }

        #region 审核
        if (e.CommandName == "shenhe")
        {
            //获取该行的主键
            LinkButton LB = (LinkButton)this.gvlist.Rows[iRowNo].Cells[7].Controls[0];
            XYECOM.Business.Auditing audBLL = new XYECOM.Business.Auditing();

            string aa = LB.Text;
            if (U_ID.ToString() != "")
            {
                if (LB.Text == "通过审核")
                {
                    int j = audBLL.UpdatesAuditing(U_ID, "u_user", XYECOM.Model.AuditingState.NoPass);
                    if (j >= 0)
                    {
                        //给用户留言
                        if (U_ID.ToString() != "")
                        {
                            SendMessage(U_ID);
                        }
                        //给用户发短信
                        if (Email.ToString() != "")
                        {
                            SendEmail(title, Email);
                        }
                    }
                }
                else if (LB.Text == "审核未通过" || LB.Text == "未审核")
                {
                    int j = audBLL.UpdatesAuditing(U_ID, "u_user", XYECOM.Model.AuditingState.Passed);
                }
            }

            BindData();
        }
        #endregion

        this.DataBind();
    }
    #endregion

    #region  分页
    private void Page1_PageChanged(object sender, System.EventArgs e)
    {
        this.BindData();
    }
    #endregion

    #region 绑定数据行初始化

    protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
            e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

            string LSsex = e.Row.Cells[4].Text;
            if (LSsex == "True")
            {
                e.Row.Cells[4].Text = "男";
            }
            else if (LSsex == "False")
            {
                e.Row.Cells[4].Text = "女";
            }
            LinkButton LB = (LinkButton)e.Row.Cells[7].Controls[0];
            string LS = LB.Text.Trim();
            if (LS == "1")
            {
                LB.Text = "通过审核";
            }
            else if (LS == "0")
            {
                LB.Text = "审核未通过";
            }
            else if (LS == "")
            {
                LB.Text = "未审核";
            }
        }
    }
    #endregion

    #region 审核商业信息失败给用户留言
    private void SendMessage(long U_ID)
    {
        if (webInfo.IsAuditingUserMessage)
        {
            XYECOM.Model.MessageInfo em = new XYECOM.Model.MessageInfo();
            XYECOM.Business.Message m = new Message();
            em.M_Adress = "";
            em.M_CompanyName = "";
            em.M_Email = "";
            em.M_FHM = "";
            em.M_HasReply = false;
            em.M_Moblie = "";
            em.M_PHMa = "";
            em.M_RecverType = "administrator";
            em.M_Restore = false;
            em.M_SenderType = "user";

            em.M_Title = webInfo.AuditingUserMessageTitle;
            em.M_Content = webInfo.AuditingUserMessageContent;

            em.M_UserName = "";
            em.M_UserType = false;
            em.U_ID = -1;
            em.UR_ID = U_ID;
            m.Insert(em);
        }
    }
    #endregion

    #region  审核失败给用户发送邮件
    private void SendEmail(string title, string Email)
    {
        if (webInfo.IsAuditingUserEmail)
        {
            string messtitle = "审核用户信息";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string[] a = new string[] { webInfo.WebName, webInfo.WebDomain, title, webInfo.WebDomain + "login." + webInfo.WebSuffix };
            string[] ac = new string[] { "{$WI_Name$}", "{$WI_url$}", "{$title$}", "{$pdateurl$}" };
            string strcont = XYECOM.Core.TemplateEmail.GetContent(a, ac, "/TemplateEmail/AuditingUser.htm");
            if (strcont != "-1")
            {
                XYECOM.Business.Utils.SendMail(Email, messtitle, strcont);
            }
        }
    }
    #endregion

    #region 删除
    protected void Button1_Click(object sender, EventArgs e)
    {
        XYECOM.Business.Log l = new XYECOM.Business.Log();
        XYECOM.Model.LogInfo el = new XYECOM.Model.LogInfo();
        XYECOM.Business.UserReg ur = new XYECOM.Business.UserReg();
        string ids = "";
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
            i = ur.Delete(ids);
            if (i >= 0)
            {
                el.L_Title = "个人用户管理";
                el.L_Content = "删除用户信息成功";
                el.L_MF = "用户管理";

                {
                    el.UM_ID = AdminId;
                }
                l.Insert(el);
            }
            else
            {
                el.L_Title = "个人用户管理";
                el.L_Content = "删除用户信息失败";
                el.L_MF = "用户管理";

                {
                    el.UM_ID = AdminId;
                }
                l.Insert(el);
                Alert("删除失败！");
            }
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

    /// <summary>
    /// 搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        BindData();
    }
}
