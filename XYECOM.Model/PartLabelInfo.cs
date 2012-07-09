using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 企业专栏标签信息
    /// </summary>
    public class PartLabelInfo
    {
        private int partId;
        /// <summary>
        /// 专栏Id
        /// </summary>
        public int PartId
        {
            get { return partId; }
            set { partId = value; }
        }

        private string partName;

        /// <summary>
        /// 专栏名称
        /// </summary>
        public string PartName
        {
            get { return partName; }
            set { partName = value; }
        }


        private string labelName;
        /// <summary>
        /// 标签名称
        /// </summary>
        public string LabelName
        {
            get { return labelName; }
            set { labelName = value; }
        }

        private string format;
        /// <summary>
        /// 格式
        /// </summary>
        public string Format
        {
            get { return format; }
            set { format = value; }
        }

        private string body;
        /// <summary>
        /// 标签体
        /// </summary>
        public string Body
        {
            get { return body; }
            set { body = value; }
        }

        private string infoIds;
        /// <summary>
        /// 当前信息Ids
        /// </summary>
        public string InfoIds
        {
            get { return infoIds; }
            set { infoIds = value; }
        }

        private DateTime beginTime;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginTime
        {
            get { return beginTime; }
            set { beginTime = value; }
        }
        private DateTime endTime;
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
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


    }
}
