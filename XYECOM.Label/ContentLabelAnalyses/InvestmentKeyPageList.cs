using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 招商加盟固定排名标签解析类
    /// </summary>
    internal class InvestmentKeyPageList : RankingLabelManager
    {
        public InvestmentKeyPageList()
        {
            base.LabelContentType = ContentLabelType.Ranking;        
        }

        protected override string GetCondition()
        {
            short rank = Core.MyConvert.GetInt16(base.ParamInfo.GetValue("显示名次"));

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

            if (base.ParamInfo.GetValue("标题字数") != "")
                queryParam.TitleFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("标题字数"));

            if (base.ParamInfo.GetValue("日期格式") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("日期格式");

            if (base.ParamInfo.GetValue("信息描述字数") != "")
                queryParam.ProductSummaryFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("信息描述字数"));

            if (base.ParamInfo.GetValue("公司名称字数") != "")
                queryParam.CompanyNameFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("公司名称字数"));

            return queryParam;
        }

        protected override System.Data.DataTable GetDataResult()
        {
            //如果不是第一页后者么样竞价信息是返回空表格
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
