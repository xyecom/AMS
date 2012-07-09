using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using XYECOM.Model;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 虚拟账户消费记录数据处理类
    /// </summary>
    public class FictitiouConsumption
    {
        /// <summary>
        /// 插入虚拟消费记录
        /// </summary>
        /// <param name="fci">记录对象</param>
        /// <returns>受影响行数</returns>
        public int Insert(FictitiouConsumptionInfo fci)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@U_ID",fci.UserId),
                new SqlParameter("@FC_Count",fci.Amount),
                new SqlParameter("@FC_Explain",fci.Explain)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_InsertFictitiouConsumption", param);
        }

        /// <summary>
        /// 获取指定编号的虚拟消费记录对象
        /// </summary>
        /// <param name="acid">要获取的虚拟消费记录对象的编号</param>
        /// <returns>该编号下对应的消费数据对象</returns>
        public FictitiouConsumptionInfo GetItem(Int64 fcid)
        {
            FictitiouConsumptionInfo fci = null;

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where FC_ID ="+fcid.ToString()),
                new SqlParameter("@strTableName","u_FictitiouConsumptionInfo"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader( CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (dr.Read())
                    fci = new FictitiouConsumptionInfo(dr.GetInt64(0), dr.GetInt64(1), dr.GetDecimal(2), dr.GetDateTime(3), dr.GetString(4));
            }

            return fci;
        }

        /// <summary>
        /// 获取满足指定条件的虚拟消费对象集
        /// </summary>
        /// <param name="strWhere">指定的where条件</param>
        /// <param name="Order">指定的order条件</param>
        /// <returns>满足指定条件的虚拟消费对象集</returns>
        public DataTable GetDataTable(string strWhere, string Order)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","u_FictitiouConsumptionInfo"),
                new SqlParameter("@strOrder",Order)
            };

            return XYECOM.Core.Data.SqlHelper.GetDataTable("XYP_SelectByWhere", param);
        }
    }
}
