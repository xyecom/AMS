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

public partial class xymanage_MessageManage_Default : XYECOM.Web.BasePage.ManagePage
{
    #region 页面初始化
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("email");
        if (!Page.IsPostBack)
        {
            this.lbemail.Text = webInfo.EmailLoginName.ToString();
        }
         
    }
    #endregion 

    protected void Button1_Click(object sender, EventArgs e)
    {
        int i = 0;
        string password = "";

        password = webInfo.EmailPwd.ToString();

        if (this.lbpassword.Text != "")
        {
            webInfo.EmailLoginName = this.lbemail.Text;
            webInfo.EmailPwd = this.lbpassword.Text;
            webInfo.Update();
        }
        else
        {
            webInfo.EmailLoginName = this.lbemail.Text;
            webInfo.EmailPwd = password;
            webInfo.Update();
        }
        string url = "SendEmail.aspx";
        if (i >= 0)
        {
            Alert("设置成功！", url);
        }
        else
        {
            Alert("设置失败！", url);
        }
    }
}
