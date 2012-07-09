using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// Ͷ������Ϣʵ����
    /// </summary>
    public class DemandInfo : BaseInfo
    {
        private string _a_reason;
        private string _a_advice;


        public DemandInfo()
        {
            ModuleFlag = "venture";
        }

        /// <summary>
        /// δͨ��ԭ��
        /// </summary>
        public string A_Reason
        {
            set { _a_reason = value; }
            get { return _a_reason; }
        }
        /// <summary>
        /// �Ƽ����
        /// </summary>
        public string A_Advice
        {
            set { _a_advice = value; }
            get { return _a_advice; }
        }

        #region �����µ�����

        private string trade;
        /// <summary>
        /// Ͷ����������ҵ
        /// </summary>
        public string Trade
        {
            get { return trade; }
            set { trade = value; }
        }

        private int typeId;
        /// <summary>
        /// ����id
        /// </summary>
        public int TypeId
        {
            get { return typeId; }
            set { typeId = value; }
        }

        private string typeName = string.Empty;

        /// <summary>
        /// Ͷ��������
        /// </summary>
        public string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }

        private string area = string.Empty;

        /// <summary>
        /// Ͷ���ʵ���
        /// </summary>
        public string Area
        {
            get { return area; }
            set { area = value; }
        }

        private string webSite = string.Empty;

        /// <summary>
        /// ������Ŀ��ַ
        /// </summary>
        public string WebSite
        {
            get { return webSite; }
            set { webSite = value; }
        }
        private string summary = string.Empty;

        /// <summary>
        /// ��ĿժҪ
        /// </summary>
        public string Summary
        {
            get { return summary; }
            set { summary = value; }
        }

        private int tradeId;
        /// <summary>
        /// ������ҵ���
        /// </summary>
        public int TradeId
        {
            get { return tradeId; }
            set { tradeId = value; }
        }

        private int areaId;

        /// <summary>
        /// Ͷ���ʵ������
        /// </summary>
        public int AreaId
        {
            get { return areaId; }
            set { areaId = value; }
        }
        #endregion
    }
}
