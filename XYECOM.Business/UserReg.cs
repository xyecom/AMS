using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{

    /// <summary>
    /// 用户注册业务类
    /// </summary>
    public class UserReg
    {
        private static readonly XYECOM.SQLServer.UserReg DAL = new XYECOM.SQLServer.UserReg();

        private XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;

        #region 添加用户
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="eu">实体类</param>
        /// <param name="U_ID">所添加的用户的自动编号</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.UserRegInfo info, out long userId)
        {
            if (info == null)
            {
                userId = 0;
                return 0;
            }

            return DAL.Insert(info, out userId);
        }
        #endregion

        #region 获取一条记录
        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="nameOrEmail">用户名/Email</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.UserRegInfo GetItem(string nameOrEmailOrAccountId)
        {
            if (String.IsNullOrEmpty(nameOrEmailOrAccountId)
                || nameOrEmailOrAccountId.Equals(""))
                return null;

            return DAL.GetItem(nameOrEmailOrAccountId);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="nameOrEmail">用户名/Email</param>
        /// <param name="password">密码(MD5加密后字符串)</param>
        /// <returns>实体对象</returns>
        public XYECOM.Model.UserRegInfo GetItem(string nameOrEmail, string password)
        {
            if (String.IsNullOrEmpty(nameOrEmail)
                || String.IsNullOrEmpty(password)
                || nameOrEmail.Equals("")
                || password.Equals(""))
                return null;

            return DAL.GetItem(nameOrEmail, password);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="U_ID">用户Id</param>
        /// <returns></returns>
        public XYECOM.Model.UserRegInfo GetItem(long userId)
        {
            if (userId <= 0) return null;

            return DAL.GetItem(userId);
        }
        #endregion

        #region 修改用户密码
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <returns>受影响的行数</returns>
        public int UpdatePassWord(long userId, string Password)
        {
            if (userId <= 0 || string.IsNullOrEmpty(Password) || Password.Equals("")) return 0;

            return DAL.UpdatePassWord(userId, Password);
        }
        #endregion

        #region 检验用户名称是否已经存在
        /// <summary>
        /// 检验用户名称是否已经存在
        /// </summary>
        /// <returns>true:已经占用，false：未被占用</returns>
        public bool IsExistTheUserName(string UserName)
        {
            if (string.IsNullOrEmpty(UserName) || UserName.Trim().Equals("")) return true;

            if (DAL.IsExistTheUserName(UserName) > 0) return true;

            return false;
        }

        public bool IsExistThePartName(string partName, long companyId)
        {
            if (string.IsNullOrEmpty(partName) || partName.Trim().Equals("")) return true;

            if (DAL.IsExistThePartName(partName, companyId) > 0) return true;

            return false;
        }
        #endregion

        #region 检验用户邮箱是否已经存在
        /// <summary>
        /// 检验用户邮箱是否已经存在
        /// </summary>
        /// <param name="email">用户电子邮箱</param>
        /// <returns>true:已经占用，false：未被占用</returns>
        public bool IsExistTheEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || email.Trim().Equals("")) return true;

            if (DAL.IsExistTheEmail(email) > 0) return true;

            return false;
        }
        #endregion

        #region 添加激活码
        /// <summary>
        /// 添加激活码
        /// </summary>
        /// <param name="activationcode">邮箱激活地址</param>
        /// <returns>影响行数</returns>
        public int UserActivation(string activationcode)
        {
            return DAL.UserActivation(activationcode);
        }
        #endregion

        #region 激活用户
        /// <summary>
        /// 激活用户
        /// </summary>
        /// <param name="activationcode">激活邮箱地址</param>
        /// <param name="U_ID">用户编号Id</param>
        /// <returns>影响行数</returns>
        public int AddActivation(string activationcode, long userId)
        {
            return DAL.AddActivation(activationcode, userId);

        }
        #endregion

        #region 根据激活码查找用户信息
        /// <summary>
        /// 根据激活码查找用户信息
        /// </summary>
        /// <param name="activationcode">邮箱激活地址</param>
        /// <returns>实体对象</returns>
        public XYECOM.Model.UserRegInfo GetUserCode(string activationcode)
        {
            return DAL.GetUserCode(activationcode);
        }
        #endregion

        #region 增加用户积分
        /// <summary>
        /// 增加用户积分
        /// </summary>
        /// <param name="userId">用户编号Id</param>
        /// <param name="Mark">增加的用户积分</param>
        /// <returns>影响行数</returns>
        public int UpdateMark(long userId, long Mark)
        {
            if (userId <= 0) return 0;

            return DAL.UpdateMark(userId, Mark);
        }
        #endregion

        #region 修改用户网店模板名称
        /// <summary>
        /// 修改用户网店模板名称
        /// </summary>
        /// <param name="U_ID">用户编号</param>
        /// <param name="tempname">模板名称</param>
        public int UpdateTmepName(long userId, string tempname)
        {
            return DAL.UpdateTmepName(userId, tempname);
        }
        #endregion

        #region 修改推荐信息
        /// <summary>
        /// 修改推荐信息
        /// </summary>
        /// <param name="eu">实体对象</param>
        /// <returns>影响行数</returns>
        public int UpdateVouch(XYECOM.Model.UserRegInfo eu)
        {
            return DAL.UpdateVouch(eu);
        }
        #endregion

        #region 删除用户
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userIds">用户编号集合</param>
        /// <returns>影响行数</returns>
        public int Delete(string userIds)
        {
            Business.Attachment attBLL = new Attachment();

            attBLL.Delete(userIds, XYECOM.Model.AttachmentItem.User, XYECOM.Model.UploadFileType.All);

            return DAL.Delete(userIds);
        }
        #endregion

        #region 扣除用户的诚信指数
        /// <summary>
        /// 扣除用户的诚信指数
        /// </summary>
        /// <param name="userId">用户编号Id</param>
        /// <param name="Money">扣除的诚信指数</param>
        /// <returns>影响行数</returns>
        public int DeductFaithMongy(long userId, int Money)
        {
            return DAL.DeductFaithMongy(userId, Money);
        }
        #endregion

        #region 增加用户的诚信指数
        /// <summary>
        /// 添加用户的诚信指数
        /// </summary>
        /// <param name="userId">用户编号Id</param>
        /// <param name="Money">诚信指数</param>
        /// <returns>影响行数</returns>
        public int AddUserCred(long userId, int Money)
        {
            return DAL.AddUserCred(userId, Money);
        }
        #endregion

        #region 普通错误被处罚的次数
        /// <summary>
        /// 普通错误被处罚的次数
        /// </summary>
        /// <param name="userId">用户编号Id</param>
        /// <param name="Money">次数</param>
        /// <returns>影响行数</returns>
        public int AddUserCommonErr(long userId, int Money)
        {
            return DAL.AddUserCommonErr(userId, Money);
        }
        #endregion

        #region 恶意错误被处罚的次数
        /// <summary>
        /// 恶意错误被处罚的次数
        /// </summary>
        /// <param name="userId">用户编号Id</param>
        /// <param name="Money">次数</param>
        /// <returns>影响行数</returns>
        public int AddUserMaliceErr(long userId, int Money)
        {
            return DAL.AddUserMaliceErr(userId, Money);
        }
        #endregion

        #region 修改用户资料完善程度
        /// <summary>
        /// 修改用户资料完善成都
        /// </summary>
        /// <param name="userId">用户编号Id</param>
        /// <param name="Consummate">完善程度</param>
        /// <returns>影响行数</returns>
        public int EditConsumate(long userId, int Consummate)
        {
            return DAL.EditConsumate(userId, Consummate);
        }
        #endregion

        #region 通过邮箱找回密码
        /// <summary>
        /// 通过邮箱设置密码
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <returns>影响行数</returns>
        public int RetakePassWord(string email)
        {
            if (string.IsNullOrEmpty(email) || email.Equals("")) return 0;

            Model.UserRegInfo info = GetItem(email);

            if (info == null) return -1;

            System.Random random = new Random();

            string newPwd = random.Next(100000, 999999).ToString();

            int update = UpdatePassWord(info.UserId, Core.SecurityUtil.MD5(newPwd, XYECOM.Configuration.Security.Instance.Md5value));

            if (update <= 0) return -2;

            string body = "您的注册名：" + info.LoginName + "<br/>"
                        + "登录密码：" + newPwd + "<br/><br/>"
                        + "请及时登录系统修改密码.<br/><br/><br/>"
                        + "<a href='" + XYECOM.Configuration.WebInfo.Instance.WebDomain + "' target='_blank'>" + XYECOM.Configuration.WebInfo.Instance.WebName + "</a><br/><br/>"
                        + DateTime.Now.ToShortDateString();

            if (!Utils.SendMail(email, "找回密码", body)) return -3;

            return 1;
        }
        #endregion

        #region 通过回答安全问题重设密码
        /// <summary>
        /// 通过回答安全问题重设密码
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="question">问题</param>
        /// <param name="answer">答案</param>
        /// <param name="password">密码</param>
        /// <param name="messinfo">返回结果</param>
        /// <returns>
        /// -2: 重设失败
        /// -1: 不存在此用户
        /// 1:  重设成功
        /// </returns>
        public int RetakePassWord(string userName, string password, string question, string answer)
        {
            if (String.IsNullOrEmpty(userName)
                || String.IsNullOrEmpty(password)
                || String.IsNullOrEmpty(question)
                || String.IsNullOrEmpty(answer)
                || userName.Equals("")
                || password.Equals("")
                || question.Equals("")
                || answer.Equals(""))
                return -2;

            return DAL.RetakePassWord(userName, password, question, answer);
        }
        #endregion

        #region 更新用户资料完善率
        /// <summary>
        /// 更新用户资料完善率
        /// </summary>
        /// <returns>更新成功:1</returns>
        public int UpdateUserPerfectPercent(long userId)
        {
            XYECOM.Model.UserInfo userInfo = new UserInfo().GetItem(userId);
            //获取设置信息
            XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;

            //资料完善度
            int U_InFormation = 0;

            #region 完善基本资料
            if (userInfo.LinkMan.ToString() != ""
                && userInfo.RegInfo.Email.ToString() != ""
                && userInfo.Telephone.ToString() != ""
                && userInfo.Address.ToString() != ""
                && userInfo.Name.ToString() != ""
                && userInfo.Character.ToString() != ""
                && userInfo.UserTypeId.ToString() != ""
                && userInfo.Post.ToString() != ""
                && userInfo.SupplyOrBuy.ToString() != "")
            {
                if (webInfo.BaseDatumPercent.ToString() != "")
                {
                    int sum = webInfo.BaseDatumPercent + webInfo.RegisterPercent;
                    U_InFormation += sum;
                }
                else
                {
                    U_InFormation += 0;
                }
            }
            #endregion

            #region 添加手机号码
            if (userInfo.Mobile.ToString() != "")
            {
                if (webInfo.MobilePercent.ToString() != "")
                {
                    U_InFormation += webInfo.MobilePercent;
                }
                else
                {
                    U_InFormation += 0;
                }
            }
            #endregion

            #region 添加所在部门
            if (userInfo.Section.ToString() != "")
            {
                if (webInfo.DepartmentPercent.ToString() != "")
                {
                    U_InFormation += webInfo.DepartmentPercent;
                }
                else
                {
                    U_InFormation += 0;
                }
            }
            #endregion

            #region 添加补充资料
            if (userInfo.Name.ToString() != "" && userInfo.Mode.ToString() != "" && userInfo.MoneyType.ToString() != "" && userInfo.RegYear.ToString() != "" && userInfo.Address.ToString() != "" && userInfo.Address.ToString() != "" && userInfo.EmployeeTotal.ToString() != "" && userInfo.MainProduct.ToString() != "" && userInfo.Synopsis.ToString() != "")
            {
                if (webInfo.AdvancedDatumPercent.ToString() != "")
                {
                    U_InFormation += webInfo.AdvancedDatumPercent;
                }
                else
                {
                    U_InFormation += 0;
                }
            }
            #endregion

            #region 添加注册资本信息
            if (userInfo.RegisteredCapital.ToString() != "" && userInfo.MoneyType.ToString() != "")
            {
                if (webInfo.CapitalPercent.ToString() != "")
                {
                    U_InFormation += webInfo.CapitalPercent;
                }
                else
                {
                    U_InFormation += 0;
                }
            }
            #endregion

            #region 添加营业执照
            int rows = 0;
            rows = XYECOM.Core.Function.GetRows("u_Certificate", "CE_ID", " where  CE_Type=1 and U_ID=" + userId + " and AuditingState = 1");
            if (rows > 0)
            {
                U_InFormation += webInfo.LicencePercent;
            }
            #endregion

            #region 添加其他证书
            int trows = 0;
            trows = XYECOM.Core.Function.GetRows("u_Certificate", "CE_ID", " where  CE_Type != 1 and  U_ID=" + userId + " and AuditingState = 1");
            if (trows > 0)
            {
                if (trows < webInfo.CertificatePercent)
                {
                    if (webInfo.CertificatePercent != 0)
                    {
                        U_InFormation += 5 * trows;
                    }
                    else
                    {
                        U_InFormation += 0;
                    }
                }
                else if (trows >= webInfo.CertificatePercent)
                {
                    U_InFormation += webInfo.CertificatePercent * 5;
                }
            }
            else
            {
                U_InFormation += 0;
            }
            #endregion

            //资料完善程度
            return EditConsumate(userId, U_InFormation);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>影响行数</returns>
        public int Update(XYECOM.Model.UserRegInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }
        #endregion

        #region 判断用户等级是否已到期
        /// <summary>
        /// 判断用户等级是否已到期
        /// </summary>
        /// <param name="regInfo">用户名</param>
        /// <param name="isSendMsg">根据验证情况是否发送信息进行提示</param>
        /// <param name="days">离结束时间的间隔天数</param>
        /// <returns>实体对象</returns>
        public Model.UserGradeState GetUserGradeState(Model.UserRegInfo regInfo, bool isSendMsg, out string days)
        {
            if (regInfo == null)
            {
                days = "";
                return XYECOM.Model.UserGradeState.Normal;
            }

            string state = DAL.GetUserGradeState(regInfo.UserId);

            if (String.IsNullOrEmpty(state)
                || state.Equals("")
                || !state.Contains("|"))
            {
                days = "";
                return XYECOM.Model.UserGradeState.Normal;
            }

            string[] values = state.Split('|');

            days = values[1];

            if (values[0].Equals("normal"))
                return XYECOM.Model.UserGradeState.Normal;

            Model.MessageInfo info = new XYECOM.Model.MessageInfo();
            Business.Message msgBLL = new Message();

            if (values[0].Equals("degrade"))
            {
                if (days.Equals("ok") && isSendMsg)
                {
                    info.U_ID = -1;
                    info.UR_ID = -1;
                    info.M_SenderType = "administrator";
                    info.M_Title = "会员自动降级成功";
                    info.M_Content = "用户编号为:" + regInfo.UserId + ",用户名为:" + regInfo.LoginName + "的用户等级已到期,系统自动降级成功,请检验";
                }
                else if (days.Equals("err") && isSendMsg)
                {
                    info.U_ID = -1;
                    info.UR_ID = -1;
                    info.M_SenderType = "administrator";
                    info.M_Title = "会员自动降级失败";
                    info.M_Content = "用户编号为:" + regInfo.UserId + ",用户名为:" + regInfo.LoginName + "的用户等级已到期,系统自动降级失败,请手动对其降级";
                }
                //给管理员发短信
                msgBLL.Insert(info);

                //给用户发短信
                if (days.Equals("ok") && isSendMsg)
                {
                    info.UR_ID = regInfo.UserId;
                    info.M_SenderType = "user";
                    info.M_Title = "会员自动降级通知";
                    info.M_Content = "您的会员资格已到期,系统自动降级！";
                    msgBLL.Insert(info);
                }
                return XYECOM.Model.UserGradeState.Degrade;
            }

            if (values[0].Equals("remind") && isSendMsg)
            {
                info.U_ID = -1;
                info.UR_ID = regInfo.UserId;
                info.M_SenderType = "user";
                info.M_Title = "会员到期通知";
                info.M_Content = "您的会员资格还有" + days + "天到期,请及时续费或与管理员联系.";
                msgBLL.Insert(info);

                return XYECOM.Model.UserGradeState.Remind;
            }

            return XYECOM.Model.UserGradeState.Normal;
        }
        #endregion

        #region 新用户注册
        /// <summary>
        /// 新用户注册
        /// </summary>
        /// <param name="userRegInfo">用户注册信息实体对象</param>
        /// <param name="userInfo">用户实体对象</param>
        /// <param name="individualInfo">用户个人信息实体对象</param>
        /// <param name="userId">用户编号Id</param>
        /// <returns>注册结果类实体对象</returns>
        public Model.ResisterUserReturnValue Register(Model.UserRegInfo userRegInfo, Model.UserInfo userInfo, string sourcePassword, out long userId)
        {
            userId = 0;

            if (!XYECOM.Configuration.WebInfo.Instance.IsRegister)
            {
                return XYECOM.Model.ResisterUserReturnValue.ForbidRegister;
            }

            if (null == userRegInfo)
            {
                return XYECOM.Model.ResisterUserReturnValue.Failed;
            }
            Model.UserType userType = (Model.UserType)userRegInfo.UserType;

            if (null == userInfo)
            {
                return XYECOM.Model.ResisterUserReturnValue.Failed;
            }


            string userName = userRegInfo.LoginName;
            string password = sourcePassword;
            string email = userRegInfo.Email;

            if (string.IsNullOrEmpty(userName) || userName.Trim().Equals("")
                || string.IsNullOrEmpty(password) || password.Trim().Equals("")
                || string.IsNullOrEmpty(email) || email.Trim().Equals(""))
            {
                return XYECOM.Model.ResisterUserReturnValue.Failed;
            }

            if (IsExistTheUserName(userName))
            {
                return XYECOM.Model.ResisterUserReturnValue.UserNameExists;
            }

            if (IsExistTheEmail(email))
            {
                return XYECOM.Model.ResisterUserReturnValue.EmailExists;
            }

            XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;

            if (webInfo.ForbidName != "")
            {
                string[] names = webInfo.ForbidName.Split(',');

                for (int j = 0; j < names.Length; j++)
                {
                    if (userName.Equals(names[j].ToLower()))
                    {
                        return XYECOM.Model.ResisterUserReturnValue.ForbidName;
                    }
                }
            }

            #region 用户注册信息
            userId = 0;
            userRegInfo.AuditingState = Model.AuditingState.Null;
            int _result = new XYECOM.Business.UserReg().Insert(userRegInfo, out userId);

            #endregion

            #region 写Cookie
            if (_result <= 0)
            {
                return XYECOM.Model.ResisterUserReturnValue.Failed;
            }

            string cookieDomain = XYECOM.Configuration.WebInfo.Instance.CookieDomain;

            XYECOM.Core.Utils.WriteCookie("UserId", userId.ToString(), cookieDomain);
            //日后作废 12-07-08
            XYECOM.Core.Utils.WriteCookie("U_ID", userId.ToString(), cookieDomain);

            //add by liujia 2008-11-21 新增Cookie和Session用于身份验证
            XYECOM.Core.Utils.WriteCookie("UserName", userRegInfo.LoginName, cookieDomain);
            XYECOM.Core.Utils.WriteCookie("PassWord", userRegInfo.Password, cookieDomain);

            #endregion

            //用户审核方式
            if (webInfo.UserRegisterAuditingType)
            {
                new Business.Auditing().UpdatesAuditing(userId, "u_user", XYECOM.Model.AuditingState.Passed);
            }


            #region 给用户发留言
            //给用户发留言
            if (webInfo.IsRegisterMessage)
            {
                XYECOM.Model.MessageInfo messageInfo = new XYECOM.Model.MessageInfo();

                messageInfo.M_Email = email;
                messageInfo.M_CompanyName = "";
                messageInfo.M_FHM = "";
                messageInfo.M_Moblie = "";
                messageInfo.M_PHMa = "";
                messageInfo.M_SenderType = "user";
                messageInfo.M_Title = webInfo.RegisterMessageTitle;
                messageInfo.M_Content = webInfo.RegisterMessageContent;
                messageInfo.U_ID = -1;
                messageInfo.UR_ID = userId;
                messageInfo.M_UserName = "";
                messageInfo.M_RecverType = "";
                messageInfo.M_Adress = "";
                new XYECOM.Business.Message().Insert(messageInfo);
            }

            #endregion

            #region 添加企业用户信息
            userInfo.UserId = userId;
            userInfo.Email = userRegInfo.Email;
            XYECOM.Business.UserInfo userInfoBLL = new XYECOM.Business.UserInfo();

            _result = userInfoBLL.Insert(userInfo);
            #endregion

            #region 给用户发送用户邮箱验证(企业发送，个人用户不用发送)
            bool sendMailFlag = true;
            if (webInfo.IsRegisterEmail)
            {
                if (email != "")
                {
                    sendMailFlag = SendActivationCode(userId, userRegInfo);
                }
            }
            #endregion

            //Add Login Log
            string ip = XYECOM.Core.XYRequest.GetIP();
            int i = new Business.UserLogin().Insert(userId, ip, XYECOM.Model.UserLog.Register.ToString());

            if (!sendMailFlag)
                return XYECOM.Model.ResisterUserReturnValue.SendEmailFailed;
            else
                return XYECOM.Model.ResisterUserReturnValue.Success;
        }

        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="userName">用户登录名</param>
        /// <param name="password">用户密码</param>
        /// <param name="question">找回密码问题</param>
        /// <param name="answer">找回密码答案</param>
        /// <param name="email">邮箱</param>
        /// <param name="userType">用户类型</param>
        /// <param name="unitName">企业名称（如果为个人，保持为空）</param>
        /// <param name="linkman">联系人</param>
        /// <param name="telephone">固定电话</param>
        /// <param name="mobile">手机</param>
        /// <param name="userId">注册成功后新用户的ID</param>
        /// <returns></returns>
        public Model.ResisterUserReturnValue Register
            (string userName,
            string password,
            string question,
            string answer,
            string email,
            Model.UserType userType,
            string unitName,
            string linkman,
            string telephone,
            string mobile,
            out long userId)
        {
            userId = 0;

            #region 用户注册信息
            XYECOM.Model.UserRegInfo userRegInfo = new XYECOM.Model.UserRegInfo();

            userRegInfo.LoginName = userName;

            userRegInfo.Password = XYECOM.Core.SecurityUtil.MD5(password, XYECOM.Configuration.Security.Instance.Md5value);
            userRegInfo.Answer = answer;
            userRegInfo.Question = question;
            userRegInfo.RegDate = DateTime.Now;
            userRegInfo.Email = email;

            #endregion

            XYECOM.Model.UserInfo userInfo = null;


            #region 添加企业用户信息
            userInfo = new XYECOM.Model.UserInfo();
            userInfo.Address = "";
            userInfo.Character = "";
            userInfo.HomePage = "";
            userInfo.License = "";
            userInfo.LinkMan = linkman;
            userInfo.Mobile = mobile;
            userInfo.Name = unitName;
            userInfo.EmployeeTotal = "";
            userInfo.Postcode = "";
            userInfo.Synopsis = "";
            userInfo.UserTypeId = 0;
            userInfo.BuyPro = "";
            userInfo.Post = "";
            userInfo.Section = "";
            userInfo.SupplyPro = "";
            userInfo.SupplyOrBuy = 0;
            userInfo.Mode = "";
            userInfo.RegisteredCapital = 0;
            userInfo.RegYear = 0;
            userInfo.Address = "";
            userInfo.Mode = "";
            userInfo.MainProduct = "";
            userInfo.MoneyType = "";
            userInfo.IM = "";
            userInfo.Telephone = telephone;
            userInfo.Fax = "";
            userInfo.TradeIds = "";
            #endregion

            return Register(userRegInfo, userInfo, password, out userId);
        }

        /// <summary>
        /// 新用户注册
        /// </summary>
        /// <param name="userName">用户登录名</param>
        /// <param name="password">用户密码</param>
        /// <param name="question">找回密码问题</param>
        /// <param name="answer">找回密码答案</param>
        /// <param name="email">邮箱</param>
        /// <param name="userType">用户类型</param>
        /// <returns>实体对象</returns>
        public Model.ResisterUserReturnValue Register
            (string userName,
            string password,
            string question,
            string answer,
            string email,
            Model.UserType userType,
            out long userId
            )
        {
            return Register(userName, password, question, answer, email, userType, "", "", "", "", out userId);
        }

        /// <summary>
        /// 发送验证码！
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="userRegInfo">实体对象</param>
        /// <returns>是否发送成功</returns>
        private bool SendActivationCode(long userId, Model.UserRegInfo userRegInfo)
        {
            XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;
            string activationCode = XYECOM.Core.SecurityUtil.MD5(userRegInfo.LoginName, XYECOM.Configuration.Security.Instance.Md5value) + XYECOM.Core.SecurityUtil.MD5(userRegInfo.Email, XYECOM.Configuration.Security.Instance.Md5value);

            bool result = false;
            XYECOM.Business.UserReg ur = new XYECOM.Business.UserReg();
            ur.AddActivation(activationCode, userId);
            string ToEmail = userRegInfo.Email; ;
            string Title = webInfo.WebName + "--注册成功！";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string[] a = new string[] { activationCode, userRegInfo.LoginName, webInfo.WebName, webInfo.WebDomain, webInfo.WebSuffix };
            string[] ac = new string[] { "{$code$}", "{$username$}", "{$WI_Name$}", "{$WI_DomanName$}", "{$WI_Suffix$}" };

            result = XYECOM.Business.Utils.SendMail(ToEmail, Title, XYECOM.Core.TemplateEmail.GetContent(a, ac, "/templateEmail/Register.htm"));

            return result;
        }
        #endregion

        #region 用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="isSaveInfo">是否保存信息</param>
        /// <returns>实体对象</returns>
        public Model.UserRegInfo Login(string userName, string password, bool isSaveInfo)
        {
            XYECOM.Model.UserRegInfo userInfo = null;

            userInfo = this.GetItem(userName, XYECOM.Core.SecurityUtil.MD5(password, XYECOM.Configuration.Security.Instance.Md5value));

            if (userInfo == null) return null;


            ip = XYECOM.Core.XYRequest.GetIP();

            //验证会员等级信息，并根据验证情况进行短信提示
            string days = "";
            Model.UserGradeState userGradeState = this.GetUserGradeState(userInfo, true, out days);

            string cookieDomain = XYECOM.Configuration.WebInfo.Instance.CookieDomain;

            XYECOM.Core.Utils.WriteCookie("U_ID", userInfo.UserId.ToString(), cookieDomain);

            //---------------------新Cookie--------------------------------------
            XYECOM.Core.Utils.WriteCookie("UserId", userInfo.UserId.ToString(), cookieDomain);
            //用户所在组
            XYECOM.Core.Utils.WriteCookie("UserGradeId", userInfo.GradeId.ToString(), cookieDomain);
            //---------------------------------------------------------------------

            string strUserType = "user";

            if (isSaveInfo)
            {
                XYECOM.Core.Utils.WriteCookie("U_Name", userInfo.LoginName.ToString(), 1, cookieDomain);
                //新Cookie
                XYECOM.Core.Utils.WriteCookie("UserName", userInfo.LoginName.ToString(), 1, cookieDomain);
                XYECOM.Core.Utils.WriteCookie("PassWord", userInfo.Password, 1, cookieDomain);
                XYECOM.Core.Utils.WriteCookie("UserType", strUserType, 1, cookieDomain);

            }
            else
            {
                XYECOM.Core.Utils.WriteCookie("U_Name", userInfo.LoginName.ToString(), cookieDomain);
                XYECOM.Core.Utils.WriteCookie("UserName", userInfo.LoginName.ToString(), cookieDomain);
                XYECOM.Core.Utils.WriteCookie("PassWord", userInfo.Password, cookieDomain);
                XYECOM.Core.Utils.WriteCookie("UserType", strUserType, cookieDomain);
            }

            System.Threading.Thread t1 = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(AfterLogin));
            t1.Start(userInfo);

            return userInfo;
        }

        private string ip = string.Empty;

        private void AfterLogin(object uinfo)
        {
            Model.UserRegInfo userInfo = null;

            if (uinfo is XYECOM.Model.UserRegInfo)
            {
                userInfo = uinfo as Model.UserRegInfo;
            }
            if (userInfo == null)
            {
                return;
            }
            XYECOM.Business.UserLogin userLoginBLL = new XYECOM.Business.UserLogin();

            DataTable loginInfo = userLoginBLL.GetDataTable(userInfo.UserId);

            //登陆增加积分和虚拟币（一天一次）
            int daySpan = -1;
            if (loginInfo.Rows.Count > 0)
            {
                if (loginInfo.Rows[0]["LastLoginDate"].ToString() != "")
                {
                    TimeSpan timeSpan = DateTime.Now - Convert.ToDateTime(loginInfo.Rows[0]["LastLoginDate"].ToString());
                    daySpan = timeSpan.Days;
                }
            }

            if (daySpan == -1 || daySpan >= 1)
            {
                //登录奖励积分
                if (webInfo.LoginAddScore > 0)
                {
                    this.UpdateMark(userInfo.UserId, webInfo.LoginAddScore);
                }
                //用户登陆增加本站给用户的金额
                if (webInfo.LoginAddWebMoney > 0)
                {
                    new XYECOM.Business.UserFictitiouCount().UpdateUserFictitiouCount(userInfo.UserId, webInfo.LoginAddWebMoney);
                }
            }

            //记录用户登录
            userLoginBLL.Insert(userInfo.UserId, ip, XYECOM.Model.UserLog.Login.ToString());
        }
        #endregion

        public int UpdatePartInfo(XYECOM.Model.UserRegInfo userRegInfo)
        {
            return DAL.UpdatePartInfo(userRegInfo);
        }

        public Model.ResisterUserReturnValue AddPart(Model.UserRegInfo regInfo)
        {
            if (IsExistTheUserName(regInfo.LoginName))
            {
                return XYECOM.Model.ResisterUserReturnValue.UserNameExists;
            }
            if (IsExistThePartName(regInfo.LayerName, regInfo.CompanyId))
            {
                return XYECOM.Model.ResisterUserReturnValue.PartNameExists;
            }
            if (IsExistTheEmail(regInfo.Email))
            {
                return XYECOM.Model.ResisterUserReturnValue.EmailExists;
            }


            XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;

            if (webInfo.ForbidName != "")
            {
                string[] names = webInfo.ForbidName.Split(',');

                for (int j = 0; j < names.Length; j++)
                {
                    if (regInfo.LoginName.Equals(names[j].ToLower()))
                    {
                        return XYECOM.Model.ResisterUserReturnValue.ForbidName;
                    }
                }
            }

            int result = DAL.AddPart(regInfo);

            if (result < 1)
            {
                return Model.ResisterUserReturnValue.Failed;
            }

            return Model.ResisterUserReturnValue.Success;
        }

        public DataTable GetPartList(long companyId)
        {
            return DAL.GetPartList(companyId);
        }

        public int UpdatePartState(string userId, string stateId)
        {
            return DAL.UpdatePartState(userId, stateId);
        }

        public int SetQuestAndAnswer(long userId, string question, string answer)
        {
            return DAL.SetQuestAndAnswer(userId, question, answer);
        }
    }
}
