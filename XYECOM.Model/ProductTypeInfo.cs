using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 产品分类实体类
    /// </summary>
    public class ProductTypeInfo
    {
        private System.Int64 _PT_ID;
        private string _PT_Name;
        private System.Int64 _PT_ParentID;
        private string _ModuleName;
        private string _FullId;
        private int _InfoCount;
        private int _TradeId;
        private string flagName;
        private bool isCustomTemplate;


        /// <summary>
        /// 是否自定义模版
        /// </summary>
        public bool IsCustomTemplate
        {
            get { return isCustomTemplate; }
            set { isCustomTemplate = value; }
        }


        /// <summary>
        /// 标识名称
        /// </summary>
        public string FlagName
        {
            get { return flagName; }
            set { flagName = value; }
        }
       

        public System.Int64 PT_ID
        {
            get { return _PT_ID; }
            set { _PT_ID = value; }
        }
        public string PT_Name
        {
            get { return _PT_Name; }
            set { _PT_Name = value; }
        }
        public System.Int64 PT_ParentID
        {
            get { return _PT_ParentID; }
            set { _PT_ParentID = value; }
        }

        public string ModuleName
        {
            set { _ModuleName = value; }
            get { return _ModuleName; }
        }

        /// <summary>
        /// 完整上级Id列表
        /// </summary>
        public string FullId
        {
            get { return _FullId; }
            set { _FullId = value; }
        }

        /// <summary>
        /// 分类下信息条数
        /// </summary>
        public int InfoCount
        {
            get { return _InfoCount; }
            set { _InfoCount = value; }
        }

        /// <summary>
        /// 相关行业id
        /// </summary>
        public int TradeId
        {
            get { return _TradeId; }
            set { _TradeId = value; }
        }
        public bool IsLeaf
        {
            get;
            set;
        }
        public int ChildCount
        {
            get;
            set;
        }
    }

}
