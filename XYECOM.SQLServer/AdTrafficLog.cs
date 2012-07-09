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
    /// ���������־���ݴ�����
    /// </summary>
    public class AdTrafficLog
    {
        /// <summary>
        /// ���һ�������־��Ϣ 
        /// </summary>
        /// <param name="AdID">���Id</param>
        /// <param name="IP">������IP</param>
        /// <returns>������Ӱ������</returns>
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
        /// ɾ��ָ�������־��Ϣ
        /// </summary>
        /// <param name="adids">����Id��</param>
        /// <returns>��Ӱ������</returns>
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
