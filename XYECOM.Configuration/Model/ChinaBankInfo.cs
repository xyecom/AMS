using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Configuration
{
    /// <summary>
    /// ��������������Ϣʵ����
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
        /// �Ƿ�����
        /// </summary>
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { isEnabled = value; }
        }

        /// <summary>
        /// �̻�Id
        /// </summary>
        public string V_Mid
        {
            get { return v_mid; }
            set { v_mid = value; }
        }

        /// <summary>
        /// �̻���Կ
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
