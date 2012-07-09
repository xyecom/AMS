using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 伪静态url规则属性类
    /// </summary>
    public class HtmlSetURLInfo
    {
        private string _name;
        private string _path;
        private string _pattern;
        private string _page;
        private string _querystring;

        public HtmlSetURLInfo(string name, string path, string pattern, string page, string querystring)
        {
            _name = name;
            _path = path;
            _pattern = pattern;
            _page = page;
            _querystring = querystring;
        }


        public string Name
        {
            get { return _name; }
        }

        public string Path
        {
            get { return _path; }
        }

        public string Pattern
        {
            get { return _pattern; }
        }

        public string Page
        {
            get { return _page; }
        }

        public string QueryString
        {
            get { return _querystring; }
        }
    }
}
