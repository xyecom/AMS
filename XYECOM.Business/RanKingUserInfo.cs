using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// �����Զ�����Ϣ
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
        /// ɾ��
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public int Delete(int infoId)
        {
            if (infoId <= 0) return 0;

            return DAL.Delete(infoId);
        }

        /// <summary>
        /// ��ȡ��Ϣ
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <param name="rankingId">����id</param>
        /// <param name="rank">����</param>
        /// <param name="moduleName">ģ������</param>
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
        /// ��ȡ��Ϣ
        /// </summary>
        /// <param name="rankingId">����id</param>
        /// <param name="rank">����</param>
        /// <param name="moduleName">ģ������</param>
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
