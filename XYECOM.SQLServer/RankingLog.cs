using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 排名日志数据处理类
    /// </summary>
    public class RankingLog
    {
        /// <summary>
        /// 删除多条日志信息
        /// </summary>
        /// <param name="logIds"></param>
        /// <returns></returns>
        public int Delete(string logIds)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where Logid in ( "+logIds + " )"),
                new SqlParameter("@strTableName","XY_RankingLog")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
    }
}
