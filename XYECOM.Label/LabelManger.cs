using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /**************************************************
     * XYECOM.Label.LabelManager.cs
     * ������ʶ��TC 20080618
     * 
     * ������������ǩ�����������
     * 
     ************************************.*************/

    /// <summary>
    /// ��ǩ����������󳬼���
    /// </summary>
    public abstract class LabelManger
    {
        protected XYECOM.Configuration.WebInfo config = XYECOM.Configuration.WebInfo.Instance;

        protected XYECOM.Configuration.Module module = XYECOM.Configuration.Module.Instance;

        /// <summary>
        /// �ⲿ�������ݶ���
        /// </summary>
        public OuterParameterInfo OuterParameter = new OuterParameterInfo();

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="message">������Ϣ</param>
        /// <param name="ex">�쳣����</param>
        protected void WriteLog(string message, Exception ex)
        { 
        
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="message">������Ϣ</param>
        /// <param name="ex">�쳣����</param>
        protected void WriteLog(string message)
        {

        }

        /// <summary>
        /// ��ȡ��ǩ����
        /// </summary>
        /// <param name="lableName">��ǩ����</param>
        /// <returns></returns>
        public static LabelType GetLabelType(string lableName)
        {
            //����Ƿ����ǩ����ֱ�Ӷ�ȡ
            if (lableName.StartsWith("xy_cls_") 
                || lableName.StartsWith("xy_asn_")
                || lableName.StartsWith("xy_tsn_"))
            {
                return LabelType.ClassLabel;
            }

            if (lableName.StartsWith("xy_poll_"))
            {
                return LabelType.PollLabel;
            }

            if (lableName.StartsWith("xy_part_"))
            {
                return LabelType.PartLabel;
            }

            if (lableName.StartsWith("sys:"))
            {
                return LabelType.SystemLabel;
            }

            return LabelType.ContentLabel;
        }

        /// <summary>
        /// ���ݱ�ǩ��������HTML����(����ʵ��)
        /// </summary>
        /// <param name="labelName">��ǩ����</param>
        /// <returns></returns>
        public abstract string CreateHTML();
    }
}
