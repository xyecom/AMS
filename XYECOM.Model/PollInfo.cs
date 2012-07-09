using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ͶƱ��Ϣʵ����
    /// </summary>
    public class PollInfo
    {
        private int pollId;
        /// <summary>
        /// ��ϢId
        /// </summary>
        public int PollId
        {
            get { return pollId; }
            set { pollId = value; }
        }

        private string labelName;
        /// <summary>
        /// ���ñ�ǩ����
        /// </summary>
        public string LabelName
        {
            get { return labelName; }
            set { labelName = value; }
        }

        private string title;
        /// <summary>
        /// ͶƱ����
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private Model.PollMode mode;
        /// <summary>
        /// ͶƱѡ��ģʽ
        /// </summary>
        public Model.PollMode Mode
        {
            get { return mode; }
            set { mode = value; }
        }
    }
}
