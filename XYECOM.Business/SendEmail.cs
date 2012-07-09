using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
  
    /// <summary>
    /// 发送邮件业务类
    /// </summary>
    public class SendEmail
    {
        private static readonly XYECOM.SQLServer.SendEmail DAL = new XYECOM.SQLServer.SendEmail();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="se">发送邮件类实体对象</param>
        /// <returns>影响行数</returns>
        public int Insert(XYECOM.Model.SendEmailInfo se)
        {
            return DAL.Insert(se);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="E_ID">邮件编号Id</param>
        /// <returns>影响的行数</returns>
        public int Delete(int E_ID)
        {
            return DAL.Delete(E_ID);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="se">邮件类实体对象</param>
        /// <returns>影响行数</returns>
        public int Update(XYECOM.Model.SendEmailInfo se)
        {
            return DAL.Update(se);
        }
        /// <summary>
        /// 得到一条邮件信息
        /// </summary>
        /// <param name="E_ID">邮件编号Id</param>
        /// <returns>邮件类实体对象</returns>
        public XYECOM.Model.SendEmailInfo GetItem(int E_ID)
        {
            return DAL.GetItem(E_ID);
        }

        #region 删除多个邮件信息
        /// <summary>
        /// 删除多个邮件信息
        /// </summary>
        /// <param name="E_ID">邮件编号集合</param>
        /// <returns>影响行数</returns>
        public int Deletes(string E_ID)
        {
            return DAL.Deletes(E_ID);
        }
        #endregion
    }
}
