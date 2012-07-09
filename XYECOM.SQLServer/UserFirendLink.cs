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
    /// 用户友情链接数据处理类
    /// </summary>
    public class UserFirendLink
    {
        #region 添加友情链接
        /// <summary>
        /// 插入一条友情链接的数据
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns>影响行数</returns>
        public int Insert(XYECOM.Model.UserFirendLinkinfo info)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Url",info.Url),
                new SqlParameter("@LogoUrl",info.LogoUrl),
                new SqlParameter("@SiteName",info.SiteName),
                new SqlParameter("@UserID",info.UserID),
            };
            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertUserFriendLink", parm);
        }
        #endregion

        #region 查询友情链接

        #region 按条件查询友情链接

        /// <summary>
        /// 按条件查询友情链接数数据
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns>数据对象</returns>
        public Model.UserFirendLinkinfo GetItem(long userId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," where UserID="+userId .ToString ()),
                new SqlParameter("@strTableName","XY_UserFirendLink"),
                new SqlParameter("@strOrder","")
            };
            XYECOM.Model.UserFirendLinkinfo info = null;
            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                { 
                    info = new XYECOM.Model.UserFirendLinkinfo();
                    info.LinkId = Core.MyConvert.GetInt32(reader["LinkId"].ToString());
                    info.Url = reader["Url"].ToString();
                    info.LogoUrl = reader["LogoUrl"].ToString();
                    info.SiteName =reader["SiteName"].ToString();
                    info.UserID = Core.MyConvert.GetInt64(reader["UserID"].ToString());
                }   
            }
            return info;
        }
        #endregion

        #region 按linkID查询友情链接
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="linkid">链接记录Id</param>
        /// <returns>数据对象</returns>
        public Model.UserFirendLinkinfo GetItem(int linkid)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," where linkid="+linkid.ToString ()),
                new SqlParameter("@strTableName","XY_UserFirendLink"),
                new SqlParameter("@strOrder","")
            };
            XYECOM.Model.UserFirendLinkinfo info = null;
            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.UserFirendLinkinfo();
                    info.LinkId = Core.MyConvert.GetInt32(reader["LinkId"].ToString());
                    info.Url = reader["Url"].ToString();
                    info.LogoUrl = reader["LogoUrl"].ToString();
                    info.SiteName = reader["SiteName"].ToString();
                    info.UserID = Core.MyConvert.GetInt64(reader["UserID"].ToString());
                }
            }
            return info;
        }
        #endregion

        #region 按UserID查询友情链接
        /// <summary>
        /// 获取友情链接列表
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public DataTable GetDataTable(long userId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere","where userId=" + userId),
                new SqlParameter("@strTableName","XY_UserFirendLink"),
                new SqlParameter("@strOrder","order by linkId desc")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }
        #endregion

        #endregion

        #region 修改友情链接
        /// <summary>
        /// 更新友情链接的数据
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns></returns>
        public int Update(XYECOM.Model.UserFirendLinkinfo info)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@LinkId",info.LinkId),
                new SqlParameter ("@Url",info.Url),
                new SqlParameter ("@LogoUrl",info.LogoUrl),
                new SqlParameter ("@SiteName",info.SiteName),
                new SqlParameter ("UserID",info.UserID),
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateUserFriendLink", parm);
        }
        #endregion

        #region 删除友情链接
        /// <summary>
        /// 删除友情链接的数据
        /// </summary>
        /// <param name="LinkId">记录id字符串，多个用逗号隔开</param>
        /// <returns>影响行数</returns>
        public int Delete(string linkId)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where LinkId in ("+linkId+")"),
                new SqlParameter("@strTableName","XY_UserFirendLink")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        #endregion
    }
}
