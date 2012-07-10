using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ÉóºË×´Ì¬Ã¶¾Ù
    /// </summary>
    public enum AuditingState
    {
        /// <summary>
        /// Î´ÉóºË
        /// </summary>
        Null = -1,
        /// <summary>
        /// ÉóºËÎ´Í¨¹ý
        /// </summary>
        NoPass = 0,
        /// <summary>
        /// ÒÑÍ¨¹ý
        /// </summary>
        Passed = 1,
        /// <summary>
        /// ±à¼­Î´ÉóºË
        /// </summary>
        EditNoPass = 2
    }
}
