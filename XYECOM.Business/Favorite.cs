using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// 收藏信息业务类
    /// </summary>
    public class Favorite
    {

        private static readonly XYECOM.SQLServer.Favorite DAL = new XYECOM.SQLServer.Favorite();
        /// <summary>
        /// 添加收藏信息
        /// </summary>
        /// <param name="ef">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.FavoriteInfo ef)
        {
            return DAL.Insert(ef);
        }

        /// <summary>
        /// 修改收藏信息
        /// </summary>
        /// <param name="ef">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.FavoriteInfo ef)
        {
            return DAL.Update(ef);
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="Fa_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM .Model.FavoriteInfo  GetItem(int Fa_ID)
        {
            return DAL.GetItem(Fa_ID);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="Fa_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(string  Fa_IDs)
        {
            return DAL.Delete(Fa_IDs);
        }
    }
}
