using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Web.Caching;

namespace XYECOM.Cache
{
    /// <summary>
    /// 缓存策略接口类
    /// </summary>
    public interface ICacheStrategy
    {
        /// <summary>
        /// 获取所有Key集合
        /// </summary>
        /// <returns></returns>
        ArrayList GetKeys();

        /// <summary>
        /// 清空全部缓存
        /// </summary>
        void Remove();

        /// <summary>
        /// 移除指定健的缓存项
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);

        /// <summary>
        /// 插入指定过期时间(秒为单位)的缓存项
        /// </summary>
        /// <param name="key">健</param>
        /// <param name="obj">值</param>
        /// <param name="minutes">分钟数</param>
        /// <param name="cacheDependency">缓存依赖</param>
        /// <param name="removeCallback"></param>
        void Insert(string key, object obj, int minutes, CacheDependency cacheDependency, CacheItemRemovedCallback removeCallback);

        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="obj">Value</param>
        /// <param name="minutes">时间(分钟)</param>
        /// <param name="removeCallback">缓存清空是的回调方法</param>
        void Insert(string key, object obj, int minutes, CacheItemRemovedCallback removeCallback);

        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="obj">Value</param>
        /// <param name="minutes">时间(分钟)</param>
        void Insert(string key, object obj, int minutes);

        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="obj">Value</param>
        void Insert(string key, object obj);


        /// <summary>
        /// 获取指定健的缓存项
        /// </summary>
        /// <param name="key"></param>        
        /// <returns></returns>
        object Get(string key);
    }
}
