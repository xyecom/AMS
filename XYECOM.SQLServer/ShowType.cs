using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Model;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 展会分类L数据处理类
    /// </summary> 
    public class ShowType
    {
        /// <summary>
        /// 获取完整id
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        private string GetFullID(long parentID)
        {
            string strFullIDs = "";

            XYECOM.Model.ShowTypeInfo info = GetItem(parentID);

            if (info == null) return "0";

            if (info.SHT_ParentID != 0)
            {
                strFullIDs = GetFullID(info.SHT_ParentID) + "," + info.SHT_ID.ToString() + strFullIDs;
            }
            else
            {
                strFullIDs = info.SHT_ID.ToString();
            }

            return strFullIDs;
        }

        /// <summary>
        /// 添加一条新的合作信息类别对象
        /// </summary>
        /// <param name="ct">要添加的合作信息类别对象</param>
        /// <returns>数字,大于或等于0表成功,否则表失败,-1表已有雷同类别</returns>
        public int Insert(ShowTypeInfo info)
        {
            string fullId = Core.Utils.AppendComma(GetFullID(info.SHT_ParentID));

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SHT_Name",info.SHT_Name),
                new SqlParameter("@SHT_ParentID",info.SHT_ParentID),
                new SqlParameter("@FullId",fullId)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertShowType", param);
        }

        /// <summary>
        /// 更改指定的合作信息类别对象
        /// </summary>
        /// <param name="ct">要更改的合作信息类别对象</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int Update(ShowTypeInfo info)
        {
            string fullId = Core.Utils.AppendComma(GetFullID(info.SHT_ParentID));

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SHT_ID",info.SHT_ID),
                new SqlParameter("@SHT_Name",info.SHT_Name),
                new SqlParameter("@SHT_ParentID",info.SHT_ParentID),
                new SqlParameter("@FullId",fullId),
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateShowType", param);
        }

        /// <summary>
        /// 删除指定编号的合作类别
        /// </summary>
        /// <param name="ctids">要删除的合作类别编号集</param>
        /// <returns>数字,大于或等于0表成功</returns>
        public int Delete(string shtids)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where SHT_ID in ("+shtids+")"),
                new SqlParameter("@strTableName","i_ShowType")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// 获取指定编号的合作类别对象
        /// </summary>
        /// <param name="ctid">要获取的合作类别对象的编号</param>
        /// <returns>该编号下的合作类别对象</returns>
        public ShowTypeInfo GetItem(Int64 shtid)
        {
            ShowTypeInfo info = null;

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where SHT_ID ="+shtid.ToString()),
                new SqlParameter("@strTableName","i_ShowType"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (dr.Read())
                    info = new ShowTypeInfo(
                        Convert.ToInt64(dr["SHT_ID"]), 
                        dr["SHT_Name"].ToString(), 
                        Convert.ToInt64(dr["SHT_ParentID"]),
                        dr["FullId"].ToString(),
                        Core.MyConvert.GetInt32(dr["InfoCount"].ToString())
                        );
            }

            return info;
        }

        /// <summary>
        /// 获取满足指定条件的合作类别对象集
        /// </summary>
        /// <param name="strWhere">指定的where条件</param>
        /// <param name="strOrder">指定的order条件</param>
        /// <returns>满足指定条件的合作类别对象集</returns>
        public DataTable GetDataTable(string strWhere, string Order)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","i_ShowType"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.GetDataTable("XYP_SelectByWhere", param);
        }

        /// <summary>
        /// 判断指定的类别下面是否还有子类别
        /// </summary>
        /// <param name="ctid">要判断是否还有子类别的类别编号</param>
        /// <returns>数字,大于0表有子类,否则无子类别</returns>
        public int IsHaveSonType(string shtid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where SHT_ParentID in ("+shtid+")"),
                new SqlParameter("@strField"," SHT_ID "),
                new SqlParameter("@strTable","i_ShowType"),
                new SqlParameter("@strCount",SqlDbType.BigInt)
            };

            param[3].Direction = ParameterDirection.Output;

            int result = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[" + "XYP_GetRecordCount" + "]", param);

            if (param[3] != null)
                result = Convert.ToInt32(param[3].Value.ToString());

            return result;
        }

        /// <summary>
        /// 根据合作信息的类别编号获取合作类别的名称
        /// </summary>
        /// <param name="ctid">要获取名称的合作类别的编号</param>
        /// <returns>该类别的名称</returns>
        public string GetCooperateTypeName(Int64 shtid)
        {
            ShowTypeInfo shti = GetItem(shtid);

            if (!object.Equals(null, shti))
                return shti.SHT_Name;
            else
                return "";
        }
    }
}
