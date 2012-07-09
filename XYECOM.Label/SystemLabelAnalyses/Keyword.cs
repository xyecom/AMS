using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// Keyword系统标签解析类【不推荐使用，请使用内容标签】
    /// </summary>
    internal class Keyword : SystemLabelManager
    {
        public override string CreateHTML()
        {
            string param = labelName.ToLower().Replace("keyword[", "").Replace("]", "").Replace("，", ",");

            string[] ps = param.Split(',');

            if (ps.Length < 2 || ps.Length > 3) throw new XYECOM.Core.LabelException("sys:keyword 标签错误，参数不完整");

            string moduleName = GetModuleEName(ps[0].ToString());

            if (moduleName.Equals("")) throw new XYECOM.Core.LabelException("sys:keyword 标签错误，参数错误");

            int number = XYECOM.Core.MyConvert.GetInt32(ps[1].ToString());

            if (number <= 0) number = 10;

            string strInfoType = "";

            XYECOM.Configuration.InfoType infoType = XYECOM.Configuration.InfoType.Sell;

            try
            {
                strInfoType = ps[2].ToString().ToLower().Trim();

                infoType = GetInfoType(strInfoType);
            }
            catch { }

            StringBuilder result = new StringBuilder("<ul>");

            System.Data.DataTable keyTable = null;

            if (moduleName.Equals("all"))
                keyTable = new XYECOM.Business.SearchKey().GetTopDataTable("", number);
            else
                keyTable = new XYECOM.Business.SearchKey().GetTopDataTable(moduleName, number);

            if (null == keyTable || keyTable.Rows.Count <= 0) return "";

            string pageSuffix = config.WebSuffix;

            string sellLinkUrl = "<li><a href='"+config.WebDomain+"search/seller_search." + pageSuffix + "?flag={0}&keyword={1}' target='_blank'>{2}</a></li>";
            string sellBogueStaticLinkUrl = "<li><a href='" + config.WebDomain + "search/seller_search-{0}--{1}-------." + pageSuffix + "' target='_blank'>{2}</a></li>";

            string buyLinkUrl = "<li><a href='" + config.WebDomain + "search/buyer_search." + pageSuffix + "?flag={0}&keyword={1}' target='_blank'>{2}</a></li>";
            string buyBogueStaticLinkUrl = "<li><a href='" + config.WebDomain + "search/buyer_search-{0}--{1}-------." + pageSuffix + "' target='_blank'>{2}</a></li>";

            string jobLinkUrl = "<li><a href='" + config.WebDomain + "job/list." + pageSuffix + "?keyword={0}' target='_blank'>{1}</a></li>";
            string bogusStaticJobLinkUrl = "<li><a href='" + config.WebDomain + "job/list-----{0}---." + pageSuffix + "' target='_blank'>{1}</a></li>";

            string newsLinkUrl = "<li><a href='" + config.WebDomain + "search/news_search." + pageSuffix + "?keyword={0}' target='_blank'>{1}</a></li>";
            string bogusStaticNewsLinkUrl = "<li><a href='" + config.WebDomain + "search/news_search---{0}-----." + pageSuffix + "' target='_blank'>{1}</a></li>";

            string srcUrl = "";

            //if (moduleName.Equals("news")
            //    || moduleName.Equals("job")
            //    || moduleName.Equals("brand")
            //    || moduleName.Equals("company")
            //    || moduleName.Equals("exhibition"))
            //    infoType = XYECOM.Configuration.InfoType.Sell;

            foreach (System.Data.DataRow row in keyTable.Rows)
            {
                string strModuleName = row["SK_Sort"].ToString();

                if (strModuleName.Equals("news") || strModuleName.Equals("job"))
                {
                    if (config.IsBogusStatic)
                        srcUrl = strModuleName.Equals("news") ? bogusStaticNewsLinkUrl : bogusStaticJobLinkUrl;
                    else
                        srcUrl = strModuleName.Equals("news") ? newsLinkUrl : jobLinkUrl;

                    result.Append(String.Format(srcUrl, row["SK_Name"].ToString(), row["SK_Name"].ToString()));
                }
                else if (strModuleName.Equals("brand") || strModuleName.Equals("company"))
                {
                    if (config.IsBogusStatic)
                        srcUrl = sellBogueStaticLinkUrl;
                    else
                        srcUrl = sellLinkUrl;

                    result.Append(String.Format(srcUrl, row["SK_Sort"].ToString(), row["SK_Name"].ToString(), row["SK_Name"].ToString()));
                }
                else
                {
                    if (config.IsBogusStatic)
                        srcUrl = infoType == XYECOM.Configuration.InfoType.Sell ? sellBogueStaticLinkUrl : buyBogueStaticLinkUrl;
                    else
                        srcUrl = infoType == XYECOM.Configuration.InfoType.Sell ? sellLinkUrl : buyLinkUrl;

                    result.Append(String.Format(srcUrl, row["SK_Sort"].ToString(), row["SK_Name"].ToString(), row["SK_Name"].ToString()));
                }
            }

            result.Append("</ul>");

            return result.ToString();
        }

        protected override string GetModuleEName(string name)
        {
            name = name.Trim().ToLower();

            if (name.Equals("all") || name.Equals("全部")) return "all";

            return base.GetModuleEName(name);
        }
    }
}
