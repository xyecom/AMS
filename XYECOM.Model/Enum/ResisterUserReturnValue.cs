using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ע���û�����ֵ����ö��
    /// </summary>
    public enum ResisterUserReturnValue
    {
        /// <summary>
        /// ע��ʧ��
        /// </summary>
        Failed,
        /// <summary>
        /// ע��ʧ�ܣ��л����Ѿ���ռ��
        /// </summary>
        UserNameExists,
        /// <summary>
        /// ע��ʧ�ܣ������Ѿ���ռ��
        /// </summary>
        EmailExists,
        /// <summary>
        /// ע��ʧ�ܣ�ʹ���˽�ֹע����û���
        /// </summary>
        ForbidName,
        /// <summary>
        /// ע��ɹ�
        /// </summary>
        Success,
        /// <summary>
        /// ע��ɹ������ʼ�����ʧ��
        /// </summary>
        SendEmailFailed,
        /// <summary>
        /// ��ֹע��
        /// </summary>
        ForbidRegister
    }
}
