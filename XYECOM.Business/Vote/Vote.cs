using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// 网上调查业务类
    /// </summary>
    public class Vote
    {
        private static readonly XYECOM.SQLServer.Vote DAL = new XYECOM.SQLServer.Vote();

        /// <summary>
        /// 插入新调查
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns></returns>
        public int Insert(Model.VoteInfo info)
        {
            if (info == null) return 0;

            return DAL.Insert(info);
        }

        /// <summary>
        /// 更新调查信息
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns></returns>
        public int Update(Model.VoteInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }

        /// <summary>
        /// 获取指定Id的调查信息
        /// </summary>
        /// <param name="voteId">调查Id</param>
        /// <returns></returns>
        public Model.VoteInfo GetItem(int voteId)
        {
            if (voteId <= 0) return null;

            return DAL.GetItem(voteId);
        }

        /// <summary>
        /// 删除指定的调查
        /// </summary>
        /// <param name="voteId">调查Id</param>
        /// <returns></returns>
        public int Delete(int voteId)
        {
            if (voteId <= 0) return 0;

            int i = DAL.Delete(voteId) ;
            //if (i > 0)
            //{
            //    new Business.VoteSubject().DeleteByVoteId(voteId);
            //}

            return i;
        }
    }
}
