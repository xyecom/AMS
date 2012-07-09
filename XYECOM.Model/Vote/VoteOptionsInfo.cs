using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 网上调查问题子选项信息
    /// </summary>
    public class VoteOptionsInfo
    {
        private int optionId;

        /// <summary>
        /// 选项ID
        /// </summary>
        public int OptionId
        {
            get { return optionId; }
            set { optionId = value; }
        }
        private int subjectId;
        /// <summary>
        /// 所属主题Id
        /// </summary>
        public int SubjectId
        {
            get { return subjectId; }
            set { subjectId = value; }
        }
        private string text;
        /// <summary>
        /// 文本
        /// </summary>
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        private int voteTotal;
        /// <summary>
        /// 被投总次数
        /// </summary>
        public int VoteTotal
        {
            get { return voteTotal; }
            set { voteTotal = value; }
        }
    }
}
