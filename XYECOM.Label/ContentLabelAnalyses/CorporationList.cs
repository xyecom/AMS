using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 企业信息列表标签解析类
    /// </summary>
    internal class CorporationList:ContentLabelManager
    {
        protected override string GetCondition()
        {
            string strWhere = " where  userAuditingState = 1";

            #region 外部参数处理相关
            
            if (base.OuterParameter.AreaId > 0)
                strWhere += " and Area_id in (" + Business.XYClass.GetSubIds("area", base.OuterParameter.AreaId) + ")";

            if (base.OuterParameter.TradeId > 0)
                strWhere += " and charindex('," + base.OuterParameter.TradeId + ",',TradeIds) >0";

            #endregion

            if (base.ParamInfo.GetValue("点击次数") != "")
                strWhere += " and U_ClickNum >=" + base.ParamInfo.GetValue("点击次数");

            if (base.ParamInfo.GetValue("企业类别") != "")
                strWhere += " and UT_ID in(" + Business.XYClass.GetSubIds("company", Core.MyConvert.GetInt64(base.ParamInfo.GetValue("企业类别"))) + ")";

            if (base.ParamInfo.GetValue("是否推荐") != "")
                strWhere += " and U_Vouch=" + base.ParamInfo.GetValue("是否推荐");

            if (base.ParamInfo.GetValue("是否显示缩略图") == "1")
                strWhere += " and UserIsHasImage >0 ";

            if (base.ParamInfo.GetValue("是否显示缩略图") == "0")
                strWhere += " and UserIsHasImage =0 ";

            if (base.ParamInfo.GetValue("用户等级") != "")
                strWhere += " and UG_ID=" + base.ParamInfo.GetValue("用户等级");

            return strWhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "U_ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName);

            //无信息类型之分
            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("调用数量") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("调用数量"));

            if (base.ParamInfo.GetValue("日期格式") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("日期格式");

            if (base.ParamInfo.GetValue("企业简介字数") != "")
                queryParam.CompanySummaryFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("企业简介字数"));

            if (base.ParamInfo.GetValue("企业名称字数") != "")
                queryParam.CompanyNameFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("企业名称字数"));

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
