using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace XYECOM.Label
{
    public class PartLabelManager : LabelManger
    {
        private static PartLabelManager instance = null;

        private static string labelName = "";

        private PartLabelManager() { }

        public static LabelManger GetInstance(string _labelName)
        {
            labelName = _labelName;

            instance = new PartLabelManager();

            return (LabelManger)instance;
        }

        public override string CreateHTML()
        {
            Model.PartLabelInfo labelInfo = new Business.PartLabel().GetItem(labelName);

            if (labelInfo == null)
            {
                return "专栏信息不存在或已经被删除！";
            }

            if (labelInfo.State != XYECOM.Model.AuditingState.Passed)
            {
                return "专栏信息尚未通过审核！";
            }

            if (DateTime.Now.CompareTo(labelInfo.BeginTime) < 0)
            {
                return "专栏展示时间未到！";
            }

            if (DateTime.Now.CompareTo(labelInfo.EndTime) >= 0)
            {
                return "专栏已过期！";
            }


            if (labelInfo.Body.Trim().Equals(""))
            {
                return "用户尚未匹配信息！";
            }


            return Analysis(labelInfo);
        }

        public string CreateHTMLForTest()
        {
            Model.PartLabelInfo labelInfo = new Business.PartLabel().GetItem(labelName);

            if (labelInfo == null)
            {
                return "专栏信息不存在或已经被删除！";
            }

            if (labelInfo.Body.Trim().Equals(""))
            {
                return "用户尚未匹配信息！";
            }

            return Analysis(labelInfo);
        }

        private string Analysis(Model.PartLabelInfo labelInfo)
        {
            string baseHTML = labelInfo.Body;

            string pageSuffix = config.WebSuffix;

            //供求，招商，加工，服务
            string linkUrl = "/search/{0}." + pageSuffix + "?flag={1}&infoId={2}";
            string bogueStaticLinkUrl = "/search/{0}-{1}-{2}." + pageSuffix;

            string newsUrl = "{0}newsinfo-{1}." + pageSuffix;


            Regex linkRegx = new Regex(@"\[link:(([a-zA-Z]+)\,(\d+))\]");

            string moduleName = "";
            int infoId = 0;
            string url = "";

            foreach (Match m in linkRegx.Matches(baseHTML))
            {
                moduleName = m.Groups[2].ToString();
                infoId = Core.MyConvert.GetInt32(m.Groups[3].ToString());

                if (moduleName.Equals("") || infoId <= 0)
                {
                    baseHTML = baseHTML.Replace(m.Groups[0].ToString(), "#");
                    continue;
                }

                if (moduleName.Equals("user"))
                {
                    Model.GeneralUserInfo userinfo = Business.CheckUser.GetUserInfo(infoId);

                    if (userinfo == null)
                    {
                        url = "#";
                    }
                    else
                    {
                        url = userinfo.shopindex;
                    }
                }
                else
                {
                    XYECOM.Configuration.ModuleInfo module = XYECOM.Configuration.Module.Instance.GetItem(moduleName);

                    Model.BaseInfo info = null;



                    if (module.EName.Equals("offer") || module.PEName.Equals("offer"))
                    {
                        info = new Business.Supply().GetItem(infoId);
                    }

                    if (module.EName.Equals("venture") || module.PEName.Equals("venture"))
                    {
                        info = new Business.Demand().GetItem(infoId);
                    }

                    if (module.EName.Equals("investment") || module.PEName.Equals("investment"))
                    {
                        info = new Business.InviteBusinessmanInfo().GetItem(infoId);
                    };

                    if (module.EName.Equals("service") || module.PEName.Equals("service"))
                    {
                        info = new Business.ServiceInfo().GetItem(infoId);
                    };

                    if (info == null)
                    {
                        url = "#";
                    }
                    else
                    {
                        Configuration.InfoType iType = XYECOM.Configuration.InfoType.Sell;

                        iType = module.GetInfoTypeEnum(info.InfoType);

                        string pageName = "sell";

                        if (iType == XYECOM.Configuration.InfoType.Buy) pageName = "buy";

                        if (XYECOM.Configuration.WebInfo.Instance.IsBogusStatic)
                        {
                            url = string.Format(bogueStaticLinkUrl, pageName, moduleName, infoId);
                        }
                        else
                        {
                            url = string.Format(linkUrl, pageName, moduleName, infoId);
                        }
                    }
                }

                baseHTML = baseHTML.Replace(m.Groups[0].ToString(), url);
            }

            return baseHTML;
        }
    }
}
