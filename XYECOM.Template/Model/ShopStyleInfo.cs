using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Template
{
    /// <summary>
    /// ����ϵ�з��ģ����Ϣ
    /// </summary>
    public class ShopStyleInfo:ShopTemplateInfo
    {
        private string name = "";
        /// <summary>
        /// ����
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string dirName = "";

        /// <summary>
        /// Ŀ¼����
        /// </summary>
        public string DirName
        {
            get { return dirName; }
            set { dirName = value; }
        }
    }
}
