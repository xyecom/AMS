using System;
using System.Collections.Generic;


namespace XYECOM.Model
{
    /// <summary>
    /// 用户虚拟账户信息实体类
    /// </summary>
    public class UserFictitiouCountInfo
    {
        private System.Int32 _C_ID;
        private System.Int64 _U_ID;
        private System.Decimal _C_SumMoney;
        private System.Decimal _C_LeftMoney;
        public System.Int32 C_ID
        {
            get { return _C_ID; }
            set { _C_ID = value; }
        }
        public System.Int64 U_ID
        {
            get { return _U_ID; }
            set { _U_ID = value; }
        }
        public System.Decimal C_SumMoney
        {
            get { return _C_SumMoney; }
            set { _C_SumMoney = value; }
        }
        public System.Decimal C_LeftMoney
        {
            get { return _C_LeftMoney; }
            set { _C_LeftMoney = value; }
        }


    }
}
