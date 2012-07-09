using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Configuration
{
    /// <summary>
    /// 模块下信息类型实体类
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
        /// 前缀
        /// </summary>
        public string Prefix
        {
            get { return prefix; }
            set { prefix = value; }
        }
        private string postfix;

        /// <summary>
        /// 后缀
        /// </summary>
        public string Postfix
        {
            get { return postfix; }
            set { postfix = value; }
        }
        private InfoType infoType;

        /// <summary>
        /// 信息类型
        /// </summary>
        public InfoType InfoType
        {
            get { return infoType; }
            set { infoType = value; }
        }
        
        /// <summary>
        /// 信息类型字符串表示形式
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
