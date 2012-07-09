using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.SQLServer
{
    public class UserPublicAccess
    {
        /// <summary>
        /// 根据用户编号获取实体信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public XYECOM.Model.UserPublic GetItem(int userId)
        {
            XYECOM.Model.UserPublic userpub = null;
            string sql = "select * from u_user where u_id = "+userId+"";
            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                if (dr.Read())
                {
                    userpub = new Model.UserPublic();
                    userpub.GradeId = Core.MyConvert.GetInt32(dr["UG_ID"].ToString());
                    userpub.AccountId = Core.MyConvert.GetInt32(dr["AccountId"].ToString());
                }
            }
            return userpub;
        }
    }
}
