using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 品牌标签解析类
    /// </summary>
    internal class BrandList : ContentLabelManager
    {
        protected override string GetCondition()
        {
            string strWhere = " where AuditingState = 1 and UserAuditingState=1 ";

            if (base.OuterParameter.AreaId > 0)
                strWhere += " and Area_id in (" + Business.XYClass.GetSubIds("area", base.OuterParameter.AreaId) + ")";

            if (base.OuterParameter.TradeId > 0)
                strWhere += " and charindex('," + base.OuterParameter.TradeId + ",',UserTradeIds) >0";



            if (base.ParamInfo.GetValue("点击次数") != "")
                strWhere += " and b_ClickNum >=" + base.ParamInfo.GetValue("点击次数");

            if (base.ParamInfo.GetValue("信息类别") != "")
            {
                strWhere += " and (PT_ID  = " + base.ParamInfo.GetValue("信息类别") + " Or charindex('," + base.ParamInfo.GetValue("信息类别") + ",',FullId) > 0)";
                //strWhere += " and PT_ID in(" + Business.XYClass.GetSubIds("brand", Core.MyConvert.GetInt64(base.ParamInfo.GetValue("信息类别"))) + ")";
            }

            if (base.ParamInfo.GetValue("是否推荐") != "")
                strWhere += " and B_Vouch=" + base.ParamInfo.GetValue("是否推荐");

            if (base.ParamInfo.GetValue("是否显示缩略图") == "1")
                strWhere += " and IsHasImage >0 ";

            if (base.ParamInfo.GetValue("是否显示缩略图") == "0")
                strWhere += " and IsHasImage =0 ";

            return strWhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "B_ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.L_StyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName, base._LabelInfo.L_StyleContent);

            //无信息类型之分
            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("调用数量") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("调用数量"));

            if (base.ParamInfo.GetValue("标题字数") != "")
                queryParam.TitleFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("标题字数"));

            if (base.ParamInfo.GetValue("日期格式") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("日期格式");

            if (base.ParamInfo.GetValue("品牌描述显示字数") != "")
                queryParam.ProductSummaryFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("品牌描述显示字数"));

            if (base.ParamInfo.GetValue("信息描述字数") != "")
                queryParam.CompanyNameFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("信息描述字数"));

            queryParam.Order = "Order by ";

            if (base.ParamInfo.GetValue("优先以会员等级排序") == "1")
                queryParam.Order += "UG_Order asc,";

            queryParam.Order += base.ParamInfo.GetValue("排序字段") + " " + base.ParamInfo.GetValue("排序方式") + " ";

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
