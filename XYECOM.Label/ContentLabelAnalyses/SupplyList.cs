using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Label
{
    /// <summary>
    /// 供求信息列表标签解析类
    /// </summary>
    internal class SupplyList : ContentLabelManager
    {
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
            string strWhere = " where AuditingState = 1 and UserAuditingState=1 and SD_IsSupply = 1 and SD_EndDate > '" + DateTime.Now + "' ";

            if (base.OuterParameter.AreaId > 0)
                strWhere += " and Area_id in (" + Business.XYClass.GetSubIds("area", base.OuterParameter.AreaId) + ")";

            if (base.OuterParameter.TradeId > 0)
                strWhere += " and charindex('," + base.OuterParameter.TradeId + ",',UserTradeIds) >0";

            ///如果为产品首页标签，则以当前产品分类为准，忽略其他分类条件
            if (base.OuterParameter.ProTypeId > 0)
            {
                strWhere += " and PT_ID in(" + Business.XYClass.GetSubIds("offer", base.OuterParameter.ProTypeId) + ")";
            }
            else
            {
                if (base.ParamInfo.GetValue("信息类别") != "")
                {
                    string[] pars = base.ParamInfo.GetValue("信息类别").Split(':');

                    if (pars[1].Equals("") || pars[1].Equals("0"))
                    {
                        strWhere += " and moduleName='" + pars[0] + "'";
                    }
                    else
                    {
                        strWhere += " and ( PT_ID = " + pars[1] + " Or Charindex('," + pars[1] + ",',FullId) > 0)";
                    }
                }
            }

            string companyTypeId = base.ParamInfo.GetValue("用户自定义分类编号");
            int cptid = 0;

            if (!string.IsNullOrEmpty("companyTypeId") && (cptid = XYECOM.Core.MyConvert.GetInt32(companyTypeId)) > 0)
            {
                strWhere += " and CompanyProductTypeid in (" + Business.XYClass.GetSubIds("companytype", cptid) + ")";
            }


            //如果在选择标签条件时选择了参与保证合同，那么就一定不参与产品保障
            //否则
            //  如果选择了 产品保障条件，一定不参与合同保障
            //  否则不加任何条件
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

            if (base.ParamInfo.GetValue("点击次数") != "")
                strWhere += " and (SD_ClickNum >=" + base.ParamInfo.GetValue("点击次数") + ")";

            if (base.ParamInfo.GetValue("是否推荐") != "")
                strWhere += " and (SD_Vouch=" + base.ParamInfo.GetValue("是否推荐") + ")";

            if (base.ParamInfo.GetValue("是否显示缩略图") == "1")
                strWhere += " and IsHasImage >0 ";
            if (base.ParamInfo.GetValue("是否显示缩略图") == "0")
                strWhere += " and IsHasImage = 0 ";

            if (base.ParamInfo.GetValue("信息类型") != "0")
                strWhere += " and SD_Flag=" + base.ParamInfo.GetValue("信息类型");

            return strWhere;
        }
        /// <summary>
        /// 分析原始参数组合成查询参数
        /// </summary>
        /// <returns></returns>
        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "SD_ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName, base._LabelInfo.LabelStyleContent);

            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("调用数量") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("调用数量"));

            if (base.ParamInfo.GetValue("标题字数") != "")
                queryParam.TitleFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("标题字数"));

            if (base.ParamInfo.GetValue("日期格式") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("日期格式");

            if (base.ParamInfo.GetValue("信息描述字数") != "")
                queryParam.ProductSummaryFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("信息描述字数"));

            if (base.ParamInfo.GetValue("公司名称字数") != "")
                queryParam.CompanyNameFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("公司名称字数"));

            queryParam.InfoType = base.ParamInfo.GetValue("信息类型");

            queryParam.Order = "Order by ";

            if (base.ParamInfo.GetValue("优先以会员等级排序") == "1")
                queryParam.Order += "UG_Order asc,";

            queryParam.Order += base.ParamInfo.GetValue("排序字段") + " " + base.ParamInfo.GetValue("排序方式") + " "; ;

            return queryParam;
        }
    }
}
