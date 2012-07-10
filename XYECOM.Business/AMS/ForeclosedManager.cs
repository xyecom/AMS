using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.Model.AMS;

namespace XYECOM.Business.AMS
{
    public class ForeclosedManager
    {
        XYECOM.SQLServer.AMS.ForeclosedAccess DAL = new SQLServer.AMS.ForeclosedAccess();

        /// <summary>
        /// 添加抵债信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool InsertForeclosed(ForeclosedInfo info)
        {
            int result = DAL.InsertForeclosed(info);
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
