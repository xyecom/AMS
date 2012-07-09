using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// ��ǩ������Ϣʵ����
    /// </summary>
    public class LabelParameterInfo
    {
        private string labelFlagName = string.Empty;
        private System.Collections.Hashtable paramList = System.Collections.Hashtable.Synchronized(new System.Collections.Hashtable());

        /// <summary>
        /// ��ǩ��ʶ����
        /// </summary>
        public string LabelFlagName
        {
            get
            {
                //����ĸת���ɴ�д
                if (labelFlagName != "")
                    labelFlagName = labelFlagName.Substring(0, 1).ToUpper() + labelFlagName.Substring(1);

                return labelFlagName; 
            }
            set { labelFlagName = value; }
        }

        /// <summary>
        /// ��ǩ��������
        /// </summary>
        public System.Collections.Hashtable ParamList
        {
            get { return paramList; }
            set { paramList = value; }
        }

        /// <summary>
        /// ��ȡ�ض�����Ԫ�ص�ֵ
        /// </summary>
        /// <param name="elementName">Ԫ�����ƣ��磺��Ϣ���</param>
        /// <returns></returns>
        public string GetValue(string elementName)
        { 
            if(paramList.Contains(elementName))
                return paramList[elementName].ToString();

            return "";
        }
    }
}
