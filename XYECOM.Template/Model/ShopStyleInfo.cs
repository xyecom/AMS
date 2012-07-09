using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Template
{
    /// <summary>
    /// 网店系列风格模板信息
    /// </summary>
    public class ShopStyleInfo:ShopTemplateInfo
    {
        private string name = "";
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string dirName = "";

        /// <summary>
        /// 目录名称
        /// </summary>
        public string DirName
        {
            get { return dirName; }
            set { dirName = value; }
        }
    }
}
