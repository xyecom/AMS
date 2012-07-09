using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// �û����궥������ҵ����
    /// </summary>
    public class UserDomain
    {
        private static readonly XYECOM.SQLServer.UserDomain DAL = new XYECOM.SQLServer.UserDomain();

        /// <summary>
        /// ����(����)
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Update(Model.UserDomainInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }

        /// <summary>
        /// ��ȡָ���û�Id��������Ϣ
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <returns></returns>
        public Model.UserDomainInfo GetItem(long userId)
        {
            if (userId <= 0) return null;

            return DAL.GetItem(userId);
        }

        /// <summary>
        /// ��ȡָ����������Ϣ
        /// </summary>
        /// <param name="domain">����</param>
        /// <returns></returns>
        public Model.UserDomainInfo GetItem(string domain)
        {
            if (string.IsNullOrEmpty(domain) || domain.Trim().Equals("")) return null;

            return DAL.GetItem(domain);
        }

        /// <summary>
        /// ɾ��ָ���û��Ķ���������Ϣ
        /// </summary>
        /// <param name="userId">�û�id</param>
        /// <returns></returns>
        public int Delete(long userId)
        {
            if (userId <= 0) return 0;

            return DAL.Delete(userId);
        }

        public int Delete(string ids)
        {
            return DAL.Deletes(ids);
        }
    }
}
