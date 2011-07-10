using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Web.Caching;

namespace XYECOM.Cache
{
    /// <summary>
    /// ������Խӿ���
    /// </summary>
    public interface ICacheStrategy
    {
        /// <summary>
        /// ��ȡ����Key����
        /// </summary>
        /// <returns></returns>
        ArrayList GetKeys();

        /// <summary>
        /// ���ȫ������
        /// </summary>
        void Remove();

        /// <summary>
        /// �Ƴ�ָ�����Ļ�����
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);

        /// <summary>
        /// ����ָ������ʱ��(��Ϊ��λ)�Ļ�����
        /// </summary>
        /// <param name="key">��</param>
        /// <param name="obj">ֵ</param>
        /// <param name="minutes">������</param>
        /// <param name="cacheDependency">��������</param>
        /// <param name="removeCallback"></param>
        void Insert(string key, object obj, int minutes, CacheDependency cacheDependency, CacheItemRemovedCallback removeCallback);

        /// <summary>
        /// ���뻺��
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="obj">Value</param>
        /// <param name="minutes">ʱ��(����)</param>
        /// <param name="removeCallback">��������ǵĻص�����</param>
        void Insert(string key, object obj, int minutes, CacheItemRemovedCallback removeCallback);

        /// <summary>
        /// ���뻺��
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="obj">Value</param>
        /// <param name="minutes">ʱ��(����)</param>
        void Insert(string key, object obj, int minutes);

        /// <summary>
        /// ���뻺��
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="obj">Value</param>
        void Insert(string key, object obj);


        /// <summary>
        /// ��ȡָ�����Ļ�����
        /// </summary>
        /// <param name="key"></param>        
        /// <returns></returns>
        object Get(string key);
    }
}
