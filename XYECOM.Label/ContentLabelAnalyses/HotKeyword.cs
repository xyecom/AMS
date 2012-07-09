using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 热门关键词列表标签解析类
    /// </summary>
    internal class HotKeyword : ContentLabelManager
    {
        protected override string GetCondition()
        {
            string strWhere = " where 1=1 ";

            if (base.ParamInfo.GetValue("所属模块") != "")
                strWhere += " and SK_Sort='" + base.ParamInfo.GetValue("所属模块") + "'";

            if (base.ParamInfo.GetValue("是否推荐") != "")
                strWhere += " and SK_IsCommend='" + base.ParamInfo.GetValue("是否推荐") + "'";

            return strWhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "SK_ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName);

            //无信息类型之分
            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("调用数量") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("调用数量"));

            if (base.ParamInfo.GetValue("链接到页面") != "")
                queryParam.ToPage = base.ParamInfo.GetValue("链接到页面");

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
