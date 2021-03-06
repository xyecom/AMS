﻿using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.Model.AMS;

namespace XYECOM.Business.AMS
{
    /// <summary>
    /// 抵债信息业务类
    /// </summary>
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

        /// <summary>
        /// 新增操作，返回自增长ID
        /// </summary>
        /// <param name="info"></param>
        /// <param name="foreId"></param>
        /// <returns></returns>
        public int InsertForeclosedReturnID(ForeclosedInfo info, out int foreId)
        {
            foreId = 0;
            if (info == null)
            {
                return 0;
            }
            return DAL.InsertForeclosed(info, out foreId);
        }

        /// <summary>
        /// 根据抵债编号修改抵债信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 根据抵债信息编号获取抵债信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ForeclosedInfo GetForeclosedInfoById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return DAL.GetForeclosedInfoById(id);
        }

        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Deletes(string Ids)
        {
            if (string.IsNullOrEmpty(Ids))
            {
                return 0;
            }
            return DAL.Deletes(Ids);
        }

        /// <summary>
        /// 根据抵债信息编号删除抵债信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            if (id <= 0)
            {
                return 0;
            }
            return DAL.Delete(id);
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
            return DAL.AuditByIds(fIds, state);
        }

        /// <summary>
        /// 关闭抵债信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int ClosedByID(int id)
        {
            if (id <= 0)
            {
                return 0;
            }
            return DAL.ClosedByID(id);
        }
    }
}
