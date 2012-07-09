//------------------------------------------------------------------------------
//
// file name：XY_AccountAccessor.cs
// author: wangzhen
// create date：2011-3-29 16:07:06
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// Data accessor of AccountAccess
    /// </summary>
    public partial class AccountAccess
    {
        /// <summary>
        /// 增加或者减少现金账户的金额(该方法只用于充值或者购买商品)
        /// </summary>
        /// <param name="infoId">用户ID</param>
        /// <param name="money">操作的金额</param>
        /// <param name="type">type=1为支出，type=2为收入，type=3缴纳保证金，type=4释放保证</param>
        /// <returns>受影响的行数</returns>
        public int IncreaseOrDecrease(int infoId, decimal money, int type)
        {

            if (infoId < 1 || money <= 0)
            {
                return 0;
            }
            SqlParameter[] parameter = new SqlParameter[] 
            {
                new SqlParameter("@accountId",infoId),
                new SqlParameter("@perationMoney",money),
                new SqlParameter("@type",type)
            };
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_IncreaseOrDecrease", parameter);
        }

        /// <summary>
        /// 关闭合同时进行释放保证金同事修改可用的大宗保证金（减去平台扣去的合同提成费用）
        /// </summary>
        /// <param name="infoId">供应商现金账户ID</param>
        /// <param name="money">冻结的金额</param>
        /// <param name="type">操作类型（当前为释放合同保证金）</param>
        /// <param name="actualAvailbMoney">实际可用的合同保证金金额</param>
        /// <returns>受影响的行数</returns>
        public int IncreaseOrDecrease(int infoId, decimal money, int type, decimal actualAvailbMoney)
        {

            if (infoId < 1 || money <= 0)
            {
                return 0;
            }
            SqlParameter[] parameter = new SqlParameter[] 
            {
                new SqlParameter("@accountId",infoId),
                new SqlParameter("@perationMoney",money),
                new SqlParameter("@type",type),
                new SqlParameter("@actualAvailbMoney",actualAvailbMoney)
            };
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_IncreaseOrDecrease", parameter);
        }

        /// <summary>
        ///根据现金账户的变化增加总金额
        /// </summary>
        /// <param name="accountId">现金账户变化</param>
        /// <param name="money">增加的总金额</param>
        /// <returns>受影响的行数</returns>
        public int IncreaseSumMoney(int accountId, decimal money)
        {
            if (money <= 0 || accountId <= 0)
            {
                return 0;
            }
            string sql = "update xy_account set summoney = summoney + " + money + " where id = " + accountId + "";
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        ///记录平台累计金额
        /// </summary>
        /// <param name="money">增加的总金额</param>
        /// <returns>受影响的行数</returns>
        public int IncreaseSumMoney(decimal money)
        {
            if (money <= 0)
            {
                return 0;
            }
            string sql = "update xy_account set summoney = summoney + " + money + " where cashAccount = 'ShanDongYiJia'";
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
        }


        /// <summary>
        ///充值
        /// </summary>
        /// <param name="accountId">用户ID</param>
        /// <param name="money">充值金额</param>
        /// <returns>受影响的行数</returns>
        public int Charge(int accountId, decimal money)
        {
            if (money <= 0 || accountId <= 0)
            {
                return 0;
            }
            string sql = "update xy_account set summoney = summoney + " + money + ",AvailableMoney = AvailableMoney + " + money + ",CurrentBalance = CurrentBalance + " + money + " where id = " + accountId + "";
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
        }
    }
}
