using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 用户账户信息实体类
    /// </summary>
    public class UserAccountInfo
    {
        private System.Int32 _UGR_ID;
        private System.Int64 _U_ID;
        private System.Decimal _UGR_Money;
        private System.Decimal _UGR_LeftMoney;

        public System.Int32 UGR_ID
        {
            set { _UGR_ID = value; }
            get { return _UGR_ID; }

        }
        
        public System.Int64 U_ID
        {
            set { _U_ID = value; }
            get { return _U_ID; }
        }
        
        public System.Decimal UGR_Money
        {
            set { _UGR_Money = value; }
            get { return _UGR_Money; }
        }

        public System.Decimal UGR_LeftMoney
        {
            get { return _UGR_LeftMoney; }
            set { _UGR_LeftMoney = value; }
        }

    }
}
