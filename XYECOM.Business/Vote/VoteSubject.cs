using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// 调查主题操作业务类
    /// </summary>
    public class VoteSubject
    {
        private static readonly XYECOM.SQLServer.VoteSubject DAL = new XYECOM.SQLServer.VoteSubject();

        /// <summary>
        /// 插入新主题
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns></returns>
        public int Insert(Model.VoteSubjectInfo info, out int subjectId)
        {
            subjectId = 0;
            if (info == null) return 0;

            return DAL.Insert(info, out subjectId);
        }

        /// <summary>
        /// 更新主题信息
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns></returns>
        public int Update(Model.VoteSubjectInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }

        /// <summary>
        /// 获取指定调查下的所有主题
        /// </summary>
        /// <param name="voteId">调查Id</param>
        /// <returns></returns>
        public List<Model.VoteSubjectInfo> GetItemsByVoteId(int voteId)
        {
            if (voteId <= 0) return new List<XYECOM.Model.VoteSubjectInfo>();

            return DAL.GetItemsByVoteId(voteId);
        }

        /// <summary>
        /// 获取问题信息
        /// </summary>
        /// <param name="subjectId">问题Id</param>
        /// <returns></returns>
        public Model.VoteSubjectInfo GetItem(int subjectId)
        {
            if (subjectId<=0) return null;

            return DAL.GetItem(subjectId);
        }

        /// <summary>
        /// 删除主题
        /// </summary>
        /// <param name="subjectId">主题Id</param>
        /// <returns></returns>
        public int Delete(int subjectId)
        {
            if (subjectId <= 0) return 0;

            int i = DAL.Delete(subjectId);

            return i;
        }
    }
}
