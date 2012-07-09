using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 资讯作者数据处理类
    /// </summary>
    public class NewsAuthor
    {
        #region 插入记录
         /// <summary>
        /// 插入新闻作者操作
         /// </summary>
         /// <param name="na">新闻作者对象</param>
         /// <param name="na_id">添加新闻作者后该对象的ID值</param>
         /// <returns>数字，大于或等于0表示添加成功</returns>
        public int Insert(XYECOM.Model.NewsAuthorInfo na, out int na_id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NA_ID",SqlDbType.Int),
                new SqlParameter("@NA_Name",na.NA_Name)
            };

            param[0].Direction = ParameterDirection.Output;

            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertNewsAuthor", param);

            if (param[0].Value.ToString() != null && param[0].Value.ToString() != "")
            {
                na_id = Convert.ToInt32(param[0].Value);
            }
            else
            {
                na_id = -1;
            }

            return rowAffected;
        }
        #endregion

        #region 修改新闻作者信息
        /// <summary>
        /// 修改新闻作者信息操作
        /// </summary>
        /// <param name="na">要修改的新闻信息对象</param>
        /// <returns>数字，大于或者等于0表示修改成功</returns>
        public int Update(XYECOM.Model.NewsAuthorInfo na)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NA_ID",na.NA_ID),
                new SqlParameter("@NA_Name",na.NA_Name)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateNewsAuthor", param);
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 得到满足指定条件的新闻作者DataTable
        /// </summary>
        /// <param name="strWhere">指定的查询条件</param>
        /// <param name="strOrderBy">指定的排序条件</param>
        /// <returns>满足条件的DataTable的新闻作者信息</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","n_NewsAuthor"),
                new SqlParameter("@strOrder",strOrderBy)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }
        #endregion

        #region 删除记录
        /// <summary>
        /// 删除指定的新闻作者信息
        /// </summary>
        /// <param name="na_ids">指定的新闻作者ID值</param>
        /// <returns>数字，大于或等于0表示删除成功</returns>
        public int Delete(string na_ids)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strwhere","where NA_ID in("+na_ids+")"),
                new SqlParameter("@strTableName","n_NewsAuthor")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        #endregion
    }
}
