using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Core.Web
{
    /// <summary>
    /// web��ط���������
    /// </summary>
    public class WebUtil
    {
        #region �����ʼ����
        private const string EmailFormat_a = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@(([0-9a-zA-Z])+([-\w]*[0-9a-zA-Z])*\.)+[a-zA-Z]{2,9})$";
        private const string EmailFormat_b = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
        private const string MultipeEmail = @"^(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+([,.](([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+)*$";
        /// <summary>
        ///  �������ʼ���ʽ�ĵ�������ʽ��ʽ
        /// </summary>
        private enum EmailRegexStyle
        {
            /// <summary>
            /// ��һ�ʼ�����֤ģʽa
            /// </summary>
            mail_a = 0x1,
            /// <summary>
            /// ��һ�ʼ�����֤ģʽb
            /// </summary>
            mail_b = 0x2,
            /// <summary>
            /// ���ʼ���ʽ,���ʼ�֮����;�ָ�
            /// </summary>
            multipemail = 0x4
        }

        /// <summary>
        ///  ����Ƿ��Ǳ�׼�������ʽ
        /// </summary>
        /// <param name="CheckStr">�����������ַ���</param>
        /// <returns>������֤�Ľ��</returns>
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
        /// �����ʼ�
        /// </summary>
        /// <param name="toMails">�����������б�</param>
        /// <param name="body">�ʼ�����</param>
        /// <param name="title">����</param>
        /// <param name="isHtml">�����Ƿ���HTML����</param>
        /// <param name="item">����</param>
        /// <param name="mailServerInfo">�ʼ���������Ϣ</param>
        /// <returns></returns>
        public static bool SendMail(string toMails, string body, string title, bool isHtml, System.Net.Mail.Attachment attachment, MailServerInfo mailServerInfo)
        {
            if (String.IsNullOrEmpty(toMails) ||
                !IsEmailFormat(toMails, EmailRegexStyle.multipemail) || 
                String.IsNullOrEmpty(body) ||
                String.IsNullOrEmpty(title))
            {
                throw new Exception("�ʼ�����ʧ�ܣ���Ϣ��������");
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
