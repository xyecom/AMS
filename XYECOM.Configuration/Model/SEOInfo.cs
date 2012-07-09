using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Configuration
{
    /// <summary>
    /// SEO ��Ϣʵ����
    /// </summary>
    public class SEOInfo
    {
        private string title;
        private string description;
        private string keywords;
        private string moduleName;

        private bool isRobots;
        private bool isMatch;

        /// <summary>
        /// ����(title)
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// ����(description)
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// �ؼ���(keywords)
        /// </summary>
        public string Keywords
        {
            get { return keywords; }
            set { keywords = value; }
        }

        /// <summary>
        /// ģ������
        /// </summary>
        public string ModuleName
        {
            get { return moduleName; }
            set { moduleName = value; }
        }

        /// <summary>
        /// �Ƿ�Ҳ��֩��ץȡ(���Ը�ģ����ҳ��Ч)
        /// </summary>
        public bool IsRobots
        {
            get { return isRobots; }
            set { isRobots = value; }
        }

        /// <summary>
        /// �Ƿ�ƥ�����ؼ���(���Ը�ģ���б�ҳ����Ϣ��ϸҳ����Ч)
        /// </summary>
        public bool IsMatch
        {
            get { return isMatch; }
            set { isMatch = value; }
        }

        public override string ToString()
        {
            return this.title;
        }

    }
}
