using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 企业经营模式信息实体类
    /// </summary>
    public class ModeInfo
    {
        private System.Int32 _m_id;
        private string _m_type;

        public ModeInfo()
        {
            _m_id = 0;
            _m_type = "";
        }


        public System.Int32 M_ID
        {
            get { return _m_id; }
            set { _m_id = value; }
        }
        public string M_Type
        {
            get { return _m_type; }
            set { _m_type = value; }
        }
    }
}
    
    
   

    
   

