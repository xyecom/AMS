using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 地区实体类
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
        /// 类别ID的路径 不包括自身
        /// </summary>
        public string FullID
        {
            get { return fullID; }
            set { fullID = value; }
        }
        /// <summary>
        /// 类别的路径 从顶级开始 不包括自身
        /// </summary>
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        /// <summary>
        /// 类别的全路径 包括自身
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
