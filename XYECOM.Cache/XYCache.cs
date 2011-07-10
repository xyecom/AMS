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
     * Copyright (C) 2008 �ݺ�����������޹�˾
     * ��Ȩ���С� 
     *
     * �ļ�����XYECOM.Cache.XYCache.cs
     * �ļ�����������ϵͳ���������
     *
     * ������ʶ��tc 20080417
     *
     * �޸ı�ʶ��
     * �޸�������
     ----------------------------------------------------------------*/
    /// <summary>
    /// ϵͳ���洦����
    /// </summary>
    public sealed class XYCache
    {
        static ICacheStrategy icachestrategy = null;

        static object lockHelper = new object();

        /// <summary>
        /// ��ȡ��̬ʵ��
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
        /// ��ʼ������
        /// </summary>
        /// <returns></returns>
        private static ICacheStrategy Init()
        {
            return icachestrategy = new DefaultCacheStrategy();
        }

        /// <summary>
        /// ����һ���������(0 ~ 100)
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
