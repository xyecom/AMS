using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 用户当前等级属性数据实体类
    /// </summary>
    public class UserGradeRelationInfo
    {
        private System.Int64 _UR_ID;
        private System.Int64 _U_ID;
        private System.Int16 _UGR_ID;
        private System.DateTime   _U_BeginTime;
        private System.String  _U_EndTime;
        public System.Decimal _U_Money;
        private bool _UR_Flag;

        public System.Int64 UR_ID
        {
            get { return _UR_ID; }
            set { _UR_ID = value; }
        }
        public System.Int64 U_ID
        {
            get { return _U_ID; }
            set { _U_ID = value; }
        }
        public System.Int16 UGR_ID
        {
            get { return _UGR_ID; }
            set { _UGR_ID = value; }
        }
        public System.DateTime U_BeginTime
        {
            get { return _U_BeginTime; }
            set { _U_BeginTime = value; }
        }
        public System.String   U_EndTime
        {
            get { return _U_EndTime; }
            set { _U_EndTime = value; }
        }
        public System.Decimal U_Money
        {
            get { return _U_Money; }
            set { _U_Money = value; }
        }
        public bool UR_Flag
        {
            get { return _UR_Flag; }
            set { _UR_Flag = value; }
        }
    }

}
