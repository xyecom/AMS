using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Label
{
    internal class SupplyBuyList : ContentLabelManager
    {
        protected override string GetCondition()
        {
            string strWhere = " where AuditingState=1 ";

            //if (base.ParamInfo.GetValue("点击次数") != "")
            //    strWhere += " and SD_ClickNum >=" + base.ParamInfo.GetValue("点击次数");

            //if (base.ParamInfo.GetValue("是否推荐") != "")
            //    strWhere += " and SD_Vouch=" + base.ParamInfo.GetValue("是否推荐");

            //if (base.ParamInfo.GetValue("是否显示缩略图") == "1")
            //    strWhere += " and IsHasImage >0 ";
            //if (base.ParamInfo.GetValue("是否显示缩略图") == "0")
            //    strWhere += " and IsHasImage = 0 ";

            if (base.ParamInfo.GetValue("所属地区编号") != "")
            {
                string ids = new XYECOM.Business.Area().GetSubIds(XYECOM.Core.MyConvert.GetInt32(base.ParamInfo.GetValue("求购所属地区")));
                strWhere += " and buyId in (" + ids + ") ";
            }
            return strWhere;
        }
        /// <summary>
        /// 分析原始参数组合成查询参数
        /// </summary>
        /// <returns></returns>
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

            if (base.ParamInfo.GetValue("信息描述字数") != "")
                queryParam.ProductSummaryFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("信息描述字数"));

            if (base.ParamInfo.GetValue("公司名称字数") != "")
                queryParam.CompanyNameFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("公司名称字数"));

            // queryParam.InfoType = base.ParamInfo.GetValue("信息类型");

            // queryParam.Order = "Order by sd_id  desc ,";

            queryParam.Order += " order by " + base.ParamInfo.GetValue("排序字段") + " " + base.ParamInfo.GetValue("排序方式") + " "; ;

            return queryParam;
        }

        protected override string GetLabelRangeCondition()
        {
            string where = string.Empty;

            if (_LabelInfo.LabelRange == Model.LabelRange.User)
            {
                where = string.Format(" and (UID in ({0}))", XYECOM.Core.Utils.RemoveComma(_LabelInfo.GroupIdOrUserId));
            }
            else
            {
                where = string.Format(" and (UG_ID in ({0}))", XYECOM.Core.Utils.RemoveComma(_LabelInfo.GroupIdOrUserId));
            }

            return where;
        }
    }
}
