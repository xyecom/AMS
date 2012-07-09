using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 标签参数信息实体类
    /// </summary>
    public class LabelParameterInfo
    {
        private string labelFlagName = string.Empty;
        private System.Collections.Hashtable paramList = System.Collections.Hashtable.Synchronized(new System.Collections.Hashtable());

        /// <summary>
        /// 标签标识名称
        /// </summary>
        public string LabelFlagName
        {
            get
            {
                //首字母转换成大写
                if (labelFlagName != "")
                    labelFlagName = labelFlagName.Substring(0, 1).ToUpper() + labelFlagName.Substring(1);

                return labelFlagName; 
            }
            set { labelFlagName = value; }
        }

        /// <summary>
        /// 标签参数集合
        /// </summary>
        public System.Collections.Hashtable ParamList
        {
            get { return paramList; }
            set { paramList = value; }
        }

        /// <summary>
        /// 获取特定参数元素的值
        /// </summary>
        /// <param name="elementName">元素名称，如：信息类别</param>
        /// <returns></returns>
        public string GetValue(string elementName)
        { 
            if(paramList.Contains(elementName))
                return paramList[elementName].ToString();

            return "";
        }
    }
}
