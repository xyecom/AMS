using System;
using System.Collections.Generic;
using System.Text;


namespace XYECOM.Model
{
     /// <summary>
     /// ������Դʵ����
     /// </summary>
    public class NewsOriginInfo
    {
        

        private int _no_id;
        private string  _no_name;

        public NewsOriginInfo() {
            _no_id = 0;
            _no_name = "";
        }

         /// <summary>
         /// ����������ԴIDֵ
         /// </summary>
        public int NO_ID
        {
            set { _no_id = value; }
            get { return _no_id; }
        }
         /// <summary>
         /// ����������Դ����
         /// </summary>
        public string NO_Name
        {
            set { _no_name = value; }
            get { return _no_name; }
        }
    }
}
