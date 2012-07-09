using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /**************************************************
     * XYECOM.Label.SystemLabelManager.cs
     * 创建标识：TC 20080618
     * 
     * 功能描述：系统标签处理类
     * 
     *************************************************/

    /// <summary>
    /// 系统标签处理类
    /// </summary>
    public abstract class SystemLabelManager : LabelManger
    {
        private static SystemLabelManager instance = null;

        protected static string labelName = "";

        public static LabelManger GetInstance(string _labelName)
        {
            labelName = _labelName.Replace("sys:", "");

            if (labelName.ToLower().StartsWith("more"))
                return new More();

            if (labelName.ToLower().StartsWith("keyword"))
                return new Keyword();

            return (LabelManger)instance;
        }

        /// <summary>
        /// 获取模块英文名称
        /// </summary>
        /// <param name="name">模块中文名或英文名</param>
        /// <returns>模块英文名</returns>
        protected virtual string GetModuleEName(string name)
        {
            name = name.ToLower().Trim();

            if (name.Equals("")) return "";

            XYECOM.Configuration.ModuleInfo info = module.GetItem(name);

            if (info != null) return info.EName;

            if (name.Equals("exhibition") || name.Equals("展会")) return "exhibition";

            if (name.Equals("job") || name.Equals("职位")) return "job";

            if (name.Equals("news") || name.Equals("资讯")) return "news";

            if (name.Equals("brand") || name.Equals("品牌")) return "brand";

            if (name.Equals("company") || name.Equals("企业")) return "company";

            return "";
        }

        /// <summary>
        /// 返回信息供求类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected XYECOM.Configuration.InfoType GetInfoType(string type)
        {
            type = type.Trim().ToLower();

            if (type.Equals("buy") || type.Equals("求") || type.Equals("求购"))
                return XYECOM.Configuration.InfoType.Buy;

            return XYECOM.Configuration.InfoType.Sell;
        }
    }
}
