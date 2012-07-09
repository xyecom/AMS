using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /*----------------------------------------------------------------
    * Copyright (C) 2008 纵横易商软件有限公司
    * 版权所有。 
    *
    * 文件名：XYECOM.Model.XYClassInfo.cs
    * 文件功能描述：系统分类信息实体类
    *
    * 创建标识：tc  20080429
    *
    * 修改标识：tc 20080711
    * 修改描述：添加ParertId信息
    ----------------------------------------------------------------*/

    /// <summary>
    /// 分类信息通用类实体类
    /// </summary>
    public class XYClassInfo
    {
        private long classId;
        private string className;
        private long parentId;
        private long infoNum;
        private bool hasSub = false;
        public List<XYClassInfo> childList = new List<XYClassInfo>();

        public bool HasSub
        {
            get { return hasSub; }
            set { hasSub = value; }
        }

        public long InfoNum
        {
            get { return infoNum; }
            set { infoNum = value; }
        }

        public long ClassId
        {
            get { return classId; }
            set { classId = value; }
        }

        public long ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }

        public string ClassName
        {
            get { return this.className; }
            set { this.className = value; }
        }
    }
}
