using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{

    /// <summary>
    /// �û�ע��ҵ����
    /// </summary>
    public class UserReg
    {
        private static readonly XYECOM.SQLServer.UserReg DAL = new XYECOM.SQLServer.UserReg();

        private XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;

        #region ����û�
        /// <summary>
        /// ����û�
        /// </summary>
        /// <param name="eu">ʵ����</param>
        /// <param name="U_ID">����ӵ��û����Զ����</param>
        /// <returns>��Ӱ�������</returns>
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

        #region ��ȡһ����¼
        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="nameOrEmail">�û���/Email</param>
        /// <returns>һ����¼</returns>
        public XYECOM.Model.UserRegInfo GetItem(string nameOrEmailOrAccountId)
        {
            if (String.IsNullOrEmpty(nameOrEmailOrAccountId)
                || nameOrEmailOrAccountId.Equals(""))
                return null;

            return DAL.GetItem(nameOrEmailOrAccountId);
        }

        /// <summary>
        /// ��ȡ�û���Ϣ
        /// </summary>
        /// <param name="nameOrEmail">�û���/Email</param>
        /// <param name="password">����(MD5���ܺ��ַ���)</param>
        /// <returns>ʵ�����</returns>
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
        /// ��ȡ�û���Ϣ
        /// </summary>
        /// <param name="U_ID">�û�Id</param>
        /// <returns></returns>
        public XYECOM.Model.UserRegInfo GetItem(long userId)
        {
            if (userId <= 0) return null;

            return DAL.GetItem(userId);
        }
        #endregion

        #region �޸��û�����
        /// <summary>
        /// �޸��û�����
        /// </summary>
        /// <param name="UserName">�û���</param>
        /// <param name="Password">����</param>
        /// <returns>��Ӱ�������</returns>
        public int UpdatePassWord(long userId, string Password)
        {
            if (userId <= 0 || string.IsNullOrEmpty(Password) || Password.Equals("")) return 0;

            return DAL.UpdatePassWord(userId, Password);
        }
        #endregion

        #region �����û������Ƿ��Ѿ�����
        /// <summary>
        /// �����û������Ƿ��Ѿ�����
        /// </summary>
        /// <returns>true:�Ѿ�ռ�ã�false��δ��ռ��</returns>
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

        #region �����û������Ƿ��Ѿ�����
        /// <summary>
        /// �����û������Ƿ��Ѿ�����
        /// </summary>
        /// <param name="email">�û���������</param>
        /// <returns>true:�Ѿ�ռ�ã�false��δ��ռ��</returns>
        public bool IsExistTheEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || email.Trim().Equals("")) return true;

            if (DAL.IsExistTheEmail(email) > 0) return true;

            return false;
        }
        #endregion

        #region ��Ӽ�����
        /// <summary>
        /// ��Ӽ�����
        /// </summary>
        /// <param name="activationcode">���伤���ַ</param>
        /// <returns>Ӱ������</returns>
        public int UserActivation(string activationcode)
        {
            return DAL.UserActivation(activationcode);
        }
        #endregion

        #region �����û�
        /// <summary>
        /// �����û�
        /// </summary>
        /// <param name="activationcode">���������ַ</param>
        /// <param name="U_ID">�û����Id</param>
        /// <returns>Ӱ������</returns>
        public int AddActivation(string activationcode, long userId)
        {
            return DAL.AddActivation(activationcode, userId);

        }
        #endregion

        #region ���ݼ���������û���Ϣ
        /// <summary>
        /// ���ݼ���������û���Ϣ
        /// </summary>
        /// <param name="activationcode">���伤���ַ</param>
        /// <returns>ʵ�����</returns>
        public XYECOM.Model.UserRegInfo GetUserCode(string activationcode)
        {
            return DAL.GetUserCode(activationcode);
        }
        #endregion

        #region �����û�����
        /// <summary>
        /// �����û�����
        /// </summary>
        /// <param name="userId">�û����Id</param>
        /// <param name="Mark">���ӵ��û�����</param>
        /// <returns>Ӱ������</returns>
        public int UpdateMark(long userId, long Mark)
        {
            if (userId <= 0) return 0;

            return DAL.UpdateMark(userId, Mark);
        }
        #endregion

        #region �޸��û�����ģ������
        /// <summary>
        /// �޸��û�����ģ������
        /// </summary>
        /// <param name="U_ID">�û����</param>
        /// <param name="tempname">ģ������</param>
        public int UpdateTmepName(long userId, string tempname)
        {
            return DAL.UpdateTmepName(userId, tempname);
        }
        #endregion

        #region �޸��Ƽ���Ϣ
        /// <summary>
        /// �޸��Ƽ���Ϣ
        /// </summary>
        /// <param name="eu">ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int UpdateVouch(XYECOM.Model.UserRegInfo eu)
        {
            return DAL.UpdateVouch(eu);
        }
        #endregion

        #region ɾ���û�
        /// <summary>
        /// ɾ���û�
        /// </summary>
        /// <param name="userIds">�û���ż���</param>
        /// <returns>Ӱ������</returns>
        public int Delete(string userIds)
        {
            Business.Attachment attBLL = new Attachment();

            attBLL.Delete(userIds, XYECOM.Model.AttachmentItem.User, XYECOM.Model.UploadFileType.All);

            return DAL.Delete(userIds);
        }
        #endregion

        #region �۳��û��ĳ���ָ��
        /// <summary>
        /// �۳��û��ĳ���ָ��
        /// </summary>
        /// <param name="userId">�û����Id</param>
        /// <param name="Money">�۳��ĳ���ָ��</param>
        /// <returns>Ӱ������</returns>
        public int DeductFaithMongy(long userId, int Money)
        {
            return DAL.DeductFaithMongy(userId, Money);
        }
        #endregion

        #region �����û��ĳ���ָ��
        /// <summary>
        /// ����û��ĳ���ָ��
        /// </summary>
        /// <param name="userId">�û����Id</param>
        /// <param name="Money">����ָ��</param>
        /// <returns>Ӱ������</returns>
        public int AddUserCred(long userId, int Money)
        {
            return DAL.AddUserCred(userId, Money);
        }
        #endregion

        #region ��ͨ���󱻴����Ĵ���
        /// <summary>
        /// ��ͨ���󱻴����Ĵ���
        /// </summary>
        /// <param name="userId">�û����Id</param>
        /// <param name="Money">����</param>
        /// <returns>Ӱ������</returns>
        public int AddUserCommonErr(long userId, int Money)
        {
            return DAL.AddUserCommonErr(userId, Money);
        }
        #endregion

        #region ������󱻴����Ĵ���
        /// <summary>
        /// ������󱻴����Ĵ���
        /// </summary>
        /// <param name="userId">�û����Id</param>
        /// <param name="Money">����</param>
        /// <returns>Ӱ������</returns>
        public int AddUserMaliceErr(long userId, int Money)
        {
            return DAL.AddUserMaliceErr(userId, Money);
        }
        #endregion

        #region �޸��û��������Ƴ̶�
        /// <summary>
        /// �޸��û��������Ƴɶ�
        /// </summary>
        /// <param name="userId">�û����Id</param>
        /// <param name="Consummate">���Ƴ̶�</param>
        /// <returns>Ӱ������</returns>
        public int EditConsumate(long userId, int Consummate)
        {
            return DAL.EditConsumate(userId, Consummate);
        }
        #endregion

        #region ͨ�������һ�����
        /// <summary>
        /// ͨ��������������
        /// </summary>
        /// <param name="email">����</param>
        /// <returns>Ӱ������</returns>
        public int RetakePassWord(string email)
        {
            if (string.IsNullOrEmpty(email) || email.Equals("")) return 0;

            Model.UserRegInfo info = GetItem(email);

            if (info == null) return -1;

            System.Random random = new Random();

            string newPwd = random.Next(100000, 999999).ToString();

            int update = UpdatePassWord(info.UserId, Core.SecurityUtil.MD5(newPwd, XYECOM.Configuration.Security.Instance.Md5value));

            if (update <= 0) return -2;

            string body = "����ע������" + info.LoginName + "<br/>"
                        + "��¼���룺" + newPwd + "<br/><br/>"
                        + "�뼰ʱ��¼ϵͳ�޸�����.<br/><br/><br/>"
                        + "<a href='" + XYECOM.Configuration.WebInfo.Instance.WebDomain + "' target='_blank'>" + XYECOM.Configuration.WebInfo.Instance.WebName + "</a><br/><br/>"
                        + DateTime.Now.ToShortDateString();

            if (!Utils.SendMail(email, "�һ�����", body)) return -3;

            return 1;
        }
        #endregion

        #region ͨ���ش�ȫ������������
        /// <summary>
        /// ͨ���ش�ȫ������������
        /// </summary>
        /// <param name="username">�û���</param>
        /// <param name="question">����</param>
        /// <param name="answer">��</param>
        /// <param name="password">����</param>
        /// <param name="messinfo">���ؽ��</param>
        /// <returns>
        /// -2: ����ʧ��
        /// -1: �����ڴ��û�
        /// 1:  ����ɹ�
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

        #region �����û�����������
        /// <summary>
        /// �����û�����������
        /// </summary>
        /// <returns>���³ɹ�:1</returns>
        public int UpdateUserPerfectPercent(long userId)
        {
            XYECOM.Model.UserInfo userInfo = new UserInfo().GetItem(userId);
            //��ȡ������Ϣ
            XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;

            //�������ƶ�
            int U_InFormation = 0;

            #region ���ƻ�������
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

            #region ����ֻ�����
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

            #region ������ڲ���
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

            #region ��Ӳ�������
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

            #region ���ע���ʱ���Ϣ
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

            #region ���Ӫҵִ��
            int rows = 0;
            rows = XYECOM.Core.Function.GetRows("u_Certificate", "CE_ID", " where  CE_Type=1 and U_ID=" + userId + " and AuditingState = 1");
            if (rows > 0)
            {
                U_InFormation += webInfo.LicencePercent;
            }
            #endregion

            #region �������֤��
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

            //�������Ƴ̶�
            return EditConsumate(userId, U_InFormation);
        }
        #endregion

        #region Update
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="info">ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Update(XYECOM.Model.UserRegInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }
        #endregion

        #region �ж��û��ȼ��Ƿ��ѵ���
        /// <summary>
        /// �ж��û��ȼ��Ƿ��ѵ���
        /// </summary>
        /// <param name="regInfo">�û���</param>
        /// <param name="isSendMsg">������֤����Ƿ�����Ϣ������ʾ</param>
        /// <param name="days">�����ʱ��ļ������</param>
        /// <returns>ʵ�����</returns>
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
                    info.M_Title = "��Ա�Զ������ɹ�";
                    info.M_Content = "�û����Ϊ:" + regInfo.UserId + ",�û���Ϊ:" + regInfo.LoginName + "���û��ȼ��ѵ���,ϵͳ�Զ������ɹ�,�����";
                }
                else if (days.Equals("err") && isSendMsg)
                {
                    info.U_ID = -1;
                    info.UR_ID = -1;
                    info.M_SenderType = "administrator";
                    info.M_Title = "��Ա�Զ�����ʧ��";
                    info.M_Content = "�û����Ϊ:" + regInfo.UserId + ",�û���Ϊ:" + regInfo.LoginName + "���û��ȼ��ѵ���,ϵͳ�Զ�����ʧ��,���ֶ����併��";
                }
                //������Ա������
                msgBLL.Insert(info);

                //���û�������
                if (days.Equals("ok") && isSendMsg)
                {
                    info.UR_ID = regInfo.UserId;
                    info.M_SenderType = "user";
                    info.M_Title = "��Ա�Զ�����֪ͨ";
                    info.M_Content = "���Ļ�Ա�ʸ��ѵ���,ϵͳ�Զ�������";
                    msgBLL.Insert(info);
                }
                return XYECOM.Model.UserGradeState.Degrade;
            }

            if (values[0].Equals("remind") && isSendMsg)
            {
                info.U_ID = -1;
                info.UR_ID = regInfo.UserId;
                info.M_SenderType = "user";
                info.M_Title = "��Ա����֪ͨ";
                info.M_Content = "���Ļ�Ա�ʸ���" + days + "�쵽��,�뼰ʱ���ѻ������Ա��ϵ.";
                msgBLL.Insert(info);

                return XYECOM.Model.UserGradeState.Remind;
            }

            return XYECOM.Model.UserGradeState.Normal;
        }
        #endregion

        #region ���û�ע��
        /// <summary>
        /// ���û�ע��
        /// </summary>
        /// <param name="userRegInfo">�û�ע����Ϣʵ�����</param>
        /// <param name="userInfo">�û�ʵ�����</param>
        /// <param name="individualInfo">�û�������Ϣʵ�����</param>
        /// <param name="userId">�û����Id</param>
        /// <returns>ע������ʵ�����</returns>
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

            #region �û�ע����Ϣ
            userId = 0;
            userRegInfo.AuditingState = Model.AuditingState.Null;
            int _result = new XYECOM.Business.UserReg().Insert(userRegInfo, out userId);

            #endregion

            #region дCookie
            if (_result <= 0)
            {
                return XYECOM.Model.ResisterUserReturnValue.Failed;
            }

            string cookieDomain = XYECOM.Configuration.WebInfo.Instance.CookieDomain;

            XYECOM.Core.Utils.WriteCookie("UserId", userId.ToString(), cookieDomain);
            //�պ����� 12-07-08
            XYECOM.Core.Utils.WriteCookie("U_ID", userId.ToString(), cookieDomain);

            //add by liujia 2008-11-21 ����Cookie��Session���������֤
            XYECOM.Core.Utils.WriteCookie("UserName", userRegInfo.LoginName, cookieDomain);
            XYECOM.Core.Utils.WriteCookie("PassWord", userRegInfo.Password, cookieDomain);

            #endregion

            //�û���˷�ʽ
            if (webInfo.UserRegisterAuditingType)
            {
                new Business.Auditing().UpdatesAuditing(userId, "u_user", XYECOM.Model.AuditingState.Passed);
            }


            #region ���û�������
            //���û�������
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

            #region �����ҵ�û���Ϣ
            userInfo.UserId = userId;
            userInfo.Email = userRegInfo.Email;
            XYECOM.Business.UserInfo userInfoBLL = new XYECOM.Business.UserInfo();

            _result = userInfoBLL.Insert(userInfo);
            #endregion

            #region ���û������û�������֤(��ҵ���ͣ������û����÷���)
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
        /// ע�����û�
        /// </summary>
        /// <param name="userName">�û���¼��</param>
        /// <param name="password">�û�����</param>
        /// <param name="question">�һ���������</param>
        /// <param name="answer">�һ������</param>
        /// <param name="email">����</param>
        /// <param name="userType">�û�����</param>
        /// <param name="unitName">��ҵ���ƣ����Ϊ���ˣ�����Ϊ�գ�</param>
        /// <param name="linkman">��ϵ��</param>
        /// <param name="telephone">�̶��绰</param>
        /// <param name="mobile">�ֻ�</param>
        /// <param name="userId">ע��ɹ������û���ID</param>
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

            #region �û�ע����Ϣ
            XYECOM.Model.UserRegInfo userRegInfo = new XYECOM.Model.UserRegInfo();

            userRegInfo.LoginName = userName;

            userRegInfo.Password = XYECOM.Core.SecurityUtil.MD5(password, XYECOM.Configuration.Security.Instance.Md5value);
            userRegInfo.Answer = answer;
            userRegInfo.Question = question;
            userRegInfo.RegDate = DateTime.Now;
            userRegInfo.Email = email;

            #endregion

            XYECOM.Model.UserInfo userInfo = null;


            #region �����ҵ�û���Ϣ
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
        /// ���û�ע��
        /// </summary>
        /// <param name="userName">�û���¼��</param>
        /// <param name="password">�û�����</param>
        /// <param name="question">�һ���������</param>
        /// <param name="answer">�һ������</param>
        /// <param name="email">����</param>
        /// <param name="userType">�û�����</param>
        /// <returns>ʵ�����</returns>
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
        /// ������֤�룡
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <param name="userRegInfo">ʵ�����</param>
        /// <returns>�Ƿ��ͳɹ�</returns>
        private bool SendActivationCode(long userId, Model.UserRegInfo userRegInfo)
        {
            XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;
            string activationCode = XYECOM.Core.SecurityUtil.MD5(userRegInfo.LoginName, XYECOM.Configuration.Security.Instance.Md5value) + XYECOM.Core.SecurityUtil.MD5(userRegInfo.Email, XYECOM.Configuration.Security.Instance.Md5value);

            bool result = false;
            XYECOM.Business.UserReg ur = new XYECOM.Business.UserReg();
            ur.AddActivation(activationCode, userId);
            string ToEmail = userRegInfo.Email; ;
            string Title = webInfo.WebName + "--ע��ɹ���";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string[] a = new string[] { activationCode, userRegInfo.LoginName, webInfo.WebName, webInfo.WebDomain, webInfo.WebSuffix };
            string[] ac = new string[] { "{$code$}", "{$username$}", "{$WI_Name$}", "{$WI_DomanName$}", "{$WI_Suffix$}" };

            result = XYECOM.Business.Utils.SendMail(ToEmail, Title, XYECOM.Core.TemplateEmail.GetContent(a, ac, "/templateEmail/Register.htm"));

            return result;
        }
        #endregion

        #region �û���¼
        /// <summary>
        /// �û���¼
        /// </summary>
        /// <param name="userName">�û���</param>
        /// <param name="password">����</param>
        /// <param name="isSaveInfo">�Ƿ񱣴���Ϣ</param>
        /// <returns>ʵ�����</returns>
        public Model.UserRegInfo Login(string userName, string password, bool isSaveInfo)
        {
            XYECOM.Model.UserRegInfo userInfo = null;

            userInfo = this.GetItem(userName, XYECOM.Core.SecurityUtil.MD5(password, XYECOM.Configuration.Security.Instance.Md5value));

            if (userInfo == null) return null;


            ip = XYECOM.Core.XYRequest.GetIP();

            //��֤��Ա�ȼ���Ϣ����������֤������ж�����ʾ
            string days = "";
            Model.UserGradeState userGradeState = this.GetUserGradeState(userInfo, true, out days);

            string cookieDomain = XYECOM.Configuration.WebInfo.Instance.CookieDomain;

            XYECOM.Core.Utils.WriteCookie("U_ID", userInfo.UserId.ToString(), cookieDomain);

            //---------------------��Cookie--------------------------------------
            XYECOM.Core.Utils.WriteCookie("UserId", userInfo.UserId.ToString(), cookieDomain);
            //�û�������
            XYECOM.Core.Utils.WriteCookie("UserGradeId", userInfo.GradeId.ToString(), cookieDomain);
            //---------------------------------------------------------------------

            string strUserType = "user";

            if (isSaveInfo)
            {
                XYECOM.Core.Utils.WriteCookie("U_Name", userInfo.LoginName.ToString(), 1, cookieDomain);
                //��Cookie
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

            //��½���ӻ��ֺ�����ң�һ��һ�Σ�
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
                //��¼��������
                if (webInfo.LoginAddScore > 0)
                {
                    this.UpdateMark(userInfo.UserId, webInfo.LoginAddScore);
                }
                //�û���½���ӱ�վ���û��Ľ��
                if (webInfo.LoginAddWebMoney > 0)
                {
                    new XYECOM.Business.UserFictitiouCount().UpdateUserFictitiouCount(userInfo.UserId, webInfo.LoginAddWebMoney);
                }
            }

            //��¼�û���¼
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
