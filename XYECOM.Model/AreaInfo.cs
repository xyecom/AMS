using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ����ʵ����
    /// </summary>
    public class AreaInfo
    {
        private int Id;
        private string name;
        private int parentID;
        private string fullID ="";
        private string fullName ="";
        private string fullNameAll="";
        private bool hasSubArea;
        private List<AreaInfo> subAreas = new List<AreaInfo>();

        /// <summary>
        /// ���ID��·�� ����������
        /// </summary>
        public string FullID
        {
            get { return fullID; }
            set { fullID = value; }
        }
        /// <summary>
        /// ����·�� �Ӷ�����ʼ ����������
        /// </summary>
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        /// <summary>
        /// ����ȫ·�� ��������
        /// </summary>
        public string FullNameAll
        {
            get { return fullNameAll; }
            set { fullNameAll = value; }
        }

        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }

        public bool HasSubArea
        {
            get { return hasSubArea; }
            set { hasSubArea = value; }
        }

        public List<AreaInfo> SubAreas
        {
            get { return subAreas; }
            set { subAreas = value; }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
