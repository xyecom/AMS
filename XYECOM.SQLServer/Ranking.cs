using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// �̶��������ݴ�����
    /// </summary>
    public class Ranking
    {
        /// <summary>
        /// �����¼
        /// </summary>
        /// <param name="info">���ݶ���</param>
        /// <returns>��Ӱ������</returns>
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
        /// ���¼�¼
        /// </summary>
        /// <param name="info">���ݶ���</param>
        /// <returns>��Ӱ������</returns>
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
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="logIds">id�ַ���</param>
        /// <returns>��Ӱ������</returns>
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
        /// ��ȡһ��������Ϣ��ָ��������¼Id��
        /// </summary>
        /// <param name="rankingId">������¼Id</param>
        /// <returns>���ݶ���</returns>
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
        /// ��ȡһ��������Ϣ��ָ���û�Id�͹ؼ���Id��
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <param name="keyId">�ؼ���Id</param>
        /// <returns>���ݶ���</returns>
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
        /// ��ȡһ��������Ϣ(ָ���ؼ���Id������)
        /// </summary>
        /// <param name="keyId">�ؼ���Id</param>
        /// <param name="rank">����</param>
        /// <returns>���ݶ���</returns>
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
        /// ��ȡָ���ؼ��ʵ�����������Ϣ
        /// </summary>
        /// <param name="keyId">�ؼ���Id</param>
        /// <returns>����ʵ��Զ��󼯺�</returns>
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
