using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
   /// <summary>
   /// ��ҵ��Ϣ����
   /// </summary>
    public class BaseInfo : Attachment
    {
        private int infoID;
        /// <summary>
        /// ��Ϣ������id
        /// </summary>
        public int InfoID
        {
            get { return infoID; }
            set { infoID = value; }
        }

        private ThumbnailImg smallImg = new ThumbnailImg();
        /// <summary>
        /// �洢СͼƬ������
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
        /// ��ǰ����ʾ���� ��sell����buy
        /// </summary>
        public string SellBuy
        {
            get { return sellBuy; }
            set { sellBuy = value; }
        }

        private string moduleFlag= string.Empty;
        /// <summary>
        /// ��ǰģ������
        /// </summary>
        public string ModuleFlag
        {
            get { return moduleFlag; }
            set { moduleFlag = value; }
        }

        /// <summary>
        /// [����]ͼƬ���ӵ�ַ������ͼƬ���ҳ�������
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
        /// ͼƬ������·��
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
        /// ͼƬ��·��
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
        /// ��Ϣ����
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private decimal price;
        /// <summary>
        /// ��ǰ����
        /// </summary>
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        private DateTime publishTime;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime PublishTime
        {
            get { return publishTime; }
            set { publishTime = value; }
        }

        private DateTime endTime;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        private string infoContent = string.Empty;
        /// <summary>
        /// ��ϸ��Ϣ
        /// </summary>
        public string InfoContent
        {
            get { return infoContent; }
            set { infoContent = value; }
        }

        private Int64 userID;
        /// <summary>
        /// �û�id
        /// </summary>
        public Int64 UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private Int64 sortID;
        /// <summary>
        /// ����id
        /// </summary>
        public Int64 SortID
        {
            get { return sortID; }
            set { sortID = value; }
        }

        private string sortName = string.Empty;
        /// <summary>
        /// ��Ϣ�������
        /// </summary>
        public string SortName
        {
            get { return sortName; }
            set { sortName = value; }
        }

        private string htmlPage = string.Empty;
        /// <summary>
        /// ��̬ҳ���ַ
        /// </summary>
        public string HtmlPage
        {
            get { return htmlPage; }
            set { htmlPage = value; }
        }

        private Int64 clickNum;
        /// <summary>
        /// �������
        /// </summary>
        public Int64 ClickNum
        {
            get { return clickNum; }
            set { clickNum = value; }
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

        private int messageNum;
        /// <summary>
        /// ������Ϣ����
        /// </summary>
        public int MessageNum
        {
            get { return messageNum; }
            set { messageNum = value; }
        }

        private int notReadingNum;
        /// <summary>
        /// δ��������Ϣ����
        /// </summary>
        public int NotReadingNum
        {
            get { return notReadingNum; }
            set { notReadingNum = value; }
        }

        private int useFulDate;
        /// <summary>
        /// ��Ϣ��Чʱ��
        /// </summary>
        public int UseFulDate
        {
            get { return useFulDate; }
            set { useFulDate = value; }
        }

        private int infoType;
        /// <summary>
        /// ��Ϣ��ʶ
        /// </summary>
        public int InfoType
        {
            get { return infoType; }
            set { infoType = value; }
        }

        private Int64 fieldID;
        /// <summary>
        /// �Զ����ֶ���Ϣ
        /// </summary>
        public Int64 FieldID
        {
            get { return fieldID; }
            set { fieldID = value; }
        }

        private bool isPause;
        /// <summary>
        /// �Ƿ���ͣ
        /// </summary>
        public bool IsPause
        {
            get { return isPause; }
            set { isPause = value; }
        }

        private AuditingState state;

        /// <summary>
        /// ���״̬
        /// </summary>
        public AuditingState AuditingState
        {
            get { return state; }
            set { state = value; }
        }
    }
}
