using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 供求信息固定排名标签解析类
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
            short rank = Core.MyConvert.GetInt16(base.ParamInfo.GetValue("显示名次"));

            long infoId = GetRankingInfoId(base.RankKeyId, rank, base.ModuleName);

            if (infoId <= 0) return "";

            string strWhere = " (SD_ID=" + infoId + ")"; ;


            string ht = base.ParamInfo.GetValue("是否参与合同保障");

            if (!string.IsNullOrEmpty(ht) && ht == "1")
            {
                strWhere += " and (IsContractVouch =1 and IsPayBail=0)";
            }
            else
            {
                string cp = base.ParamInfo.GetValue("是否参与产品保障");
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
    }
}
