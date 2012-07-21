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


            _templateuserinfo.CompanyId = userRegInfo.CompanyId;

            _templateuserinfo.IsPrimary = userRegInfo.IsPrimary;
            //��������(��ʦ����)	LayerName	varchar(50)	50		FALSE	FALSE	FALSE
            _templateuserinfo.LayerName = userRegInfo.LayerName;
            //��������	Description	text			FALSE	FALSE	FALSE
            _templateuserinfo.Description = userRegInfo.Description;
            //�绰	Telphone	varchar(50)	50		FALSE	FALSE	FALSE
            _templateuserinfo.Telphone = userRegInfo.Telphone;
            //������ϵ��ʽ	OtherContact	varchar(200)	200		FALSE	FALSE	FALSE
            _templateuserinfo.OtherContact = userRegInfo.OtherContact;
            //�Ա�0 �� 1Ů	Sex	bit			FALSE	FALSE	FALSE
            _templateuserinfo.Sex = userRegInfo.Sex;
            //���֤	IdNumber	varchar(50)	50		FALSE	FALSE	FALSE
            _templateuserinfo.IdNumber = userRegInfo.IdNumber;
            //��ʦ֤	LayerId	varchar(50)	50		FALSE	FALSE	FALSE
            _templateuserinfo.LayerId = userRegInfo.LayerId;
            //��������	AreaId	int			FALSE	FALSE	FALSE
            _templateuserinfo.AreaId = userRegInfo.AreaId;
            //�Ƿ�����֤ר��	IsExport	bit			FALSE	FALSE	FALSE
            _templateuserinfo.IsExport = userRegInfo.IsPrimary;
            //��ҵ���ͣ���ҵ&����&��ʦ&����ʦ����	UserType	int			FALSE	FALSE	FALSE
            _templateuserinfo.UserType = (Model.UserType)userRegInfo.UserType;
            //ɾ��״̬	DelState	int			FALSE	FALSE	FALSE
            _templateuserinfo.DelState = userRegInfo.DelState;
            //Ψһ��ʾ	IdentityNumber	varchar(50)	50		FALSE	FALSE	FALSE
            _templateuserinfo.IdentityNumber = userRegInfo.IdentityNumber;

            _templateuserinfo.PartManagerName = userRegInfo.PartManagerName;
            _templateuserinfo.PartManagerTel = userRegInfo.PartManagerTel;

            _templateuserinfo.accountid = userRegInfo.AccountId;
            _templateuserinfo.creditintegral = userRegInfo.CreditIntegral;
            _templateuserinfo.creditleavl = new CreditLeavlManager().GetItemByPoint(userRegInfo.CreditIntegral);

            _templateuserinfo.userid = userRegInfo.UserId;

            _templateuserinfo.LoginName = userRegInfo.LoginName;

            _templateuserinfo.regdate = userRegInfo.RegDate;


            if (userRegInfo.IsActivation)
                _templateuserinfo.activation = true;
            else
                _templateuserinfo.activation = false;

            _templateuserinfo.isaudited = userRegInfo.AuditingState == XYECOM.Model.AuditingState.Passed ? true : false;

            _templateuserinfo.Email = userRegInfo.Email;

            if (userRegInfo.IsHasImage)
                _templateuserinfo.LayerPicture = Business.Attachment.GetInfoDefaultImgHref(XYECOM.Model.AttachmentItem.User, _templateuserinfo.userid);
            else
                _templateuserinfo.LayerPicture = SYS_NOIMAGE_PATH;

            XYECOM.Model.UserInfo _UserInfo = new XYECOM.Business.UserInfo().GetItem(userRegInfo.CompanyId);

            if (_UserInfo != null)
            {
                //�ֻ���״̬	IsBoundMobile	bit			FALSE	FALSE	FALSE
                _templateuserinfo.IsBoundMobile = _UserInfo.IsBoundMobile;
                //�����״̬	IsBoundEmail	bit			FALSE	FALSE	FALSE
                _templateuserinfo.IsBoundEmail = _UserInfo.IsBoundEmail;
                //���ۻ���	Point	int			FALSE	FALSE	FALSE
                _templateuserinfo.Point = _UserInfo.Point;
                //�Ƿ�ʵ����֤	IsReal	bit			FALSE	FALSE	FALSE
                _templateuserinfo.IsReal = _UserInfo.IsReal;
                //������	GoodTimes	int			FALSE	FALSE	FALSE
                _templateuserinfo.GoodTimes = _UserInfo.GoodTimes;
                //������	MidTimes	int			FALSE	FALSE	FALSE
                _templateuserinfo.MidTimes = _UserInfo.MidTimes;
                //������	BadTimes	int			FALSE	FALSE	FALSE
                _templateuserinfo.BadTimes = _UserInfo.BadTimes;

                _templateuserinfo.template = userRegInfo.TemplateName;

                if (_templateuserinfo.template.IndexOf("|") != -1)
                    _templateuserinfo.template = _templateuserinfo.template.Split('|')[1];

                _templateuserinfo.cred = userRegInfo.Cred;

                _templateuserinfo.infoperfectpercent = userRegInfo.InFormation;

                _templateuserinfo.maliceerr = userRegInfo.MaliceErr;

                _templateuserinfo.commonerr = userRegInfo.CommonErr;

                _templateuserinfo.LinkMan = _UserInfo.LinkMan.ToString();
                                                
                _templateuserinfo.CompanyName = _UserInfo.Name.ToString();

                _templateuserinfo.Fax = _UserInfo.Fax;

                _templateuserinfo.homepage = _UserInfo.HomePage;

                _templateuserinfo.character = _UserInfo.Character;

                _templateuserinfo.unittypeid = (int)_UserInfo.UserTypeId;

                _templateuserinfo.tradeids = _UserInfo.TradeIds;


                _templateuserinfo.employeetotal = _UserInfo.EmployeeTotal;

                _templateuserinfo.regareaid = _UserInfo.RegAreaId;

                if (_UserInfo.AreaId > 0)
                {
                    Model.AreaInfo areainfo = new Business.Area().GetItem(_UserInfo.AreaId);
                    if (null != areainfo)
                        _templateuserinfo.AreaName = areainfo.FullNameAll;
                }

                _templateuserinfo.Address = _UserInfo.Address;

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
