using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 招商结盟信息列表标签解析类
    /// </summary>
    internal class BusinessList : ContentLabelManager
    {
        protected override string GetCondition()
        {
            string strWhere = " where  AuditingState = 1 and UserAuditingState=1 and IBI_Pause = '1' and IBI_EndTime > '" + DateTime.Now + "' ";

            if (base.OuterParameter.AreaId > 0)
                strWhere += " and Area_id in (" + Business.XYClass.GetSubIds("area", base.OuterParameter.AreaId) + ")";

            if (base.OuterParameter.TradeId > 0)
                strWhere += " and charindex('," + base.OuterParameter.TradeId + ",',UserTradeIds) >0";



            if (base.ParamInfo.GetValue("点击次数") != "")
                strWhere += " and IBI_ClickNum >=" + base.ParamInfo.GetValue("点击次数");

            if (base.ParamInfo.GetValue("信息类别") != "")
            {
                string[] pars = base.ParamInfo.GetValue("信息类别").Split(':');

                if (pars[1].Equals("") || pars[1].Equals("0"))
                {
                    strWhere += " and moduleName='" + pars[0] + "'";
                }
                else
                {
                    strWhere += " and (IT_ID  = " + pars[1] + " Or Charindex('," + pars[1] + ",',FullID)>0)";
                }
            }

            if (base.ParamInfo.GetValue("是否推荐") != "")
                strWhere += " and IBI_Vouch=" + base.ParamInfo.GetValue("是否推荐");
            if (base.ParamInfo.GetValue("是否显示缩略图") == "1")
                strWhere += " and IsHasImage >0 ";
            if (base.ParamInfo.GetValue("是否显示缩略图") == "0")
                strWhere += " and IsHasImage =0 ";
            if (base.ParamInfo.GetValue("信息类型") != "0")
                strWhere += " and IBI_Sign=" + base.ParamInfo.GetValue("信息类型");

            return strWhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "IBI_ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName, base._LabelInfo.LabelStyleContent);

            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("调用数量") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("调用数量"));

            if (base.ParamInfo.GetValue("标题字数") != "")
                queryParam.TitleFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("标题字数"));

            if (base.ParamInfo.GetValue("日期格式") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("日期格式");

            if (base.ParamInfo.GetValue("信息描述显示字数") != "")
                queryParam.ProductSummaryFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("信息描述显示字数"));

            if (base.ParamInfo.GetValue("公司名称字数") != "")
                queryParam.CompanyNameFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("公司名称字数"));

            queryParam.InfoType = base.ParamInfo.GetValue("信息类型");

            queryParam.Order = "Order by ";

            if (base.ParamInfo.GetValue("优先以会员等级排序") == "1")
                queryParam.Order += "UG_Order asc,";

            queryParam.Order += base.ParamInfo.GetValue("排序字段") + " " + base.ParamInfo.GetValue("排序方式") + " "; ;

            return queryParam;
        }

        protected override System.Data.DataTable GetDataResult()
        {
            System.Data.DataTable table = XYECOM.Core.Function.GetDataTableForTop(PageSize,
                    base.QueryParamInfo.Columns,
                    base.QueryParamInfo.DataSourceName,
                    base.QueryParamInfo.Condition,
                    base.QueryParamInfo.Order);

            return table;
        }
    }
}
