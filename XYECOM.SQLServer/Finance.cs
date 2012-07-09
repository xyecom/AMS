using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using XYECOM.Core.Data;
using System.Data;
using XYECOM.SQLServer;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// ������Ϣ���ݴ�����
    /// </summary>
    public class Finance
    {
        /// <summary>
        /// �����¼
        /// </summary>
        /// <param name="ef">���ݶ���</param>
        /// <returns>��Ӱ������</returns>
        public int Insert(XYECOM.Model.FinanceInfo ef)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@U_Name",ef.U_Name ),
                new  SqlParameter ("@UM_ID",ef.UM_ID ),
                new SqlParameter ("@M_Money",ef .M_Money ),
                new  SqlParameter ("@FT_ID",ef.FT_ID ),
                new SqlParameter ("@F_Remark",ef .F_Remark )
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertFinance", parm);
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="F_ID"></param>
        /// <param name="FT_ID"></param>
        /// <param name="M_Money"></param>
        /// <param name="U_Name"></param>
        /// <param name="F_Remark"></param>
        /// <returns></returns>
        public int Update(int F_ID ,int FT_ID, decimal M_Money,string U_Name,string F_Remark)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@F_ID",F_ID ),
                new SqlParameter ("@M_Money",M_Money ),
                new  SqlParameter ("@FT_ID",FT_ID ),
                new SqlParameter ("@U_Name",U_Name ),
                new SqlParameter ("@F_Remark",F_Remark )
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateFinance", parm);
        }

        /// <summary>
        /// ɾ����¼
        /// </summary>
        /// <param name="F_ID">��¼Id</param>
        /// <returns>��Ӱ������</returns>
        public int Delete(int F_ID)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@strwhere","where F_ID="+F_ID .ToString ()),
                new  SqlParameter ("@strTableName","b_Finance")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", parm);
        }
        /// <summary>
        /// ��ȡ������Ϣ���ݶ��´ΰ�
        /// </summary>
        /// <param name="F_ID">��¼Id</param>
        /// <returns>���ݶ���</returns>
        public XYECOM .Model .FinanceInfo  GetItem(int F_ID)
        {
            XYECOM.Model.FinanceInfo fc = null;
            SqlParameter[] Parame = new SqlParameter[]
            {
                new SqlParameter ("@strWhere","where F_ID="+F_ID .ToString ()),
                new SqlParameter ("@strTableName","XYV_Finance"),
                new SqlParameter("@strOrder","") 
            };
            using (SqlDataReader rdr = XYECOM.Core.Data.SqlHelper.ExecuteReader( CommandType.StoredProcedure, "XYP_SelectByWhere", Parame))
            {
                if (rdr.Read())
                {
                    fc = new XYECOM.Model.FinanceInfo();

                    fc.F_ID = Int64.Parse(rdr["F_ID"].ToString());
                    fc.F_Remark = rdr["F_Remark"].ToString();
                    fc.FT_ID = Int32.Parse(rdr["FT_ID"].ToString());
                    fc.M_Money = Convert.ToDecimal(rdr["M_Money"].ToString());
                    fc.U_Name = rdr["U_Name"].ToString();
                    fc.UM_ID = Int32.Parse(rdr["UM_ID"].ToString());
                }
            }
            return fc;
        }
    }
}
