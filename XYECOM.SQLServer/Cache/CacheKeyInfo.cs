using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 缓存Key信息实体类
    /// </summary>
    public class CacheKeyInfo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public CacheKeyInfo(string key)
        {
            this.key = key;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <param name="minutes"></param>
        public CacheKeyInfo(string key,int minutes)
        {
            this.key = key;
            this.minutes = minutes;
        }

        private string key;
        /// <summary>
        /// key
        /// </summary>
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private int readTimes = 1;
        /// <summary>
        /// 读取次数
        /// </summary>
        public int ReadTimes
        {
            get { return readTimes; }
            set { readTimes = value; }
        }

        private int minutes = 0;
        /// <summary>
        /// 过期时间，分为单位
        /// </summary>
        public int Minutes
        {
            get { return minutes; }
            set { minutes = value; }
        }
    }
}
