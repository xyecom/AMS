using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using XYECOM.Model;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// �����˻����Ѽ�¼���ݴ�����
    /// </summary>
    public class FictitiouConsumption
    {
        /// <summary>
        /// �����������Ѽ�¼
        /// </summary>
        /// <param name="fci">��¼����</param>
        /// <returns>��Ӱ������</returns>
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
        /// ��ȡָ����ŵ��������Ѽ�¼����
        /// </summary>
        /// <param name="acid">Ҫ��ȡ���������Ѽ�¼����ı��</param>
        /// <returns>�ñ���¶�Ӧ���������ݶ���</returns>
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
        /// ��ȡ����ָ���������������Ѷ���
        /// </summary>
        /// <param name="strWhere">ָ����where����</param>
        /// <param name="Order">ָ����order����</param>
        /// <returns>����ָ���������������Ѷ���</returns>
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
