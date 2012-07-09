using System;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;
using XYECOM.Core;
using System.Web.Caching;

namespace XYECOM.Configuration
{
    /// <summary>
    /// webinfo.config �ļ�������
    /// </summary>
    public class WebInfo : BaseConfig
    {
        private static WebInfo instance = null;

        private static System.Web.Caching.Cache cache = null;

        static WebInfo()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            if (context != null)
            {
                cache = context.Cache;
            }
            else
            {
                cache = System.Web.HttpRuntime.Cache;
            }
        }

        private WebInfo()
        {
        }

        /// <summary>
        /// ��ʼ��
        /// </summary>
        protected override void Init()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/WebInfo.config"));
            webName = GetNodeValue(docXml, "WebName");
            webLogo = GetNodeValue(docXml, "WebLogo");
            WebDomain = GetNodeValue(docXml, "WebDomain");
            WebSuffix = GetNodeValue(docXml, "WebSuffix");
            IsBogusStatic = MyConvert.GetBoolean(GetNodeValue(docXml, "IsBogusStatic"));
            StaticPageSuffix = GetNodeValue(docXml, "StaticPageSuffix");
            IsDomain = MyConvert.GetBoolean(GetNodeValue(docXml, "IsDomain"));
            IsNewsDomain = MyConvert.GetBoolean(GetNodeValue(docXml, "IsNewsDomain"));
            WebMoneyName = GetNodeValue(docXml, "WebMoneyName");
            UploadFileType = GetNodeValue(docXml, "UploadFileType");
            UploadFileSize = MyConvert.GetInt32(GetNodeValue(docXml, "UploadFileSize"));
            uploadImg = GetNodeValue(docXml, "UploadImg");
            uploadThumbnailImgFolder = GetNodeValue(docXml, "UploadThumbnailImgFolder");
            uploadThumbnailImg1 = GetNodeValue(docXml, "UploadThumbnailImg1");
            uploadThumbnailImg2 = GetNodeValue(docXml, "UploadThumbnailImg2");
            uploadThumbnailImg3 = GetNodeValue(docXml, "UploadThumbnailImg3");
            UploadAdjunctType = GetNodeValue(docXml, "UploadAdjunctType");
            UploadAdjunctSize = MyConvert.GetInt32(GetNodeValue(docXml, "UploadAdjunctSize"));
            Email = GetNodeValue(docXml, "Email");
            EmailServer = GetNodeValue(docXml, "EmailServer");
            emailServerPort = MyConvert.GetInt32(GetNodeValue(docXml, "EmailServerPort"));
            EmailLoginName = GetNodeValue(docXml, "EmailLoginName");
            EmailPwd = GetNodeValue(docXml, "EmailPwd");
            IsWaterMark = MyConvert.GetBoolean(GetNodeValue(docXml, "IsWaterMark"));
            WaterMarkType = MyConvert.GetInt32(GetNodeValue(docXml, "WaterMarkType"));
            WaterMarkContent = GetNodeValue(docXml, "WaterMarkContent");
            WaterMarkFont = GetNodeValue(docXml, "WaterMarkFont");
            WaterMarkFontSize = MyConvert.GetInt32(GetNodeValue(docXml, "WaterMarkFontSize"));
            WaterMarkPlace = GetNodeValue(docXml, "WaterMarkPlace");
            WaterMarkColor = GetNodeValue(docXml, "WaterMarkColor");
            WaterMarkPicURL = GetNodeValue(docXml, "WaterMarkPicURL");
            WaterMarkPicPlace = GetNodeValue(docXml, "WaterMarkPicPlace");
            WaterMarkPicDiaphaneity = MyConvert.GetFloat(GetNodeValue(docXml, "WaterMarkPicDiaphaneity"));
            WaterMarkPicBgColor = GetNodeValue(docXml, "WaterMarkPicBgColor");
            registerMode = GetNodeValue(docXml, "RegisterMode");
            IsRegister = MyConvert.GetBoolean(GetNodeValue(docXml, "IsRegister"));
            userRegisterAuditingType = MyConvert.GetBoolean(GetNodeValue(docXml, "UserRegisterAuditingType"));
            UserDefaultLevel = MyConvert.GetInt32(GetNodeValue(docXml, "UserDefaultLevel"));
            ForbidName = GetNodeValue(docXml, "ForbidName");
            UserDefaultWebMoney = MyConvert.GetInt32(GetNodeValue(docXml, "UserDefaultWebMoney"));
            IsRegisterEmail = MyConvert.GetBoolean(GetNodeValue(docXml, "IsRegisterEmail"));
            IsRegisterMessage = MyConvert.GetBoolean(GetNodeValue(docXml, "IsRegisterMessage"));
            RegisterMessageTitle = GetNodeValue(docXml, "RegisterMessageTitle");
            RegisterMessageContent = GetNodeValue(docXml, "RegisterMessageContent");
            IsAuditingUserMessage = MyConvert.GetBoolean(GetNodeValue(docXml, "IsAuditingUserMessage"));
            AuditingUserMessageTitle = GetNodeValue(docXml, "AuditingUserMessageTitle");
            AuditingUserMessageContent = GetNodeValue(docXml, "AuditingUserMessageContent");
            LoginAddScore = MyConvert.GetInt32(GetNodeValue(docXml, "LoginAddScore"));
            LoginAddWebMoney = MyConvert.GetDecimal(GetNodeValue(docXml, "LoginAddWebMoney"));
            BaseDatumPercent = MyConvert.GetInt32(GetNodeValue(docXml, "BaseDatumPercent"));
            AdvancedDatumPercent = MyConvert.GetInt32(GetNodeValue(docXml, "AdvancedDatumPercent"));
            LicencePercent = MyConvert.GetInt32(GetNodeValue(docXml, "LicencePercent"));
            CertificatePercent = MyConvert.GetInt32(GetNodeValue(docXml, "CertificatePercent"));
            RegisterPercent = MyConvert.GetInt32(GetNodeValue(docXml, "RegisterPercent"));
            MobilePercent = MyConvert.GetInt32(GetNodeValue(docXml, "MobilePercent"));
            DepartmentPercent = MyConvert.GetInt32(GetNodeValue(docXml, "DepartmentPercent"));
            CapitalPercent = MyConvert.GetInt32(GetNodeValue(docXml, "CapitalPercent"));
            IssueInfoAddWebMoney = MyConvert.GetInt32(GetNodeValue(docXml, "IssueInfoAddWebMoney"));
            EditInfoAuditingType = MyConvert.GetBoolean(GetNodeValue(docXml, "EditInfoAuditingType"));
            InsertInfoAuditingType = MyConvert.GetBoolean(GetNodeValue(docXml, "InsertInfoAuditingType"));
            RefreshInfoAddWebMoney = MyConvert.GetDecimal(GetNodeValue(docXml, "RefreshInfoAddWebMoney"));
            InfoEndTimeType = MyConvert.GetBoolean(GetNodeValue(docXml, "InfoEndTimeType"));
            IsAuditingInfoEmail = MyConvert.GetBoolean(GetNodeValue(docXml, "IsAuditingInfoEmail"));
            IsAuditingInfoMessage = MyConvert.GetBoolean(GetNodeValue(docXml, "IsAuditingInfoMessage"));
            AuditingInfoMessageTitle = GetNodeValue(docXml, "AuditingInfoMessageTitle");
            AuditingInfoMessageContent = GetNodeValue(docXml, "AuditingInfoMessageContent");
            IsAuditingUserEmail = MyConvert.GetBoolean(GetNodeValue(docXml, "IsAuditingUserEmail"));
            IsGuestLookLinkInfo = MyConvert.GetBoolean(GetNodeValue(docXml, "IsGuestLookLinkInfo"));
            IsJobEmail = MyConvert.GetBoolean(GetNodeValue(docXml, "IsJobEmail"));
            IsAddMoneyEmail = MyConvert.GetBoolean(GetNodeValue(docXml, "IsAddMoneyEmail"));
            IsJobMessage = MyConvert.GetBoolean(GetNodeValue(docXml, "IsJobMessage"));
            JobMessageTitle = GetNodeValue(docXml, "JobMessageTitle");
            JobMessageContent = GetNodeValue(docXml, "JobMessageContent");
            IsBidEmail = MyConvert.GetBoolean(GetNodeValue(docXml, "IsBidEmail"));
            isBidMessage = MyConvert.GetBoolean(GetNodeValue(docXml, "IsBidMessage"));
            BidMessageTitle = GetNodeValue(docXml, "BidMessageTitle");
            BidMessageContent = GetNodeValue(docXml, "BidMessageContent");
            BidKeyWordDefaultPercent = MyConvert.GetInt32(GetNodeValue(docXml, "BidKeyWordDefaultPercent"));
            //BidMoneyType = MyConvert.GetBoolean(GetNodeValue(docXml, "BidMoneyType"));
            IsAddMoneyMessage = MyConvert.GetBoolean(GetNodeValue(docXml, "IsAddMoneyMessage"));
            AddMoneyMessageTitle = GetNodeValue(docXml, "AddMoneyMessageTitle");
            AddMoneyMessageContent = GetNodeValue(docXml, "AddMoneyMessageContent");
            IsOrderEmail = MyConvert.GetBoolean(GetNodeValue(docXml, "IsOrderEmail"));
            IsOrderMessage = MyConvert.GetBoolean(GetNodeValue(docXml, "IsOrderMessage"));
            OrderMessageTitle = GetNodeValue(docXml, "OrderMessageTitle");
            OrderMessageContent = GetNodeValue(docXml, "OrderMessageContent");
            systemMessageNumber = MyConvert.GetInt32(GetNodeValue(docXml, "SystemMessageNumber"));
            //productNameNumber = MyConvert.GetInt32(GetNodeValue(docXml, "ProductNameNumber"));
            //NewsTypeNum = MyConvert.GetInt32(GetNodeValue(docXml, "NewsTypeNum"));
            adminFolder = GetNodeValue(docXml, "AdminFolder");
            isRun = MyConvert.GetBoolean(GetNodeValue(docXml, "IsRun"));
            siteCloseTip = GetNodeValue(docXml, "SiteCloseTip");
            aboutInfoNum = MyConvert.GetInt32(GetNodeValue(docXml, "AboutInfoNum"));
            aboutNewsNum = MyConvert.GetInt32(GetNodeValue(docXml, "AboutNewsNum"));


            cookieDomain = GetNodeValue(docXml, "CookieDomain");
            isTradeDomain = MyConvert.GetBoolean(GetNodeValue(docXml, "IsTradeDomain"));
            isAreaDomain = MyConvert.GetBoolean(GetNodeValue(docXml, "IsAreaDomain"));
            isTopicDomain = MyConvert.GetBoolean(GetNodeValue(docXml, "IsTopicDomain"));
            isProTypeDomain = MyConvert.GetBoolean(GetNodeValue(docXml, "IsProTypeDomain"));
            isAutoGatherSearchKey = MyConvert.GetBoolean(GetNodeValue(docXml, "IsAutoGatherSearchKey"));
            canChooseTradeNumber = MyConvert.GetInt32(GetNodeValue(docXml, "CanChooseTradeNumber"));
            //���뻺��
            string depFile = System.Web.HttpContext.Current.Server.MapPath("/config/webInfo.config");
            if (cache["WebInfo"] != null) cache.Remove("WebInfo");
            cache.Insert("WebInfo", this, new System.Web.Caching.CacheDependency(depFile));
        }

        /// <summary>
        /// ���������ļ�
        /// </summary>
        /// <returns>true:�ɹ�,false:ʧ��</returns>
        public override bool Update()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/WebInfo.config"));
            SetNodeValue(docXml, "WebName", WebName);
            SetNodeValue(docXml, "WebLogo", webLogo);
            SetNodeValue(docXml, "WebDomain", WebDomain);
            SetNodeValue(docXml, "WebSuffix", WebSuffix);
            SetNodeValue(docXml, "IsBogusStatic", IsBogusStatic);
            SetNodeValue(docXml, "StaticPageSuffix", StaticPageSuffix);
            SetNodeValue(docXml, "IsDomain", IsDomain);
            SetNodeValue(docXml, "IsNewsDomain", IsNewsDomain);
            SetNodeValue(docXml, "WebMoneyName", WebMoneyName);
            SetNodeValue(docXml, "UploadFileType", UploadFileType);
            SetNodeValue(docXml, "UploadFileSize", UploadFileSize);
            SetNodeValue(docXml, "UploadImg", uploadImg);
            SetNodeValue(docXml, "UploadThumbnailImgFolder", uploadThumbnailImgFolder);
            SetNodeValue(docXml, "UploadThumbnailImg1", uploadThumbnailImg1);
            SetNodeValue(docXml, "UploadThumbnailImg2", uploadThumbnailImg2);
            SetNodeValue(docXml, "UploadThumbnailImg3", uploadThumbnailImg3);
            SetNodeValue(docXml, "UploadAdjunctType", UploadAdjunctType);
            SetNodeValue(docXml, "UploadAdjunctSize", UploadAdjunctSize);
            SetNodeValue(docXml, "Email", Email);
            SetNodeValue(docXml, "EmailServer", EmailServer);
            SetNodeValue(docXml, "EmailServerPort", emailServerPort);
            SetNodeValue(docXml, "EmailLoginName", EmailLoginName);
            SetNodeValue(docXml, "EmailPwd", EmailPwd);
            SetNodeValue(docXml, "IsWaterMark", IsWaterMark);
            SetNodeValue(docXml, "WaterMarkType", WaterMarkType);
            SetNodeValue(docXml, "WaterMarkContent", WaterMarkContent);
            SetNodeValue(docXml, "WaterMarkFont", WaterMarkFont);
            SetNodeValue(docXml, "WaterMarkFontSize", WaterMarkFontSize);
            SetNodeValue(docXml, "WaterMarkPlace", WaterMarkPlace);
            SetNodeValue(docXml, "WaterMarkColor", WaterMarkColor);
            SetNodeValue(docXml, "WaterMarkPicURL", WaterMarkPicURL);
            SetNodeValue(docXml, "WaterMarkPicPlace", WaterMarkPicPlace);
            SetNodeValue(docXml, "WaterMarkPicDiaphaneity", WaterMarkPicDiaphaneity);
            SetNodeValue(docXml, "WaterMarkPicBgColor", WaterMarkPicBgColor);
            SetNodeValue(docXml, "RegisterMode", registerMode);
            SetNodeValue(docXml, "IsRegister", IsRegister);
            SetNodeValue(docXml, "UserRegisterAuditingType", userRegisterAuditingType);
            SetNodeValue(docXml, "UserDefaultLevel", UserDefaultLevel);
            SetNodeValue(docXml, "ForbidName", ForbidName);
            SetNodeValue(docXml, "UserDefaultWebMoney", UserDefaultWebMoney);
            SetNodeValue(docXml, "IsRegisterEmail", IsRegisterEmail);
            SetNodeValue(docXml, "IsRegisterMessage", IsRegisterMessage);
            SetNodeValue(docXml, "RegisterMessageTitle", RegisterMessageTitle);
            SetNodeValue(docXml, "RegisterMessageContent", RegisterMessageContent);
            SetNodeValue(docXml, "IsAuditingUserMessage", IsAuditingUserMessage);
            SetNodeValue(docXml, "AuditingUserMessageTitle", AuditingUserMessageTitle);
            SetNodeValue(docXml, "AuditingUserMessageContent", AuditingUserMessageContent);
            SetNodeValue(docXml, "LoginAddScore", LoginAddScore);
            SetNodeValue(docXml, "LoginAddWebMoney", LoginAddWebMoney);
            SetNodeValue(docXml, "BaseDatumPercent", BaseDatumPercent);
            SetNodeValue(docXml, "AdvancedDatumPercent", AdvancedDatumPercent);
            SetNodeValue(docXml, "LicencePercent", LicencePercent);
            SetNodeValue(docXml, "CertificatePercent", CertificatePercent);
            SetNodeValue(docXml, "RegisterPercent", RegisterPercent);
            SetNodeValue(docXml, "MobilePercent", MobilePercent);
            SetNodeValue(docXml, "DepartmentPercent", DepartmentPercent);
            SetNodeValue(docXml, "CapitalPercent", CapitalPercent);
            SetNodeValue(docXml, "IssueInfoAddWebMoney", IssueInfoAddWebMoney);
            SetNodeValue(docXml, "EditInfoAuditingType", EditInfoAuditingType);
            SetNodeValue(docXml, "InsertInfoAuditingType", InsertInfoAuditingType);
            SetNodeValue(docXml, "RefreshInfoAddWebMoney", RefreshInfoAddWebMoney);
            SetNodeValue(docXml, "InfoEndTimeType", InfoEndTimeType);
            SetNodeValue(docXml, "IsAuditingInfoEmail", IsAuditingInfoEmail);
            SetNodeValue(docXml, "IsAuditingInfoMessage", IsAuditingInfoMessage);
            SetNodeValue(docXml, "AuditingInfoMessageTitle", AuditingInfoMessageTitle);
            SetNodeValue(docXml, "AuditingInfoMessageContent", AuditingInfoMessageContent);
            SetNodeValue(docXml, "IsAuditingUserEmail", IsAuditingUserEmail);
            SetNodeValue(docXml, "IsGuestLookLinkInfo", IsGuestLookLinkInfo);
            SetNodeValue(docXml, "IsJobEmail", IsJobEmail);
            SetNodeValue(docXml, "IsAddMoneyEmail", IsAddMoneyEmail);
            SetNodeValue(docXml, "IsJobMessage", IsJobMessage);
            SetNodeValue(docXml, "JobMessageTitle", JobMessageTitle);
            SetNodeValue(docXml, "JobMessageContent", JobMessageContent);
            SetNodeValue(docXml, "IsBidEmail", IsBidEmail);
            SetNodeValue(docXml, "IsBidMessage", IsBidMessage);
            SetNodeValue(docXml, "BidMessageTitle", BidMessageTitle);
            SetNodeValue(docXml, "BidMessageContent", BidMessageContent);
            SetNodeValue(docXml, "BidKeyWordDefaultPercent", BidKeyWordDefaultPercent);
            //SetNodeValue(docXml, "BidMoneyType", BidMoneyType);
            SetNodeValue(docXml, "IsAddMoneyMessage", IsAddMoneyMessage);
            SetNodeValue(docXml, "AddMoneyMessageTitle", AddMoneyMessageTitle);
            SetNodeValue(docXml, "AddMoneyMessageContent", AddMoneyMessageContent);
            SetNodeValue(docXml, "IsOrderEmail", IsOrderEmail);
            SetNodeValue(docXml, "IsOrderMessage", IsOrderMessage);
            SetNodeValue(docXml, "OrderMessageTitle", OrderMessageTitle);
            SetNodeValue(docXml, "OrderMessageContent", OrderMessageContent);
            SetNodeValue(docXml, "SystemMessageNumber", systemMessageNumber);
            //SetNodeValue(docXml, "ProductNameNumber", productNameNumber);
            //SetNodeValue(docXml, "NewsTypeNum", newsTypeNum);
            SetNodeValue(docXml, "IsRun", isRun);
            SetNodeValue(docXml, "SiteCloseTip", siteCloseTip);
            SetNodeValue(docXml, "AboutInfoNum", aboutInfoNum);
            SetNodeValue(docXml, "AboutNewsNum", aboutNewsNum);

            SetNodeValue(docXml, "CookieDomain", cookieDomain);
            SetNodeValue(docXml, "IsTradeDomain", isTradeDomain);
            SetNodeValue(docXml, "IsAreaDomain", isAreaDomain);
            SetNodeValue(docXml, "IsTopicDomain", isTopicDomain);
            SetNodeValue(docXml, "IsProTypeDomain", isProTypeDomain);
            SetNodeValue(docXml, "IsAutoGatherSearchKey", isAutoGatherSearchKey);
            SetNodeValue(docXml, "CanChooseTradeNumber", canChooseTradeNumber);

            try
            {
                docXml.Save(System.Web.HttpContext.Current.Server.MapPath("/Config/WebInfo.config"));
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Refresh();
            }
        }

        /// <summary>
        /// ��ȡ��̬ʵ��
        /// </summary>
        public static WebInfo Instance
        {
            get
            {
                if (cache["WebInfo"] == null)
                {
                    instance = new WebInfo();
                }
                else
                {
                    instance = (WebInfo)cache["WebInfo"];
                }
                //if (instance == null)
                //    instance = new WebInfo();

                return instance;
            }
        }

        private string webName;
        private string webDomain;
        private string webSuffix;
        private bool isBogusStatic;
        private string staticPageSuffix;
        private bool isDomain;
        private bool isNewsDomain;
        private string adminFolder;

        /// <summary>
        /// ��վ����
        /// </summary>
        public string WebName
        {
            get { return webName; }
            set { webName = value; }
        }
        /// <summary>
        /// ��վ����
        /// </summary>
        public string WebDomain
        {
            get { return webDomain; }
            set { webDomain = value; }
        }

        private string webLogo;
        /// <summary>
        /// ��վLogo��ַ
        /// </summary>
        public string WebLogo
        {
            get { return webLogo; }
            set { webLogo = value; }
        }
        /// <summary>
        /// ��վα��׺����
        /// </summary>
        public string WebSuffix
        {
            get { return webSuffix; }
            set { webSuffix = value; }
        }
        /// <summary>
        /// ����α��̬
        /// </summary>
        public bool IsBogusStatic
        {
            get { return isBogusStatic; }
            set { isBogusStatic = value; }
        }
        /// <summary>
        /// ��̬ҳ���׺��
        /// </summary>
        public string StaticPageSuffix
        {
            get { return staticPageSuffix; }
            set { staticPageSuffix = value; }
        }
        /// <summary>
        /// �Ƿ����ö�������(true������,false������)
        /// </summary>
        public bool IsDomain
        {
            get { return isDomain; }
            set { isDomain = value; }
        }

        /// <summary>
        /// �Ƿ�������Ѷ��Ŀ��������(true������,false������)
        /// </summary>
        public bool IsNewsDomain
        {
            get { return isNewsDomain; }
            set { isNewsDomain = value; }
        }

        /// <summary>
        /// ��̨�����ַ
        /// </summary>
        public string AdminFolder
        {
            get { return adminFolder; }
        }

        private string webMoneyName;
        /// <summary>
        /// ��վ��������
        /// </summary>
        public string WebMoneyName
        {
            get { return webMoneyName; }
            set { webMoneyName = value; }
        }

        private string uploadFileType;
        /// <summary>
        /// �����ϴ����ļ�����
        /// </summary>
        public string UploadFileType
        {
            get { return uploadFileType; }
            set { uploadFileType = value; }
        }
        private int uploadFileSize;
        /// <summary>
        /// �����ϴ��ļ���С
        /// </summary>
        public int UploadFileSize
        {
            get { return uploadFileSize; }
            set { uploadFileSize = value; }
        }
        private string uploadImg;
        /// <summary>
        /// �ϴ�ͼƬ�����ߴ磬���ڸĳߴ���ǿ���������óߴ�
        /// </summary>
        public string UploadImg
        {
            get { return uploadImg; }
            set { uploadImg = value; }
        }
        private string uploadThumbnailImgFolder;
        /// <summary>
        /// ��������ͼ�ĵ�ַ
        /// </summary>
        public string UploadThumbnailImgFolder
        {
            get { return uploadThumbnailImgFolder; }
            set { uploadThumbnailImgFolder = value; }
        }
        private string uploadThumbnailImg1;
        /// <summary>
        /// ��������ͼ1�Ĵ�С
        /// </summary>
        public string UploadThumbnailImg1
        {
            get { return uploadThumbnailImg1; }
            set { uploadThumbnailImg1 = value; }
        }
        private string uploadThumbnailImg2;
        /// <summary>
        /// ��������ͼ2�Ĵ�С
        /// </summary>
        public string UploadThumbnailImg2
        {
            get { return uploadThumbnailImg2; }
            set { uploadThumbnailImg2 = value; }
        }
        private string uploadThumbnailImg3;
        /// <summary>
        /// ��������ͼ3�Ĵ�С
        /// </summary>
        public string UploadThumbnailImg3
        {
            get { return uploadThumbnailImg3; }
            set { uploadThumbnailImg3 = value; }
        }
        private string uploadAdjunctType;
        /// <summary>
        /// �ϴ��������
        /// </summary>
        public string UploadAdjunctType
        {
            get { return uploadAdjunctType; }
            set { uploadAdjunctType = value; }
        }
        private int uploadAdjunctSize;
        /// <summary>
        /// �ϴ�������С
        /// </summary>
        public int UploadAdjunctSize
        {
            get { return uploadAdjunctSize; }
            set { uploadAdjunctSize = value; }
        }
        private string email;
        /// <summary>
        /// վ������
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string emailServer;
        /// <summary>
        /// SMTP��������ַ��IP
        /// </summary>
        public string EmailServer
        {
            get { return emailServer; }
            set { emailServer = value; }
        }

        private int emailServerPort;
        /// <summary>
        /// SMTP�������˿�
        /// </summary>
        public int EmailServerPort
        {
            get { return emailServerPort; }
            set { emailServerPort = value; }
        }

        private string emailLoginName;
        /// <summary>
        /// ��½��������
        /// </summary>
        public string EmailLoginName
        {
            get { return emailLoginName; }
            set { emailLoginName = value; }
        }
        private string emailPwd;
        /// <summary>
        /// ��½��������
        /// </summary>
        public string EmailPwd
        {
            get { return emailPwd; }
            set { emailPwd = value; }
        }
        private bool isWaterMark;
        /// <summary>
        /// �Ƿ�����ˮӡ(false����,True����)
        /// </summary>
        public bool IsWaterMark
        {
            get { return isWaterMark; }
            set { isWaterMark = value; }
        }
        private int waterMarkType;
        /// <summary>
        /// ˮӡ�ķ�ʽ(0Ϊ����ˮӡ,1ΪͼƬˮӡ)
        /// </summary>
        public int WaterMarkType
        {
            get { return waterMarkType; }
            set { waterMarkType = value; }
        }
        private string waterMarkContent;
        /// <summary>
        /// ����ˮӡ������
        /// </summary>
        public string WaterMarkContent
        {
            get { return waterMarkContent; }
            set { waterMarkContent = value; }
        }
        private string waterMarkFont;
        /// <summary>
        /// ����ˮӡ����������
        /// </summary>
        public string WaterMarkFont
        {
            get { return waterMarkFont; }
            set { waterMarkFont = value; }
        }
        private int waterMarkFontSize;
        /// <summary>
        /// ����ˮӡ�����ִ�С
        /// </summary>
        public int WaterMarkFontSize
        {
            get { return waterMarkFontSize; }
            set { waterMarkFontSize = value; }
        }
        private string waterMarkPlace;
        /// <summary>
        /// ����ˮӡ��λ��
        /// </summary>
        public string WaterMarkPlace
        {
            get { return waterMarkPlace; }
            set { waterMarkPlace = value; }
        }
        private string waterMarkColor;
        /// <summary>
        /// ����ˮӡ����ɫ
        /// </summary>
        public string WaterMarkColor
        {
            get { return waterMarkColor; }
            set { waterMarkColor = value; }
        }
        private string waterMarkPicURL;
        /// <summary>
        /// ͼƬˮӡ��ͼƬ��ַ
        /// </summary>
        public string WaterMarkPicURL
        {
            get { return waterMarkPicURL; }
            set { waterMarkPicURL = value; }
        }
        private string waterMarkPicPlace;
        /// <summary>
        /// ͼƬˮӡ���õ�λ��
        /// </summary>
        public string WaterMarkPicPlace
        {
            get { return waterMarkPicPlace; }
            set { waterMarkPicPlace = value; }
        }
        private float waterMarkPicDiaphaneity;
        /// <summary>
        /// ͼƬˮӡ��͸����
        /// </summary>
        public float WaterMarkPicDiaphaneity
        {
            get { return waterMarkPicDiaphaneity; }
            set { waterMarkPicDiaphaneity = value; }
        }
        private string waterMarkPicBgColor;
        /// <summary>
        /// ͼƬˮӡ�ĵ�ɫ
        /// </summary>
        public string WaterMarkPicBgColor
        {
            get { return waterMarkPicBgColor; }
            set { waterMarkPicBgColor = value; }
        }

        private string registerMode;
        /// <summary>
        /// �û�ע��ģʽ
        /// </summary>
        public string RegisterMode
        {
            get { return registerMode; }
            set { registerMode = value; }
        }


        private bool isRegister;
        /// <summary>
        /// �Ƿ�����ע��
        /// </summary>
        public bool IsRegister
        {
            get { return isRegister; }
            set { isRegister = value; }
        }
        private bool userRegisterAuditingType;
        /// <summary>
        /// �û�ע����˷�ʽ,true���Զ����,false���˹����
        /// </summary>
        public bool UserRegisterAuditingType
        {
            get { return userRegisterAuditingType; }
            set { userRegisterAuditingType = value; }
        }
        private int userDefaultLevel;
        /// <summary>
        /// Ĭ��ע���û��ȼ�
        /// </summary>
        public int UserDefaultLevel
        {
            get { return userDefaultLevel; }
            set { userDefaultLevel = value; }
        }
        private string forbidName;
        /// <summary>
        /// ��ֹע���û���
        /// </summary>
        public string ForbidName
        {
            get { return forbidName; }
            set { forbidName = value; }
        }
        private int userDefaultWebMoney;
        /// <summary>
        /// ע��ɹ�Ĭ������Ҹ���
        /// </summary>
        public int UserDefaultWebMoney
        {
            get { return userDefaultWebMoney; }
            set { userDefaultWebMoney = value; }
        }
        private bool isRegisterEmail;
        /// <summary>
        /// ע���Ƿ������ʼ�����
        /// </summary>
        public bool IsRegisterEmail
        {
            get { return isRegisterEmail; }
            set { isRegisterEmail = value; }
        }
        private bool isRegisterMessage;
        /// <summary>
        /// �Ƿ��Ͷ���
        /// </summary>
        public bool IsRegisterMessage
        {
            get { return isRegisterMessage; }
            set { isRegisterMessage = value; }
        }
        private string registerMessageTitle;
        /// <summary>
        /// ע��ɹ����ű���
        /// </summary>
        public string RegisterMessageTitle
        {
            get { return registerMessageTitle; }
            set { registerMessageTitle = value; }
        }
        private string registerMessageContent;
        /// <summary>
        /// ע��ɹ���������
        /// </summary>
        public string RegisterMessageContent
        {
            get { return registerMessageContent; }
            set { registerMessageContent = value; }
        }
        private bool isAuditingUserMessage;
        /// <summary>
        /// ����û���Ϣ�Ƿ��Ͷ���
        /// </summary>
        public bool IsAuditingUserMessage
        {
            get { return isAuditingUserMessage; }
            set { isAuditingUserMessage = value; }
        }
        private string auditingUserMessageTitle;
        /// <summary>
        /// ����û���Ϣ���Ͷ��ű���
        /// </summary>
        public string AuditingUserMessageTitle
        {
            get { return auditingUserMessageTitle; }
            set { auditingUserMessageTitle = value; }
        }
        private string auditingUserMessageContent;
        /// <summary>
        /// ����û���Ϣ���Ͷ�������
        /// </summary>
        public string AuditingUserMessageContent
        {
            get { return auditingUserMessageContent; }
            set { auditingUserMessageContent = value; }
        }
        private int loginAddScore;
        /// <summary>
        /// ��½���ӻ���
        /// </summary>
        public int LoginAddScore
        {
            get { return loginAddScore; }
            set { loginAddScore = value; }
        }
        private decimal loginAddWebMoney;
        /// <summary>
        /// ��¼����
        /// </summary>
        public decimal LoginAddWebMoney
        {
            get { return loginAddWebMoney; }
            set { loginAddWebMoney = value; }
        }
        private int baseDatumPercent;
        /// <summary>
        /// ��ɻ������ϱ���
        /// </summary>
        public int BaseDatumPercent
        {
            get { return baseDatumPercent; }
            set { baseDatumPercent = value; }
        }
        private int advancedDatumPercent;
        /// <summary>
        /// ��ɸ߼����ϱ���
        /// </summary>
        public int AdvancedDatumPercent
        {
            get { return advancedDatumPercent; }
            set { advancedDatumPercent = value; }
        }
        private int licencePercent;
        /// <summary>
        /// ���Ӫҵִ���ϴ�����
        /// </summary>
        public int LicencePercent
        {
            get { return licencePercent; }
            set { licencePercent = value; }
        }
        private int certificatePercent;
        /// <summary>
        /// �����һ���������ϴ�����
        /// </summary>
        public int CertificatePercent
        {
            get { return certificatePercent; }
            set { certificatePercent = value; }
        }
        private int registerPercent;
        /// <summary>
        /// ע��ɹ����ƶ�����ֵ
        /// </summary>
        public int RegisterPercent
        {
            get { return registerPercent; }
            set { registerPercent = value; }
        }
        private int mobilePercent;
        /// <summary>
        /// ����ֻ����ƶ�����ֵ
        /// </summary>
        public int MobilePercent
        {
            get { return mobilePercent; }
            set { mobilePercent = value; }
        }
        private int departmentPercent;
        /// <summary>
        /// ������ڲ������ƶ�����ֵ
        /// </summary>
        public int DepartmentPercent
        {
            get { return departmentPercent; }
            set { departmentPercent = value; }
        }
        private int capitalPercent;
        /// <summary>
        /// ���ע���ʱ����ƶ�����ֵ
        /// </summary>
        public int CapitalPercent
        {
            get { return capitalPercent; }
            set { capitalPercent = value; }
        }
        private decimal issueInfoAddWebMoney;
        /// <summary>
        /// �û�������Ϣ����
        /// </summary>
        public decimal IssueInfoAddWebMoney
        {
            get { return issueInfoAddWebMoney; }
            set { issueInfoAddWebMoney = value; }
        }
        private bool editInfoAuditingType;
        /// <summary>
        /// �޸���ҵ��Ϣ��˷�ʽ(True���Զ����,false���˹����)
        /// </summary>
        public bool EditInfoAuditingType
        {
            get { return editInfoAuditingType; }
            set { editInfoAuditingType = value; }
        }
        private bool insertInfoAuditingType;
        /// <summary>
        /// ������ҵ��Ϣ��˷�ʽ(True���Զ����,false���˹����)
        /// </summary>
        public bool InsertInfoAuditingType
        {
            get { return insertInfoAuditingType; }
            set { insertInfoAuditingType = value; }
        }
        private decimal refreshInfoAddWebMoney;
        /// <summary>
        /// ˢ��һ����Ϣ����
        /// </summary>
        public decimal RefreshInfoAddWebMoney
        {
            get { return refreshInfoAddWebMoney; }
            set { refreshInfoAddWebMoney = value; }
        }
        private bool infoEndTimeType;
        /// <summary>
        /// ��ҵ��Ϣ�����н���ʱ�䷽ʽ(true��ʱ���,false��ʱ���.Ĭ��ʱ���true)
        /// </summary>
        public bool InfoEndTimeType
        {
            get { return infoEndTimeType; }
            set { infoEndTimeType = value; }
        }
        private bool isAuditingInfoEmail;
        /// <summary>
        /// �����ҵ��Ϣ�Ƿ������ʼ�����(true������,false������)
        /// </summary>
        public bool IsAuditingInfoEmail
        {
            get { return isAuditingInfoEmail; }
            set { isAuditingInfoEmail = value; }
        }
        private bool isAuditingInfoMessage;
        /// <summary>
        /// �����ҵ��Ϣ�Ƿ�����վ�ڶ���(true������,false������)
        /// </summary>
        public bool IsAuditingInfoMessage
        {
            get { return isAuditingInfoMessage; }
            set { isAuditingInfoMessage = value; }
        }
        private string auditingInfoMessageTitle;
        /// <summary>
        /// �����ҵ��Ϣ����վ�ڶ�����Ϣ����
        /// </summary>
        public string AuditingInfoMessageTitle
        {
            get { return auditingInfoMessageTitle; }
            set { auditingInfoMessageTitle = value; }
        }
        private string auditingInfoMessageContent;
        /// <summary>
        /// �����ҵ��Ϣ����վ�ڶ�����Ϣ����
        /// </summary>
        public string AuditingInfoMessageContent
        {
            get { return auditingInfoMessageContent; }
            set { auditingInfoMessageContent = value; }
        }
        private bool isAuditingUserEmail;
        /// <summary>
        /// ����û���Ϣ�Ƿ����ʼ�(true������,false������)
        /// </summary>
        public bool IsAuditingUserEmail
        {
            get { return isAuditingUserEmail; }
            set { isAuditingUserEmail = value; }
        }
        private bool isGuestLookLinkInfo;
        /// <summary>
        /// �����ο��Ƿ���Բ鿴��ϵ��ʽ(true,���ԣ�false��������)
        /// </summary>
        public bool IsGuestLookLinkInfo
        {
            get { return isGuestLookLinkInfo; }
            set { isGuestLookLinkInfo = value; }
        }
        private bool isJobEmail;
        /// <summary>
        /// ��Ƹ��ְ�Ƿ��ʼ�
        /// </summary>
        public bool IsJobEmail
        {
            get { return isJobEmail; }
            set { isJobEmail = value; }
        }
        private bool isAddMoneyEmail;
        /// <summary>
        /// ��ֵ�Ƿ����ʼ�
        /// </summary>
        public bool IsAddMoneyEmail
        {
            get { return isAddMoneyEmail; }
            set { isAddMoneyEmail = value; }
        }
        private bool isJobMessage;
        /// <summary>
        /// ��Ƹ��ְ��Ϣ������ʾ
        /// </summary>
        public bool IsJobMessage
        {
            get { return isJobMessage; }
            set { isJobMessage = value; }
        }
        private string jobMessageTitle;
        /// <summary>
        /// ��Ƹ��ְ��Ϣ���ű���
        /// </summary>
        public string JobMessageTitle
        {
            get { return jobMessageTitle; }
            set { jobMessageTitle = value; }
        }
        private string jobMessageContent;
        /// <summary>
        /// ��Ƹ��ְ��Ϣ��������
        /// </summary>
        public string JobMessageContent
        {
            get { return jobMessageContent; }
            set { jobMessageContent = value; }
        }
        private bool isBidEmail;
        /// <summary>
        /// �����Ƿ����ʼ�
        /// </summary>
        public bool IsBidEmail
        {
            get { return isBidEmail; }
            set { isBidEmail = value; }
        }
        private bool isBidMessage;
        /// <summary>
        /// ������Ϣ������ʾ
        /// </summary>
        public bool IsBidMessage
        {
            get { return isBidMessage; }
            set { isBidMessage = value; }
        }
        private string bidMessageTitle;
        /// <summary>
        /// ������Ϣ���ű���
        /// </summary>
        public string BidMessageTitle
        {
            get { return bidMessageTitle; }
            set { bidMessageTitle = value; }
        }
        private string bidMessageContent;
        /// <summary>
        /// ������Ϣ��������
        /// </summary>
        public string BidMessageContent
        {
            get { return bidMessageContent; }
            set { bidMessageContent = value; }
        }
        private int bidKeyWordDefaultPercent;
        /// <summary>
        /// �ؼ��־�����Ԥ�������ٷֱȻ���ֵ
        /// </summary>
        public int BidKeyWordDefaultPercent
        {
            get { return bidKeyWordDefaultPercent; }
            set { bidKeyWordDefaultPercent = value; }
        }
        //private bool bidMoneyType;
        ///// <summary>
        ///// ��վ���۽��׻�������(true���ֽ�,false���������)
        ///// </summary>
        //public bool BidMoneyType
        //{
        //    get { return bidMoneyType; }
        //    set { bidMoneyType = value; }
        //}
        private bool isAddMoneyMessage;
        /// <summary>
        /// �û���ֵ��Ϣ��ʾ
        /// </summary>
        public bool IsAddMoneyMessage
        {
            get { return isAddMoneyMessage; }
            set { isAddMoneyMessage = value; }
        }
        private string addMoneyMessageTitle;
        /// <summary>
        /// �û���ֵ��Ϣ���ű���
        /// </summary>
        public string AddMoneyMessageTitle
        {
            get { return addMoneyMessageTitle; }
            set { addMoneyMessageTitle = value; }
        }
        private string addMoneyMessageContent;
        /// <summary>
        /// �û���ֵ��Ϣ��������
        /// </summary>
        public string AddMoneyMessageContent
        {
            get { return addMoneyMessageContent; }
            set { addMoneyMessageContent = value; }
        }
        private bool isOrderEmail;
        /// <summary>
        /// �����Ƿ����ʼ�
        /// </summary>
        public bool IsOrderEmail
        {
            get { return isOrderEmail; }
            set { isOrderEmail = value; }
        }
        private bool isOrderMessage;
        /// <summary>
        /// �����Ƿ�����(True,��,False,��)
        /// </summary>
        public bool IsOrderMessage
        {
            get { return isOrderMessage; }
            set { isOrderMessage = value; }
        }
        private string orderMessageTitle;
        /// <summary>
        /// ������Ϣ���ű���
        /// </summary>
        public string OrderMessageTitle
        {
            get { return orderMessageTitle; }
            set { orderMessageTitle = value; }
        }
        private string orderMessageContent;
        /// <summary>
        /// ������Ϣ��������
        /// </summary>
        public string OrderMessageContent
        {
            get { return orderMessageContent; }
            set { orderMessageContent = value; }
        }

        private int systemMessageNumber;

        /// <summary>
        /// ��ȡϵͳ����������Ϣ����
        /// </summary>
        public int SystemMessageNumber
        {
            get { return systemMessageNumber; }
            set { systemMessageNumber = value; }
        }

        //private int productNameNumber;

        ///// <summary>
        ///// ��Ʒ�������������������
        ///// </summary>
        //public int ProductNameNumber
        //{
        //    get { return productNameNumber; }
        //    set { productNameNumber = value; }
        //}

        //private int newsTypeNum;

        ///// <summary>
        ///// �û�ѡ��������Ŀ������(?????)
        ///// </summary>
        //public int NewsTypeNum
        //{
        //    get { return newsTypeNum; }
        //    set { newsTypeNum = value; }
        //}

        /// <summary>
        /// ��վ�Ƿ�������״̬
        /// </summary>
        private bool isRun;

        public bool IsRun
        {
            get { return isRun; }
            set { isRun = value; }
        }


        private string siteCloseTip;
        /// <summary>
        /// ��վ�ر���ʾ
        /// </summary>
        public string SiteCloseTip
        {
            get
            {
                if (string.IsNullOrEmpty(siteCloseTip) || siteCloseTip.Equals(""))
                    siteCloseTip = "վ������ά����....";

                return siteCloseTip;
            }
            set { siteCloseTip = value; }
        }

        private int aboutInfoNum;

        /// <summary>
        /// ��ز�Ʒ����ҵ��Ϣ��ȡ����
        /// </summary>
        public int AboutInfoNum
        {
            get { return aboutInfoNum; }
            set { aboutInfoNum = value; }
        }

        private int aboutNewsNum;
        /// <summary>
        /// ������Ŷ�ȡ����
        /// </summary>
        public int AboutNewsNum
        {
            get { return aboutNewsNum; }
            set { aboutNewsNum = value; }
        }



        private string cookieDomain;

        /// <summary>
        /// Cookie ��
        /// </summary>
        public string CookieDomain
        {
            get
            {
                return cookieDomain;
            }
            set
            {
                cookieDomain = value;
            }
        }

        private bool isTradeDomain;
        /// <summary>
        /// �Ƿ�������ҵվ��������
        /// </summary>
        public bool IsTradeDomain
        {
            get { return isTradeDomain; }
            set { isTradeDomain = value; }
        }

        private bool isAreaDomain;
        /// <summary>
        /// �Ƿ����õ���վ��������
        /// </summary>
        public bool IsAreaDomain
        {
            get { return isAreaDomain; }
            set { isAreaDomain = value; }
        }

        private bool isTopicDomain;
        /// <summary>
        /// �Ƿ�����ר���������
        /// </summary>
        public bool IsTopicDomain
        {
            get { return isTopicDomain; }
            set { isTopicDomain = value; }
        }


        private bool isProTypeDomain;

        /// <summary>
        /// �Ƿ����ò�Ʒ�����������
        /// </summary>
        public bool IsProTypeDomain
        {
            get { return isProTypeDomain; }
            set { isProTypeDomain = value; }
        }

        private bool isAutoGatherSearchKey;
        /// <summary>
        /// �Ƿ��Զ��ռ������ؼ���
        /// </summary>
        public bool IsAutoGatherSearchKey
        {
            get { return isAutoGatherSearchKey; }
            set { isAutoGatherSearchKey = value; }
        }

        private int canChooseTradeNumber;
        /// <summary>
        /// ����ѡ�����ҵ����
        /// </summary>
        public int CanChooseTradeNumber
        {
            get { return canChooseTradeNumber; }
            set { canChooseTradeNumber = value; }
        }

        /// <summary>
        /// ������ֹע����û���
        /// </summary>
        public void AddForbidName(string __forbidName)
        {
            __forbidName = __forbidName.Trim().ToLower();

            foreach (string s in this.forbidName.Split(','))
            {
                if (s.ToLower().Trim().Equals(__forbidName)) return;
            }

            if (this.forbidName.Equals(""))
                this.forbidName = __forbidName;
            else
                this.forbidName += "," + __forbidName;
        }

        /// <summary>
        /// ��ȡ������(��������)
        /// </summary>
        /// <param name="hostName">������</param>
        /// <returns></returns>
        public string GetSubDomain(string hostName)
        {
            return "http://" + hostName + GetShortDomain();
        }

        /// <summary>
        /// ��ȡ������(ȥ��www)
        /// </summary>
        /// <returns></returns>
        public string GetShortDomain()
        {
            return this.webDomain.Substring(this.webDomain.IndexOf('.'), this.webDomain.Length - this.webDomain.IndexOf('.'));
        }

        private int _slidesCount = 4;

        /// <summary>
        /// �����ϴ��Ļõ�Ƭ����
        /// </summary>
        public int SlidesCount
        {
            get { return _slidesCount; }
            set { _slidesCount = value; }
        }
    }
}
