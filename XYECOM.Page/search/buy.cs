using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Page.search
{
    /// <summary>
    /// ģ�� search/buy.htm ������
    /// </summary>
    public class buy : ForeBasePage
    {
        public string yearnum = "";
        public string infoid = "";
        public string ghao = "086";
        
        //��������
        public XYECOM.Model.SupplyInfo offerinfo = new XYECOM.Model.SupplyInfo();
        public XYECOM.Model.DemandInfo machininginfo = new XYECOM.Model.DemandInfo();
        public XYECOM.Model.InviteBusinessmanInfo investmentinfo = new XYECOM.Model.InviteBusinessmanInfo();
        public XYECOM.Model.ServiecInfo serviceinfo = new XYECOM.Model.ServiecInfo();


        public XYECOM.Business.FiltrateKeyWord filtrateKeyWordBLL = new XYECOM.Business.FiltrateKeyWord();
        //public DataTable dtimg = new DataTable();
        private long curInfoUserId = 0;

        //��̭���� ����ɾ��
        public XYECOM.Model.SupplyInfo es;
        public XYECOM.Model.DemandInfo ed;
        public XYECOM.Model.InviteBusinessmanInfo ibi;
        public XYECOM.Model.ServiecInfo esi;
        public XYECOM.Model.UserInfo eui = new XYECOM.Model.UserInfo();
        public XYECOM.Model.UserRegInfo eu = new XYECOM.Model.UserRegInfo();


        public DataTable dtimg = new DataTable();
        public string titleinfo = "";
        public int uinformation = 0;
        public string fieldbody = "";
        public string offerurl = "";
        public string linkmodule = "";
        /// <summary>
        /// Ϊ���ݣ�֮��ɾ��
        /// </summary>
        protected string areaname = "";
        public DataTable dtm;
        //ϵͳ������������
        public int smType = 0;

        //ǰ׺
        [Obsolete]
        protected string prefix = "";
        //��׺
        [Obsolete]
        protected string postfix = "";

        protected XYECOM.Configuration.ModuleInfo module = null;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            seo.Robots = true;

            if (!pageinfo.IsPost)
            {
                //���ɵĶ���ֵ�����ڿ���ɾ��
                es = offerinfo;
                ed = machininginfo;
                ibi = investmentinfo;
                esi = serviceinfo;

                string infoFlag = XYECOM.Core.XYRequest.GetQueryString("flag");
                int lngInfoId = XYECOM.Core.MyConvert.GetInt32(XYECOM.Core.XYRequest.GetQueryString("infoid"));

                if (lngInfoId <= 0 || infoFlag == "")
                {
                    ShowErrorMsg("��Ϣ�����ڻ��ѱ�ɾ����");
                    return;
                }

                XYECOM.Configuration.SEOInfo seoInfo = null;

                module = moduleConfig.GetItem(infoFlag);

                
                //����������
                string descTableName = "";

                //����������࣬��Ҫ����SEO
                string allClassName = "";

                //��Ϣ����Id
                long sortId =0;

                //����Ϣ
                if (module.EName.Equals("offer") || module.PEName.Equals("offer"))
                {
                    pageinfo.ModuleFlag = "offer";
                    linkmodule = "buyoffer";
                    descTableName = "i_Supply";

                    offerinfo = new XYECOM.Business.Supply().GetItem(lngInfoId);

                    if (offerinfo == null || offerinfo.AuditingState != XYECOM.Model.AuditingState.Passed)
                    { 
                        ShowErrorMsg("��Ϣ�����ڻ�δͨ����ˣ�");
                        return;
                    }

                    //���˹ؼ���
                    FilterKeyWord(offerinfo);

                    sortId = offerinfo.SortID;

                    curInfoUserId = offerinfo.UserID;

                    seoInfo = SEO.GetInfoPageSEO(module.EName);

                    if (seoInfo != null)
                    {
                        seo.Title = seoInfo.Title.Replace("{keyword}", offerinfo.Title);
                        seo.Description = seoInfo.Description.Replace("{keyword}", offerinfo.Title);
                        seo.Keywords = seoInfo.Keywords.Replace("{keyword}", offerinfo.SortName);

                        if (seoInfo.IsMatch)
                        {
                            allClassName = GetAllClassNameForSEO(infoFlag, offerinfo.SortID);

                            seo.Title += "_" + allClassName;
                            seo.Description += "," + allClassName;
                            seo.Keywords += "," + allClassName.Replace("_",",");
                        }
                    }
                    if (seo.Title.Equals("")){ seo.Title = offerinfo.Title; }


                    titleinfo = "�Ҷ�����" + config.WebName + "�����ġ�" + offerinfo.Title + "���ܸ���Ȥ";

                    fieldbody = GetFiledInnerHTML(offerinfo.SortID, module.EName, offerinfo.FieldID);

                }
                
                //�ӹ���Ϣ
                if (module.EName.Equals("venture") || module.PEName.Equals("venture"))
                {
                    pageinfo.ModuleFlag = "venture";
                    linkmodule = "buymachining";
                    descTableName = "i_Demand";

                    machininginfo = new XYECOM.Business.Demand().GetItem(lngInfoId);

                    if (machininginfo == null || machininginfo.AuditingState != XYECOM.Model.AuditingState.Passed)
                    { 
                        ShowErrorMsg("��Ϣ�����ڻ�δͨ����ˣ�");
                        return;
                    }

                    //���˹ؼ���
                    FilterKeyWord(machininginfo);

                    sortId = machininginfo.TypeId;

                    curInfoUserId = machininginfo.UserID;

                    seoInfo = SEO.GetInfoPageSEO(module.EName);

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

                    if (seo.Title.Equals("")){seo.Title = machininginfo.Title;}

                    titleinfo = "�Ҷ�����" + config.WebName + "�����ġ�" + machininginfo.Title + "���ܸ���Ȥ";

                    fieldbody = GetFiledInnerHTML(machininginfo.TypeId, module.EName, machininginfo.FieldID);

                }

                //������Ϣ
                if (module.EName.Equals("investment") || module.PEName.Equals("investment"))
                {
                    pageinfo.ModuleFlag = "investment";
                    linkmodule = "buyinvestment";
                    descTableName ="i_InviteBusinessmanInfo";

                    investmentinfo = new XYECOM.Business.InviteBusinessmanInfo().GetItem(lngInfoId);

                    if(investmentinfo ==null || investmentinfo.AuditingState != XYECOM.Model.AuditingState.Passed)
                    {
                        ShowErrorMsg("��Ϣ�����ڻ�δͨ����ˣ�");
                        return;
                    }

                    //���˹ؼ���
                    FilterKeyWord(investmentinfo);

                    sortId = investmentinfo.SortID;

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
                    linkmodule = "buyservice";
                    descTableName ="i_Surrogate";

                    serviceinfo = new XYECOM.Business.ServiceInfo().GetItem(lngInfoId);

                    if (serviceinfo == null || serviceinfo.AuditingState != XYECOM.Model.AuditingState.Passed)
                    {
                        ShowErrorMsg("��Ϣ�����ڻ�δͨ����ˣ�");
                        return;
                    }

                    //���˹ؼ���
                    FilterKeyWord(serviceinfo);

                    sortId = serviceinfo.SortID;

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

                UpdateNavigation(module.EName, sortId);

                offerinfo.SellBuy = machininginfo.SellBuy = investmentinfo.SellBuy = serviceinfo.SellBuy = "buy";                

                if (lngInfoId > 0)
                {
                    dtimg = XYECOM.Core.Function.GetDataTable(" where DescTabID=" + lngInfoId + " and DescTabName='"+descTableName+"' and At_Index > 1 ", " ", "XYV_Attachment");
                }

                if (SEO.IsAppendWebName)
                {
                    seo.Title = seo.Title + "_" + webInfo.WebName;
                    seo.Description = seo.Description + "," + webInfo.WebName;
                    seo.Keywords = seo.Keywords + "," + webInfo.WebName;
                }

                infoid = lngInfoId +"";

                dtm = GetExpressMessage(module.EName);

                //�û���Ϣ
                if (curInfoUserId > 0)
                {                    
                    XYECOM.Business.UserInfo ui = new XYECOM.Business.UserInfo();
                    eui = ui.GetItem(Convert.ToInt64(curInfoUserId));

                    try
                    {
                        areaname = eui.AreaInfo.FullNameAll;
                    }
                    catch { }

                    XYECOM.Business.UserReg ur = new XYECOM.Business.UserReg();
                    eu = ur.GetItem(Convert.ToInt64(curInfoUserId));
                    uinformation = eu.InFormation * 2;
                    yearnum = DateTime.Compare(DateTime.Now, eu.RegDate).ToString();
                }
            }
        }


        /// <summary>
        /// ��ת������ҳ��
        /// </summary>
        /// <param name="message">��Ϣ</param>
        private void ShowErrorMsg(string message)
        {
            pageinfo.PageError = 1;
            pageinfo.MsgboxText = message;
            pageinfo.MsgboxURL = System.Web.HttpContext.Current.Request.UrlReferrer + "";
        }
        /// <summary>
        /// ����û���Ϣ
        /// </summary>
        /// <returns>�û���Ϣʵ�����</returns>
        protected Model.GeneralUserInfo GetUserInfo()
        {
            Model.GeneralUserInfo userinfo = base.GetUserInfo(curInfoUserId);

            userinfo.logo = Business.Attachment.GetInfoDefaultImgHref(XYECOM.Model.AttachmentItem.Logo, curInfoUserId);

            return userinfo;
        }

        #region ���µ������
        /// <summary>
        /// ���µ������
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="typeId">�����</param>
        /// <returns>�������</returns>
        protected override string GetHref(string moduleName, long typeId)
        {
            string linkUrl = config.WebURL + "search/buyer_search." + config.suffix + "?flag={0}&pt_id={1}";
            string bogueStaticLinkUrl = config.WebURL + "search/buyer_search-{0}-{1}--------." + config.suffix;

            string strTypeId = typeId.ToString();

            if (typeId == 0) strTypeId = "";

            if (webInfo.IsBogusStatic)
            {
                return String.Format(bogueStaticLinkUrl, moduleName, strTypeId);
            }

            return String.Format(linkUrl, moduleName, strTypeId);
        }
        #endregion
    }
}
