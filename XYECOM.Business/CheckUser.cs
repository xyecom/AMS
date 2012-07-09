using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// �����û�ҵ����
    /// </summary>
    public class CheckUser
    {
        public static string SYS_NOIMAGE_PATH = "";

        static CheckUser()
        {
            SYS_NOIMAGE_PATH = XYECOM.Configuration.WebInfo.Instance.WebDomain + "Common/Images/DefaultImg.gif";
        }

        #region �û����ĵ�½�û��Ķ���
        /// <summary>
        /// �û����ĵ�½�û���ȫ�ֶ���
        /// </summary>
        public static XYECOM.Model.GeneralUserInfo UserInfo
        {
            get
            {
                if (null != XYECOM.Core.Utils.GetSessionObj("UserInfo"))
                {
                    return (XYECOM.Model.GeneralUserInfo)XYECOM.Core.Utils.GetSessionObj("UserInfo");
                }
                else
                {
                    string strUserName = XYECOM.Core.Utils.GetCookie("UserName");
                    string strPassWord = XYECOM.Core.Utils.GetCookie("PassWord");

                    if ("" != strUserName)
                    {
                        XYECOM.Model.UserRegInfo _userInfo = new XYECOM.Business.UserReg().GetItem(strUserName, strPassWord);
                        if (null != _userInfo)
                        {
                            XYECOM.Model.GeneralUserInfo _info = GetUserInfo(_userInfo);

                            if (null != _info)
                            {
                                string cookieDomain = XYECOM.Configuration.WebInfo.Instance.CookieDomain;

                                XYECOM.Core.Utils.WriteCookie("UserId", _userInfo.UserId.ToString(), cookieDomain);
                                //�û�������
                                XYECOM.Core.Utils.WriteCookie("UserGradeId", _userInfo.GradeId.ToString(), cookieDomain);
                                
                                string strUserType = "user";

                                XYECOM.Core.Utils.WriteCookie("UserType", strUserType, cookieDomain);


                                XYECOM.Core.Utils.SetSession("UserInfo", _info);
                            }
                            return _info;
                        }
                    }
                    return null;
                }
            }
        }
        #endregion

        /// <summary>
        /// ��ȡǰ̨�û���½״̬
        /// </summary>
        /// <returns></returns>
        public static bool CheckUserLogin()
        {
            return UserInfo != null;
        }

        #region ��ȡ����ǰ̨�û���Ϣ
        /// <summary>
        /// ��ȡ����ǰ̨�û���Ϣ
        /// </summary>
        /// <param name="userId">�û����</param>
        /// <returns>ǰ̨�û���Ϣʵ�����</returns>
        public static XYECOM.Model.GeneralUserInfo GetUserInfo(long userId)
        {
            XYECOM.Model.UserRegInfo _userInfo = new XYECOM.Business.UserReg().GetItem(userId);

            if (_userInfo == null) return null;

            return GetUserInfo(_userInfo);
        }
        /// <summary>
        /// ��ȡǰ̨�û�����
        /// </summary>
        /// <param name="userRegInfo">�û�ʵ�����</param>
        /// <returns>�û�ʵ�����</returns>
        public static XYECOM.Model.GeneralUserInfo GetUserInfo(XYECOM.Model.UserRegInfo userRegInfo)
        {
            XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;

            if (userRegInfo == null) return null;
            XYECOM.Model.GeneralUserInfo _templateuserinfo = new XYECOM.Model.GeneralUserInfo();

            _templateuserinfo.accountid = userRegInfo.AccountId;
            _templateuserinfo.creditintegral = userRegInfo.CreditIntegral;
            _templateuserinfo.creditleavl = new CreditLeavlManager().GetItemByPoint(userRegInfo.CreditIntegral);

            _templateuserinfo.userid = userRegInfo.UserId;

            _templateuserinfo.loginname = userRegInfo.LoginName;

            _templateuserinfo.regdate = userRegInfo.RegDate;


            if (userRegInfo.IsActivation)
                _templateuserinfo.activation = true;
            else
                _templateuserinfo.activation = false;

            _templateuserinfo.isaudited = userRegInfo.AuditingState == XYECOM.Model.AuditingState.Passed ? true : false;

            _templateuserinfo.email = userRegInfo.Email;

            _templateuserinfo.mark = userRegInfo.Mark;

            if (userRegInfo.IsHasImage)
                _templateuserinfo.imgurl = Business.Attachment.GetInfoDefaultImgHref(XYECOM.Model.AttachmentItem.User, _templateuserinfo.userid);
            else
                _templateuserinfo.imgurl = SYS_NOIMAGE_PATH;

            XYECOM.Model.UserInfo _UserInfo = new XYECOM.Business.UserInfo().GetItem(userRegInfo.UserId);

            if (_UserInfo != null)
            {
                _templateuserinfo.years = userRegInfo.Years;

                if (_templateuserinfo.years.Equals("0")) _templateuserinfo.years = "1";

                _templateuserinfo.template = userRegInfo.TemplateName;

                if (_templateuserinfo.template.IndexOf("|") != -1)
                    _templateuserinfo.template = _templateuserinfo.template.Split('|')[1];

                _templateuserinfo.cred = userRegInfo.Cred;

                _templateuserinfo.infoperfectpercent = userRegInfo.InFormation;

                _templateuserinfo.maliceerr = userRegInfo.MaliceErr;

                _templateuserinfo.commonerr = userRegInfo.CommonErr;

                _templateuserinfo.linkman = _UserInfo.LinkMan.ToString();

                _templateuserinfo.sexbool = _UserInfo.Sex;

                _templateuserinfo.manageaddress = _UserInfo.BusinessAddress;

                if (_UserInfo.Sex.ToString() == "True")
                    _templateuserinfo.sex = "����";
                else
                    _templateuserinfo.sex = "Ůʿ";

                _templateuserinfo.name = _UserInfo.Name.ToString();

                //֮��ɾ��
                _templateuserinfo.unitname = _UserInfo.Name.ToString();

                _templateuserinfo.mobile = _UserInfo.Mobile;

                _templateuserinfo.telephone = _UserInfo.Telephone;

                _templateuserinfo.fax = _UserInfo.Fax;

                _templateuserinfo.gradeid = _UserInfo.RegInfo.GradeId;

                _templateuserinfo.synopsis = _UserInfo.Synopsis;

                _templateuserinfo.homepage = _UserInfo.HomePage;

                _templateuserinfo.character = _UserInfo.Character;

                _templateuserinfo.unittypeid = (int)_UserInfo.UserTypeId;

                _templateuserinfo.tradeids = _UserInfo.TradeIds;

                _templateuserinfo.unittype = "";
                if (_UserInfo._UserTypeInfo != null)
                    _templateuserinfo.unittype = _UserInfo._UserTypeInfo.UT_Type;

                _templateuserinfo.employeetotal = _UserInfo.EmployeeTotal;

                if (_UserInfo.RegAreaId > 0)
                {
                    Model.AreaInfo areainfo = new Business.Area().GetItem(_UserInfo.RegAreaId);
                    if (null != areainfo)
                        _templateuserinfo.regarea = areainfo.FullNameAll;
                }

                _templateuserinfo.regareaid = _UserInfo.RegAreaId;

                if (_UserInfo.AreaId > 0)
                {
                    Model.AreaInfo areainfo = new Business.Area().GetItem(_UserInfo.AreaId);
                    if (null != areainfo)
                        _templateuserinfo.areaname = areainfo.FullNameAll;
                }


                //_templateuserinfo.address = _UserInfo.U_Address;

                _templateuserinfo.address = _UserInfo.Address;

                _templateuserinfo.areaid = _UserInfo.AreaId;

                _templateuserinfo.mode = _UserInfo.Mode;

                _templateuserinfo.regyear = _UserInfo.RegYear.ToString();

                _templateuserinfo.supplypro = _UserInfo.MainProduct;

                _templateuserinfo.buypro = _UserInfo.BuyPro;

                _templateuserinfo.registeredcapital = _UserInfo.RegisteredCapital.ToString();

                _templateuserinfo.post = _UserInfo.Post;

                _templateuserinfo.department = _UserInfo.Section;

                _templateuserinfo.zipcode = _UserInfo.Postcode;

                _templateuserinfo.supplyorbuy = _UserInfo.SupplyOrBuy;

                _templateuserinfo.im = _UserInfo.IM;

                if (_templateuserinfo.isshop)
                {
                    //�������󶨶�������
                    Model.UserDomainInfo domainInfo = new Business.UserDomain().GetItem(_templateuserinfo.userid);
                    if (_templateuserinfo.isbindingtopdomain && domainInfo != null && domainInfo.State == XYECOM.Model.AuditingState.Passed)
                    {
                        _templateuserinfo.shopindex = "http://" + domainInfo.Domain;
                        _templateuserinfo.domain = "http://" + domainInfo.Domain + "/";
                        _templateuserinfo.contactus = _templateuserinfo.shopindex + "/contact." + webInfo.WebSuffix;
                    }
                    else if (webInfo.IsDomain && _templateuserinfo.issubdomain)
                    {
                        _templateuserinfo.shopindex = webInfo.GetSubDomain(_templateuserinfo.loginname);
                        _templateuserinfo.contactus = webInfo.GetSubDomain(_templateuserinfo.loginname) + "contact." + webInfo.WebSuffix;
                        _templateuserinfo.domain = webInfo.GetSubDomain(_templateuserinfo.loginname);
                        //http://yijia.botao.com/
                    }
                    else
                    {
                        _templateuserinfo.shopindex = webInfo.WebDomain + "shop/" + _templateuserinfo.loginname + "/index." + webInfo.WebSuffix;
                        _templateuserinfo.contactus = webInfo.WebDomain + "shop/" + _templateuserinfo.loginname + "/contact." + webInfo.WebSuffix;
                        _templateuserinfo.domain = webInfo.WebDomain + "shop/" + _templateuserinfo.loginname + "/";
                        //http://www.botao.com/shop/yijia/
                    }
                }
                else
                {
                    if (webInfo.IsBogusStatic)
                        _templateuserinfo.shopindex = webInfo.WebDomain + "company/info-" + _templateuserinfo.userid + "." + webInfo.WebSuffix;
                    else
                        _templateuserinfo.shopindex = webInfo.WebDomain + "company/info." + webInfo.WebSuffix + "?ui=" + _templateuserinfo.userid;

                    _templateuserinfo.contactus = _templateuserinfo.shopindex;
                    _templateuserinfo.domain = webInfo.WebDomain;
                }
            }

            return _templateuserinfo;
        }
        #endregion

        #region ��̨�û���Ϣ
        /// <summary>
        /// ����̨�û�Session״̬
        /// </summary>
        /// <returns>Session�Ƿ����</returns>
        public static bool CheckManageSessionState()
        {
            string adminDir = XYECOM.Configuration.WebInfo.Instance.AdminFolder;
            //��Session״̬��ʧʱͨ��Cookie������֤
            if (Core.Utils.GetSession("A_Name") == "" || Core.Utils.GetSession("UM_ID") == "")
            {
                if (Core.Utils.GetCookie("AdminId") == ""
                    || Core.Utils.GetCookie("AdminName") == ""
                    || Core.Utils.GetCookie("AdminExpires") == ""
                    || Core.Utils.GetCookie("AdminPwd") == "")
                {
                    return false;
                }

                //��ȡ�û�����ID
                string adminId = Core.Utils.GetCookie("AdminId");
                string adminName = Core.Utils.GetCookie("AdminName");
                string adminPwd = Core.Utils.GetCookie("AdminPwd");
                string adminExpires = Core.Utils.GetCookie("AdminExpires");

                //����
                adminId = XYECOM.Core.SecurityUtil.AESDecrypt(adminId, XYECOM.Configuration.Security.Instance.AESKey);
                adminName = XYECOM.Core.SecurityUtil.AESDecrypt(adminName, XYECOM.Configuration.Security.Instance.AESKey);
                adminExpires = XYECOM.Core.SecurityUtil.AESDecrypt(adminExpires, XYECOM.Configuration.Security.Instance.AESKey);

                //�жϹ���ʱ��
                DateTime time = Convert.ToDateTime(adminExpires);
                TimeSpan timeSpan = time - DateTime.Now;

                XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;

                int span = timeSpan.Minutes;
                //����Ѿ�����
                if (span < 0)
                {
                    Core.Utils.ClearCookie("AdminId", webInfo.CookieDomain);
                    Core.Utils.ClearCookie("AdminName", webInfo.CookieDomain);
                    Core.Utils.ClearCookie("AdminPwd", webInfo.CookieDomain);
                    Core.Utils.ClearCookie("AdminExpires", webInfo.CookieDomain);
                    return false;
                }

                //��ȡ�û���������������֤
                int result = new XYECOM.Business.Admin().isMyUser(adminName, adminPwd);

                if (result <= 0)
                {
                    Core.Utils.ClearCookie("AdminId", webInfo.CookieDomain);
                    Core.Utils.ClearCookie("AdminName", webInfo.CookieDomain);
                    Core.Utils.ClearCookie("AdminPwd", webInfo.CookieDomain);
                    Core.Utils.ClearCookie("AdminExpires", webInfo.CookieDomain);
                    return false;
                }

                //�������ù���ʱ�䣬����20����
                Core.Utils.WriteCookie("AdminExpires", XYECOM.Core.SecurityUtil.AESEncrypt(DateTime.Now.AddMinutes(30).ToLongTimeString(), XYECOM.Configuration.Security.Instance.AESKey), webInfo.CookieDomain);

                //����Session
                Core.Utils.SetSession("A_Name", adminName);
                Core.Utils.SetSession("UM_ID", adminId);
            }
            return true;
        }
        #endregion
    }
}
