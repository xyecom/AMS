using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// ����б��ǩ������
    /// </summary>
    internal class AdvertisingList : ContentLabelManager
    {
        protected override string GetCondition()
        {
            string strWhere = " where AD_Isuse=1 and getdate()<=ad_enddate";

            if (base.ParamInfo.GetValue("���λ") != "")
            {
                strWhere += " and AP_ID=" + base.ParamInfo.GetValue("���λ");
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

            if (base.ParamInfo.GetValue("��������") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("��������"));

            queryParam.Order = " order by AD_ID";

            return queryParam;
        }
    }
}
