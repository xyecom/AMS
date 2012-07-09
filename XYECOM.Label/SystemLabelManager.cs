using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /**************************************************
     * XYECOM.Label.SystemLabelManager.cs
     * ������ʶ��TC 20080618
     * 
     * ����������ϵͳ��ǩ������
     * 
     *************************************************/

    /// <summary>
    /// ϵͳ��ǩ������
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
        /// ��ȡģ��Ӣ������
        /// </summary>
        /// <param name="name">ģ����������Ӣ����</param>
        /// <returns>ģ��Ӣ����</returns>
        protected virtual string GetModuleEName(string name)
        {
            name = name.ToLower().Trim();

            if (name.Equals("")) return "";

            XYECOM.Configuration.ModuleInfo info = module.GetItem(name);

            if (info != null) return info.EName;

            if (name.Equals("exhibition") || name.Equals("չ��")) return "exhibition";

            if (name.Equals("job") || name.Equals("ְλ")) return "job";

            if (name.Equals("news") || name.Equals("��Ѷ")) return "news";

            if (name.Equals("brand") || name.Equals("Ʒ��")) return "brand";

            if (name.Equals("company") || name.Equals("��ҵ")) return "company";

            return "";
        }

        /// <summary>
        /// ������Ϣ��������
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected XYECOM.Configuration.InfoType GetInfoType(string type)
        {
            type = type.Trim().ToLower();

            if (type.Equals("buy") || type.Equals("��") || type.Equals("��"))
                return XYECOM.Configuration.InfoType.Buy;

            return XYECOM.Configuration.InfoType.Sell;
        }
    }
}
