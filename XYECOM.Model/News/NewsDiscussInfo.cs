using System;


namespace XYECOM.Model
{
    /// <summary>
    /// ��Ѷ������Ϣʵ����
    /// </summary>
    public class NewsDiscussInfo
    {
        private Int64 _nd_id;
        private Int64 _u_id;
        private string _u_name;
        private Int64 _ns_id;
        private string _nd_content;
        private DateTime _nd_addtime;
        private bool _nd_isshow;
        private string ipAddress;
        private bool ipIsShow;

        

        /// <summary>
        /// Ĭ�Ϲ��캯��
        /// </summary>
        public NewsDiscussInfo() { }
        
        
        /// <summary>
        /// ����ֵ����Ĺ��캯��
        /// </summary>
        /// <param name="ndid">���۱��</param>
        /// <param name="uid">�û����</param>
        /// <param name="uname">�û��������ǳ�</param>
        /// <param name="nsid">���ű��</param>
        /// <param name="ndcontent">��������</param>
        /// <param name="ndaddtime">����ʱ��</param>
        /// <param name="ndisshow">�Ƿ���ʾ</param>
        public NewsDiscussInfo(Int64 ndid, Int64 uid, string uname, Int64 nsid, string ndcontent, DateTime ndaddtime, bool ndisshow,string ipaddress,bool ipisshow)
        {
            this._nd_id = ndid;
            this._u_id = uid;
            this._u_name = uname;
            this._ns_id = nsid;
            this._nd_content = ndcontent;
            this._nd_addtime = ndaddtime;
            this._nd_isshow = ndisshow;
            this.IpAddress = ipaddress;
            this.ipIsShow = ipisshow;
        }

        /// <summary>
        /// ���۱��
        /// </summary>
        public Int64 ND_ID
        {
            set { _nd_id = value; }
            get { return _nd_id; }
        }

        /// <summary>
        /// �û����
        /// </summary>
        public Int64 U_ID
        {
            set { _u_id = value; }
            get { return _u_id; }
        }
        /// <summary>
        /// �û����ƻ��ǳ�
        /// </summary>
        public string U_Name
        {
            set { _u_name = value; }
            get { return _u_name; }
        }

        /// <summary>
        /// ���ű��
        /// </summary>
        public Int64 NS_ID
        {
            set { _ns_id = value; }
            get { return _ns_id; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string ND_Content
        {
            set { _nd_content = value; }
            get { return _nd_content; }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime ND_AddTime
        {
            set { _nd_addtime = value; }
            get { return _nd_addtime; }
        }

        /// <summary>
        /// �Ƿ���ʾ
        /// </summary>
        public bool ND_IsShow
        {
            set { _nd_isshow = value; }
            get { return _nd_isshow; }
        }

        /// <summary>
        /// �����ߵ�IP��ַ
        /// </summary>
        public string IpAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }

        /// <summary>
        /// �����ߵ�IP��ַ�Ƿ���ʾ
        /// </summary>
        public bool IpIsShow
        {
            get { return ipIsShow; }
            set { ipIsShow = value; }
        }
    }
}
