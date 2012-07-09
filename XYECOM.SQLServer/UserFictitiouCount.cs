using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using XYECOM.Core.Data;
using XYECOM.SQLServer;
using System.Data;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// �û������˻����ݴ�����
    /// </summary>
    public class UserFictitiouCount
    {
        /// <summary>
        /// �����¼
        /// </summary>
        /// <param name="efc">���ݶ���</param>
        /// <returns>Ӱ������</returns>
        public int Insert(XYECOM.Model.UserFictitiouCountInfo efc)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@U_ID",efc.U_ID ),
                new SqlParameter ("@C_SumMoney",efc.C_SumMoney ), 
                new SqlParameter ("@C_LeftMoney",efc .C_LeftMoney )
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_InsertFictitiouCount", parm);
        }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <returns>���ݶ���</returns>
        public Model.UserFictitiouCountInfo GetItem(long userId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," where U_ID="+userId .ToString ()),
                new SqlParameter("@strTableName","u_FictitiouCount"),
                new SqlParameter("@strOrder","")
            };

            XYECOM.Model.UserFictitiouCountInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.UserFictitiouCountInfo();
                    info.C_ID = Core.MyConvert.GetInt32(reader["C_ID"].ToString());
                    info.C_LeftMoney = Core.MyConvert.GetDecimal(reader["C_LeftMoney"].ToString());
                    info.C_SumMoney = Core.MyConvert.GetDecimal(reader["C_SumMoney"].ToString());
                    info.U_ID = userId;
                }
            }

            return info;
        }

        //public DataTable GetDataTable(long U_ID)
        //{
        //    SqlParameter[] param = new SqlParameter[] 
        //    { 
        //        new SqlParameter("@strWhere"," where U_ID="+U_ID .ToString ()),
        //        new SqlParameter("@strTableName","XYV_FictitiouaCount"),
        //        new SqlParameter("@strOrder","")
        //    };

        //    return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", param);
        //}

        /// <summary>
        /// �û���ֵ
        /// </summary>
        /// <param name="U_ID">�û�id</param>
        /// <param name="Money">���</param>
        /// <returns>Ӱ������</returns>
        public int UpdateUserFictitiouCount(long U_ID, decimal Money)
        {
            SqlParameter  [] parm  =new SqlParameter []
            {
                new SqlParameter ("@U_ID",U_ID ),
                new SqlParameter ("@Money",Money)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_UpdateFictitiouMoney", parm);
        }

        /// <summary>
        /// �۳��û������
        /// </summary>
        /// <param name="userId">�û�id</param>
        /// <param name="amount">���</param>
        /// <returns>Ӱ������</returns>
        public int DeductUserUUFictitiouCount(long userId, decimal amount)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@U_ID",userId ),
                new SqlParameter ("@Money",amount)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_UpdatedeDuctFictitiouMoney", parm);
        }
    }
}
