using System;
using System.Collections.Generic;
using System.Text;


namespace XYECOM.Model
{
    /// <summary>
    /// ����Ա��Ϣʵ����
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
        /// ����Ա���
        /// </summary>
        public int UM_ID
        {
            get { return _UM_ID; }
            set { _UM_ID = value; }
        }
        /// <summary>
        /// ����Ա����
        /// </summary>
        public string UM_Pwd
        {
            get { return _UM_Pwd; }
            set { _UM_Pwd = value; }
        }
        /// <summary>
        /// ����Ա��ɫ���
        /// </summary>
        public int UR_ID
        {
            get { return _UR_ID; }
            set { _UR_ID = value; }
        }
        /// <summary>
        /// ����Ա����
        /// </summary>
        public string UM_Name
        {
            get { return _UM_Name; }
            set { _UM_Name = value; }
        }
        #endregion
    }
}
