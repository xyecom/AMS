using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 企业信息分页信息标签解析类
    /// </summary>
    internal class CorporationPageList : ContentLabelManager
    {
        public CorporationPageList()
        {
            base.LabelContentType = ContentLabelType.Pagination;
        }

        protected override string GetCondition()
        {
            return base.StrPageSearchWhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "U_ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName);

            queryParam.Condition = GetCondition();

            if (base.CustomPageSize != 0) PageSize = base.CustomPageSize;

            if (PageSize == 0)
            {
                if (base.ParamInfo.GetValue("调用数量") != "")
                {
                    base.PageSize = Core.MyConvert.GetInt32(base.ParamInfo.GetValue("调用数量"));
                }
            }

            if (base.ParamInfo.GetValue("日期格式") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("日期格式");

            if (base.ParamInfo.GetValue("公司简介显示字数") != "")
                queryParam.CompanySummaryFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("公司简介显示字数"));

            if (base.ParamInfo.GetValue("标题字数") != "")
                queryParam.CompanyNameFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("标题字数"));

            if (!base.OuterParameter.OrderStr.Equals(""))
            {
                queryParam.SortFields = base.OuterParameter.OrderStr;
            }
            else
            {
                queryParam.SortFields = "UG_Order asc," + base.ParamInfo.GetValue("排序字段") + " " + base.ParamInfo.GetValue("排序方式");
            }

            return queryParam;
        }

        protected override string ModuleFlag
        {
            get
            {
                return "company";
            }
        }
    }
}
