using System;
using System.Collections.Generic;
using System.Text;


namespace XYECOM.Model
{      
    /// <summary>
    /// ���λ���ʵ����
    /// </summary>
    public class AdPlaceTypeInfo
    {
       
        private int _at_id;
        private string _at_name;
        private int _at_pid;
        private string _at_alt;

        public AdPlaceTypeInfo() {
            _at_id = 0;
            _at_name = "";
            _at_pid = 0;
            _at_alt = "";
        }
        
        #region AdPlaceType������
         /// <summary>
         /// ���λ����ID
         /// </summary>
        public int AT_ID
        {
            set { _at_id = value; }
            get { return _at_id; }
        }
         /// <summary>
         /// ���λ��������
         /// </summary>
        public string AT_Name
        {
            set { _at_name = value; }
            get { return _at_name; }
        }
         /// <summary>
         /// ���λ���ĸ�ID
         /// </summary>
        public int AT_PID
        {
            set { _at_pid = value; }
            get { return _at_pid; }
        }
         /// <summary>
         /// ���λ����˵��
         /// </summary>
        public string AT_Alt
        {
            set { _at_alt = value; }
            get { return _at_alt; }
        }
        #endregion
    }
}
