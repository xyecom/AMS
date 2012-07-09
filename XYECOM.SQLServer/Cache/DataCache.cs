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
    /// ���ݻ���������
    /// </summary>
    public abstract class DataCache
    {
        /// <summary>
        /// �������ݶ����Id��������ʶ�ļ���
        /// </summary>
        protected static CacheKeys cacheKeys = new CacheKeys();

        /// <summary>
        /// ���캯��
        /// </summary>
        public DataCache()
        {
            InitCache();
        }

        /// <summary>
        /// �����������ݵ�Sql���
        /// </summary>
        public abstract string SQL_Get_All
        {
            get;
        }

        /// <summary>
        /// ���ݵĳ�ʼ�����
        /// һ����ϵͳ����֮������һ��
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
            //���ַ���MD5���ܺ���ΪKey
            string md5Key = GetFullKey(key);

            if (cacheKeys.ContainsAndRemove(md5Key))
            {
                XYCache.Instance.Remove(md5Key);
            }

            cacheKeys.Add(md5Key);
            XYCache.Instance.Insert(md5Key, value);
        }

        /// <summary>
        /// ���뻺��
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="minutes">�������ʱ�䣨�Է�Ϊ��λ��</param>
        protected virtual void InsertCache(string key, object value,int minutes)
        {
            //���ַ���MD5���ܺ���ΪKey
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
        /// ɾ������ʱ�Ļص��¼�
        /// ɾ���������ݵ�ͬʱɾ��key�ļ�¼
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="reason"></param>
        private void OnCacheRemove(string key, object obj, CacheItemRemovedReason reason)
        {
            cacheKeys.Remove(key);
        }

        /// <summary>
        /// ����ָ�����Ļ������
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
        /// �����������ݵĻ���
        /// ���� SQL_Get_All Ϊkey��ִ�еĽ������
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
        /// ��ȡ���� key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string GetFullKey(string key)
        {
            return Core.SecurityUtil.MD5("_data_" + key,"32");  
        }


        /// <summary>
        /// �������ݵĸ���
        /// ��Ҫ�����ݷ����䶯�ǲ���
        /// </summary>
        /// <returns></returns>
        protected virtual void UpdateCache()
        {
            RemoveCache();

            InitCache();
        }

        /// <summary>
        /// �Ƴ�����
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
        /// ����ָ����Key���в�������
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
        /// �Ƴ����л�������
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
