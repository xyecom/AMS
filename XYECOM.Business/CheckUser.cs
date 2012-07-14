using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// 设置用户业务类
    /// </summary>
    public class CheckUser
    {
        public static string SYS_NOIMAGE_PATH = "";

        static CheckUser()
        {
            SYS_NOIMAGE_PATH = XYECOM.Configuration.WebInfo.Instance.WebDomain + "Common/Images/DefaultImg.gif";
        }

        #region 用户中心登陆用户的对象
        /// <summary>
        /// 用户中心登陆用户的全局对象
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
                                //用户所在组
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
        /// 获取前台用户登陆状态
        /// </summary>
        /// <returns></returns>
        public static bool CheckUserLogin()
        {
            return UserInfo != null;
        }

        #region 获取设置前台用户信息
        /// <summary>
        /// 获取设置前台用户信息
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>前台用户信息实体对象</returns>
        public static XYECOM.Model.GeneralUserInfo GetUserInfo(long userId)
        {
            XYECOM.Model.UserRegInfo _userInfo = new XYECOM.Business.UserReg().GetItem(userId);

            if (_userInfo == null) return null;

            return GetUserInfo(_userInfo);
        }
        /// <summary>
        /// 获取前台用户对象
        /// </summary>
        /// <param name="userRegInfo">用户实体对象</param>
        /// <returns>用户实体对象</returns>
        public static XYECOM.Model.GeneralUserInfo GetUserInfo(XYECOM.Model.UserRegInfo userRegInfo)
        {
            XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;

            if (userRegInfo == null) return null;
            XYECOM.Model.GeneralUserInfo _templateuserinfo = new XYECOM.Model.GeneralUserInfo();


            _templateuserinfo.CompanyId = userRegInfo.CompanyId;

            _templateuserinfo.IsPrimary = userRegInfo.IsPrimary;
            //部门名称(律师姓名)	LayerName	varchar(50)	50		FALSE	FALSE	FALSE
            _templateuserinfo.LayerName = userRegInfo.LayerName;
            //部门描述	Description	text			FALSE	FALSE	FALSE
            _templateuserinfo.Description = userRegInfo.Description;
            //电话	Telphone	varchar(50)	50		FALSE	FALSE	FALSE
            _templateuserinfo.Telphone = userRegInfo.Telphone;
            //其他联系方式	OtherContact	varchar(200)	200		FALSE	FALSE	FALSE
            _templateuserinfo.OtherContact = userRegInfo.OtherContact;
            //性别0 男 1女	Sex	bit			FALSE	FALSE	FALSE
            _templateuserinfo.Sex = userRegInfo.Sex;
            //身份证	IdNumber	varchar(50)	50		FALSE	FALSE	FALSE
            _templateuserinfo.IdNumber = userRegInfo.IdNumber;
            //律师证	LayerId	varchar(50)	50		FALSE	FALSE	FALSE
            _templateuserinfo.LayerId = userRegInfo.LayerId;
            //所属地区	AreaId	int			FALSE	FALSE	FALSE
            _templateuserinfo.AreaId = userRegInfo.AreaId;
            //是否是认证专家	IsExport	bit			FALSE	FALSE	FALSE
            _templateuserinfo.IsExport = userRegInfo.IsPrimary;
            //企业类型（企业&个人&律师&非律师））	UserType	int			FALSE	FALSE	FALSE
            _templateuserinfo.UserType = (Model.UserType)userRegInfo.UserType;
            //删除状态	DelState	int			FALSE	FALSE	FALSE
            _templateuserinfo.DelState = userRegInfo.DelState;
            //唯一标示	IdentityNumber	varchar(50)	50		FALSE	FALSE	FALSE
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
                //手机绑定状态	IsBoundMobile	bit			FALSE	FALSE	FALSE
                _templateuserinfo.IsBoundMobile = _UserInfo.IsBoundMobile;
                //邮箱绑定状态	IsBoundEmail	bit			FALSE	FALSE	FALSE
                _templateuserinfo.IsBoundEmail = _UserInfo.IsBoundEmail;
                //评价积分	Point	int			FALSE	FALSE	FALSE
                _templateuserinfo.Point = _UserInfo.Point;
                //是否实名认证	IsReal	bit			FALSE	FALSE	FALSE
                _templateuserinfo.IsReal = _UserInfo.IsReal;
                //好评数	GoodTimes	int			FALSE	FALSE	FALSE
                _templateuserinfo.GoodTimes = _UserInfo.GoodTimes;
                //中评数	MidTimes	int			FALSE	FALSE	FALSE
                _templateuserinfo.MidTimes = _UserInfo.MidTimes;
                //差评数	BadTimes	int			FALSE	FALSE	FALSE
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

        #region 后台用户信息
        /// <summary>
        /// 检查后台用户Session状态
        /// </summary>
        /// <returns>Session是否存在</returns>
        public static bool CheckManageSessionState()
        {
            string adminDir = XYECOM.Configuration.WebInfo.Instance.AdminFolder;
            //当Session状态丢失时通过Cookie重新验证
            if (Core.Utils.GetSession("A_Name") == "" || Core.Utils.GetSession("UM_ID") == "")
            {
                if (Core.Utils.GetCookie("AdminId") == ""
                    || Core.Utils.GetCookie("AdminName") == ""
                    || Core.Utils.GetCookie("AdminExpires") == ""
                    || Core.Utils.GetCookie("AdminPwd") == "")
                {
                    return false;
                }

                //获取用户名和ID
                string adminId = Core.Utils.GetCookie("AdminId");
                string adminName = Core.Utils.GetCookie("AdminName");
                string adminPwd = Core.Utils.GetCookie("AdminPwd");
                string adminExpires = Core.Utils.GetCookie("AdminExpires");

                //解密
                adminId = XYECOM.Core.SecurityUtil.AESDecrypt(adminId, XYECOM.Configuration.Security.Instance.AESKey);
                adminName = XYECOM.Core.SecurityUtil.AESDecrypt(adminName, XYECOM.Configuration.Security.Instance.AESKey);
                adminExpires = XYECOM.Core.SecurityUtil.AESDecrypt(adminExpires, XYECOM.Configuration.Security.Instance.AESKey);

                //判断过期时间
                DateTime time = Convert.ToDateTime(adminExpires);
                TimeSpan timeSpan = time - DateTime.Now;

                XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;

                int span = timeSpan.Minutes;
                //如果已经过期
                if (span < 0)
                {
                    Core.Utils.ClearCookie("AdminId", webInfo.CookieDomain);
                    Core.Utils.ClearCookie("AdminName", webInfo.CookieDomain);
                    Core.Utils.ClearCookie("AdminPwd", webInfo.CookieDomain);
                    Core.Utils.ClearCookie("AdminExpires", webInfo.CookieDomain);
                    return false;
                }

                //获取用户名和密码重新验证
                int result = new XYECOM.Business.Admin().isMyUser(adminName, adminPwd);

                if (result <= 0)
                {
                    Core.Utils.ClearCookie("AdminId", webInfo.CookieDomain);
                    Core.Utils.ClearCookie("AdminName", webInfo.CookieDomain);
                    Core.Utils.ClearCookie("AdminPwd", webInfo.CookieDomain);
                    Core.Utils.ClearCookie("AdminExpires", webInfo.CookieDomain);
                    return false;
                }

                //重新设置过期时间，延期20分钟
                Core.Utils.WriteCookie("AdminExpires", XYECOM.Core.SecurityUtil.AESEncrypt(DateTime.Now.AddMinutes(30).ToLongTimeString(), XYECOM.Configuration.Security.Instance.AESKey), webInfo.CookieDomain);

                //重置Session
                Core.Utils.SetSession("A_Name", adminName);
                Core.Utils.SetSession("UM_ID", adminId);
            }
            return true;
        }
        #endregion
    }
}
