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
    /// 友情链接分类数据处理类
    /// </summary>
    public class FriendLinkSort
    {
         /// <summary>
         /// 添加友情链接类别对象
         /// </summary>
         /// <param name="fs">友情链接类别对象</param>
         /// <param name="fs_id">该友情链接类别对象的ID值</param>
         /// <returns>数字,大于0表示添加成功</returns>
        public int Insert(XYECOM.Model.FriendLinkSortInfo fs, out int fs_id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("FS_ID",SqlDbType.Int),
                new SqlParameter("FS_Name",fs.FS_Name),
                new SqlParameter("FS_PID",fs.FS_PID),
                new SqlParameter("FS_Alt",fs.FS_Alt)
            };

            param[0].Direction = ParameterDirection.Output;

            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertFriendLinkSort", param);
            if (param[0].Value.ToString() != null && param[0].Value.ToString() != "")
            {
                fs_id = Convert.ToInt32(param[0].Value);
            }
            else
            {
                fs_id = -1;
            }
            return rowAffected;
        }

         /// <summary>
         /// 修改一个友情链接类别信息
         /// </summary>
         /// <param name="fs">要修改的友情链接类别对象</param>
         /// <returns>数字,大于0表示修改成功</returns>
        public int Update(XYECOM.Model.FriendLinkSortInfo fs)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@FS_ID",fs.FS_ID),
                new SqlParameter("@FS_Name",fs.FS_Name),
                new SqlParameter("@FS_PID",fs.FS_PID),
                new SqlParameter("@FS_Alt",fs.FS_Alt)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateFriendLinkSort", param);
        }

         /// <summary>
         /// 删除指定的友情链接类别信息
         /// </summary>
         /// <param name="fs_ids">要删除的友情链接类别ID串</param>
         /// <returns>数字，大于0表删除成功</returns>
        public int Delete(string fs_ids)
        {
            SqlParameter [] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere","where FS_ID in ("+fs_ids+")"),
                new SqlParameter("@strTableName","b_FriendLinkSort")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// 获取所有友情链接分类
        /// </summary>
        /// <returns></returns>
        public List<Model.FriendLinkSortInfo> GetItems()
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",""),
                new SqlParameter("@strTableName","b_FriendLinkSort"),
                new SqlParameter("@strOrder","")
            };

            List<Model.FriendLinkSortInfo> infos = new List<XYECOM.Model.FriendLinkSortInfo>();

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    Model.FriendLinkSortInfo info = new XYECOM.Model.FriendLinkSortInfo();
                    info.FS_ID = Core.MyConvert.GetInt32(dr["FS_ID"].ToString());
                    info.FS_Name = dr["FS_Name"].ToString();
                    info.FS_Alt = dr["FS_Alt"].ToString();

                    infos.Add(info);
                }
            }

            return infos;
        }
         
        /// <summary>
        /// 得到满足条件的DataTable类型的友情链接类别信息
        /// </summary>
        /// <param name="strWhere">查找友情链接类别信息的Where条件</param>
        /// <param name="strOrderBy">查找友情链接类别信息的OrderBy条件</param>
        /// <returns>DataTable类型的满足查询条件的友情链接类别信息</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","b_FriendLinkSort"),
                new SqlParameter("@strOrder",strOrderBy)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", param);
        }

        /// <summary>
        /// 根据指定ID值判断该类别下面是个还有子类别
        /// </summary>
        /// <param name="fs_ids">指定的类别ID值</param>
        /// <returns>数字,大于0表还有子类别,否则表无子类别</returns>
        public int GetSonType(string fs_ids)
        {
            string strWhere = " FS_PID in("+fs_ids+")";
            string strTableName = " b_FriendLinkSort";

            return Utils.GetTotalRecotd(strTableName,"FS_ID",strWhere);
        }

        /// <summary>
        /// 依据友情链接类别ID获取友情链接类别的名称
         /// </summary>
         /// <param name="fsid">要获取的友情链接类别的ID</param>
         /// <returns>该友情链接类别的名称</returns>
        public string GetFriendLinkName(int fsid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere","where FS_ID="+fsid.ToString()),
                new SqlParameter("@strTableName","b_FriendLinkSort"),
                new SqlParameter("@strOrder","")
            };

            string FriendLinkName = "";
            
            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure,"XYP_SelectByWhere", param))
            {
                if (dr.Read())
                {
                    FriendLinkName = dr["FS_Name"].ToString();
                }
            }

            return FriendLinkName;
        }
    }
}
