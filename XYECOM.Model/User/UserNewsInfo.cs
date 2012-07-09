using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 企业资讯信息实体类
    /// </summary>
    public class UserNewsInfo
    {
        private System.Int32 _N_ID;
        private System.Int64 _U_ID;
        private string _N_title;
        private string _N_content;
        private DateTime _addtime;
        private int _AuditingState;
        private int _titleInfoid;
        private int _state;
        private string _TowTitle;
        private string _TitleStyle;
        private string _KeyWord;
        private string _Author;
        private string _Origin;
        private int _Count;
        private string _Less;

        public int AuditingState
        {
            get { return _AuditingState; }
            set { _AuditingState = value; }
        }

        public System.Int32 NewsId
        {
            set
            {
                _N_ID = value;
            }
            get
            {
                return _N_ID;
            }
        }

        public System.Int64 UserId
        {
            set
            {
                _U_ID = value;
            }
            get
            {
                return _U_ID;
            }
        }

        public string Title
        {
            set
            {
                _N_title = value;
            }
            get
            {
                return _N_title;
            }
        }

        public string Content
        {
            set
            {
                _N_content = value;
            }
            get
            {
                return _N_content;
            }
        }

        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }

        public int TitleInfoId
        {
            set { _titleInfoid = value; }
            get { return _titleInfoid; }
        }

        public int State
        {
            set { _state = value; }
            get { return _state; }
        }

        public string TowTitle
        {
            get { return _TowTitle; }
            set { _TowTitle = value; }
        }
        
        public string TitleStyle
        {
            get { return _TitleStyle; }
            set { _TitleStyle = value; }
        }

        public string KeyWord
        {
            get { return _KeyWord; }
            set { _KeyWord = value; }
        }

        public string Author
        {
            get { return _Author; }
            set { _Author = value; }
        }

        public string Origin
        {
            get { return _Origin; }
            set { _Origin = value; }
        }

        public int Count
        {
            get { return _Count; }
            set { _Count = value; }
        }

        public string Less
        {
            get { return _Less; }
            set { _Less = value; }
        }

    }
}
