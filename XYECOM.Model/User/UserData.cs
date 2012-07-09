using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 用户数据实体类
    /// </summary>
    public class UserData
    {
        private int _id;
        private Int64 _uid;
        private String companyids;

        /// <summary>
        /// 编号
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        /// <summary>
        /// 用户ID
        /// </summary>
        public Int64 Uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        
        /// <summary>
        /// 查看用户ID集合
        /// </summary>
        public String Companyids
        {
            get { return companyids; }
            set { companyids = value; }
        }
    }
} 
