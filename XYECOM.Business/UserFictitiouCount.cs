using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// 用户虚拟账户业务类
    /// </summary>
    public class UserFictitiouCount
    {
        private static readonly XYECOM.SQLServer.UserFictitiouCount DAL = new XYECOM.SQLServer.UserFictitiouCount();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="efc">实体对象</param>
        /// <returns>影响行数</returns>
        public int Insert(XYECOM.Model.UserFictitiouCountInfo efc)
        {
            return DAL.Insert(efc);
        }

        /// <summary>
        /// 获取一条虚拟账户信息
        /// </summary>
        /// <param name="userId">用户编号Id</param>
        /// <returns>实体对象</returns>
        public Model.UserFictitiouCountInfo GetItem(long userId)
        {
            if (userId <= 0) return null;
            
            return DAL.GetItem(userId);
        }

        //public DataTable GetDataTable(long U_ID)
        //{
        //    return DAL.GetDataTable(U_ID);
        //}

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="U_ID">用户编号Id</param>
        /// <param name="Money">金额</param>
        /// <returns>影响行数</returns>
        public int UpdateUserFictitiouCount(long U_ID, decimal Money)
        {
            return DAL.UpdateUserFictitiouCount(U_ID, Money);
        }

        /// <summary>
        /// 扣除用户的虚拟币
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="amount">金额</param>
        /// <returns>影响行数</returns>
        public int DeductUserUUFictitiouCount(long userId, decimal amount)
        {
            return DAL.DeductUserUUFictitiouCount(userId, amount);
        }
    }
}
