using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.Caching;
using XYECOM.Cache;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 数据缓存抽象基类
    /// </summary>
    public abstract class DataCache
    {
        /// <summary>
        /// 缓存数据对象的Id或其他标识的集合
        /// </summary>
        protected static CacheKeys cacheKeys = new CacheKeys();

        /// <summary>
        /// 构造函数
        /// </summary>
        public DataCache()
        {
            InitCache();
        }

        /// <summary>
        /// 返回所有数据的Sql语句
        /// </summary>
        public abstract string SQL_Get_All
        {
            get;
        }

        /// <summary>
        /// 数据的初始化填充
        /// 一般在系统运行之处运行一次
        /// </summary>
        public virtual DataTable InitCache()
        {
            if (SQL_Get_All.Trim().Equals("")) return new DataTable();

            string md5Key = GetFullKey(SQL_Get_All);

            if (cacheKeys.Contains(md5Key))
            {                
                cacheKeys.Remove(md5Key);
            }

            DataTable table = XYECOM.Core.Data.SqlHelper.ExecuteTable(SQL_Get_All);

            if (table != null)
            {
                InsertCache(SQL_Get_All, table,9999);
            }

            return table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected virtual void InsertCache(string key, object value)
        {
            //将字符串MD5加密后做为Key
            string md5Key = GetFullKey(key);

            if (cacheKeys.ContainsAndRemove(md5Key))
            {
                XYCache.Instance.Remove(md5Key);
            }

            cacheKeys.Add(md5Key);
            XYCache.Instance.Insert(md5Key, value);
        }

        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="minutes">缓存过期时间（以分为单位）</param>
        protected virtual void InsertCache(string key, object value,int minutes)
        {
            //将字符串MD5加密后做为Key
            string md5Key = GetFullKey(key);

            if (cacheKeys.ContainsAndRemove(md5Key))
            {
                XYCache.Instance.Remove(md5Key);
            }

            cacheKeys.Add(md5Key,minutes);

            CacheItemRemovedCallback onRemove = new CacheItemRemovedCallback(OnCacheRemove);

            XYCache.Instance.Insert(md5Key, value,minutes,onRemove);
        }

        /// <summary>
        /// 删除缓存时的回调事件
        /// 删除缓存内容的同时删除key的记录
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="reason"></param>
        private void OnCacheRemove(string key, object obj, CacheItemRemovedReason reason)
        {
            cacheKeys.Remove(key);
        }

        /// <summary>
        /// 返回指定键的缓存对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected virtual Object GetCache(string key)
        {
            string md5Key = GetFullKey(key);

            if (cacheKeys.ContainsAndAddTimes(md5Key))
            {
                if (XYCache.Instance.Get(md5Key) != null)
                    return XYCache.Instance.Get(md5Key);

                cacheKeys.Remove(key);
            }

            return null;
        }

        /// <summary>
        /// 返回所有数据的缓存
        /// 即以 SQL_Get_All 为key并执行的结果缓存
        /// </summary>
        /// <returns></returns>
        protected virtual Object GetCache()
        {
            string md5Key = GetFullKey(SQL_Get_All);

            if (cacheKeys.ContainsAndAddTimes(md5Key))
            {
                if (XYCache.Instance.Get(md5Key) != null)
                    return XYCache.Instance.Get(md5Key);

                cacheKeys.Remove(md5Key);
            }

            return InitCache();
        }

        /// <summary>
        /// 获取完整 key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string GetFullKey(string key)
        {
            return Core.SecurityUtil.MD5("_data_" + key,"32");  
        }


        /// <summary>
        /// 整体数据的更新
        /// 主要在数据发生变动是操作
        /// </summary>
        /// <returns></returns>
        protected virtual void UpdateCache()
        {
            RemoveCache();

            InitCache();
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">key</param>
        protected virtual void RemoveCache(string key)
        {
            key = GetFullKey(key);

            if (cacheKeys.ContainsAndRemove(key))
            {
                XYCache.Instance.Remove(key);
            }
        }

        /// <summary>
        /// 根据指定的Key更行部分数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual void UpdateCache(string key, object value)
        {
            key = GetFullKey(key);

            if (cacheKeys.ContainsAndRemove(key))
            {
                XYCache.Instance.Remove(key);
            }

            cacheKeys.Add(key);
            XYCache.Instance.Insert(key, value);
        }

        /// <summary>
        /// 移除所有缓存数据
        /// </summary>
        public virtual void RemoveCache()
        {
            for (int i = 0; i < cacheKeys.Keys.Count;i++ )
            {
                CacheKeyInfo key = (CacheKeyInfo)cacheKeys.Keys[i];

                if (key != null) XYCache.Instance.Remove(key.Key);
            }

            cacheKeys.Clear();
        }
    }
}
