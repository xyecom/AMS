using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// 友情链接业务类
    /// </summary>
    public class UserFirendLink
    {
        private static readonly XYECOM.SQLServer.UserFirendLink DAL = new XYECOM.SQLServer.UserFirendLink();

        #region 添加友情链接
        /// <summary>
        /// 添加友情链接
        /// </summary>
        /// <param name="efl">友情链接属性类对象</param>
        /// <returns>数字。大于等于0表示添加成功</returns>
        public int Insert(XYECOM.Model.UserFirendLinkinfo info)
        {
            if (info != null) return DAL.Insert(info);
            else return -1;               
        }
        #endregion

        #region 修改友情链接
        /// <summary>
        /// 修改友情链接
        /// </summary>
        /// <param name="efl">友情链接属性类对象</param>
        /// <returns>数字。大于等于0表示修改成功</returns>
        public int Update(XYECOM.Model.UserFirendLinkinfo info)
        {
            if (info != null) return DAL.Update(info);
            else return -1; 
        }

        #endregion

        #region 删除友情链接
        /// <summary>
        /// 删除友情链接
        /// </summary>
        /// <param name="FL_IDs">友情链接编号字符串</param>
        /// <returns>数字。大于等于0表示删除成功</returns>
        public int Delete(string UFL_IDs)
        {
            if (UFL_IDs != null) return DAL.Delete(UFL_IDs);
            else return -1; 
        }
        #endregion

        #region 获取友情链接
        /// <summary>
        /// 获取制定友情链接
        /// </summary>
        /// <param name="FL_ID">友情链接编号</param>
        /// <returns>友情链接属性类对象</returns>
        public XYECOM.Model.UserFirendLinkinfo GetItem(long UserID)
        {
            if (UserID <= 0) return null;

            return DAL.GetItem(UserID);
        }

        /// <summary>
        /// 获取一条友情链接信息
        /// </summary>
        /// <param name="linkid">友情链接编号Id</param>
        /// <returns>实体对象</returns>
        public XYECOM.Model.UserFirendLinkinfo GetItem(int linkid)
        {
            if (linkid <= 0) return null;

            return DAL.GetItem(linkid);
        }

        /// <summary>
        /// 获取某一用户友情链接信息
        /// </summary>
        /// <param name="userId">用户编号Id</param>
        /// <returns>某一用户友情链接信息</returns>
        public DataTable GetDataTable(long userId)
        {
            if (userId <= 0) return new DataTable();

            return DAL.GetDataTable(userId);
        }
        #endregion

    }
}
    


