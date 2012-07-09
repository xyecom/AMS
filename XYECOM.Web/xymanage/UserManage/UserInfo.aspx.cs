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
using XYECOM.Business;
using XYECOM.Core;

public partial class xymanage_UserManage_EditeUserInfo : XYECOM.Web.BasePage.ManagePage
{
    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("user");

        if ("" != XYECOM.Core.XYRequest.GetQueryString("backURL"))
            backURL = XYECOM.Core.XYRequest.GetQueryString("backURL");
        else
            backURL = "UserListManger.aspx?";

        btnBack.Attributes["onclick"] = "location='" + backURL + "'";

        if (!Page.IsPostBack)
        {
            if (this.Request.QueryString["U_ID"].ToString() != "")
            {
                this.GetReader(Convert.ToInt32(this.Request.QueryString["U_ID"].ToString()));
            }
        }
    }
    #endregion

    #region 读取数据
    private void GetReader(int userId)
    {
        XYECOM.Business.UserInfo userInfoBLL = new XYECOM.Business.UserInfo();
        XYECOM.Business.UserAccount userAccountBLL = new XYECOM.Business.UserAccount();
        XYECOM.Business.UserFictitiouCount userFictitiouCountBLL = new XYECOM.Business.UserFictitiouCount();
        XYECOM.Business.UserLogin userLoginBLL = new UserLogin();
        XYECOM.Business.Auditing auditingBLL = new Auditing();
        XYECOM.Business.UserReg regBLL = new UserReg();

        XYECOM.Model.UserInfo userInfo = userInfoBLL.GetItem(userId);
        XYECOM.Model.UserRegInfo reginfo = regBLL.GetItem(userId);

        //XYECOM.Model.UserAccountInfo userAccountInfo = userAccountBLL.GetItem(userId);
        XYECOM.Model.UserFictitiouCountInfo userFictitiouCountInfo = userFictitiouCountBLL.GetItem(userId);
        XYECOM.Model.UserLoginInfo userLoginInfo = userLoginBLL.GetItem(userId);

        XYECOM.Model.AuditingInfo atinfo = auditingBLL.GetItem(userId.ToString(), "u_User");

        //企业信息
        if (userInfo != null)
        {
            this.lbcompanyname.InnerHtml = userInfo.Name + "&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"UserMoreInfo.aspx?U_ID=" + userId.ToString() + "&backURL=" + XYECOM.Core.Utils.JSEscape(XYECOM.Core.XYRequest.GetQueryString("backURL")) + "\">查看(编辑)公司详细资料>></a>&nbsp;&nbsp;&nbsp;&nbsp;<a href='EnterUserCenter.aspx?u_id=" + userId + "' target='_blank'>进入企业会员中心>></a>"; //公司名称          
            this.lbsection.InnerHtml = userInfo.Section;//所在部门
            this.lbpost.InnerHtml = userInfo.Post;//担任职位
            this.lblevel.InnerHtml = string.Empty;//更改会员等级
            this.phone.InnerHtml = userInfo.Telephone;
            this.linkman.InnerHtml = userInfo.LinkMan;
        }

        this.U_ID.Value = userId.ToString();

        //用户基本信息
        if (userInfo.RegInfo != null)
        {
            this.mail.InnerHtml = userInfo.RegInfo.Email;
            this.Email.Value = userInfo.RegInfo.Email;
            this.lbmark.InnerHtml = userInfo.RegInfo.Mark.ToString();//用户积分
        }

        //虚拟账户信息
        this.lbfcleftmoney.InnerHtml = userFictitiouCountInfo.C_LeftMoney.ToString(".#");//虚拟账户余额

        if (userLoginInfo != null)
        {
            this.regip.InnerHtml = userLoginInfo.RegIP;
            this.lastloginip.InnerHtml = userLoginInfo.LastLoginIP;
            this.lastlogintime.InnerHtml = userLoginInfo.LastLoginDate.ToString(); ;
            this.loginnum.InnerHtml = userLoginInfo.LoginNum.ToString();
        }
        else
        {
            this.regip.InnerHtml = "暂无信息";
            this.lastloginip.InnerHtml = "暂无信息";
            this.lastlogintime.InnerHtml = "暂无信息";
            this.loginnum.InnerHtml = "暂无信息";
        }

        if (userInfo.RegInfo.AuditingState == XYECOM.Model.AuditingState.Null)
        {
            this.lbmessage.Text = "未审核";
        }
        else if (userInfo.RegInfo.AuditingState == XYECOM.Model.AuditingState.Passed)
        {
            this.lbmessage.Text = "通过审核";
            this.Button5.Enabled = false;
        }
        else if (userInfo.RegInfo.AuditingState == XYECOM.Model.AuditingState.NoPass)
        {
            this.lbmessage.Text = "未通过审核";
            if (atinfo != null)
            {
                if (atinfo.A_Reason != "" || atinfo.A_Advice != "")
                {
                    this.plreason.Visible = true;
                    if (atinfo.A_Reason != "")
                    {
                        this.labreason.Text = atinfo.A_Reason;
                        this.tbA_Reason.Text = atinfo.A_Reason;
                    }
                    else
                    {
                        this.labreason.Text = "暂无原因";
                        this.tbA_Reason.Text = "暂无原因";
                    }
                    if (atinfo.A_Advice != "")
                    {
                        this.labadv.Text = atinfo.A_Advice;
                        this.tbA_Advice.Text = atinfo.A_Advice;
                    }
                    else
                    {
                        this.labadv.Text = "暂无建议";
                        this.tbA_Advice.Text = "暂无建议";
                    }
                }
            }
        }
    }
    #endregion

    #region 通过审核
    protected void Button5_Click(object sender, EventArgs e)
    {
        XYECOM.Business.Auditing auditingBLL = new XYECOM.Business.Auditing();

        int i = auditingBLL.UpdatesAuditing(Convert.ToInt64(this.U_ID.Value), "u_user", XYECOM.Model.AuditingState.Passed);

        if (i > 0)
        {
            if (this.U_ID.Value != "")
            {
                new XYECOM.Business.UserReg().UpdateUserPerfectPercent(XYECOM.Core.MyConvert.GetInt64(this.U_ID.Value));
            }
            Alert("审核成功！", Request.Url.PathAndQuery);
        }
        else
        {
            Alert("审核失败！", Request.Url.PathAndQuery);
        }
    }
    #endregion

    #region 拒绝通过审核
    protected void Button1_Click(object sender, EventArgs e)
    {
        long userId = XYECOM.Core.MyConvert.GetInt64(this.U_ID.Value);

        int i = NotPassAudit("u_user", userId, this.tbA_Reason.Text.Trim(), this.tbA_Advice.Text.Trim());

        XYECOM.Business.UserReg ur = new XYECOM.Business.UserReg();
        XYECOM.Business.UserFictitiouCount uft = new XYECOM.Business.UserFictitiouCount();

        #region 审核成功
        if (i > 0)
        {
            //给用户留言
            if (userId > 0)
            {
                SendMessage(userId, "企业信息审核", "企业信息审核未通过原因：" + this.tbA_Advice.Text);
            }

            //给用户发短信
            if (this.Email.Value != "")
            {
                SendEmail(this.lbcompanyname.InnerHtml, this.Email.Value);
            }
            //个人资料
            XYECOM.Business.FaithSet fs = new XYECOM.Business.FaithSet();
            DataTable dt = fs.GetDataTable();

            if (rbcommonerror.Checked == true)//普通错误扣除的诚信指数和UU币
            {
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["GF_ErrMoney"].ToString() != "")//扣除UU币
                    {
                        uft.DeductUserUUFictitiouCount(Convert.ToInt64(this.U_ID.Value), Convert.ToInt32(dt.Rows[0]["GF_ErrMoney"].ToString()));
                    }
                    if (dt.Rows[0]["GF_ErrFath"].ToString() != "")// 扣除诚信指数
                    {
                        ur.DeductFaithMongy(Convert.ToInt64(this.U_ID.Value), Convert.ToInt32(dt.Rows[0]["GF_ErrFath"].ToString()));
                    }
                }

            }
            else if (rbgravenesserror.Checked == true)//恶意错误扣除的诚信指数和UU币
            {
                if (dt.Rows.Count > 0)
                {

                    if (dt.Rows[0]["GF_Fath"].ToString() != "")
                    {
                        ur.DeductFaithMongy(Convert.ToInt64(this.U_ID.Value), Convert.ToInt32(dt.Rows[0]["GF_Fath"].ToString()));
                    }
                    if (dt.Rows[0]["GF_Money"].ToString() != "")
                    {
                        uft.DeductUserUUFictitiouCount(Convert.ToInt64(this.U_ID.Value), Convert.ToDecimal(dt.Rows[0]["GF_Money"].ToString()));
                    }
                }
                ur.AddUserMaliceErr(Convert.ToInt64(this.U_ID.Value), 1);//恶意处罚的次数
            }
            Alert("操作成功！", Request.Url.PathAndQuery);
        }
        #endregion
        else
        {
            Alert("操作失败！", Request.Url.PathAndQuery);
        }
    }
    #endregion

    #region 审核商业信息失败给用户留言
    private void SendMessage(long U_ID, string title, string content)
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
        if (webInfo.IsAuditingUserEmail.ToString().ToLower() == "true")
        {
            string messtitle = "审核用户信息";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string[] a = new string[] { webInfo.WebName.ToString(), webInfo.WebDomain.ToString(), title, webInfo.WebDomain.ToString() + "login." + webInfo.WebSuffix.ToString() };
            string[] ac = new string[] { "{$WI_Name$}", "{$WI_url$}", "{$title$}", "{$pdateurl$}" };
            string strcont = XYECOM.Core.TemplateEmail.GetContent(a, ac, "/TemplateEmail/AuditingUser.htm");
            if (strcont != "-1")
            {
                XYECOM.Business.Utils.SendMail(Email, messtitle, strcont);
            }
        }
    }
    #endregion

    #region 重设密码
    protected void Button2_Click(object sender, EventArgs e)
    {
        String pwd = XYECOM.Core.SecurityUtil.MD5(this.txtpwd.Text, XYECOM.Configuration.Security.Instance.Md5value);
        XYECOM.Business.UserReg userRegBLL = new XYECOM.Business.UserReg();
        int num = userRegBLL.UpdatePassWord(XYECOM.Core.MyConvert.GetInt64(this.Request.QueryString["U_ID"].ToString()), pwd);
        if (num > 0)
        {
            this.libok.Text = "重设密码成功";
        }
        else
        {
            this.libok.Text = "重设密码失败";
        }
    }
    #endregion

}







