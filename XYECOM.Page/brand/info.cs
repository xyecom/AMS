using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Page.brand
{
    /// <summary>
    /// 模板 brand/info.htm 代码类
    /// </summary>
    public class info : ForeBasePage
    {        
        public string infoid = "";
        public string linktype = "";
        public string ghao = "+86";
        public string uids = "";
	    public DataTable dtm ;

        //过时属性 以后删除
        public XYECOM.Model.BrandInfo eb = new XYECOM.Model.BrandInfo();
        public XYECOM.Model.UserInfo eui = new XYECOM.Model.UserInfo();
        public XYECOM.Model.UserRegInfo eu = new XYECOM.Model.UserRegInfo();
        
        //新增属性
        public XYECOM.Model.BrandInfo brandinfo = new XYECOM.Model.BrandInfo();

        public XYECOM.Business.FiltrateKeyWord filtrateKeyWordBLL = new XYECOM.Business.FiltrateKeyWord();
        public DataTable dtimg = new DataTable();
        public string titleinfo = "";
        public string moduleflag = "";
        public string linkmodule = "";

        private long curInfoUserId = 0;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!pageinfo.IsPost)
            {
                //this.pageinfo.OnLoadEvents +="GetClickNum();";
                eb = brandinfo;
                moduleflag = "brand";
                linkmodule = "brand";

                pageinfo.ModuleFlag = moduleflag;

                if (XYECOM.Core.XYRequest.GetQueryString("infoid") != "")
                {
                    dtm = GetExpressMessage("brand");

                    seo.Robots = true;
                    
                    infoid = XYECOM.Core.XYRequest.GetQueryString("infoid");
                    dtimg = XYECOM.Core.Function.GetDataTable(" where DescTabID=" + XYECOM.Core.XYRequest.GetQueryString("infoid") + " and DescTabName='u_Barnd' and At_Index > 1 ", " ", "XYV_Attachment");

                    XYECOM.Business.Brand b = new XYECOM.Business.Brand();

                    brandinfo = b.GetItem(Convert.ToInt64(XYECOM.Core.XYRequest.GetQueryString("infoid")));

                    if (brandinfo != null)
                    {
                        //过滤关键字
                        FilterKeyWord(brandinfo);
                        
                        seo.Title = brandinfo.Title;

                        curInfoUserId = brandinfo.UserID;

                        UpdateNavigation("brand",brandinfo.SortID);

                        XYECOM.Configuration.SEOInfo seoInfo = SEO.GetInfoPageSEO("brand");

                        if (seoInfo!=null)
                        {
                            seo.Title = seoInfo.Title.Replace("{keyword}", brandinfo.Title);
                            seo.Description = seoInfo.Description.Replace("{keyword}", brandinfo.Title);
                            seo.Keywords = seoInfo.Keywords.Replace("{keyword}", brandinfo.Title);

                            if (seoInfo.IsMatch)
                            {
                                string allClassName = GetAllClassNameForSEO("brand", brandinfo.SortID);

                                seo.Title += "_" + allClassName;
                                seo.Description += "_" + allClassName;
                                seo.Keywords += "," + allClassName.Replace("_",",");
                            }
                        }

                        if (seo.Title.Equals("")) seo.Title = brandinfo.Title;

                        if (SEO.IsAppendWebName)
                        {
                            seo.Title = seo.Title + "_" + webInfo.WebName;
                            seo.Description = seo.Description + "," + webInfo.WebName;
                            seo.Keywords = seo.Keywords + "," + webInfo.WebName;
                        }

                        uids = brandinfo.UserID.ToString();
                        titleinfo = "我对您在" + config.WebName + "发布的“" + brandinfo.Title + "”很感兴趣";

                        
                        eui = new XYECOM.Business.UserInfo().GetItem(brandinfo.UserID);
                        eu = new XYECOM.Business.UserReg().GetItem(brandinfo.UserID);
                    }
                }
                if (curInfoUserId > 0)
                {
                    string onLoadText = "GetClickNum('" + linkmodule + "','" + pageinfo.ModuleFlag + "','" + infoid + "','" + curInfoUserId + "')";
                    string attachScript = "GetClickNum('" + linkmodule + "','" + pageinfo.ModuleFlag + "','" + infoid + "','" + curInfoUserId + "','0')";

                    attachScript = attachScript.Replace("'", "\\'");

                    this.pageinfo.OnLoadEvents += onLoadText + ";attachScript('LoginUpdate','" + attachScript + "');";

                }
            }
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
            string linkUrl = config.WebURL + "search/seller_search." + config.suffix + "?flag=brand&pt_id={0}";
            string bogueStaticLinkUrl = config.WebURL + "/search/seller_search-brand-{0}--------." + config.suffix;

            string strClassId = typeId.ToString();

            if (typeId == 0) strClassId = "";

            if (webInfo.IsBogusStatic)
            {
                return String.Format(bogueStaticLinkUrl, strClassId);
            }

            return String.Format(linkUrl, strClassId);
        }
        #endregion
        /// <summary>
        /// 返回指定用户的通用信息
        /// </summary>
        /// <returns>实体对象</returns>
        protected Model.GeneralUserInfo GetUserInfo()
        {
            return base.GetUserInfo(curInfoUserId);
        }

    }
}
