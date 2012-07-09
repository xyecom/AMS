using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 个人信息分页列表标签解析类
    /// </summary>
    internal class AssociatorPageList : ContentLabelManager
    {
        public AssociatorPageList() 
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

            queryParam.SortFields = base.ParamInfo.GetValue("排序字段") + " " + base.ParamInfo.GetValue("排序方式");

            return queryParam;
        }

        public override SEARCH_PAGE_LIST SearchPageList
        {
            get
            {
                return SEARCH_PAGE_LIST.JOB_RESUMELIST;
            }
        }
    }
}
