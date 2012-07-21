//------------------------------------------------------------------------------
//
// file name：XY_CompanyProductTypeAccessor.cs
// author: wangzhen
// create date：2011-3-29 16:07:06
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using XYECOM.Core.Data;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// Data accessor of CompanyProductTypeAccess
    /// </summary>
    public partial class CompanyProductTypeAccess
    {
        /// <summary>
        /// 根据用户编号获取该用户自定义分类根分类（王振添加 2011-03-30） modfiy by botao at 2011-05-09 10:53
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        public DataTable GetListByUserId(long userid)
        {            
            SqlParameter[] parame = new SqlParameter[]
			{				
                new SqlParameter("@userid",userid)
			};
            string sql = "select * from XY_CompanyProductType where UserId=@userid";
            return SqlHelper.ExecuteTable(CommandType.Text, sql, parame);

        }

        /// 根据用户和产品编号获取该用户的所有自定义分类（王振添加 2011-03-30）
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Model.CompanyProductTypeInfo GetListByIdAndUserId(int id, int userid)
        {
            XYECOM.Model.CompanyProductTypeInfo info = null;
            SqlParameter[] parame = new SqlParameter[]
			{
				new SqlParameter("@Id",id),
                new SqlParameter("@userid",userid)
			};
            string sql = "select * from XY_CompanyProductType where Id = @Id and UserId=@userid";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text, sql, parame))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.CompanyProductTypeInfo();
                    info.Id = id;
                    info.PtName = reader["PtName"].ToString();
                    info.InfoCount = Core.MyConvert.GetInt32(reader["InfoCount"].ToString());
                    info.UserId = userid;
                    info.CompanyId = Core.MyConvert.GetInt32(reader["ParentId"].ToString());
                }
            }
            return info;
        }

        /// <summary>
        /// 获取某个用户的所以自定义顶级分类
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable GetRootType(int userId)
        {
            string sql = "select * from XY_CompanyProductType where (UserId=" + userId + ") and (ParentId is null or ParentId=0) order by orderid asc";
            return SqlHelper.ExecuteTable(sql);
        }
    }
}
