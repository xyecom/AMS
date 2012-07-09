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
    public class ChargeNewsSet
    {
        /// <summary>
        /// 添加一条新的新闻设置对象
        /// </summary>
        /// <param name="ci">要添加的新闻设置对象</param>
        /// <returns>数字,大于或等于0表成功,等于-1表有雷同设置,其他表失败</returns>
        public int Insert(ChargeNewsSetInfo ci)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CN_VisitPopedom",ci.CN_VisitPopedom),
                new SqlParameter("@CN_ConsumeWebMoney",ci.CN_ConsumeWebMoney),
                new SqlParameter("@CN_ConsumeMoney",ci.CN_ConsumeMoney),
                new SqlParameter("@NS_ID",ci.NS_ID)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertChargeNews", param);
        }

        /// <summary>
        /// 更改指定新闻设置对象
        /// </summary>
        /// <param name="ci">要修改的新闻设置对象</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int Update(ChargeNewsSetInfo ci)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CN_ID",ci.CN_ID),
                new SqlParameter("@CN_VisitPopedom",ci.CN_VisitPopedom),
                new SqlParameter("@CN_ConsumeWebMoney",ci.CN_ConsumeWebMoney),
                new SqlParameter("@CN_ConsumeMoney",ci.CN_ConsumeMoney),
                new SqlParameter("@NS_ID",ci.NS_ID)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_UpdateChargeNews", param);
        }

        /// <summary>
        /// 删除指定编号集的收费新闻设置
        /// </summary>
        /// <param name="newsIds">要删除的收费新闻编号集</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int Delete(string newsIds)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where NS_ID in ("+newsIds+")"),
                new SqlParameter("@strTableName","n_ChargeNewsSet")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// 按会员等级删除收费新闻资费信息
        /// </summary>
        /// <param name="userGradeId"></param>
        /// <returns></returns>
        public int DeleteByUserGradeId(int userGradeId)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where CN_VisitPopedom =" + userGradeId),
                new SqlParameter("@strTableName","n_ChargeNewsSet")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param); 
        }

        /// <summary>
        /// 获取满足指定条件的收费新闻设置对象集
        /// </summary>
        /// <param name="strWhere">指定的Where条件</param>
        /// <param name="Oder">指定的排序条件</param>
        /// <returns>满足指定条件的收费新闻设置对象集</returns>
        public DataTable GetDataTable(string strWhere, string Order)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","n_ChargeNewsSet"),
                new SqlParameter("@strOrder",Order)
            };

            return XYECOM.Core.Data.SqlHelper.GetDataTable("XYP_SelectByWhere", param);
        }

        /// <summary>
        /// 获取指定编号的收费新闻对象
        /// </summary>
        /// <param name="ciid">指定的收费新闻编号</param>
        /// <returns>该编号对应的收费新闻对象</returns>
        public ChargeNewsSetInfo GetItem(Int64 ciid)
        {
            ChargeNewsSetInfo info = null;

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where CN_ID="+ciid.ToString()),
                new SqlParameter("@strTableName","n_ChargeNewsSet"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (dr.Read())
                {
                    info = new ChargeNewsSetInfo();
                    info.NS_ID = Convert.ToInt64(dr["NS_ID"]);
                    info.CN_VisitPopedom = Convert.ToInt16(dr["CN_VisitPopedom"]);
                    info.CN_ConsumeWebMoney = Convert.ToInt32(dr["CN_ConsumeWebMoney"]);
                    info.CN_ConsumeMoney = Convert.ToInt32(dr["CN_ConsumeMoney"]);
                    info.CN_ID = Convert.ToInt64(dr["CN_ID"]);
                }
            }

            return info;
        }

        /// <summary>
        /// 获取指定资讯编号和用户等级的收费新闻对象
        /// </summary>
        /// <param name="newsId">新闻ID</param>
        /// <param name="userGaadeId">等级Id</param>
        /// <returns></returns>
        public ChargeNewsSetInfo GetItem(long newsId, int userGradeId)
        {
            ChargeNewsSetInfo info = null;

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where NS_ID="+newsId + "and CN_VisitPopedom=" + userGradeId),
                new SqlParameter("@strTableName","n_ChargeNewsSet"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (dr.Read())
                {
                    info = new ChargeNewsSetInfo();
                    info.NS_ID = Convert.ToInt64(dr["NS_ID"]);
                    info.CN_VisitPopedom = Convert.ToInt16(dr["CN_VisitPopedom"]);
                    info.CN_ConsumeWebMoney = Convert.ToInt32(dr["CN_ConsumeWebMoney"]);
                    info.CN_ConsumeMoney = Convert.ToInt32(dr["CN_ConsumeMoney"]);
                    info.CN_ID = Convert.ToInt64(dr["CN_ID"]);
                }
            }

            return info;
        }

        /// <summary>
        /// 获取满足指定条件的字段的集合
        /// </summary>
        /// <param name="strWhere">指定的Where条件</param>
        /// <param name="Field">要获取的字段</param>
        /// <returns>满足条件的字段的集合</returns>
        public DataTable GetDataTableForField(string strWhere, string Field)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTable","n_ChargeNewsSet"),
                new SqlParameter("@strField",Field)
            };

            return XYECOM.Core.Data.SqlHelper.GetDataTable("XYP_GetFieldByWhere", param);
        }
    }
}
