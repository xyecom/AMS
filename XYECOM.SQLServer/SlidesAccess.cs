//------------------------------------------------------------------------------
//
// file name：XY_SlidesAccessor.cs
// author: wangzhen
// create date：2011-6-1 17:01:53
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using XYECOM.Core.Data;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// Data accessor of SlidesAccess
    /// </summary>
    public partial class SlidesAccess
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="infoId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public XYECOM.Model.SlidesInfo GetItem(int infoId, int userId)
        {
            XYECOM.Model.SlidesInfo info = null;
            SqlParameter[] parame = new SqlParameter[]
			{
				new SqlParameter("@Id",infoId),
                new SqlParameter("@UserId",userId)
			};
            string sql = "select * from XY_Slides where Id = @Id and UserId=@UserId";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text, sql, parame))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.SlidesInfo();
                    info.Id = Core.MyConvert.GetInt32(reader["Id"].ToString());
                    info.UserId = Core.MyConvert.GetInt32(reader["UserId"].ToString());
                    info.Link = reader["Link"].ToString();
                    info.SlidesTitle = reader["SlidesTitle"].ToString();
                    info.OrderId = Core.MyConvert.GetInt32(reader["OrderId"].ToString());
                }
            }
            return info;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable SelectByUserId(int userId)
        {
            string sql = "select * from XY_Slides where UserId=" + userId;
            return SqlHelper.ExecuteTable(sql);
        }
    }
}
