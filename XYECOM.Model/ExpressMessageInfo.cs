using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 快速留言信息实体类
    /// </summary>
    public class ExpressMessageInfo
    {
        private int _id;
        private string moduleName;
        private string body;

        /// <summary>
        /// 信息ID
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
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
        /// 留言内容
        /// </summary>
        public string Body
        {
            get { return body; }
            set { body = value; }
        }
    }
}
