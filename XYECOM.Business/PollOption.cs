using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// ͶƱ����ҵ����
    /// </summary>
    public class PollOption
    {
        private static readonly XYECOM.SQLServer.PollOption DAL = new XYECOM.SQLServer.PollOption();

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="info">ͶƱ������ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Insert(Model.PollOptionInfo info)
        {
            if (info == null) return 0;

            return DAL.Insert(info);
        }

        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="info">ͶƱ������ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Update(Model.PollOptionInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="optionId">���Id</param>
        /// <returns>Ӱ������</returns>
        public int Delete(int optionId)
        {
            if (optionId <= 0) return 0;

            return DAL.Delete(optionId);
        }

        /// <summary>
        /// ����ͶƱIdɾ��ͶƱ������Ϣ
        /// </summary>
        /// <param name="pollId">ͶƱ���Id</param>
        /// <returns>Ӱ������</returns>
        public int DeleteByPollId(int pollId)
        {
            if (pollId <= 0) return 0;

            return DAL.DeleteByPollId(pollId);
        }

        /// <summary>
        /// ����ͶƱ�����Ż��ͶƱ������Ϣ
        /// </summary>
        /// <param name="optionId">ͶƱ������Id</param>
        /// <returns>ͶƱ������ʵ�����</returns>
        public Model.PollOptionInfo GetItem(int optionId)
        {
            if (optionId <= 0) return null;

            return DAL.GetItem(optionId);
        }

        /// <summary>
        /// ����ͶƱId�õ�ͶƱ������Ϣ
        /// </summary>
        /// <param name="pollId">ͶƱ���Id</param>
        /// <returns>ͶƱ������Ϣ����</returns>
        public List<Model.PollOptionInfo> GetItems(int pollId)
        {
            if (pollId <= 0) return new List<XYECOM.Model.PollOptionInfo>();

            return DAL.GetItems(pollId);
        }

        /// <summary>
        /// ��ָ��Idѡ��ͶƱ
        /// </summary>
        /// <param name="optionId">ͶƱ������Id</param>
        /// <returns>Ӱ������</returns>
        public int Poll(int optionId)
        {
            Model.PollOptionInfo info = GetItem(optionId);

            if (info == null) return 0;

            info.Total++;

            return Update(info);
        }
    }
}
