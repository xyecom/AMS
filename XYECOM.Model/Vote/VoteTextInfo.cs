using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 调查文本内容信息
    /// </summary>
    public class VoteTextInfo
    {
        private int textId;
        /// <summary>
        /// 文本Id
        /// </summary>
        public int TextId
        {
            get { return textId; }
            set { textId = value; }
        }
        private string body;
        /// <summary>
        /// 内容
        /// </summary>
        public string Body
        {
            get { return body; }
            set { body = value; }
        }
        private int subjectId;
        /// <summary>
        /// 所属主题id
        /// </summary>
        public int SubjectId
        {
            get { return subjectId; }
            set { subjectId = value; }
        }
    }
}
