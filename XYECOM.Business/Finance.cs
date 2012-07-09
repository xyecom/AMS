using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;


namespace XYECOM.Business
{
    /// <summary>
    /// 财务业务类
    /// </summary>
    public class Finance
    {
        private static readonly XYECOM.SQLServer.Finance DAL =new XYECOM.SQLServer.Finance();

        /// <summary>
        /// 添加财务信息
        /// </summary>
        /// <param name="ef">财务实体对象</param>
        /// <returns>影响行数</returns>
        public int Insert(XYECOM.Model.FinanceInfo ef)
        {
            return DAL.Insert(ef);
        }
        /// <summary>
        /// 修改财务信息
        /// </summary>
        /// <param name="F_ID">编号</param>
        /// <param name="FT_ID">财务类别编号</param>
        /// <param name="M_Money">钱</param>
        /// <param name="U_Name">用户名</param>
        /// <param name="F_Remark">评论</param>
        /// <returns></returns>
        public int Update(int F_ID ,int FT_ID, decimal M_Money,string U_Name,string F_Remark)
        {
            return DAL.Update(F_ID, FT_ID, M_Money, U_Name, F_Remark);
        }
        /// <summary>
        /// 删除财务信息
        /// </summary>
        /// <param name="F_ID">编号Id</param>
        /// <returns>影响行数</returns>
        public int Delete(int F_ID)
        {
            return DAL.Delete(F_ID);
        }
        /// <summary>
        /// 根据编号得到一条财务信息
        /// </summary>
        /// <param name="F_ID">编号</param>
        /// <returns>财务信息实体对象</returns>
        public XYECOM .Model .FinanceInfo  GetItem(int F_ID)
        {
            return DAL.GetItem(F_ID);
        }
    }
}
