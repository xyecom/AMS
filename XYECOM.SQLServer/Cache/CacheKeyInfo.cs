using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// ����Key��Ϣʵ����
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
        /// ��ȡ����
        /// </summary>
        public int ReadTimes
        {
            get { return readTimes; }
            set { readTimes = value; }
        }

        private int minutes = 0;
        /// <summary>
        /// ����ʱ�䣬��Ϊ��λ
        /// </summary>
        public int Minutes
        {
            get { return minutes; }
            set { minutes = value; }
        }
    }
}
