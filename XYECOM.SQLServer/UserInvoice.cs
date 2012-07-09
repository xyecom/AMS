using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data ;
using System.Text;
using XYECOM.Core.Data;
using XYECOM.SQLServer;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// �û����뷢Ʊ���ݴ�����
    /// </summary>
    public class UserInvoice
    {
        /// <summary>
        /// �����¼
        /// </summary>
        /// <param name="ei">ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Insert(XYECOM.Model.UserInvoiceInfo ei)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@I_Name",ei.I_Name ),
                new SqlParameter ("@I_address",ei .I_Address ),
                new SqlParameter ("@I_PostCode",ei.I_PostCode ),
                new SqlParameter ("@I_Money",ei.I_Money ),
                new SqlParameter ("@I_Title",ei.I_Title ),
                new SqlParameter ("@I_Content",ei.I_Content ),
                new SqlParameter ("@I_Product",ei .I_Product  )   ,
                new SqlParameter ("@I_IsFlag",ei .I_IsFlag ),
                new SqlParameter ("@U_ID",ei .U_ID)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertInvoice", parm);
        }

        /// <summary>
        /// ɾ����¼
        /// </summary>
        /// <param name="I_ID">��¼Id</param>
        /// <returns>Ӱ������</returns>
        public int Delete(int I_ID)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@strwhere","where I_ID="+I_ID.ToString()),
                new SqlParameter("@strTableName","u_Invoice")                           
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", parm);
        }

        //public DataTable GetDataTable()
        //{
        //    SqlParameter[] param = new SqlParameter[] 
        //    { 
        //        new SqlParameter("@strWhere",""),
        //        new SqlParameter("@strTableName","u_Invoice"),
        //        new SqlParameter("@strOrder","")
        //    };

        //    return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", param);       
        //}

        /// <summary>
        /// �ѹ�ʱ�����Ƽ�ʹ��
        /// </summary>
        /// <param name="I_ID"></param>
        /// <returns></returns>
        public XYECOM.Model.UserInvoiceInfo GetItem(int I_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where I_ID=" + I_ID.ToString()),
                new SqlParameter("@strTableName","u_Invoice"),
                new SqlParameter("@strOrder","")
            };

            XYECOM.Model.UserInvoiceInfo info = null;

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure,"XYP_SelectByWhere", param))
            {
                if (dr.Read())
                {
                    info = new XYECOM.Model.UserInvoiceInfo();

                    info.I_Address = dr["I_Address"].ToString();
                    info.I_Advice = dr["I_Advice"].ToString();
                    info.I_Content = dr["I_Content"].ToString();
                    info.I_ID = Int32.Parse(dr["I_ID"].ToString());
                    info.I_IsFlag = short.Parse(dr["I_IsFlag"].ToString());
                    info.I_Money = decimal.Parse(dr["I_Money"].ToString());
                    info.I_Name = dr["I_Name"].ToString();
                    info.I_PostCode = dr["I_PostCode"].ToString();
                    info.I_Product = dr["I_Product"].ToString();
                    info.I_Reason = dr["I_Reason"].ToString();
                    info.I_Title = dr["I_Title"].ToString();
                    info.U_ID = Int64.Parse(dr["U_ID"].ToString());
                    info.I_Addtime = DateTime.Parse(dr["I_Addtime"].ToString());
                }
            }

            return info;
        }

        /// <summary>
        /// ɾ��������뷢Ʊ��Ϣ
        /// </summary>
        /// <param name="I_ID"></param>
        /// <returns></returns>
        public int Deletes(string I_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where I_ID in ("+I_ID+")"),
                new SqlParameter("@strTableName","u_Invoice")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// ���¼�¼
        /// </summary>
        /// <param name="I_ID">��¼Id</param>
        /// <param name="I_IsFlag">��Ʊ��ʶ</param>
        /// <param name="I_Advice">����</param>
        /// <param name="I_Reason">ԭ��</param>
        /// <returns></returns>
        public int Update(int I_ID, System.Int16 I_IsFlag, string I_Advice, string I_Reason)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@I_ID",I_ID),
                new SqlParameter ("@I_IsFlag",I_IsFlag),
                new SqlParameter ("@I_Advice",I_Advice),
                new SqlParameter ("@I_Reason",I_Reason)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateInvoice", parm);
        }
    }
}
