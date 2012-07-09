using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Data ;
using System.Text;


namespace XYECOM.Business
{
    /// <summary>
    /// 用户申请发票业务类
    /// </summary>
    public class UserInvoice
    {
        private static readonly XYECOM.SQLServer.UserInvoice DAL = new XYECOM.SQLServer.UserInvoice();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ei">实体对象</param>
        /// <returns>影响行数</returns>
        public int Insert(XYECOM.Model.UserInvoiceInfo ei)
        {
            return DAL.Insert(ei);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="I_ID">编号Id</param>
        /// <returns>影响行数</returns>
        public int Delete(int I_ID)
        {
            return DAL.Delete(I_ID);
        }

        /// <summary>
        /// 获取发票信息
        /// </summary>
        /// <param name="I_ID">编号Id</param>
        /// <returns>实体对象</returns>
        public XYECOM.Model.UserInvoiceInfo GetItem(int I_ID)
        {
            return DAL.GetItem(I_ID);
        }

        #region 删除多个申请发票信息
        /// <summary>
        /// 删除多个申请发票信息
        /// </summary>
        /// <param name="I_ID">编号集合</param>
        /// <returns>影响行数</returns>
        public int Deletes(string I_ID)
        {
            return DAL.Deletes(I_ID);
        }
        #endregion

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="I_ID">申请发票编号</param>
        /// <param name="I_IsFlag">发票标识</param>
        /// <param name="I_Advice">描述</param>
        /// <param name="I_Reason">原因</param>
        /// <returns>影响行数</returns>
        public int Update(int I_ID, System.Int16 I_IsFlag, string I_Advice, string I_Reason)
        {
            return DAL.Update(I_ID, I_IsFlag, I_Advice, I_Reason);
        }
    }
}
