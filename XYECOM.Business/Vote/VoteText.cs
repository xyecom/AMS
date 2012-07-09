using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// 调查文本内容业务类
    /// </summary>
    public class VoteText
    {
        private static readonly XYECOM.SQLServer.VoteText DAL = new XYECOM.SQLServer.VoteText();

        /// <summary>
        /// 插入一条信息
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns></returns>
        public int Insert(Model.VoteTextInfo info)
        {
            if (info == null) return 0;

            return DAL.Insert(info);
        }

        /// <summary>
        /// 通过主题Id返回所有的文本内容
        /// </summary>
        /// <param name="subjectId">主题Id</param>
        /// <returns></returns>
        public List<Model.VoteTextInfo> GetItemsBySubjectId(int subjectId)
        {
            if (subjectId <= 0) return new List<XYECOM.Model.VoteTextInfo>();

            return DAL.GetItemsBySubjectId(subjectId);
        }

        /// <summary>
        /// 删除文本
        /// </summary>
        /// <param name="textId">文本Id</param>
        /// <returns></returns>
        public int Delete(int textId)
        {
            if (textId <= 0) return 0;

            return DAL.Delete(textId);
        }
    }
}
