using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using XYECOM.Model;
using XYECOM.Core.Data;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 资讯评论数据处理类
    /// </summary>
    public class NewsDiscuss
    {
        #region 添加新评论
        /// <summary>
        /// 添加新的新闻评论
        /// </summary>
        /// <param name="nd">要添加的评论对象</param>
        /// <param name="ndid">该评论添加后的编号</param>
        /// <returns>数字,大于或等于0表添加成功,否则添加失败.</returns>
        public int Insert(NewsDiscussInfo nd)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@U_ID",nd.U_ID),
                new SqlParameter("@U_Name",nd.U_Name),
                new SqlParameter("@NS_ID",nd.NS_ID),
                new SqlParameter("@ND_Content",nd.ND_Content),
                new SqlParameter("@ND_IsShow",nd.ND_IsShow),
                new SqlParameter("@IPAddress",nd.IpAddress),
                new SqlParameter("@IPIsShow",nd.IpIsShow)
            };

            int rowAffected = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertNewsDiscuss", param);

            return rowAffected;
        }
        #endregion

        #region 修改新闻评论
        /// <summary>
        /// 修改新闻评论对象
        /// </summary>
        /// <param name="nd">要修改的新闻评论对象</param>
        /// <returns>数字,大于或等于0表修改成功,否则失败</returns>
        public int Update(NewsDiscussInfo nd)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ND_ID",nd.ND_ID),
                new SqlParameter("@U_ID",nd.U_ID),
                new SqlParameter("@U_Name",nd.U_Name),
                new SqlParameter("@NS_ID",nd.NS_ID),
                new SqlParameter("@NS_Content",nd.ND_Content),
                new SqlParameter("@ND_AddTime",nd.ND_AddTime),
                new SqlParameter("@ND_IsShow",nd.ND_IsShow),
                new SqlParameter("@IPAddress",nd.IpAddress),
                new SqlParameter("@IPIsShow",nd.IpIsShow)
            };

            int rowAffected = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateNewsDiscuss", param);
            return rowAffected;
        }
        #endregion

        #region 获取指定条件的新闻评论的DataTable
        /// <summary>
        /// 获取指定条件的新闻评论的DataTable
        /// </summary>
        /// <param name="strWhere">指定的Where条件</param>
        /// <param name="strOrderBy">指定的OrderBy条件</param>
        /// <returns>满足条件的新闻评论的DataTable</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","n_NewsDiscuss"),
                new SqlParameter("@strOrder",strOrderBy)
            };

            return XYECOM.Core.Data.SqlHelper.GetDataTable("XYP_SelectByWhere", param);
        }
        #endregion

        #region 获取指定编号的评论对象
        /// <summary>
        /// 获取指定编号的评论对象
        /// </summary>
        /// <param name="ndid">指定的评论编号</param>
        /// <returns>该编号的评论对象</returns>
        public NewsDiscussInfo GetItem(Int64 ndid)
        {
            NewsDiscussInfo newsdiscuss = null;

            SqlParameter [] parm = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," Where ND_ID="+ndid.ToString()),
                new SqlParameter("@strTableName","n_NewsDiscuss"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", parm))
            {
                if (rdr.Read())
                    newsdiscuss = new NewsDiscussInfo(Convert.ToInt64(rdr["ND_ID"]),
                                                      Convert.ToInt64(rdr["U_ID"]),
                                                      rdr["U_Name"].ToString(),
                                                      Convert.ToInt64(rdr["NS_ID"]),
                                                      rdr["ND_Content"].ToString(),
                                                      Convert.ToDateTime(rdr["ND_AddTime"]),
                                                      Convert.ToBoolean(rdr["ND_IsShow"]),
                                                      rdr["IPAddress"].ToString(),
                                                      Convert.ToBoolean(rdr["IPIsShow"]));
            }

            return newsdiscuss;
        }
        #endregion

        #region 删除指定编号的新闻评论
        /// <summary>
        /// 删除指定编号的新闻评论
        /// </summary>
        /// <param name="ndids">要删除的新闻评论的编号</param>
        /// <returns>数字,大于等于0表删除成功,否则删除失败.</returns>
        public int Delete(string ndids)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@strWhere","where ND_ID in ("+ndids+")"),
                new SqlParameter("@strTableName","n_NewsDiscuss")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        #endregion

        #region 更改评论是否显示
        /// <summary>
        /// 更改评论显示状态
        /// </summary>
        /// <param name="ndid">要更改的评论编号</param>
        /// <param name="IsShow">要更改的显示状态</param>
        /// <returns>数字,大于等于0表更改成功,否则更改失败.</returns>
        public int SetIsShow(Int64 ndid, bool IsShow)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ND_ID",ndid),
                new SqlParameter("@ND_IsShow",IsShow)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateNewsDiscussIsShow", param);
        }
        #endregion

        #region 获取前n条新闻评论
        /// <summary>
        /// 获取前n条新闻评论
        /// </summary>
        /// <param name="strWhere">指定的where条件</param>
        /// <param name="strOrderBy">指定的排序条件</param>
        /// <param name="strTableName">指定的数据表名称</param>
        /// <param name="strColumuName">指定的字段</param>
        /// <param name="TopNum">要获取的前n条数目</param>
        /// <returns>满足条件的DataTable类型的记录</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy, string strColumuName, int TopNum)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strOrder",strOrderBy),
                new SqlParameter("@strTableName"," XYV_NewsDiscuss "),
                new SqlParameter("@strColumuName",strColumuName),
                new SqlParameter("@strTopNum",TopNum)
            };

            return XYECOM.Core.Data.SqlHelper.GetDataTable("XYP_GetTopByWhere", param);
        }
        #endregion
    }
}
