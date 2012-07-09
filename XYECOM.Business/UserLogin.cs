using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// 会员登录日志业务类
    /// </summary>
    public class UserLogin
    {
        private static readonly XYECOM.SQLServer.UserLogin DAL = new XYECOM.SQLServer.UserLogin();

        /// <summary>
        /// 添加用户登录信息
        /// </summary>
        /// <param name="el">实体类</param>
        /// <returns>受影响的行数</returns>
        //public int InsertOrUpdate(long userId)
        //{
        //    XYECOM.Model.UserLoginInfo userLoginInfo = new XYECOM.Model.UserLoginInfo();
        //    userLoginInfo.UserId = userId;
        //    userLoginInfo.RegIP = XYECOM.Core.XYRequest.GetIP();

        //    return DAL.Insert(userLoginInfo);
        //}

        /// <summary>
        /// 添加用户登录信息
        /// </summary>
        /// <param name="el">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(long userId, string ip, string Flag)
        {
            XYECOM.Model.UserLoginInfo userLoginInfo = new XYECOM.Model.UserLoginInfo();

            if (Flag == XYECOM.Model.UserLog.Register.ToString())
            {
                userLoginInfo.UserId = userId;
                userLoginInfo.RegIP = ip;
                userLoginInfo.LastLoginIP = ip;

                userLoginInfo.LastLoginDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"); ;
                userLoginInfo.FirstLoginDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"); ;
            }
            else
            {
                userLoginInfo.UserId = userId;
                userLoginInfo.RegIP = "";
                userLoginInfo.LastLoginIP = ip;
                userLoginInfo.LastLoginDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"); ;
                userLoginInfo.FirstLoginDate = "";
            }
            return DAL.Insert(userLoginInfo);
        }

        /// <summary>
        /// 获取用户登录信息
        /// </summary>
        /// <param name="userId">用户编号Id</param>
        /// <returns>实体对象</returns>
        public Model.UserLoginInfo GetItem(long userId)
        {
            if (userId <= 0) return null;

            return DAL.GetItem(userId);
        }


        /// <summary>
        /// 获取某用户登录的所有信息
        /// </summary>
        /// <param name="U_ID">用户编号</param>
        /// <returns>记录集</returns>
        public DataTable GetDataTable(long U_ID)
        {
            return DAL.GetDataTable(U_ID);
        }

        /// <summary>
        /// 获取用户登录信息
        /// </summary>
        /// <param name="U_ID">用户编号Id</param>
        /// <param name="dt">第一次登录时间</param>
        /// <param name="IP">注册IP</param>
        /// <returns>用户登录信息</returns>
        public DataTable GetDataTable(long U_ID, string dt, string IP)
        {
            return DAL.GetDataTable(U_ID, dt, IP);
        }
        /// <summary>
        /// 获取某用户登录登陆次数[附带条件]
        /// </summary>
        /// <param name="beginDate">开始日期[可为空]</param>
        /// <param name="endDate">结束日期[可为空]</param>
        /// <param name="u_id">用户id[]</param>
        /// <returns>返回登陆次数</returns>
        public string GetUserLoginNumByDate(string beginDate, string endDate, string u_id)
        {

            string num = "[用户ID异常]";
            int uid = XYECOM.Core.MyConvert.GetInt32(u_id);
            if (uid > 0)
            {
                string strWhere = " where u_id = " + u_id;

                if (beginDate != "")
                {
                    strWhere += " and (LastLoginDate > '" + beginDate + "') ";
                }
                if (endDate != "")
                {
                    strWhere += " and (LastLoginDate < '" + XYECOM.Core.MyConvert.GetDateTime(endDate).AddDays(1) + "') ";
                }

                num = DAL.GetUserLoginNumByDate(strWhere);
            }
            return num;

        }
        /// <summary>
        /// 获取某用户登录登陆次数[附带条件]带活跃度排序
        /// </summary>
        /// <param name="strWhere">联合查询条件</param>
        /// <param name="strWhere2">最终查询条件</param>
        /// <returns></returns>
        public DataTable GetUserLoginNumsByDate(string where)
        {
            return DAL.GetUserLoginNumsByDate(where);
        }
    }
}
