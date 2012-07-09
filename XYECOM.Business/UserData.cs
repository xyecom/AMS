using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// 用户资料业务类
    /// </summary>
    public class UserData
    {
        public static readonly XYECOM.SQLServer.UserData DAL = new XYECOM.SQLServer.UserData();

        /// <summary>
        /// 添加用户资料
        /// </summary>
        /// <param name="userdata">用户资料实体对象</param>
        /// <returns>影响行数</returns>
        public int Insert(XYECOM.Model.UserData userdata) { 
            if (null == userdata) return 0;
            return DAL.Insert(userdata);
        }

        /// <summary>
        /// 更新用户资料
        /// </summary>
        /// <param name="userdata">用户资料实体对象</param>
        /// <returns>影响行数</returns>
        public int Update(XYECOM.Model.UserData userdata) {
            if (null == userdata) return 0;
            return DAL.Update(userdata);
        }

        /// <summary>
        /// 获取一条用户资料
        /// </summary>
        /// <param name="uid">用户编号Id</param>
        /// <returns>实体对象</returns>
        public Model.UserData GetItem(Int64 uid) {
            if (uid <= 0) return null;
            return DAL.GetItem(uid);
        }
    }
}
 