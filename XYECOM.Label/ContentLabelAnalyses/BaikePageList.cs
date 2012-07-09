using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    public class BaikePageList : ContentLabelManager
    {
        public BaikePageList()
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

            queryParam.PrimaryKey = "LemmaId";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName);

            queryParam.Condition = GetCondition();

            if (base.CustomPageSize != 0) PageSize = base.CustomPageSize;

            if (PageSize == 0)
            {
                if (base.ParamInfo.GetValue("每页调用数量") != "")
                {
                    base.PageSize = Core.MyConvert.GetInt32(base.ParamInfo.GetValue("每页调用数量"));
                }
            }

            if (base.ParamInfo.GetValue("日期格式") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("日期格式");

            queryParam.SortFields = base.ParamInfo.GetValue("排序字段") + " " + base.ParamInfo.GetValue("排序方式");

            if (!string.IsNullOrEmpty(base.ParamInfo.GetValue("内容显示字数")))
            {
                queryParam.NewsLeadinFontNumber = XYECOM.Core.MyConvert.GetInt32(base.ParamInfo.GetValue("内容显示字数"));
            }

            return queryParam;
        }

        public override SEARCH_PAGE_LIST SearchPageList
        {
            get
            {
                return SEARCH_PAGE_LIST.BAIKE_LIST;
            }
        }
    }
}
