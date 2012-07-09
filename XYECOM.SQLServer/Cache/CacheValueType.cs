using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// ����ֵ����ö��
    /// </summary>
    public enum CacheValueType
    {
        /// <summary>
        /// ������
        /// </summary>
        Table,
        /// <summary>
        /// ��������
        /// </summary>
        Object,
        /// <summary>
        /// ����������
        /// </summary>
        DataRow,
        /// <summary>
        /// int ����
        /// </summary>
        Int,
        /// <summary>
        /// �ַ�������
        /// </summary>
        String,
        /// <summary>
        /// bool����
        /// </summary>
        Bool
    }
}
