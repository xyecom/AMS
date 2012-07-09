using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    public enum LemmaCheckState
    {
        /// <summary>
        /// 审核未通过
        /// </summary>
        UnCheck,

        /// <summary>
        /// 编辑待审核
        /// </summary>
        WaitForCheck,

        /// <summary>
        /// 审核通过
        /// </summary>
        Checked,

        /// <summary>
        /// 新建待审核
        /// </summary>
        NewWaitForCheck,
    }
}
