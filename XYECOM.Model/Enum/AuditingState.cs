using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ���״̬ö��
    /// </summary>
    public enum AuditingState
    {
        /// <summary>
        /// Ϊ���
        /// </summary>
        Null = -1,
        /// <summary>
        /// ���δͨ��
        /// </summary>
        NoPass = 0,
        /// <summary>
        /// ��ͨ��
        /// </summary>
        Passed = 1,
        /// <summary>
        /// �༭δ���
        /// </summary>
        EditNoPass = 2
    }
}
