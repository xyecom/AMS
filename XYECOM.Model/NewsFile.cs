using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace XYECOM.Model
{
    public class NewsFile
    {
        private FileInfo fileinfo;

        private NewsFile() { }

        public NewsFile(string ph, string v, string pp)
            : this()
        {
            this.virtualPath = v;
            this.physicalPath = ph;
            this.propertiesPath = pp;

            if (!string.IsNullOrEmpty(physicalPath) && File.Exists(physicalPath))
            {
                fileinfo = new FileInfo(physicalPath);
            }
        }

        private string virtualPath;

        public string VirtualPath
        {
            get { return virtualPath; }
            set { virtualPath = value; }
        }

        private string propertiesPath;

        public string PropertiesPath
        {
            get { return propertiesPath; }
            set { propertiesPath = value; }
        }

        private string physicalPath;

        public string PhysicalPath
        {
            get { return physicalPath; }
            set
            {
                physicalPath = value;
            }
        }

        public string Name
        {
            get
            {
                if (fileinfo != null)
                {
                    return fileinfo.Name;
                }

                return "文件已被删除或" + physicalPath + "不存在该文件";
            }
        }

        public string LastWriteTime
        {
            get
            {
                if (fileinfo != null)
                {
                    return fileinfo.LastWriteTime.ToString("yyyy-MM-dd hh:mm:ss");
                }
                return "文件已被删除或" + physicalPath + "不存在该文件";
            }
        }
    }
}
