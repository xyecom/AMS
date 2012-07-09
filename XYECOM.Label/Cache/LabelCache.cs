using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 标签缓存处理类
    /// </summary>
    public class LabelCache
    {
        private const string CACHE_PREFIX = "xy_lable_";

        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="labelName">标签名称</param>
        /// <param name="labelHTML">解析后的结果</param>
        /// <param name="type">标签类型</param>
        public static void InsertCache(string labelName,string labelHTML,LabelCacheType type)
        {
            if (XYECOM.Configuration.Cache.Instance.TimeSpan <= 0) return;

            string key = GetKeyFlag(type) + labelName;

            XYECOM.Cache.XYCache.Instance.Insert(key, labelHTML, XYECOM.Configuration.Cache.Instance.TimeSpan);
        }

        /// <summary>
        /// 获取标签缓存
        /// </summary>
        /// <param name="labelName">标签名称</param>
        /// <param name="type">标签类型</param>
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
        /// 删除指定类型的标签缓存
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
        /// 清除全部标签缓存
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
        /// 通过标签类型获取标识前缀名称
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
