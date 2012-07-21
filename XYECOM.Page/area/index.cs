using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Page.area
{
    /// <summary>
    /// 模板 area/index.htm 代码类
    /// </summary>
    public class index : ForeBasePage
    {
        protected string areaname = string.Empty;
        protected DataTable zqdata = new DataTable();
        protected DataTable dzdata = new DataTable();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

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

            string price = string.Empty;
            string typeId = string.Empty;

            if (XYECOM.Core.XYRequest.IsPost())
            {
                string action = XYECOM.Core.XYRequest.GetFormString("btnSearch");

                if (action == "搜 索")
                {
                    price = XYECOM.Core.XYRequest.GetFormString("ddlBounty");
                }
                if (action == "搜索")
                {
                    typeId = XYECOM.Core.XYRequest.GetFormString("dzTypeId");
                }
            }

            zqdata = GetZqData(info.AreaId, price);
            dzdata = GetDzData(info.AreaId, typeId);

        }

        DataTable GetDzData(int areaId, string typeId)
        {
            return new DataTable();
        }
        DataTable GetZqData(int areaId, string price)
        {
            string sqlfmt = @"select CreditId,Title,Bounty,Arrears,AreaId,PassDate,
                        (select COUNT(1) from TenderInfo where CreditInfoId=CreditId) TenderCount,
                        (select Name from XY_Area where id=AreaId) AreaName
                        from CreditInfo
                        where AreaId= {0} and {1} and ApprovaStatus in (1,2,3,4,5,6)
                        order by  PassDate desc";

            string condation = " (1=1) ";

            if (!string.IsNullOrEmpty(price))
            {
                if (price == "1")
                {
                    condation = " (Arrears < 10000)";
                }
                if (price == "2")
                {
                    condation = " (Arrears > 100000 and Arrears < 500000)";
                }
                if (price == "3") { }
            }

            string sql = string.Format(sqlfmt, areaId, condation);
            return Core.Data.SqlHelper.ExecuteTable(sql);

        }
    }
}
