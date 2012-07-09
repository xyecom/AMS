using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 资讯栏目列表标签解析类
    /// </summary>
    internal class ChannelPageList : ContentLabelManager
    {
        public ChannelPageList()
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

            queryParam.PrimaryKey = "NS_ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName);

            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("调用数量") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("调用数量"));

            if (base.ParamInfo.GetValue("标题字数") != "")
                queryParam.TitleFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("标题字数"));

            if (base.ParamInfo.GetValue("日期格式") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("日期格式");

            if (base.ParamInfo.GetValue("导读字数") != "")
                queryParam.NewsLeadinFontNumber = Convert.ToInt32(base.ParamInfo.GetValue("导读字数"));

            queryParam.SortFields = base.ParamInfo.GetValue("排序字段") + " " + base.ParamInfo.GetValue("排序方式").ToLower();

            return queryParam;
        }

        public override SEARCH_PAGE_LIST SearchPageList
        {
            get
            {
                return SEARCH_PAGE_LIST.NEWS_CHANNEL;
            }
        }
    }
}
