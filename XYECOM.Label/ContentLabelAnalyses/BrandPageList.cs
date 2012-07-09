using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// Ʒ����Ϣ��ҳ�б��ǩ������
    /// </summary>
    internal class BrandPageList : ContentLabelManager
    {
        public BrandPageList()
        {
            base.LabelContentType = ContentLabelType.Pagination;
        }

        protected override string GetCondition()
        {
            return base.StrPageSearchWhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "B_ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.L_StyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName, base._LabelInfo.L_StyleContent);

            queryParam.Condition = GetCondition();

            if (base.CustomPageSize != 0) PageSize = base.CustomPageSize;

            if (PageSize == 0)
            {
                if (base.ParamInfo.GetValue("��������") != "")
                {
                    base.PageSize = Core.MyConvert.GetInt32(base.ParamInfo.GetValue("��������"));
                }
            }

            if (base.ParamInfo.GetValue("��������") != "")
                queryParam.TitleFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("��������"));

            if (base.ParamInfo.GetValue("���ڸ�ʽ") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("���ڸ�ʽ");

            if (base.ParamInfo.GetValue("Ʒ��������ʾ����") != "")
                queryParam.ProductSummaryFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("Ʒ��������ʾ����"));

            if (base.ParamInfo.GetValue("��˾��������") != "")
                queryParam.CompanyNameFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("��˾��������"));

            if (!base.OuterParameter.OrderStr.Equals(""))
            {
                queryParam.SortFields = base.OuterParameter.OrderStr;
            }
            else
            {
                queryParam.SortFields = "UG_Order asc," + base.ParamInfo.GetValue("�����ֶ�") + " " + base.ParamInfo.GetValue("����ʽ");
            }

            return queryParam;
        }

        protected override System.Data.DataTable GetDataResult()
        {
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

            base.TotalRecord = totalRecord;

            base.SetPagination(base.PageIndex, base.PageURL, SEARCH_PAGE_LIST.SEARCH_SELLER_SEARCH, "brand");

            return table;
        }
    }
}
