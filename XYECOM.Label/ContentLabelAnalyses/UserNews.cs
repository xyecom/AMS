using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Label
{
    /// <summary>
    /// 企业资讯列表标签解析类
    /// </summary>
    internal class UserNews : ContentLabelManager
    {
        protected override string GetCondition()
        {
            string strWhere = " where 1= 1";

            if (base.ParamInfo.GetValue("用户Id") == "" && base.ParamInfo.GetValue("用户Id") == "0")
                strWhere += " and u_id = " + base.ParamInfo.GetValue("用户Id");

            return strWhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "N_ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName);

            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("调用数量") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("调用数量"));

            if (base.ParamInfo.GetValue("标题字数") != "")
                queryParam.TitleFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("标题字数"));

            if (base.ParamInfo.GetValue("日期格式") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("日期格式");

            queryParam.Order = " order by UG_Order asc,n_id desc";

            return queryParam;
        }

        protected override System.Data.DataTable GetDataResult()
        {
            DataTable table = XYECOM.Core.Function.GetDataTableForTop(PageSize,
                base.QueryParamInfo.Columns,
                base.QueryParamInfo.DataSourceName,
                base.QueryParamInfo.Condition,
                base.QueryParamInfo.Order);

            return table;
        }
    }
}
