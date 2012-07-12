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

        public bool UpdateForeclosedByID(ForeclosedInfo info)
        {
            int result = DAL.UpdateForeclosedByID(info);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ForeclosedInfo GetForeclosedInfoById(int id)
        {
            return DAL.GetForeclosedInfoById(id);
        }

        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Deletes(string Ids)
        {
            return DAL.Deletes(Ids);
        }

        /// <summary>
        /// 单条审核操作
        /// </summary>
        /// <param name="fId">抵债信息编号</param>
        /// <param name="state">审核通过or审核不通过</param>
        /// <returns></returns>
        public int AuditById(int fId, bool state)
        {
            if (fId <= 0)
            {
                return 0;
            }
            return DAL.AuditById(fId, state);
        }

        /// <summary>
        /// 多条审核操作
        /// </summary>
        /// <param name="fIds">抵债信息编号</param>
        /// <param name="state">审核通过or审核不通过</param>
        /// <returns></returns>
        public int AuditByIds(string fIds, bool state)
        {
            if (string.IsNullOrEmpty(fIds))
            {
                return 0;
            }
            return DAL.AuditByIds(fIds,state);
        }
    }
}
