using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ������Ϣʵ����
    /// </summary>
    public class ServiecInfo : BaseInfo
    {
        public ServiecInfo()
        {
            ModuleFlag = "service";
        }

        private string _a_reason;
        private string _a_advice;
        private long _a_id;        
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        /// δͨ��ԭ��
        /// </summary>
        public string A_Reason
        {
            set { _a_reason = value; }
            get { return _a_reason; }
        }

        /// <summary>
        /// �Ƽ����
        /// </summary>
        public string A_Advice
        {
            set { _a_advice = value; }
            get { return _a_advice; }
        }

        /// <summary>
        /// ��˱��
        /// </summary>
        public long A_ID
        {
            get { return _a_id; }
            set { _a_id = value; }
        }
    }

}