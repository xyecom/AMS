using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYECOM.Page;

namespace XYECOM.Web
{
    public partial class Register : ForeBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.MultiView1.ActiveViewIndex = 0;
            }
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbtn = sender as RadioButton;
            this.MultiView1.ActiveViewIndex = int.Parse(rbtn.ToolTip);
        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            string loginName = string.Empty;
            string companyName = string.Empty;
            string pwd = string.Empty;
            int areaId = Core.MyConvert.GetInt32(this.city.Value.Trim());
            string email = string.Empty;
            string chief = string.Empty;
            int selIndex = this.MultiView1.ActiveViewIndex;
            Model.UserType userType = XYECOM.Model.UserType.CreditorEnterprise;
            loginName = txtUserName.Text.Trim();
            pwd = txtPwd1.Text.Trim();
            email = txtEmail.Text.Trim();

            switch (selIndex + 1)
            {
                case 1:

                    userType = XYECOM.Model.UserType.CreditorEnterprise;
                    companyName = this.txtCompanyName.Text.Trim();

                    chief = this.txtCompanyChief.Text.Trim();
                    break;
                case 2:
                    userType = XYECOM.Model.UserType.CreditorIndividual;
                    break;
                case 3:
                    userType = XYECOM.Model.UserType.Layer;
                    companyName = this.txtLawyerCompanyName.Text.Trim();
                    break;
                case 4:
                    userType = XYECOM.Model.UserType.NotLayer;
                    break;
            }


            Model.UserRegInfo regInfo = new XYECOM.Model.UserRegInfo();

            regInfo.LoginName = loginName;
            regInfo.Password = Core.SecurityUtil.MD5(pwd, XYECOM.Configuration.Security.Instance.Md5value);
            regInfo.Email = email;
            regInfo.RegDate = DateTime.Now;
            regInfo.UserType = (int)userType;
            regInfo.AreaId = areaId;
            regInfo.Answer = string.Empty;
            regInfo.Question = string.Empty;
            regInfo.IsPrimary = true;


            XYECOM.Model.UserInfo userInfo = new XYECOM.Model.UserInfo();
            userInfo.Email = email;
            userInfo.AreaId = areaId;
            userInfo.Name = companyName;
            userInfo.LinkMan = chief;

            userInfo.Address = string.Empty;
            userInfo.Address = string.Empty;
            userInfo.BuyPro = string.Empty;
            userInfo.License = string.Empty;
            userInfo.Character = string.Empty;
            userInfo.EmployeeTotal = string.Empty;
            userInfo.HomePage = string.Empty;
            userInfo.Synopsis = string.Empty;
            userInfo.Postcode = string.Empty;
            //userInfo.RegAreaId
            userInfo.Mobile = string.Empty;
            //userInfo.UserTypeId
            userInfo.Sex = true;
            userInfo.Section = string.Empty;
            userInfo.Post = string.Empty;
            userInfo.SupplyOrBuy = 3;
            userInfo.SupplyPro = string.Empty;
            userInfo.BuyPro = string.Empty;
            userInfo.Mode = string.Empty;
            userInfo.RegisteredCapital = decimal.Zero;
            userInfo.RegYear = 1;
            userInfo.Address = string.Empty;
            userInfo.MainProduct = string.Empty;
            userInfo.MoneyType = string.Empty;
            userInfo.IM = string.Empty;
            userInfo.Telephone = string.Empty;
            userInfo.Fax = string.Empty;
            userInfo.TradeIds = string.Empty;

            long userId = 0;

            string message = string.Empty;

            Model.ResisterUserReturnValue value = new Business.UserReg().Register(regInfo, userInfo, pwd, out userId);


            if (value == XYECOM.Model.ResisterUserReturnValue.UserNameExists)
                message = "注册失败，用户名已经被占用";

            if (value == XYECOM.Model.ResisterUserReturnValue.EmailExists)
                message = "注册失败，邮箱已经被占用";

            if (value == XYECOM.Model.ResisterUserReturnValue.Failed)
                message = "注册失败，异常错误，请检查各项数据";

            if (value == XYECOM.Model.ResisterUserReturnValue.ForbidName)
                message = "注册失败，此用户名禁止注册";

            if (!string.IsNullOrEmpty(message))
            {
                GotoMsgBoxPageForDynamicPage(message, 5, "/register.aspx");
                return;
            }

            string gotoUrl = "";

            if (userType == XYECOM.Model.UserType.CreditorEnterprise || userType == Model.UserType.CreditorIndividual)
            {
                gotoUrl = "/Creditor/index.aspx";
            }
            else
            {
                gotoUrl = "Server/index.aspx";
            }

            message = "注册成功，系统将自动进入会员中心...";

            GotoMsgBoxPageForDynamicPage(message, 1, gotoUrl);
        }
    }
}
