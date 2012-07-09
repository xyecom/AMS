using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Label
{
    /// <summary>
    /// ���������б��ǩ������
    /// </summary>
    public class FriendLink : ContentLabelManager
    {
        protected override string GetCondition()
        {
            string strWhere = " where FL_Flag = 1";

            //=============Ϊ�����޸Ĵ������ǰ�汾 ========================
            if (base.ParamInfo.GetValue("��������") != "")
                strWhere += " and FL_Type=" + base.ParamInfo.GetValue("��������");
            //==============================================================

            if (base.ParamInfo.GetValue("��������") != "")
                strWhere += " and FL_Type=" + base.ParamInfo.GetValue("��������");

            if (base.ParamInfo.GetValue("���ӷ���") != "")
                strWhere += " and FS_ID=" + base.ParamInfo.GetValue("���ӷ���");

            if (base.ParamInfo.GetValue("�Ƿ��Ƽ�") != "")
                strWhere += " and FL_IsCommend='" + base.ParamInfo.GetValue("�Ƿ��Ƽ�") + "'";

            return strWhere;
        }

        protected override LabelQueryParameterInfo GetQueryParameter()
        {
            LabelQueryParameterInfo queryParam = new LabelQueryParameterInfo();

            queryParam.PrimaryKey = "FL_ID";
            queryParam.Columns = GetColumnNames(base._LabelInfo.LabelStyleContent);
            queryParam.DataSourceName = DataSourceManager.GetDataSourceName(base.ParamInfo.LabelFlagName);

            queryParam.Condition = GetCondition();

            if (base.ParamInfo.GetValue("��������") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("��������"));

            if (base.ParamInfo.GetValue("������ʾ") != "")
                queryParam.IsFriendLinkAlt = XYECOM.Core.MyConvert.GetBoolean(base.ParamInfo.GetValue("������ʾ"));

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
