using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 投票信息实体类
    /// </summary>
    public class PollInfo
    {
        private int pollId;
        /// <summary>
        /// 信息Id
        /// </summary>
        public int PollId
        {
            get { return pollId; }
            set { pollId = value; }
        }

        private string labelName;
        /// <summary>
        /// 调用标签名称
        /// </summary>
        public string LabelName
        {
            get { return labelName; }
            set { labelName = value; }
        }

        private string title;
        /// <summary>
        /// 投票标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private Model.PollMode mode;
        /// <summary>
        /// 投票选项模式
        /// </summary>
        public Model.PollMode Mode
        {
            get { return mode; }
            set { mode = value; }
        }
    }
}
