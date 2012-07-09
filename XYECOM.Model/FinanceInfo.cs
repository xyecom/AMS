using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    #region  财务信息属性
    /// <summary>
    /// 财务信息实体类
    /// </summary>
    public class FinanceInfo
    {
        private System.Int64 _F_ID;
        private string  _U_Name;
        private System.Int32 _UM_ID;
        private System.Decimal _M_Money;
        private System.Int32 _FT_ID;
        private string _F_Remark;

        public FinanceInfo()
        {
            _F_ID = 0;
            _U_Name = "";
            _UM_ID = 0;
            _M_Money = 0;
            _FT_ID = 0;
            _F_Remark = "";
        }


        public System.Int64 F_ID
        {
            set { _F_ID = value; }
            get { return _F_ID; }
        }
        public string U_Name
        {
            set { _U_Name = value; }
            get { return _U_Name; }
        }
        public System.Int32 UM_ID
        {
            set { _UM_ID = value; }
            get { return _UM_ID; }
        }
        public System.Decimal M_Money
        {
            set { _M_Money = value; }
            get { return _M_Money; }
        }
        public System.Int32 FT_ID
        {
            set { _FT_ID = value; }
            get { return _FT_ID; }
        }
        public string F_Remark
        {
            set { _F_Remark = value; }
            get { return _F_Remark; }
        }

    }
    #endregion
}
