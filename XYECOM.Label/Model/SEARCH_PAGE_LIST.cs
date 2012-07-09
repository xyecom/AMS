using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 系统所有搜索页面列表
    /// </summary>
    public enum SEARCH_PAGE_LIST
    {
        /// <summary>
        /// 供应搜索(/search/seller_search)
        /// </summary>
        SEARCH_SELLER_SEARCH,
        /// <summary>
        /// 求购所搜(/search/buyer_search)
        /// </summary>
        SEARCH_BUYER_SEARCH,
        /// <summary>
        /// 新闻搜索(/search/news_search)
        /// </summary>
        SEARCH_NEWS_SEARCH,
        /// <summary>
        /// 招聘搜索(/job/list)
        /// </summary>
        JOB_LIST,
        /// <summary>
        /// 人才搜索(/job/resumelist)
        /// </summary>
        JOB_RESUMELIST,
        /// <summary>
        /// 新闻频道页(/news/channel)
        /// </summary>
        NEWS_CHANNEL,
        /// <summary>
        /// 词条列表
        /// </summary>
        BAIKE_LIST,
        /// <summary>
        /// 团购列表（网店）
        /// </summary>
        TEAMBUY_LIST_SHOP,
        /// <summary>
        /// 团购列表（平台）
        /// </summary>
        TEAMBUY_LIST_PLAT,
        /// <summary>
        /// 求购（buy_search.aspx）
        /// </summary>
        SEARCH_BUY
    }
}
