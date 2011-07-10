using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using System.IO;

namespace XYECOM.Cache
{
    /*----------------------------------------------------------------
     * Copyright (C) 2008 纵横易商软件有限公司
     * 版权所有。 
     *
     * 文件名：XYECOM.Cache.XYCache.cs
     * 文件功能描述：系统缓存操作类
     *
     * 创建标识：tc 20080417
     *
     * 修改标识：
     * 修改描述：
     ----------------------------------------------------------------*/
    /// <summary>
    /// 系统缓存处理类
    /// </summary>
    public sealed class XYCache
    {
        static ICacheStrategy icachestrategy = null;

        static object lockHelper = new object();

        /// <summary>
        /// 获取单态实例
        /// </summary>
        public static ICacheStrategy Instance
        {
            get
            {
                if (icachestrategy == null)
                {
                    lock (lockHelper)
                    {
                        icachestrategy = Init();
                    }
                }

                return icachestrategy;
            }
        }

        /// <summary>
        /// 初始化对象
        /// </summary>
        /// <returns></returns>
        private static ICacheStrategy Init()
        {
            return icachestrategy = new DefaultCacheStrategy();
        }

        /// <summary>
        /// 产生一个随机秒数(0 ~ 100)
        /// </summary>
        /// <returns></returns>
        private int GetRandSeconds()
        {
            Random r = new Random();
            int randNum = (int)(r.NextDouble() * 120);
            return randNum;
        }
    }
}
