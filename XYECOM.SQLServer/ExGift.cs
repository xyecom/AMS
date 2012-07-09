using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using XYECOM.Core.Data;
using System.Data;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 
    /// </summary>
    public class ExGift
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exGiftInfo"></param>
        /// <param name="giftInfo"></param>
        /// <returns></returns>
        public int ExchangeGift(XYECOM.Model.ExGiftInfo exGiftInfo, XYECOM.Model.GiftInfo giftInfo)
        {
            SqlParameter[] spArray =
            {
               new SqlParameter("@UserId",exGiftInfo.UserId),
               new SqlParameter("@GId",giftInfo.GId),
               new SqlParameter("@Name",giftInfo.Name),
               new SqlParameter("@Amount",giftInfo.Amount),
               new SqlParameter("@Number",exGiftInfo.Number),
               new SqlParameter("@ReturnValue",SqlDbType.Int)
            };
            spArray[5].Direction=ParameterDirection.ReturnValue;

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_ExchangeGift", spArray);

            return XYECOM.Core.MyConvert.GetInt32(spArray[5].Value.ToString());
        }

        /// <summary>
        /// 改变兑换记录的状态
        /// </summary>
        /// <param name="exId">兑换记录ID</param>
        /// <param name="newState">0：待确认；1：已确认</param>
        /// <returns>影响的行数</returns>
        public int UpdateState(int exId, int newState)
        {
            SqlParameter[] spArray =
            {
                new SqlParameter("@ExId",exId),
                new SqlParameter("@NewState",newState)
            };
            int err = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_ChangeState", spArray);
            return err;
        }


        #region 删除礼物
        /// <summary>
        /// 删除多条礼品兑换记录
        /// </summary>
        /// <param name="ExIds">礼品兑换编号字符串</param>
        /// <returns>数字。大于等于0表示删除成功</returns>
        public int Delete(string ExIds)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where ExId in ("+ExIds+")"),
                new SqlParameter("@strTableName","XY_ExGift")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        #endregion

        /// <summary>
        /// 检查指定礼品是否有指定兑换状态的记录，状态小于0则不判断该状态
        /// </summary>
        /// <param name="gId">礼品ID</param>
        /// <param name="state">0：等待确认；1：已确认</param>
        /// <returns>1：存在；0：不存在</returns>
        public int IsExistExchange(int gId, int state)
        {
            SqlParameter[] spArray =
            {
                new SqlParameter("@GId",gId),
                new SqlParameter("@State",state),
                new SqlParameter("@ReturnValue",SqlDbType.Int)
            };
            spArray[2].Direction = ParameterDirection.ReturnValue;
            XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_IsExistExchange", spArray);
            return XYECOM.Core.MyConvert.GetInt32(spArray[2].Value.ToString());
        }
    }
}
