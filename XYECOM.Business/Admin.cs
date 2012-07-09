using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// 系统管理员业务类
    /// </summary>
    public class Admin
    {
        private static readonly XYECOM.SQLServer.Admin DAL = new XYECOM.SQLServer.Admin();

        /// <summary>
        /// 添加管理员信息
        /// </summary>
        /// <param name="ea">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.AdminInfo ea)
        {
            return DAL.Insert(ea);
        }

        /// <summary>
        /// 修改管理员信息
        /// </summary>
        /// <param name="ea">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.AdminInfo ea)
        {
            return DAL.Update(ea);
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="UM_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.AdminInfo GetItem(int UM_ID)
        {
            return DAL.GetItem(UM_ID);
        }

        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns>记录集</returns>
        public DataTable GetDataTable()
        {
            return DAL.GetDataTable();
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="UM_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int UM_ID)
        {
            return DAL.Delete(UM_ID);
        }
        /// <summary>
        /// 校验用户名密码是否正确
        /// </summary>
        /// <param name="UserName">用户名称</param>
        /// <param name="Password">用户密码</param>
        /// <returns>大于零表示用户名密码是正确的</returns>
        public int isMyUser(string UserName, string Password)
        {
            return DAL.isMyUser(UserName, Password);
        }


        /// <summary>
        /// 通过用户名称获取对象
        /// </summary>
        /// <param name="username">用户名称</param>
        /// <returns>管理员实体对象</returns>
        public XYECOM.Model.AdminInfo GetItem(string username)
        {
            return DAL.GetItem(username);
        }
    }
}
