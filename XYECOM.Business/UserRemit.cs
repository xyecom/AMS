using System;
using System.Collections.Generic;

using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// 汇款信息业务类
    /// </summary>
    public class UserRemit
    {
        private static readonly XYECOM.SQLServer.UserRemit DAL = new XYECOM.SQLServer.UserRemit();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="er">实体对象</param>
        /// <returns>影响行数</returns>
        public int Insert(XYECOM.Model.UserRemitInfo er)
        {
            return DAL.Insert(er);
        }
        
      
        //public DataTable  GetDataTable(int  R_ID)
        //{
        //    return DAL.GetDataTable(R_ID);  
        //}

        /// <summary>
        /// 获取一条汇款信息
        /// </summary>
        /// <param name="R_ID">编号Id</param>
        /// <returns>实体对象</returns>
        public XYECOM.Model.UserRemitInfo GetItem(int R_ID)
        {
            return DAL.GetItem(R_ID);
        }
        
        /// <summary>
        /// 删除一条汇款信息
        /// </summary>
        /// <param name="R_ID">编号Id</param>
        /// <returns>影响行数</returns>
        public int Delete(int R_ID)
        {
            return DAL.Delete(R_ID);
        }
        #region 删除多个汇款确认信息
        /// <summary>
        /// 删除多个汇款信息
        /// </summary>
        /// <param name="R_ID">编号集合</param>
        /// <returns>影响行数</returns>
        public int Deletes(string R_ID)
        {
            return DAL.Deletes(R_ID);
        }
        #endregion

        /// <summary>
        /// 修改用户现金账户
        /// </summary>
        /// <param name="U_ID">用户编号Id</param>
        /// <param name="Money">金额</param>
        /// <returns>影响行数</returns>
        public  int UpdateMoney(long U_ID, Decimal Money)
        {
            return DAL.UpdateMoney(U_ID, Money);
        }

        /// <summary>
        /// 修改是否充值
        /// </summary>
        /// <param name="R_ID">编号Id</param>
        /// <returns>影响行数</returns>
        public int UpdateIsPay(long R_ID)
        {
            return DAL.UpdateIsPay(R_ID);
        }
        #region 扣除用户的诚信指数
        /// <summary>
        /// 扣除用户的诚信指数
        /// </summary>
        /// <param name="U_ID">用户编号Id</param>
        /// <param name="Money">诚信指数</param>
        /// <returns>影响行数</returns>
        public int DeductFaithMongy(long U_ID,int Money)
        {
            return DAL.DeductFaithMongy(U_ID, Money);
        }
        #endregion
    }
}
