using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// ��ҵ��Ϣ�б��ǩ������
    /// </summary>
    internal class CorporationList:ContentLabelManager
    {
        protected override string GetCondition()
        {
            string strWhere = " where  userAuditingState = 1";

            #region �ⲿ�����������
            
            if (base.OuterParameter.AreaId > 0)
                strWhere += " and Area_id in (" + Business.XYClass.GetSubIds("area", base.OuterParameter.AreaId) + ")";

            if (base.OuterParameter.TradeId > 0)
                strWhere += " and charindex('," + base.OuterParameter.TradeId + ",',TradeIds) >0";

            #endregion

            if (base.ParamInfo.GetValue("�������") != "")
                strWhere += " and U_ClickNum >=" + base.ParamInfo.GetValue("�������");

            if (base.ParamInfo.GetValue("��ҵ���") != "")
                strWhere += " and UT_ID in(" + Business.XYClass.GetSubIds("company", Core.MyConvert.GetInt64(base.ParamInfo.GetValue("��ҵ���"))) + ")";

            if (base.ParamInfo.GetValue("�Ƿ��Ƽ�") != "")
                strWhere += " and U_Vouch=" + base.ParamInfo.GetValue("�Ƿ��Ƽ�");

            if (base.ParamInfo.GetValue("�Ƿ���ʾ����ͼ") == "1")
                strWhere += " and UserIsHasImage >0 ";

            if (base.ParamInfo.GetValue("�Ƿ���ʾ����ͼ") == "0")
                strWhere += " and UserIsHasImage =0 ";

            if (base.ParamInfo.GetValue("�û��ȼ�") != "")
                strWhere += " and UG_ID=" + base.ParamInfo.GetValue("�û��ȼ�");

            return strWhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "U_ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName);

            //����Ϣ����֮��
            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("��������") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("��������"));

            if (base.ParamInfo.GetValue("���ڸ�ʽ") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("���ڸ�ʽ");

            if (base.ParamInfo.GetValue("��ҵ�������") != "")
                queryParam.CompanySummaryFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("��ҵ�������"));

            if (base.ParamInfo.GetValue("��ҵ��������") != "")
                queryParam.CompanyNameFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("��ҵ��������"));

            queryParam.Order = "Order by ";

            if (base.ParamInfo.GetValue("�����Ի�Ա�ȼ�����") == "1")
                queryParam.Order += "UG_Order asc,";

            queryParam.Order += base.ParamInfo.GetValue("�����ֶ�") + " " + base.ParamInfo.GetValue("����ʽ") + " ";

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
