using System;
using System.Collections.Generic;
using System.Text;


namespace XYECOM.Model
{
    /// <summary>
    /// 岗位信息实体类
    /// </summary>
    public class PostInfo
    {
        private int _P_ID;
        private string _P_Name;
        private int _P_ParentID;
        private string _FullId;
        private int _InfoCount;

        public PostInfo()
        {
        }

        public int P_ID
        {
            set { _P_ID = value; }
            get { return _P_ID; }
        }

        public string P_Name
        {
            set { _P_Name = value; }
            get { return _P_Name; }
        }
        public int P_ParentID
        {
            set { _P_ParentID = value; }
            get { return _P_ParentID; }
        }

        /// <summary>
        /// 完整父级Id集合
        /// </summary>
        public string FullId
        {
            get { return _FullId; }
            set { _FullId = value; }
        }

        /// <summary>
        /// 信息总和
        /// </summary>
        public int InfoCount
        {
            get { return _InfoCount; }
            set { _InfoCount = value; }
        }
    }
}
