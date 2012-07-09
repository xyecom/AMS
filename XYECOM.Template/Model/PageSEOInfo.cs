using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Template
{
    /// <summary>
    /// 页面SEO信息实体类
    /// </summary>
    public class PageSEOInfo
    {
        private string _Title = "";
        private string _Keywords = "";
        private string _Description = "";
        private string _Tags = "";
        private bool _Robots = false;

        /// <summary>
        /// title
        /// </summary>
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        /// <summary>
        /// keywords
        /// </summary>
        public string Keywords
        {
            get { return _Keywords; }
            set { _Keywords = value; }
        }

        /// <summary>
        /// description
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        /// <summary>
        /// tags
        /// </summary>
        public string Tags
        {
            get { return _Tags; }
            set { _Tags = value; }
        }

        /// <summary>
        /// robots
        /// </summary>
        public bool Robots
        {
            get { return _Robots; }
            set { _Robots = value; }
        }

        //名称全部小写，仅供模板中调用
        public string title{get { return _Title; }}
        public string keywords{get { return _Keywords; }}
        public string description{ get { return _Description; }}
        public string tags{get { return _Tags; }}
        public bool tobots{get { return _Robots; }}
    }
}
