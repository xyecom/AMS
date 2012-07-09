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

public partial class xymanage_basic_UserInfoSet : XYECOM.Web.BasePage.ManagePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("basic");
        if (!IsPostBack)
        {
            GetWebInfo();
            this.btok.Attributes.Add("onclick", "javascript:return UserInput()");
        }
    }
    
    #region 绑定要编辑的用户数据
    private void GetWebInfo()
    {
        if (webInfo.IsRegister)
            this.isusert.Checked = true;
        else
            this.isuserf.Checked = true;

        this.RegisterModeList.SelectedValue = webInfo.RegisterMode;

        if (webInfo.IsRegisterEmail)
        {
            this.rbresteisemailyes.Checked = true;
        }
        else
        {
            this.rbresteisemailno.Checked = true;
        }

        if (webInfo.IsAuditingUserEmail)
        {
            this.auditinguseryes.Checked = true;
        }
        else
        {
            this.auditinguserno.Checked = true;
        }

        if (webInfo.WebMoneyName != "")
        {
            this.Label2.Text = webInfo.WebMoneyName;
            this.Label3.Text = webInfo.WebMoneyName;
        }

        this.txtCanChooseTradeNumber.Text = webInfo.CanChooseTradeNumber.ToString();

        if (webInfo.UserRegisterAuditingType)
            this.atuoadtuser.Checked = true;
        else
            this.manadtuser.Checked = true;

        this.txtScores.Text = webInfo.LoginAddScore.ToString();


        if (webInfo.IsGuestLookLinkInfo)
            this.yke.Checked = true;
        else
            this.yk.Checked = true;

        if (webInfo.IsRegisterMessage)
        {
            this.webnotet.Checked = true;
        }
        else
        {
            this.webnotef.Checked = true;
        }

        this.tbnotetitle.Text = webInfo.RegisterMessageTitle;
        this.tbnotetext.Text = webInfo.RegisterMessageContent;
        
        this.tbforbidname.Text =webInfo.ForbidName.ToString();

        this.tbuserhortation.Text = webInfo.UserDefaultWebMoney.ToString();

        this.tbloginhortation.Text = webInfo.LoginAddWebMoney.ToString();
     
		// 资料完善度开始
        this.tbregist.Text = webInfo.RegisterPercent.ToString();

        this.tbbase.Text = webInfo.BaseDatumPercent.ToString();

        this.tbmobile.Text = webInfo.MobilePercent.ToString();

        this.tbbranch.Text = webInfo.DepartmentPercent.ToString();

        this.tbcomple.Text = webInfo.AdvancedDatumPercent.ToString();

        this.tbcapital.Text = webInfo.CapitalPercent.ToString();

        this.tblicence.Text = webInfo.LicencePercent.ToString();

        this.tbcertificate.Text = webInfo.CertificatePercent.ToString();

        
		// 资料完善度结束
        if (webInfo.IsAuditingUserMessage)
        {
            this.rbauditmessageyes.Checked = true;
        }
        else
        {
            this.rbauditmessageno.Checked = true;
        }

        this.lbsentmessasgetitle.Text = webInfo.AuditingUserMessageTitle;

        this.lbusersentmessagecontent.Text = webInfo.AuditingUserMessageContent; ;

        if (webInfo.IsAddMoneyMessage)
        {
            this.useraddmoneymessageyes.Checked = true;
        }
        else
        {
            this.useraddmoneymessageno.Checked =true ;
        }

        this.addmoneytitle.Text = webInfo.AddMoneyMessageTitle.ToString();
        this.addmoneycontent.Text = webInfo.AddMoneyMessageContent;

        if (webInfo.IsAddMoneyEmail)
        {
            this.addmoneyyes.Checked = true;
        }
        else
        {
            this.addmoneyno.Checked = true;
        }

        ViewState["wi_id"] = 0;
        //this.btok.Text = "提  交";
    }
    #endregion

    #region 单击提交按钮事件
    protected void btok_Click(object sender, EventArgs e)
    {
        if (this.isusert.Checked == true)
            webInfo.IsRegister = true;
        else if (this.isuserf.Checked == true)
            webInfo.IsRegister = false;

        webInfo.RegisterMode = this.RegisterModeList.SelectedValue;

        if (this.atuoadtuser.Checked == true)
            webInfo.UserRegisterAuditingType = true;
        else 
            webInfo.UserRegisterAuditingType = false;
                
        webInfo.ForbidName = this.tbforbidname.Text;
        
        if (this.tbuserhortation.Text != "")
            webInfo.UserDefaultWebMoney = XYECOM.Core.MyConvert.GetInt32(this.tbuserhortation.Text);
        else
            webInfo.UserDefaultWebMoney = 0;

        webInfo.CanChooseTradeNumber = XYECOM.Core.MyConvert.GetInt32(this.txtCanChooseTradeNumber.Text.Trim());

        if (this.tbloginhortation.Text != "")
            webInfo.LoginAddWebMoney = XYECOM.Core.MyConvert.GetInt32(this.tbloginhortation.Text);
        else
            webInfo.LoginAddWebMoney = 0;

        if (this.rbresteisemailyes.Checked==true)
        {
            webInfo.IsRegisterEmail = true;
        }
        else if (this.rbresteisemailno.Checked==true)
        {
            webInfo.IsRegisterEmail = false;
        }

        if (this.auditinguseryes.Checked == true)
        {
            webInfo.IsAuditingUserEmail = true;
        }
        else
        {
            webInfo.IsAuditingUserEmail = false;
        }
        if (this.yk.Checked == true)
            webInfo.IsGuestLookLinkInfo = false;
        else if (this.yke.Checked == true)
            webInfo.IsGuestLookLinkInfo = true;


        if (this.webnotet.Checked == true)
        {
            webInfo.IsRegisterMessage = true;
        }
        else if (this.webnotef.Checked == true)
        {
            webInfo.IsRegisterMessage = false;
        }
        webInfo.RegisterMessageTitle = this.tbnotetitle.Text;
        webInfo.RegisterMessageContent = this.tbnotetext.Text;
        
		// 资料完善度开始
		if (this.tbregist.Text.Trim() != "")
            webInfo.RegisterPercent = XYECOM.Core.MyConvert.GetInt32(this.tbregist.Text.Trim());
        else
            webInfo.RegisterPercent = 0;

        if (this.tbbase.Text.Trim() != "")
            webInfo.BaseDatumPercent = XYECOM.Core.MyConvert.GetInt32(this.tbbase.Text.Trim());
        else
            webInfo.BaseDatumPercent = 0;

        if (this.tbmobile.Text.Trim() != "")
            webInfo.MobilePercent = XYECOM.Core.MyConvert.GetInt32(this.tbmobile.Text.Trim());
        else
            webInfo.MobilePercent = 0;

        if (this.tbbranch.Text.Trim() != "")
            webInfo.DepartmentPercent = XYECOM.Core.MyConvert.GetInt32(this.tbbranch.Text.Trim());
        else
            webInfo.DepartmentPercent = 0;

        if (this.tbcomple.Text.Trim() != "")
            webInfo.AdvancedDatumPercent = XYECOM.Core.MyConvert.GetInt32(this.tbcomple.Text.Trim());
        else
            webInfo.AdvancedDatumPercent = 0;

        if (this.tbcapital.Text.Trim() != "")
            webInfo.CapitalPercent = XYECOM.Core.MyConvert.GetInt32(this.tbcapital.Text.Trim());
        else
            webInfo.CapitalPercent = 0;

        if (this.tblicence.Text.Trim() != "")
            webInfo.LicencePercent = XYECOM.Core.MyConvert.GetInt32(this.tblicence.Text.Trim());
        else
            webInfo.LicencePercent = 0;

        if (this.tbcertificate.Text.Trim() != "")
            webInfo.CertificatePercent = XYECOM.Core.MyConvert.GetInt32(this.tbcertificate.Text.Trim());
        else
            webInfo.CertificatePercent = 0;
        // 资料完善度结束			
        if (this.rbauditmessageyes.Checked == true)
        {
            webInfo.IsAuditingUserMessage = true;
        }
        else  if(this.rbauditmessageno.Checked == true)
        {
            webInfo.IsAuditingUserMessage = false;
        }

        if (this.addmoneyyes.Checked)
        {
            webInfo.IsAddMoneyEmail = true;
        }
        else if (this.addmoneyno.Checked)
        {
            webInfo.IsAddMoneyEmail = false;
        }

        if (this.txtScores.Text != "")
            webInfo.LoginAddScore = XYECOM.Core.MyConvert.GetInt32(this.txtScores.Text.Trim());
        else
            webInfo.LoginAddScore = 0;

        if (this.useraddmoneymessageyes.Checked == true)
        {
            webInfo.IsAddMoneyMessage = true;
        }
        else if (this.useraddmoneymessageno.Checked == true)
        {
            webInfo.IsAddMoneyMessage = false;
        }

        webInfo.AddMoneyMessageTitle = this.addmoneytitle.Text;
        webInfo.AddMoneyMessageContent = this.addmoneycontent.Text;
        webInfo.AuditingUserMessageTitle = this.lbsentmessasgetitle.Text;
        webInfo.AuditingUserMessageContent = this.lbusersentmessagecontent.Text;
        //实例化网站设置方法类以及登录日志类
        XYECOM.Business.Log l = new XYECOM.Business.Log();
        XYECOM.Model.LogInfo el = new XYECOM.Model.LogInfo();

        bool resule = webInfo.Update();
        string url = "UserInfoSet.aspx";
        //根据添加或修改的结果判断是否成功
        if (resule)
        {
            el.L_Title = "网站设置";
            el.L_Content = "设置网站信息成功";
            el.L_MF = "系统信息设置";
            
            {
                el.UM_ID = AdminId;
            }
            l.Insert(el);
            Alert("设置成功！", url);
        }
        else
        {
            el.L_Title = "网站设置";
            el.L_Content = "设置网站信息失败";
            el.L_MF = "系统信息设置";
            
            {
                el.UM_ID = AdminId;
            }
            l.Insert(el);
            Alert("设置失败,请检查/config/目录写权限！", url);
        }
    }
    #endregion
}
