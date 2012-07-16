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

        /// <summary>
        /// 判断某服务商是否已经对某债权信息投标
        /// </summary>
        /// <param name="credId"></param>
        /// <returns></returns>
        public bool CheckTenderByCredID(int credId, int serId)
        {
            if (credId <= 0)
            {
                return true;
            }
            return DAL.CheckTenderByCredID(credId, serId);
        }

        /// <summary>
        /// 根据投标编号获取投标信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TenderInfo GetTenderInfoByID(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return DAL.GetTenderInfoByID(id);
        }

        /// <summary>
        /// 根据投标信息编号更改为已中标
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateTenderByID(int id, int credId)
        {
            if (id <= 0)
            {
                return 0;
            }
            return DAL.UpdateTenderByID(id, credId);
        }
        /// <summary>
        /// 根据债权信息获取投标成功的投标信息
        /// </summary>
        /// <param name="credId"></param>
        /// <returns></returns>
        public TenderInfo GetTenderByCredId(int credId)
        {
            if (credId <= 0)
            {
                return null;
            }
            return DAL.GetTenderByCredId(credId);
        }
    }
}
