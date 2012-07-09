using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// ������Ϣ�̶�������ǩ������
    /// </summary>
    internal class SupplyKeyPageList : RankingLabelManager
    {
        public SupplyKeyPageList()
        {
            base.LabelContentType = ContentLabelType.Ranking;
        }

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
            short rank = Core.MyConvert.GetInt16(base.ParamInfo.GetValue("��ʾ����"));

            long infoId = GetRankingInfoId(base.RankKeyId, rank, base.ModuleName);

            if (infoId <= 0) return "";

            string strWhere = " (SD_ID=" + infoId + ")"; ;


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

            base.StrKeySearchWhere = strWhere;

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
                queryParam.TitleFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("��������"));

            if (base.ParamInfo.GetValue("���ڸ�ʽ") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("���ڸ�ʽ");

            if (base.ParamInfo.GetValue("��Ϣ��������") != "")
                queryParam.ProductSummaryFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("��Ϣ��������"));

            if (base.ParamInfo.GetValue("��˾��������") != "")
                queryParam.CompanyNameFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("��˾��������"));

            return queryParam;
        }
    }
}
