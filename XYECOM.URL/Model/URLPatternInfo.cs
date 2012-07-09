using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.URL
{
    /// <summary>
    /// ��дα��ַ��Ϣʵ����
    /// </summary>
    public class URLPatternInfo
    {
        private string name;
        private string pattern;
        private string page;
        private string queryString;
        private string path;
        private string group;

        public URLPatternInfo() { }

        public URLPatternInfo(string name, string pattern, string page, string querystring,string group)
        {
            this.name = name;
            this.pattern = pattern;
            this.page = page;
            this.queryString = querystring;
            this.group = group;
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// ƥ�����
        /// </summary>
        public string Pattern
        {
            get { return pattern; }
            set { pattern = value; }
        }

        /// <summary>
        /// ҳ��
        /// </summary>
        public string Page
        {
            get { return page; }
            set { page = value; }
        }

        /// <summary>
        /// �������
        /// </summary>
        public string QueryString
        {
            get { return queryString; }
            set { queryString = value; }
        }

        /// <summary>
        /// ·��
        /// </summary>
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public string Group
        {
            get { return group; }
            set { group = value; }
        }
    }
}
