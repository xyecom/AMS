using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Page.search
{
    /// <summary>
    /// 模板 search/buy.htm 代码类
    /// </summary>
    public class buy : ForeBasePage
    {
        public string yearnum = "";
        public string infoid = "";
        public string ghao = "086";
        
        //新增对象
        public XYECOM.Model.SupplyInfo offerinfo = new XYECOM.Model.SupplyInfo();
        public XYECOM.Model.DemandInfo machininginfo = new XYECOM.Model.DemandInfo();
        public XYECOM.Model.InviteBusinessmanInfo investmentinfo = new XYECOM.Model.InviteBusinessmanInfo();
        public XYECOM.Model.ServiecInfo serviceinfo = new XYECOM.Model.ServiecInfo();


        public XYECOM.Business.FiltrateKeyWord filtrateKeyWordBLL = new XYECOM.Business.FiltrateKeyWord();
        //public DataTable dtimg = new DataTable();
        private long curInfoUserId = 0;

        //淘汰对象 后期删除
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
        /// 为兼容，之后删除
        /// </summary>
        protected string areaname = "";
        public DataTable dtm;
        //系统快速留言类型
        public int smType = 0;

        //前缀
        [Obsolete]
        protected string prefix = "";
        //后缀
        [Obsolete]
        protected string postfix = "";

        protected XYECOM.Configuration.ModuleInfo module = null;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            seo.Robots = true;

            if (!pageinfo.IsPost)
            {
                //给旧的对象赋值，后期可以删除
                es = offerinfo;
                ed = machininginfo;
                ibi = investmentinfo;
                esi = serviceinfo;

                string infoFlag = XYECOM.Core.XYRequest.GetQueryString("flag");
                int lngInfoId = XYECOM.Core.MyConvert.GetInt32(XYECOM.Core.XYRequest.GetQueryString("infoid"));

                if (lngInfoId <= 0 || infoFlag == "")
                {
                    ShowErrorMsg("信息不存在或已被删除！");
                    return;
                }

                XYECOM.Configuration.SEOInfo seoInfo = null;

                module = moduleConfig.GetItem(infoFlag);

                
                //附件表名称
                string descTableName = "";

                //完整分类分类，主要用于SEO
                string allClassName = "";

                //信息分类Id
                long sortId =0;

                //求购信息
                if (module.EName.Equals("offer") || module.PEName.Equals("offer"))
                {
                    pageinfo.ModuleFlag = "offer";
                    linkmodule = "buyoffer";
                    descTableName = "i_Supply";

                    offerinfo = new XYECOM.Business.Supply().GetItem(lngInfoId);

                    if (offerinfo == null || offerinfo.AuditingState != XYECOM.Model.AuditingState.Passed)
                    { 
                        ShowErrorMsg("信息不存在或未通过审核！");
                        return;
                    }

                    //过滤关键字
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


                    titleinfo = "我对您在" + config.WebName + "发布的“" + offerinfo.Title + "”很感兴趣";

                    fieldbody = GetFiledInnerHTML(offerinfo.SortID, module.EName, offerinfo.FieldID);

                }
                
                //加工信息
                if (module.EName.Equals("venture") || module.PEName.Equals("venture"))
                {
                    pageinfo.ModuleFlag = "venture";
                    linkmodule = "buymachining";
                    descTableName = "i_Demand";

                    machininginfo = new XYECOM.Business.Demand().GetItem(lngInfoId);

                    if (machininginfo == null || machininginfo.AuditingState != XYECOM.Model.AuditingState.Passed)
                    { 
                        ShowErrorMsg("信息不存在或未通过审核！");
                        return;
                    }

                    //过滤关键字
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

                    titleinfo = "我对您在" + config.WebName + "发布的“" + machininginfo.Title + "”很感兴趣";

                    fieldbody = GetFiledInnerHTML(machininginfo.TypeId, module.EName, machininginfo.FieldID);

                }

                //招商信息
                if (module.EName.Equals("investment") || module.PEName.Equals("investment"))
                {
                    pageinfo.ModuleFlag = "investment";
                    linkmodule = "buyinvestment";
                    descTableName ="i_InviteBusinessmanInfo";

                    investmentinfo = new XYECOM.Business.InviteBusinessmanInfo().GetItem(lngInfoId);

                    if(investmentinfo ==null || investmentinfo.AuditingState != XYECOM.Model.AuditingState.Passed)
                    {
                        ShowErrorMsg("信息不存在或未通过审核！");
                        return;
                    }

                    //过滤关键字
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

                    titleinfo = "我对您在" + config.WebName + "发布的“" + investmentinfo.Title + "”很感兴趣";

                    fieldbody = GetFiledInnerHTML(investmentinfo.SortID, module.EName, investmentinfo.FieldID);
                }

                //服务信息
                if (module.EName.Equals("service") || module.PEName.Equals("service"))
                { 
                    pageinfo.ModuleFlag = "service";
                    linkmodule = "buyservice";
                    descTableName ="i_Surrogate";

                    serviceinfo = new XYECOM.Business.ServiceInfo().GetItem(lngInfoId);

                    if (serviceinfo == null || serviceinfo.AuditingState != XYECOM.Model.AuditingState.Passed)
                    {
                        ShowErrorMsg("信息不存在或未通过审核！");
                        return;
                    }

                    //过滤关键字
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

                    titleinfo = "我对您在" + config.WebName + "发布的“" + serviceinfo.Title + "”很感兴趣";

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

                //用户信息
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
        /// 跳转到错误页面
        /// </summary>
        /// <param name="message">信息</param>
        private void ShowErrorMsg(string message)
        {
            pageinfo.PageError = 1;
            pageinfo.MsgboxText = message;
            pageinfo.MsgboxURL = System.Web.HttpContext.Current.Request.UrlReferrer + "";
        }
        /// <summary>
        /// 获得用户信息
        /// </summary>
        /// <returns>用户信息实体对象</returns>
        protected Model.GeneralUserInfo GetUserInfo()
        {
            Model.GeneralUserInfo userinfo = base.GetUserInfo(curInfoUserId);

            userinfo.logo = Business.Attachment.GetInfoDefaultImgHref(XYECOM.Model.AttachmentItem.Logo, curInfoUserId);

            return userinfo;
        }

        #region 更新导航相关
        /// <summary>
        /// 更新导航相关
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <param name="typeId">类别编号</param>
        /// <returns>导航相关</returns>
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
