using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// ������־ҵ����
    /// </summary>
    public class RankingLog
    {
        private XYECOM.SQLServer.RankingLog DAL = new XYECOM.SQLServer.RankingLog();
        /// <summary>
        /// ɾ��������־��Ϣ
        /// </summary>
        /// <param name="logIds">��ż���</param>
        /// <returns>Ӱ������</returns>
        public int Delete(string logIds)
        {
            if (String.IsNullOrEmpty(logIds)) return 0;

            logIds = logIds.Trim();

            if (logIds.Equals("")) return 0;

            return DAL.Delete(logIds);
        }
    }
}
