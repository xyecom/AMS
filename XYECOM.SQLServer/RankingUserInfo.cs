using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace XYECOM.SQLServer
{
    public class RankingUserInfo
    {

        /// <summary>
        /// ���������Զ�����Ϣ
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Update(XYECOM.Model.RankingUserInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@RU_UserId",info.UserId),                
                new SqlParameter("@RU_RankingId",info.RankingId),
                new SqlParameter("@RU_ModuleName",info.ModuleName),
                new SqlParameter("@RU_Title",info.Title),
                new SqlParameter("@RU_Desc",info.Desc),
                new SqlParameter("@RU_Link",info.Link),
                new SqlParameter("@RU_ImageUrl",info.ImageUrl),
                new SqlParameter("@RU_IsHasImage",info.IsHasImage),
                new SqlParameter("@RU_AuditingState",info.AuditingState),
                new SqlParameter("@RU_Rank",info.Rank)
            };
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateRankingUserInfo", param);
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public int Delete(int infoId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where InfoID="+infoId),
                new SqlParameter("@strTableName","XY_RankingUserInfo")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        /// <summary>
        /// �����Զ���id�����Զ�������
        /// </summary>
        /// <param name="InfoId"></param>
        /// <returns></returns>
        public Model.RankingUserInfo GetItem(int InfoId)
        {
            XYECOM.Model.RankingUserInfo info = null;
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where InfoId=" + InfoId ),
                new SqlParameter("@strTableName","XY_RankingUserInfo"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.RankingUserInfo();

                    info.InfoId = Core.MyConvert.GetInt32(reader["infoId"].ToString());
                    info.UserId = Core.MyConvert.GetInt64(reader["UserId"].ToString());
                    info.RankingId = Core.MyConvert.GetInt32(reader["rankingId"].ToString());
                    info.ModuleName = reader["moduleName"].ToString();
                    info.Title = reader["title"].ToString();
                    info.Desc = reader["desc"].ToString();
                    info.Link = reader["LInk"].ToString();
                    info.ImageUrl = reader["ImageUrl"].ToString();
                    info.IsHasImage = Core.MyConvert.GetInt32(reader["IsHasImage"].ToString());
                    info.IntAuditingState = Core.MyConvert.GetInt32(reader["AuditingState"].ToString());
                    info.Rank = Core.MyConvert.GetInt32(reader["Rank"].ToString());
                }
            }

            return info;
        }
        /// <summary>
        /// ��ȡ��Ϣ
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <param name="rankingId">����id</param>
        /// <param name="rank">����</param>
        /// <param name="moduleName">ģ������</param>
        /// <returns></returns>
        public Model.RankingUserInfo GetItem(long userId, int rankingId, int rank,string moduleName)
        {
            XYECOM.Model.RankingUserInfo info = null;

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where UserId=" + userId + " and RankingId = " + rankingId + " and rank=" + rank + " and moduleName='"+moduleName+"'" ),
                new SqlParameter("@strTableName","XY_RankingUserInfo"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.RankingUserInfo();

                    info.InfoId = Core.MyConvert.GetInt32(reader["infoId"].ToString());
                    info.UserId = Core.MyConvert.GetInt64(reader["UserId"].ToString());
                    info.RankingId = Core.MyConvert.GetInt32(reader["rankingId"].ToString());
                    info.ModuleName = reader["moduleName"].ToString();
                    info.Title = reader["title"].ToString();
                    info.Desc = reader["desc"].ToString();
                    info.Link = reader["LInk"].ToString();
                    info.ImageUrl = reader["ImageUrl"].ToString();
                    info.IsHasImage = Core.MyConvert.GetInt32(reader["IsHasImage"].ToString());
                    info.IntAuditingState = Core.MyConvert.GetInt32(reader["AuditingState"].ToString());
                    info.Rank = Core.MyConvert.GetInt32(reader["Rank"].ToString());
                }
            }

            return info;
        }


        /// <summary>
        /// ��ȡ��Ϣ
        /// </summary>
        /// <param name="rankingId">����id</param>
        /// <param name="rank">����</param>
        /// <param name="moduleName">ģ������</param>
        /// <returns></returns>
        public Model.RankingUserInfo GetItem(int rankingId, int rank, string moduleName)
        {
            XYECOM.Model.RankingUserInfo info = null;

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where RankingId = " + rankingId + " and rank=" + rank + " and moduleName='"+moduleName+"'" ),
                new SqlParameter("@strTableName","XY_RankingUserInfo"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.RankingUserInfo();

                    info.InfoId = Core.MyConvert.GetInt32(reader["infoId"].ToString());
                    info.UserId = Core.MyConvert.GetInt64(reader["UserId"].ToString());
                    info.RankingId = Core.MyConvert.GetInt32(reader["rankingId"].ToString());
                    info.ModuleName = reader["moduleName"].ToString();
                    info.Title = reader["title"].ToString();
                    info.Desc = reader["desc"].ToString();
                    info.Link = reader["LInk"].ToString();
                    info.ImageUrl = reader["ImageUrl"].ToString();
                    info.IsHasImage = Core.MyConvert.GetInt32(reader["IsHasImage"].ToString());
                    info.IntAuditingState = Core.MyConvert.GetInt32(reader["AuditingState"].ToString());
                    info.Rank = Core.MyConvert.GetInt32(reader["Rank"].ToString());
                }
            }

            return info;
        }
    }
}
