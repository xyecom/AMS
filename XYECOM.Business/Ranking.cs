using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// 排名业务类
    /// </summary>
    public class Ranking
    {
        private static readonly XYECOM.SQLServer.Ranking DAL = new XYECOM.SQLServer.Ranking();

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="info">排名类实体对象</param>
        /// <returns>影响行数</returns>
        public int Insert(XYECOM.Model.RankingInfo info)
        {
            if (info == null) return 0;

            return DAL.Insert(info);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="info">排名类实体对象</param>
        /// <returns>影响行数</returns>
        public int Update(XYECOM.Model.RankingInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }

        /// <summary>
        /// 删除多条信息
        /// </summary>
        /// <param name="logIds">编号集合</param>
        /// <returns>影响行数</returns>
        public int Delete(string rIds)
        {
            if(string.IsNullOrEmpty(rIds))return 0;

            rIds = rIds.Trim();

            if (rIds.Equals("")) return 0;

            return DAL.Delete(rIds);
        }

        /// <summary>
        /// 获取一条排名信息（指定排名记录Id）
        /// </summary>
        /// <param name="rankingId">排名记录Id</param>
        /// <returns>排名类实体对象</returns>
        public Model.RankingInfo GetItem(long rankingId)
        {
            if (rankingId <= 0) return null;

            return DAL.GetItem(rankingId);
        }

        /// <summary>
        /// 获取一条排名信息（指定用户Id,关键字Id,名次）
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="keyId">关键词Id</param>
        /// <param name="rank">名次</param>
        /// <returns>排名类实体对象</returns>
        public Model.RankingInfo GetItem(long userId, long keyId,short rank)
        {
            if (userId <= 0 || keyId <= 0 || rank<=0) return null;

            return DAL.GetItem(userId, keyId, rank);
        }

        /// <summary>
        /// 获取一条排名信息(指定关键词Id和名次)
        /// </summary>
        /// <param name="keyId">关键词Id</param>
        /// <param name="rank">名次</param>
        /// <returns>排名类实体对象</returns>
        public Model.RankingInfo GetItem(long keyId, short rank)
        {
            if (keyId <= 0 || rank <= 0) return null;

            return DAL.GetItem(keyId, rank);
        }

        /// <summary>
        /// 获取指定关键词的所有排名信息
        /// </summary>
        /// <param name="keyId">关键词Id</param>
        /// <returns>排名信息集合</returns>
        public List<Model.RankingInfo> GetItems(long keyId)
        {
            if (keyId <= 0) return new List<XYECOM.Model.RankingInfo>();

            return DAL.GetItems(keyId);
        }


        /// <summary>
        /// 搜索排名关键词
        /// </summary>
        /// <param name="key">关键字Id</param>
        /// <returns>排名关键词</returns>
        public DataTable GetKeywordRankingInfo(long keyId)
        {
            Model.SearchKeyInfo keyInfo = new Business.SearchKey().GetItem(keyId);

            if (keyInfo == null) return new DataTable();

            bool isCustomPrice = false;

            string moneyUnits = "元";

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
                    strState = "已售出(到期时间：" + _rankInfo.EndTime.ToString("yyyy-MM-dd") + ")";
                    strLink = "--";
                }
                else
                {
                    price = keyInfo.GetPrice(i);

                    if (price == 0) price = objRank.GetPrice(i);

                    strState = "购买价格：" + price.ToString() + moneyUnits;

                    strLink = "<a href='" + webInfo.WebDomain + "user/buy_key_1." + webInfo.WebSuffix + "?keyid=" + keyId + "&rank=" + i + "'>购买</a>";
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
