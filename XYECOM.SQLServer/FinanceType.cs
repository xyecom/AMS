using System;
using System.Collections.Generic;
using System.Text;
using System.Data  ;
using XYECOM.Core.Data;
using XYECOM.SQLServer;
using System.Data.SqlClient;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// ����������ݴ�����
    /// </summary>
    public  class FinanceType
    {
        /// <summary>
        /// �����¼
        /// </summary>
        /// <param name="et">���ݶ���</param>
        /// <returns>��Ӱ������</returns>
        public int Insert(XYECOM.Model.FinanceTypeInfo et)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new  SqlParameter ("@FT_Type",et .FT_Type )
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertFinanceType", parm);
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="et">���ݶ���</param>
        /// <returns>��Ӱ������</returns>
        public int Update(XYECOM.Model.FinanceTypeInfo et)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@FT_ID",et .FT_ID ),
                new  SqlParameter ("@FT_Type",et .FT_Type )
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateFinanceType", parm);
        }

        /// <summary>
        /// ɾ����¼
        /// </summary>
        /// <param name="FT_ID">����Id</param>
        /// <returns>��Ӱ������</returns>
        public int Delete(int FT_ID)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@strwhere"," where FT_ID="+FT_ID .ToString ()),
                new  SqlParameter ("@strTableName","b_FinanceType")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", parm);
        }

        /// <summary>
        /// ��ȡ���ݶ���
        /// </summary>
        /// <param name="FT_ID">����Id</param>
        /// <returns>���ݶ���</returns>
        public XYECOM .Model .FinanceTypeInfo  GetItem(int FT_ID)
        {
            XYECOM.Model.FinanceTypeInfo ft = null;
            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter ("@strWhere","where FT_ID="+FT_ID .ToString () ),
                new  SqlParameter ("@strTableName","b_FinanceType"),
                new  SqlParameter ("@strOrder","")
            };
            using (SqlDataReader rdr = XYECOM.Core.Data.SqlHelper.ExecuteReader( CommandType.StoredProcedure, "XYP_SelectByWhere", Param))
            {
                if (rdr.Read())
                {
                    ft = new XYECOM.Model.FinanceTypeInfo();
                    ft.FT_ID = Int32.Parse(rdr["FT_ID"].ToString());
                    ft.FT_Type = rdr["FT_Type"].ToString();
                }         
            }
            return ft;
        }

        /// <summary>
        /// ��ȡ���з�������
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new  SqlParameter ("@strWhere",""),
                new SqlParameter ("strTableName","b_FinanceType"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", parm);
        }
    }
}
