using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 固定排名数据处理类
    /// </summary>
    public class Ranking
    {
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns>受影响行数</returns>
        public int Insert(XYECOM.Model.RankingInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@KeyId",info.KeyId),
                new SqlParameter("@UserId",info.UserId),
                new SqlParameter("@InfoIds",info.InfoIds),
                new SqlParameter("@BeginTime",info.BeginTime),
                new SqlParameter("@EndTime",info.EndTime),
                new SqlParameter("@Amount",info.Amount),
                new SqlParameter("@Rank",info.Rank),
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertRanking", param);
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns>受影响行数</returns>
        public int Update(XYECOM.Model.RankingInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@RId",info.RankingId),
                new SqlParameter("@KeyId",info.KeyId),
                new SqlParameter("@UserId",info.UserId),
                new SqlParameter("@InfoIds",info.InfoIds),
                new SqlParameter("@BeginTime",info.BeginTime),
                new SqlParameter("@EndTime",info.EndTime),
                new SqlParameter("@Amount",info.Amount),
                new SqlParameter("@Rank",info.Rank),
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateRanking", param);
        }

        /// <summary>
        /// 删除多条信息
        /// </summary>
        /// <param name="logIds">id字符串</param>
        /// <returns>受影响行数</returns>
        public int Delete(string rIds)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where rid in ( "+rIds + " )"),
                new SqlParameter("@strTableName","XY_Ranking")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }


        /// <summary>
        /// 获取一条排名信息（指定排名记录Id）
        /// </summary>
        /// <param name="rankingId">排名记录Id</param>
        /// <returns>数据对象</returns>
        public Model.RankingInfo GetItem(long rankingId)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Top",""),
                new SqlParameter("@Columns","*"),
                new SqlParameter("@Table","XY_Ranking"),
                new SqlParameter("@Where"," rid=" + rankingId),
                new SqlParameter("@Order","RId desc")
            };

            Model.RankingInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_CommonSelect", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.RankingInfo();

                    info.RankingId = Core.MyConvert.GetInt32(reader["RID"].ToString());
                    info.KeyId = Core.MyConvert.GetInt64(reader["keyId"].ToString());
                    info.UserId = Core.MyConvert.GetInt64(reader["UserId"].ToString());
                    info.InfoIds = reader["InfoIds"].ToString();
                    info.BeginTime = Core.MyConvert.GetDateTime(reader["BeginTime"].ToString());
                    info.EndTime = Core.MyConvert.GetDateTime(reader["EndTime"].ToString());
                    info.Amount = Core.MyConvert.GetDecimal(reader["Amount"].ToString());
                    info.Rank = Core.MyConvert.GetInt16(reader["rank"].ToString());
                }
            }

            return info;
        }

        /// <summary>
        /// 获取一条排名信息（指定用户Id和关键字Id）
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="keyId">关键词Id</param>
        /// <returns>数据对象</returns>
        public Model.RankingInfo GetItem(long userId, long keyId,short rank)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Top",""),
                new SqlParameter("@Columns","*"),
                new SqlParameter("@Table","XY_Ranking"),
                new SqlParameter("@Where"," UserId=" + userId + " and keyId=" + keyId + " rank=" + rank),
                new SqlParameter("@Order","RId desc")
            };

            Model.RankingInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_CommonSelect", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.RankingInfo();

                    info.RankingId = Core.MyConvert.GetInt32(reader["RID"].ToString());
                    info.KeyId = Core.MyConvert.GetInt64(reader["keyId"].ToString());
                    info.UserId = Core.MyConvert.GetInt64(reader["UserId"].ToString());
                    info.InfoIds = reader["InfoIds"].ToString();
                    info.BeginTime = Core.MyConvert.GetDateTime(reader["BeginTime"].ToString());
                    info.EndTime = Core.MyConvert.GetDateTime(reader["EndTime"].ToString());
                    info.Amount = Core.MyConvert.GetDecimal(reader["Amount"].ToString());
                    info.Rank = Core.MyConvert.GetInt16(reader["rank"].ToString());
                }
            }

            return info;
        }

        /// <summary>
        /// 获取一条排名信息(指定关键词Id和名次)
        /// </summary>
        /// <param name="keyId">关键词Id</param>
        /// <param name="rank">名次</param>
        /// <returns>数据对象</returns>
        public Model.RankingInfo GetItem(long keyId, short rank)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Top",""),
                new SqlParameter("@Columns","*"),
                new SqlParameter("@Table","XY_Ranking"),
                new SqlParameter("@Where"," keyId=" + keyId + " and rank=" + rank),
                new SqlParameter("@Order","RId desc")
            };

            Model.RankingInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_CommonSelect", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.RankingInfo();

                    info.RankingId = Core.MyConvert.GetInt32(reader["RID"].ToString());
                    info.KeyId = Core.MyConvert.GetInt64(reader["keyId"].ToString());
                    info.UserId = Core.MyConvert.GetInt64(reader["UserId"].ToString());
                    info.InfoIds = reader["InfoIds"].ToString();
                    info.BeginTime = Core.MyConvert.GetDateTime(reader["BeginTime"].ToString());
                    info.EndTime = Core.MyConvert.GetDateTime(reader["EndTime"].ToString());
                    info.Amount = Core.MyConvert.GetDecimal(reader["Amount"].ToString());
                    info.Rank = Core.MyConvert.GetInt16(reader["rank"].ToString());
                }
            }

            return info;
        }

        /// <summary>
        /// 获取指定关键词的所有排名信息
        /// </summary>
        /// <param name="keyId">关键词Id</param>
        /// <returns>数据实体对对象集合</returns>
        public List<Model.RankingInfo> GetItems(long keyId)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Top",""),
                new SqlParameter("@Columns","*"),
                new SqlParameter("@Table","XY_Ranking"),
                new SqlParameter("@Where"," keyId=" + keyId),
                new SqlParameter("@Order","Rank asc")
            };

            List<Model.RankingInfo> infos = new List<XYECOM.Model.RankingInfo>();

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_CommonSelect", param))
            { 
                Model.RankingInfo info = null;
                while (reader.Read())
                {
                    info = new XYECOM.Model.RankingInfo();

                    info.RankingId = Core.MyConvert.GetInt32(reader["RID"].ToString());
                    info.KeyId = Core.MyConvert.GetInt64(reader["keyId"].ToString());
                    info.UserId = Core.MyConvert.GetInt64(reader["UserId"].ToString());
                    info.InfoIds = reader["InfoIds"].ToString();
                    info.BeginTime = Core.MyConvert.GetDateTime(reader["BeginTime"].ToString());
                    info.EndTime = Core.MyConvert.GetDateTime(reader["EndTime"].ToString());
                    info.Amount = Core.MyConvert.GetDecimal(reader["Amount"].ToString());
                    info.Rank = Core.MyConvert.GetInt16(reader["rank"].ToString());

                    infos.Add(info);
                }
            }

            return infos;
        }
    }
}
