using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Model;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 服务信息分类数据处理类
    /// </summary>
    public class ServiceType
    {
        /// <summary>
        /// 获取完整Id
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        private string GetFullID(long parentID)
        {
            string strFullIDs = "";

            XYECOM.Model.ServiceTypeInfo info = GetItem(parentID);

            if (info == null) return "0";

            if (info.ST_ParentID != 0)
            {
                strFullIDs = GetFullID(info.ST_ParentID) + "," + info.ST_ID.ToString() + strFullIDs;
            }
            else
            {
                strFullIDs = info.ST_ID.ToString();
            }

            return strFullIDs;
        }

        /// <summary> 
        /// 添加一条新的服务信息类别对象
        /// </summary>
        /// <param name="ct">要添加的服务信息类别对象</param>
        /// <returns>数字,大于或等于0表成功,否则表失败,-1表已有雷同类别</returns>
        public int Insert(ServiceTypeInfo info)
        {
            string fullId = Core.Utils.AppendComma(GetFullID(info.ST_ParentID));

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ST_Name",info.ST_Name),
                new SqlParameter("@ST_ParentID",info.ST_ParentID),
                new SqlParameter("@ModuleName",info.ModuleName),
                new SqlParameter("@FullId",fullId),
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertServiceType", param);
        }

        /// <summary>
        /// 更改指定的服务信息类别对象
        /// </summary>
        /// <param name="ct">要更改的服务信息类别对象</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int Update(ServiceTypeInfo info)
        {
            string fullId = Core.Utils.AppendComma(GetFullID(info.ST_ParentID));

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ST_ID",info.ST_ID),
                new SqlParameter("@ST_Name",info.ST_Name),
                new SqlParameter("@ModuleName",info.ModuleName),
                new SqlParameter("@ST_ParentID",info.ST_ParentID),
                new SqlParameter("@FullId",fullId),
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateServiceType", param);
        }

        /// <summary>
        /// 删除指定编号的服务类别
        /// </summary>
        /// <param name="ctids">要删除的服务类别编号集</param>
        /// <returns>数字,大于或等于0表成功</returns>
        public int Delete(string stids)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where ST_ID in ("+stids+")"),
                new SqlParameter("@strTableName","i_ServiceType")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// 获取指定编号的服务类别对象
        /// </summary>
        /// <param name="ctid">要获取的服务类别对象的编号</param>
        /// <returns>该编号下的服务类别对象</returns>
        public ServiceTypeInfo GetItem(Int64 stid)
        {
            ServiceTypeInfo sti = null;

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where ST_ID ="+stid.ToString()),
                new SqlParameter("@strTableName","i_ServiceType"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (dr.Read())
                    sti = new ServiceTypeInfo(
                        Convert.ToInt64(dr["ST_ID"]), 
                        dr["ST_Name"].ToString(), 
                        Convert.ToInt64(dr["ST_ParentID"]),  
                        dr["ModuleName"].ToString(),
                        dr["FullId"].ToString(),
                        Core.MyConvert.GetInt32(dr["InfoCount"].ToString())    
                        );
            }

            return sti;
        }

        /// <summary>
        /// 获取满足指定条件的服务类别对象集
        /// </summary>
        /// <param name="strWhere">指定的where条件</param>
        /// <param name="strOrder">指定的order条件</param>
        /// <returns>满足指定条件的服务类别对象集</returns>
        public DataTable GetDataTable(string strWhere, string strOrder)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","i_ServiceType"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.GetDataTable("XYP_SelectByWhere", param);
        }
        /// <summary>
        /// 判断指定的服务类别集下面是否还有子类别
        /// </summary>
        /// <param name="ctid">要判断是否还有子类别的类别编号集</param>
        /// <returns>数字,大于0表有子类,否则无子类别</returns>
        public int IsHaveSonType(string stid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where ST_ParentID in ("+stid+")"),
                new SqlParameter("@strField"," ST_ID "),
                new SqlParameter("@strTable","i_ServiceType"),
                new SqlParameter("@strCount",SqlDbType.BigInt)
            };

            param[3].Direction = ParameterDirection.Output;

            int result = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[" + "XYP_GetRecordCount" + "]", param);

            if (param[3] != null)
                result = Convert.ToInt32(param[3].Value.ToString());

            return result;
        }

        /// <summary>
        /// 根据服务信息的类别编号获取合作类别的名称
        /// </summary>
        /// <param name="ctid">要获取名称的服务类别的编号</param>
        /// <returns>该类别的名称</returns>
        public string GetServiceTypeName(Int64 stid)
        {
            ServiceTypeInfo sti = GetItem(stid);

            if (!object.Equals(null, sti))
                return sti.ST_Name;
            else
                return "";
        }
    }
}
