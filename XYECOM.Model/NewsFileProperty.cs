using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    public class NewsFileProperty
    {
        private string onlyToday = "0";

        public string OnlyToday
        {
            get { return onlyToday; }
            set { onlyToday = value; }
        }

        private string newsTypeId = "0";

        public string NewsTypeId
        {
            get { return newsTypeId; }
            set { newsTypeId = value; }
        }

        private int count = 100;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        private string webMaster;

        public string WebMaster
        {
            get { return webMaster; }
            set { webMaster = value; }
        }
        private string updatePeri;

        public string UpdatePeri
        {
            get { return updatePeri; }
            set { updatePeri = value; }
        }
        private string domainName;

        public string DomainName
        {
            get { return domainName; }
            set { domainName = value; }
        }

        private string virtualPath;

        public string VirtualPath
        {
            get { return virtualPath; }
            set { virtualPath = value; }
        }
    }
}