using System;
using System.Collections.Generic;
using System.Text;


namespace XYECOM.Model
{
     /// <summary>
     /// ��������ʵ����
     /// </summary>
    public class NewsAuthorInfo
    {
        

        private int _na_id;
        private string _na_name;

        public NewsAuthorInfo() {
            _na_id = 0;
            _na_name = "";
        }


         /// <summary>
         /// ��������ID
         /// </summary>
        public int NA_ID
        {
            set { _na_id = value; }
            get { return _na_id; }
        }
         /// <summary>
         /// ������������
         /// </summary>
        public string NA_Name
        {
            set { _na_name = value; }
            get { return _na_name; }
        }
    }
}
