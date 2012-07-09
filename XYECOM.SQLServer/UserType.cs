using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.Core.Data;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 企业分类数据处理类
    /// </summary>
    public class UserType:DataCache
    {
        /// <summary>
        /// 获取完整分类
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        private string GetFullID(long parentID)
        {
            string strFullIDs = "";

            XYECOM.Model.UserTypeInfo info = GetItem(parentID);

            if (info == null) return "0";

            if (info.UT_PID != 0)
            {
                strFullIDs = GetFullID(info.UT_PID) + "," + info.UT_ID.ToString() + strFullIDs;
            }
            else
            {
                strFullIDs = info.UT_ID.ToString();
            }

            return strFullIDs;
        }
        /// <summary>
        /// 添加用户类型
        /// </summary>
        /// <param name="eut">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.UserTypeInfo info)
        {
            string fullId = Core.Utils.AppendComma(GetFullID(info.UT_PID));

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@UT_Type",info.UT_Type),
                new SqlParameter("@UT_PID",info.UT_PID),
                new SqlParameter("@UT_FullId",fullId)
            };

            int result =  SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertUserType", param);

            UpdateCache();

            return result;
        }
        
        /// <summary>
        /// 修改用户类型信息
        /// </summary>
        /// <param name="eut">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.UserTypeInfo info)
        {
            string fullId = Core.Utils.AppendComma(GetFullID(info.UT_PID));

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@UT_Type",info.UT_Type),
                new SqlParameter("@UT_PID",info.UT_PID),
                new SqlParameter("@UT_ID",info.UT_ID),
                new SqlParameter("@UT_FullID",fullId)
            };

            int result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateUserType", param);

            UpdateCache();

            return result;
        }
      
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="UT_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public int Delete(long UT_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where UT_ID="+UT_ID.ToString()),
                new SqlParameter("@strTableName","b_UserType")
            };

            int result = XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);

            UpdateCache();

            return result;
        }

        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="UT_IDs">id字符串，多个用逗号隔开</param>
        /// <returns></returns>
        public int Delete(string UT_IDs)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where UT_ID in ("+UT_IDs.ToString() + ")"),
                new SqlParameter("@strTableName","b_UserType")
            };

            int result = XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);

            UpdateCache();

            return result;
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="UT_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.UserTypeInfo GetItem(long UT_ID)
        {
            XYECOM.Model.UserTypeInfo info = null;
            
            Object obj= GetCache();

            if (obj != null)
            {
                DataTable table = (DataTable)obj;

                DataRow[] rows = table.Select("UT_ID =" + UT_ID.ToString());

                if (rows != null && rows.Length > 0)
                {
                    info = new XYECOM.Model.UserTypeInfo();
                    info.UT_ID = Convert.ToInt64(rows[0]["UT_ID"].ToString());
                    info.UT_PID = Convert.ToInt64(rows[0]["UT_PID"].ToString());
                    info.UT_Type = rows[0]["UT_Type"].ToString();
                    info.UT_FullID = rows[0]["UT_FullID"].ToString();
                    info.UT_InfoCount = Core.MyConvert.GetInt32(rows[0]["UT_InfoCount"].ToString());
                }
            }

            return info;
        }

        /// <summary>
        /// 获取企业分类信息
        /// </summary>
        /// <param name="typeName">分类名称</param>
        /// <returns></returns>
        public XYECOM.Model.UserTypeInfo GetItem(string typeName)
        {
            XYECOM.Model.UserTypeInfo info = null;

            Object obj = GetCache();

            if (obj != null)
            {
                DataTable table = (DataTable)obj;

                DataRow[] rows = table.Select("UT_Type ='" + typeName +"'");

                if (rows != null && rows.Length > 0)
                {
                    info = new XYECOM.Model.UserTypeInfo();
                    info.UT_ID = Convert.ToInt64(rows[0]["UT_ID"].ToString());
                    info.UT_PID = Convert.ToInt64(rows[0]["UT_PID"].ToString());
                    info.UT_Type = rows[0]["UT_Type"].ToString();
                    info.UT_FullID = rows[0]["UT_FullID"].ToString();
                    info.UT_InfoCount = Core.MyConvert.GetInt32(rows[0]["UT_InfoCount"].ToString());
                }
            }

            return info;
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
            string where = "";

            if (userTypeId >= 0) where = " UT_PID=" + userTypeId.ToString();

            DataTable _table = new DataTable();
            
            Object obj= GetCache();

            if (obj != null)
            {
                DataTable table = (DataTable)obj;

                _table = table.Clone();

                DataRow[] rows = table.Select(where);

                if (rows != null && rows.Length > 0)
                {
                    foreach(DataRow row in rows)
                    {
                        _table.ImportRow(row);
                    }
                }
            }

            return _table;
        }

        public override string SQL_Get_All
        {
            get { return "select * from b_UserType"; }
        }
    }
}
