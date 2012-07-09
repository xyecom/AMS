using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Configuration
{
    /// <summary>
    /// IM ������Ϣʵ����
    /// </summary>
    public class IMInfo
    {
        private string name;
        private bool isEnabled;
        private string code;

        /// <summary>
        /// IM ����
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// IM �Ƿ�����
        /// </summary>
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { isEnabled = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Code
        {
            get 
            {
                if (code == null) return "";

                return System.Web.HttpContext.Current.Server.HtmlDecode(code.Replace("\r\n", "")); 
            }
            set 
            {
                code = System.Web.HttpContext.Current.Server.HtmlEncode(value);
            }
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
