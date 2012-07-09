using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// 企业动态业务类
    /// </summary>
    public class UserNews
    {
        private static readonly XYECOM.SQLServer.UserNews DAL = new XYECOM.SQLServer.UserNews();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="en">实体对象</param>
        /// <returns>影响行数</returns>
        public int Insert(XYECOM.Model.UserNewsInfo en)
        {
            return DAL.Insert(en);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="N_ID">编号Id</param>
        /// <returns>影响行数</returns>
        public int Delete(string N_ID)
        {
            return DAL.Delete(N_ID);
        }

        /// <summary>
        /// 获取用户资讯信息
        /// </summary>
        /// <param name="N_ID">编号Id</param>
        /// <returns>实体对象</returns>
        public XYECOM.Model.UserNewsInfo GetItem(int N_ID)
        {
            return DAL.GetItem(N_ID);
        }

        /// <summary>
        ///更新获取用户资讯信息
        /// </summary>
        /// <param name="en">实体对象</param>
        /// <returns>影响行数</returns>
        public int Update(XYECOM.Model.UserNewsInfo en)
        {
            return DAL.Update(en);
        }

        /// <summary>
        /// 获取用户资讯信息
        /// </summary>
        /// <param name="N_ID">编号Id</param>
        /// <returns>实体对象</returns>
        public bool IsDeletdTitleInfo(int ID, int UserId)
        {
            DataTable tableinfo = new DataTable();
            
            if(ID != null && UserId != null)
                tableinfo = DAL.SelectByparam(ID, UserId);
            
            if (tableinfo.Rows.Count > 0)
                return true;
            return false;
        }
    }
}
