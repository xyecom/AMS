using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    public class SupplyBuyPageList : ContentLabelManager
    {
         public SupplyBuyPageList()
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

            queryParam.PrimaryKey = "SD_ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName, base._LabelInfo.LabelStyleContent);

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

            if (!base.OuterParameter.OrderStr.Equals(""))
            {
                queryParam.SortFields = base.OuterParameter.OrderStr;
            }
            else
            {
                queryParam.SortFields = base.ParamInfo.GetValue("排序字段") + " " + base.ParamInfo.GetValue("排序方式");
            }
            return queryParam;
        }

        protected override System.Data.DataTable GetDataResult()
        {
            int totalRecord = 0;

            System.Data.DataTable table = XYECOM.Business.Utils.GetPaginationData(
               base.QueryParamInfo.DataSourceName,
               base.QueryParamInfo.PrimaryKey,
               base.QueryParamInfo.Columns,
               base.QueryParamInfo.SortFields,
               base.QueryParamInfo.Condition,
               base.PageSize,
               base.PageIndex,
               out totalRecord);

            base.TotalRecord = totalRecord;
            base.SetPagination(base.PageIndex, base.PageURL, SEARCH_PAGE_LIST.SEARCH_BUY, "");
            return table;
        }
    }
}
