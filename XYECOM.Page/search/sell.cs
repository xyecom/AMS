using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Page.search
{
    /// <summary>
    /// ģ�� search/sell.htm ������
    /// </summary>
    public class sell : ForeBasePage
    {
        public string infoid = "";
        public DataTable dtm;

        //��������
        public XYECOM.Model.SupplyInfo offerinfo = new XYECOM.Model.SupplyInfo();
        public XYECOM.Model.DemandInfo machininginfo = new XYECOM.Model.DemandInfo();
        public XYECOM.Model.InviteBusinessmanInfo investmentinfo = new XYECOM.Model.InviteBusinessmanInfo();
        public XYECOM.Model.ServiecInfo serviceinfo = new XYECOM.Model.ServiecInfo();

        public XYECOM.Business.FiltrateKeyWord filtrateKeyWordBLL = new XYECOM.Business.FiltrateKeyWord();

        public string titleinfo = "";
        public string fieldbody = "";
        public string offerurl = "";
        public string linkmodule = "";
        
        private long curInfoUserId = 0;

        private string curPage = "";

        private int lngInfoId = 0;

        /// <summary>
        /// Ϊ���ݣ�֮��ɾ��
        /// </summary>
        protected string areaname = "";

        //ģ����Ϣ
        protected XYECOM.Configuration.ModuleInfo module = null;


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            seo.Robots = true;

            //��ǰ��Ϣ���û�id
            
            if (!pageinfo.IsPost)
            {
                string infoFlag = XYECOM.Core.XYRequest.GetQueryString("flag");

                lngInfoId = XYECOM.Core.MyConvert.GetInt32(XYECOM.Core.XYRequest.GetQueryString("infoid"));

                curPage = XYECOM.Core.XYRequest.GetQueryString("curPage");

                if (infoFlag == "" || lngInfoId < 0)
                {
                    ShowErrorMsg("��Ϣ�����ڻ��ѱ�ɾ����");
                    return;
                }

                XYECOM.Business.FiltrateKeyWord filter = new XYECOM.Business.FiltrateKeyWord();

                XYECOM.Configuration.SEOInfo seoInfo = SEO.GetInfoPageSEO(infoFlag);
                                
                module = moduleConfig.GetItem(infoFlag);

                
                //����������࣬��Ҫ����SEO
                string allClassName = "";

                //��Ϣ����Id
                long classId = 0;

                //��ҵ��Ϣ
                if (module.EName.Equals("offer") || module.PEName.Equals("offer"))
                {
                    pageinfo.ModuleFlag = "offer";
                    
                    linkmodule = "selloffer";

                    offerinfo = new XYECOM.Business.Supply().GetItem(lngInfoId);

                    if (offerinfo == null || offerinfo.AuditingState != XYECOM.Model.AuditingState.Passed)
                    {
                        ShowErrorMsg("��Ϣ�����ڻ�δͨ����ˣ�");
                        return;
                    }
                    //���˹ؼ���
                    FilterKeyWord(offerinfo);

                    curInfoUserId = offerinfo.UserID;

                    classId = offerinfo.SortID;

                    if (seoInfo != null)
                    {
                        seo.Title =  seoInfo.Title.Replace("{keyword}", offerinfo.Title);
                        seo.Description = seoInfo.Description.Replace("{keyword}", offerinfo.Title);
                        seo.Keywords = seoInfo.Keywords.Replace("{keyword}", offerinfo.SortName);

                        if (seoInfo.IsMatch)
                        {
                            allClassName = GetAllClassNameForSEO(infoFlag,offerinfo.SortID);

                            seo.Title += "_" + allClassName;
                            seo.Description += "," + allClassName;
                            seo.Keywords += "," + allClassName.Replace("_",",");
                        }
                    }

                    if (seo.Title.Equals("")) { seo.Title = offerinfo.Title;}

                    titleinfo = "�Ҷ�����" + config.WebName + "�����ġ�" + offerinfo.Title + "���ܸ���Ȥ";

                    fieldbody = GetFiledInnerHTML(offerinfo.SortID, module.EName, offerinfo.FieldID);
                }

                //�ӹ�
                if (module.EName.Equals("venture") || module.PEName.Equals("venture"))
                {
                    
                    pageinfo.ModuleFlag = "venture";
                    linkmodule = "sellmachining";

                    machininginfo = new XYECOM.Business.Demand().GetItem(lngInfoId);
                    
                    if (machininginfo == null || machininginfo.AuditingState != XYECOM.Model.AuditingState.Passed)
                    {
                        ShowErrorMsg("��Ϣ�����ڻ�δͨ����ˣ�");
                        return;
                    }

                    //���˹ؼ���
                    FilterKeyWord(machininginfo);

                    classId = machininginfo.TypeId;

                    seoInfo = SEO.GetInfoPageSEO(module.EName);

                    curInfoUserId = machininginfo.UserID;

                    if (seoInfo != null)
                    {
                        seo.Title = seoInfo.Title.Replace("{keyword}", machininginfo.Title);
                        seo.Description = seoInfo.Description.Replace("{keyword}", machininginfo.Title);
                        seo.Keywords = seoInfo.Keywords.Replace("{keyword}", machininginfo.SortName);

                        if (seoInfo.IsMatch)
                        {
                            allClassName = GetAllClassNameForSEO(infoFlag, machininginfo.TypeId);

                            seo.Title += "_" + allClassName;
                            seo.Description += "," + allClassName;
                            seo.Keywords += "," + allClassName.Replace("_",",");
                        }
                    }

                    if (seo.Title.Equals("")) {seo.Title = machininginfo.Title;}

                    titleinfo = "�Ҷ�����" + config.WebName + "�����ġ�" + machininginfo.Title + "���ܸ���Ȥ";

                    fieldbody = GetFiledInnerHTML(machininginfo.TypeId, module.EName, machininginfo.FieldID);
                }

                //����
                if (module.EName.Equals("investment") || module.PEName.Equals("investment"))
                {
                    
                    pageinfo.ModuleFlag = "investment";
                    linkmodule = "sellinvestment";

                    investmentinfo = new XYECOM.Business.InviteBusinessmanInfo().GetItem(lngInfoId);

                    if (investmentinfo == null || investmentinfo.AuditingState != XYECOM.Model.AuditingState.Passed)
                    {
                        ShowErrorMsg("��Ϣ�����ڻ�δͨ����ˣ�");
                        return;
                    }

                    //���˹ؼ���
                    FilterKeyWord(investmentinfo);                    

                    classId = investmentinfo.SortID;

                    curInfoUserId = investmentinfo.UserID;

                    seoInfo = SEO.GetInfoPageSEO(module.EName);
                    if (seoInfo != null)
                    {
                        seo.Title = seoInfo.Title.Replace("{keyword}", investmentinfo.Title);
                        seo.Description = seoInfo.Description.Replace("{keyword}", investmentinfo.Title);
                        seo.Keywords = seoInfo.Keywords.Replace("{keyword}", investmentinfo.SortName);

                        if (seoInfo.IsMatch)
                        {
                            allClassName = GetAllClassNameForSEO(infoFlag, investmentinfo.SortID);

                            seo.Title += "_" + allClassName;
                            seo.Description += "," + allClassName;
                            seo.Keywords += "," + allClassName.Replace("_",",");
                        }
                    }

                    if (seo.Title.Equals("")){seo.Title = investmentinfo.Title;}

                    titleinfo = "�Ҷ�����" + config.WebName + "�����ġ�" + investmentinfo.Title + "���ܸ���Ȥ";

                    fieldbody = GetFiledInnerHTML(investmentinfo.SortID, module.EName, investmentinfo.FieldID);
                }

                //������Ϣ
                if (module.EName.Equals("service") || module.PEName.Equals("service"))
                {
                    
                    pageinfo.ModuleFlag = "service";
                    linkmodule = "sellservice";

                    serviceinfo = new XYECOM.Business.ServiceInfo().GetItem(lngInfoId);
                    if (serviceinfo == null || serviceinfo.AuditingState != XYECOM.Model.AuditingState.Passed)
                    {
                        ShowErrorMsg("��Ϣ�����ڻ�δͨ����ˣ�");
                        return;
                    }

                    //���˹ؼ���
                    FilterKeyWord(serviceinfo);

                    classId = serviceinfo.SortID;

                    curInfoUserId = serviceinfo.UserID;

                    seoInfo = SEO.GetInfoPageSEO(module.EName);

                    if (seoInfo != null)
                    {
                        seo.Title = seoInfo.Title.Replace("{keyword}", serviceinfo.Title);
                        seo.Description = seoInfo.Description.Replace("{keyword}", serviceinfo.Title);
                        seo.Keywords = seoInfo.Keywords.Replace("{keyword}", serviceinfo.SortName);

                        if (seoInfo.IsMatch)
                        {
                            allClassName = GetAllClassNameForSEO(infoFlag, serviceinfo.SortID);

                            seo.Title += "_" + allClassName;
                            seo.Description += "," + allClassName;
                            seo.Keywords += "," + allClassName.Replace("_",",");
                        }
                    }

                    if (seo.Title.Equals("")){seo.Title = serviceinfo.Title;}

                    titleinfo = "�Ҷ�����" + config.WebName + "�����ġ�" + serviceinfo.Title + "���ܸ���Ȥ";

                    fieldbody = GetFiledInnerHTML(serviceinfo.SortID, module.EName, serviceinfo.FieldID);
                }

                offerinfo.SellBuy = machininginfo.SellBuy = investmentinfo.SellBuy = serviceinfo.SellBuy = "sell";

                if (SEO.IsAppendWebName)
                {
                    seo.Title = seo.Title + "_" + webInfo.WebName;
                    seo.Description = seo.Description + "," + webInfo.WebName;
                    seo.Keywords = seo.Keywords + "," + webInfo.WebName;
                }

                infoid = lngInfoId + "";
                    
                dtm = GetExpressMessage(module.EName);

               
                UpdateNavigation(module.EName, classId);
            }
        }
        /// <summary>
        /// ��ȡ��Ϣ��Ĭ��ͼƬ��ַ
        /// </summary>
        /// <returns>��Ϣ��Ĭ��ͼƬ��ַ</returns>
        protected Model.GeneralUserInfo GetUserInfo()
        {
            Model.GeneralUserInfo userinfo = base.GetUserInfo(curInfoUserId);

            userinfo.logo = Business.Attachment.GetInfoDefaultImgHref(XYECOM.Model.AttachmentItem.Logo, curInfoUserId);

            return userinfo;
        }

        /// <summary>
        /// ��ת������ҳ��
        /// </summary>
        /// <param name="message"></param>
        private void ShowErrorMsg(string message)
        {
            pageinfo.PageError = 1;
            pageinfo.MsgboxText = message;
            pageinfo.MsgboxURL = System.Web.HttpContext.Current.Request.UrlReferrer + "";
        }

        /// <summary>
        /// ��ʼ����ز�Ʒ��Ϣ
        /// </summary>
        protected DataTable GetAboutInfo()
        {
            int _TopNumber = webInfo.AboutInfoNum;
            if (_TopNumber <= 0) _TopNumber = 5;
            if (_TopNumber >50)_TopNumber = 50;

            return Business.XYInfo.GetAboutInfo(module.EName, curInfoUserId, _TopNumber, lngInfoId);
        }
    }
}
