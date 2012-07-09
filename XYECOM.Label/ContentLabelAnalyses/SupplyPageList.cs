using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 供求信息分页列表标签解析类
    /// </summary>
    internal class SupplyPageList : ContentLabelManager
    {
        public SupplyPageList()
        {
            base.LabelContentType = ContentLabelType.Pagination;
        }

        protected override string GetCondition()
        {
            string strWhere = string.Empty;

            string ht = base.ParamInfo.GetValue("是否参与合同保障");
                        
            if (!string.IsNullOrEmpty(ht) && ht == "1")
            {
                strWhere += " (IsContractVouch =1 and IsPayBail=0)";
            }
            else
            {
                string cp = base.ParamInfo.GetValue("是否参与产品保障");
                if (!string.IsNullOrEmpty(cp))
                {
                    strWhere += " (IsContractVouch =0 and IsPayBail=" + cp + ")";
                }
            }

            base.StrKeySearchWhere = strWhere;

            return strWhere;
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

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "SD_ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName, base._LabelInfo.LabelStyleContent);

            queryParam.Condition = GetCondition();

            if (base.CustomPageSize != 0) PageSize = base.CustomPageSize;

            if (PageSize == 0)
            {
                if (base.ParamInfo.GetValue("调用数量") != "")
                {
                    base.PageSize = Core.MyConvert.GetInt32(base.ParamInfo.GetValue("调用数量"));
                }
            }

            if (base.ParamInfo.GetValue("标题字数") != "")
                queryParam.TitleFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("标题字数"));

            if (base.ParamInfo.GetValue("日期格式") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("日期格式");

            if (base.ParamInfo.GetValue("信息描述字数") != "")
                queryParam.ProductSummaryFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("信息描述字数"));

            if (base.ParamInfo.GetValue("公司名称字数") != "")
                queryParam.CompanyNameFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("公司名称字数"));

            if (!base.OuterParameter.OrderStr.Equals(""))
            {
                queryParam.SortFields = base.OuterParameter.OrderStr;
            }
            else
            {
                queryParam.SortFields = "UG_Order asc," + base.ParamInfo.GetValue("排序字段") + " " + base.ParamInfo.GetValue("排序方式");
            }
            return queryParam;
        }

        protected override string ModuleFlag
        {
            get
            {
                return "offer";
            }
        }
    }
}
