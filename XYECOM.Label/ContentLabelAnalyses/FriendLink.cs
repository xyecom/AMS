using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Label
{
    /// <summary>
    /// 友情链接列表标签解析类
    /// </summary>
    public class FriendLink : ContentLabelManager
    {
        protected override string GetCondition()
        {
            string strWhere = " where FL_Flag = 1";

            //=============为兼容修改错别字以前版本 ========================
            if (base.ParamInfo.GetValue("连接类型") != "")
                strWhere += " and FL_Type=" + base.ParamInfo.GetValue("连接类型");
            //==============================================================

            if (base.ParamInfo.GetValue("链接类型") != "")
                strWhere += " and FL_Type=" + base.ParamInfo.GetValue("链接类型");

            if (base.ParamInfo.GetValue("链接分类") != "")
                strWhere += " and FS_ID=" + base.ParamInfo.GetValue("链接分类");

            if (base.ParamInfo.GetValue("是否推荐") != "")
                strWhere += " and FL_IsCommend='" + base.ParamInfo.GetValue("是否推荐") + "'";

            return strWhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "FL_ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName);

            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("调用数量") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("调用数量"));

            if (base.ParamInfo.GetValue("连接提示") != "")
                queryParam.IsFriendLinkAlt = XYECOM.Core.MyConvert.GetBoolean(base.ParamInfo.GetValue("连接提示"));

            queryParam.Order = "";

            return queryParam;
        }

        protected override System.Data.DataTable GetDataResult()
        {
            DataTable table = XYECOM.Core.Function.GetDataTableForTop(PageSize,
                    base.QueryParamInfo.Columns,
                    base.QueryParamInfo.DataSourceName,
                    base.QueryParamInfo.Condition,
                    base.QueryParamInfo.Order);

            return table;
        }
    }
}
