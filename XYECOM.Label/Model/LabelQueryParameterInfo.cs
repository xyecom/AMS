using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /**************************************************
     * XYECOM.Label.LabelParameter.cs
     * ������ʶ��TC 20080618
     * 
     * ������������ǩ����ʵ����
     * 
     *************************************************/

    /// <summary>
    /// ��ǩ���ݲ�ѯ����ʵ����
    /// </summary>
    public class LabelQueryParameterInfo
    {
        #region ͨ�ò���
        /// <summary>
        /// ����
        /// </summary>
        public string PrimaryKey = "";
        /// <summary>
        /// ������������
        /// </summary>
        public int TopNumbers = 0;
        /// <summary>
        /// ����
        /// </summary>
        public string Condition = "";

        #region ԭ���ݶ�ȡ������Ҫ���������
        /// <summary>
        /// ����
        /// </summary>
        public string Order = "";
        #endregion

        #region ����·��෽����Ҫ�Ĳ���
        /// <summary>
        /// �����ֶ�����
        /// </summary>
        private string sortFields ="";

        public string SortFields
        {
            get {
                if (string.IsNullOrEmpty(sortFields))
                    return "";

                return sortFields;
            }
            set 
            {
                sortFields = value;
            }
        }
        #endregion

        /// ����Դ����
        /// </summary>
        public string DataSourceName = "";
        /// <summary>
        /// ����������
        /// </summary>
        /// 
        private string columns;
        public string Columns
        {
            get 
            {
                if (String.IsNullOrEmpty(columns) || null == columns || columns.Trim().Equals(""))
                    columns = "*";

                return columns;
            }
            set 
            {
                columns = value;
            }
        }
        /// <summary>
        /// ��Ϣ��������
        /// </summary>
        public int TitleFontNumbers = 0;
        /// <summary>
        /// ��Ʒ��������
        /// </summary>
        public int ProductSummaryFontNumbers = 0;
        /// <summary>
        /// ��˾��������
        /// </summary>
        public int CompanyNameFontNumbers = 0;
        /// <summary>
        /// ��˾�������
        /// </summary>
        public int CompanySummaryFontNumbers = 0;
        /// <summary>
        /// ���ڸ�ʽ
        /// </summary>
        public string DateFormat = "";
        /// <summary>
        /// ��Ϣ����
        /// </summary>
        public string InfoType = "";

        #endregion

        #region ����ͨ��
        /// <summary>
        /// ������ĿId
        /// </summary>
        public int NewsChannelId = 0;

        /// <summary>
        /// ���ŵ�������
        /// </summary>
        public int NewsLeadinFontNumber = 0;

        #endregion

        #region �õ�����ר��

        /// <summary>
        /// �õƿ��
        /// </summary>
        public int SlideWidth =0;
        /// <summary>
        /// �õƸ߶�
        /// </summary>
        public int SlideHeight = 0;
        /// <summary>
        /// �õ��ı��߶�
        /// </summary>
        public int SlideTextHeight = 0;

        #endregion

        #region ��������ר��
        
        /// <summary>
        /// ������������
        /// </summary>
        public int FriendLinkType = 0;
        /// <summary>
        /// ����������ʾ
        /// </summary>
        public bool IsFriendLinkAlt = false;

        #endregion

        #region ���Źؼ���ר��
        public string ToPage = "";
        #endregion

        #region ģ������ ������ liujia 2008-11-17
        /// <summary>
        /// ģ������
        /// </summary>
        public string moduleName = "";
        #endregion
    }
}
