using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 用户其他数据处理类
    /// </summary>
    public class UserData
    {
        #region IUserData 成员

        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="userdata">用户数据对象</param>
        /// <returns>影响行数</returns>
        public int Insert(XYECOM.Model.UserData userdata)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@uid",userdata.Uid),
                new SqlParameter("@companyids",userdata.Companyids)
            };
            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertUserData", parm);
        }

        /// <summary>
        /// 更新就路
        /// </summary>
        /// <param name="userdata">数据对象</param>
        /// <returns>影响行数</returns>
        public int Update(XYECOM.Model.UserData userdata)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@uid",userdata.Uid),
                new SqlParameter("@companyids",userdata.Companyids)
            };
            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateUserData", parm);
        }

        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <returns>影响行数</returns>
        public XYECOM.Model.UserData GetItem(Int64 uid)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@strwhere"," where uid="+ uid),
                new SqlParameter ("@strTableName","xy_userdata"),
                new SqlParameter ("@strOrder","")
            };

            Model.UserData info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", parm))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.UserData();

                    info.Id = XYECOM.Core.MyConvert.GetInt32(reader["id"].ToString());

                    info.Uid = XYECOM.Core.MyConvert.GetInt32(reader["uid"].ToString());

                    info.Companyids = reader["companyids"].ToString();
                }
            }
            return info;
        }

        #endregion
    } 
}
