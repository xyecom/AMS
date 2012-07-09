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
    /// 管理员权限数据处理表
    /// </summary>
    public class UserPopedom
    {
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="UR_ID">管理员角色编号</param>
        /// <returns>影响行数</returns>
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
        /// 删除记录
        /// </summary>
        /// <param name="UR_ID">管理员角色编号</param>
        /// <returns>影响行数</returns>
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
        /// 判断用户是否有指定模块的权限
        /// </summary>
        /// <param name="tablename">模块标识表名称</param>
        /// <param name="UM_ID">管理员Id</param>
        /// <returns>true:有权限,false:无权限</returns>
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
