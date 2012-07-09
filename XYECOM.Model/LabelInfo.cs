using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 标签信息实体类
    /// </summary>
    public class LabelInfo
    {
        private long _id;
        private string _L_Name;
        private string _L_CName;
        private int _LT_ID;
        private string _L_TableName;
        private string _L_Content;
        private string l_StyleHead;         //样式开始标记
        private string l_StyleContent;      //样式内容
        private string l_StyleFooter;     //样式结束标记

        public LabelInfo()
        {
            _id = 0;
            _L_Name = "";
            _L_CName = "";
            _LT_ID = 0;
            _L_TableName = "";
            _L_Content = "";
            l_StyleFooter = "";
            l_StyleHead = "";
            l_StyleContent = "";
        }

        public long Id
        {
            set { _id = value; }
            get { return _id; }
        }

        public string LabelName
        {
            set { _L_Name = value; }
            get { return _L_Name; }
        }

        public string LabelCName
        {
            set { _L_CName = value; }
            get { return _L_CName; }
        }

        public int LabelTypeId
        {
            set { _LT_ID = value; }
            get { return _LT_ID; }
        }

        public string LabelTableName
        {
            set { _L_TableName = value; }
            get { return _L_TableName; }
        }

        public string LabelContent
        {
            set { _L_Content = value; }
            get { return _L_Content; }
        }
        public string LabelStyleFooter
        {
            get { return l_StyleFooter; }
            set { l_StyleFooter = value; }
        }

        public string LabelStyleHead
        {
            get { return l_StyleHead; }
            set { l_StyleHead = value; }
        }
        public string LabelStyleContent
        {
            get { return l_StyleContent; }
            set { l_StyleContent = value; }
        }

        public string LabelDescription
        {
            get;
            set;
        }

        public Model.LabelRange LabelRange
        {
            get;
            set;
        }
        public string GroupIdOrUserId
        {
            get;
            set;
        }
        public string LabelRangeData
        {
            get
            {
                return string.Format("{0}:{1}", LabelRange.ToString(), GroupIdOrUserId);
            }
        }
    }
}
