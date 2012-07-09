using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// 招聘岗位业务逻辑类
    /// </summary>
    public class Post
    {
        private static readonly XYECOM.SQLServer.Post DAL = new XYECOM.SQLServer.Post();

        /// <summary>
        /// 添加岗位信息
        /// </summary>
        /// <param name="enp">岗位信息属性类对象</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.PostInfo enp)
        {
            return DAL.Insert(enp);
        }

        /// <summary>
        /// 修改岗位信息
        /// </summary>
        /// <param name="enp">岗位信息属性类对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.PostInfo enp)
        {
            return DAL.Update(enp);
        }

        /// <summary>
        /// 删除岗位信息
        /// </summary>
        /// <param name="P_ID">岗位编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int P_ID)
        {
            return DAL.Delete(P_ID);
        }

        /// <summary>
        /// 删除多个招聘岗位信息
        /// </summary>
        /// <param name="P_IDs">招聘岗位编号集合</param>
        /// <returns>影响行数</returns>
        public int Delete(string P_IDs)
        {
            return DAL.Delete(P_IDs);
        }

        /// <summary>
        /// 获取指定岗位信息
        /// </summary>
        /// <param name="P_ID">岗位信息编号</param>
        /// <returns>岗位信息属性类对象</returns>
        public XYECOM.Model.PostInfo GetItem(int P_ID)
        {
            return DAL.GetItem(P_ID);
            
        }

        /// <summary>
        /// 根据父级Id得到招聘岗位的信息
        /// </summary>
        /// <param name="P_ParentID">父级Id</param>
        /// <returns>招聘岗位的信息</returns>
        public DataTable GetDataTableForParentID(int P_ParentID)
        {
            return DAL.GetDataTableForParentID(P_ParentID);
        }

        /// <summary>
        /// 根据招聘岗位编号id得到招聘岗位信息
        /// </summary>
        /// <param name="P_ID">招聘岗位编号Id</param>
        /// <returns>招聘岗位信息</returns>
        public DataTable GetDataTable(int P_ID)
        {
            return DAL.GetDataTable(P_ID);
        }

        /// <summary>
        /// 根据招聘岗位编号的集合得到招聘岗位的信息
        /// </summary>
        /// <param name="P_IDs">招聘岗位编号集合</param>
        /// <returns>招聘岗位信息</returns>
        public DataTable GetDataTable(string P_IDs)
        {
            return DAL.GetDataTable(P_IDs);
        }
    }
}
