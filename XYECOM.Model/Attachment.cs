using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 附件抽象类，有附件的信息继承此类
    /// </summary>
    public abstract class Attachment
    {
        private List<Model.AttachmentInfo> attachInfo = new List<AttachmentInfo>();
        /// <summary>
        /// 附件信息
        /// </summary>
        public List<Model.AttachmentInfo> AttachInfo
        {
            get { return attachInfo; }
            set { attachInfo = value; }
        }

    }
}
