using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Label
{
    public class TeamBuyList : ContentLabelManager
    {
        protected override string GetLabelRangeCondition()
        {
            string where = string.Empty;

            if (_LabelInfo.LabelRange == Model.LabelRange.User)
            {
                where = string.Format(" and (UserId in ({0}))", XYECOM.Core.Utils.RemoveComma(_LabelInfo.GroupIdOrUserId));
            }

            return where;
        }

        protected override string GetCondition()
        {
            string strWhere = " where (AuditingState=" + ((int)Model.AuditingState.Passed) + ") and (IsDeleted=0) ";

            string isPlat = base.ParamInfo.GetValue("是否是平台团购");
            if (!string.IsNullOrEmpty(isPlat))
            {
                strWhere += " and (IsPlatform=" + isPlat + ")";
            }
            string isCommend = base.ParamInfo.GetValue("是否推荐");
            if (!string.IsNullOrEmpty(isCommend))
            {
                strWhere += " and (IsRecommend=" + isCommend + ")";
            }

            string isUserCommend = base.ParamInfo.GetValue("是否用户推荐");
            if (!string.IsNullOrEmpty(isUserCommend))
            {
                strWhere += " and (IsUserRecommend=" + isUserCommend + ")";
            }

            return strWhere;
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

    }
}
