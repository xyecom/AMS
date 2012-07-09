using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// ����ҵ����
    /// </summary>
    public class Ranking
    {
        private static readonly XYECOM.SQLServer.Ranking DAL = new XYECOM.SQLServer.Ranking();

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="info">������ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Insert(XYECOM.Model.RankingInfo info)
        {
            if (info == null) return 0;

            return DAL.Insert(info);
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="info">������ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Update(XYECOM.Model.RankingInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }

        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="logIds">��ż���</param>
        /// <returns>Ӱ������</returns>
        public int Delete(string rIds)
        {
            if(string.IsNullOrEmpty(rIds))return 0;

            rIds = rIds.Trim();

            if (rIds.Equals("")) return 0;

            return DAL.Delete(rIds);
        }

        /// <summary>
        /// ��ȡһ��������Ϣ��ָ��������¼Id��
        /// </summary>
        /// <param name="rankingId">������¼Id</param>
        /// <returns>������ʵ�����</returns>
        public Model.RankingInfo GetItem(long rankingId)
        {
            if (rankingId <= 0) return null;

            return DAL.GetItem(rankingId);
        }

        /// <summary>
        /// ��ȡһ��������Ϣ��ָ���û�Id,�ؼ���Id,���Σ�
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <param name="keyId">�ؼ���Id</param>
        /// <param name="rank">����</param>
        /// <returns>������ʵ�����</returns>
        public Model.RankingInfo GetItem(long userId, long keyId,short rank)
        {
            if (userId <= 0 || keyId <= 0 || rank<=0) return null;

            return DAL.GetItem(userId, keyId, rank);
        }

        /// <summary>
        /// ��ȡһ��������Ϣ(ָ���ؼ���Id������)
        /// </summary>
        /// <param name="keyId">�ؼ���Id</param>
        /// <param name="rank">����</param>
        /// <returns>������ʵ�����</returns>
        public Model.RankingInfo GetItem(long keyId, short rank)
        {
            if (keyId <= 0 || rank <= 0) return null;

            return DAL.GetItem(keyId, rank);
        }

        /// <summary>
        /// ��ȡָ���ؼ��ʵ�����������Ϣ
        /// </summary>
        /// <param name="keyId">�ؼ���Id</param>
        /// <returns>������Ϣ����</returns>
        public List<Model.RankingInfo> GetItems(long keyId)
        {
            if (keyId <= 0) return new List<XYECOM.Model.RankingInfo>();

            return DAL.GetItems(keyId);
        }


        /// <summary>
        /// ���������ؼ���
        /// </summary>
        /// <param name="key">�ؼ���Id</param>
        /// <returns>�����ؼ���</returns>
        public DataTable GetKeywordRankingInfo(long keyId)
        {
            Model.SearchKeyInfo keyInfo = new Business.SearchKey().GetItem(keyId);

            if (keyInfo == null) return new DataTable();

            bool isCustomPrice = false;

            string moneyUnits = "Ԫ";

            XYECOM.Configuration.Ranking objRank = XYECOM.Configuration.Ranking.Instance;
            XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;

            if (objRank.MoneyType == XYECOM.Configuration.RankingMoneyType.VirtualMoney)
                moneyUnits = XYECOM.Configuration.WebInfo.Instance.WebMoneyName;

            moneyUnits = moneyUnits + "/" + objRank.TimeUnits;
            
            Business.Ranking rankBLL = new Ranking();

            string strState = "";
            string strLink = "";

            int tatal = objRank.Total;
            int index = 1;

            Model.RankingInfo _rankInfo = null;

            DataTable rankingData = new System.Data.DataTable();

            rankingData.Columns.Add("Rank");
            rankingData.Columns.Add("State");
            rankingData.Columns.Add("Link");
            
            DataRow row = null;

            int price = 0;

            for(short i=1;i<=tatal;i++)
            {
                _rankInfo = rankBLL.GetItem(keyId, i);

                row = rankingData.NewRow();

                row["Rank"] = i;

                if (_rankInfo != null)
                {
                    strState = "���۳�(����ʱ�䣺" + _rankInfo.EndTime.ToString("yyyy-MM-dd") + ")";
                    strLink = "--";
                }
                else
                {
                    price = keyInfo.GetPrice(i);

                    if (price == 0) price = objRank.GetPrice(i);

                    strState = "����۸�" + price.ToString() + moneyUnits;

                    strLink = "<a href='" + webInfo.WebDomain + "user/buy_key_1." + webInfo.WebSuffix + "?keyid=" + keyId + "&rank=" + i + "'>����</a>";
                }

                row["State"] = strState;
                row["Link"] = strLink;

                index++;

                rankingData.Rows.Add(row);
            }

            return rankingData;
        }
    }
}
