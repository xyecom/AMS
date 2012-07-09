using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// ��Ƹ��Ϣ�б��ǩ������
    /// </summary>
    internal class EngageList : ContentLabelManager
    {
        protected override string GetCondition()
        {
            string strWhere = " where  AuditingState = 1 and EI_Puach = '1' and UserAuditingState=1";

            if (base.OuterParameter.AreaId > 0)
                strWhere += " and Area_id in (" + Business.XYClass.GetSubIds("area", base.OuterParameter.AreaId) + ")";

            if (base.OuterParameter.TradeId > 0)
                strWhere += " and charindex('," + base.OuterParameter.TradeId + ",',UserTradeIds) >0";



            if (base.ParamInfo.GetValue("�������") != "")
                strWhere += " and EI_ClickNum >=" + base.ParamInfo.GetValue("�������");

            if (base.ParamInfo.GetValue("��Ϣ���") != "")
                strWhere += " and ( P_ID=" + base.ParamInfo.GetValue("��Ϣ���") + " Or charindex('," + base.ParamInfo.GetValue("��Ϣ���") + ",',FullId) > 0)";

            if (base.ParamInfo.GetValue("�Ƿ��Ƽ�") != "")
                strWhere += " and EI_Vouch=" + base.ParamInfo.GetValue("�Ƿ��Ƽ�");

            return strWhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "EI_ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName, base._LabelInfo.LabelStyleContent);

            //����Ϣ����֮��,������ͼ
            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("��������") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("��������"));

            if (base.ParamInfo.GetValue("��λ����") != "")
                queryParam.TitleFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("��λ����"));

            if (base.ParamInfo.GetValue("���ڸ�ʽ") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("���ڸ�ʽ");

            if (base.ParamInfo.GetValue("����Ҫ����������") != "")
                queryParam.ProductSummaryFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("����Ҫ����������"));

            //if (base.ParamInfo.GetValue("��Ϣ��������") != "")
            //    queryParam.CompanyNameFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("��Ϣ��������"));

            if (base.ParamInfo.GetValue("��˾��������") != "")
                queryParam.CompanyNameFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("��˾��������"));

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
