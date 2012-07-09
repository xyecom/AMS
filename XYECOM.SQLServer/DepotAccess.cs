//------------------------------------------------------------------------------
//
// file name：XY_DepotAccessor.cs
// author: wangzhen
// create date：2011-3-29 16:07:06
//
//------------------------------------------------------------------------------
using System.Data;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// Data accessor of DepotAccess
    /// </summary>
    public partial class DepotAccess
    {
        /// <summary>
        /// 根据用户编号获取该用户的仓库信息 （王振添加 2011-03-31）
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>仓库信息</returns>
        public DataTable GetDepotByUserId(int userId)
        {
            string sql = "select id,DepotName from XY_Depot where userid = "+userId+"";
            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.Text, sql, null);
        }
    }
}
