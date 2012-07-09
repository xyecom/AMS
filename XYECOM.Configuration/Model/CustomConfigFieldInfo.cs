using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Configuration
{
    /// <summary>
    /// �Զ��������ֶ���Ϣʵ����
    /// </summary>
    public class CustomConfigFieldInfo
    {
        private string key="";
        private string value = "";

        public CustomConfigFieldInfo() { }

        public CustomConfigFieldInfo(string _key, string _value)
        {
            this.key = _key;
            this.value = _value;
        }

        /// <summary>
        /// key
        /// </summary>
        public string Key 
        {
            set { this.key = value; }
            get { return this.key; }
        }

        /// <summary>
        /// value
        /// </summary>
        public string Value
        {
            set { this.value = XYECOM.Core.Utils.HtmlEncode(value); }
            get { return XYECOM.Core.Utils.HtmlDecode(this.value); }
        }
    }
}
