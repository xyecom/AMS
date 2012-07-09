using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// �û����궥��������Ϣʵ����
    /// </summary>
    public class UserDomainInfo
    {
        private long infoId;
        /// <summary>
        /// ��ϢId
        /// </summary>
        public long InfoId
        {
            get { return infoId; }
            set { infoId = value; }
        }
        private long userId;
        /// <summary>
        /// �û�id
        /// </summary>
        public long UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private string _ICPInfo;

        /// <summary>
        /// ICP������
        /// </summary>
        public string ICPInfo
        {
            get { return _ICPInfo; }
            set { _ICPInfo = value; }
        }

        private string domain;
        /// <summary>
        /// ����
        /// </summary>
        public string Domain
        {
            get { return domain; }
            set { domain = value; }
        }

        private AuditingState state = AuditingState.Null;
        /// <summary>
        /// ״̬(ö����)
        /// </summary>
        public AuditingState State
        {
            get { return state; }
            set 
            { 
                state = value;

                if (state == AuditingState.Null) intState = -1;
                if (state == AuditingState.NoPass) intState = 0;
                if (state == AuditingState.Passed) intState = 1;
            }
        }

        private short intState;
        /// <summary>
        /// ״̬(����)[-1:�����,0:δͨ�����,1:ͨ�����]
        /// </summary>
        public short IntState
        {
            get { return intState; }
            set 
            {
                intState = value;

                if (intState == -1) state = AuditingState.Null;
                if (intState == 0) state = AuditingState.NoPass;
                if (intState == 1) state = AuditingState.Passed;
            }
        }



        public override string ToString()
        {
            return domain;
        }

    }
}
