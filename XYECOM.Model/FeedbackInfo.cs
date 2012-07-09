using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    #region 意见反馈属性类
    /// <summary>
    /// 意见反馈属性类
    /// </summary>

    public class FeedbackInfo
    {
        private long _FeedbackID;
        private int _Type;
        private string _Title;
        private string _Name;
        private string _telephone;
        private string _Email;
        private string _Centent;
        private string _Addtime;
        private int _ComplaintId;
        private int _DefendantId;
        private int _InfoFlag;
        private int _InfoId;
        private int _IsAdminAgree;


        /// <summary>
        /// 投诉者(用户ID)
        /// </summary>
        public int ComplaintId
        {
            get { return _ComplaintId; }
            set { _ComplaintId = value; }
        }
        /// <summary>
        /// 被投诉者(用户ID)
        /// </summary>
        public int DefendantId
        {
            get { return _DefendantId; }
            set { _DefendantId = value; }
        }
        /// <summary>
        /// 信息标识
        /// </summary>
        public int InfoFlag
        {
            get { return _InfoFlag; }
            set { _InfoFlag = value; }
        }
        /// <summary>
        /// 信息编号
        /// </summary>
        public int InfoId
        {
            get { return _InfoId; }
            set { _InfoId = value; }
        }

        /// <summary>
        /// 管理员是否同意投诉
        /// </summary>
        public int IsAdminAgree
        {
            get { return _IsAdminAgree; }
            set { _IsAdminAgree = value; }
        }

        /// <summary>
        /// 反馈ID
        /// </summary>
        public long FeedbackID
        {
            get { return _FeedbackID; }
            set { _FeedbackID = value; }
        }
        
        /// <summary>
        /// 反馈类型
        /// </summary>
        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        /// <summary>
        /// 主题
        /// </summary>
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }
        
        /// <summary>
        /// Email
        /// </summary>
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        
        /// <summary>
        /// 反馈内容
        /// </summary>
        public string Centent
        {
            get { return _Centent; }
            set { _Centent = value; }
        }


        /// <summary>
        /// 添加时间
        /// </summary>
        public string Addtime
        {
            get { return Core.MyConvert.GetDateTime(_Addtime).ToString("yyyy-MM-dd"); }
            set { _Addtime = value; }
        } 

    }


    /// <summary>
    /// 枚举反馈类型
    /// </summary>
    public enum Feedbacktype
    {
        qiuzhu=1,
        jianyi,
        tousu,
        biaoyang,
        yewulianxi
    }


    #endregion
}
