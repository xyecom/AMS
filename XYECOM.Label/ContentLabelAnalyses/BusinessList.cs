using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// ���̽�����Ϣ�б��ǩ������
    /// </summary>
    internal class BusinessList : ContentLabelManager
    {
        protected override string GetCondition()
        {
            string strWhere = " where  AuditingState = 1 and UserAuditingState=1 and IBI_Pause = '1' and IBI_EndTime > '" + DateTime.Now + "' ";

            if (base.OuterParameter.AreaId > 0)
                strWhere += " and Area_id in (" + Business.XYClass.GetSubIds("area", base.OuterParameter.AreaId) + ")";

            if (base.OuterParameter.TradeId > 0)
                strWhere += " and charindex('," + base.OuterParameter.TradeId + ",',UserTradeIds) >0";



            if (base.ParamInfo.GetValue("�������") != "")
                strWhere += " and IBI_ClickNum >=" + base.ParamInfo.GetValue("�������");

            if (base.ParamInfo.GetValue("��Ϣ���") != "")
            {
                string[] pars = base.ParamInfo.GetValue("��Ϣ���").Split(':');

                if (pars[1].Equals("") || pars[1].Equals("0"))
                {
                    strWhere += " and moduleName='" + pars[0] + "'";
                }
                else
                {
                    strWhere += " and (IT_ID  = " + pars[1] + " Or Charindex('," + pars[1] + ",',FullID)>0)";
                }
            }

            if (base.ParamInfo.GetValue("�Ƿ��Ƽ�") != "")
                strWhere += " and IBI_Vouch=" + base.ParamInfo.GetValue("�Ƿ��Ƽ�");
            if (base.ParamInfo.GetValue("�Ƿ���ʾ����ͼ") == "1")
                strWhere += " and IsHasImage >0 ";
            if (base.ParamInfo.GetValue("�Ƿ���ʾ����ͼ") == "0")
                strWhere += " and IsHasImage =0 ";
            if (base.ParamInfo.GetValue("��Ϣ����") != "0")
                strWhere += " and IBI_Sign=" + base.ParamInfo.GetValue("��Ϣ����");

            return strWhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "IBI_ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName, base._LabelInfo.LabelStyleContent);

            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("��������") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("��������"));

            if (base.ParamInfo.GetValue("��������") != "")
                queryParam.TitleFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("��������"));

            if (base.ParamInfo.GetValue("���ڸ�ʽ") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("���ڸ�ʽ");

            if (base.ParamInfo.GetValue("��Ϣ������ʾ����") != "")
                queryParam.ProductSummaryFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("��Ϣ������ʾ����"));

            if (base.ParamInfo.GetValue("��˾��������") != "")
                queryParam.CompanyNameFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("��˾��������"));

            queryParam.InfoType = base.ParamInfo.GetValue("��Ϣ����");

            queryParam.Order = "Order by ";

            if (base.ParamInfo.GetValue("�����Ի�Ա�ȼ�����") == "1")
                queryParam.Order += "UG_Order asc,";

            queryParam.Order += base.ParamInfo.GetValue("�����ֶ�") + " " + base.ParamInfo.GetValue("����ʽ") + " "; ;

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
