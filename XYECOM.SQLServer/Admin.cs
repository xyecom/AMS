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
    /// 系统管理员数据处理类
    /// </summary>
    public class Admin
    {
        /// <summary>
        /// 添加管理员信息
        /// </summary>
        /// <param name="ea">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.AdminInfo ea)
        {
            SqlParameter[] param = new SqlParameter[] 
            {                                                      
                new SqlParameter("@UM_Pwd",ea.UM_Pwd),
                new SqlParameter("@UM_Name",ea.UM_Name),
                new SqlParameter("@UR_ID",ea.UR_ID)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertAdmin", param);
        }

        /// <summary>
        /// 修改管理员信息
        /// </summary>
        /// <param name="ea">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.AdminInfo ea)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@UM_ID",ea.UM_ID),         
                new SqlParameter("@UM_Pwd",ea.UM_Pwd),
                new SqlParameter("@UR_ID",ea.UR_ID)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateAdmin", param);
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="UM_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.AdminInfo GetItem(int adminId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where UM_ID=" + adminId.ToString()),
                new SqlParameter("@strTableName","b_Admin"),
                new SqlParameter("@strOrder","")
            };
            XYECOM.Model.AdminInfo info = null;
            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.AdminInfo();

                    info.UM_ID = XYECOM.Core.MyConvert.GetInt32(reader["UM_ID"].ToString());
                    info.UM_Name = reader["UM_Name"].ToString();
                    info.UM_Pwd = reader["UM_Pwd"].ToString();
                    info.UR_ID = XYECOM.Core.MyConvert.GetInt32(reader["UR_ID"].ToString());
                }
            }
            return info;
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
                new SqlParameter("@strTableName","b_Admin"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="UM_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int UM_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where UM_ID="+UM_ID.ToString()),
                new SqlParameter("@strTableName","b_Admin")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }


        /// <summary>
        /// 校验用户名密码是否正确
        /// </summary>
        /// <param name="UserName">用户名称</param>
        /// <param name="Password">用户密码</param>
        /// <returns>大于零表示用户名密码是正确的</returns>
        public int isMyUser(string UserName, string Password)
        {
            SqlParameter[] Param = new SqlParameter[] 
            { 
                new SqlParameter("@UserName",UserName),
                new SqlParameter ("@Password",Password)
            };

            object obj = XYECOM.Core.Data.SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "XYP_CheckAdmin", Param);

            if (obj == null) return 0;

            return (int)obj;
        }


        /// <summary>
        /// 通过用户获取数据对象
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>管理员数据对象</returns>
        public XYECOM.Model.AdminInfo GetItem(string userName)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," Where UM_Name='" + userName.ToString()+"'"),
                new SqlParameter("@strTableName","b_Admin"),
                new SqlParameter("@strOrder","")
            };
            XYECOM.Model.AdminInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.AdminInfo();

                    info.UM_ID = XYECOM.Core.MyConvert.GetInt32(reader["UM_ID"].ToString());
                    info.UM_Name = reader["UM_Name"].ToString();
                    info.UM_Pwd = reader["UM_Pwd"].ToString();
                    info.UR_ID = XYECOM.Core.MyConvert.GetInt32(reader["UR_ID"].ToString());
                }
            }

            return info;
        }

    }
}
