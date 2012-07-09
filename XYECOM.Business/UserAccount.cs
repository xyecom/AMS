using System;
using System.Collections.Generic;
using System.Text;

using System.Data;



namespace XYECOM.Business
{
    /// <summary>
   /// 用户现金账户业务类
   /// </summary>
    public class UserAccount
    {
        private static readonly XYECOM.SQLServer.UserAccount DAL = new XYECOM.SQLServer.UserAccount();
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="UGR_ID">现金账户编号Id</param>
        /// <returns>影响行数</returns>
        public int DeleteAcount(int UGR_ID)
        {
            return DAL.DeleteAcount(UGR_ID);
        }

        /// <summary>
        /// 根据用户编号得到该用户现金账户的信息
        /// </summary>
        /// <param name="U_ID">用户编号Id</param>
        /// <returns>用户现金账户Id</returns>
        public DataTable GetDataTable(long U_ID)
        {
            return DAL.GetDataTable(U_ID);
        }

        /// <summary>
        /// 返回指定用户账户信息
        /// </summary>
        /// <param name="userId">用户编号Id</param>
        /// <returns>用户现金账户实体对象</returns>
        public Model.UserAccountInfo GetItem(long userId)
        {
            if (userId <= 0) return null;

            return DAL.GetItem(userId);
        }

        #region 剩余的钱给用户入账户
        /// <summary>
        /// 剩余的钱给用户入账
        /// </summary>
        /// <param name="U_ID">用户编号Id</param>
        /// <param name="Money">用户剩余的钱</param>
        /// <returns>影响行数</returns>
        public int AddAccountMoney(long U_ID, decimal Money)
        {
            return DAL.AddAccountMoney(U_ID, Money);
        }
        #endregion
        
        #region 扣除用户账户金额
        /// <summary>
        /// 扣除用户账户金额
        /// </summary>
        /// <param name="U_ID">用户编号Id</param>
        /// <param name="Money">扣除用户的金额</param>
        /// <returns>影响行数</returns>
        public int DeductAccountMoney(long U_ID, decimal Money)
        {
            return DAL.DeductAccountMoney(U_ID, Money);
        }
        #endregion    
    }
}
