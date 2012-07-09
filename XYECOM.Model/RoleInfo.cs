using System;
using System.Collections.Generic;
using System.Text;


namespace XYECOM.Model
{
    /// <summary>
    /// 管理员角色信息实体类
    /// </summary>
    public class RoleInfo
    {
        private System.Int16 _UR_ID;
        private string _UR_Name;

        public System.Int16 UR_ID
        {
            get { return _UR_ID; }
            set { _UR_ID = value; }
        }
        public string UR_Name
        {
            get { return _UR_Name; }
            set { _UR_Name = value; }
        }
    }

}
