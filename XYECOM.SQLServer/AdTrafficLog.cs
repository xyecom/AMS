using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using XYECOM.Core.Data;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 公告访问日志数据处理类
    /// </summary>
    public class AdTrafficLog
    {
        /// <summary>
        /// 添加一条广告日志信息 
        /// </summary>
        /// <param name="AdID">广告Id</param>
        /// <param name="IP">访问者IP</param>
        /// <returns>插入受影响行数</returns>
        public int Insert(long AdID, string IP)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Adid",AdID),
                new SqlParameter("@IP",IP),
            };

            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertAdTrafficLog", param);

            return rowAffected;
        }
  

        /// <summary>
        /// 删除指定广告日志信息
        /// </summary>
        /// <param name="adids">公告Id集</param>
        /// <returns>受影响行数</returns>
        public int DeleteByids(string adids)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere","where adid in ("+adids+")"),
                new SqlParameter("@strTableName","XY_AdTrafficLog")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

    }
}
