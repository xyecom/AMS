using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// 用户类型业务类
    /// </summary>
    public class UserType
    {
        private static readonly XYECOM.SQLServer.UserType DAL = new XYECOM.SQLServer.UserType();

        /// <summary>
        /// 添加用户类型
        /// </summary>
        /// <param name="eut">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.UserTypeInfo eut)
        {
            return DAL.Insert(eut);
        }
        
        /// <summary>
        /// 修改用户类型信息
        /// </summary>
        /// <param name="eut">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.UserTypeInfo eut)
        {
            return DAL.Update(eut);
        }
      
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="UT_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public int Delete(long UT_ID)
        {
            return DAL.Delete(UT_ID);
        }

        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="UT_IDs">编号集合</param>
        /// <returns>影响行数</returns>
        public int Delete(string UT_IDs)
        {
            return DAL.Delete(UT_IDs);
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="UT_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.UserTypeInfo GetItem(long userTypeId)
        {
            if (userTypeId <= 0) return null;

            return DAL.GetItem(userTypeId);
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="UT_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.UserTypeInfo GetItem(string typeName)
        {
            if (string.IsNullOrEmpty(typeName)) return null;

            return DAL.GetItem(typeName);
        } 
        
        /// <summary>
        /// 获取用户类型信息
        /// </summary>
        /// <param name="UT_PID">
        /// 如果 UT_PID 大于等于 0 返回一部分类型信息
        /// 否则 返回所有类型信息
        /// </param>
        /// <returns></returns>
        public DataTable GetDataTable(long userTypeId)
        {
            return DAL.GetDataTable(userTypeId);
        }

       
    }
}
