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
        /// 新增操作，返回自增长ID
        /// </summary>
        /// <param name="info"></param>
        /// <param name="credId"></param>
        /// <returns></returns>
        public int InsertCreditInfo(CreditInfo info, out int credId)
        {
            credId = 0;
            if (info == null)
            {
                return 0;
            }
            return DAL.InsertCreditInfo(info, out credId);
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

        /// <summary>
        /// 根据债权信息编号以及是否服务商修改债权信息是否被评价
        /// </summary>
        /// <param name="credId"></param>
        /// <param name="isServer"></param>
        /// <returns></returns>
        public int UpdateEvaluationByCredId(int credId, bool isServer)
        {
            if (credId <= 0)
            {
                return 0;
            }
            return DAL.UpdateEvaluationByCredId(credId, isServer);
        }

        /// <summary>
        /// 推荐or不推荐
        /// </summary>
        /// <param name="credId"></param>
        /// <param name="isJian"></param>
        /// <returns></returns>
        public int UpdateIsDraftById(int credId, bool isJian)
        {
            if (credId <= 0)
            {
                return 0;
            }
            return DAL.UpdateIsDraftById(credId, isJian);
        }

        /// <summary>
        /// 根据债权编号获取同一地区的推荐个数
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        public int GetTuiJianCountById(int Id)
        {
            if (Id <= 0)
            {
                return 0;
            }
            return DAL.GetTuiJianCountById(Id);
        }
    }
}
