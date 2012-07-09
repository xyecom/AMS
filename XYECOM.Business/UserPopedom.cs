using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace XYECOM.Business
{
   
    /// <summary>
    /// 管理员权限业务类
    /// </summary>
    public class UserPopedom
    {

        private static readonly XYECOM.SQLServer.UserPopedom DAL = new XYECOM.SQLServer.UserPopedom();

        /// <summary>
        /// 获取管理员权限信息
        /// </summary>
        /// <param name="UR_ID">管理员角色编号</param>
        /// <returns>管理员权限信息</returns>
        public DataTable GetDataTable(int UR_ID)
        {
            return DAL.GetDataTable(UR_ID);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="UR_ID">管理员角色编号</param>
        /// <returns>影响行数</returns>
        public int Delete(int UR_ID)
        {
            return DAL.Delete(UR_ID);
        }

        /// <summary>
        /// 判断用户是否有指定模块的权限
        /// </summary>
        /// <param name="tablename">模块标识表名称</param>
        /// <param name="UM_ID">管理员编号Id</param>
        /// <returns>true:有权限,false:无权限</returns>
        public bool IsUser(string tablename, long UM_ID)
        {
            return DAL.IsUser(tablename, UM_ID);
        }
    }
}
