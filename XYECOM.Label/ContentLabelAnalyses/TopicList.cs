using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// ר���б��ǩ������
    /// </summary>
    internal class TopicList : ContentLabelManager
    {
        protected override string GetCondition()
        {
            string strWhere = " where 1=1 ";

            if (base.ParamInfo.GetValue("ר������") != "all")
            {
                if ("general".Equals(base.ParamInfo.GetValue("ר������")))
                    strWhere += " and (TopicType is null Or topicType='')";

                if("news".Equals(base.ParamInfo.GetValue("ר������")))
                    strWhere += " and topicType='news'";
            }

            if (base.ParamInfo.GetValue("�������") != "")
                strWhere += " and ShowNum >=" + base.ParamInfo.GetValue("�������");

            if (base.ParamInfo.GetValue("��Ϣ���") != "")
                strWhere += " and TCID=" + base.ParamInfo.GetValue("��Ϣ���");

            if (base.ParamInfo.GetValue("�Ƿ��Ƽ�") != "")
                strWhere += " and Commend=" + base.ParamInfo.GetValue("�Ƿ��Ƽ�");

            if (base.ParamInfo.GetValue("�Ƿ���ʾ����ͼ") != "")
                strWhere += " and Flag = " + base.ParamInfo.GetValue("�Ƿ���ʾ����ͼ") + " ";

            return strWhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName);

            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("��������") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("��������"));

            if (base.ParamInfo.GetValue("��������") != "")
                queryParam.TitleFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("��������"));

            if (base.ParamInfo.GetValue("���ڸ�ʽ") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("���ڸ�ʽ");

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
