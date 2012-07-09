using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Label
{
    /// <summary>
    /// ������Ϣ�б��ǩ������
    /// </summary>
    internal class SupplyList : ContentLabelManager
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
            string strWhere = " where AuditingState = 1 and UserAuditingState=1 and SD_IsSupply = 1 and SD_EndDate > '" + DateTime.Now + "' ";

            if (base.OuterParameter.AreaId > 0)
                strWhere += " and Area_id in (" + Business.XYClass.GetSubIds("area", base.OuterParameter.AreaId) + ")";

            if (base.OuterParameter.TradeId > 0)
                strWhere += " and charindex('," + base.OuterParameter.TradeId + ",',UserTradeIds) >0";

            ///���Ϊ��Ʒ��ҳ��ǩ�����Ե�ǰ��Ʒ����Ϊ׼������������������
            if (base.OuterParameter.ProTypeId > 0)
            {
                strWhere += " and PT_ID in(" + Business.XYClass.GetSubIds("offer", base.OuterParameter.ProTypeId) + ")";
            }
            else
            {
                if (base.ParamInfo.GetValue("��Ϣ���") != "")
                {
                    string[] pars = base.ParamInfo.GetValue("��Ϣ���").Split(':');

                    if (pars[1].Equals("") || pars[1].Equals("0"))
                    {
                        strWhere += " and moduleName='" + pars[0] + "'";
                    }
                    else
                    {
                        strWhere += " and ( PT_ID = " + pars[1] + " Or Charindex('," + pars[1] + ",',FullId) > 0)";
                    }
                }
            }

            string companyTypeId = base.ParamInfo.GetValue("�û��Զ��������");
            int cptid = 0;

            if (!string.IsNullOrEmpty("companyTypeId") && (cptid = XYECOM.Core.MyConvert.GetInt32(companyTypeId)) > 0)
            {
                strWhere += " and CompanyProductTypeid in (" + Business.XYClass.GetSubIds("companytype", cptid) + ")";
            }


            //�����ѡ���ǩ����ʱѡ���˲��뱣֤��ͬ����ô��һ���������Ʒ����
            //����
            //  ���ѡ���� ��Ʒ����������һ���������ͬ����
            //  ���򲻼��κ�����
            string ht = base.ParamInfo.GetValue("�Ƿ�����ͬ����");
            if (!string.IsNullOrEmpty(ht) && ht == "1") 
            {
                strWhere += " and (IsContractVouch =1 and IsPayBail=0)";
            }
            else
            {
                string cp = base.ParamInfo.GetValue("�Ƿ�����Ʒ����");
                if (!string.IsNullOrEmpty(cp))
                {
                    strWhere += " and (IsContractVouch =0 and IsPayBail=" + cp + ")";
                }
            }

            if (base.ParamInfo.GetValue("�������") != "")
                strWhere += " and (SD_ClickNum >=" + base.ParamInfo.GetValue("�������") + ")";

            if (base.ParamInfo.GetValue("�Ƿ��Ƽ�") != "")
                strWhere += " and (SD_Vouch=" + base.ParamInfo.GetValue("�Ƿ��Ƽ�") + ")";

            if (base.ParamInfo.GetValue("�Ƿ���ʾ����ͼ") == "1")
                strWhere += " and IsHasImage >0 ";
            if (base.ParamInfo.GetValue("�Ƿ���ʾ����ͼ") == "0")
                strWhere += " and IsHasImage = 0 ";

            if (base.ParamInfo.GetValue("��Ϣ����") != "0")
                strWhere += " and SD_Flag=" + base.ParamInfo.GetValue("��Ϣ����");

            return strWhere;
        }
        /// <summary>
        /// ����ԭʼ������ϳɲ�ѯ����
        /// </summary>
        /// <returns></returns>
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

            if (base.ParamInfo.GetValue("��Ϣ��������") != "")
                queryParam.ProductSummaryFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("��Ϣ��������"));

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
