using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// ���̼��˹̶�������ǩ������
    /// </summary>
    internal class InvestmentKeyPageList : RankingLabelManager
    {
        public InvestmentKeyPageList()
        {
            base.LabelContentType = ContentLabelType.Ranking;        
        }

        protected override string GetCondition()
        {
            short rank = Core.MyConvert.GetInt16(base.ParamInfo.GetValue("��ʾ����"));

            long infoId = GetRankingInfoId(base.RankKeyId, rank, base.ModuleName);

            if (infoId <= 0) return "";

            string strWhere = "  IBI_ID=" + infoId;

            base.StrKeySearchWhere = strWhere;

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
                queryParam.TitleFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("��������"));

            if (base.ParamInfo.GetValue("���ڸ�ʽ") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("���ڸ�ʽ");

            if (base.ParamInfo.GetValue("��Ϣ��������") != "")
                queryParam.ProductSummaryFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("��Ϣ��������"));

            if (base.ParamInfo.GetValue("��˾��������") != "")
                queryParam.CompanyNameFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("��˾��������"));

            return queryParam;
        }

        protected override System.Data.DataTable GetDataResult()
        {
            //������ǵ�һҳ����ô��������Ϣ�Ƿ��ؿձ��
            if (!(base.StrKeySearchWhere != "" && base.PageIndex == 1))
                return new System.Data.DataTable();

            base.PageSize = 1;

            int totalRecord = 0;

            System.Data.DataTable table = XYECOM.Business.Utils.GetPaginationData(
               base.QueryParamInfo.DataSourceName,
               base.QueryParamInfo.PrimaryKey,
               base.QueryParamInfo.Columns,
               base.QueryParamInfo.SortFields,
               base.QueryParamInfo.Condition,
               base.PageSize,
               base.PageIndex,
               out totalRecord);

            return table;
        }
    }
}
