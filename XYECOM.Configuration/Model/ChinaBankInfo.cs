using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Configuration
{
    /// <summary>
    /// 网银在线配置信息实体类
    /// </summary>
    public class ChinaBankInfo
    {
        private bool isEnabled;
        private string v_mid;
        private string key;

        public ChinaBankInfo() { }

        public ChinaBankInfo(string v_mid, string key) 
        {
            this.v_mid = v_mid;
            this.key = key;
        }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { isEnabled = value; }
        }

        /// <summary>
        /// 商户Id
        /// </summary>
        public string V_Mid
        {
            get { return v_mid; }
            set { v_mid = value; }
        }

        /// <summary>
        /// 商户密钥
        /// </summary>
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        public override string ToString()
        {
            return this.v_mid;
        }
    }
}
