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

public partial class xymanage_UserManage_UserListManger : XYECOM.Web.BasePage.ManagePage
{
    public int A_ID;
    public XYECOM.Business.UserLogin login = new UserLogin();
    protected string loginnum = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("user");
        if (this.txtPageSize.Text != "")
        {
            this.Page1.PageSize = XYECOM.Core.MyConvert.GetInt32(this.txtPageSize.Text);
        }
        else
        {
            this.Page1.PageSize = 20;
        }
        if (!Page.IsPostBack)
        {
            this.btnDelete.Attributes.Add("onclick", "javascript:return del();");
            this.btnIsPass.Attributes.Add("onclick", "javascript:return IsSelectInfo();");

            SetValueByquery(Page1, "page");
            SetValueByquery(txtKeyWord, "KeyWord");
            SetValueByquery(txtcompany, "company");
            SetValueByquery(ddlCreaditLeav, "Creadid");
            SetValueByquery(ddlState, "State");
            SetValueByquery(areatypeid, "areatypeid");
            SetValueByquery(bgdate, "bgdate");
            SetValueByquery(egdate, "egdate");
            SetValueByquery(txtPageSize, "pagesize");
            SetValueByquery(txtdays, "isdays");
            SetValueByquery(cbdays, "cbday", "1");
            DataBindCreaditLeav();
        }
    }
    /// <summary>
    /// 绑定信用度
    /// </summary>
    private void DataBindCreaditLeav()
    {
        XYECOM.Business.CreditLeavlManager cread = new CreditLeavlManager();
        this.ddlCreaditLeav.DataSource = cread.Select();
        this.ddlCreaditLeav.DataTextField = "LeavlName";
        this.ddlCreaditLeav.DataValueField = "id";

        this.ddlCreaditLeav.DataBind();
        ListItem item = new ListItem("请选择信誉级别", "");
        ddlCreaditLeav.Items.Insert(0, item);
    }

    #region 绑定数据
    protected override void BindData()
    {
        backURL = XYECOM.Core.Utils.JSEscape("UserListManger.aspx?page=" + Page1.CurPage.ToString() +
            "&KeyWord=" + txtKeyWord.Text.Trim() +
            "&company=" + txtcompany.Text.Trim() +
            "&State=" + ddlState.SelectedValue +
            "&areatypeid=" + areatypeid.Value.Trim() +            
            "&bgdate=" + bgdate.Value.Trim() +
            "&egdate=" + egdate.Value.Trim() +            
            "&pagesize=" + txtPageSize.Text +
            "&isdays=" + txtdays.Text +
            "&cbday=" + cbdays.Checked.ToString().ToLower() +            
            "&Creadid=" + this.ddlCreaditLeav.SelectedValue
            );

        this.lblMessage.Text = "";

        string strWhere = "1=1 ";

        if (XYECOM.Core.XYRequest.GetQueryString("username") != "")
        {
            strWhere += " and U_Name like '" + XYECOM.Core.XYRequest.GetQueryString("username") + "' ";
        }
        if (this.txtKeyWord.Text != "")
        {
            strWhere += " and U_Name like '%" + this.txtKeyWord.Text + "%'";
        }
        if (this.txtcompany.Text != "")
        {
            strWhere += " and UI_Name like '%" + this.txtcompany.Text + "%'";
        }
        if (this.ddlState.SelectedValue != "-1")
        {
            if (this.ddlState.SelectedValue.Equals("null"))
                strWhere += " and UserAuditingState is  null";
            else if (this.ddlState.SelectedValue.Equals("1"))
                strWhere += " and UserAuditingState = 1";
            else if (this.ddlState.SelectedValue.Equals("0"))
                strWhere += " and UserAuditingState = 0";
        }

        if (!this.areatypeid.Value.Equals(""))
        {
            strWhere += " and Area_ID=" + this.areatypeid.Value;
        }

        string begindate = this.bgdate.Value;
        string enddate = this.egdate.Value;
        try
        {
            DateTime begdate = XYECOM.Core.MyConvert.GetDateTime(begindate);
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

        string orderField = "u_id";



        if (this.txtdays.Text != "" && this.cbdays.Checked)
        {
            strWhere += " and datediff(day,U_RegDate,getdate())<=" + (XYECOM.Core.MyConvert.GetInt32(this.txtdays.Text) - 1) + " and datediff(day,U_RegDate,getdate())>=0 ";
        }

        if (this.ddlCreaditLeav.SelectedValue != "")
        {
            string id = this.ddlCreaditLeav.SelectedValue;
            string where = string.Format(@" and ((CreditIntegral >= (select downPoint from xy_creditleavl where id={0}))
                                and(((select UpPoint from xy_creditleavl where id={1})=-1)or
                              (CreditIntegral <= (select UpPoint from xy_creditleavl where id={2}))))", id, id, id);
            strWhere += where;
        }
        int totalRecord = 0;
        DataTable dt = XYECOM.Business.Utils.GetPaginationData("XYV_UserInfo", "U_ID", "U_ID,U_Name,UI_HomePage,UI_Name,UG_ID,UserAuditingState,U_RegDate,U_Email,U_Vouch,U_Flag,tradeids,U_Way", orderField + " desc", strWhere, this.Page1.PageSize, this.Page1.CurPage, out totalRecord);

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

    #region 分页相关代码
    override protected void OnInit(EventArgs e)
    {
        this.Load += new System.EventHandler(this.Page_Load);
        this.Page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
        base.OnInit(e);
    }

    private void Page1_PageChanged(object sender, System.EventArgs e)
    {
        this.BindData();
    }
    #endregion

    #region 绑定数据
    protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
            e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

            if (e.Row.Cells[2].Text.Length > 30)
                e.Row.Cells[2].Text = XYECOM.Core.Utils.IsLength(30, e.Row.Cells[2].Text);

            LinkButton LB = (LinkButton)e.Row.Cells[5].Controls[0];
            string LS = LB.Text.Trim();
            if (LS == "1")
            {
                LB.Text = "通过审核";
            }
            else if (LS == "0")
            {
                LB.Text = "审核未通过";
            }
            else
            {
                LB.Text = "未审核";
            }            
        }
    }
    #endregion

    protected string GetUserGradeRelationEndTime(object objUserId)
    {
        long userId = 0;
        try
        {
            userId = Convert.ToInt64(objUserId);
        }
        catch { }

        if (userId <= 0) return "--";


        XYECOM.Model.UserGradeRelationInfo ugInfo = null;
        ugInfo = new XYECOM.Business.UserGradeRelation().GetItem(userId);
        if (ugInfo == null) return "";
        string endTime = ugInfo.U_EndTime.Trim();

        if (endTime == "&nbsp;" || endTime.Equals(""))
        {
            return "--";
        }
        else
        {
            TimeSpan ts = Convert.ToDateTime(endTime) - DateTime.Now;

            if (ts.Days <= 0)
            {
                return "<span style='color:#f00'>已过期</span>";
            }
            else if (ts.Days <= 30)
            {
                return "<span style='color:#f00'>剩余" + ts.Days + "天</span>";
            }
            else
            {
                return "<span style='color:#008000'>未过期<br/>" + Convert.ToDateTime(endTime).ToShortDateString() + "</span>";
            }

            //e.Row.Cells[7].ToolTip = "结束日期：" + Convert.ToDateTime(endTime).ToShortDateString();
        }
    }

    #region 审核操作
    protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //获取该行的行号         
        XYECOM.Business.UserInfo userInfoBLL = new XYECOM.Business.UserInfo();
        XYECOM.Business.UserReg userRegBLL = new XYECOM.Business.UserReg();

        int iRowNo = Convert.ToInt32(e.CommandArgument);
        int u_id = Convert.ToInt32(this.gvlist.DataKeys[iRowNo].Value);
        string U_Name = this.gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)]["U_Name"].ToString();

        int U_ID = 0;
        string Email = "";
        string title = "";

        if (gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)]["U_ID"].ToString() != "")
        {
            U_ID = Convert.ToInt32(gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)]["U_ID"].ToString());
        }
        if (gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)]["U_Email"].ToString() != "")
        {
            Email = gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)]["U_Email"].ToString();
        }
        if (gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)]["UI_Name"].ToString() != "")
        {
            title = gvlist.DataKeys[Convert.ToInt32(e.CommandArgument)]["UI_Name"].ToString();
        }

        if (e.CommandName == "shenhe")
        {
            //获取该行的主键
            LinkButton linkBtn = (LinkButton)this.gvlist.Rows[iRowNo].Cells[5].Controls[0];

            XYECOM.Business.Auditing auditingBLL = new XYECOM.Business.Auditing();

            XYECOM.Model.UserInfo userInfo = userInfoBLL.GetItem(U_ID);

            if (U_ID.ToString() != "")
            {
                if (linkBtn.Text == "通过审核")
                {
                    int j = auditingBLL.UpdatesAuditing(U_ID, "u_user", XYECOM.Model.AuditingState.NoPass);
                }
                else if (linkBtn.Text == "审核未通过")
                {
                    int t = auditingBLL.UpdatesAuditing(U_ID, "u_user", XYECOM.Model.AuditingState.Passed);
                    if (t >= 0 && userInfo != null)
                    {
                        // 资料完善程度
                        userRegBLL.UpdateUserPerfectPercent(U_ID);
                        //诚信指数
                        //userRegBLL.AddUserCred(U_ID, U_Cred);
                    }
                }
                else if (linkBtn.Text == "未审核")
                {
                    int y = auditingBLL.UpdatesAuditing(U_ID, "u_user", XYECOM.Model.AuditingState.Passed);

                    if (y >= 0)
                    {
                        if (userInfo != null)
                        {
                            // 资料完善程度
                            userRegBLL.UpdateUserPerfectPercent(U_ID);
                            //诚信指数
                            //userRegBLL.AddUserCred(U_ID, U_Cred);
                        }

                        //给用户留言
                        if (U_ID.ToString() != "")
                        {
                            SendMessage(U_ID);
                        }
                        // 给用户发短信
                        if (Email.ToString() != "")
                        {
                            SendEmail(title, Email);
                        }
                    }
                }
            }

            this.BindData();
        }

        #region 推荐
        else if (e.CommandName == "tj")
        {
            //获取该行的行号
            int i = Convert.ToInt32(e.CommandArgument);
            //获取该行的主键
            LinkButton LB = (LinkButton)gvlist.Rows[i].Cells[6].Controls[0];
            XYECOM.Model.UserRegInfo eu = new XYECOM.Model.UserRegInfo();
            if (LB.Text == "推荐")
            {
                eu.UserId = U_ID;
                eu.IsVouch = false;
                userRegBLL.UpdateVouch(eu);

            }
            else if (LB.Text == "不推荐")
            {
                eu.UserId = U_ID;
                eu.IsVouch = true;
                userRegBLL.UpdateVouch(eu);
            }
            this.BindData();
        }
        #endregion
    }
    #endregion

    #region 删除操作
    protected void btnDelete_Click(object sender, EventArgs e)
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
                el.L_Title = "用户管理";
                el.L_Content = "删除用户信息成功";
                el.L_MF = "用户管理";
                el.UM_ID = AdminId;
                l.Insert(el);
                BindData();
            }
            else
            {
                el.L_Title = "用户管理";
                el.L_Content = "删除用户信息失败";
                el.L_MF = "用户管理";
                el.UM_ID = AdminId;
                l.Insert(el);
                Alert("删除失败！");
            }
        }
    }
    #endregion

    protected string SetUrl(object Flag, object Uid)
    {
        if (string.IsNullOrEmpty(Flag.ToString()) || string.IsNullOrEmpty(Uid.ToString()))
            return "#";
        if (Flag.ToString() == "False")
            return "IndividualInfo.aspx?U_ID=" + Uid.ToString();
        else
            return "UserInfo.aspx?U_ID=" + Uid.ToString();
    }

    #region 审核商业信息失败给用户留言
    private void SendMessage(long U_ID)
    {
        if (webInfo.IsAuditingUserMessage.ToString().ToLower() == "true")
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
            if (webInfo.AuditingUserMessageTitle.ToString() != "")
            {
                em.M_Title = webInfo.AuditingUserMessageTitle.ToString();
            }
            else
            {
                em.M_Title = "";
            }
            if (webInfo.AuditingUserMessageContent.ToString() != "")
            {
                em.M_Content = webInfo.AuditingUserMessageContent.ToString();
            }
            else
            {
                em.M_Content = "";
            }
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

    #region 搜索
    protected void Button2_Click(object sender, EventArgs e)
    {
        BindData();
    }
    #endregion

    #region 批量审核

    protected void btnIsPass_Click(object sender, EventArgs e)
    {
        string num = "";
        XYECOM.Business.Auditing AD = new XYECOM.Business.Auditing();

        foreach (GridViewRow GR in this.gvlist.Rows)
        {
            if (((CheckBox)(GR.FindControl("chkExport"))).Checked == true)
            {
                num += "," + gvlist.DataKeys[GR.DataItemIndex].Value.ToString();
            }
        }
        if (num.IndexOf(',') == 0)
        {
            num = num.Substring(1);
            String[] Ids = num.Split(',');
            foreach (String i in Ids)
            {
                AD.UpdatesAuditing(XYECOM.Core.MyConvert.GetInt64(i), "u_User", XYECOM.Model.AuditingState.Passed);
            }
            BindData();
        }
    }

    #endregion
}
