using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.Model.AMS;
using XYECOM.SQLServer.AMS;
using System.Data;
namespace XYECOM.Business.AMS
{
    /// <summary>
    /// 债权业务类
    /// </summary>
    public class CreditInfoManager
    {
        CreditInfoAccess DAL = new CreditInfoAccess();
        /// <summary>
        /// 增加债权信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool InsertCreditInfo(CreditInfo info)
        {
            if (info == null)
            {
                return false;
            }
            int result = DAL.InsertCreditInfo(info);
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
        /// 单条修改债权信息状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int UpdateApprovaStatusByID(int id, XYECOM.Model.CreditState state)
        {
            if (id <= 0)
            {
                return 0;
            }
            return DAL.UpdateApprovaStatusByID(id, state);
        }

        /// <summary>
        /// 多条修改债权信息状态
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int UpdateApprovaStatusByID(string ids, XYECOM.Model.CreditState state)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return 0;
            }
            return DAL.UpdateApprovaStatusByID(ids, state);
        }

        /// <summary>
        /// 根据编号获取抵债信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CreditInfo GetCreditInfoById(int id)
        {
            if (id < 0)
            {
                return null;
            }
            return DAL.GetCreditInfoById(id);
        }

                /// <summary>
        /// 修改债权信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateCreditInfoByID(CreditInfo info)
        {
            if (info == null)
            {
                return 0;
            }
            return DAL.UpdateCreditInfoByID(info);
        }
    }
}
