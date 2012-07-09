using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// ͶƱҵ����
    /// </summary>
    public class Poll
    {
        private static readonly XYECOM.SQLServer.Poll DAL = new XYECOM.SQLServer.Poll();

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="info">ͶƱ��ʵ�����</param>
        /// <param name="lastId">���id</param>
        /// <returns>Ӱ������</returns>
        public int Insert(Model.PollInfo info,out int lastId)
        {
            lastId = 0;
            if (info == null) return 0;

            return DAL.Insert(info,out lastId);
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="info">ͶƱ��ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Update(Model.PollInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="pollId">���Id</param>
        /// <returns>Ӱ������</returns>
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
        /// �õ�һ��ͶƱ��Ϣ
        /// </summary>
        /// <param name="pollId">���id</param>
        /// <returns>ͶƱ��ʵ�����</returns>
        public Model.PollInfo GetItem(int pollId)
        {
            if (pollId <= 0) return null;

            return DAL.GetItem(pollId);
        }

        /// <summary>
        /// ���ݱ�ǩ���Ƶõ�ͶƱ��Ϣ
        /// </summary>
        /// <param name="labelName">��ǩ����</param>
        /// <returns>ͶƱ��ʵ�����</returns>
        public Model.PollInfo GetItem(string labelName)
        {
            if (string.IsNullOrEmpty(labelName)) return null;

            return DAL.GetItem(labelName);
        }
    }
}
