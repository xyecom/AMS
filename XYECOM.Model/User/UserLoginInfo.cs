using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// �û���¼��־��Ϣʵ����
    /// </summary>
    public class UserLoginInfo
    {
        private int _Id;

        /// <summary>
        /// ��ϢId
        /// </summary>
        public int Id
        {
            set { _Id = value; }
            get { return _Id; }
        }

        private long  _UserId;
        /// <summary>
        /// �û����
        /// </summary>
        public long  UserId
        {
            set { _UserId = value; }
            get { return _UserId; }
        }

        private string _RegIP;
        /// <summary>
        /// �û�ע��ɣ�
        /// </summary>
        public string RegIP
        {
            set { _RegIP = value; }
            get { return _RegIP; }
        }

        private string _LastLoginIP;
        /// <summary>
        /// ���һ�ε�½�ɣ�
        /// </summary>
        public string LastLoginIP
        {
            set { _LastLoginIP = value; }
            get { return _LastLoginIP; }
        }

        private string _FirstLoginDate;
        /// <summary>
        /// ��һ�ε�¼ʱ��
        /// </summary>
        public string FirstLoginDate
        {
            get { return _FirstLoginDate; }
            set { _FirstLoginDate = value; }
        }

        private int _LoginNum;
        /// <summary>
        /// ��¼����
        /// </summary>
        public int LoginNum
        {
            get { return _LoginNum; }
            set { _LoginNum = value; }
        }

        private string _LastLoginDate;
        /// <summary>
        /// ����¼ʱ��
        /// </summary>
        public string LastLoginDate
        {
            get { return _LastLoginDate; }
            set { _LastLoginDate = value; }
        }
    }
}
