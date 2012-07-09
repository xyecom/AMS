using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.Core.Data;
using System.Data.SqlClient;
using System.Data;
using XYECOM.SQLServer;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    public class newlist
    {
        /// <summary>
        /// 更改用户资讯信息状态（推荐，置顶） jerome
        /// </summary>
        /// <param name="lstId">用户资讯信息Ids</param>
        /// <param name="state">状态枚举</param>
        /// <returns>返回影响行数</returns>
        public int changeStateInfo(string lstId, int state)
        {
            if (string.IsNullOrEmpty(lstId)) return -1;

            string sqlfmt = string.Empty;
            string sql = string.Empty;

            sqlfmt = "update u_News set State={0}*State where N_ID in ({1})";
            sql = string.Format(sqlfmt, state, lstId);

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 更改用户资讯信息状态（取消推荐，取消置顶） jerome
        /// </summary>
        /// <param name="lstId">用户资讯信息Ids</param>
        /// <param name="state">状态枚举</param>
        /// <returns>返回影响行数</returns>
        public int unChangeStateInfo(string lstId, int state)
        {
            if (string.IsNullOrEmpty(lstId)) return -1;

            string sqlfmt = string.Empty;
            string sql = string.Empty;

            sqlfmt = "update u_News set State=State/{0} where N_ID in ({1})";
            sql = string.Format(sqlfmt, state, lstId);

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 根据用户资讯Id获取用户资讯对象 jerome
        /// </summary>
        /// <param name="lstId">用户资讯信息Id</param>
        /// <returns>对象</returns>
        public XYECOM.Model.UserNewsInfo GetUserNewsInfoById(string Id)
        {
            SqlParameter[] param = new SqlParameter[] 
                { 
                    new SqlParameter("@strWhere"," Where N_ID=" + Id),
                    new SqlParameter("@strTableName","u_News"),
                    new SqlParameter("@strOrder","")
                };

            XYECOM.Model.UserNewsInfo Newsinfo = new Model.UserNewsInfo();

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    Newsinfo.State = Core.MyConvert.GetInt32(reader["State"].ToString());
                }
            }
            return Newsinfo;
        }
    }
}
