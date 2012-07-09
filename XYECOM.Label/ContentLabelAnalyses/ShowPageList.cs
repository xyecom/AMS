using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 展会信息分页列表标签解析类
    /// </summary>
    internal class ShowPageList : ContentLabelManager
    {
        public ShowPageList()
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

            queryParam.PrimaryKey = "id";
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

            if (base.ParamInfo.GetValue("标题字数") != "")
                queryParam.TitleFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("标题字数"));

            if (base.ParamInfo.GetValue("日期格式") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("日期格式");

            if (base.ParamInfo.GetValue("信息描述字数") != "")
                queryParam.ProductSummaryFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("信息描述字数"));

            if (base.ParamInfo.GetValue("公司名称字数") != "")
                queryParam.CompanyNameFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("公司名称字数"));

            queryParam.SortFields = " " + base.ParamInfo.GetValue("排序字段") + " " + base.ParamInfo.GetValue("排序方式");

            queryParam.SortFields.Replace("SHI_ID", "Id");

            return queryParam;
        }

        protected override string ModuleFlag
        {
            get
            {
                return "exhibition";
            }
        }
    }
}
