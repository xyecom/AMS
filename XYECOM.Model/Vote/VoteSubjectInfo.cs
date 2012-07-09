using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    public enum VoteSubjectType
    {
        /// <summary>
        /// 单行文本框
        /// </summary>
        SingleLineText,
        /// <summary>
        /// 多行文本框
        /// </summary>
        MultilineText,
        /// <summary>
        /// 单选列表
        /// </summary>
        RadioBoxList,
        /// <summary>
        /// 多选列表
        /// </summary>
        CheckBoxList 
    }
    /// <summary>
    /// 投票主题
    /// </summary>
    public class VoteSubjectInfo
    {
        private int subjectId;
        /// <summary>
        /// 主题Id
        /// </summary>
        public int SubjectId
        {
            get { return subjectId; }
            set { subjectId = value; }
        }
        private int voteId;
        /// <summary>
        /// 所属投票Id
        /// </summary>
        public int VoteId
        {
            get { return voteId; }
            set { voteId = value; }
        }
        private string subject;
        /// <summary>
        /// 主题
        /// </summary>
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        private string type;
        /// <summary>
        /// 类型(字符串)
        /// </summary>
        public string StrType
        {
            get { return type; }
            set 
            { 
                type = value;

                if (type.Equals("text")) enumType = VoteSubjectType.SingleLineText;
                if (type.Equals("mtext")) enumType = VoteSubjectType.MultilineText;
                if (type.Equals("select")) enumType = VoteSubjectType.RadioBoxList;
                if (type.Equals("mselect")) enumType = VoteSubjectType.CheckBoxList;
            }
        }

        private VoteSubjectType enumType;

        /// <summary>
        /// 类型(枚举型)
        /// </summary>
        public VoteSubjectType Type
        {
            get 
            {
                return enumType;
            }
            set 
            {
                enumType = value;

                if (enumType == VoteSubjectType.SingleLineText) type = "text";
                if (enumType == VoteSubjectType.MultilineText) type = "mselect";
                if (enumType == VoteSubjectType.RadioBoxList) type = "select";
                if (enumType == VoteSubjectType.CheckBoxList) type = "mselect";
            }
        }
    }
}
