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

        XYECOM.Business.UserReg regBLL = new UserReg();

        XYECOM.Model.UserInfo userInfo = userInfoBLL.GetItem(userId);
        XYECOM.Model.UserRegInfo reginfo = regBLL.GetItem(userId);

        //企业信息
        if (userInfo != null)
        {
            this.lbcompanyname.InnerHtml = userInfo.Name;//公司名称          
            this.phone.InnerHtml = userInfo.Telephone;
            this.address.InnerHtml = userInfo.Address;
            this.linkman.InnerHtml = userInfo.LinkMan;
            this.tdDescription.InnerHtml = userInfo.Description;
            this.area.InnerHtml = userInfo.AreaInfo.FullNameAll;
        }

        this.U_ID.Value = userId.ToString();

        //用户基本信息
        if (userInfo.RegInfo != null)
        {
            this.mail.InnerHtml = userInfo.RegInfo.Email;
            this.Email.Value = userInfo.RegInfo.Email;
            this.othercontract.InnerHtml = userInfo.RegInfo.OtherContact;//担任职位            
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







