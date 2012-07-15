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
        Draft =0,

        /// <summary>
        /// δ���
        /// </summary>
        Null =-1,

        /// <summary>
        /// ���δͨ��
        /// </summary>
        NoPass = 1,

        /// <summary>
        /// Ͷ����
        /// </summary>
        Tender =2,

        /// <summary>
        /// ����������
        /// </summary>
        InProgress = 3,

        /// <summary>
        /// �����̰�����ɵȴ�ծȨ��ȷ��
        /// </summary>
        CreditConfirm = 4,

        /// <summary>
        ///��������
        /// </summary>
        CreditEnd = 5,

        /// <summary>
        /// ծȨ��ȡ������
        /// </summary>
        Canceled= 6,

        /// <summary>
        /// ��ɾ��
        /// </summary>
        Delete = 7
    }
}
