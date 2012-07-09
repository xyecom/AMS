using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
   /// <summary>
   /// 商业信息基类
   /// </summary>
    public class BaseInfo : Attachment
    {
        private int infoID;
        /// <summary>
        /// 信息的主键id
        /// </summary>
        public int InfoID
        {
            get { return infoID; }
            set { infoID = value; }
        }

        private ThumbnailImg smallImg = new ThumbnailImg();
        /// <summary>
        /// 存储小图片的数组
        /// </summary>
        public ThumbnailImg SmallImg
        {
            get 
            {
                if (AttachInfo.Count > 0)
                {
                    smallImg.SURL = AttachInfo[0].Server.S_URL;
                    smallImg.Images = AttachInfo[0].ThumbnailImg.Split('|');
                    smallImg.DefaultFilePath = AttachInfo[0].Server.S_URL + AttachInfo[0].At_Path;
                }
                return smallImg; 
            }
        }

        private string sellBuy = "sell";
        /// <summary>
        /// 当前的显示类型 是sell还是buy
        /// </summary>
        public string SellBuy
        {
            get { return sellBuy; }
            set { sellBuy = value; }
        }

        private string moduleFlag= string.Empty;
        /// <summary>
        /// 当前模块名称
        /// </summary>
        public string ModuleFlag
        {
            get { return moduleFlag; }
            set { moduleFlag = value; }
        }

        /// <summary>
        /// [更多]图片链接地址，即到图片浏览页面的链接
        /// </summary>
        public string MorePicUrl
        {
            get 
            {
                if (moduleFlag.ToLower().Equals("brand")) sellBuy = "";

                XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;
                if (webInfo.IsBogusStatic)
                {
                    return webInfo.WebDomain + "search/picture-" + sellBuy + moduleFlag + "-" + infoID + "." + webInfo.WebSuffix;
                }
                else
                {
                    return webInfo.WebDomain + "search/picture." + webInfo.WebSuffix + "?flag=" + sellBuy + moduleFlag + "&id=" + infoID;
                }
            }
        }

        private string _s_url = "";

        /// <summary>
        /// 图片服务器路径
        /// </summary>
        public string S_URL
        {
            set 
            {
                smallImg.SURL = value;
                _s_url = value; 
            }
            get { return _s_url; }
        }

        private string filePath = string.Empty;
        /// <summary>
        /// 图片的路径
        /// </summary>
        public string FilePath
        {
            get 
            {
                if (AttachInfo.Count > 0)
                {
                    filePath = AttachInfo[0].Server.S_URL + AttachInfo[0].At_Path;
                }
                return filePath; 
            }
            set 
            {
                smallImg.DefaultFilePath = value;
                filePath = value; 
            }
        }

        private string title = string.Empty;
        /// <summary>
        /// 信息标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private decimal price;
        /// <summary>
        /// 当前单价
        /// </summary>
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        private DateTime publishTime;
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PublishTime
        {
            get { return publishTime; }
            set { publishTime = value; }
        }

        private DateTime endTime;
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        private string infoContent = string.Empty;
        /// <summary>
        /// 详细信息
        /// </summary>
        public string InfoContent
        {
            get { return infoContent; }
            set { infoContent = value; }
        }

        private Int64 userID;
        /// <summary>
        /// 用户id
        /// </summary>
        public Int64 UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private Int64 sortID;
        /// <summary>
        /// 分类id
        /// </summary>
        public Int64 SortID
        {
            get { return sortID; }
            set { sortID = value; }
        }

        private string sortName = string.Empty;
        /// <summary>
        /// 信息类别名称
        /// </summary>
        public string SortName
        {
            get { return sortName; }
            set { sortName = value; }
        }

        private string htmlPage = string.Empty;
        /// <summary>
        /// 静态页面地址
        /// </summary>
        public string HtmlPage
        {
            get { return htmlPage; }
            set { htmlPage = value; }
        }

        private Int64 clickNum;
        /// <summary>
        /// 点击次数
        /// </summary>
        public Int64 ClickNum
        {
            get { return clickNum; }
            set { clickNum = value; }
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

        private int messageNum;
        /// <summary>
        /// 留言信息条数
        /// </summary>
        public int MessageNum
        {
            get { return messageNum; }
            set { messageNum = value; }
        }

        private int notReadingNum;
        /// <summary>
        /// 未读留言信息条数
        /// </summary>
        public int NotReadingNum
        {
            get { return notReadingNum; }
            set { notReadingNum = value; }
        }

        private int useFulDate;
        /// <summary>
        /// 信息有效时间
        /// </summary>
        public int UseFulDate
        {
            get { return useFulDate; }
            set { useFulDate = value; }
        }

        private int infoType;
        /// <summary>
        /// 信息标识
        /// </summary>
        public int InfoType
        {
            get { return infoType; }
            set { infoType = value; }
        }

        private Int64 fieldID;
        /// <summary>
        /// 自定义字段信息
        /// </summary>
        public Int64 FieldID
        {
            get { return fieldID; }
            set { fieldID = value; }
        }

        private bool isPause;
        /// <summary>
        /// 是否暂停
        /// </summary>
        public bool IsPause
        {
            get { return isPause; }
            set { isPause = value; }
        }

        private AuditingState state;

        /// <summary>
        /// 审核状态
        /// </summary>
        public AuditingState AuditingState
        {
            get { return state; }
            set { state = value; }
        }
    }
}
