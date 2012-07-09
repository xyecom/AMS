using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    public class NewsSourceInfo : NewsInfo
    {
        private string domainName;

        /// <summary>
        /// 二级域名
        /// </summary>
        public string DomainName
        {
            get { return domainName; }
            set { domainName = value; }
        }

        private string templetFolderAddress;

        /// <summary>
        /// 栏目Folder模板
        /// </summary>
        public string TempletFolderAddress
        {
            get { return templetFolderAddress; }
            set { templetFolderAddress = value; }
        }

        private int isHasImage;
        /// <summary>
        /// 是否包含图片
        /// </summary>
        public int IsHasImage
        {
            get { return isHasImage; }
            set { isHasImage = value; }
        }

        private string categoryName;

        /// <summary>
        /// 新闻栏目
        /// </summary>
        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }


        public const string FilePath = "/FileList.xml";
    }
}
