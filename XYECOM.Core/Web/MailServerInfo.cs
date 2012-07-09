using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Core.Web
{
    /// <summary>
    /// 网站邮件服务器信息实体类
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
        /// 发送使用邮箱
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// 登录用户名
        /// </summary>
        public string UserLoginName
        {
            get { return userLoginName; }
            set { userLoginName = value; }
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        /// <summary>
        /// 邮件服务器名称
        /// </summary>
        public string MailServerName
        {
            get { return mailServerName; }
            set { mailServerName = value; }
        }

        /// <summary>
        /// smtp服务器端口
        /// </summary>
        public int MailServerPort
        {
            get { return mailServerPort; }
            set { mailServerPort = value; }
        }
    }
}
