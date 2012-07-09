using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 专题列表标签解析类
    /// </summary>
    internal class TopicList : ContentLabelManager
    {
        protected override string GetCondition()
        {
            string strWhere = " where 1=1 ";

            if (base.ParamInfo.GetValue("专题属性") != "all")
            {
                if ("general".Equals(base.ParamInfo.GetValue("专题属性")))
                    strWhere += " and (TopicType is null Or topicType='')";

                if("news".Equals(base.ParamInfo.GetValue("专题属性")))
                    strWhere += " and topicType='news'";
            }

            if (base.ParamInfo.GetValue("点击次数") != "")
                strWhere += " and ShowNum >=" + base.ParamInfo.GetValue("点击次数");

            if (base.ParamInfo.GetValue("信息类别") != "")
                strWhere += " and TCID=" + base.ParamInfo.GetValue("信息类别");

            if (base.ParamInfo.GetValue("是否推荐") != "")
                strWhere += " and Commend=" + base.ParamInfo.GetValue("是否推荐");

            if (base.ParamInfo.GetValue("是否显示缩略图") != "")
                strWhere += " and Flag = " + base.ParamInfo.GetValue("是否显示缩略图") + " ";

            return strWhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName);

            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("调用数量") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("调用数量"));

            if (base.ParamInfo.GetValue("标题字数") != "")
                queryParam.TitleFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("标题字数"));

            if (base.ParamInfo.GetValue("日期格式") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("日期格式");

            queryParam.Order = " order by ID  ";

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
