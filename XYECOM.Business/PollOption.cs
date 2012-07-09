using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// 投票主题业务类
    /// </summary>
    public class PollOption
    {
        private static readonly XYECOM.SQLServer.PollOption DAL = new XYECOM.SQLServer.PollOption();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="info">投票主题类实体对象</param>
        /// <returns>影响行数</returns>
        public int Insert(Model.PollOptionInfo info)
        {
            if (info == null) return 0;

            return DAL.Insert(info);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="info">投票主题类实体对象</param>
        /// <returns>影响行数</returns>
        public int Update(Model.PollOptionInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="optionId">编号Id</param>
        /// <returns>影响行数</returns>
        public int Delete(int optionId)
        {
            if (optionId <= 0) return 0;

            return DAL.Delete(optionId);
        }

        /// <summary>
        /// 根据投票Id删除投票主题信息
        /// </summary>
        /// <param name="pollId">投票编号Id</param>
        /// <returns>影响行数</returns>
        public int DeleteByPollId(int pollId)
        {
            if (pollId <= 0) return 0;

            return DAL.DeleteByPollId(pollId);
        }

        /// <summary>
        /// 根据投票主题编号获得投票主题信息
        /// </summary>
        /// <param name="optionId">投票主题编号Id</param>
        /// <returns>投票主题类实体对象</returns>
        public Model.PollOptionInfo GetItem(int optionId)
        {
            if (optionId <= 0) return null;

            return DAL.GetItem(optionId);
        }

        /// <summary>
        /// 根据投票Id得到投票主题信息
        /// </summary>
        /// <param name="pollId">投票编号Id</param>
        /// <returns>投票主题信息集合</returns>
        public List<Model.PollOptionInfo> GetItems(int pollId)
        {
            if (pollId <= 0) return new List<XYECOM.Model.PollOptionInfo>();

            return DAL.GetItems(pollId);
        }

        /// <summary>
        /// 给指定Id选项投票
        /// </summary>
        /// <param name="optionId">投票主题编号Id</param>
        /// <returns>影响行数</returns>
        public int Poll(int optionId)
        {
            Model.PollOptionInfo info = GetItem(optionId);

            if (info == null) return 0;

            info.Total++;

            return Update(info);
        }
    }
}
