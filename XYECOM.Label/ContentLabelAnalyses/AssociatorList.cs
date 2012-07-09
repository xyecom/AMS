using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 个人信息列表标签解析类
    /// </summary>
    internal class AssociatorList : ContentLabelManager
    {
        protected override string GetCondition()
        {
            string strWhere = " where UserAuditingState = 1 ";

            return strWhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "U_ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName);

            //无信息类型之分,无类别之分，无缩略图
            //queryParam.Condition = ConditionManager.GetCondition(base.ParamInfo.LabelFlagName, "", base.ParamInfo.GetValue("点击次数"), base.ParamInfo.GetValue("是否推荐"), "", "");
            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("调用数量") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("调用数量"));

            if (base.ParamInfo.GetValue("日期格式") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("日期格式");


            queryParam.Order = " order by " + base.ParamInfo.GetValue("排序字段") + " " + base.ParamInfo.GetValue("排序方式") + " ";

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
