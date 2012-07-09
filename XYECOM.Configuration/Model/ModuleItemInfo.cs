using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Configuration
{
    /// <summary>
    /// ģ������Ϣ����ʵ����
    /// </summary>
    public class ModuleItemInfo
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string prefix;

        /// <summary>
        /// ǰ׺
        /// </summary>
        public string Prefix
        {
            get { return prefix; }
            set { prefix = value; }
        }
        private string postfix;

        /// <summary>
        /// ��׺
        /// </summary>
        public string Postfix
        {
            get { return postfix; }
            set { postfix = value; }
        }
        private InfoType infoType;

        /// <summary>
        /// ��Ϣ����
        /// </summary>
        public InfoType InfoType
        {
            get { return infoType; }
            set { infoType = value; }
        }
        
        /// <summary>
        /// ��Ϣ�����ַ�����ʾ��ʽ
        /// </summary>
        public string InfoTypeStr
        {
            get
            {
                if (infoType == InfoType.Buy)
                    return "buy";

                return "sell";
            }
            set
            {
                if (value == "buy")
                    infoType = InfoType.Buy;
                else if (value == "sell")
                    infoType = InfoType.Sell;
            }
        }
    }
}
