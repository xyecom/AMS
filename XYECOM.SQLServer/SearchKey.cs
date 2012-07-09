using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Model;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 搜索关键词数据处理类
    /// </summary>
    public class SearchKey
    {
        /// <summary>
        /// 添加新的热门搜索关键字对象
        /// </summary>
        /// <param name="si">关键字对象</param>
        /// <returns>数字,大于或等于0表成功,小于0表失败</returns>
        public int Insert(SearchKeyInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SK_Name",info.SK_Name),
                new SqlParameter("@SK_Sort",info.SK_Sort),
                new SqlParameter("@SK_Count",info.SK_Count),
                new SqlParameter("@SK_IsCommend",info.SK_IsCommend),
                new SqlParameter("@SK_IsRanking",info.SK_IsRanking),
                new SqlParameter("@SK_CustomPrice",info.SK_CustomPrice)
            };

            int row = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertSearchKey", param);

            return row;
        }

        /// <summary>
        /// 修改指定的热门关键字对象
        /// </summary>
        /// <param name="si">要修改的关键字对象</param>
        /// <returns>数字,大于或等于0表成功,小于0表失败</returns>
        public int Update(SearchKeyInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SK_ID",info.SK_ID),
                new SqlParameter("@SK_Name",info.SK_Name),
                new SqlParameter("@SK_Sort",info.SK_Sort),
                new SqlParameter("@SK_Count",info.SK_Count),
                new SqlParameter("@SK_IsCommend",info.SK_IsCommend),
                new SqlParameter("@SK_IsRanking",info.SK_IsRanking),
                new SqlParameter("@SK_CustomPrice",info.SK_CustomPrice)
            };

            int row = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateSearchKey", param);

            return row;
        }

      
        /// <summary>
        /// 删除指定编号的热门关键字
        /// </summary>
        /// <param name="siids">指定的编号</param>
        /// <returns>数字,大于或等于0表成功,小于0表失败</returns>
        public int Delete(string siids)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere","where SK_ID in ("+siids+")"),
                new SqlParameter("@strTableName","b_SearchKey")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// 获取指定关键词信息
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <returns>该编号对应的热门关键字对象</returns>
        public SearchKeyInfo GetRankingItem(string keyword)
        {
            SearchKeyInfo info = null;

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere","where SK_IsRanking='1' and SK_Name='"+keyword + "'"),
                new SqlParameter("@strTableName","b_SearchKey"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new SearchKeyInfo();

                    info.SK_ID = Core.MyConvert.GetInt64(reader["SK_ID"].ToString());
                    info.SK_Name = reader["SK_Name"].ToString();
                    info.SK_Sort = reader["SK_Sort"].ToString();
                    info.SK_Count = Core.MyConvert.GetInt64(reader["SK_Count"].ToString());
                    info.SK_IsCommend = Core.MyConvert.GetBoolean(reader["SK_IsCommend"].ToString());
                    info.SK_IsRanking = Core.MyConvert.GetBoolean(reader["SK_IsRanking"].ToString());
                    info.SK_AddTime = Core.MyConvert.GetDateTime(reader["SK_AddTime"].ToString());
                    info.SK_LastSearchTime = Core.MyConvert.GetDateTime(reader["SK_LastSearchTime"].ToString());
                    info.SK_CustomPrice = reader["SK_CustomPrice"].ToString();
                }
            }

            return info;
        }

        /// <summary>
        /// 获取指定编号的热门关键字对象
        /// </summary>
        /// <param name="keyId">指定的对象编号</param>
        /// <returns>该编号对应的热门关键字对象</returns>
        public SearchKeyInfo GetItem(long keyId)
        {
            SearchKeyInfo info = null;

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere","where SK_ID="+keyId.ToString()),
                new SqlParameter("@strTableName","b_SearchKey"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new SearchKeyInfo();

                    info.SK_ID = Core.MyConvert.GetInt64(reader["SK_ID"].ToString());
                    info.SK_Name = reader["SK_Name"].ToString();
                    info.SK_Sort = reader["SK_Sort"].ToString();
                    info.SK_Count = Core.MyConvert.GetInt64(reader["SK_Count"].ToString());
                    info.SK_IsCommend = Core.MyConvert.GetBoolean(reader["SK_IsCommend"].ToString());
                    info.SK_IsRanking = Core.MyConvert.GetBoolean(reader["SK_IsRanking"].ToString());
                    info.SK_AddTime = Core.MyConvert.GetDateTime(reader["SK_AddTime"].ToString());
                    info.SK_LastSearchTime = Core.MyConvert.GetDateTime(reader["SK_LastSearchTime"].ToString());
                    info.SK_CustomPrice = reader["SK_CustomPrice"].ToString();
                }
            }

            return info;
        }

        /// <summary>
        /// 前台搜索热词处理(如果该词存在,则加一,否则根据设置插入或略过)
        /// </summary>
        /// <param name="keyName">关键词</param>
        /// <param name="moduleName">所属模块名称</param>
        /// <param name="isInsert">如果该热词存在,在搜索次数加一并返回true,否则返回false</param>
        /// <returns></returns>
        public bool UpdateNumberOfSearches(string keyName, string moduleName,bool isInsert)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SearchKeyName",keyName),
                new SqlParameter("@SearchKeySort",moduleName),
                new SqlParameter("@IsInsert",isInsert),
            };

            int row = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_SearchSearchKey", param);

            if (row >= 0)
                return true;
            else
                return false;
        }

        public bool IsExistsOnUpdate(SearchKeyInfo info)
        {
            string sql = "select count(1) from b_SearchKey where SK_Name='{0}' and SK_Sort='{1}' and SK_ID<>{2}";
            sql = string.Format(sql, info.SK_Name, info.SK_Sort, info.SK_ID);

            object obj = XYECOM.Core.Data.SqlHelper.ExecuteScalar(sql);
            if (obj != null) 
            {
                try
                {
                    return (int.Parse(obj.ToString()) > 0);
                    
                }
                catch (Exception)
                {
                    return false;
                }
                
            }

            return false;
        }
    }
}
