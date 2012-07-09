using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// ��ǩ���洦����
    /// </summary>
    public class LabelCache
    {
        private const string CACHE_PREFIX = "xy_lable_";

        /// <summary>
        /// ���뻺��
        /// </summary>
        /// <param name="labelName">��ǩ����</param>
        /// <param name="labelHTML">������Ľ��</param>
        /// <param name="type">��ǩ����</param>
        public static void InsertCache(string labelName,string labelHTML,LabelCacheType type)
        {
            if (XYECOM.Configuration.Cache.Instance.TimeSpan <= 0) return;

            string key = GetKeyFlag(type) + labelName;

            XYECOM.Cache.XYCache.Instance.Insert(key, labelHTML, XYECOM.Configuration.Cache.Instance.TimeSpan);
        }

        /// <summary>
        /// ��ȡ��ǩ����
        /// </summary>
        /// <param name="labelName">��ǩ����</param>
        /// <param name="type">��ǩ����</param>
        /// <returns></returns>
        public static string GetCache(string labelName, LabelCacheType type)
        {
            if (XYECOM.Configuration.Cache.Instance.TimeSpan <= 0) return null;

            string key = GetKeyFlag(type) + labelName;

            Object obj = XYECOM.Cache.XYCache.Instance.Get(key);
            
            if (obj == null) return null;

            return obj.ToString();
        }

        /// <summary>
        /// ɾ��ָ�����͵ı�ǩ����
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static void Remove(LabelCacheType type)
        {
            System.Collections.ArrayList keys = XYECOM.Cache.XYCache.Instance.GetKeys();

            for (int i = 0; i < keys.Count; i++)
            { 
                string key = keys[i].ToString();

                if (key.StartsWith(GetKeyFlag(type)))
                {
                    XYECOM.Cache.XYCache.Instance.Remove(key);
                }
            }
        }

        /// <summary>
        /// ���ȫ����ǩ����
        /// </summary>
        public static void Clear()
        {
            System.Collections.ArrayList keys = XYECOM.Cache.XYCache.Instance.GetKeys();

            for (int i = 0; i < keys.Count; i++)
            {
                string key = keys[i].ToString();

                if (key.StartsWith(CACHE_PREFIX))
                {
                    XYECOM.Cache.XYCache.Instance.Remove(key);
                }
            }
        }

        /// <summary>
        /// ͨ����ǩ���ͻ�ȡ��ʶǰ׺����
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string GetKeyFlag(LabelCacheType type)
        {
            string temp = "";
            if (type == LabelCacheType.ContentLabel)
                temp =  "content_";

            if (type == LabelCacheType.ClassLabel)
                temp = "class_";

            if (type == LabelCacheType.SystemLabel)
                temp = "system_";

            if (type == LabelCacheType.ClassInfoStat)
                temp = "classinfo_";

            if (type == LabelCacheType.PollLabel)
                temp = "poll_";


            return CACHE_PREFIX + temp;
        }
    }
}
