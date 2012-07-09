using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ���̼�����Ϣʵ����
    /// </summary>
    public class InviteBusinessmanInfo : BaseInfo
    {
        //private Int64 _a_id;
        private string _a_area;
        private string _a_advice;
        private string _a_reason;

        public InviteBusinessmanInfo()
        {
            ModuleFlag = "investment";
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string A_Area
        {
            get { return _a_area; }
            set { _a_area = value; }
        }

        private string _AreaName;

        public string AreaName
        {
            get { return _AreaName; }
            set { _AreaName = value; }
        }

        /// <summary>
        /// �Ƽ����
        /// </summary>
        public string A_Advice
        {
            set { _a_advice = value; }
            get { return _a_advice; }
        }

        /// <summary>
        /// δͨ��ԭ��
        /// </summary>
        public string A_Reason
        {
            set { _a_reason = value; }
            get { return _a_reason; }
        }

        #region ����������ֵ

        private string quondamProduct;
        /// <summary>
        /// ��ǰ����Ĳ�Ʒ����
        /// </summary>
        public string QuondamProduct
        {
            get { return quondamProduct; }
            set { quondamProduct = value; }
        }

        private string support;
        /// <summary>
        /// ���ṩ֧��
        /// </summary>
        public string Support
        {
            get { return support; }
            set { support = value; }
        }

        private string demand;
        /// <summary>
        /// �Դ�����Ҫ��
        /// </summary>
        public string Demand
        {
            get { return demand; }
            set { demand = value; }
        }

        private string url;
        /// <summary>
        /// ���̵���ַ
        /// </summary>
        public string URL
        {
            get { return url; }
            set { url = value; }
        }

        #endregion
    }
}
