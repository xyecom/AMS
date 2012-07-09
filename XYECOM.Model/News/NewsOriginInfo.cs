using System;
using System.Collections.Generic;
using System.Text;


namespace XYECOM.Model
{
     /// <summary>
     /// 新闻来源实体类
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
         /// 定义新闻来源ID值
         /// </summary>
        public int NO_ID
        {
            set { _no_id = value; }
            get { return _no_id; }
        }
         /// <summary>
         /// 定义新闻来源名称
         /// </summary>
        public string NO_Name
        {
            set { _no_name = value; }
            get { return _no_name; }
        }
    }
}
