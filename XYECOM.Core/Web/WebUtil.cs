using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Core.Web
{
    /// <summary>
    /// web相关方法公共类
    /// </summary>
    public class WebUtil
    {
        #region 发送邮件相关
        private const string EmailFormat_a = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@(([0-9a-zA-Z])+([-\w]*[0-9a-zA-Z])*\.)+[a-zA-Z]{2,9})$";
        private const string EmailFormat_b = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
        private const string MultipeEmail = @"^(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+([,.](([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+)*$";
        /// <summary>
        ///  检测电子邮件格式的的正则表达式样式
        /// </summary>
        private enum EmailRegexStyle
        {
            /// <summary>
            /// 单一邮件的验证模式a
            /// </summary>
            mail_a = 0x1,
            /// <summary>
            /// 单一邮件的验证模式b
            /// </summary>
            mail_b = 0x2,
            /// <summary>
            /// 多邮件格式,个邮件之间用;分割
            /// </summary>
            multipemail = 0x4
        }

        /// <summary>
        ///  检测是否是标准的邮箱格式
        /// </summary>
        /// <param name="CheckStr">被检测的输入字符串</param>
        /// <returns>返回验证的结果</returns>
        private static bool IsEmailFormat(string CheckStr, EmailRegexStyle MailRegex)
        {
            if (string.IsNullOrEmpty(CheckStr))
            {
                return false;
            }
            else
            {
                string Pattern = EmailFormat_a;

                switch (MailRegex)
                {
                    case EmailRegexStyle.mail_a:
                        break;
                    case EmailRegexStyle.mail_b:
                        Pattern = EmailFormat_b;
                        break;
                    case EmailRegexStyle.multipemail:
                        Pattern = MultipeEmail;
                        break;
                    default:
                        break;
                }
                return System.Text.RegularExpressions.Regex.IsMatch(CheckStr, Pattern);
            }
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="toMails">接收者邮箱列表</param>
        /// <param name="body">邮件主体</param>
        /// <param name="title">标题</param>
        /// <param name="isHtml">内容是否有HTML代码</param>
        /// <param name="item">附件</param>
        /// <param name="mailServerInfo">邮件服务器信息</param>
        /// <returns></returns>
        public static bool SendMail(string toMails, string body, string title, bool isHtml, System.Net.Mail.Attachment attachment, MailServerInfo mailServerInfo)
        {
            if (String.IsNullOrEmpty(toMails) ||
                !IsEmailFormat(toMails, EmailRegexStyle.multipemail) || 
                String.IsNullOrEmpty(body) ||
                String.IsNullOrEmpty(title))
            {
                throw new Exception("邮件发送失败！信息不完整！");
            }

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.From = new System.Net.Mail.MailAddress(mailServerInfo.Email, mailServerInfo.DisplayName, System.Text.Encoding.UTF8);
            mailMessage.To.Add(toMails);
            mailMessage.Subject = title;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = isHtml;

            if (attachment != null)
                mailMessage.Attachments.Add(attachment);

            mailMessage.SubjectEncoding = System.Text.Encoding.Default;
            mailMessage.BodyEncoding = System.Text.Encoding.Default;

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

            client.Host = mailServerInfo.MailServerName;
            client.Port = mailServerInfo.MailServerPort;
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential(mailServerInfo.UserLoginName, mailServerInfo.Password);
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.Send(mailMessage);

            return true;
        }
        #endregion
    }
}
