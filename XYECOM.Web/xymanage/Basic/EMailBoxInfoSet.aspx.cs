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
using System.Net.Mail;

public partial class xymanage_basic_EMailBoxInfoSet : XYECOM.Web.BasePage.ManagePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("basic");
    }

    protected override void BindData()
    {
        this.txtEmail.Text = webInfo.Email;
        this.txtEmailServer.Text =webInfo.EmailServer;
        this.txtEmailServerPort.Text = webInfo.EmailServerPort.ToString();
        this.txtLoginName.Text = webInfo.EmailLoginName;
        this.txtPassword.Attributes.Add("value", webInfo.EmailPwd);
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        webInfo.Email = this.txtEmail.Text.Trim();
        webInfo.EmailServer = this.txtEmailServer.Text.Trim();

        int port = XYECOM.Core.MyConvert.GetInt32(this.txtEmailServerPort.Text.Trim());
        if (port <= 0) port = 25;

        webInfo.EmailServerPort = port;

        webInfo.EmailLoginName = this.txtLoginName.Text.Trim();
        webInfo.EmailPwd = this.txtPassword.Text.Trim();

        bool result = webInfo.Update();

        //根据添加或修改的结果判断是否成功
        if (result)
        {
            this.lblSetMsg.Text = "邮件服务器设置成功";

            BindData();
        }
        else
        {
            this.lblSetMsg.Text = "邮件服务器设置失败,请检查配置文件目录读写权限！";
        }
    }

    protected void btnTest_Click(object sender, EventArgs e)
    {
        string toEmail = this.txtTestEmail.Text.Trim();
        string title = "你好";
        string content = "你好,这是一封测试邮件,请不要回复.";

        if(XYECOM.Business.Utils.SendMail(toEmail, title, content))
        {
            this.lbmessage.Text = "发送成功.";
        }
        else
        {
            this.lbmessage.Text = "邮件发送失败,请更改设置或重试.";
        } 
    }
}
