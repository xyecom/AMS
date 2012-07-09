//------------------------------------------------------------------------------
//
// file name：XY_MeasuringUnitAccessor.cs
// author: wangzhen
// create date：2011-3-28 12:27:38
//
//------------------------------------------------------------------------------
using System.Data;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// Data accessor of MeasuringUnitAccess
    /// </summary>
    public partial class MeasuringUnitAccess
    {
        /// <summary>
        /// 根据分类编号获取与该分类相关的计量单位集合（王振添加 3011-03-31）
        /// </summary>
        /// <param name="proTypeId">分类编号</param>
        /// <returns>计量单位</returns>
        public DataTable GetUnitByProdTypId(int proTypeId)
        {
            string sql = "select id,MeasuringUnitName from XY_MeasuringUnit where id in (select MeasuringUnitId from XY_ProductTypeMeasuringUnit where ProductTypeId = " + proTypeId + " or producttypeid in (select PT_id from b_producttype where charindex(','+cast(Pt_id as varchar(50))+',',(select FullID from  b_producttype  where Pt_id =" + proTypeId + "))>0))";
            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.Text, sql, null);
        }
    }
}
