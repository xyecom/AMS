using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 资讯实体类
    /// </summary>
    public class NewsInfo
    {
        public NewsInfo()
        {
        }

        private long newsId;

        /// <summary>
        /// 资讯ID
        /// </summary>
        public long NewsId
        {
            get { return newsId; }
            set { newsId = value; }
        }

        private NewsType type;

        /// <summary>
        /// 资讯类型
        /// </summary>
        public NewsType Type
        {
            get { return type; }
            set { type = value; }
        }
        private string typeIds;

        /// <summary>
        /// 所属频道Id集合
        /// </summary>
        public string TypeIds
        {
            get { return typeIds; }
            set 
            {
                typeIds = value;
            }
        }
        private string title;

        /// <summary>
        /// 资讯标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }


        private string subTitle;

        /// <summary>
        /// 资讯副标题
        /// </summary>
        public string SubTitle
        {
            get { return subTitle; }
            set { subTitle = value; }
        }

        private string titleStyle = "";
        /// <summary>
        /// 标题样式
        /// </summary>
        public string TitleStyle
        {
            get { return titleStyle; }
            set { titleStyle = value; }
        }

        private string keyword;

        /// <summary>
        /// 关键字
        /// </summary>
        public string Keyword
        {
            get { return keyword; }
            set { keyword = value; }
        }
        private string headlineNewsUrl;

        /// <summary>
        /// 标题新闻Url地址
        /// </summary>
        public string HeadlineNewsUrl
        {
            get { return headlineNewsUrl; }
            set { headlineNewsUrl = value; }
        }
        private string picUrl;

        /// <summary>
        /// 图片地址
        /// </summary>
        public string PicUrl
        {
            get { return picUrl; }
            set { picUrl = value; }
        }
        private string author;

        /// <summary>
        /// 作者
        /// </summary>
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        private string origin;

        /// <summary>
        /// 来源
        /// </summary>
        public string Origin
        {
            get { return origin; }
            set { origin = value; }
        }
        private string leadin;

        /// <summary>
        ///导读
        /// </summary>
        public string Leadin
        {
            get { return leadin; }
            set { leadin = value; }
        }
        private string content;

        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        private string addTime;

        /// <summary>
        /// 添加时间
        /// </summary>
        public string AddTime
        {
            get 
            {
                return Core.MyConvert.GetDateTime(addTime).ToString("yyyy-MM-dd"); 
            }
            set { addTime = value; }
        }
        private int clickNumber;

        /// <summary>
        /// 单击次数
        /// </summary>
        public int ClickNumber
        {
            get { return clickNumber; }
            set { clickNumber = value; }
        }
        private AuditingState state;

        /// <summary>
        /// 审核状态
        /// </summary>
        public AuditingState State
        {
            get { return state; }
            set { state = value; }
        }
        private bool isCommend;

        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool IsCommend
        {
            get { return isCommend; }
            set { isCommend = value; }
        }
        private string _HTMLPage;

        /// <summary>
        /// 今天页面地址
        /// </summary>
        public string HTMLPage
        {
            get { return _HTMLPage; }
            set { _HTMLPage = value; }
        }
        private bool isAllowComment;
         
        /// <summary>
        /// 是否允许评论
        /// </summary>
        public bool IsAllowComment
        {
            get { return isAllowComment; }
            set { isAllowComment = value; }
        }
        private bool isTop;

        /// <summary>
        /// 是否为头条
        /// </summary>
        public bool IsTop
        {
            get { return isTop; }
            set { isTop = value; }
        }

        private bool isHot;

        /// <summary>
        /// 是否为热点新闻
        /// </summary>
        public bool IsHot
        {
            get { return isHot; }
            set { isHot = value; }            
        }

        private bool isSlide;

        /// <summary>
        /// 似乎否为幻灯
        /// </summary>
        public bool IsSlide
        {
            get { return isSlide; }
            set { isSlide = value; }
        }

        public string Tags
        {
            get
            {
                string[] tags = keyword.Split(',');
                StringBuilder sb = new StringBuilder("");
                for (int i = 0; i < tags.Length; i++)
                {
                    if (XYECOM.Configuration.WebInfo.Instance.IsBogusStatic == false)
                    {
                        sb.Append("<a href=\"" + XYECOM.Configuration.WebInfo.Instance.WebDomain + "search/news_search." + XYECOM.Configuration.WebInfo.Instance.WebSuffix + "?keyword=");
                        sb.Append(tags[i]);
                        sb.Append("\" target=\"_blank\">");
                        sb.Append(tags[i]);
                        sb.Append("</a>");
                    }
                    else
                    {
                        sb.Append("<a href=\"" + XYECOM.Configuration.WebInfo.Instance.WebDomain + "search/news_search---");
                        sb.Append(tags[i]);
                        sb.Append("-----." + XYECOM.Configuration.WebInfo.Instance.WebSuffix + "\"  target=\"_blank\">");
                        sb.Append(tags[i]);
                        sb.Append("</a>");
                    }
                }

                return sb.ToString();
            }
        }

        private string chargeState="";
        /// <summary>
        /// 资讯收费状态
        /// </summary>
        public string ChargeState
        {
            get 
            {
                return this.chargeState;
            }
            set {
                chargeState = value;
            }
        }


        ///// 新闻权重，3表示一般置顶
        ///// 1表示总置顶，2表示栏目置顶
        ///// </summary>
        //public Int16 NS_Sort
        //{
        //    set { _ns_sort = value; }
        //    get { return _ns_sort; }
        //}

      


        private string topicType;
        /// <summary>
        /// 专题id
        /// </summary>
        public string TopicType
        {
            get { return topicType; }
            set { topicType = value; }
        }


        private long contributor;
        /// <summary>
        /// 投稿人
        /// </summary>
        public long Contributor
        {
            get { return contributor; }
            set { contributor = value; }
        }

        private string adjunct;

        /// <summary>
        /// 附件
        /// </summary>
        public string Adjunct
        {
            get { return this.adjunct; }
            set { adjunct = value; }
        }

        private string areaIds;

        /// <summary>
        /// 新闻所属的地区信息，主要用于地方站
        /// </summary>
        public string AreaIds
        {
            get { return areaIds; }
            set { areaIds = value; }
        }

        private string tradeIds;
        /// <summary>
        /// 新闻所属的行业信息，主要用于行业频道
        /// </summary>
        public string TradeIds
        {
            get { return tradeIds; }
            set { tradeIds = value; }
        }
        private int uM_ID;
        ///<summary>
        /// 新闻发布人的ID 主要用于记录统计当前发布人一共发布多少条记录
        /// </summary>
        public int UM_ID
        {
            get { return uM_ID; }
            set { uM_ID = value; }
        }

        
        private string fileUrl;


        /// <summary>
        /// 是否有附件链接地址
        /// </summary>
        public string FileUrl
        {
            get { return fileUrl; }
            set { fileUrl = value; }
        }


        private string protypeIds;

        /// <summary>
        /// 新闻所属的产品类型
        /// </summary>
        public string ProtypeIds
        {
            get { return protypeIds; }
            set { protypeIds = value; }
        }

        private int userTitleInfoId;
        /// <summary>
        /// 用户自定义栏目Id
        /// </summary>
        /// 
        public int UserTitleInfoId
        {
            get { return userTitleInfoId; }
            set { userTitleInfoId = value; }
        }

        
        private string proIds;
        /// <summary>
        /// 相关产品Ids
        /// </summary>
        /// 
        public string ProIds
        {
            get { return proIds; }
            set { proIds = value; }
        }

        private int isScheme;
        /// <summary>
        /// 是否是方案式采购
        /// </summary>
        /// 
        public int IsScheme
        {
            get { return isScheme; }
            set { isScheme = value; }
        }
    }
}
