using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Page.search
{
    public class buyinfo : ForeBasePage
    {
        public string yearnum = "";
        public string infoid = "";
        public string ghao = "086";

        //新增对象
        public XYECOM.Model.SupplyBuyInfo offerinfo = new XYECOM.Model.SupplyBuyInfo();


        public XYECOM.Business.FiltrateKeyWord filtrateKeyWordBLL = new XYECOM.Business.FiltrateKeyWord();
        //public DataTable dtimg = new DataTable();
        private long curInfoUserId = 0;

        //淘汰对象 后期删除
        public XYECOM.Model.SupplyBuyInfo es;

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
        protected Model.GeneralUserInfo userinfo2 = null;
        protected XYECOM.Configuration.ModuleInfo module = null;
        public string areanames = "";
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            seo.Robots = true;

            if (!pageinfo.IsPost)
            {
                //给旧的对象赋值，后期可以删除
                es = offerinfo;
                long lngInfoId = XYECOM.Core.MyConvert.GetInt64(XYECOM.Core.XYRequest.GetQueryString("sdid"));
                if (lngInfoId <= 0)
                {
                    ShowErrorMsg("信息不存在或已被删除！");
                    return;
                }
                pageinfo.ModuleFlag = "offer";
                linkmodule = "buyoffer";

                offerinfo = new XYECOM.Business.SupplyBuy().GetItem(lngInfoId);
                if (offerinfo != null)
                {
                    userinfo2 = base.GetUserInfo(offerinfo.Uid);
                    userinfo2.logo = Business.Attachment.GetInfoDefaultImgHref(XYECOM.Model.AttachmentItem.Logo, curInfoUserId);
                }
                XYECOM.Business.Area area = new Business.Area();
                areanames = "地区不详";
                if (offerinfo.Area_id > 0)
                {
                    areanames = area.GetItem(offerinfo.Area_id).Name;
                }

                if (offerinfo == null || offerinfo.State != 1)
                {
                    ShowErrorMsg("信息不存在或未通过审核！");
                    return;
                }
                titleinfo = "我对您在" + config.WebName + "发布的“" + offerinfo.Title + "”很感兴趣";

                if (SEO.IsAppendWebName)
                {
                    seo.Title = seo.Title + "_" + webInfo.WebName;
                    seo.Description = seo.Description + "," + webInfo.WebName;
                    seo.Keywords = seo.Keywords + "," + webInfo.WebName;
                }
                infoid = lngInfoId + "";

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
            userinfo2 = base.GetUserInfo(curInfoUserId);
            if (curInfoUserId > 0)
            {
                userinfo.logo = Business.Attachment.GetInfoDefaultImgHref(XYECOM.Model.AttachmentItem.Logo, curInfoUserId);
            }


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
            string linkUrl = config.WebURL + "search/butinfo." + config.suffix + "?pt_id={1}";
            string bogueStaticLinkUrl = config.WebURL + "search/butinfo-{0}." + config.suffix;

            string strTypeId = typeId.ToString();

            if (typeId == 0) strTypeId = "";

            if (webInfo.IsBogusStatic)
            {
                return String.Format(bogueStaticLinkUrl, strTypeId);
            }

            return String.Format(linkUrl, moduleName, strTypeId);
        }
        #endregion
    }
}
