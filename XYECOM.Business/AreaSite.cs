using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// 地方站标业务类
    /// </summary>
    public class AreaSite
    {
        private static readonly XYECOM.SQLServer.AreaSite DAL = new XYECOM.SQLServer.AreaSite();

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="info">地方站标实体对象</param>
        /// <returns>影响行数</returns>
        public int Insert(Model.AreaSiteInfo info)
        {
            if (info == null) return 0;

            return DAL.Insert(info);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="info">地方站标实体对象</param>
        /// <returns>影响行数</returns>
        public int Update(Model.AreaSiteInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }

        /// <summary>
        /// 删除一条
        /// </summary>
        /// <param name="siteId">站点Id</param>
        /// <returns>影响行数</returns>
        public int Delete(int siteId)
        {
            if (siteId <=0) return 0;

            return DAL.Delete(siteId);
        }

        /// <summary>
        /// 根据地方站Id获取详细信息
        /// </summary>
        /// <param name="siteId">地方站Id</param>
        /// <returns>实体对象</returns>
        public Model.AreaSiteInfo GetItemBySiteId(int siteId)
        {
            if (siteId <= 0) return null;

            return DAL.GetItemBySiteId(siteId);
        }

        /// <summary>
        /// 根据标识名称获取地方站信息
        /// </summary>
        /// <param name="flagName">标示名称</param>
        /// <returns>地方站标实体对象</returns>
        public Model.AreaSiteInfo GetItemByFlagName(string flagName)
        {
            if (string.IsNullOrEmpty(flagName)) return null;

            return DAL.GetItemByFlagName(flagName);
        }

        /// <summary>
        /// 根据地区Id获取地方站信息
        /// </summary>
        /// <param name="areaId">地区Id</param>
        /// <returns>地方站标实体对象</returns>
        public Model.AreaSiteInfo GetItemByAreaId(int areaId)
        {
            if (areaId <= 0) return null;

            return DAL.GetItemByAreaId(areaId);
        }

        /// <summary>
        /// 返回所有数据
        /// </summary>
        /// <returns>地方站标所有信心的Datable</returns>
        public DataTable GetDataTable()
        {
            return DAL.GetDataTable();
        }
    }
}
