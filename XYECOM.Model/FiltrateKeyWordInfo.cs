using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ���˹ؼ�����Ϣʵ����
    /// </summary>
    public class FiltrateKeyWordInfo
    {
        #region FiltrateKeyWord
        private int _fkw_id;
        private string _fkw_name;

        public FiltrateKeyWordInfo()
        {
            _fkw_id = 0;
            _fkw_name = "";
        }


        /// <summary>
        /// 
        /// </summary>
        public int FKW_ID
        {
            set { _fkw_id = value; }
            get { return _fkw_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FKW_Name
        {
            set { _fkw_name = value; }
            get { return _fkw_name; }
        }
        #endregion Model
    }

}
