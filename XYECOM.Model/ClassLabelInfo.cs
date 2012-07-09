using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// �����ǩʵ����
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
        /// ��ʶ����
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string CNName
        {
            get { return _CNName; }
            set { _CNName = value; }
        }

        /// <summary>
        /// ��ǩ��
        /// </summary>
        public string Body
        {
            get { return body; }
            set { body = value; }
        }

        /// <summary>
        /// ����������������������Ϣ�ķ��ࣩ
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
