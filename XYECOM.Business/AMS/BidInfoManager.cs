using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.Model.AMS;
using XYECOM.SQLServer.AMS;
using System.Data;

namespace XYECOM.Business.AMS
{
    /// <summary>
    /// 竞价业务逻辑类
    /// </summary>
    public class BidInfoManager
    {
        BidInfoAccess DAL = new BidInfoAccess();

        /// <summary>
        /// 新增报价信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool InserBidInfo(BidInfo info)
        {
            if (info == null)
            {
                return false;
            }
            int result = DAL.InserBidInfo(info);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取领先信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetLingXian(int ForeclosedId)
        {
            return DAL.GetLingXian(ForeclosedId);
        }

        /// <summary>
        /// 根据抵债信息编号获取该抵债信息的竞价个数
        /// </summary>
        /// <param name="ForeID"></param>
        /// <returns></returns>
        public int GetBidInfoCountByForeID(int ForeID)
        {
            if (ForeID <= 0)
            {
                return 0;
            }
            return DAL.GetBidInfoCountByForeID(ForeID);
        }
    }
}
