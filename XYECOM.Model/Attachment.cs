using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ���������࣬�и�������Ϣ�̳д���
    /// </summary>
    public abstract class Attachment
    {
        private List<Model.AttachmentInfo> attachInfo = new List<AttachmentInfo>();
        /// <summary>
        /// ������Ϣ
        /// </summary>
        public List<Model.AttachmentInfo> AttachInfo
        {
            get { return attachInfo; }
            set { attachInfo = value; }
        }

    }
}
