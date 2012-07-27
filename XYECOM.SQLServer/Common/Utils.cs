using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.SQLServer
{
    /*----------------------------------------------------------------
     * Copyright (C) 2008 
     * 版权所有。 
     *
     * 文件名：XYECOM.SQLServer.Utils.cs
     * 文件功能描述：通用数据处理类
     *
     * 创建标识：TC   20080506
     *
     * 修改标识：
     * 修改描述：
     ----------------------------------------------------------------*/
    /// <summary>
    /// 数据处理层通用类
    /// </summary>
    public class Utils
    {
        #region ExecuteTable
        /// <summary>
        /// 根据条件获取对应数据
        /// 使用提示：适用于读取小量数据，大量数据请选用其他方法
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="colums">列名</param>
        /// <param name="where">条件</param>
        /// <param name="order">排序</param>
        /// <param name="topNumber">记录条数</param>
        /// <returns></returns>
        public static DataTable ExecuteTable(string tableName, string colums, string where, string order, int topNumber)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Top",topNumber),
                new SqlParameter("@Columns",colums),
                new SqlParameter("@Table",tableName),
                new SqlParameter("@Where",where),
                new SqlParameter("@Order",order)
            };

            return Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "[XYP_CommonSelect]", param);
        }

        /// <summary>
        /// 根据条件获取对应数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="colums">列名</param>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public static DataTable ExecuteTable(string tableName, string colums, string where)
        {
            return ExecuteTable(tableName, colums, where, "", 0);
        }

        #endregion


        /// <summary>
        /// 返回制定条件的数据条数
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="primaryKey">主健</param>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public static int GetTotalRecotd(string tableName, string primaryKey, string where)
        {
            string cmdText = "Select Count(" + primaryKey + ") From " + tableName;

            if (!where.Trim().Equals("")) cmdText += " where " + where;

            object result = Core.Data.SqlHelper.ExecuteScalar(cmdText);

            if (null == result) return 0;

            return XYECOM.Core.MyConvert.GetInt32(result.ToString());
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="tableName">表或视图名</param>
        /// <param name="primaryKey">主键</param>
        /// <param name="fieldNames">读取字段列表</param>
        /// <param name="orderFields">排序字段列表(支持多个,eg. field1 desc,field2 asc)</param>
        /// <param name="where">条件</param>
        /// <param name="pageSize">当前页</param>
        /// <param name="pageIndex">每页条数</param>
        /// <param name="totalRecord">总记录条数</param>
        /// <returns></returns>
        public static System.Data.DataTable GetPaginationData(string tableName, string primaryKey, string fieldNames, string orderFields, string where, int pageSize, int pageIndex, out int totalRecord)
        {
            if (string.IsNullOrEmpty(orderFields.Trim()))
            {
                orderFields = primaryKey;
            }
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@TableName",tableName),
                new SqlParameter("@PrimaryKey",primaryKey),
                new SqlParameter("@CurPage",pageIndex),
                new SqlParameter("@PageSize",pageSize),
                new SqlParameter("@Fields",fieldNames),
                new SqlParameter("@FieldOrder",orderFields),
                new SqlParameter("@Where",where),
                new SqlParameter("@TotalRecord",SqlDbType.Int),
            };

            param[7].Direction = ParameterDirection.Output;

            DataTable table = Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "[XYP_Pagination]", param);

            if (param[7].Value != null && param[7].Value.ToString() != "")
                totalRecord = Core.MyConvert.GetInt32(param[7].Value.ToString());
            else
                totalRecord = 0;

            return table;
        }

        #region 修改指定字段的值
        /// <summary>
        /// 修改指定字段的值
        /// </summary>
        /// <param name="strColumuName">列名</param>
        /// <param name="strColumuValue">值</param>
        /// <param name="strWhere">条件</param>
        /// <param name="strTableName">表名</param>
        /// <returns></returns>
        public static int UpdateColumuByWhere(string strColumuName, string strColumuValue, string strWhere, string strTableName)
        {
            int rows;
            try
            {
                SqlParameter[] parameters =	
                {
                    new SqlParameter("@TableName",strTableName),
                    new SqlParameter("@ColumuName",strColumuName),
                    new SqlParameter("@ColumuValue","'" + strColumuValue + "'"),
                    new SqlParameter("@StrWhere",strWhere)
                };


                rows = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "usp_updatecolumubywhere", parameters);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                rows = 0;
            }
            return rows;
        }

        #endregion

        /// <summary>
        /// 根据表tableName以及条件vwhere删除一条或多条记录。
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="where">条件</param>
        /// <returns>受影响行数</returns>
        public static int Delete(string tableName, string where)
        {
            System.Data.SqlClient.SqlParameter[] pars = new System.Data.SqlClient.SqlParameter[]
            {
                new SqlParameter("@tableName", tableName),
                new SqlParameter("@strWhere", where)
            };
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(System.Data.CommandType.StoredProcedure, "XYP_Delete", pars);
        }

        /// <summary>
        /// 获取类型信息的Fullid
        /// </summary>
        /// <param name="ename"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetFullid(string ename, string id)
        {
            string fullids = "";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Ename",ename),
                new SqlParameter("@id",id)
            };

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "usp_SelectGetFullid", param))
            {
                if (reader.Read())
                {
                    fullids = reader["fullid"].ToString();
                }
                return fullids;
            }

        }
    }
}
