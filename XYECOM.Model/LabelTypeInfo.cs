using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 标签分类实体类
    /// </summary>
    public class LabelTypeInfo
    {
        private int _LT_ID;
        private string _LT_Name;
        private int _LT_ParentID;
        private string _LT_Remark;

        public LabelTypeInfo() {
            _LT_ID = 0;
            _LT_Name = "";
            _LT_ParentID = 0;
            _LT_Remark = "";
        }

        public int LT_ID
        {
            set { _LT_ID = value; }
            get { return _LT_ID; }
        }

        public string LT_Name
        {
            set { _LT_Name = value; }
            get { return _LT_Name; }
        }

        public int LT_ParentID
        {
            set { _LT_ParentID = value; }
            get { return _LT_ParentID; }
        }

        public string LT_Remark
        {
            set { _LT_Remark = value; }
            get { return _LT_Remark; }
        }
    }
}
