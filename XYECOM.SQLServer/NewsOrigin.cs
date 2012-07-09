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
    /// 资讯来源数据处理类
    /// </summary>
    public class NewsOrigin
    {
        #region 添加新闻来源
        /// <summary>
        /// 添加新闻来源信息
        /// </summary>
        /// <param name="no">要添加的新闻来源对象</param>
        /// <param name="no_id">添加成功后该新闻来源对象在表中的ID值</param>
        /// <returns>数字，大于或等于0表添加成功</returns>
        public int Insert(XYECOM.Model.NewsOriginInfo no, out int no_id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NO_ID",SqlDbType.Int),
                new SqlParameter("@NO_Name",no.NO_Name)
            };

            param[0].Direction = ParameterDirection.Output;
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertNewsOrigin", param);

            if (param[0].Value.ToString() != "" && param[0].Value.ToString() != null)
            {
                no_id = Convert.ToInt32(param[0].Value);
            }
            else
            {
                no_id = -1;
            }
            return rowAffected;
        }
        #endregion

        #region 修改指定的新闻来源
        /// <summary>
        /// 修改指定的新闻来源信息
        /// </summary>
        /// <param name="no">要修改的新闻来源信息对象</param>
        /// <returns>数字，大于或等于0表修改成功</returns>
        public int Update(XYECOM.Model.NewsOriginInfo no)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NO_ID",no.NO_ID),
                new SqlParameter("@NO_Name",no.NO_Name)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateNewsOrigin", param);
        }
        #endregion

        #region 得到满足条件的新闻来源信息DataTable列表
        /// <summary>
        /// 得到满足条件的新闻来源信息对象
        /// </summary>
        /// <param name="strWhere">指定的Where查询条件</param>
        /// <param name="strOrderBy">指定的排序条件</param>
        /// <returns>满足条件的新闻来源信息对象</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","n_NewsOrigin"),
                new SqlParameter("@strOrder",strOrderBy)
            };
            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }
        #endregion

        #region 删除指定的新闻来源信息对象
        /// <summary>
        /// 删除指定的新闻来源信息
        /// </summary>
        /// <param name="no_ids">指定的新闻来源信息对象ID值</param>
        /// <returns>数字，大于或等于0表删除成功</returns>
        public int Delete(string no_ids)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strwhere","where NO_ID in ("+no_ids+")"),
                new SqlParameter("@strTableName","n_NewsOrigin")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("ups_DeleteByWhere", param);
        }
        #endregion
    }
}
