using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 用户网店顶级域名信息实体类
    /// </summary>
    public class UserDomainInfo
    {
        private long infoId;
        /// <summary>
        /// 信息Id
        /// </summary>
        public long InfoId
        {
            get { return infoId; }
            set { infoId = value; }
        }
        private long userId;
        /// <summary>
        /// 用户id
        /// </summary>
        public long UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private string _ICPInfo;

        /// <summary>
        /// ICP备案号
        /// </summary>
        public string ICPInfo
        {
            get { return _ICPInfo; }
            set { _ICPInfo = value; }
        }

        private string domain;
        /// <summary>
        /// 域名
        /// </summary>
        public string Domain
        {
            get { return domain; }
            set { domain = value; }
        }

        private AuditingState state = AuditingState.Null;
        /// <summary>
        /// 状态(枚举型)
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
        /// 状态(整型)[-1:审核中,0:未通过审核,1:通过审核]
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
