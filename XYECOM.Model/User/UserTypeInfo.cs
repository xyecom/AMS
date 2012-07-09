using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ��ҵ������Ϣʵ����
    /// </summary>
    public class UserTypeInfo
    {
        private System.Int64 _UT_ID;
        private string _UT_Type;
        private System.Int64 _UT_PID;
        private string _UT_FullID;
        private int _UT_InfoCount;

        /// <summary>
        /// ����Id
        /// </summary>
        public System.Int64 UT_ID
        {
            get 
            { return _UT_ID;}
            set
            { _UT_ID = value;}
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string UT_Type
        {
            get { return _UT_Type;}
            set { _UT_Type = value; }
        }

        /// <summary>
        /// ����Id
        /// </summary>
        public System.Int64 UT_PID
        {
            get { return _UT_PID; }
            set { _UT_PID = value; }
        }

        /// <summary>
        /// ��������Id����
        /// </summary>
        public string UT_FullID
        {
            get { return _UT_FullID; }
            set { _UT_FullID = value; }
        }

        /// <summary>
        /// ��������ҵ����ͳ��
        /// </summary>
        public int UT_InfoCount
        {
            get { return _UT_InfoCount; }
            set { _UT_InfoCount = value; }
        }
    }

}
