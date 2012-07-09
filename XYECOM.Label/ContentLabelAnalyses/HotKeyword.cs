using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// ���Źؼ����б��ǩ������
    /// </summary>
    internal class HotKeyword : ContentLabelManager
    {
        protected override string GetCondition()
        {
            string strWhere = " where 1=1 ";

            if (base.ParamInfo.GetValue("����ģ��") != "")
                strWhere += " and SK_Sort='" + base.ParamInfo.GetValue("����ģ��") + "'";

            if (base.ParamInfo.GetValue("�Ƿ��Ƽ�") != "")
                strWhere += " and SK_IsCommend='" + base.ParamInfo.GetValue("�Ƿ��Ƽ�") + "'";

            return strWhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "SK_ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName);

            //����Ϣ����֮��
            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("��������") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("��������"));

            if (base.ParamInfo.GetValue("���ӵ�ҳ��") != "")
                queryParam.ToPage = base.ParamInfo.GetValue("���ӵ�ҳ��");

            return queryParam;
        }

        protected override System.Data.DataTable GetDataResult()
        {
            System.Data.DataTable table = XYECOM.Core.Function.GetDataTableForTop(PageSize,
                base.QueryParamInfo.Columns,
                base.QueryParamInfo.DataSourceName,
                base.QueryParamInfo.Condition,
                base.QueryParamInfo.Order);

            return table;
        }
    }
}
