using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    public enum ClassAdsState
    {
        /// <summary>
        /// ȫ��
        /// </summary>
        All,
        /// <summary>
        /// չʾ�У��Ѿ���ʼչʾ��
        /// </summary>
        OnView,
        /// <summary>
        /// ��Ч�ģ������Ѿ���ʼչʾ�ĺͻ�δ��ʼ�ģ�
        /// </summary>
        Valid,
        /// <summary>
        /// �ѹ��ڣ�չʾ������
        /// </summary>
        HasExpired,
        /// <summary>
        /// ��δ��ʼ
        /// </summary>
        NotStarted
    }
}
