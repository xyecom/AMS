using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 用户登录日志信息实体类
    /// </summary>
    public class UserLoginInfo
    {
        private int _Id;

        /// <summary>
        /// 信息Id
        /// </summary>
        public int Id
        {
            set { _Id = value; }
            get { return _Id; }
        }

        private long  _UserId;
        /// <summary>
        /// 用户编号
        /// </summary>
        public long  UserId
        {
            set { _UserId = value; }
            get { return _UserId; }
        }

        private string _RegIP;
        /// <summary>
        /// 用户注册ＩＰ
        /// </summary>
        public string RegIP
        {
            set { _RegIP = value; }
            get { return _RegIP; }
        }

        private string _LastLoginIP;
        /// <summary>
        /// 最后一次登陆ＩＰ
        /// </summary>
        public string LastLoginIP
        {
            set { _LastLoginIP = value; }
            get { return _LastLoginIP; }
        }

        private string _FirstLoginDate;
        /// <summary>
        /// 第一次登录时间
        /// </summary>
        public string FirstLoginDate
        {
            get { return _FirstLoginDate; }
            set { _FirstLoginDate = value; }
        }

        private int _LoginNum;
        /// <summary>
        /// 登录次数
        /// </summary>
        public int LoginNum
        {
            get { return _LoginNum; }
            set { _LoginNum = value; }
        }

        private string _LastLoginDate;
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public string LastLoginDate
        {
            get { return _LastLoginDate; }
            set { _LastLoginDate = value; }
        }
    }
}
