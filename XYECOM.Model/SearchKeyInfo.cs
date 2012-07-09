using System;

namespace XYECOM.Model
{
    /// <summary>
    /// 定义热门搜索关键字实体类
    /// </summary>
    public class SearchKeyInfo
    {
        private Int64 _sk_id;
        private string _sk_name;
        private string _sk_sort;
        private Int64 _sk_count;
        private bool _sk_iscommend;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public SearchKeyInfo() { }

        /// <summary>
        /// 热门搜索关键字编号
        /// </summary>
        public Int64 SK_ID
        {
            set { _sk_id = value; }
            get { return _sk_id; }
        }

        /// <summary>
        /// 热门搜索关键字名称
        /// </summary>
        public string SK_Name
        {
            set { _sk_name = value; }
            get { return _sk_name; }
        }

        /// <summary>
        /// 热门搜索关键字类别名称
        /// </summary>
        public string SK_Sort
        {
            set { _sk_sort = value; }
            get { return _sk_sort; }
        }

        /// <summary>
        /// 该字被搜索次数
        /// </summary>
        public Int64 SK_Count
        {
            set { this._sk_count = value; }
            get { return _sk_count; }
        }

        /// <summary>
        /// 是否推荐该关键字
        /// </summary>
        public bool SK_IsCommend
        {
            set { this._sk_iscommend = value; }
            get { return _sk_iscommend; }
        }

        private bool _SK_IsRanking;
        /// <summary>
        /// 是否参与排名
        /// </summary>
        public bool SK_IsRanking
        {
            get { return _SK_IsRanking; }
            set { _SK_IsRanking = value; }
        }

        private DateTime _SK_AddTime;
        /// <summary>
        /// 录入时间(第一次被搜索时间)
        /// </summary>
        public DateTime SK_AddTime
        {
            get { return _SK_AddTime; }
            set { _SK_AddTime = value; }
        }

        private DateTime _SK_LastSearchTime;
        /// <summary>
        /// 最后一次搜索时间
        /// </summary>
        public DateTime SK_LastSearchTime
        {
            get { return _SK_LastSearchTime; }
            set { _SK_LastSearchTime = value; }
        }

        private string _SK_CustomPrice ="";

        /// <summary>
        /// 自定义价格
        /// </summary>
        public string SK_CustomPrice
        {
            get { return _SK_CustomPrice; }
            set { _SK_CustomPrice = value; }
        }

        /// <summary>
        /// 获取价格
        /// </summary>
        /// <param name="rank">名次</param>
        /// <returns></returns>
        public int GetPrice(short rank)
        {
            if (_SK_CustomPrice.Equals("")) return 0;

            string[] prices = _SK_CustomPrice.Split('|');

            if (rank > prices.Length) return 0;

            return Core.MyConvert.GetInt32(prices[rank - 1].ToString());
        }
    }
}
