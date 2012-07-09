using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using XYECOM.Core.Data;
using XYECOM.SQLServer;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// ����ԱȨ�����ݴ����
    /// </summary>
    public class UserPopedom
    {
        /// <summary>
        /// ��ȡ��¼
        /// </summary>
        /// <param name="UR_ID">����Ա��ɫ���</param>
        /// <returns>Ӱ������</returns>
        public DataTable GetDataTable(int UR_ID)
        {
            SqlParameter[] parm = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where UR_ID=" + UR_ID.ToString()),
                new SqlParameter("@strTableName","b_PopedomSet"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", parm);
        }

        /// <summary>
        /// ɾ����¼
        /// </summary>
        /// <param name="UR_ID">����Ա��ɫ���</param>
        /// <returns>Ӱ������</returns>
        public int Delete(int UR_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where UR_ID="+UR_ID.ToString()),
                new SqlParameter("@strTableName","b_PopedomSet")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// �ж��û��Ƿ���ָ��ģ���Ȩ��
        /// </summary>
        /// <param name="tablename">ģ���ʶ������</param>
        /// <param name="UM_ID">����ԱId</param>
        /// <returns>true:��Ȩ��,false:��Ȩ��</returns>
        public bool IsUser(string tablename, long UM_ID)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@tablename",tablename.ToString()),
                new SqlParameter("@UM_ID",UM_ID),
                new SqlParameter ("@ispopedom",SqlDbType .Bit )
            };

            parm[2].Direction = ParameterDirection.Output;

            XYECOM.Core.Data.SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "XYP_IsUser", parm);
            
            if (parm[2].Value != null && parm[2].Value.ToString().ToLower() == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
