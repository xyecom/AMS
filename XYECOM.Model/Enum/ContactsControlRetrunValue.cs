using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ��ϵ��ʽ���Ʒ���ֵö��
    /// </summary>
    public enum ContactsControlRetrunValue : short
    {
        /// <summary>
        /// ���ܲ鿴
        /// </summary>
        CanNotSee = -1,
        /// <summary>
        /// �ѵ�¼����Ȩ��̫�ͣ����ܲ鿴
        /// </summary>
        PopedomTooLow,
        /// <summary>
        /// ���Բ鿴
        /// </summary>
        CanSee,
        /// <summary>
        /// δ֪
        /// </summary>
        Null
    }
}
