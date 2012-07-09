using System;
using System.Collections.Generic;
using System.Text;

using XYECOM.Core.Data;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
   /// <summary>
   /// ��Ϣ������ݴ�����
   /// </summary>
    public class Auditing
    {
        /// <summary>
        /// ��������Ϣ
        /// </summary>
        /// <param name="info">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.AuditingInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@DescTabID",SqlDbType.Int),
                new SqlParameter("@DescTabName",SqlDbType.VarChar),
                new SqlParameter("@A_Reason",SqlDbType.VarChar),
                new SqlParameter("@A_Advice",SqlDbType.VarChar),
            };

            param[0].Value = info.DescTabID;
            param[1].Value = info.DescTabName;
            param[2].Value = info.A_Reason;
            param[3].Value = info.A_Advice;


            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertAuditingInfo", param);
        }

        /// <summary>
        /// �޸������Ϣ
        /// </summary>
        /// <param name="info">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.AuditingInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@DescTabID",SqlDbType.Int),
                new SqlParameter("@DescTabName",SqlDbType.VarChar),
                new SqlParameter("@A_Reason",SqlDbType.VarChar),
                new SqlParameter("@A_Advice",SqlDbType.VarChar)
            };

            param[0].Value = info.DescTabID;
            param[1].Value = info.DescTabName;
            param[2].Value = info.A_Reason;
            param[3].Value = info.A_Advice;
 
            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateAuditingInfo", param);
        }

        /// <summary>
        /// ��ȡһ����¼[�ѹ�ʱ]
        /// </summary>
        /// <param name="A_ID">��¼���</param>
        /// <returns>һ����¼</returns>
        public XYECOM.Model.AuditingInfo GetItem(int A_ID)
        {
            XYECOM.Model.AuditingInfo aut = null;
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where A_ID=" + A_ID.ToString()),
                new SqlParameter("@strTableName","pl_Auditing"),
                new SqlParameter("@strOrder","")
            };
            using (SqlDataReader rdr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (rdr.Read())
                {
                    aut = new XYECOM.Model.AuditingInfo();
                    aut.A_Advice = rdr["A_Advice"].ToString();
                    aut.A_ID = Int64.Parse(rdr["A_ID"].ToString());
                    aut.A_Reason = rdr["A_Reason"].ToString();
                    aut.DescTabID = Int64.Parse(rdr["DescTabID"].ToString());
                    aut.DescTabName = rdr["DescTabName"].ToString();
                }
            }
            return aut;
        }

        /// <summary>
        /// ��ȡָ����Ϣ�������Ϣ
        /// </summary>
        /// <param name="DescTabID">��ϢId</param>
        /// <param name="DescTabName">��Ϣ��ʶ������</param>
        /// <returns></returns>
        public XYECOM.Model.AuditingInfo GetItem(string DescTabID, string DescTabName)
        {
            XYECOM.Model.AuditingInfo aut = null;
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where DescTabID=" + DescTabID.ToString() + " and DescTabName='" + DescTabName + "' "),
                new SqlParameter("@strTableName","pl_Auditing"),
                new SqlParameter("@strOrder","")
            };
            using (SqlDataReader rdr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (rdr.Read())
                {
                    aut = new XYECOM.Model.AuditingInfo();
                    aut.A_Advice = rdr["A_Advice"].ToString();
                    aut.A_ID = Int64.Parse(rdr["A_ID"].ToString());
                    aut.A_Reason = rdr["A_Reason"].ToString();
                    aut.DescTabID = Int64.Parse(rdr["DescTabID"].ToString());
                    aut.DescTabName = rdr["DescTabName"].ToString();
                }
            }
            return aut;
        }

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        /// <param name="A_ID">��¼���</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(int A_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where A_ID="+A_ID.ToString()),
                new SqlParameter("@strTableName","pl_Auditing")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        
        #region ��ȡ��¼
        /// <summary>
        /// ��ȡ������¼
        /// </summary>
        /// <param name="DescTabID">��ϢId</param>
        /// <param name="DescTabName">��Ϣ��ʶ������</param>
        /// <returns>�����</returns>
        public DataTable GetDataTable(long DescTabID, string DescTabName)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strwhere","where DescTabID="+DescTabID.ToString()+"and DescTabName='"+DescTabName.ToString ()+"'"),
                new SqlParameter("@strtableName","pl_Auditing"),
                new SqlParameter("@strOrder"," ")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }
        #endregion

        /// <summary>
        /// �޸����״̬--����
        /// </summary>
        /// <param name="DescTabID">id</param>
        /// <param name="DescTabName">��Ϣ��ʶ������</param>
        /// <param name="AuditingState">���״̬</param>
        /// <returns>��Ӱ�������</returns>
        public int UpdatesAuditing(long DescTabID, String DescTabName, XYECOM.Model.AuditingState AuditingState)
        {
            int AuditState = 0;
            
            if (AuditingState == XYECOM.Model.AuditingState.Passed)
            {
                AuditState = 1;
            }
            
            if (AuditingState == XYECOM.Model.AuditingState.NoPass)
            {
                AuditState = 0;
            }
            
            if (AuditingState == XYECOM.Model.AuditingState.Null)
            {
                AuditState = -1;
            }

            SqlParameter[] param = new SqlParameter[]
                {
                new SqlParameter("@DescTabID",DescTabID),
                new SqlParameter("@DescTabName",DescTabName),
                new SqlParameter("@Auditingstate",AuditState)
                };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdatesAuditing", param);
        }
    }
}
