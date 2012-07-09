using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 快速留言消息数据处理类
    /// </summary>
    public class ExpressMessage:DataCache
    {
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响行数</returns>
        public int Insert(XYECOM.Model.ExpressMessageInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ModuleName",info.ModuleName),
                new SqlParameter("@Body",info.Body),
            };

            int rowAffected = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertExpressMessage", param);

            UpdateCache();

            return rowAffected;
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响行数</returns>
        public int Update(XYECOM.Model.ExpressMessageInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Id",info.Id),
                new SqlParameter("@ModuleName",info.ModuleName),
                new SqlParameter("@Body",info.Body)
            };

            int rowAffected = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateExpressMessage", param);

            UpdateCache();

            return rowAffected;
        }

        /// <summary>
        /// 删除记录(多条)
        /// </summary>
        /// <param name="ids">记录Id集合,以逗号隔开</param>
        /// <returns>受影响行数</returns>
        public int Delete(string ids)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere","where Id in ("+ids+")"),
                new SqlParameter("@strTableName","XY_ExpressMessage")
            };

            int result =  XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);

            UpdateCache();

            return result;
        }

        /// <summary>
        /// 获取数据对象
        /// </summary>
        /// <param name="id">记录Id</param>
        /// <returns>受影响行数</returns>
        public XYECOM.Model.ExpressMessageInfo GetItem(int id)
        {
            XYECOM.Model.ExpressMessageInfo info = null;

            Object obj= GetCache();

            if (obj != null)
            {
                DataTable table = (DataTable)obj;

                DataRow[] rows = table.Select("Id =" + id);

                if (rows != null && rows.Length > 0)
                {
                    info = new XYECOM.Model.ExpressMessageInfo();

                    info.Id = Convert.ToInt32(rows[0]["Id"].ToString());
                    info.ModuleName = rows[0]["moduleName"].ToString();
                    info.Body = rows[0]["body"].ToString();
                }
            }

            return info;
        }

        /// <summary>
        /// 获取指定模板的所有快速留言信息
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <returns>数据集合</returns>
        public List<Model.ExpressMessageInfo> GetItems(string moduleName)
        {
            List<Model.ExpressMessageInfo> infos = new List<XYECOM.Model.ExpressMessageInfo>();

            Object obj = GetCache();

            if (obj != null)
            {
                DataTable table = (DataTable)obj;

                DataRow[] rows = table.Select("moduleName='general' or moduleName='" + moduleName + "'");

                XYECOM.Model.ExpressMessageInfo info = null;

                foreach (DataRow row in rows)
                {
                    info = new XYECOM.Model.ExpressMessageInfo();

                    info.Id = Convert.ToInt32(row["Id"].ToString());
                    info.ModuleName = row["moduleName"].ToString();
                    info.Body = row["body"].ToString();

                    infos.Add(info);
                }
            }

            return infos;
        }
        /// <summary>
        /// 
        /// </summary>
        public override string SQL_Get_All
        {
            get { return "select * From XY_ExpressMessage"; }
        }
    }
}
