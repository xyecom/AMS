using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Label
{
    /// <summary>
    /// ��Ѷ�б��ǩ������
    /// </summary>
    public class NewsList : ContentLabelManager
    {
        protected override string GetCondition()
        {
            //Ĭ�ϵ��ò�����������Ŀ�µ���Ѷ
            bool isIncludeHideNews = false;

            string strWhere = " where (AuditingState = 1)";

            if (base.OuterParameter.AreaId > 0)
                strWhere += " and (" + GetAreaWhere(base.OuterParameter.AreaId) + ")";

            if (base.OuterParameter.TradeId > 0)
                strWhere += " and (charindex('," + base.OuterParameter.TradeId + ",',TradeIds) >0) ";

            if (base.OuterParameter.ProTypeId > 0)
                strWhere += " and (charindex('," + base.OuterParameter.ProTypeId + ",',ProTypeIds) >0) ";

            if (base.ParamInfo.GetValue("�������") != "")
                strWhere += " and (NS_Count >=" + base.ParamInfo.GetValue("�������") + ")";

            if (base.ParamInfo.GetValue("�Ƿ��Ƽ�") != "")
                strWhere += " and (NS_IsCommand=" + base.ParamInfo.GetValue("�Ƿ��Ƽ�") + ")";

            if (base.ParamInfo.GetValue("Ͷ����Ѷ") != "")
            {
                if (base.ParamInfo.GetValue("Ͷ����Ѷ") == "1")
                {
                    strWhere += " and (Contributor <> 0) ";
                }
                if (base.ParamInfo.GetValue("Ͷ����Ѷ") == "0")
                {
                    strWhere += " and (Contributor=0) ";
                }
            }

            if (base.ParamInfo.GetValue("��Ѷ��Ŀ") != "")
            {
                XYECOM.Model.NewsTitlesInfo info = new XYECOM.Business.NewsTitles().GetItem(Core.MyConvert.GetInt32(base.ParamInfo.GetValue("��Ѷ��Ŀ")));

                if (info != null)
                {
                    strWhere += " and (" + Business.Utils.GetNewsChannelQueryWhere(Core.MyConvert.GetInt32(base.ParamInfo.GetValue("��Ѷ��Ŀ"))) + ")";

                    //�����ǰ��ĿΪ������Ŀ�����������������Ŀ�µ���Ѷ
                    if (!info.IsShow) isIncludeHideNews = true;
                }
            }

            if (!isIncludeHideNews) strWhere += " and nt_isshow = 1";

            if (base.ParamInfo.GetValue("ר������") != "")
                strWhere += " and (TopicType='" + base.ParamInfo.GetValue("ר������") + "' or  PATINDEX ('" + base.ParamInfo.GetValue("ר������") + ",%',TopicType) >0 or  PATINDEX('%," + base.ParamInfo.GetValue("ר������") + ",%',TopicType) >0 or  PATINDEX('%," + base.ParamInfo.GetValue("ר������") + "',TopicType) >0)";

            //Ϊ���ݣ��ϱ�ǩ�ֶ�Ϊ���Ƿ���ʾ����ͼ
            if (base.ParamInfo.GetValue("�Ƿ���ʾ����ͼ") == "1")
                strWhere += " and (IsHasImage > 0) ";
            if (base.ParamInfo.GetValue("�Ƿ���ʾ����ͼ") == "0")
                strWhere += " and (IsHasImage = 0) ";

            //���ֶΣ��Ƿ�ΪͼƬ��Ѷ
            if (base.ParamInfo.GetValue("�Ƿ�ΪͼƬ��Ѷ") == "1")
                strWhere += " and (IsHasImage > 0 Or NS_PicUrl <>'')";
            if (base.ParamInfo.GetValue("�Ƿ�ΪͼƬ��Ѷ") == "0")
                strWhere += " and (IsHasImage = 0 and NS_PicUrl ='')";

            if (!base.ParamInfo.GetValue("��Ѷ����").Equals("����"))
            {
                if (base.ParamInfo.GetValue("��Ѷ����").Equals("ͷ��"))
                {
                    strWhere += " and (NS_IsTop =1)";
                }
                if (base.ParamInfo.GetValue("��Ѷ����").Equals("�ȵ�"))
                {
                    strWhere += " and (NS_IsHot =1)";
                }
                if (base.ParamInfo.GetValue("��Ѷ����").Equals("�õ�"))
                {
                    strWhere += " and (NS_IsSlide =1)";
                }
                if (base.ParamInfo.GetValue("��Ѷ����").Equals("����ʽ�ɹ�"))
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

            if (base.ParamInfo.GetValue("��������") != "")
                PageSize = Convert.ToInt32(base.ParamInfo.GetValue("��������"));

            if (base.ParamInfo.GetValue("��������") != "")
                queryParam.TitleFontNumbers = Convert.ToInt32(base.ParamInfo.GetValue("��������"));

            if (base.ParamInfo.GetValue("���ڸ�ʽ") != "")
                queryParam.DateFormat = base.ParamInfo.GetValue("���ڸ�ʽ");

            if (base.ParamInfo.GetValue("���ŵ�������") != "")
                queryParam.NewsLeadinFontNumber = Convert.ToInt32(base.ParamInfo.GetValue("���ŵ�������"));


            queryParam.Order = " order by " + base.ParamInfo.GetValue("�����ֶ�") + " " + base.ParamInfo.GetValue("����ʽ") + " ";

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
