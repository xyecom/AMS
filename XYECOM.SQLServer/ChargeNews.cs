using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using XYECOM.Model;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 收费资讯数据处理类
    /// </summary>
    public class ChargeNews
    {
        /// <summary>
        /// 添加新的收费信息对象
        /// </summary>
        /// <param name="cn">要添加的收费信息对象</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int Insert(ChargeNewsInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@U_ID",info.U_ID),
                new SqlParameter("@NS_ID",info.NS_ID)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertChargeNewsInfo", param);
        }

        /// <summary>
        /// 删除指定的收费信息对象
        /// </summary>
        /// <param name="ids">要删除的收费信息对象编号集</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int Delete(string ids)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where CI_ID in ("+ids+")"),
                new SqlParameter("@strTableName","n_ChargeNewsInfo")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// 获取满足指定条件的收费信息集
        /// </summary>
        /// <param name="strWhere">指定的Where条件</param>
        /// <param name="Order">指定的Order条件</param>
        /// <returns>满足条件的DataTable集</returns>
        public DataTable GetDataTable(string strWhere, string Order)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","n_ChargeNewsInfo"),
                new SqlParameter("@strOrder",Order)
            };

            return XYECOM.Core.Data.SqlHelper.GetDataTable("XYP_SelectByWhere", param);
        }

        /// <summary>
        /// 获取指定编号的收费信息对象
        /// </summary>
        /// <param name="cnid">指定的收费信息对象编号</param>
        /// <returns>该编号下的收费信息对象</returns>
        public ChargeNewsInfo GetItem(Int64 cnid)
        {
            ChargeNewsInfo chargenew = null;
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere","where CI_ID="+cnid.ToString()),
                new SqlParameter("@strTableName","n_ChargeNewsInfo"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (dr.Read())
                    chargenew = new ChargeNewsInfo(Convert.ToInt64(dr["CI_ID"]), Convert.ToInt64(dr["U_ID"]), Convert.ToInt64(dr["NS_ID"]), Convert.ToDateTime(dr["CI_AddTime"]));
            }
            return chargenew;
        }

        /// <summary>
        /// 判断用户对某收费新闻是否付过费
        /// </summary>
        /// <param name="uid">指定的用户编号</param>
        /// <param name="nsid">指定的新闻编号</param>
        /// <returns>bool型,false表已付费,true表没有尚未付费</returns>
        public int GetIsCharged(Int64 uid, Int64 nsid, out int webmoney, out int money)
        {
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@U_ID",uid),
                    new SqlParameter("@NS_ID",nsid),
                    new SqlParameter("@CN_ConsumeWebMoney",SqlDbType.Int),
                    new SqlParameter("@CN_ConsumeMoney",SqlDbType.Int),
                    new SqlParameter("@lue",SqlDbType.Int)
                };

                param[2].Direction = ParameterDirection.Output;
                param[3].Direction = ParameterDirection.Output;
                param[4].Direction = ParameterDirection.ReturnValue;

                object row = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_IsChargedForNews", param);

                if (string.IsNullOrEmpty(param[2].Value.ToString()))
                    webmoney = 0;
                else
                    webmoney = Convert.ToInt32(param[2].Value.ToString());

                if (string.IsNullOrEmpty(param[3].Value.ToString()))
                    money = 0;
                else
                    money = Convert.ToInt32(param[3].Value.ToString());

                if (string.IsNullOrEmpty(param[4].Value.ToString()))
                    return -5; //表查询错误
                else
                    return Convert.ToInt32(param[4].Value.ToString());
        }

        /// <summary>
        /// 指定的用户缴纳付费新闻操作,先进行扣费,然后添加消费记录(现金,虚拟)，最后添加新闻付费记录
        /// </summary>
        /// <param name="uid">指定的用户</param>
        /// <param name="nsid">要付费的新闻</param>
        /// <param name="webmoney">要缴纳的虚拟货币</param>
        /// <param name="money">要缴纳的现金货币</param>
        /// <returns>数字,大于或等于0表缴费操作成功,-1表余额不足,-2表缴费失败</returns>
        public int ConsumeUpdateMoney(Int64 uid, Int64 nsid, Decimal webmoney, Decimal money)
        {
            string AC_Explain = "支付收费新闻的现金货币金额";
            string FC_Explain = "支付收费新闻的虚拟货币金额";

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@U_ID",uid),
                new SqlParameter("@NS_ID",nsid),
                new SqlParameter("@ConsumeFictitiouMoney",webmoney),
                new SqlParameter("@ConsumeAccountMoney",money),
                new SqlParameter("@AC_Explain",AC_Explain),
                new SqlParameter("@FC_Explain",FC_Explain)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_UpdateConsumption", param);
        }
    }
}
