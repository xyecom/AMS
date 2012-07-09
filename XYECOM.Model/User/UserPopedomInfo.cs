using System;
using System.Collections.Generic;
using System.Text;


namespace XYECOM.Model
{
    /// <summary>
    /// 用户等级全新信息实体类
    /// </summary>
    public class UserPopedomInfo
    {
        private System.Int64 _P_ID;
        private string _P_TableName;
        private bool _P_IsPopedom;
        private System.Int32 _UR_ID;

        public System.Int64 P_ID
        {
            set { _P_ID = value; }
            get { return _P_ID; }
        }
        public string P_TableName
        {
            set { _P_TableName = value; }
            get { return _P_TableName; }
        }
        public bool P_IsPopedom
        {
            set { _P_IsPopedom = value; }
            get { return _P_IsPopedom; }
        }
        public System.Int32 UR_ID
        {
            set { _UR_ID = value; }
            get { return _UR_ID; }
        }
    }
}
