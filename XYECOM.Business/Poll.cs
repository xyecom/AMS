using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// 投票业务类
    /// </summary>
    public class Poll
    {
        private static readonly XYECOM.SQLServer.Poll DAL = new XYECOM.SQLServer.Poll();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="info">投票类实体对象</param>
        /// <param name="lastId">编号id</param>
        /// <returns>影响行数</returns>
        public int Insert(Model.PollInfo info,out int lastId)
        {
            lastId = 0;
            if (info == null) return 0;

            return DAL.Insert(info,out lastId);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="info">投票类实体对象</param>
        /// <returns>影响行数</returns>
        public int Update(Model.PollInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pollId">编号Id</param>
        /// <returns>影响行数</returns>
        public int Delete(int pollId)
        {
            if (pollId <= 0) return 0;

            int result = DAL.Delete(pollId);

            if (result > 0)
            {
                new PollOption().DeleteByPollId(pollId);
            }
            return result;
        }

        /// <summary>
        /// 得到一条投票信息
        /// </summary>
        /// <param name="pollId">编号id</param>
        /// <returns>投票类实体对象</returns>
        public Model.PollInfo GetItem(int pollId)
        {
            if (pollId <= 0) return null;

            return DAL.GetItem(pollId);
        }

        /// <summary>
        /// 根据标签名称得到投票信息
        /// </summary>
        /// <param name="labelName">标签名称</param>
        /// <returns>投票类实体对象</returns>
        public Model.PollInfo GetItem(string labelName)
        {
            if (string.IsNullOrEmpty(labelName)) return null;

            return DAL.GetItem(labelName);
        }
    }
}
