using System;
using System.Collections.Generic;
using System.Text;


namespace XYECOM.Model
{
    /// <summary>
    /// 管理员信息实体类
    /// </summary>
    public class AdminInfo
    {
        #region Admin
        private int _UM_ID;
        private int _UR_ID;
        private string _UM_Pwd;
        private string _UM_Name;

        public AdminInfo()
        {
            _UM_ID = 0;
            _UR_ID = 0;
            _UM_Pwd = "";
            _UM_Name = "";
        }

        /// <summary>
        /// 管理员编号
        /// </summary>
        public int UM_ID
        {
            get { return _UM_ID; }
            set { _UM_ID = value; }
        }
        /// <summary>
        /// 管理员密码
        /// </summary>
        public string UM_Pwd
        {
            get { return _UM_Pwd; }
            set { _UM_Pwd = value; }
        }
        /// <summary>
        /// 管理员角色编号
        /// </summary>
        public int UR_ID
        {
            get { return _UR_ID; }
            set { _UR_ID = value; }
        }
        /// <summary>
        /// 管理员名称
        /// </summary>
        public string UM_Name
        {
            get { return _UM_Name; }
            set { _UM_Name = value; }
        }
        #endregion
    }
}
