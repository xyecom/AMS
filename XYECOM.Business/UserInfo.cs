using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// 用户业务类
    /// </summary>
    public class UserInfo
    {
        private static readonly XYECOM.SQLServer.UserInfo DAL = new XYECOM.SQLServer.UserInfo();

        #region 添加用户
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="eui">实体对象</param>
        /// <returns>影响行数</returns>
        public int Insert(XYECOM.Model.UserInfo eui)
        {
            return DAL.Insert(eui);
        }
        #endregion

        #region 修改用户信息
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="eui">实体对象</param>
        /// <returns>影响行数</returns>
        public int Update(XYECOM.Model.UserInfo eui)
        {
            return DAL.Update(eui);
        }
        #endregion

        #region 获取一条记录
        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="userId">用户编号Id</param>
        /// <returns>实体对象</returns>
        public XYECOM.Model.UserInfo GetItem(long userId)
        {
            if (userId <= 0) return null;

            return DAL.GetItem(userId);
        }
        #endregion

        #region  根据用户名找U_ID
        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="username">用户名称</param>
        /// <returns>实体对象</returns>
        public XYECOM.Model.UserInfo GetItem(string username)
        {
            Model.UserRegInfo regInfo = new Business.UserReg().GetItem(username);

            if (regInfo == null) return null;

            return GetItem(regInfo.UserId);
        }
        #endregion

        #region 删除用户
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="U_ID">编号Id</param>
        /// <returns>影响行数</returns>
        public int Delete(string U_ID)
        {
            return DAL.Delete(U_ID);
        }
        #endregion
                
        #region 修改用户等级ID
        /// <summary>
        /// 修改用户等级
        /// </summary>
        /// <param name="U_ID">用户编号</param>
        /// <param name="UG_ID">用户等级编号</param>
        /// <returns>影响行数</returns>
        public int UpdateUGID(long U_ID, int UG_ID)
        {
            return DAL.UpdateUGID(U_ID, UG_ID);
        }
        #endregion

        /// <summary>
        /// 获取用户发布的信息条数
        /// </summary>
        /// <param name="viewname">表或视图名称</param>
        /// <param name="useridfieldname">用户Id字段名称</param>
        /// <param name="userid">用户id</param>
        /// <param name="datefieldname">日期字段名称</param>
        /// <param name="startime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <param name="infoidfieldname">信息Id字段名称</param>
        /// <param name="modulename">模块名称</param>
        /// <returns></returns>
        public int InfoAddNum(String tablename, String useridfieldname, long userid, String datefieldname, String startime, String endtime, String infoidfieldname, String modulename)
        {
            return DAL.InfoAddNum(tablename, useridfieldname, userid, datefieldname, startime, endtime, infoidfieldname, modulename);
        }

        /// <summary>
        /// 专用方法，用于设置标签范围
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public DataTable GetUserNamesByIds(string userIds)
        {
            return DAL.GetUserNamesByIds(userIds);
        }

        /// <summary>
        /// 根据用户编号获取公司名称 王振添加（2011-04-15）
        /// </summary>
        /// <param name="uid">用户编号</param>
        /// <returns>公司名称</returns>
        public string GetCompNameByUId(int uid)
        {
            if (uid <= 0)
            {
                return string.Empty;
            }
            return DAL.GetCompNameByUId(uid);
        }

        public int UpdateBaseInfo(Model.GeneralUserInfo userinfo)
        {   
            return DAL.UpdateBaseInfo(userinfo);
        }
    }
}

