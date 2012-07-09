using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ��Ѷʵ����
    /// </summary>
    public class NewsInfo
    {
        public NewsInfo()
        {
        }

        private long newsId;

        /// <summary>
        /// ��ѶID
        /// </summary>
        public long NewsId
        {
            get { return newsId; }
            set { newsId = value; }
        }

        private NewsType type;

        /// <summary>
        /// ��Ѷ����
        /// </summary>
        public NewsType Type
        {
            get { return type; }
            set { type = value; }
        }
        private string typeIds;

        /// <summary>
        /// ����Ƶ��Id����
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
        /// ��Ѷ����
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }


        private string subTitle;

        /// <summary>
        /// ��Ѷ������
        /// </summary>
        public string SubTitle
        {
            get { return subTitle; }
            set { subTitle = value; }
        }

        private string titleStyle = "";
        /// <summary>
        /// ������ʽ
        /// </summary>
        public string TitleStyle
        {
            get { return titleStyle; }
            set { titleStyle = value; }
        }

        private string keyword;

        /// <summary>
        /// �ؼ���
        /// </summary>
        public string Keyword
        {
            get { return keyword; }
            set { keyword = value; }
        }
        private string headlineNewsUrl;

        /// <summary>
        /// ��������Url��ַ
        /// </summary>
        public string HeadlineNewsUrl
        {
            get { return headlineNewsUrl; }
            set { headlineNewsUrl = value; }
        }
        private string picUrl;

        /// <summary>
        /// ͼƬ��ַ
        /// </summary>
        public string PicUrl
        {
            get { return picUrl; }
            set { picUrl = value; }
        }
        private string author;

        /// <summary>
        /// ����
        /// </summary>
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        private string origin;

        /// <summary>
        /// ��Դ
        /// </summary>
        public string Origin
        {
            get { return origin; }
            set { origin = value; }
        }
        private string leadin;

        /// <summary>
        ///����
        /// </summary>
        public string Leadin
        {
            get { return leadin; }
            set { leadin = value; }
        }
        private string content;

        /// <summary>
        /// ����
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        private string addTime;

        /// <summary>
        /// ���ʱ��
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
        /// ��������
        /// </summary>
        public int ClickNumber
        {
            get { return clickNumber; }
            set { clickNumber = value; }
        }
        private AuditingState state;

        /// <summary>
        /// ���״̬
        /// </summary>
        public AuditingState State
        {
            get { return state; }
            set { state = value; }
        }
        private bool isCommend;

        /// <summary>
        /// �Ƿ��Ƽ�
        /// </summary>
        public bool IsCommend
        {
            get { return isCommend; }
            set { isCommend = value; }
        }
        private string _HTMLPage;

        /// <summary>
        /// ����ҳ���ַ
        /// </summary>
        public string HTMLPage
        {
            get { return _HTMLPage; }
            set { _HTMLPage = value; }
        }
        private bool isAllowComment;
         
        /// <summary>
        /// �Ƿ���������
        /// </summary>
        public bool IsAllowComment
        {
            get { return isAllowComment; }
            set { isAllowComment = value; }
        }
        private bool isTop;

        /// <summary>
        /// �Ƿ�Ϊͷ��
        /// </summary>
        public bool IsTop
        {
            get { return isTop; }
            set { isTop = value; }
        }

        private bool isHot;

        /// <summary>
        /// �Ƿ�Ϊ�ȵ�����
        /// </summary>
        public bool IsHot
        {
            get { return isHot; }
            set { isHot = value; }            
        }

        private bool isSlide;

        /// <summary>
        /// �ƺ���Ϊ�õ�
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
        /// ��Ѷ�շ�״̬
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


        ///// ����Ȩ�أ�3��ʾһ���ö�
        ///// 1��ʾ���ö���2��ʾ��Ŀ�ö�
        ///// </summary>
        //public Int16 NS_Sort
        //{
        //    set { _ns_sort = value; }
        //    get { return _ns_sort; }
        //}

      


        private string topicType;
        /// <summary>
        /// ר��id
        /// </summary>
        public string TopicType
        {
            get { return topicType; }
            set { topicType = value; }
        }


        private long contributor;
        /// <summary>
        /// Ͷ����
        /// </summary>
        public long Contributor
        {
            get { return contributor; }
            set { contributor = value; }
        }

        private string adjunct;

        /// <summary>
        /// ����
        /// </summary>
        public string Adjunct
        {
            get { return this.adjunct; }
            set { adjunct = value; }
        }

        private string areaIds;

        /// <summary>
        /// ���������ĵ�����Ϣ����Ҫ���ڵط�վ
        /// </summary>
        public string AreaIds
        {
            get { return areaIds; }
            set { areaIds = value; }
        }

        private string tradeIds;
        /// <summary>
        /// ������������ҵ��Ϣ����Ҫ������ҵƵ��
        /// </summary>
        public string TradeIds
        {
            get { return tradeIds; }
            set { tradeIds = value; }
        }
        private int uM_ID;
        ///<summary>
        /// ���ŷ����˵�ID ��Ҫ���ڼ�¼ͳ�Ƶ�ǰ������һ��������������¼
        /// </summary>
        public int UM_ID
        {
            get { return uM_ID; }
            set { uM_ID = value; }
        }

        
        private string fileUrl;


        /// <summary>
        /// �Ƿ��и������ӵ�ַ
        /// </summary>
        public string FileUrl
        {
            get { return fileUrl; }
            set { fileUrl = value; }
        }


        private string protypeIds;

        /// <summary>
        /// ���������Ĳ�Ʒ����
        /// </summary>
        public string ProtypeIds
        {
            get { return protypeIds; }
            set { protypeIds = value; }
        }

        private int userTitleInfoId;
        /// <summary>
        /// �û��Զ�����ĿId
        /// </summary>
        /// 
        public int UserTitleInfoId
        {
            get { return userTitleInfoId; }
            set { userTitleInfoId = value; }
        }

        
        private string proIds;
        /// <summary>
        /// ��ز�ƷIds
        /// </summary>
        /// 
        public string ProIds
        {
            get { return proIds; }
            set { proIds = value; }
        }

        private int isScheme;
        /// <summary>
        /// �Ƿ��Ƿ���ʽ�ɹ�
        /// </summary>
        /// 
        public int IsScheme
        {
            get { return isScheme; }
            set { isScheme = value; }
        }
    }
}
