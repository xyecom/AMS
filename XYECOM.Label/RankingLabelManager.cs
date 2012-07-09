using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    public class RankingLabelManager : ContentLabelManager, IKeyRank
    {
        #region IKeyRank ��Ա

        private long rankKeyId = -1;

        /// <summary>
        /// �����ؼ���Id
        /// </summary>
        public long RankKeyId
        {
            get
            {                
                return rankKeyId;
            }
            set
            {
                rankKeyId = value;
            }
        }

        private string moduleName = "";

        /// <summary>
        /// ��ǰģ������
        /// </summary>
        public string ModuleName
        {
            get
            {
                return moduleName;
            }
            set
            {
                moduleName = value;
            }
        }

        #endregion

        public override string CreateHTML()
        {
            short rank = Core.MyConvert.GetInt16(base.ParamInfo.GetValue("��ʾ����"));

            int rankingId = GetRankingId(RankKeyId, rank, ModuleName);

            if (rankingId <= 0) return base.CreateHTML();

            Model.RankingUserInfo customInfo = new Business.RanKingUserInfo().GetItem(rankingId, rank, ModuleName);

            if (customInfo == null || customInfo.AuditingState != XYECOM.Model.AuditingState.Passed) return base.CreateHTML();

            string image = customInfo.ImageUrl;

            if (image.Equals(""))
            {
                image = Business.Attachment.GetInfoDefaultImgHref(XYECOM.Model.AttachmentItem.CustomRanking, customInfo.InfoId);
            }

            string link = customInfo.Link;

            if (link.Equals(""))
            {
                link = "#";
            }

            string desc = customInfo.Desc;

            if (desc.Length > 100) desc = desc.Substring(0, 100);

            Model.GeneralUserInfo userinfo = Business.CheckUser.GetUserInfo(customInfo.UserId);

            string userlink = "";
            string companyname = "";

            if (userinfo != null)
            {
                userlink = userinfo.shopindex;
                companyname = userinfo.name;
            }

            string[] ac = new string[] { "{image}", "{title}", "{link}", "{desc}", "{userlink}", "{companyname}" };

            string[] a = new string[] { image, customInfo.Title, link, desc, userlink, companyname };

            string strcont = XYECOM.Core.TemplateEmail.GetContent(a, ac, "/templates/" + Configuration.Template.Instance.Path + "/__ranking.htm");

            if (strcont != "-1")
            {
                return strcont;
            }

            return base.CreateHTML();
        }


        /// <returns></returns>
        protected int GetRankingId(long rankKeyId, short rank, string moduleName)
        {
            if (rankKeyId <= 0) return 0;

            if (rank <= 0 || rank > XYECOM.Configuration.Ranking.Instance.Total) return 0;

            Model.RankingInfo rankingInfo = new Business.Ranking().GetItem(rankKeyId, rank);

            if (rankingInfo == null) return 0;

            return rankingInfo.RankingId;
        }
    }
}
