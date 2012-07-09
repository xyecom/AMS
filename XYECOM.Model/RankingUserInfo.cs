using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    #region �����Զ�����Ϣ��
    /// <summary>
    /// �����Զ�����Ϣ��
    /// </summary>
    [Serializable]
    public class RankingUserInfo
    {

        private int infoId;
        /// <summary>
        /// ��Ϣ����id
        /// </summary>
        public int InfoId
        {
            get { return infoId; }
            set { infoId = value; }
        }

        private long userId;
        /// <summary>
        /// �û�id
        /// </summary>
        public long UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private int rankingId;
        /// <summary>
        /// ������id
        /// </summary>
        public int RankingId
        {
            get { return rankingId; }
            set { rankingId = value; }
        }

        private string moduleName;
        /// <summary>
        /// ģ���ʾ����
        /// </summary>
        public string ModuleName
        {
            get { return moduleName; }
            set { moduleName = value; }
        }

        private string title;
        /// <summary>
        /// ��Ϣ����
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string desc;
        /// <summary>
        /// ��Ϣ����
        /// </summary>
        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }

        private string link;
        /// <summary>
        /// ��Ϣ����
        /// </summary>
        public string Link
        {
            get { return link; }
            set { link = value; }
        }

        private string imageUrl;
        /// <summary>
        /// ͼƬ����
        /// </summary>
        public string ImageUrl
        {
            get { return imageUrl; }
            set { imageUrl = value; }
        }

        private int isHasImage;
        /// <summary>
        /// �Ƿ����ͼƬ��ָ�ϴ���ͼƬ��
        /// </summary>
        public int IsHasImage
        {
            get { return isHasImage; }
            set { isHasImage = value; }
        }

        private int intAuditingState;
        /// <summary>
        /// ��˵�״̬(Int)
        /// </summary>
        public int IntAuditingState
        {
            get { return intAuditingState; }
            set 
            { 
                intAuditingState = value;

                if (intAuditingState == 0) auditingState = AuditingState.NoPass;
                if (intAuditingState == 1) auditingState = AuditingState.Passed;
            }
        }

        private Model.AuditingState auditingState = AuditingState.Null;
        /// <summary>
        /// ���״̬(Enum)
        /// </summary>
        public Model.AuditingState AuditingState
        {
            get { return auditingState; }
        }

        private int rank;
        /// <summary>
        /// �ؼ��ֵ�����
        /// </summary>
        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }

    }
    #endregion
}
