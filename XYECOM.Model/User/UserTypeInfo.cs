using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 企业分类信息实体类
    /// </summary>
    public class UserTypeInfo
    {
        private System.Int64 _UT_ID;
        private string _UT_Type;
        private System.Int64 _UT_PID;
        private string _UT_FullID;
        private int _UT_InfoCount;

        /// <summary>
        /// 类型Id
        /// </summary>
        public System.Int64 UT_ID
        {
            get 
            { return _UT_ID;}
            set
            { _UT_ID = value;}
        }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string UT_Type
        {
            get { return _UT_Type;}
            set { _UT_Type = value; }
        }

        /// <summary>
        /// 父级Id
        /// </summary>
        public System.Int64 UT_PID
        {
            get { return _UT_PID; }
            set { _UT_PID = value; }
        }

        /// <summary>
        /// 父级分类Id集合
        /// </summary>
        public string UT_FullID
        {
            get { return _UT_FullID; }
            set { _UT_FullID = value; }
        }

        /// <summary>
        /// 分类下企业总数统计
        /// </summary>
        public int UT_InfoCount
        {
            get { return _UT_InfoCount; }
            set { _UT_InfoCount = value; }
        }
    }

}
