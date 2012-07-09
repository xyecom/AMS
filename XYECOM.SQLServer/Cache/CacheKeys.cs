using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// ����Key
    /// </summary>
    public class CacheKeys
    {
        private ArrayList keys = new ArrayList();

        private static object lockHelper = new object();

        /// <summary>
        /// ������
        /// </summary>
        public ArrayList Keys
        {
            get { return keys; }
            set { keys = value; }
        }

        /// <summary>
        /// ����һ��key
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
        /// ����һ��key
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="minutes">����ʱ��</param>
        public void Add(string key, int minutes)
        {
            lock (lockHelper)
            {
                keys.Add(new CacheKeyInfo(key, minutes));
            }
        }

        /// <summary>
        /// ���ж��Ƿ���ָ����key
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
        /// �ж�ָ����Key�Ƿ���ڣ����������ʹ��ȡ�����ۼ�
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
        /// �ж��Ƿ���ڣ�������ڣ�˳��ɾ��
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
        /// ɾ��һ��Key
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
        /// �Ƴ�ȫ��
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
