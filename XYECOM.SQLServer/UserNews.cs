using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.Core.Data;
using XYECOM.SQLServer;
using System.Data.SqlClient;
using System.Data;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 企业动态数据处理类
    /// </summary>
    public class UserNews
    {
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="en">数据对象</param>
        /// <returns>影响行数</returns>
        public int Insert(XYECOM.Model.UserNewsInfo en)
        {
            en.AuditingState = 1;
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@U_ID",en .UserId),
                new  SqlParameter("@N_title",en .Title ),
                new SqlParameter("@N_content",en .Content), 
                new SqlParameter("@AuditingState",en.AuditingState),
                new SqlParameter("@TitleInfoId",en.TitleInfoId),
                new SqlParameter("@State",en.State),
                new SqlParameter("@TowTitle",en.TowTitle),
                new SqlParameter("@KeyWord",en.KeyWord),
                new SqlParameter("@Author",en.Author),
                new SqlParameter("@Origin",en.Origin),
                new SqlParameter("@Less",en.Less)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertUserNews", parm);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="N_ID">记录Id</param>
        /// <returns>影响行数</returns>
        public int Delete(string N_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where N_ID in (" + N_ID .ToString ()+")"),
                new SqlParameter("@strTableName","u_News")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="N_ID">记录Id</param>
        /// <returns>数据对象</returns>
        public XYECOM.Model.UserNewsInfo GetItem(int N_ID)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@strWhere","where N_ID="+N_ID .ToString ()),
                new SqlParameter ("@strTableName","u_News"),
                new SqlParameter("@strOrder","")
            };

            XYECOM.Model.UserNewsInfo userNewsInfo = null;
            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", parm))
            {
                if (dr.Read())
                {
                    userNewsInfo = new XYECOM.Model.UserNewsInfo();

                    userNewsInfo.AddTime = Core.MyConvert.GetDateTime(dr["N_AddTime"].ToString());
                    userNewsInfo.Content = dr["N_Content"].ToString();
                    userNewsInfo.NewsId = Core.MyConvert.GetInt32(dr["N_ID"].ToString());
                    userNewsInfo.Title = dr["N_title"].ToString();
                    userNewsInfo.UserId = Core.MyConvert.GetInt64(dr["U_ID"].ToString());
                    userNewsInfo.AuditingState = Core.MyConvert.GetInt32(dr["AuditingState"].ToString());
                    userNewsInfo.TitleInfoId = Core.MyConvert.GetInt32(dr["TitleInfoId"].ToString());
                    userNewsInfo.State = Core.MyConvert.GetInt32(dr["State"].ToString());
                    userNewsInfo.Author = dr["Author"].ToString();
                    userNewsInfo.KeyWord = dr["KeyWord"].ToString();
                    userNewsInfo.Origin = dr["Origin"].ToString();
                    userNewsInfo.TowTitle = dr["TowTitle"].ToString();
                    userNewsInfo.Less = dr["Less"].ToString();
                }
            }
            return userNewsInfo;
        }

        //public DataTable GetDataTable(long  U_ID)
        //{
        //    SqlParameter[] param = new SqlParameter[] 
        //    { 
        //        new SqlParameter("@strWhere"," where U_ID="+U_ID .ToString ()),
        //        new SqlParameter("@strTableName","u_News"),
        //        new SqlParameter("@strOrder","")
        //    };

        //    return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", param);
        //}

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="en">数据对象</param>
        /// <returns>影响行数</returns>
        public int Update(XYECOM.Model.UserNewsInfo en)
        {
            SqlParameter[] param = new SqlParameter[] 
            {                                                      
                new SqlParameter("@N_ID",en.NewsId ),
                new SqlParameter("@N_title",en.Title ),
                new SqlParameter("@N_content",en.Content ),
                new SqlParameter("@TitleInfoId",en.TitleInfoId ),
                new SqlParameter("@State",en.State),
                new SqlParameter("@AuditingState",en.AuditingState),
                new SqlParameter("@TowTitle",en.TowTitle),
                new SqlParameter("@KeyWord",en.KeyWord),
                new SqlParameter("@Author",en.Author),
                new SqlParameter("@Origin",en.Origin),
                new SqlParameter("@Less",en.Less)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateUserNews", param);
        }
        /// <summary>
        /// 根据用户Id和删除的用户资讯栏目Id查询
        /// </summary>
        /// <returns>影响行数</returns>
        public DataTable SelectByparam(int Id, int UserId)
        {
            string strwhere = "";
            DataTable tableInfo = new DataTable();

            strwhere = "where TitleInfoId=" + Id + " and U_ID=" + UserId;
            tableInfo = XYECOM.Core.Data.SqlHelper.SelectByWhere("u_News", strwhere, "");

            return tableInfo;
        }
    }
}
