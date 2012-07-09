using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 广告列表标签解析类
    /// </summary>
    internal class AdvertisingList : ContentLabelManager
    {
        protected override string GetCondition()
        {
            string strWhere = " where AD_Isuse=1 and getdate()<=ad_enddate";

            if (base.ParamInfo.GetValue("广告位") != "")
            {
                strWhere += " and AP_ID=" + base.ParamInfo.GetValue("广告位");
            }

            strWhere += " and (getdate()<=ad_enddate)";

            return strWhere;
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

            queryParam.Order = " order by AD_ID";

            return queryParam;
        }
    }
}
