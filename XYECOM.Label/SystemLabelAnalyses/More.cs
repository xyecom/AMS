using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// More 系统标签解析类
    /// </summary>
    internal class More:SystemLabelManager
    {
        /// <summary>
        /// 获取解析结果
        /// </summary>
        /// <returns></returns>
        public override string CreateHTML()
        {
            string param = labelName.ToLower().Replace("more[", "").Replace("]", "").Replace("，",",");

            string[] ps = param.Split(',');

            if (ps.Length < 2 || ps.Length > 3) throw new XYECOM.Core.LabelException("sys:more 标签错误,参数不完整");

            string moduleName = GetModuleEName(ps[0].ToString().Trim());

            string className = ps[1].ToString().Trim();

            if (moduleName.Equals("") || className.Equals(""))
                throw new XYECOM.Core.LabelException("sys:more 标签错误,参数不完整");

            string strInfoType = "";
            XYECOM.Configuration.InfoType infoType = XYECOM.Configuration.InfoType.Sell;

            try
            {
                strInfoType = ps[2].ToString().Trim();
                infoType = GetInfoType(strInfoType);
            }
            catch { }

            long classId = 0;
            if (Core.Utils.IsNumber(className)) { classId = Core.MyConvert.GetInt64(className); }

            Business.XYClass BLL = new XYECOM.Business.XYClass();

            Model.XYClassInfo clsInfo = null;

            if(classId >0)
                clsInfo = Business.XYClass.GetItem(moduleName,classId);
            else
                clsInfo = Business.XYClass.GetItem(moduleName, className);

            if (clsInfo == null) throw new XYECOM.Core.LabelException("sys:more 标签错误,分类不存在");

            string result = "";
            string pageSuffix = config.WebSuffix;
            bool isBogusStatic = config.IsBogusStatic;

            string linkUrl = "/search/seller_search." + pageSuffix + "?flag={0}&typeid={1}";
            string bogueStaticLinkUrl = "/search/seller_search-{0}-{1}--------." + pageSuffix;

            string buyLinkUrl = "/search/buyer_search." + pageSuffix + "?flag={0}&typeid={1}'";
            string buyBogueStaticLinkUrl = "/search/buyer_search-{0}-{1}--------." + pageSuffix;

            string jobLinkUrl = "/job/list." + pageSuffix + "?typeid={0}";
            string bogusStaticJobLinkUrl = "/job/list-{0}-------." + pageSuffix;

            string newsLinkUrl =  "/news/{0}channel." + pageSuffix + "?nt_id={1}";
            string bogusStaticNewsLinkUrl = "/news/{0}channel-{1}." + pageSuffix;

            if (moduleName.Equals("news"))
            {
                int _NTID = Convert.ToInt32(clsInfo.ClassId);

                string subChannelFolder ="";
                Model.NewsTitlesInfo channel = null;
                
                bool isHTML = false;
                if (_NTID > 0)
                {
                    channel = new Business.NewsTitles().GetItem(_NTID);

                    subChannelFolder =channel.TempletFolderAddress;
                    //如果已经生成静态页面则返回静态页面地址
                    if (channel != null && channel.HTMLPage != string.Empty && channel.HTMLPage != "")
                    {
                        isHTML = true;
                        result = XYECOM.Configuration.WebInfo.Instance.WebDomain + channel.HTMLPage;
                    }
                }
                string domain = XYECOM.Configuration.WebInfo.Instance.GetSubDomain(channel.DomainName);
                if (!isHTML)
                {
                    if (!subChannelFolder.Equals("")) subChannelFolder = subChannelFolder + "/";

                    if (isBogusStatic)
                    {
                        if (XYECOM.Configuration.WebInfo.Instance.IsNewsDomain && channel.DomainName !="")
                        {
                            result =  domain + "/channel-" + clsInfo.ClassId + "." + pageSuffix;
                        }
                        else
                        {
                            result = string.Format(bogusStaticNewsLinkUrl, subChannelFolder, clsInfo.ClassId);
                        }
                    }
                    else
                        if (XYECOM.Configuration.WebInfo.Instance.IsNewsDomain && channel.DomainName != "")
                        {
                            result =  domain + "/channel." + pageSuffix + "?nt_id=" + clsInfo.ClassId + "";
                        }else
                        {
                            result = string.Format(newsLinkUrl, subChannelFolder, clsInfo.ClassId);
                        }      
                }
            }
            else if (moduleName.Equals("job"))
            {
                if (isBogusStatic)
                {
                    result = string.Format(bogusStaticJobLinkUrl, clsInfo.ClassId);
                }
                else
                {
                    result = string.Format(jobLinkUrl, clsInfo.ClassId);
                }
            }
            else
            {
                string srcUlr = "";

                if (isBogusStatic)
                {
                    if (!strInfoType.Equals("") && infoType == XYECOM.Configuration.InfoType.Buy)
                        srcUlr = buyBogueStaticLinkUrl;
                    else
                        srcUlr = bogueStaticLinkUrl;
                }
                else
                {
                    if (!strInfoType.Equals("") && infoType == XYECOM.Configuration.InfoType.Buy)
                        srcUlr = buyLinkUrl;
                    else
                        srcUlr = linkUrl;
                }
                result = string.Format(srcUlr, moduleName, clsInfo.ClassId);
            }

            if (result.Equals("")) throw new Exception("sys:more 标签错误");

            return result;
        }
    }
}
