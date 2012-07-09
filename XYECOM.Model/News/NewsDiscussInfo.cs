using System;


namespace XYECOM.Model
{
    /// <summary>
    /// 资讯评论信息实体类
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
        /// 默认构造函数
        /// </summary>
        public NewsDiscussInfo() { }
        
        
        /// <summary>
        /// 给定值得类的构造函数
        /// </summary>
        /// <param name="ndid">评论编号</param>
        /// <param name="uid">用户编号</param>
        /// <param name="uname">用户姓名或昵称</param>
        /// <param name="nsid">新闻编号</param>
        /// <param name="ndcontent">评论内容</param>
        /// <param name="ndaddtime">评论时间</param>
        /// <param name="ndisshow">是否显示</param>
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
        /// 评论编号
        /// </summary>
        public Int64 ND_ID
        {
            set { _nd_id = value; }
            get { return _nd_id; }
        }

        /// <summary>
        /// 用户编号
        /// </summary>
        public Int64 U_ID
        {
            set { _u_id = value; }
            get { return _u_id; }
        }
        /// <summary>
        /// 用户名称或昵称
        /// </summary>
        public string U_Name
        {
            set { _u_name = value; }
            get { return _u_name; }
        }

        /// <summary>
        /// 新闻编号
        /// </summary>
        public Int64 NS_ID
        {
            set { _ns_id = value; }
            get { return _ns_id; }
        }

        /// <summary>
        /// 评论内容
        /// </summary>
        public string ND_Content
        {
            set { _nd_content = value; }
            get { return _nd_content; }
        }

        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime ND_AddTime
        {
            set { _nd_addtime = value; }
            get { return _nd_addtime; }
        }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool ND_IsShow
        {
            set { _nd_isshow = value; }
            get { return _nd_isshow; }
        }

        /// <summary>
        /// 评论者的IP地址
        /// </summary>
        public string IpAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }

        /// <summary>
        /// 评论者的IP地址是否显示
        /// </summary>
        public bool IpIsShow
        {
            get { return ipIsShow; }
            set { ipIsShow = value; }
        }
    }
}
