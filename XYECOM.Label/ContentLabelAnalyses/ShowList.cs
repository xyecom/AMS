using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 展会列表标签解析类
    /// </summary>
    internal class ShowList : ContentLabelManager
    {
        protected override string GetCondition()
        {
            string strWhere = " where 1=1 ";

            if (base.ParamInfo.GetValue("信息类别") != "")
            {
                string typeId = ""; 

                if (base.ParamInfo.GetValue("信息类别").IndexOf(':') != -1)
                {
                    typeId = base.ParamInfo.GetValue("信息类别").Split(':')[1];
                }
                else
                { 
                    typeId = base.ParamInfo.GetValue("信息类别");
                }

                if (!typeId.Equals("") && !typeId.Equals("0"))
                {
                    strWhere += " and ( typeid  = " + typeId + " Or charindex(',"+typeId+",',FullID) > 0)";
                }
            }

            if (base.ParamInfo.GetValue("展会类型") != "所有")
            {
                if (base.ParamInfo.GetValue("展会类型") == "国内展")
                {
                    strWhere += " and type='国内展' ";
                }

                if (base.ParamInfo.GetValue("展会类型") == "国外展")
                {
                    strWhere += " and type='国外展' ";
                }
            }

            if (base.ParamInfo.GetValue("是否推荐") != "")
                strWhere += " and IsCommend=" + base.ParamInfo.GetValue("是否推荐");

            if (base.ParamInfo.GetValue("是否包含图片") == "1")
                strWhere += " and IsHasImage >0 ";
            if (base.ParamInfo.GetValue("是否包含图片") == "0")
                strWhere += " and IsHasImage =0 ";

            return strWhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "id";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName);

            //无信息类型之分
            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("调用数量") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("调用数量"));

            if (base.ParamInfo.GetValue("标题字数") != "")
                queryParam.TitleFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("标题字数"));

            if (base.ParamInfo.GetValue("日期格式") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("日期格式");

            if (base.ParamInfo.GetValue("信息描述字数") != "")
                queryParam.ProductSummaryFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("信息描述字数"));

            queryParam.Order = " order by " + base.ParamInfo.GetValue("排序字段") + " " + base.ParamInfo.GetValue("排序方式") + " ";

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
