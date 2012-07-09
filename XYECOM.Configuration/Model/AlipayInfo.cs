using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Configuration
{
    /// <summary>
    /// 支付宝配置信息实体类
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

        #region 属性

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { isEnabled = value; }
        }

        /// <summary>
        /// 服务
        /// </summary>
        public string Service
        {
            get { return service; }
            set { service = value.Trim(); }
        }

        /// <summary>
        /// 合作者Id
        /// </summary>
        public string Partner
        {
            get { return partner; }
            set { partner = value.Trim(); }
        }

        /// <summary>
        /// 字符集
        /// </summary>
        public string InputCharset
        {
            get { return inputCharset; }
            set { inputCharset = value.Trim(); }
        }

        /// <summary>
        /// 支付宝帐号
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value.Trim(); }
        }

        /// <summary>
        /// 安全校验码
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
