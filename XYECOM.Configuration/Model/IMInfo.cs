using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Configuration
{
    /// <summary>
    /// IM 工具信息实体类
    /// </summary>
    public class IMInfo
    {
        private string name;
        private bool isEnabled;
        private string code;

        /// <summary>
        /// IM 名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// IM 是否启用
        /// </summary>
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { isEnabled = value; }
        }

        /// <summary>
        /// 代码
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
