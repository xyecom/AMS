using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ��ҵר����ǩ��Ϣ
    /// </summary>
    public class PartLabelInfo
    {
        private int partId;
        /// <summary>
        /// ר��Id
        /// </summary>
        public int PartId
        {
            get { return partId; }
            set { partId = value; }
        }

        private string partName;

        /// <summary>
        /// ר������
        /// </summary>
        public string PartName
        {
            get { return partName; }
            set { partName = value; }
        }


        private string labelName;
        /// <summary>
        /// ��ǩ����
        /// </summary>
        public string LabelName
        {
            get { return labelName; }
            set { labelName = value; }
        }

        private string format;
        /// <summary>
        /// ��ʽ
        /// </summary>
        public string Format
        {
            get { return format; }
            set { format = value; }
        }

        private string body;
        /// <summary>
        /// ��ǩ��
        /// </summary>
        public string Body
        {
            get { return body; }
            set { body = value; }
        }

        private string infoIds;
        /// <summary>
        /// ��ǰ��ϢIds
        /// </summary>
        public string InfoIds
        {
            get { return infoIds; }
            set { infoIds = value; }
        }

        private DateTime beginTime;
        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        public DateTime BeginTime
        {
            get { return beginTime; }
            set { beginTime = value; }
        }
        private DateTime endTime;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
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


    }
}
