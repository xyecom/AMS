using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    public class BaikeList : ContentLabelManager
    {
        protected override string GetCondition()
        {
            string strWhere = " where Display=1";

            if (base.ParamInfo.GetValue("浏览次数") != "")
                strWhere += " and BrowseTimes >=" + base.ParamInfo.GetValue("浏览次数");

            if (base.ParamInfo.GetValue("百科分类") != "")
            {
                strWhere += " and (" + GetLemmaCategoryWhere(base.ParamInfo.GetValue("百科分类")) + ")";
            }

            if (base.ParamInfo.GetValue("是否推荐") != "")
                strWhere += " and IsRecommend=" + base.ParamInfo.GetValue("是否推荐");

            if (base.ParamInfo.GetValue("是否优秀") != "")
                strWhere += " and IsBestLemma=" + base.ParamInfo.GetValue("是否优秀");

            return strWhere;
        }

        private string GetLemmaCategoryWhere(string lemmaCategory)
        {
            if (lemmaCategory.Equals("")) return "";

            string[] arrID = lemmaCategory.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string tmpwhere = "";

            for (int i = 0; i < arrID.Length; i++)
            {
                int curAreaId = Core.MyConvert.GetInt32(arrID[i]);

                if (curAreaId <= 0) continue;

                tmpwhere += tmpwhere == "" ? "" : " or ";

                tmpwhere += " charindex ('," + curAreaId + ",',lemmaCategory) >0";
            }

            return tmpwhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "LemmaId";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName, base._LabelInfo.LabelStyleContent);

            //无信息类型之分
            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("调用数量") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("调用数量"));

            if (base.ParamInfo.GetValue("日期格式") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("日期格式");

            queryParam.Order = "Order by ";

            queryParam.Order += base.ParamInfo.GetValue("排序字段") + " " + base.ParamInfo.GetValue("排序方式") + " ";


            if (!string.IsNullOrEmpty(base.ParamInfo.GetValue("内容显示字数")))
            {
                queryParam.NewsLeadinFontNumber = XYECOM.Core.MyConvert.GetInt32(base.ParamInfo.GetValue("内容显示字数"));
            }
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
