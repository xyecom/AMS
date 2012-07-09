using System;
using System.Collections.Generic;


namespace XYECOM.Model
{
    /// <summary>
    /// 资讯栏目实体类
    /// </summary>
    public class NewsTitlesInfo
    {
        private int _Id;
        private string _Name;
        private string _ShortName;
        private int _ParentId;
        private string _EnName;
        private string _TempletFolderAddress;
        private string _TempletViewAddress;
        private string _HTMLPage;
        private bool _IsShow;
        private bool _IsAllowContribut;
        private string _DomainName;

    
        public NewsTitlesInfo()
        {
            _Id = 0;
            _Name = "";
            _ShortName = "";
            _ParentId = 0;
            _EnName = "";
            _TempletFolderAddress = "";
            _TempletViewAddress = "";
            _HTMLPage = "";
            _DomainName = "";
        }

        #region 定义新闻栏目类NewsTitles属性
        /// <summary>
        /// 栏目信息编号
        /// </summary>
        public int Id
        {
            set { _Id = value; }
            get { return _Id; }
        }
        /// <summary>
        /// 栏目名称
        /// </summary>
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }
        /// <summary>
        /// 栏目简称
        /// </summary>
        public string ShortName
        {
            set { _ShortName = value; }
            get { return _ShortName; }
        }
        /// <summary>
        /// 父栏目ID  
        /// </summary>
        public int ParentId
        {
            set { _ParentId = value; }
            get { return _ParentId; }
        }
        /// <summary>
        /// 栏目英文名称
        /// </summary>
        public string EnName
        {
            set { _EnName = value; }
            get { return _EnName; }
        }
        /// <summary>
        /// 栏目文件夹地址
        /// </summary>
        public string TempletFolderAddress
        {
            set { _TempletFolderAddress = value; }
            get { return _TempletFolderAddress; }
        }

        /// <summary>
        /// 栏目访问地址
        /// </summary>
        public string TempletViewAddress
        {
            set { _TempletViewAddress = value; }
            get { return _TempletViewAddress; }
        }

        /// <summary>
        /// 生成静态页面地址
        /// </summary>
        public string HTMLPage
        {
            get { return _HTMLPage; }
            set { _HTMLPage = value; }
        }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsShow
        {
            get { return _IsShow; }
            set { _IsShow = value; }
        }

        /// <summary>
        /// 是否允许在该栏目下投稿
        /// </summary>
        public bool IsAllowContribut
        {
            get { return _IsAllowContribut; }
            set { _IsAllowContribut = value; }
        }

        public override string ToString()
        {
            return this._Name;
        }
        /// <summary>
        /// 二级域名
        /// </summary>
        public string DomainName
        {
            get { return _DomainName; }
            set { _DomainName = value; }
        }

        #endregion
    }
}
