using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Configuration
{
    /// <summary>
    /// ֧����������Ϣʵ����
    /// </summary>
    public class AlipayInfo
    {
        private bool isEnabled;
        private string service = "";
        private string partner = "";
        private string inputCharset = "gb2312";
        private string email = "";
        private string securityCode = "";

        public AlipayInfo() { }

        #region ����

        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { isEnabled = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Service
        {
            get { return service; }
            set { service = value.Trim(); }
        }

        /// <summary>
        /// ������Id
        /// </summary>
        public string Partner
        {
            get { return partner; }
            set { partner = value.Trim(); }
        }

        /// <summary>
        /// �ַ���
        /// </summary>
        public string InputCharset
        {
            get { return inputCharset; }
            set { inputCharset = value.Trim(); }
        }

        /// <summary>
        /// ֧�����ʺ�
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value.Trim(); }
        }

        /// <summary>
        /// ��ȫУ����
        /// </summary>
        public string SecurityCode
        {
            get { return securityCode; }
            set { securityCode = value.Trim(); }
        }
        #endregion

        public override string ToString()
        {
            return this.email;
        }
    }
}
