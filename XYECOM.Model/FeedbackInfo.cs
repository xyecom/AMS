using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    #region �������������
    /// <summary>
    /// �������������
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
        /// Ͷ����(�û�ID)
        /// </summary>
        public int ComplaintId
        {
            get { return _ComplaintId; }
            set { _ComplaintId = value; }
        }
        /// <summary>
        /// ��Ͷ����(�û�ID)
        /// </summary>
        public int DefendantId
        {
            get { return _DefendantId; }
            set { _DefendantId = value; }
        }
        /// <summary>
        /// ��Ϣ��ʶ
        /// </summary>
        public int InfoFlag
        {
            get { return _InfoFlag; }
            set { _InfoFlag = value; }
        }
        /// <summary>
        /// ��Ϣ���
        /// </summary>
        public int InfoId
        {
            get { return _InfoId; }
            set { _InfoId = value; }
        }

        /// <summary>
        /// ����Ա�Ƿ�ͬ��Ͷ��
        /// </summary>
        public int IsAdminAgree
        {
            get { return _IsAdminAgree; }
            set { _IsAdminAgree = value; }
        }

        /// <summary>
        /// ����ID
        /// </summary>
        public long FeedbackID
        {
            get { return _FeedbackID; }
            set { _FeedbackID = value; }
        }
        
        /// <summary>
        /// ��������
        /// </summary>
        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        
        /// <summary>
        /// ����
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        
        /// <summary>
        /// ��ϵ�绰
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
        /// ��������
        /// </summary>
        public string Centent
        {
            get { return _Centent; }
            set { _Centent = value; }
        }


        /// <summary>
        /// ���ʱ��
        /// </summary>
        public string Addtime
        {
            get { return Core.MyConvert.GetDateTime(_Addtime).ToString("yyyy-MM-dd"); }
            set { _Addtime = value; }
        } 

    }


    /// <summary>
    /// ö�ٷ�������
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
