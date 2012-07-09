using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// 调查主题子选项业务类
    /// </summary>
    public class VoteOptions
    {
        private static readonly XYECOM.SQLServer.VoteOptions DAL = new XYECOM.SQLServer.VoteOptions();

        /// <summary>
        /// 插入选项
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns></returns>
        public int Insert(Model.VoteOptionsInfo info)
        {
            if (info == null) return 0;

            return DAL.Insert(info);
        }

        /// <summary>
        /// 更新选项信息
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns></returns>
        public int Update(Model.VoteOptionsInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }

        /// <summary>
        /// 获取指定主题下的所有选项
        /// </summary>
        /// <param name="subjectId">主题Id</param>
        /// <returns></returns>
        public List<Model.VoteOptionsInfo> GetItemsBySubjectId(int subjectId)
        {
            if (subjectId <= 0) return new List<XYECOM.Model.VoteOptionsInfo>();

            return DAL.GetItemsBySubjectId(subjectId);
        }

        /// <summary>
        /// 获取问题信息
        /// </summary>
        /// <param name="subjectId">问题Id</param>
        /// <returns></returns>
        public Model.VoteOptionsInfo GetItem(int optionId)
        {
            if (optionId <= 0) return null;

            return DAL.GetItem(optionId);
        }

         /// <summary>
        /// 投票
        /// </summary>
        /// <param name="optionId">选项Id</param>
        /// <returns></returns>
        public int Vote(int optionId)
        {
            if (optionId <= 0) return 0;

            return DAL.Vote(optionId);
        }

         /// <summary>
        /// 删除主题
        /// </summary>
        /// <param name="voteId">主题Id</param>
        /// <returns></returns>
        public int Delete(int optionId)
        {
            if (optionId <= 0) return 0;

            return DAL.Delete(optionId);
        }
    }
}
