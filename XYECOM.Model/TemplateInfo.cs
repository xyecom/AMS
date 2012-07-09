using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 模板信息实体类
    /// </summary>
    public class TemplateInfo
    {
        // Fields
        private string m_copyright;
        private string m_directory;
        private string m_name;
        private int m_templateid;

        // Properties
        public string Copyright
        {
            get
            {
                return this.m_copyright;
            }
            set
            {
                this.m_copyright = value;
            }
        }

        public string Directory
        {
            get
            {
                return this.m_directory;
            }
            set
            {
                this.m_directory = value;
            }
        }

        public string Name
        {
            get
            {
                return this.m_name;
            }
            set
            {
                this.m_name = value;
            }
        }

        public int Templateid
        {
            get
            {
                return this.m_templateid;
            }
            set
            {
                this.m_templateid = value;
            }
        }
    }
 

}
