using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.Caching;
using XYECOM.Model;

namespace XYECOM.Page.shop
{

    public class ShopBasePage : BasePage
    {
        protected XYECOM.Model.GeneralUserInfo shopuserinfo = new XYECOM.Model.GeneralUserInfo();

        protected string editinfourl = string.Empty;
        protected string modifypwdurl = string.Empty;
        protected string loginname = string.Empty;

        /// <summary>
        /// 临时变量
        /// </summary>
        protected string str = string.Empty;

        protected bool islogin = false;

        protected override void OnLoad(EventArgs e)
        {
            XYECOM.Model.UserRegInfo userRegInfo = null;
            string userName = XYECOM.Core.XYRequest.GetQueryString("u_name");
            string userTopDomain = string.Empty;
            if (!string.IsNullOrEmpty(userName))
            {
                userRegInfo = new XYECOM.Business.UserReg().GetItem(userName);
            }
            else if (!string.IsNullOrEmpty((userTopDomain = XYECOM.Core.XYRequest.GetQueryString("udomain"))))
            {
                XYECOM.Model.UserDomainInfo udInfo = new Business.UserDomain().GetItem(userTopDomain);

                if (udInfo == null)
                {
                    GotoMsgBoxPage("域名错误！", "/index." + config.suffix);
                    return;
                }

                userRegInfo = new XYECOM.Business.UserReg().GetItem(udInfo.UserId);
            }
            else
            {
                GotoMsgBoxPage("参数错误！", "/index." + config.suffix);
                return;
            }

            if (userRegInfo == null || userRegInfo.UserType == (int)Model.UserType.CreditorEnterprise || userRegInfo.UserType == (int)Model.UserType.CreditorIndividual)
            {
                GotoMsgBoxPage("用户不存在或未被审核通过！", "/index." + config.suffix);
                return;
            }

            shopuserinfo = Business.CheckUser.GetUserInfo(userRegInfo);


            islogin = XYECOM.Business.CheckUser.CheckUserLogin();

            if (islogin)
            {
                Model.GeneralUserInfo userinfo = XYECOM.Business.CheckUser.UserInfo;
                Model.UserType utype = (UserType)userinfo.UserType;

                string folder = (utype == UserType.Layer || utype == UserType.NotLayer) ? "Server" : "Creditor";
                editinfourl = "/" + folder + "/BaseEdit.aspx";
                modifypwdurl = "/" + folder + "/ModifyPwd.aspx";
                loginname = userinfo.LoginName;
            }
            base.OnLoad(e);
        }
    }
}
