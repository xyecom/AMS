using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Page.Upload
{
    /// <summary>
    ///ö��
    /// </summary>
    public enum CreateThumbnailState
    {
        /// <summary>
        /// �ߴ���ִ���
        /// </summary>
        DimensionError,
        /// <summary>
        /// ͼ��̫С��copyԭ�ļ���ȥ
        /// </summary>
        DimensionSmall,
        /// <summary>
        /// ���ɳɹ�
        /// </summary>
        Succeed,
        /// <summary>
        /// �ļ�������
        /// </summary>
        NotFound
    }
}
