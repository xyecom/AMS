using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Core.Web
{
    /// <summary>
    /// ��վ�ʼ���������Ϣʵ����
    /// </summary>
    public class MailServerInfo
    {
        private string email;
        private string userLoginName;
        private string password;
        private string displayName;
        private string mailServerName;
        private int mailServerPort;

        /// <summary>
        /// ����ʹ������
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// ��¼�û���
        /// </summary>
        public string UserLoginName
        {
            get { return userLoginName; }
            set { userLoginName = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// ��ʾ����
        /// </summary>
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        /// <summary>
        /// �ʼ�����������
        /// </summary>
        public string MailServerName
        {
            get { return mailServerName; }
            set { mailServerName = value; }
        }

        /// <summary>
        /// smtp�������˿�
        /// </summary>
        public int MailServerPort
        {
            get { return mailServerPort; }
            set { mailServerPort = value; }
        }
    }
}
