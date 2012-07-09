namespace XYECOM.Plugin.DZ
{
    using System;
    using System.Data;

    /// <summary>
    /// 用户信息实体类
    /// </summary>
    internal class UserInfo
    {
        private string userName = string.Empty;     //用户名
        private string nickName = string.Empty;     //昵称
        private string password = string.Empty;     //密码
       // private int gender;                         //性别
       // private DateTime joindate;                  //注册日期
        private string invisible = string.Empty;    //是否隐身
        private string pmsound = string.Empty;      //短消息铃声
        private string ppp = string.Empty;          //每页贴数
        private string sigstatus = string.Empty;    //签名
        private string tpp = string.Empty;          //每页主题数
        private string uid = string.Empty;          //用户UID编号
        private int templateId;

        internal UserInfo()
        {
        }

        internal string Invisible
        {
            get
            {
                return this.invisible;
            }
            set
            {
                invisible = value;
            }
        }

        internal string Pmsound
        {
            get
            {
                return this.pmsound;
            }
            set
            {
                pmsound = value;
            }
        }

        internal string Ppp
        {
            get
            {
                return this.ppp;
            }
            set
            {
                ppp = value;
            }
        }

        internal string Sigstatus
        {
            get
            {
                return this.sigstatus;
            }
            set
            {
                sigstatus = value;
            }
        }

        internal string Tpp
        {
            get
            {
                return this.tpp;
            }
            set
            {
                tpp = value;
            }
        }

        internal string Uid
        {
            get
            {
                return this.uid;
            }
            set
            {
                this.uid = value;
            }
        }

        public int TemplateId
        {
            get { return templateId; }
            set { templateId = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}

