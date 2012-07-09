using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Label
{
    public class TeamBuyPageList : ContentLabelManager
    {
        public TeamBuyPageList()
        {
            base.LabelContentType = ContentLabelType.Pagination;            
        }

        protected override string GetCondition()
        {
            string where = base.StrPageSearchWhere;
            where += " and (AuditingState=" + ((int)Model.AuditingState.Passed) + ") and (IsDeleted=0) ";

            string isPlat = base.ParamInfo.GetValue("是否是平台团购");
            if (!string.IsNullOrEmpty(isPlat))
            {
                where += " and (IsPlatform=" + isPlat + ")";
            }
            return where;
        }
        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "Id";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = "XY_TeamBuy";
            //无信息类型之分
            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("调用数量") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("调用数量"));

            if (base.ParamInfo.GetValue("标题字数") != "")
                queryParam.TitleFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("标题字数"));

            if (base.ParamInfo.GetValue("日期格式") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("日期格式");

            if (base.ParamInfo.GetValue("信息描述字数") != "")
                queryParam.ProductSummaryFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("信息描述字数"));

            queryParam.Order = " order by " + base.ParamInfo.GetValue("排序字段") + " " + base.ParamInfo.GetValue("排序方式") + " ";

            return queryParam;
        }

        public override SEARCH_PAGE_LIST SearchPageList
        {
            get
            {
                if (IsPlatForm)
                {
                    return SEARCH_PAGE_LIST.TEAMBUY_LIST_PLAT;
                }
                return SEARCH_PAGE_LIST.TEAMBUY_LIST_SHOP;
            }
        }
    }
}
