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
    /// ����Ա������־���ݴ�����
    /// </summary>
    public class Log
    {
        /// <summary>
        /// �����¼
        /// </summary>
        /// <param name="el">��־����</param>
        /// <returns>��Ӱ������</returns>
        public int Insert(XYECOM.Model.LogInfo el)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@L_Title",el .L_Title ),
                new SqlParameter ("@L_Content",el .L_Content ),
                new SqlParameter ("@UM_ID",el .UM_ID ),
                new SqlParameter ("@L_MF",el .L_MF )
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertLog", parm);
        }

        /// <summary>
        /// ɾ����־��¼
        /// </summary>
        /// <param name="L_ID">��¼Id</param>
        /// <returns>��Ӱ������</returns>
        public int Delete(int L_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where L_ID="+L_ID.ToString()),
                new SqlParameter("@strTableName","b_Log")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// ��ȡ��־��Ϣ
        /// </summary>
        /// <param name="L_ID">��¼Id</param>
        /// <returns>��־���ݶ���</returns>
        public XYECOM.Model.LogInfo GetItem(int L_ID)
        {
            XYECOM.Model.LogInfo lg = null;
            SqlParameter[] Param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where L_ID=" + L_ID.ToString()),
                new SqlParameter("@strTableName","XYV_Log"),
                new SqlParameter("@strOrder","")
            };
            using (SqlDataReader rdr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", Param))
            {
                if (rdr.Read())
                {
                    lg = new XYECOM.Model.LogInfo();
                    lg.L_Content = rdr["L_Content"].ToString();
                    lg.L_ID = Int32.Parse(rdr["L_ID"].ToString());
                    lg.L_MF = rdr["L_MF"].ToString();
                    lg.L_Title = rdr["L_Title"].ToString();
                    lg.UM_ID = Int32.Parse(rdr["UM_ID"].ToString());
                    lg.L_AddTime = DateTime.Parse(rdr["L_addtime"].ToString());
                }

            }
            return lg;
        }

        /// <summary>
        /// ɾ��������־��Ϣ
        /// </summary>
        /// <param name="logIds">��¼Id��������ö��Ÿ���</param>
        /// <returns>��Ӱ������</returns>
        public int Delete(string logIds)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where L_ID in ("+logIds.ToString()+")"),
                new SqlParameter("@strTableName","b_Log")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// ɾ��ȫ����־
        /// </summary>
        /// <returns></returns>
        public int DeleteAll()
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@Where"," 1=1 "),
                new SqlParameter("@TableName","b_Log")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_CommonDelete", param);
        }
    }
}
