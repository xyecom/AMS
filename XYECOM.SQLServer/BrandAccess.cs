//------------------------------------------------------------------------------
//
// file name：XY_BrandAccessor.cs
// author: wangzhen
// create date：2011-3-29 16:07:06
//
//------------------------------------------------------------------------------
using System.Data;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// Data accessor of BrandAccess
    /// </summary>
    public partial class BrandAccess
    {
        /// <summary>
        /// 根据分类编号获取与该分类相关的品牌集合（王振添加 2011-03-31）
        /// </summary>
        /// <param name="proTypeId">分类ID</param>
        /// <returns>品牌集合</returns>
        public DataTable GetBrandByProdTypeId(int proTypeId)
        {
            string sql = "select id,BrandName,FlagName from XY_Brand where id in (select brandid from XY_ProductTypeBrand where producttypeid = " + proTypeId + " or producttypeid in (select PT_id from b_producttype where charindex(','+cast(Pt_id as varchar(50))+',',(select FullID from  b_producttype  where Pt_id =" + proTypeId + "))>0))";
            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.Text, sql, null);            
        }
    }
}
