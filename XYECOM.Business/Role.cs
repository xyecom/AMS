using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// 角色业务类
    /// </summary>
    public class Role
    {
        private static readonly XYECOM.SQLServer.Role DAL = new XYECOM.SQLServer.Role();
        
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="er">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.RoleInfo er)
        {
            return DAL.Insert(er);   
        }
        
        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="er">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.RoleInfo er)
        {
            return DAL.Update(er);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="UR_ID">角色编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int UR_ID)
        {
            return DAL.Delete(UR_ID);
        }
       
        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="UR_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.RoleInfo GetItem(int UR_ID)
        {
            return DAL.GetItem(UR_ID);
        }
        
        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns>记录集</returns>
        public DataTable GetDataTable()
        {
            return DAL.GetDataTable();
        }        
    }
}
