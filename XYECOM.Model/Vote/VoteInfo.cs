using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 网上调查虚信息
    /// </summary>
    public class VoteInfo
    {
        private int voteId;
        /// <summary>
        /// 信息Id
        /// </summary>
        public int VoteId
        {
            get { return voteId; }
            set { voteId = value; }
        }
        private string title;
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string desc;

        /// <summary>
        /// 描述
        /// </summary>
        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }
        private string userType;
        /// <summary>
        /// 可参与用户类型(all:所有用户,user:仅会员)
        /// </summary>
        public string UserType
        {
            get { return userType; }
            set { userType = value; }
        }

        private DateTime startTime;

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
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
    }
}
