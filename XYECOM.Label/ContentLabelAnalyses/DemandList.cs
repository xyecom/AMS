using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// �ӹ���Ϣ�б��ǩ������
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


            if (base.ParamInfo.GetValue("�������") != "")
                strWhere += " and (SD_ClickNum >=" + base.ParamInfo.GetValue("�������") + ")";

            string typeId = base.ParamInfo.GetValue("Ͷ��������");

            if (!string.IsNullOrEmpty(typeId) && typeId != "0")
            {
                strWhere += " and (TypeId=" + typeId + ")";
            }

            if (base.ParamInfo.GetValue("�Ƿ��Ƽ�") != "")
                strWhere += " and (SD_Vouch=" + base.ParamInfo.GetValue("�Ƿ��Ƽ�") + ")";

            //if (base.ParamInfo.GetValue("�Ƿ���ʾ����ͼ") == "1")
            //    strWhere += " and IsHasImage >0 ";

            //if (base.ParamInfo.GetValue("�Ƿ���ʾ����ͼ") == "0")
            //    strWhere += " and IsHasImage = 0 ";

            string flag = base.ParamInfo.GetValue("��Ϣ����");

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
    }
}
