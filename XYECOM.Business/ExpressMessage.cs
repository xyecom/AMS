using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// ��������ҵ����
    /// </summary>
    public class ExpressMessage
    {
        private static readonly XYECOM.SQLServer.ExpressMessage DAL = new XYECOM.SQLServer.ExpressMessage();
        /// <summary>
        /// ��ӿ�������
        /// </summary>
        /// <param name="info">��������ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Insert(XYECOM.Model.ExpressMessageInfo info)
        {
            if (info == null) return 0;

            return DAL.Insert(info);
        }
        /// <summary>
        /// �޸Ŀ�������
        /// </summary>
        /// <param name="info">��������ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Update(XYECOM.Model.ExpressMessageInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }
        /// <summary>
        /// ɾ����������
        /// </summary>
        /// <param name="ids">�������Ա��</param>
        /// <returns>Ӱ������</returns>
        public int Delete(string ids)
        {
            if (String.IsNullOrEmpty(ids) || ids.Trim().Equals("")) return 0;

            return DAL.Delete(ids);
        }
        /// <summary>
        /// �õ�һ����������
        /// </summary>
        /// <param name="id">�������Ա��</param>
        /// <returns>����������Ϣʵ�����</returns>
        public XYECOM.Model.ExpressMessageInfo GetItem(int id)
        {
            if (id <= 0) return null;

            return DAL.GetItem(id);
        }
        /// <summary>
        /// ��ȡָ��ģ������п���������Ϣ
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <returns>ָ��ģ�����п���������Ϣ�ļ���</returns>
        public List<Model.ExpressMessageInfo> GetItems(string moduleName)
        {
            if (string.IsNullOrEmpty(moduleName) || moduleName.Equals("")) return new List<XYECOM.Model.ExpressMessageInfo>();

            return DAL.GetItems(moduleName);
        }
    }
}
