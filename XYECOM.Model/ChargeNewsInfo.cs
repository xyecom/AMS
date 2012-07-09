using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 收费新闻收费信息实体类
    /// </summary>
    public class ChargeNewsInfo
    {
        private Int64 _ci_id;
        private Int64 _u_id;
        private Int64 _ns_id;
        private DateTime _ci_addtime;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public ChargeNewsInfo() { }

        /// <summary>
        /// 给定值得构造函数
        /// </summary>
        /// <param name="ciid"></param>
        /// <param name="uid"></param>
        /// <param name="nsid"></param>
        /// <param name="aiaddtime"></param>
        public ChargeNewsInfo(Int64 ciid,Int64 uid,Int64 nsid,DateTime aiaddtime)
        {
            this._ci_id = ciid;
            this._u_id = uid;
            this._ns_id = nsid;
            this._ci_addtime = aiaddtime;
        }

        /// <summary>
        /// 收费信息编号
        /// </summary>
        public Int64 CI_ID
        {
            get { return _ci_id; }
            set { _ci_id = value; }
        }

        /// <summary>
        /// 该信息的使用用户编号
        /// </summary>
        public Int64 U_ID
        {
            get { return _u_id; }
            set { _u_id = value; }
        }

        /// <summary>
        /// 该用户购买新闻的编号
        /// </summary>
        public Int64 NS_ID
        {
            get { return _ns_id; }
            set { _ns_id = value; }
        }

        /// <summary>
        /// 该新闻被购买的时间
        /// </summary>
        public DateTime CI_AddTime
        {
            get { return _ci_addtime; }
        }
    }
}
