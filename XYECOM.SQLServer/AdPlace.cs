using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;
using XYECOM.Core;

namespace XYECOM.SQLServer {

	#region 广告位方法类
    /// <summary>
    /// 广告位数据处理类
    /// </summary>
	public class AdPlace
	{		
	      /// <summary>
	      /// 添加广告位
	      /// </summary>
	      /// <param name="ap">广告位属性类</param>
	      /// <returns>受影响行数</returns>
        public int Insert(XYECOM.Model.AdPlaceInfo ap)
        {
            SqlParameter[] param = new SqlParameter[] 
			{
			    new SqlParameter("@AP_Name",ap.AP_Name),
				new SqlParameter("@AP_Alt",ap.AP_Alt),
                new SqlParameter("@AT_ID",ap.AT_ID),
                new SqlParameter("@AP_IsUse",ap.AP_IsUse)
			};

            int RowAfferent = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertAdPlace", param);

            return RowAfferent;
        }
        /// <summary>
        /// 修改指定的广告位信息
        /// </summary>
        /// <param name="ap">该广告位对象</param>
        /// <returns>数字，大于或等于0表示修改成功</returns>
        public int Update(XYECOM.Model.AdPlaceInfo ap)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@AP_ID",ap.AP_ID),
                new SqlParameter("@AP_Name",ap.AP_Name),
                new SqlParameter("@AP_Alt",ap.AP_Alt),
                new SqlParameter("@AT_ID",ap.AT_ID),
                new SqlParameter("@AP_IsUse",ap.AP_IsUse)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateAdPlace", param);
        }
		  /// <summary>
		  /// 得到符合条件的广告为信息
		  /// </summary>
		  /// <param name="strWhere">特定的查找条件</param>
		  /// <param name="OrderBy">特定的排序条件</param>
		  /// <returns>DataTable类型的广告信息</returns>
		public DataTable GetDataTable(string strWhere ,string OrderBy) 
		{
			SqlParameter [] param = new SqlParameter[]
			{
				new SqlParameter("@strWhere",strWhere),
				new SqlParameter("@strTableName","b_AdPlaceInfo"),
				new SqlParameter("@strOrder",OrderBy)
			};

			return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", param);
		}
		  /// <summary>
		  /// 删除指定的广告位
		  /// </summary>
		  /// <param name="AP_ID">指定的广告位编号</param>
		  /// <returns>返回所影响的行数</returns>
		public int Delete(string  AP_ID) 
		{
			SqlParameter[] param = new SqlParameter[]
			{
                new SqlParameter("@strWhere","where AP_ID in ("+AP_ID+")"),
				new SqlParameter("@strTableName","b_AdPlaceInfo")
			};

			return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
		}
         /// <summary>
         /// 更改指定广告位的启用状态
         /// </summary>
         /// <param name="AP_ID">指定广告位的ID</param>
         /// <param name="AP_IsUse">要更改的广告位状态</param>
         /// <returns>数字，大于或等于0表更改成功</returns>
        public int UpdateForIsUse(int AP_ID, bool AP_IsUse)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@AP_ID",AP_ID),
                new SqlParameter("@AP_IsUse",AP_IsUse)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateAdPlaceForIsUse", param);
        }
	}
	#endregion
}
