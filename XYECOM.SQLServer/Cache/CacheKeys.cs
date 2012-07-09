using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 缓存Key
    /// </summary>
    public class CacheKeys
    {
        private ArrayList keys = new ArrayList();

        private static object lockHelper = new object();

        /// <summary>
        /// 键集合
        /// </summary>
        public ArrayList Keys
        {
            get { return keys; }
            set { keys = value; }
        }

        /// <summary>
        /// 新增一个key
        /// </summary>
        /// <param name="key"></param>
        public void Add(string key)
        {
            lock (lockHelper)
            {
                keys.Add(new CacheKeyInfo(key));
            }
        }

        /// <summary>
        /// 新增一个key
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="minutes">缓存时间</param>
        public void Add(string key, int minutes)
        {
            lock (lockHelper)
            {
                keys.Add(new CacheKeyInfo(key, minutes));
            }
        }

        /// <summary>
        /// 仅判断是否有指定的key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(string key)
        {
            //string md5Key = GetFullKey(key);
            if (String.IsNullOrEmpty(key)) return false;

            for (int i = 0; i < keys.Count; i++)
            {
                CacheKeyInfo keyInfo = (CacheKeyInfo)keys[i];

                if (keyInfo.Key.Equals(key)) return true;
            }

            return false;
        }

        /// <summary>
        /// 判断指定的Key是否存在，如果存在则使读取次数累加
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsAndAddTimes(string key)
        {
            if (String.IsNullOrEmpty(key)) return false;

            for (int i = 0; i < keys.Count; i++)
            {
                CacheKeyInfo keyInfo = (CacheKeyInfo)keys[i];

                if (keyInfo.Key.Equals(key))
                {
                    keyInfo.ReadTimes++;
                    return true; 
                }
            }

            return false;
        }

        /// <summary>
        /// 判断是否存在，如果存在，顺便删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsAndRemove(string key)
        {
            if (String.IsNullOrEmpty(key)) return false;

            for (int i = 0; i < keys.Count; i++)
            {
                CacheKeyInfo keyInfo = (CacheKeyInfo)keys[i];

                if (keyInfo.Key.Equals(key))
                {
                    lock (lockHelper)
                    {
                        keys.Remove(keyInfo);
                    }
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 删除一个Key
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            if (String.IsNullOrEmpty(key)) return;

            for (int i = 0; i < keys.Count; i++)
            {
                CacheKeyInfo keyInfo = (CacheKeyInfo)keys[i];

                if (keyInfo.Key.Equals(key))
                {
                    lock (lockHelper)
                    {
                        keys.Remove(keyInfo);
                    }
                    return;
                }
            }
        }

        /// <summary>
        /// 移除全部
        /// </summary>
        public void Clear()
        {
            keys.Clear();
        }

        private string GetFullKey(string key)
        {
            return Core.SecurityUtil.MD5("_data_" + key, "32");
        }
    }
}
