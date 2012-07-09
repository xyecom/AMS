using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace XYECOM.Label
{
    /**************************************************
     * XYECOM.Label.ClassLabelManager.cs
     * 创建标识：TC 20081013
     * 
     * 功能描述：分类标签处理类
     * 
     *************************************************/

    /// <summary>
    /// 分类标签解析类
    /// </summary>
    public class ClassLabelManager:LabelManger
    {
        private static ClassLabelManager instance = null;

        private static string labelName = "";

        private ClassLabelManager() { }

        /// <summary>
        /// 获取标签解析类实例
        /// </summary>
        /// <param name="_labelName"></param>
        /// <returns></returns>
        public static LabelManger GetInstance(string _labelName)
        {
            labelName = _labelName;

            instance = new ClassLabelManager();

            return (LabelManger)instance;
        }

        /// <summary>
        /// 获取要替换的用户分类Id字符串
        /// 用户分类(行业分类)仅对产品信息有效
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <returns></returns>
        private string GetUserTypeIdStr(string moduleName)
        {
            XYECOM.Configuration.ModuleInfo mInfo = module.GetItem(moduleName);

            if (mInfo == null) return "";

            if (mInfo.EName.Equals("offer") || mInfo.PEName.Equals("offer"))
            {
                if (OuterParameter.TradeId > 0) return OuterParameter.TradeId.ToString();
            }

            return "";
        }

        /// <summary>
        /// 获取要要替换的地区Id字符串
        /// </summary>
        /// <returns></returns>
        private string GetAreaIdStr()
        {
            if (OuterParameter.AreaId > 0) return OuterParameter.AreaId.ToString();

            return  "";
        }

        /// <summary>
        /// 获取最终结果
        /// </summary>
        /// <returns></returns>
        public override string CreateHTML()
        {
            string pageSuffix = config.WebSuffix;

            //供求，招商，加工，服务，品牌，企业
            string linkUrl = config.WebDomain+ "search/seller_search." + pageSuffix + "?flag={0}&typeid={1}&usertypeid={2}&areaid={3}";
            string bogueStaticLinkUrl = config.WebDomain + "search/seller_search-{0}-{1}--{2}--{3}----." + pageSuffix;

            string buylinkUrl = config.WebDomain + "search/buyer_search." + pageSuffix + "?flag={0}&typeid={1}&usertypeid={2}&areaid={3}";
            string bogueStaticBuyLinkUrl = config.WebDomain + "search/buyer_search-{0}-{1}--{2}--{3}----." + pageSuffix;

            //职位
            string jobLinkUrl = config.WebDomain + "job/list." + pageSuffix + "?typeid={0}";
            string bogusStaticJobLinkUrl = config.WebDomain + "job/list-{0}-------." + pageSuffix;

            //新闻资讯搜索
            string newsSearchUrl = config.WebDomain + "search/news_search." + pageSuffix + "?typeid={0}";
            string bogueStaticNewsSearchUrl = config.WebDomain + "search/news_search--{0}------." + pageSuffix;

            //新闻频道列表
            string newsLinkUrl = config.WebDomain + "news/{0}channel." + pageSuffix + "?nt_id={1}";
            string bogusStaticNewsLinkUrl = config.WebDomain + "news/{0}channel-{1}." + pageSuffix;

            //百科
            string baikeLinkUrl = "/baike/list." + pageSuffix + "?typeid={0}";
            string bogusStaticbaikeLinkUrl = "/baike/list-{0}--." + pageSuffix;

            //地区导航
            //供求，招商，加工，服务，品牌，企业
            string areasellLinkUrl = config.WebDomain + "search/seller_search." + pageSuffix + "?flag={1}&areaid={0}";
            string areasellBogueStaticLinkUrl = config.WebDomain + "search/seller_search-{1}-----{0}----." + pageSuffix + "";

            string areabuyLinkUrl = config.WebDomain + "search/buyer_search." + pageSuffix + "?flag={1}&areaid={0}";
            string areabuyBogueStaticLinkUrl = config.WebDomain + "search/buyer_search-{1}-----{0}----." + pageSuffix + "";

            //按地区搜索职位信息导航
            string areajobLinkUrl = config.WebDomain + "job/list." + pageSuffix + "?areaid={0}";
            string areabogusStaticJobLinkUrl = config.WebDomain + "job/list--{0}------." + pageSuffix + "";

            //+++++++++++++  pro cate ++++++++++++++++++++++++++++

            string cateUrl = config.WebDomain + "cate/index." + pageSuffix + "?fn={0}";
            string bogueStaticCateUrl = config.WebDomain + "cate/{0}-index." + pageSuffix;
            string domainCateUrl = "http://{0}" + config.GetShortDomain(); 

            string _CateUrl = cateUrl;

            if (config.IsProTypeDomain)
                _CateUrl = domainCateUrl;
            else if (config.IsBogusStatic)
                _CateUrl = bogueStaticCateUrl;


            Regex cateLinkRegx = new Regex(@"\[cate-link:(([a-zA-Z]+)\,(\d+))\]");

            //++++++++++++++++++++++++++++++++++++++++++++++++++++


            Business.ClassLabel BLL = new XYECOM.Business.ClassLabel();

            Model.ClassLabelInfo clsLabelInfo = BLL.GetItem(labelName);

            if (clsLabelInfo == null) throw new XYECOM.Core.LabelException("标签解析错误！标签不存在或已被删除！");

            string labelBody = clsLabelInfo.Body;

            Regex jobLinkRegx = new Regex(@"\[job-link:(\d+)\]");

            Regex linkRegx = new Regex(@"\[link:(([a-zA-Z]+)\,(\d+))\]");

            Regex buylinkRegx = new Regex(@"\[buy-link:(([a-zA-Z]+)\,(\d+))\]");

            Regex newsLinkRegx = new Regex(@"\[news-link:(\d+)\]");

            Regex baikeLinkRegx = new Regex(@"\[baike-link:(\d+)\]");

            //add by liujia 2008-11-18 地区地址解析

            Regex areajob = new Regex(@"\[area-job:(\d+)\]");

            Regex areasell = new Regex(@"\[area-sell:(\d+),(\w+)\]");

            Regex areabuy = new Regex(@"\[area-buy:(\d+),(\w+)\]");

            //Add by tc 2009-5-20 地方站导航标签解析

            Regex asn = new Regex(@"\[ASN:(\d+)\]");

            string asnLinkUrl = config.WebDomain + "area/index." + pageSuffix + "?fn={0}";

            string bogusStaticASNLinkUrl = config.WebDomain + "area/{0}-index." + pageSuffix + "";

            string dASNLinkUrl = config.GetSubDomain("{0}");

            //add by tc 2009-05-31

            Regex tsn = new Regex(@"\[TSN:(\d+)\]");

            string tsnLinkUrl = config.WebDomain + "trade/index." + pageSuffix + "?fn={0}";

            string bogusStaticTSNLinkUrl = config.WebDomain + "trade/{0}-index." + pageSuffix + "";

            string dTSNLinkUrl = config.GetSubDomain("{0}");




            string userTypeIdStr = "";
            string areaIdStr = "";

            foreach (Match m in linkRegx.Matches(labelBody))
            {
                if (XYECOM.Configuration.WebInfo.Instance.IsBogusStatic)
                {
                    if (m.Groups[2].ToString().Equals("news"))
                    {
                        labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(bogueStaticNewsSearchUrl, m.Groups[3].ToString(),userTypeIdStr,areaIdStr));
                    }
                    else
                    {
                        userTypeIdStr = GetUserTypeIdStr(m.Groups[2].ToString());
                        areaIdStr = GetAreaIdStr();

                        labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(bogueStaticLinkUrl, m.Groups[2].ToString(), m.Groups[3].ToString(),userTypeIdStr,areaIdStr));
                    }
                }
                else
                {
                    if (m.Groups[2].ToString().Equals("news"))
                    {
                        labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(newsSearchUrl, m.Groups[3].ToString(),userTypeIdStr,areaIdStr));
                    }
                    else
                    {
                        userTypeIdStr = GetUserTypeIdStr(m.Groups[2].ToString());
                        areaIdStr = GetAreaIdStr();

                        labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(linkUrl, m.Groups[2].ToString(), m.Groups[3].ToString(),userTypeIdStr,areaIdStr));
                    }
                }
            }

            foreach (Match m in buylinkRegx.Matches(labelBody))
            {
                userTypeIdStr = GetUserTypeIdStr(m.Groups[2].ToString());
                areaIdStr = GetAreaIdStr();

                if (XYECOM.Configuration.WebInfo.Instance.IsBogusStatic)
                {
                    labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(bogueStaticBuyLinkUrl, m.Groups[2].ToString(), m.Groups[3].ToString(),userTypeIdStr,areaIdStr));
                }
                else
                {
                    labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(buylinkUrl, m.Groups[2].ToString(), m.Groups[3].ToString(),userTypeIdStr,areaIdStr));
                }
            }

            //Prodcut Cate
            string proFlagName = "";
            foreach (Match m in cateLinkRegx.Matches(labelBody))
            {
                long proTypeId = Core.MyConvert.GetInt64(m.Groups[3].ToString());

                if (proTypeId <= 0)
                {
                    labelBody = labelBody.Replace(m.Groups[0].ToString(), "#");
                    continue;
                }

                Model.ProductTypeInfo ptInfo = new Business.ProductType().GetItem(proTypeId);

                if (ptInfo == null)
                {
                    labelBody = labelBody.Replace(m.Groups[0].ToString(), "#");
                    continue;
                }

                proFlagName = ptInfo.FlagName.Trim();

                if (!proFlagName.Equals(""))
                {
                    labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(_CateUrl, proFlagName));
                    continue;
                }

                userTypeIdStr = GetUserTypeIdStr(m.Groups[2].ToString());
                areaIdStr = GetAreaIdStr();

                if (XYECOM.Configuration.WebInfo.Instance.IsBogusStatic)
                {
                    labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(bogueStaticLinkUrl, m.Groups[2].ToString(), m.Groups[3].ToString(), userTypeIdStr, areaIdStr));
                }
                else
                {
                    labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(linkUrl, m.Groups[2].ToString(), m.Groups[3].ToString(), userTypeIdStr, areaIdStr));
                }
            }

            foreach (Match m in jobLinkRegx.Matches(labelBody))
            {
                if (XYECOM.Configuration.WebInfo.Instance.IsBogusStatic)
                    labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(bogusStaticJobLinkUrl, m.Groups[1].ToString()));
                else
                    labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(jobLinkUrl, m.Groups[1].ToString()));
            }

            foreach (Match m in newsLinkRegx.Matches(labelBody))
            {
                int _NTID = XYECOM.Core.MyConvert.GetInt32(m.Groups[1].ToString());

                bool isHTML = false;

                string subChannelFolder = "";

                if (_NTID > 0)
                {
                    Model.NewsTitlesInfo channel = new Business.NewsTitles().GetItem(_NTID);
                    if (channel != null)
                    {
                        //如果已经生成静态页面则返回静态页面地址
                        if (channel.HTMLPage != string.Empty && channel.HTMLPage != "")
                        {
                            isHTML = true;
                            labelBody = labelBody.Replace(m.Groups[0].ToString(), XYECOM.Configuration.WebInfo.Instance.WebDomain + channel.HTMLPage);
                        }

                        subChannelFolder = channel.TempletFolderAddress.Trim();
                        if (!subChannelFolder.Equals("")) subChannelFolder = subChannelFolder + "/";
                    }
                }

                if (!isHTML)
                {
                    if (XYECOM.Configuration.WebInfo.Instance.IsBogusStatic)
                        labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(bogusStaticNewsLinkUrl, subChannelFolder,m.Groups[1].ToString()));
                    else
                        labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(newsLinkUrl, subChannelFolder,m.Groups[1].ToString()));
                }
            }

            //add by liujia 2008-11-18 地区地址解析
            foreach (Match m in areajob.Matches(labelBody))
            {
                if (XYECOM.Configuration.WebInfo.Instance.IsBogusStatic)
                    labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(areabogusStaticJobLinkUrl, m.Groups[1].ToString()));
                else
                    labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(areajobLinkUrl, m.Groups[1].ToString()));
            }

            //百科
            foreach (Match m in baikeLinkRegx.Matches(labelBody))
            {
                if (XYECOM.Configuration.WebInfo.Instance.IsBogusStatic)
                    labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(bogusStaticbaikeLinkUrl, m.Groups[1].ToString()));
                else
                    labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(baikeLinkUrl, m.Groups[1].ToString()));
            }

            foreach (Match m in areasell.Matches(labelBody))
            {
                if (XYECOM.Configuration.WebInfo.Instance.IsBogusStatic)
                    labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(areasellBogueStaticLinkUrl, m.Groups[1].ToString(), m.Groups[2].ToString()));
                else
                    labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(areasellLinkUrl, m.Groups[1].ToString(), m.Groups[2].ToString()));
            }

            foreach (Match m in areabuy.Matches(labelBody))
            {
                if (XYECOM.Configuration.WebInfo.Instance.IsBogusStatic)
                    labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(areabuyBogueStaticLinkUrl, m.Groups[1].ToString(), m.Groups[2].ToString()));
                else
                    labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(areabuyLinkUrl, m.Groups[1].ToString(), m.Groups[2].ToString()));
            }

            foreach (Match m in asn.Matches(labelBody))
            {
                int sId = Core.MyConvert.GetInt32(m.Groups[1].ToString());

                string flagName = new Business.AreaSite().GetItemBySiteId(sId).FlagName;

                if (XYECOM.Configuration.WebInfo.Instance.IsAreaDomain)
                {
                    labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(dASNLinkUrl, flagName));
                }
                else
                {
                    if (XYECOM.Configuration.WebInfo.Instance.IsBogusStatic)
                        labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(bogusStaticASNLinkUrl, flagName));
                    else
                        labelBody = labelBody.Replace(m.Groups[0].ToString(), string.Format(asnLinkUrl, flagName));
                }
            }

            return labelBody;
        }
    }
}
