using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Page.area
{
    /// <summary>
    /// ģ�� area/index.htm ������
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
                    GotoMsgBoxPage("�ط�վ��Ϣ���ڻ��Ѿ���ɾ����", 5, config.WebURL);
                    return;
                }

                Model.AreaInfo area = new Business.Area().GetItem(info.AreaId);

                if (area != null) areaname = area.Name;
                //�����ⲿ����
                pageinfo.OuterAreaId = info.AreaId;
            }
        }
    }
}
