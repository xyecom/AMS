using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// �û�����ʵ����
    /// </summary>
    public class UserData
    {
        private int _id;
        private Int64 _uid;
        private String companyids;

        /// <summary>
        /// ���
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        /// <summary>
        /// �û�ID
        /// </summary>
        public Int64 Uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        
        /// <summary>
        /// �鿴�û�ID����
        /// </summary>
        public String Companyids
        {
            get { return companyids; }
            set { companyids = value; }
        }
    }
} 
