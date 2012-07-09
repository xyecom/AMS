using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 地方站标业务类
    /// </summary>
    public class AreaSite: DataCache
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="info">地方站标实体对象</param>
        /// <returns>返回结果(影响行数)</returns>
        public int Insert(Model.AreaSiteInfo info)
        {
            string cmdText = "Insert Into XY_AreaSite(AreaId,FlagName,IsCustomTemplate) values(@AreaId,@FlagName,@IsCustomTemplate)";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@AreaId",info.AreaId),
                new SqlParameter("@FlagName",info.FlagName),
                new SqlParameter("@IsCustomTemplate",info.IsCostomTemplate)
            };

            int i = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);

            UpdateCache();

            return i;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="info">地方站标实体对象</param>
        /// <returns>返回结果(影响行数)</returns>
        public int Update(Model.AreaSiteInfo info)
        {
            string cmdText = "Update XY_AreaSite set AreaId = @AreaId,FlagName = @FlagName,IsCustomTemplate= @IsCustomTemplate where id =@Id";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@AreaId",info.AreaId),
                new SqlParameter("@FlagName",info.FlagName),
                new SqlParameter("@IsCustomTemplate",info.IsCostomTemplate),
                new SqlParameter("@Id",info.SiteId)
            };

            int i = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);

            UpdateCache();

            return i;
        }

        /// <summary>
        /// 删除一条
        /// </summary>
        /// <param name="siteId">站点Id</param>
        /// <returns>返回结果(影响行数)</returns>
        public int Delete(int siteId)
        {
            string cmdText = "Delete XY_AreaSite where id =@Id";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@Id",siteId)
            };

            int i = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);

            UpdateCache();

            return i;
        }

        /// <summary>
        /// 根据地方站Id获取详细信息
        /// </summary>
        /// <param name="siteId">地方站Id</param>
        /// <returns>返回相应地方站实对象</returns>
        public Model.AreaSiteInfo GetItemBySiteId(int siteId)
        {
            XYECOM.Model.AreaSiteInfo info = null;

            DataTable table = GetDataTable();

            DataRow[] rows = table.Select("id =" + siteId);

            if (rows != null && rows.Length > 0)
            {
                info = new XYECOM.Model.AreaSiteInfo();

                info.SiteId = Core.MyConvert.GetInt32(rows[0]["Id"].ToString());
                info.AreaId = Core.MyConvert.GetInt32(rows[0]["AreaId"].ToString());
                info.FlagName = rows[0]["FlagName"].ToString();
                info.IsCostomTemplate = rows[0]["IsCustomTemplate"].ToString().Equals("True") ? true : false;
            }

            return info;
        }

        /// <summary>
        /// 根据地区Id获取地方站信息
        /// </summary>
        /// <param name="areaId">地区Id</param>
        /// <returns>相应地方站实体对象</returns>
        public Model.AreaSiteInfo GetItemByAreaId(int areaId)
        {
            XYECOM.Model.AreaSiteInfo info = null;

            DataTable table = GetDataTable();

            DataRow[] rows = table.Select("areaId =" + areaId);

            if (rows != null && rows.Length > 0)
            {
                info = new XYECOM.Model.AreaSiteInfo();

                info.SiteId = Core.MyConvert.GetInt32(rows[0]["Id"].ToString());
                info.AreaId = Core.MyConvert.GetInt32(rows[0]["AreaId"].ToString());
                info.FlagName = rows[0]["FlagName"].ToString();
                info.IsCostomTemplate = rows[0]["IsCustomTemplate"].ToString().Equals("True") ? true : false;
            }

            return info;
        }

        /// <summary>
        /// 根据标识名称获取地方站信息
        /// </summary>
        /// <param name="flagName">标示名称</param>
        /// <returns>地方站标实体对象</returns>
        public Model.AreaSiteInfo GetItemByFlagName(string flagName)
        {
            XYECOM.Model.AreaSiteInfo info = null;

            DataTable table = GetDataTable();

            DataRow[] rows = table.Select("flagName ='" + flagName + "'");

            if (rows != null && rows.Length > 0)
            {
                info = new XYECOM.Model.AreaSiteInfo();

                info.SiteId = Core.MyConvert.GetInt32(rows[0]["Id"].ToString());
                info.AreaId = Core.MyConvert.GetInt32(rows[0]["AreaId"].ToString());
                info.FlagName = rows[0]["FlagName"].ToString();
                info.IsCostomTemplate = rows[0]["IsCustomTemplate"].ToString().Equals("True") ? true : false;
            }

            return info;
        }

        /// <summary>
        /// 返回所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            Object obj = GetCache();

            if (obj == null) return new DataTable();

            DataTable table = (DataTable)obj;

            return table;
        }

        /// <summary>
        /// 得到Sql查询语句
        /// </summary>
        public override string SQL_Get_All
        {
            get { return "select * from xy_areasite"; }
        }
    }
}
