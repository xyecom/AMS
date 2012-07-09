using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Model;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 招商加盟分类数据处理类
    /// </summary>
    public class InviteBusinessType
    {
        /// <summary>
        /// 获取完整Id
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        private string GetFullID(long parentID)
        {
            string strFullIDs = "";

            XYECOM.Model.InviteBusinessTypeInfo info = GetItem(parentID);

            if (info == null) return "0";

            if (info.IT_ParentID != 0)
            {
                strFullIDs = GetFullID(info.IT_ParentID) + "," + info.IT_ID.ToString() + strFullIDs;
            }
            else
            {
                strFullIDs = info.IT_ID.ToString();
            }

            return strFullIDs;
        }

        /// <summary> 
        /// 添加一条新的招商代理类别对象
        /// </summary>
        /// <param name="ct">要添加的招商代理类别对象</param>
        /// <returns>数字,大于或等于0表成功,否则表失败,-1表已有雷同类别</returns>
        public int Insert(InviteBusinessTypeInfo info)
        {
            string fullId = Core.Utils.AppendComma(GetFullID(info.IT_ParentID));

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@IT_Name",info.IT_Name),
                new SqlParameter("@IT_ParentID",info.IT_ParentID),
                new SqlParameter("@ModuleName",info.ModuleName),
                new SqlParameter("@FullId",fullId)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertInviteBusinessType", param);
        }

        /// <summary>
        /// 更改指定的招商代理类别对象
        /// </summary>
        /// <param name="ct">要更改的招商代理类别对象</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int Update(InviteBusinessTypeInfo info)
        {
            string fullId = Core.Utils.AppendComma(GetFullID(info.IT_ParentID));

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@IT_ID",info.IT_ID),
                new SqlParameter("@IT_Name",info.IT_Name),
                new SqlParameter("@ModuleName",info.ModuleName),
                new SqlParameter("@IT_ParentID",info.IT_ParentID),
                new SqlParameter("@FullId",fullId),
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateInviteBusinessType", param);
        }

        /// <summary>
        /// 删除指定编号的招商代理类别
        /// </summary>
        /// <param name="ctids">要删除的招商代理类别编号集</param>
        /// <returns>数字,大于或等于0表成功</returns>
        public int Delete(string itids)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where IT_ID in ("+itids+")"),
                new SqlParameter("@strTableName","i_InviteBusinessType")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// 获取指定编号的招商代理类别对象
        /// </summary>
        /// <param name="infoid">要获取的招商代理类别对象的编号</param>
        /// <returns>该编号下的招商代理类别对象</returns>
        public InviteBusinessTypeInfo GetItem(long infoid)
        {
            InviteBusinessTypeInfo info = null;
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where IT_ID ="+infoid.ToString()),
                new SqlParameter("@strTableName","i_InviteBusinessType"),
                new SqlParameter("@strOrder","")
            };
            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (dr.Read())
                    info = new InviteBusinessTypeInfo(Convert.ToInt64(dr["IT_ID"]), dr["IT_Name"].ToString(), Convert.ToInt64(dr["IT_ParentID"]), dr["ModuleName"].ToString(), dr["FullId"].ToString(), Core.MyConvert.GetInt32(dr["InfoCount"].ToString()));
            }

            return info;
        }

        /// <summary>
        /// 获取满足指定条件的招商代理类别对象集
        /// </summary>
        /// <param name="strWhere">指定的where条件</param>
        /// <param name="strOrder">指定的order条件</param>
        /// <returns>满足指定条件的招商代理类别对象集</returns>
        public DataTable GetDataTable(string strWhere, string strOrder)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","i_InviteBusinessType"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.GetDataTable("XYP_SelectByWhere", param);
        }

        /// <summary>
        /// 判断指定的类别集下面是否还有子类别
        /// </summary>
        /// <param name="infoId">要判断是否还有子类别的类别编号集</param>
        /// <returns>数字,大于0表有子类,否则无子类别</returns>
        public int IsHaveSonType(string infoId)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where IT_ParentID in ("+infoId+")"),
                new SqlParameter("@strField"," IT_ID "),
                new SqlParameter("@strTable","i_InviteBusinessType"),
                new SqlParameter("@strCount",SqlDbType.BigInt)
            };

            param[3].Direction = ParameterDirection.Output;
            int result = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[" + "XYP_GetRecordCount" + "]", param);

            if (param[3] != null)
                result = Convert.ToInt32(param[3].Value.ToString());

            return result;
        }

        /// <summary>
        /// 根据招商代理的类别编号获取合作类别的名称
        /// </summary>
        /// <param name="infoId">要获取名称的招商代理类别的编号</param>
        /// <returns>该类别的名称</returns>
        public string GetInviteBusinessTypeName(long infoId)
        {
            InviteBusinessTypeInfo ibt = GetItem(infoId);

            if (!object.Equals(null, ibt))
                return ibt.IT_Name;
            else
                return "";
        }
    }
}
