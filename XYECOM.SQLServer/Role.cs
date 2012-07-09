using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;
using XYECOM.Core;


namespace XYECOM.SQLServer
{
    /// <summary>
    /// 管理员角色数据处理类
    /// </summary>
    public class Role
    {
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="er">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.RoleInfo er)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@value",er.UR_Name),
                new SqlParameter("@TableName","b_Role")
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertRole", param);          
        }
        
        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="er">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.RoleInfo er)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@ID",er.UR_ID),
                new SqlParameter("@value",er.UR_Name),
                new SqlParameter("@TableName","b_Role")
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_Update", param);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="UR_ID">角色编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int UR_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where UR_ID="+UR_ID.ToString()),
                new SqlParameter("@strTableName","b_Role")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
       
        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="UR_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.RoleInfo GetItem(int UR_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where UR_ID=" + UR_ID.ToString()),
                new SqlParameter("@strTableName","b_Role"),
                new SqlParameter("@strOrder","")
            };

            XYECOM.Model.RoleInfo Info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader( CommandType.StoredProcedure,"XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    Info = new XYECOM.Model.RoleInfo();

                    Info.UR_ID = short.Parse(reader["UR_ID"].ToString());
                    Info.UR_Name = reader["UR_Name"].ToString();
                }
            }

            return Info;
        }
        
        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns>记录集</returns>
        public DataTable GetDataTable()
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere",""),
                new SqlParameter("@strTableName","b_Role"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", param);
        }        
    }
}
