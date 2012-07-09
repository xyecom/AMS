using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// ������־���ݴ�����
    /// </summary>
    public class RankingLog
    {
        /// <summary>
        /// ɾ��������־��Ϣ
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
