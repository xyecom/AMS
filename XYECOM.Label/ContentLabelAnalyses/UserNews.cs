using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Label
{
    /// <summary>
    /// ��ҵ��Ѷ�б��ǩ������
    /// </summary>
    internal class UserNews : ContentLabelManager
    {
        protected override string GetCondition()
        {
            string strWhere = " where 1= 1";

            if (base.ParamInfo.GetValue("�û�Id") == "" && base.ParamInfo.GetValue("�û�Id") == "0")
                strWhere += " and u_id = " + base.ParamInfo.GetValue("�û�Id");

            return strWhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "N_ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName);

            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("��������") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("��������"));

            if (base.ParamInfo.GetValue("��������") != "")
                queryParam.TitleFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("��������"));

            if (base.ParamInfo.GetValue("���ڸ�ʽ") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("���ڸ�ʽ");

            queryParam.Order = " order by UG_Order asc,n_id desc";

            return queryParam;
        }

        protected override System.Data.DataTable GetDataResult()
        {
            DataTable table = XYECOM.Core.Function.GetDataTableForTop(PageSize,
                base.QueryParamInfo.Columns,
                base.QueryParamInfo.DataSourceName,
                base.QueryParamInfo.Condition,
                base.QueryParamInfo.Order);

            return table;
        }
    }
}
