using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.Model.AMS;
using XYECOM.SQLServer.AMS;
using System.Data;
namespace XYECOM.Business.AMS
{
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
    }
}
