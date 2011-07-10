using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace XYECOM.Cache
{
    /// <summary>
    /// 默认缓存策略
    /// </summary>
    public class DefaultCacheStrategy:ICacheStrategy
    {
        private readonly System.Web.Caching.Cache _cache;

        /// <summary>
        /// 构造方法
        /// </summary>
        public DefaultCacheStrategy()
        {
            HttpContext context = HttpContext.Current;
            if (context != null)
            {
                _cache = context.Cache;
            }
            else
            {
                _cache = HttpRuntime.Cache;
            }
        }



        #region ICacheStrategy 成员
 
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public System.Collections.ArrayList GetKeys()
        {
            IDictionaryEnumerator cacheEnum = _cache.GetEnumerator();
            ArrayList list = new ArrayList();
            while (cacheEnum.MoveNext())
            {
                list.Add(cacheEnum.Key);
            }

            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Remove()
        {
            ArrayList keys = GetKeys();

            for (int i = 0; i < keys.Count; i++)
            {
                string key = keys[i].ToString();

                if (!String.IsNullOrEmpty(key)) _cache.Remove(key);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            if(key != null && key !=""){
                _cache.Remove(key);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="minutes"></param>
        /// <param name="cacheDependency"></param>
        /// <param name="removeCallback"></param>
        public void Insert(string key, object obj, int minutes, CacheDependency cacheDependency, CacheItemRemovedCallback removeCallback)
        {
            if (String.IsNullOrEmpty(key) || key.Equals("")) return;

            if (null == obj) return;

            if (minutes >0)
                _cache.Insert(key, obj, cacheDependency, DateTime.Now.AddSeconds(minutes * 60), TimeSpan.Zero, CacheItemPriority.High, removeCallback);
            else
                _cache.Insert(key, obj, cacheDependency, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.High, removeCallback);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="minutes"></param>
        /// <param name="removeCallback"></param>
        public void Insert(string key, object obj, int minutes, CacheItemRemovedCallback removeCallback)
        {
            Insert(key, obj, minutes, null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="minutes"></param>
        /// <param name="cacheDependency"></param>
        public void Insert(string key, object obj, int minutes, CacheDependency cacheDependency)
        {
            Insert(key, obj, minutes, cacheDependency, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="minutes"></param>
        public void Insert(string key, object obj, int minutes)
        {
            Insert(key, obj, minutes, null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        public void Insert(string key, object obj)
        {
            Insert(key, obj, 9999, null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            if (_cache[key] == null) return null;
            return _cache[key];
        }

        #endregion
    }
}
