using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;
using XYECOM.SQLServer;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// �û��ʻ����ݴ�����
    /// </summary>
    public class UserAccount
    {
        /// <summary>
        /// ɾ���˻���
        /// </summary>
        /// <param name="UGR_ID">��¼Id</param>
        /// <returns>Ӱ������</returns>
        public int DeleteAcount(int UGR_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where UGR_ID=" + UGR_ID.ToString()),
                new SqlParameter("@strTableName","u_Account"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("XYP_SelectByWhere", param);
        }

        /// <summary>
        /// ��ȡָ���û������е��˻���Ϣ
        /// </summary>
        /// <param name="U_ID">�û�id</param>
        /// <returns>��¼�����</returns>
        public DataTable GetDataTable(long U_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," where U_ID="+U_ID .ToString ()),
                new SqlParameter("@strTableName","XYV_Acount"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", param);
        }

        /// <summary>
        /// ����ָ���û����ʻ���Ϣ
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <returns></returns>
        public Model.UserAccountInfo GetItem(long userId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where U_ID=" + userId.ToString()),
                new SqlParameter("@strTableName","u_Account"),
                new SqlParameter("@strOrder","")
            };

            Model.UserAccountInfo info = null;
            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader( CommandType.StoredProcedure,"XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.UserAccountInfo();

                    info.U_ID = Core.MyConvert.GetInt64(reader["U_ID"].ToString());
                    info.UGR_ID = Core.MyConvert.GetInt32(reader["UGR_ID"].ToString());
                    info.UGR_LeftMoney = Core.MyConvert.GetDecimal(reader["UGR_LeftMoney"].ToString());
                    info.UGR_Money = Core.MyConvert.GetDecimal(reader["UGR_Money"].ToString());
                }
            }
            return info;
        }

        #region ʣ���Ǯ���û����˻�
        /// <summary>
        /// ���û��ʻ���ֵ
        /// </summary>
        /// <param name="U_ID">�û�Id</param>
        /// <param name="Money">��ֵ���</param>
        /// <returns>Ӱ������</returns>
        public int AddAccountMoney(long U_ID, decimal Money)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@U_ID", U_ID),
                new SqlParameter("@Money",Money)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_UpdateAccountMoney", param);
        }
        #endregion

        #region �۳��û��˻����
        /// <summary>
        /// �û��˻�֧���۳���Ӧ���
        /// </summary>
        /// <param name="U_ID">�û�Id</param>
        /// <param name="Money">���ѽ��</param>
        /// <returns>Ӱ������</returns>
        public int DeductAccountMoney(long U_ID, decimal Money)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@U_ID", U_ID),
                new SqlParameter("@Money",Money)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_UpdateDeductAccountMoney", param);
        }
        #endregion
    
    }
}
