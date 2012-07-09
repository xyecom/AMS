using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ����������Ϣʵ����
    /// </summary>
    public class ExpressMessageInfo
    {
        private int _id;
        private string moduleName;
        private string body;

        /// <summary>
        /// ��ϢID
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
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
        /// ��������
        /// </summary>
        public string Body
        {
            get { return body; }
            set { body = value; }
        }
    }
}
