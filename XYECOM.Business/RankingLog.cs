using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// 排名日志业务类
    /// </summary>
    public class RankingLog
    {
        private XYECOM.SQLServer.RankingLog DAL = new XYECOM.SQLServer.RankingLog();
        /// <summary>
        /// 删除多条日志信息
        /// </summary>
        /// <param name="logIds">编号集合</param>
        /// <returns>影响行数</returns>
        public int Delete(string logIds)
        {
            if (String.IsNullOrEmpty(logIds)) return 0;

            logIds = logIds.Trim();

            if (logIds.Equals("")) return 0;

            return DAL.Delete(logIds);
        }
    }
}
