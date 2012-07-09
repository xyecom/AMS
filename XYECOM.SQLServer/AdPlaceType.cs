using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using XYECOM.Core.Data;
using XYECOM.Core;

namespace XYECOM.SQLServer
{

     /// <summary>
     /// 广告位类别工厂类
     /// </summary>
    public class AdPlaceType
    {
        public AdPlaceType() { }
        
        #region 添加一个广告位类别
         /// <summary>
         /// 添加广告位类别
         /// </summary>
         /// <param name="at">广告位类别实体类</param>
         /// <param name="at_id">所添加实体类的ID值</param>
         /// <returns>数字,大于0表示添加成功</returns>
        public int Insert(XYECOM.Model.AdPlaceTypeInfo at, out int at_id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@AT_ID",SqlDbType.Int),
                new SqlParameter("@AT_Name",at.AT_Name),
                new SqlParameter("@AT_PID",at.AT_PID),
                new SqlParameter("@AT_Alt",at.AT_Alt)
            };

            param[0].Direction = ParameterDirection.Output;

            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertAdPlaceType", param);

            if (param[0].Value.ToString() != null && param[0].Value.ToString() != "")
            {
                at_id = Convert.ToInt32(param[0].Value);
            }
            else
                at_id = -1;

            return rowAffected;
        }
        #endregion

        #region 修改指定广告位类别信息
         /// <summary>
         /// 修改指定广告位类别信息
         /// </summary>
         /// <param name="at">要修改的指定广告位对象</param>
        /// <returns>数字，大于或等于0表示修改成功</returns>
        public int Update(XYECOM.Model.AdPlaceTypeInfo at)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@AT_ID",at.AT_ID),
                new SqlParameter("@AT_Name",at.AT_Name),
                new SqlParameter("@AT_PID",at.AT_PID),
                new SqlParameter("@AT_Alt",at.AT_Alt)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateAdPlaceType", param);
        }
        #endregion

        #region 删除指定广告位类别信息
         /// <summary>
         /// 删除指定的广告位类别信息
         /// </summary>
         /// <param name="at_ids">要删除的广告位类别ID串</param>
         /// <returns>数字，大于或等于0表删除成功</returns>
        public int Delete(string at_ids)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere","where AT_ID in("+at_ids+")"),
                new SqlParameter("@strTableName","b_AdPlaceType")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        #endregion

        #region 判断该类别下面是否还有子类别
        /// <summary>
        /// 根据ID判断要删除的类别下是否还有子类别
        /// </summary>
        /// <param name="at_ids">指定的ID值</param>
        /// <returns>数字,大于0表示还有子类别,等于0表示无子类别</returns>
        public int GetSonType(string at_ids)
        {
            string strWhere = "where AT_PID in("+at_ids+")";
            string strTableName = "b_AdPlaceType";

            return Function.GetRows(strTableName, "AT_ID", strWhere);
        }
        #endregion

        #region 获得指定的广告位类别的DataTable
        /// <summary>
         /// 获得指定的DataTable类型的广告位类别
         /// </summary>
         /// <param name="strWhere">指定的广告位类别</param>
        /// <param name="strOrderBy">指定的广告位类别检索信息</param>
         /// <returns>DataTable类型的满足条件的广告位类别信息</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","b_AdPlaceType"),
                new SqlParameter("@strOrder",strOrderBy)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", param);
        }
        #endregion
        
        #region 依据广告位类别ID获取该广告位类别的名称
        /// <summary>
        /// 依据广告位ID获取该广告位的名称
         /// </summary>
         /// <param name="atid">广告位ID</param>
         /// <returns>该广告位ID对应的广告位名称</returns>
        public string GetAdPlaceTypeName(int atid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere","where AT_ID="+atid.ToString()),
                new SqlParameter("@strTableName","b_AdPlaceType"),
                new SqlParameter("@strOrder","")
            };
            string AdPlaceTypeName = "";
            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure,"XYP_SelectByWhere", param))
            {
                if (dr.Read())
                {
                    AdPlaceTypeName = dr["AT_Name"].ToString();
                }
            }
            return AdPlaceTypeName;
        }
        #endregion

        #region 依据广告条类别ID获取该广告条类别的名称
        /// <summary>
        /// 依据广告位ID获取该广告位的名称
        /// </summary>
        /// <param name="atid">广告位ID</param>
        /// <returns>该广告位ID对应的广告位名称</returns>
        public string GetAdPlaceTypeNames(int atid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere","where AP_ID="+atid.ToString()),
                new SqlParameter("@strTableName","b_AdPlaceInfo"),
                new SqlParameter("@strOrder","")
            };
            string AdPlaceTypeName = "";
            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure,"XYP_SelectByWhere", param))
            {
                if (dr.Read())
                {
                    AdPlaceTypeName = dr["AP_Name"].ToString();
                }
            }
            return AdPlaceTypeName;
        }
        #endregion
    }

}
