using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ͶƱѡ����Ϣʵ����
    /// </summary>
    public class PollOptionInfo
    {
        private int optionId;
        /// <summary>
        /// ѡ����ϢId
        /// </summary>
        public int OptionId
        {
            get { return optionId; }
            set { optionId = value; }
        }

        private int pollId;
        /// <summary>
        /// �������ͶƱ����Id
        /// </summary>
        public int PollId
        {
            get { return pollId; }
            set { pollId = value; }
        }

        private string option;
        /// <summary>
        /// ѡ������
        /// </summary>
        public string Option
        {
            get { return option; }
            set { option = value; }
        }

        private int total;
        /// <summary>
        /// ͶƱ����
        /// </summary>
        public int Total
        {
            get { return total; }
            set { total = value; }
        }
    }
}
