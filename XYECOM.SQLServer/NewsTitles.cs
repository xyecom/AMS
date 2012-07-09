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
    /// 资讯栏目数据处理类
    /// </summary>
    public class NewsTitles : DataCache
    {
        #region 添加新闻栏目
        /// <summary>
        ///  添加新闻栏目信息
        /// </summary>
        /// <param name="info">栏目信息对象</param>
        /// <param name="nt_id">所添加的新闻栏目的ID值</param>
        /// <returns>数字，大于或等于0表示添加成功</returns>
        public int Insert(XYECOM.Model.NewsTitlesInfo info, out int nt_id)
        {
            SqlParameter[] prarm = new SqlParameter[]
            {
                new SqlParameter("@NT_ID",SqlDbType.Int),
                new SqlParameter("@NT_Name",info.Name),
                new SqlParameter("@NT_NessName",info.ShortName),
                new SqlParameter("@NT_PID",info.ParentId),
                new SqlParameter("@NT_EnName",info.EnName),
                new SqlParameter("@NT_TempletFolder",info.TempletFolderAddress),
                new SqlParameter("@NT_TempletViewAddress",info.TempletViewAddress),
                new SqlParameter("@NT_IsShow",info.IsShow),
                new SqlParameter("@NT_IsAllowContribut",info.IsAllowContribut),
                new SqlParameter("@DomainName",info.DomainName)
            };

            prarm[0].Direction = ParameterDirection.Output;

            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertNewsTitles", prarm);

            if (prarm[0].Value.ToString() != null && prarm[0].Value.ToString() != "")
            {
                nt_id = Convert.ToInt32(prarm[0].Value);
            }
            else
            {
                nt_id = -1;
            }

            UpdateCache();

            return rowAffected;
        }
        #endregion

        #region  修改新闻栏目信息
        /// <summary>
        /// 修改指定的新闻栏目信息
        /// </summary>
        /// <param name="info">栏目信息对象</param>
        /// <returns>数字，大于或等于0表示修改成功</returns>
        public int Update(XYECOM.Model.NewsTitlesInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@NT_ID",info.Id),
                new SqlParameter("@NT_Name",info.Name),
                new SqlParameter("@NT_NessName",info.ShortName),
                new SqlParameter("@NT_PID",info.ParentId),
                new SqlParameter("@NT_EnName",info.EnName),
                new SqlParameter("@NT_TempletFolder",info.TempletFolderAddress),
                new SqlParameter("@NT_TempletViewAddress",info.TempletViewAddress),
                new SqlParameter("@NT_IsShow",info.IsShow),
                new SqlParameter("@NT_IsAllowContribut",info.IsAllowContribut),
                new SqlParameter("@DomainName",info.DomainName)
            };

            int i = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateNewsTitles", param);

            UpdateCache();

            return i;
        }
        #endregion

        #region 删除指定的新闻栏目
        /// <summary>
        /// 删除指定的新闻栏目信息
        /// </summary>
        /// <param name="nt_ids">指定的新闻栏目编号字符串</param>
        /// <returns>数字，大于或等于0表示删除成功</returns>
        public int Delete(string nt_ids)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strwhere","where NT_ID in("+nt_ids+")"),
                new SqlParameter("@strTableName","n_NewsTitleInfo")
            };

            int i = XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);

            UpdateCache();

            return i;
        }
        #endregion

        /// <summary>
        /// 获取缓存表
        /// </summary>
        /// <returns></returns>
        private DataTable GetCacheTable()
        {
            Object obj = GetCache();

            if (obj == null) return null;

            DataTable table = (DataTable)obj;

            return table;
        }

        /// <summary>
        /// 获取栏目信息
        /// </summary>
        /// <param name="id">栏目Id</param>
        /// <returns>栏目数据对象</returns>
        public Model.NewsTitlesInfo GetItem(int Id)
        {
            XYECOM.Model.NewsTitlesInfo info = null;

            DataTable table = GetCacheTable();

            if (table == null) return info;

            DataRow[] rows = table.Select("NT_ID =" + Id);

            if (rows != null && rows.Length > 0)
            {
                info = new XYECOM.Model.NewsTitlesInfo();

                info.Name = rows[0]["NT_Name"].ToString();
                info.EnName = rows[0]["NT_EnName"].ToString();
                info.Id = Id;
                info.ShortName = rows[0]["NT_NessName"].ToString();
                info.ParentId = XYECOM.Core.MyConvert.GetInt32(rows[0]["NT_Pid"].ToString());
                info.TempletFolderAddress = rows[0]["NT_TempletFolderAddress"].ToString();
                info.HTMLPage = rows[0]["NT_HTMLPage"].ToString();
                info.IsShow = Core.MyConvert.GetBoolean(rows[0]["NT_IsShow"].ToString());
                info.IsAllowContribut = Core.MyConvert.GetBoolean(rows[0]["NT_IsAllowContribut"].ToString());
                info.DomainName = rows[0]["DomainName"].ToString();
            }

            return info;
        }

        /// <summary>
        /// 通过二级域名标识获取栏目数据对象
        /// </summary>
        /// <param name="domainname">二级域名标识名称</param>
        /// <returns>栏目数据对象</returns>
        public Model.NewsTitlesInfo GetItemByDomainName(string domainname)
        {
            XYECOM.Model.NewsTitlesInfo info = null;

            DataTable table = GetCacheTable();

            if (table == null) return info;

            DataRow[] rows = table.Select("domainname='" + domainname + "'");

            if (rows != null && rows.Length > 0)
            {
                info = new XYECOM.Model.NewsTitlesInfo();

                info.Name = rows[0]["NT_Name"].ToString();
                info.EnName = rows[0]["NT_EnName"].ToString();
                info.Id = Core.MyConvert.GetInt32(rows[0]["NT_ID"].ToString());
                info.ShortName = rows[0]["NT_NessName"].ToString();
                info.ParentId = XYECOM.Core.MyConvert.GetInt32(rows[0]["NT_Pid"].ToString());
                info.TempletFolderAddress = rows[0]["NT_TempletFolderAddress"].ToString();
                info.HTMLPage = rows[0]["NT_HTMLPage"].ToString();
                info.IsShow = Core.MyConvert.GetBoolean(rows[0]["NT_IsShow"].ToString());
                info.IsAllowContribut = Core.MyConvert.GetBoolean(rows[0]["NT_IsAllowContribut"].ToString());
                info.DomainName = rows[0]["DomainName"].ToString();
            }

            return info;
        }

        /// <summary>
        /// 获取子栏目信息
        /// </summary>
        /// <param name="parentId">父栏目Id</param>
        /// <returns>子栏目集合</returns>
        public List<Model.NewsTitlesInfo> GetItems(int parentId)
        {
            List<Model.NewsTitlesInfo> infos = new List<XYECOM.Model.NewsTitlesInfo>();

            DataTable table = GetCacheTable();

            if (table == null) return infos;

            DataRow[] rows = table.Select("NT_PID=" + parentId, "NT_ID Asc");

            foreach (DataRow row in rows)
            {
                Model.NewsTitlesInfo info = new XYECOM.Model.NewsTitlesInfo();

                info.Id = XYECOM.Core.MyConvert.GetInt32(row["NT_ID"].ToString());
                info.Name = row["NT_Name"].ToString();
                info.EnName = row["NT_EnName"].ToString();
                info.ShortName = row["NT_NessName"].ToString();
                info.ParentId = XYECOM.Core.MyConvert.GetInt32(row["NT_Pid"].ToString());
                info.TempletFolderAddress = row["NT_TempletFolderAddress"].ToString();
                info.HTMLPage = row["NT_HTMLPage"].ToString();
                info.IsShow = Core.MyConvert.GetBoolean(row["NT_IsShow"].ToString());
                info.IsAllowContribut = Core.MyConvert.GetBoolean(row["NT_IsAllowContribut"].ToString());
                info.DomainName = row["DomainName"].ToString();

                infos.Add(info);
            }

            return infos;
        }

        public override string SQL_Get_All
        {
            get { return "select * from n_NewsTitleInfo"; }
        }
    }
}
