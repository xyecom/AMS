using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;

namespace XYECOM.SQLServer
{
    public partial class ContractAccess
    {
        /// <summary>
        /// 根据用户编号，获取合同信息
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="isBuyer">是否是采购商，True是采购商</param>
        /// <returns></returns>
        public DataTable SelectByUserId(int userId, bool isBuyer)
        {
            string sql = "select * from XYV_PersonContracts";

            if (isBuyer)
            {
                sql += " where BuyerId=" + userId;
            }
            else
            {
                sql += " where SellerId=" + userId;
            }

            return SqlHelper.ExecuteTable(sql);
        }

        /// <summary>
        /// 确认合同
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public int ConfirmContract(int infoId)
        {
            string sql = "UPDATE XY_Contract SET EffectDate=getdate(),State=" + ((int)Model.ContractStatus.Effective) + " where Id=" + infoId;
            return SqlHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 关闭合同
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public int CloseContract(int infoId)
        {
            //添加完成时间字段
            string sql = "UPDATE XY_Contract SET CloseDate=getdate(),State=" + ((int)Model.ContractStatus.Closed) + " where Id=" + infoId;
            //string sql = "UPDATE XY_Contract SET State=" + ((int)Model.ContractStatus.Closed) + " where Id=" + infoId;
            return SqlHelper.ExecuteNonQuery(sql);
        }

        public int CancelContract(int infoId)
        {
            string sql = "DELETE FROM XY_ContractDetails WHERE ContractId=" + infoId + ";DELETE FROM XY_Contract WHERE Id=" + infoId;
            return SqlHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 合同异议
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public int ObjectionContract(int infoId)
        {
            string sql = "UPDATE XY_Contract SET State=" + ((int)Model.ContractStatus.WaitingForBuyerEdit) + " where Id=" + infoId;
            return SqlHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 锁定订单
        /// </summary>
        /// <param name="infoId">合同编号（PKID）</param>
        /// <returns></returns>
        public int LockOrder(int infoId)
        {
            string sql = "update XY_Contract set BackState=State,State=" + (int)Model.ContractStatus.Lock + ",locktime=getdate(),islock = 1 where id =" + infoId;
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 解锁订单
        /// </summary>
        /// <param name="infoId">合同编号（PKID）</param>
        /// <returns></returns>
        public int UnLockOrder(int infoId)
        {
            string sql = "update XY_Contract set State=backState,backState=null,locktime=null,islock = 0 where id =" + infoId;
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 根据服务要求获取集合
        /// </summary>
        /// <param name="State"></param>
        /// <returns>对象集合</returns>
        /// 
        public DataTable GetObjServer(XYECOM.Model.ContractStatus State)
        {
            string sql = "SELECT Id FROM XY_Contract WHERE ContractPeriod < GETDATE() AND isLock=0 AND State=" + ((int)State);
            return SqlHelper.ExecuteTable(sql);
        }
    }
}
