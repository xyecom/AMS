using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// �����Ϣʵ����
    /// </summary>
    public class AuditingInfo
    {
        private long  _a_id;
        private long  _desctabid;
        private string _desctabname;
        private string _a_reason;
        private string _a_advice;

        public AuditingInfo()
        {
            _a_id = 0;
            _desctabid = 0;
            _desctabname = "";
            _a_reason = "";
            _a_advice = "";
        }

        /// <summary>
        /// ��˱��
        /// </summary>
        public long  A_ID
        {
            set { _a_id = value; }
            get { return _a_id; }
        }
        /// <summary>
        /// Ŀ�����
        /// </summary>
        public long  DescTabID
        {
            set { _desctabid = value; }
            get { return _desctabid; }
        }
        /// <summary>
        /// Ŀ�������
        /// </summary>
        public string DescTabName
        {
            set { _desctabname = value; }
            get { return _desctabname; }
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
    }
}
