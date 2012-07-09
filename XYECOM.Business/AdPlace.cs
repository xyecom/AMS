using System;
using System.Collections.Generic;
using System.Text;

using System.Data;


namespace XYECOM.Business {
    
    /// <summary>
    /// 广告位业务类
    /// </summary>
	public class AdPlace
	{
        private static readonly XYECOM.SQLServer.AdPlace DAL = new XYECOM.SQLServer.AdPlace();
		  /// <summary>
		  /// 添加广告位
		  /// </summary>
		  /// <param name="ap">广告位属性类</param>
		  /// <returns>受影响行数</returns>
        public int Insert(XYECOM.Model.AdPlaceInfo ap)
        {
            return DAL.Insert(ap);
        }
        /// <summary>
        /// 修改指定的广告位信息
        /// </summary>
        /// <param name="ap">该广告位对象</param>
        /// <returns>数字，大于或等于0表示修改成功</returns>
        public int Update(XYECOM.Model.AdPlaceInfo ap)
        {
            return DAL.Update(ap);
        }
		  /// <summary>
		  /// 得到符合条件的广告为信息
		  /// </summary>
		  /// <param name="strWhere">特定的查找条件</param>
		  /// <param name="OrderBy">特定的排序条件</param>
		  /// <returns>DataTable类型的广告信息</returns>
		public DataTable GetDataTable(string strWhere ,string OrderBy) 
		{
            return DAL.GetDataTable(strWhere, OrderBy);
		}
		  /// <summary>
		  /// 删除指定的广告位
		  /// </summary>
		  /// <param name="AP_ID">指定的广告位编号</param>
		  /// <returns>返回所影响的行数</returns>
		public int Delete(string  AP_ID) 
		{
            return DAL.Delete(AP_ID);
		}
         /// <summary>
         /// 更改指定广告位的启用状态
         /// </summary>
         /// <param name="AP_ID">指定广告位的ID</param>
         /// <param name="AP_IsUse">要更改的广告位状态</param>
         /// <returns>数字，大于或等于0表更改成功</returns>
        public int UpdateForIsUse(int AP_ID, bool AP_IsUse)
        {
            return DAL.UpdateForIsUse(AP_ID,AP_IsUse);
        }
	}
	
}
