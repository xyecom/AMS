using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// 排名自定义信息
    /// </summary>
    public class RanKingUserInfo
    {
        private static readonly XYECOM.SQLServer.RankingUserInfo DAL = new XYECOM.SQLServer.RankingUserInfo();

        public int Update(XYECOM.Model.RankingUserInfo info)
        {
            if(info == null)return 0;

            return DAL.Update(info);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public int Delete(int infoId)
        {
            if (infoId <= 0) return 0;

            return DAL.Delete(infoId);
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="rankingId">排名id</param>
        /// <param name="rank">名次</param>
        /// <param name="moduleName">模块名称</param>
        /// <returns></returns>
        public Model.RankingUserInfo GetItem(long userId, int rankingId, int rank, string moduleName)
        {
            if (userId <= 0 
                || rankingId <= 0 
                || rank <= 0 
                || string.IsNullOrEmpty(moduleName)) 
                return null;

            return DAL.GetItem(userId,rankingId,rank,moduleName);
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="rankingId">排名id</param>
        /// <param name="rank">名次</param>
        /// <param name="moduleName">模块名称</param>
        /// <returns></returns>
        public Model.RankingUserInfo GetItem(int rankingId, int rank, string moduleName)
        {
            if (rankingId <= 0
                || rank <= 0
                || string.IsNullOrEmpty(moduleName))
                return null;

            return DAL.GetItem(rankingId, rank, moduleName);
        }

        public Model.RankingUserInfo GetItem(int InfoId)
        {
            if (InfoId <= 0)
                return null;
            return DAL.GetItem(InfoId);
        }
    }
}
