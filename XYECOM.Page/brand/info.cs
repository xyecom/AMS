using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Page.brand
{
    /// <summary>
    /// ģ�� brand/info.htm ������
    /// </summary>
    public class info : ForeBasePage
    {        
        public string infoid = "";
        public string linktype = "";
        public string ghao = "+86";
        public string uids = "";
	    public DataTable dtm ;

        //��ʱ���� �Ժ�ɾ��
        public XYECOM.Model.BrandInfo eb = new XYECOM.Model.BrandInfo();
        public XYECOM.Model.UserInfo eui = new XYECOM.Model.UserInfo();
        public XYECOM.Model.UserRegInfo eu = new XYECOM.Model.UserRegInfo();
        
        //��������
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
                        //���˹ؼ���
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
                        titleinfo = "�Ҷ�����" + config.WebName + "�����ġ�" + brandinfo.Title + "���ܸ���Ȥ";

                        
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

        #region ���µ������
        /// <summary>
        /// ���µ������
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="typeId">�����</param>
        /// <returns>�������</returns>
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
        /// ����ָ���û���ͨ����Ϣ
        /// </summary>
        /// <returns>ʵ�����</returns>
        protected Model.GeneralUserInfo GetUserInfo()
        {
            return base.GetUserInfo(curInfoUserId);
        }

    }
}
