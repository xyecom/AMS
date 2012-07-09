using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// ������Ϣ�б��ǩ������
    /// </summary>
    internal class AssociatorList : ContentLabelManager
    {
        protected override string GetCondition()
        {
            string strWhere = " where UserAuditingState = 1 ";

            return strWhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "U_ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName);

            //����Ϣ����֮��,�����֮�֣�������ͼ
            //queryParam.Condition = ConditionManager.GetCondition(base.ParamInfo.LabelFlagName, "", base.ParamInfo.GetValue("�������"), base.ParamInfo.GetValue("�Ƿ��Ƽ�"), "", "");
            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("��������") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("��������"));

            if (base.ParamInfo.GetValue("���ڸ�ʽ") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("���ڸ�ʽ");


            queryParam.Order = " order by " + base.ParamInfo.GetValue("�����ֶ�") + " " + base.ParamInfo.GetValue("����ʽ") + " ";

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
