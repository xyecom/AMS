using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    internal class VoteList : ContentLabelManager
    {
        protected override string GetCondition()
        {
            string strWhere = " where 1=1 ";

            if (base.ParamInfo.GetValue("仅调用已开始未结束信息") == "1")
                strWhere += " and StartTime<=getdate() and endTime > getdate()";

            return strWhere;
        }


        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "VoteId";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName);

            //无信息类型之分
            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("调用数量") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("调用数量"));

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
