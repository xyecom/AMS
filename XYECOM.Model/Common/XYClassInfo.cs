using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /*----------------------------------------------------------------
    * Copyright (C) 2008 �ݺ�����������޹�˾
    * ��Ȩ���С� 
    *
    * �ļ�����XYECOM.Model.XYClassInfo.cs
    * �ļ�����������ϵͳ������Ϣʵ����
    *
    * ������ʶ��tc  20080429
    *
    * �޸ı�ʶ��tc 20080711
    * �޸����������ParertId��Ϣ
    ----------------------------------------------------------------*/

    /// <summary>
    /// ������Ϣͨ����ʵ����
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
