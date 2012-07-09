using System;
using System.Collections.Generic;
using System.Text;

using System.Data ;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// 日志业务类
    /// </summary>
    public class Log
    {
        private static readonly XYECOM.SQLServer.Log DAL = new XYECOM.SQLServer.Log();

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="el">日志实体对象</param>
        /// <returns>影响行数</returns>
        public int Insert(XYECOM.Model.LogInfo el)
        {
            return DAL.Insert(el);
        }

        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="L_ID">日志编号Id</param>
        /// <returns>影响行数</returns>
        public int Delete(int L_ID)
        {
            return DAL.Delete(L_ID);
        }

        /// <summary>
        /// 根据日志编号Id得到日志信息
        /// </summary>
        /// <param name="L_ID">日志编号Id</param>
        /// <returns>日志实体对象</returns>
        public XYECOM .Model  .LogInfo  GetItem(int L_ID)
        {
            return DAL.GetItem(L_ID);
        }

        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="L_ID">日志编号id</param>
        /// <returns>影响行数</returns>
        public int Delete(string  L_ID)
        {
            return DAL.Delete(L_ID);
        }

        /// <summary>
        /// 删除所有日志
        /// </summary>
        /// <returns>影响行数</returns>
        public int DeleteAll()
        {
            return DAL.DeleteAll();
        }

        public string GetOperInfo(string Opertae)
        {
            string ReStr = "";

            if (Opertae != "")
            {
                switch (XYECOM.Core.MyConvert.GetInt32(Opertae))
                {
                    case (int)XYECOM.Model.AccountOperate.ContractMargin:
                        ReStr = "充值合同保证金";
                        break;
                    case (int)XYECOM.Model.AccountOperate.InputMoney:
                        ReStr = "在线充值";
                        break;
                    case (int)XYECOM.Model.AccountOperate.PayContractMargin:
                        ReStr = "支付合同保证金";
                        break;
                    case (int)XYECOM.Model.AccountOperate.PayOrders:
                        ReStr = "支付订单";
                        break;
                    case (int)XYECOM.Model.AccountOperate.PaySupMargin:
                        ReStr = "支付产品保证金";
                        break;
                }
            }

            return ReStr;
        }
    }
}
