using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Label
{
    //2011/05/23 jerome

    internal class UserNewsList : ContentLabelManager
    {
        protected override string GetLabelRangeCondition()
        {
            string where = string.Empty;

            if (_LabelInfo.LabelRange == Model.LabelRange.User)
            {
                where = string.Format(" and (U_ID in ({0}))", XYECOM.Core.Utils.RemoveComma(_LabelInfo.GroupIdOrUserId));
            }
            else
            {
                where = string.Format(" and (UG_ID in ({0}))", XYECOM.Core.Utils.RemoveComma(_LabelInfo.GroupIdOrUserId));
            }

            return where;
        }

        protected override string GetCondition()
        {
            string strWhere = " where (AuditingState = 1)";

            strWhere += " and (UserAuditingState = 1)";

            //if (base.OuterParameter.AreaId > 0)
            //    strWhere += " and (" + GetAreaWhere(base.OuterParameter.AreaId) + ")";

            //if (base.OuterParameter.TradeId > 0)
            //    strWhere += " and (charindex('," + base.OuterParameter.TradeId + ",',TradeIds) >0) ";

            //if (base.OuterParameter.ProTypeId > 0)
            //    strWhere += " and (charindex('," + base.OuterParameter.ProTypeId + ",',ProTypeIds) >0) ";

            if (base.ParamInfo.GetValue("点击次数") != "")
                strWhere += " and (Count >=" + base.ParamInfo.GetValue("点击次数") + ")";

            if (base.ParamInfo.GetValue("是否推荐") != "")
            {
                if (XYECOM.Core.MyConvert.GetInt32(base.ParamInfo.GetValue("是否推荐")) == (int)XYECOM.Model.UserNewsFlagInfo.commend)
                    strWhere += " and (State%" + XYECOM.Core.MyConvert.GetInt32(base.ParamInfo.GetValue("是否推荐")) + "=0)";
            }

            return strWhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "N_ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName, base._LabelInfo.LabelStyleContent);

            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("调用数量") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("调用数量"));

            if (base.ParamInfo.GetValue("标题字数") != "")
                queryParam.TitleFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("标题字数"));

            if (base.ParamInfo.GetValue("日期格式") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("日期格式");

            if (base.ParamInfo.GetValue("新闻导读字数") != "")
                queryParam.NewsLeadinFontNumber = Convert.ToInt32(base.ParamInfo.GetValue("新闻导读字数"));


            queryParam.Order = " order by " + base.ParamInfo.GetValue("排序字段") + " " + base.ParamInfo.GetValue("排序方式") + " ";

            return queryParam;
        }
    }
}
