using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using XYECOM.Core.XML;

namespace XYECOM.Configuration
{
    /// <summary>
    /// Ranking.config 文件处理类
    /// </summary>
    public class Ranking : BaseConfig
    {
        private int rankingTotal;
        private string timeUnits;
        private RankingMoneyType moneyType = RankingMoneyType.Cash;

        private static Ranking instance = null;

        private List<RankingPriceInfo> priceInfo = new List<RankingPriceInfo>();

        private Ranking()
        {
        }

        /// <summary>
        /// 获取单态实例
        /// </summary>
        public static Ranking Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        instance = new Ranking();
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void Init()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/Ranking.config"));

            rankingTotal = XYECOM.Core.MyConvert.GetInt32(GetNodeValue(docXml, "Total"));
            timeUnits = GetNodeValue(docXml, "TimeUnits");

            string mType = GetNodeValue(docXml, "MoneyType");

            if (mType.Equals("Cash")) 
                moneyType = RankingMoneyType.Cash;
            else 
                moneyType = RankingMoneyType.VirtualMoney;

            //IM 相关读取
            XmlElement ele = (XmlElement)docXml.GetElementsByTagName("Price")[0];

            RankingPriceInfo info = null;

            XmlNodeList list = ele.GetElementsByTagName("Item");

            for (int i = 0; i < list.Count; i++)
            {
                info = new RankingPriceInfo();
                info.Rank = XYECOM.Core.MyConvert.GetInt16(list[i].Attributes["rank"].Value);
                info.Price = XYECOM.Core.MyConvert.GetInt32(list[i].Attributes["price"].Value);

                priceInfo.Add(info);
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns>true:更新成功,false:更新失败</returns>
        public override bool Update()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/Ranking.config"));

            SetNodeValue(docXml, "Total", rankingTotal);
            SetNodeValue(docXml, "TimeUnits", timeUnits);

            string mType ="Cash";

            if (moneyType == RankingMoneyType.VirtualMoney)
                mType = "VirtualMoney";

            SetNodeValue(docXml, "MoneyType", mType);

            XmlElement ele = (XmlElement)docXml.GetElementsByTagName("Price")[0];
            ele.RemoveAll();
            XmlNode page = null;

            foreach (RankingPriceInfo info in priceInfo)
            {
                page = XMLUtil.AppendElement(ele, "Item");
                XMLUtil.SetAttribute(page, "rank", info.Rank.ToString());
                XMLUtil.SetAttribute(page, "price", info.Price.ToString());
            }

            try
            {
                docXml.Save(System.Web.HttpContext.Current.Server.MapPath("/Config/Ranking.config"));
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                instance = new Ranking();
            }
        }

        /// <summary>
        /// 排名个数
        /// </summary>
        public int Total
        {
            get { return rankingTotal; }
            set { rankingTotal = value; }
        }

        /// <summary>
        /// 排名时间周期单位
        /// </summary>
        public string TimeUnits
        {
            get { return timeUnits; }
            set { timeUnits = value; }
        }

        /// <summary>
        /// 排名服务所使用的货币类型
        /// </summary>
        public RankingMoneyType MoneyType
        {
            get { return moneyType; }
            set { moneyType = value; }
        }

        /// <summary>
        /// 价格信息
        /// </summary>
        public List<RankingPriceInfo> PriceInfo
        {
            get { return priceInfo; }
            set { priceInfo = value; }
        }

        /// <summary>
        /// 获取价格
        /// </summary>
        /// <param name="rank">名次</param>
        /// <returns></returns>
        public int GetPrice(short rank)
        {
            if (rank <= 0) return 0;

            foreach (RankingPriceInfo info in PriceInfo)
            {
                if (info.Rank == rank) return info.Price;
            }

            return 0;
        }

    }
}
