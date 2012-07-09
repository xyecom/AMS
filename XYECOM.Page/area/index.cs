using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Page.area
{
    /// <summary>
    /// 模板 area/index.htm 代码类
    /// </summary>
    public class index:ForeBasePage
    {
        protected string areaname = "";

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!pageinfo.IsPost)
            {
                string flagName = XYECOM.Core.XYRequest.GetQueryString("fn");

                Model.AreaSiteInfo info = new Business.AreaSite().GetItemByFlagName(flagName);

                if (info == null)
                {
                    GotoMsgBoxPage("地方站信息不在或已经被删除！", 5, config.WebURL);
                    return;
                }

                Model.AreaInfo area = new Business.Area().GetItem(info.AreaId);

                if (area != null) areaname = area.Name;
                //传递外部参数
                pageinfo.OuterAreaId = info.AreaId;
            }
        }
    }
}
