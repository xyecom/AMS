using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.Model.AMS;
using XYECOM.SQLServer.AMS;

namespace XYECOM.Business.AMS
{
    /// <summary>
    /// 投标业务逻辑类
    /// </summary>
    public class TenderInfoManager
    {
        TenderInfoAccess DAL = new TenderInfoAccess();

        /// <summary>
        /// 添加竞标信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertTenderInfo(TenderInfo info)
        {
            if (info == null)
            {
                return 0;
            }
            return DAL.InsertTenderInfo(info);
        }

        /// <summary>
        /// 根据债权信息编号获取投标个数
        /// </summary>
        /// <param name="CreditID"></param>
        /// <returns></returns>
        public int GetTenderCountByCreditID(int CreditID)
        {
            if (CreditID <= 0)
            {
                return 0;
            }
            return DAL.GetTenderCountByCreditID(CreditID);
        }
    }
}
