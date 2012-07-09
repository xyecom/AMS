using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Configuration
{
    /// <summary>
    /// SEO 信息实体类
    /// </summary>
    public class SEOInfo
    {
        private string title;
        private string description;
        private string keywords;
        private string moduleName;

        private bool isRobots;
        private bool isMatch;

        /// <summary>
        /// 标题(title)
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// 描述(description)
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// 关键字(keywords)
        /// </summary>
        public string Keywords
        {
            get { return keywords; }
            set { keywords = value; }
        }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName
        {
            get { return moduleName; }
            set { moduleName = value; }
        }

        /// <summary>
        /// 是否也许蜘蛛抓取(仅对各模块首页有效)
        /// </summary>
        public bool IsRobots
        {
            get { return isRobots; }
            set { isRobots = value; }
        }

        /// <summary>
        /// 是否匹配分类关键字(仅对各模块列表页和信息详细页面有效)
        /// </summary>
        public bool IsMatch
        {
            get { return isMatch; }
            set { isMatch = value; }
        }

        public override string ToString()
        {
            return this.title;
        }

    }
}
