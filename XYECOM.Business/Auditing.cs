using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// 审核业务类
    /// </summary>
    public class Auditing
    {
        private static readonly XYECOM.SQLServer.Auditing DAL = new XYECOM.SQLServer.Auditing();
        /// <summary>
        /// 添加审核信息
        /// </summary>
        /// <param name="ea">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.AuditingInfo info)
        {
            if (info == null) return 0;

            return DAL.Insert(info);
        }

        /// <summary>
        /// 修改审核信息
        /// </summary>
        /// <param name="ea">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.AuditingInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="A_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.AuditingInfo GetItem(int A_ID)
        {
            return DAL.GetItem (A_ID);
        }

        public XYECOM.Model.AuditingInfo GetItem(string descTabID, string descTabName)
        {
            if (String.IsNullOrEmpty(descTabID) || string.IsNullOrEmpty(descTabName)) return null;

            return DAL.GetItem(descTabID, descTabName);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="A_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int A_ID)
        {
            if (A_ID <= 0) return 0;

            return DAL.Delete(A_ID);
        }
        /// <summary>
        /// 获取多条记录
        /// </summary>
        /// <param name="Ｕ_ID">条件查询</param>
        /// <returns>多条记录</returns>
        public DataTable GetDataTable(long DescTabID, string DescTabName)
        {
            return DAL.GetDataTable(DescTabID, DescTabName);
        }


        /// <summary>
        /// 修改审核状态--多条
        /// </summary>
        /// <param name="DescTabID">id</param>
        /// <param name="DescTabName">表名</param>
        /// <param name="AuditingState">审核状态</param>
        /// <returns>是否成功</returns>
        public int UpdatesAuditing(long DescTabID, String DescTabName, XYECOM.Model.AuditingState AuditingState)
        {
            return DAL.UpdatesAuditing(DescTabID, DescTabName, AuditingState);
        }
    }
}
