using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// �ؼ���������ǩ�ӿ�
    /// </summary>
    public interface IKeyRank
    {
        /// <summary>
        /// �����ؼ���ID
        /// </summary>
        long RankKeyId { get;set;}

        /// <summary>
        /// ��ǰģ������
        /// </summary>
        string ModuleName { get;set;}
    }
}
