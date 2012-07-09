using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Template
{
    /// <summary>
    /// 网店模板访问权限方式枚举
    /// </summary>
    public enum ShopTemplateAccess
    {
        /// <summary>
        /// 公用模板
        /// </summary>
        Public,
        /// <summary>
        /// 私有模板
        /// </summary>
        Private
    }

    /// <summary>
    /// 网店模板相关信息实体类
    /// </summary>
    public class ShopAboutInfo:ShopTemplateInfo
    {
        private string _name;
        private string _cname;
        private string _author;
        private string _createdate;
        private string _ver;
        private string _copyright;
        private string _image;

        public ShopAboutInfo(string name, string cname,string access,string user, string author, string createdate, string ver, string copyright,string image)
        {
            _name = name;
            _cname = cname;
            _author = author;
            _createdate = createdate;
            _ver = ver;
            _copyright = copyright;
            _image = image;

            base.AccessStr = access;
            base.User = user;
        }

        /// <summary>
        /// 模板名称
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// 模板中文名称
        /// </summary>
        public string CName
        {
            get { return _cname; }
        }

        /// <summary>
        /// 模板作者
        /// </summary>
        public string Author
        {
            get { return _author; }
        }

        /// <summary>
        /// 模板创建时间
        /// </summary>
        public string CreateDate
        {
            get { return _createdate; }
        }

        /// <summary>
        /// 模板支持版本
        /// </summary>
        public string Ver
        {
            get { return _ver; }
        }

        /// <summary>
        /// 模板版权
        /// </summary>
        public string Copyright
        {
            get { return _copyright; }
        }

        /// <summary>
        /// 形象图片
        /// </summary>
        public string Image
        {
            set { _image = value; }
            get { return _image; }
        }
    }
}
