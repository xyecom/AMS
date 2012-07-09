using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// չ���б��ǩ������
    /// </summary>
    internal class ShowList : ContentLabelManager
    {
        protected override string GetCondition()
        {
            string strWhere = " where 1=1 ";

            if (base.ParamInfo.GetValue("��Ϣ���") != "")
            {
                string typeId = ""; 

                if (base.ParamInfo.GetValue("��Ϣ���").IndexOf(':') != -1)
                {
                    typeId = base.ParamInfo.GetValue("��Ϣ���").Split(':')[1];
                }
                else
                { 
                    typeId = base.ParamInfo.GetValue("��Ϣ���");
                }

                if (!typeId.Equals("") && !typeId.Equals("0"))
                {
                    strWhere += " and ( typeid  = " + typeId + " Or charindex(',"+typeId+",',FullID) > 0)";
                }
            }

            if (base.ParamInfo.GetValue("չ������") != "����")
            {
                if (base.ParamInfo.GetValue("չ������") == "����չ")
                {
                    strWhere += " and type='����չ' ";
                }

                if (base.ParamInfo.GetValue("չ������") == "����չ")
                {
                    strWhere += " and type='����չ' ";
                }
            }

            if (base.ParamInfo.GetValue("�Ƿ��Ƽ�") != "")
                strWhere += " and IsCommend=" + base.ParamInfo.GetValue("�Ƿ��Ƽ�");

            if (base.ParamInfo.GetValue("�Ƿ����ͼƬ") == "1")
                strWhere += " and IsHasImage >0 ";
            if (base.ParamInfo.GetValue("�Ƿ����ͼƬ") == "0")
                strWhere += " and IsHasImage =0 ";

            return strWhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "id";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName);

            //����Ϣ����֮��
            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("��������") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("��������"));

            if (base.ParamInfo.GetValue("��������") != "")
                queryParam.TitleFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("��������"));

            if (base.ParamInfo.GetValue("���ڸ�ʽ") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("���ڸ�ʽ");

            if (base.ParamInfo.GetValue("��Ϣ��������") != "")
                queryParam.ProductSummaryFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("��Ϣ��������"));

            queryParam.Order = " order by " + base.ParamInfo.GetValue("�����ֶ�") + " " + base.ParamInfo.GetValue("����ʽ") + " ";

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
