using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Label
{
    /// <summary>
    /// 资讯列表标签解析类
    /// </summary>
    public class NewsList : ContentLabelManager
    {
        protected override string GetCondition()
        {
            //默认调用不包含隐藏栏目下的资讯
            bool isIncludeHideNews = false;

            string strWhere = " where (AuditingState = 1)";

            if (base.OuterParameter.AreaId > 0)
                strWhere += " and (" + GetAreaWhere(base.OuterParameter.AreaId) + ")";

            if (base.OuterParameter.TradeId > 0)
                strWhere += " and (charindex('," + base.OuterParameter.TradeId + ",',TradeIds) >0) ";

            if (base.OuterParameter.ProTypeId > 0)
                strWhere += " and (charindex('," + base.OuterParameter.ProTypeId + ",',ProTypeIds) >0) ";

            if (base.ParamInfo.GetValue("点击次数") != "")
                strWhere += " and (NS_Count >=" + base.ParamInfo.GetValue("点击次数") + ")";

            if (base.ParamInfo.GetValue("是否推荐") != "")
                strWhere += " and (NS_IsCommand=" + base.ParamInfo.GetValue("是否推荐") + ")";

            if (base.ParamInfo.GetValue("投稿资讯") != "")
            {
                if (base.ParamInfo.GetValue("投稿资讯") == "1")
                {
                    strWhere += " and (Contributor <> 0) ";
                }
                if (base.ParamInfo.GetValue("投稿资讯") == "0")
                {
                    strWhere += " and (Contributor=0) ";
                }
            }

            if (base.ParamInfo.GetValue("资讯栏目") != "")
            {
                XYECOM.Model.NewsTitlesInfo info = new XYECOM.Business.NewsTitles().GetItem(Core.MyConvert.GetInt32(base.ParamInfo.GetValue("资讯栏目")));

                if (info != null)
                {
                    strWhere += " and (" + Business.Utils.GetNewsChannelQueryWhere(Core.MyConvert.GetInt32(base.ParamInfo.GetValue("资讯栏目"))) + ")";

                    //如果当前栏目为隐藏栏目，则允许调用隐藏栏目下的资讯
                    if (!info.IsShow) isIncludeHideNews = true;
                }
            }

            if (!isIncludeHideNews) strWhere += " and nt_isshow = 1";

            if (base.ParamInfo.GetValue("专题属性") != "")
                strWhere += " and (TopicType='" + base.ParamInfo.GetValue("专题属性") + "' or  PATINDEX ('" + base.ParamInfo.GetValue("专题属性") + ",%',TopicType) >0 or  PATINDEX('%," + base.ParamInfo.GetValue("专题属性") + ",%',TopicType) >0 or  PATINDEX('%," + base.ParamInfo.GetValue("专题属性") + "',TopicType) >0)";

            //为兼容，老标签字段为：是否显示缩略图
            if (base.ParamInfo.GetValue("是否显示缩略图") == "1")
                strWhere += " and (IsHasImage > 0) ";
            if (base.ParamInfo.GetValue("是否显示缩略图") == "0")
                strWhere += " and (IsHasImage = 0) ";

            //新字段，是否为图片资讯
            if (base.ParamInfo.GetValue("是否为图片资讯") == "1")
                strWhere += " and (IsHasImage > 0 Or NS_PicUrl <>'')";
            if (base.ParamInfo.GetValue("是否为图片资讯") == "0")
                strWhere += " and (IsHasImage = 0 and NS_PicUrl ='')";

            if (!base.ParamInfo.GetValue("资讯类型").Equals("基本"))
            {
                if (base.ParamInfo.GetValue("资讯类型").Equals("头条"))
                {
                    strWhere += " and (NS_IsTop =1)";
                }
                if (base.ParamInfo.GetValue("资讯类型").Equals("热点"))
                {
                    strWhere += " and (NS_IsHot =1)";
                }
                if (base.ParamInfo.GetValue("资讯类型").Equals("幻灯"))
                {
                    strWhere += " and (NS_IsSlide =1)";
                }
                if (base.ParamInfo.GetValue("资讯类型").Equals("方案式采购"))
                {
                    strWhere += " and (IsScheme =1)";
                }
            }
            return strWhere;
        }

        private string GetAreaWhere(int araeId)
        {
            Business.Area areaBLL = new XYECOM.Business.Area();
            string idlist = areaBLL.GetSubIds(araeId);

            if (idlist.Equals("")) return "";

            string[] arrID = idlist.Split(',');
            string tmpwhere = "";

            for (int i = 0; i < arrID.Length; i++)
            {
                int curAreaId = Core.MyConvert.GetInt32(arrID[i]);

                if (curAreaId <= 0) continue;

                tmpwhere += tmpwhere == "" ? "" : " or ";

                tmpwhere += " charindex ('," + curAreaId + ",',AreaIds) >0";
            }

            return tmpwhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "NS_ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName);

            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("调用数量") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("调用数量"));

            if (base.ParamInfo.GetValue("标题字数") != "")
                queryParam.TitleFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("标题字数"));

            if (base.ParamInfo.GetValue("日期格式") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("日期格式");

            if (base.ParamInfo.GetValue("新闻导读字数") != "")
                queryParam.NewsLeadinFontNumber = Convert.ToInt32(base.ParamInfo.GetValue("新闻导读字数"));


            queryParam.Order = " order by " + base.ParamInfo.GetValue("排序字段") + " " + base.ParamInfo.GetValue("排序方式") + " ";

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
