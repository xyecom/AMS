using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    #region 日志属性类
    /// <summary>
    /// 日志信息实体类
    /// </summary>
    public class LogInfo
    {
        private System.Int32 _L_ID;
        private string _L_Title;
        private string _L_Content;
        private System.Int32 _UM_ID;
        private string _L_MF;
        private DateTime _L_addtime;

        public LogInfo()
        {
            _L_ID = 0;
            _L_Title = "";
            _L_Content = "";
            _UM_ID = 0;
            _L_MF = "";
        }

        public System.Int32 L_ID
        {
            set { _L_ID = value; }
            get { return _L_ID; }
        }
        public string L_Title
        {
            set { _L_Title = value; }
            get { return _L_Title; }
        }
        public string L_Content
        {
            set { _L_Content = value; }
            get { return _L_Content; }
        }
        public System.Int32 UM_ID
        {
            set { _UM_ID = value; }
            get { return _UM_ID; }
        }
        public string L_MF
        {
            set { _L_MF = value; }
            get { return _L_MF; }
        }

        public DateTime L_AddTime
        {
            set { _L_addtime = value; }
            get { return _L_addtime; }
        }
    }
    #endregion 

}
