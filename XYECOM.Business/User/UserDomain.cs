using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// 用户网店顶级域名业务类
    /// </summary>
    public class UserDomain
    {
        private static readonly XYECOM.SQLServer.UserDomain DAL = new XYECOM.SQLServer.UserDomain();

        /// <summary>
        /// 更新(插入)
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Update(Model.UserDomainInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }

        /// <summary>
        /// 获取指定用户Id的域名信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public Model.UserDomainInfo GetItem(long userId)
        {
            if (userId <= 0) return null;

            return DAL.GetItem(userId);
        }

        /// <summary>
        /// 获取指定域名的信息
        /// </summary>
        /// <param name="domain">域名</param>
        /// <returns></returns>
        public Model.UserDomainInfo GetItem(string domain)
        {
            if (string.IsNullOrEmpty(domain) || domain.Trim().Equals("")) return null;

            return DAL.GetItem(domain);
        }

        /// <summary>
        /// 删除指定用户的顶级域名信息
        /// </summary>
        /// <param name="userId">用户id</param>
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
