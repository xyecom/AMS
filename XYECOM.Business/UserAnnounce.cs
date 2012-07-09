using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// 网站公告业务类
    /// </summary>
    public class UserAnnounce
    {

        private static readonly XYECOM.SQLServer.UserAnnounce DAL = new XYECOM.SQLServer.UserAnnounce();

        #region 添加或更新一条网站公告
        /// <summary>
        /// 添加或更新一条网站公告
        /// </summary>
        /// <param name="info">网站公告实体对象</param>
        /// <returns>影响行数</returns>
        public int InsertAndUpdate(XYECOM.Model.UserAnnounceInfo info)
        {
            if (info != null) return DAL.InsertAndUpdate(info);
            else return -1;
        }
        #endregion

        #region 删除网站公告
        /// <summary>
        /// 删除网站公告
        /// </summary>
        /// <param name="UA_IDs">编号Id</param>
        /// <returns>影响行数</returns>
        public int Delete(string UA_IDs)
        {
            if (UA_IDs != null) return DAL.Delete(UA_IDs);
            else return -1;
        }
        #endregion

        #region 获取网站公告
        /// <summary>
        /// 获取网站公告
        /// </summary>
        /// <param name="UserID">用户编号id</param>
        /// <returns>网站公告实体对象</returns>
        public XYECOM.Model.UserAnnounceInfo GetItem(long UserID)
        {
            if (UserID > 0)
            {
                return DAL.GetItem(UserID);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 根据条件获得网站公告信息
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="strOrderBy">排序</param>
        /// <returns>获得网站公告信息</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            if (strWhere != null) return DAL.GetDataTable(strWhere, strOrderBy);
            else return null;
        }
        #endregion

    }
}
