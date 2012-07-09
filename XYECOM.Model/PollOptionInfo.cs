using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 投票选项信息实体类
    /// </summary>
    public class PollOptionInfo
    {
        private int optionId;
        /// <summary>
        /// 选项信息Id
        /// </summary>
        public int OptionId
        {
            get { return optionId; }
            set { optionId = value; }
        }

        private int pollId;
        /// <summary>
        /// 相关联的投票主题Id
        /// </summary>
        public int PollId
        {
            get { return pollId; }
            set { pollId = value; }
        }

        private string option;
        /// <summary>
        /// 选项内容
        /// </summary>
        public string Option
        {
            get { return option; }
            set { option = value; }
        }

        private int total;
        /// <summary>
        /// 投票总数
        /// </summary>
        public int Total
        {
            get { return total; }
            set { total = value; }
        }
    }
}
