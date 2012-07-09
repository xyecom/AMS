using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Configuration
{
    /// <summary>
    /// ��Ǯ������Ϣʵ����
    /// </summary>
    public class _99BillInfo
    {
        private bool isEnabled;
        private string merchant_id;
        private string merchant_key;

        public _99BillInfo() { }

        public _99BillInfo(string merchant_id, string merchant_key) 
        {
            this.merchant_id = merchant_id;
            this.merchant_key = merchant_key;
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
        /// �̻����
        /// </summary>
        public string Merchant_Id
        {
            get { return merchant_id; }
            set { merchant_id = value; }
        }

        /// <summary>
        /// �̻���Կ
        /// </summary>
        public string Merchant_Key
        {
            get { return merchant_key; }
            set { merchant_key = value; }
        }

        public override string ToString()
        {
            return this.merchant_id;
        }
    }
}
