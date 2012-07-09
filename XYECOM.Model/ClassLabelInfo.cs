using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 分类标签实体类
    /// </summary>
    public class ClassLabelInfo
    {
        private int Id;
        private string name;
        private string _CNName;
        private string body;
        private string tableName;

        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }

        /// <summary>
        /// 标识名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// 中文名称
        /// </summary>
        public string CNName
        {
            get { return _CNName; }
            set { _CNName = value; }
        }

        /// <summary>
        /// 标签体
        /// </summary>
        public string Body
        {
            get { return body; }
            set { body = value; }
        }

        /// <summary>
        /// 表名（可以区别是那种信息的分类）
        /// </summary>
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
