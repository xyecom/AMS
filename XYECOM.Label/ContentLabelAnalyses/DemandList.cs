using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 加工信息列表标签解析类
    /// </summary>
    internal class DemandList : ContentLabelManager
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
            string strWhere = " where (AuditingState = 1) and (UserAuditingState=1) and (SD_IsSupply = 1) and (datediff(day,getdate(),SD_EndDate)>0) ";

            if (base.OuterParameter.AreaId > 0)
                strWhere += " and Area_id in (" + Business.XYClass.GetSubIds("area", base.OuterParameter.AreaId) + ")";

            if (base.OuterParameter.TradeId > 0)
                strWhere += " and (charindex('," + base.OuterParameter.TradeId + ",',UserTradeIds) >0)";


            if (base.ParamInfo.GetValue("点击次数") != "")
                strWhere += " and (SD_ClickNum >=" + base.ParamInfo.GetValue("点击次数") + ")";

            string typeId = base.ParamInfo.GetValue("投融资类型");

            if (!string.IsNullOrEmpty(typeId) && typeId != "0")
            {
                strWhere += " and (TypeId=" + typeId + ")";
            }

            if (base.ParamInfo.GetValue("是否推荐") != "")
                strWhere += " and (SD_Vouch=" + base.ParamInfo.GetValue("是否推荐") + ")";

            //if (base.ParamInfo.GetValue("是否显示缩略图") == "1")
            //    strWhere += " and IsHasImage >0 ";

            //if (base.ParamInfo.GetValue("是否显示缩略图") == "0")
            //    strWhere += " and IsHasImage = 0 ";

            string flag = base.ParamInfo.GetValue("信息类型");

            if (!string.IsNullOrEmpty(flag) && flag != "0")
            {
                strWhere += " and (SD_Flag=" + flag + ")";
            }


            return strWhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "SD_ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName, base._LabelInfo.LabelStyleContent);

            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("调用数量") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("调用数量"));

            if (base.ParamInfo.GetValue("标题字数") != "")
                queryParam.TitleFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("标题字数"));

            if (base.ParamInfo.GetValue("日期格式") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("日期格式");

            if (base.ParamInfo.GetValue("信息描述显示字数") != "")
                queryParam.ProductSummaryFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("信息描述显示字数"));

            if (base.ParamInfo.GetValue("公司名称字数") != "")
                queryParam.CompanyNameFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("公司名称字数"));

            queryParam.InfoType = base.ParamInfo.GetValue("信息类型");

            queryParam.Order = "Order by ";

            if (base.ParamInfo.GetValue("优先以会员等级排序") == "1")
                queryParam.Order += "UG_Order asc,";

            queryParam.Order += base.ParamInfo.GetValue("排序字段") + " " + base.ParamInfo.GetValue("排序方式") + " "; ;

            return queryParam;
        }
    }
}
