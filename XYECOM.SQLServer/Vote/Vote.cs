using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 网上调查数据操作类
    /// </summary>
    public class Vote
    {
        /// <summary>
        /// 插入新调查
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns></returns>
        public int Insert(Model.VoteInfo info)
        {
            string cmdText = "Insert Into XY_Vote(Title,[Desc],UserType,StartTime,EndTime) values(@Title,@Desc,@UserType,@StartTime,@EndTime)";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@Title",info.Title),
                new SqlParameter("@Desc",info.Desc),
                new SqlParameter("@UserType",info.UserType),
                new SqlParameter("@StartTime",info.StartTime),
                new SqlParameter("@EndTime",info.EndTime),
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);
        }

        /// <summary>
        /// 更新调查信息
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns></returns>
        public int Update(Model.VoteInfo info)
        {
            string cmdText = "Update XY_Vote set Title = @Title,[Desc]=@Desc,UserType=@UserType,StartTime=@StartTime,EndTime=@EndTime where VoteId = @VoteId";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@Title",info.Title),
                new SqlParameter("@Desc",info.Desc),
                new SqlParameter("@UserType",info.UserType),
                new SqlParameter("@VoteId",info.VoteId),
                new SqlParameter("@StartTime",info.StartTime),
                new SqlParameter("@EndTime",info.EndTime),
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);
        }

        /// <summary>
        /// 获取指定Id的调查信息
        /// </summary>
        /// <param name="voteId">调查Id</param>
        /// <returns></returns>
        public Model.VoteInfo GetItem(int voteId)
        {
            string cmdText = "select * from XY_Vote where VoteId =@VoteId";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@VoteId",voteId)
            };

            Model.VoteInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.Text, cmdText, param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.VoteInfo();

                    info.VoteId = XYECOM.Core.MyConvert.GetInt32(reader["VoteId"].ToString());
                    info.Title = reader["Title"].ToString();
                    info.Desc = reader["Desc"].ToString();
                    info.UserType = reader["UserType"].ToString();
                    info.StartTime = Core.MyConvert.GetDateTime(reader["StartTime"].ToString());
                    info.EndTime = Core.MyConvert.GetDateTime(reader["EndTime"].ToString());
                }
            }

            return info;
        }

        /// <summary>
        /// 删除指定的调查
        /// </summary>
        /// <param name="voteId">调查Id</param>
        /// <returns></returns>
        public int Delete(int voteId)
        {
            string cmdText = "Delete XY_Vote where VoteId = @VoteId";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@VoteId",voteId)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);
        }
    }
}
