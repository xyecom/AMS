using System;
using System.Collections.Generic;
using System.Text;


namespace XYECOM.Model
{
    /// <summary>
    /// ��ֵ��ϸʵ����
    /// </summary>
    public class UserInputMoneyInfo
    {
        private System.Int64 _IM_ID;
        private System.Int64 _U_ID;
        private System.Int64 _UM_ID;
        private System.Int64 _FT_ID;
        private System.Decimal _IM_Count;
        private System.Int32 _PM_ID;
        /// <summary>
        /// ��ֵ���
        /// </summary>
        private System.Int64 IM_ID
        {
            get { return _IM_ID; }
            set { _IM_ID = value; }
        }
        /// <summary>
        /// �û����
        /// </summary>
        public System.Int64 U_ID
        {
            get { return _U_ID; }
            set { _U_ID = value; }
        }
        /// <summary>
        /// ����Ա���
        /// </summary>
        public System.Int64 UM_ID
        {
            get { return _UM_ID; }
            set { _UM_ID = value; }
        }
        /// <summary>
        /// ���������
        /// </summary>
        public System.Int64 FT_ID
        {
            get { return _FT_ID; }
            set { _FT_ID = value; }
        }
        /// <summary>
        /// ��ֵ���
        /// </summary>
        public System.Decimal IM_Count
        {
            get { return _IM_Count; }
            set { _IM_Count = value; }
        }
        /// <summary>
        /// ֧�����
        /// </summary>
        public System.Int32 PM_ID
        {
            get { return _PM_ID; }
            set { _PM_ID = value; }
        }

        private string _OrderID;

        public string OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }

        private string _PlatformFlag;

        public string PlatformFlag
        {
            get { return _PlatformFlag; }
            set { _PlatformFlag = value; }
        }
    }
}

