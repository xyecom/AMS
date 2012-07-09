using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    #region 排名自定义信息类
    /// <summary>
    /// 排名自定义信息类
    /// </summary>
    [Serializable]
    public class RankingUserInfo
    {

        private int infoId;
        /// <summary>
        /// 信息主键id
        /// </summary>
        public int InfoId
        {
            get { return infoId; }
            set { infoId = value; }
        }

        private long userId;
        /// <summary>
        /// 用户id
        /// </summary>
        public long UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private int rankingId;
        /// <summary>
        /// 排名的id
        /// </summary>
        public int RankingId
        {
            get { return rankingId; }
            set { rankingId = value; }
        }

        private string moduleName;
        /// <summary>
        /// 模块标示名称
        /// </summary>
        public string ModuleName
        {
            get { return moduleName; }
            set { moduleName = value; }
        }

        private string title;
        /// <summary>
        /// 信息标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string desc;
        /// <summary>
        /// 信息描述
        /// </summary>
        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }

        private string link;
        /// <summary>
        /// 信息链接
        /// </summary>
        public string Link
        {
            get { return link; }
            set { link = value; }
        }

        private string imageUrl;
        /// <summary>
        /// 图片链接
        /// </summary>
        public string ImageUrl
        {
            get { return imageUrl; }
            set { imageUrl = value; }
        }

        private int isHasImage;
        /// <summary>
        /// 是否包含图片（指上传的图片）
        /// </summary>
        public int IsHasImage
        {
            get { return isHasImage; }
            set { isHasImage = value; }
        }

        private int intAuditingState;
        /// <summary>
        /// 审核的状态(Int)
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
        /// 审核状态(Enum)
        /// </summary>
        public Model.AuditingState AuditingState
        {
            get { return auditingState; }
        }

        private int rank;
        /// <summary>
        /// 关键字的排名
        /// </summary>
        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }

    }
    #endregion
}
