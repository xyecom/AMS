using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ծȨ��Ϣ״̬
    /// </summary>
    public enum CreditState
    {
        /// <summary>
        /// �ݸ�
        /// </summary>
        Draft,

        /// <summary>
        /// δ���
        /// </summary>
        Null,

        /// <summary>
        /// ���δͨ��
        /// </summary>
        NoPass,

        /// <summary>
        /// Ͷ����
        /// </summary>
        Tender,

        /// <summary>
        /// ����������
        /// </summary>
        InProgress,

        /// <summary>
        /// �����̰�����ɵȴ�ծȨ��ȷ��
        /// </summary>
        CreditConfirm,

        /// <summary>
        ///��������
        /// </summary>
        CreditEnd,

        /// <summary>
        /// ծȨ��ȡ������
        /// </summary>
        Canceled
    }
}
