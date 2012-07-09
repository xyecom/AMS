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

public partial class xymanage_basic_BussinessInfoSet : XYECOM.Web.BasePage.ManagePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("basic");        
    }

    #region 绑定要编辑的商业信息设置
    protected override void BindData()
    {
        this.btok.Attributes.Add("onclick", "javascript:return BussinessInput();");

        //修改商业信息审核方式(True表自动审核,false表人工审核)
        if (webInfo.InsertInfoAuditingType)
            this.autoadtms.Checked = true;
        else
            this.manadtms.Checked = true;
        
        if (webInfo.WebMoneyName != "")
        {
            this.Label4.Text = webInfo.WebMoneyName;
            this.Label5.Text = webInfo.WebMoneyName;
        }

        if (webInfo.EditInfoAuditingType)
            this.autonewadt.Checked = true;
        else
            this.mannewadt.Checked = true;

        //用户发布信息奖励
        this.tbuseraddinfo.Text = webInfo.IssueInfoAddWebMoney.ToString();


        //刷新一次信息奖励
        this.tbrefurbishinfo.Text = webInfo.RefreshInfoAddWebMoney.ToString();

        //设置热门关键字读取数目
        //this.tbsearchkey.Text = webInfo.HotKeyNumber.ToString();

        //商业信息设置中截至时间方式(true表时间段,false表时间点.默认时间段true)
        if (webInfo.InfoEndTimeType)
            this.enddate.Checked = true;
        else
            this.endtime.Checked = true;

        //审核商业信息是否启用站内短信(true表启用,false表不启用)
        if (webInfo.IsAuditingInfoMessage)
            this.AuditIsMessageYes.Checked = true;
        else
            this.AuditIsMessageNo.Checked = true;

        this.tbsentmessagetitle.Text = webInfo.AuditingInfoMessageTitle;

        this.tbsentmessagecontent.Text = webInfo.AuditingUserMessageContent;

        this.txtAboutInfoNum.Text = webInfo.AboutInfoNum.ToString();

        this.txtSysMessageNum.Text = webInfo.SystemMessageNumber.ToString();

        //申请商业信息是否启用邮件发送(true表启用,false表不启用)
        if (webInfo.IsAuditingInfoEmail)
            this.AuditIsEmailYes.Checked = true;
        else
            this.AuditIsEmailNo.Checked = true;

        if (webInfo.IsBidEmail)
            this.BidIsEmailYes.Checked = true;
        else
            this.BidIsEmailNo.Checked = true;

        if (webInfo.IsBidMessage)
            this.BidIsMessageYes.Checked = true;
        else
            this.BidIsMessageNo.Checked = true;

        this.jinjiatitle.Text = webInfo.BidMessageTitle;

        this.jinjiacontent.Text = webInfo.BidMessageContent;

        if (webInfo.IsJobEmail)
            this.JobIsEmailYes.Checked = true;
        else
            this.JobIsEmailNo.Checked = true;

        if (webInfo.IsJobMessage)
            this.JobIsMessageYes.Checked = true;
        else
            this.JobIsMessageNo.Checked = true;

        this.jobtitle.Text = webInfo.JobMessageTitle.ToString();

        this.jobcontent.Text = webInfo.JobMessageContent;

        //if (Convert.ToBoolean(webInfo.Rows[0]["WI_JobIsMessage"]) == true)
        //    this.jobmessageyes.Checked = true;
        //else
        //    this.jobmessageno.Checked = true;


        if (webInfo.IsOrderEmail)
            this.OrderIsEmailYes.Checked = true;
        else
            this.OrderIsEmailNo.Checked = true;

        if (webInfo.IsOrderMessage)
            this.OrderIsMessageYes.Checked = true;
        else
            this.OrderIsMessageNo.Checked = true;

        this.ordermessagetitle.Text = webInfo.OrderMessageTitle;
        this.ordermessagecontent.Text = webInfo.OrderMessageContent;

        //ViewState["wi_id"] = 0;
        //this.btok.Text = "提  交"; 

    }
    #endregion

    #region 确定
    protected void btok_Click(object sender, EventArgs e)
    {
        //商业信息审核方式
        if (this.autoadtms.Checked == true)
            webInfo.InsertInfoAuditingType = true;
        else
            webInfo.InsertInfoAuditingType = false;

        //修改后审核方式
        if (this.autonewadt.Checked == true)
            webInfo.EditInfoAuditingType = true;
        else
            webInfo.EditInfoAuditingType = false;

        //发布信息奖励
        if (this.tbuseraddinfo.Text != "")
            webInfo.IssueInfoAddWebMoney = Convert.ToInt32(this.tbuseraddinfo.Text);
        else
            webInfo.IssueInfoAddWebMoney = 0;

        //刷新一次信息奖励
        if (this.tbrefurbishinfo.Text != "")
            webInfo.RefreshInfoAddWebMoney = Convert.ToInt32(this.tbrefurbishinfo.Text);
        else
            webInfo.RefreshInfoAddWebMoney = 0;

        //热门关键字显示数目
        //if (string.IsNullOrEmpty(this.tbsearchkey.Text.Trim()))
        //    webInfo.HotKeyNumber = 0;
        //else
        //    webInfo.HotKeyNumber = Convert.ToInt32(this.tbsearchkey.Text.Trim());

        //有效期选择方式
        if (this.enddate.Checked == true)
            webInfo.InfoEndTimeType = true;
        else
            webInfo.InfoEndTimeType = false;

        //商业信息审核邮件提示  
        webInfo.IsAuditingInfoEmail = false;
        if (this.AuditIsEmailYes.Checked == true) webInfo.IsAuditingInfoEmail = true;

        //商业信息审核短信提示
        webInfo.IsAuditingInfoMessage = false;
        if (this.AuditIsMessageYes.Checked == true) webInfo.IsAuditingInfoMessage = true;     

        //商业信息审核短信标题
        webInfo.AuditingInfoMessageTitle = this.tbsentmessagetitle.Text;
        //商业信息审核短信内容
        webInfo.AuditingUserMessageContent = this.tbsentmessagecontent.Text;

        webInfo.AboutInfoNum = XYECOM.Core.MyConvert.GetInt32(txtAboutInfoNum.Text.Trim());

        webInfo.SystemMessageNumber = XYECOM.Core.MyConvert.GetInt32(this.txtSysMessageNum.Text);

        //竞价邮件提示
        webInfo.IsBidEmail = false;
        if (this.BidIsEmailYes.Checked == true) webInfo.IsBidEmail = true;

        //竞价短信提示
        webInfo.IsBidMessage = false;
        if (this.BidIsMessageYes.Checked == true) webInfo.IsBidMessage = true;

        //竞价短信标题
        webInfo.BidMessageTitle = this.jinjiatitle.Text;
        //竞价短信内容
        webInfo.BidMessageContent = this.jinjiacontent.Text;

        //推荐好友邮件提示
        webInfo.IsJobEmail = false;
        if (this.JobIsEmailYes.Checked == true) webInfo.IsJobEmail = true;

        //招聘求职短信提示
        webInfo.IsJobMessage = false;
        if (this.JobIsMessageYes.Checked == true) webInfo.IsJobMessage = true;

        //订单邮件提示
        webInfo.IsOrderEmail = false;
        if (this.OrderIsEmailYes.Checked == true) webInfo.IsOrderEmail = true;

        //订单短信提示
        webInfo.IsOrderMessage = false;
        if (this.OrderIsMessageYes.Checked == true) webInfo.IsOrderMessage = true;

        //订单短信标题
        webInfo.OrderMessageTitle = this.ordermessagetitle.Text;
        //订单短信内容
        webInfo.OrderMessageContent = this.ordermessagecontent.Text;
        //招聘求职短信标题
        webInfo.JobMessageTitle = this.jobtitle.Text;
        //招聘求职短信内容
        webInfo.JobMessageContent = this.jobcontent.Text;

        //实例化网站设置方法类以及登录日志类
        XYECOM.Business.Log l = new XYECOM.Business.Log();
        XYECOM.Model.LogInfo el = new XYECOM.Model.LogInfo();

        bool result = webInfo.Update();

        //根据添加或修改的结果判断是否成功
        el.L_Title = "网站设置模块";
        el.L_MF = "系统信息设置";
        el.L_Content = "设置商业信息设置成功";

        string url = "BussinessInfoSet.aspx";

        
        {
            el.UM_ID = AdminId;
        }
        if (result)
        {
            //XYECOM.Core.Config.WebConfig.instance.UpdateNode("datetype", webInfo.InfoEndTimeType.ToString());
            Alert("商业基本信息设置成功！", url);
        }
        else
        {
            el.L_Content = "设置商业信息设置失败";
            Alert("商业基本信息设置失败,可重新设置！", url);
        }
        l.Insert(el);
    }
    #endregion 
}
