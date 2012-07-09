using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// Gift的业务逻辑类
    /// </summary>
    public class Gift
    {
        private static readonly XYECOM.SQLServer.Gift giftDal = new XYECOM.SQLServer.Gift();

        #region 添加礼品
        /// <summary>
        /// 添加礼品
        /// </summary>
        /// <param name="giftInfo">礼品属性类对象</param>
        /// <returns>数字。大于等于0表示添加成功</returns>
        public int Insert(XYECOM.Model.GiftInfo giftInfo, out short gId)
        {
            return giftDal.Insert(giftInfo, out gId);
        }
        #endregion

        #region 修改礼品
        /// <summary>
        /// 修改礼品
        /// </summary>
        /// <param name="giftInfo">礼品属性类对象</param>
        /// <returns>数字。大于等于0表示修改成功</returns>
        public int Update(XYECOM.Model.GiftInfo giftInfo)
        {
            return giftDal.Update(giftInfo);
        }
        #endregion

        #region 删除礼品

        /// <summary>
        /// 删除礼品
        /// </summary>
        /// <param name="gId">礼品编号字符串</param>
        /// <param name="unDeletedIds">未删除的礼品编号，""表示 gId 参数错误，格式有问题或不足1项</param>
        /// <returns>大于等于0表示成功，-1表示 gId 参数错误，格式有问题或不足1项，-2表示所选记录全部存在兑换请求不能删除</returns>
        public int Delete(string gId, out string unDeletedIds)
        {
            string[] idArray = gId.Split(',');
            int total = idArray.Length;
            int sub = 0;
            unDeletedIds = "";
            if (idArray.Length != 0)
            {
                ExGift exGiftBll = new ExGift();
                gId = "";
                foreach (string id in idArray)
                {                    
                    if (exGiftBll.HasExchange(XYECOM.Core.MyConvert.GetInt32(id), 0))
                    {
                        unDeletedIds += id + ",";
                        sub++;
                    }
                    else
                    {
                        gId += id + ",";
                    }
                }
                if (unDeletedIds.Length > 0)
                {
                    unDeletedIds = unDeletedIds.Remove(unDeletedIds.Length - 1);
                }
                if (sub == total)
                {
                    return -2;
                }
                else
                {
                    return giftDal.Delete(gId.Remove(gId.Length - 1));
                }
            }
            else
            {
                return -1;
            }
        }

        #endregion

        #region 获取礼品
        /// <summary>
        /// 获取指定礼品
        /// </summary>
        /// <param name="gId">礼品编号</param>
        /// <returns>礼品属性类对象</returns>
        public XYECOM.Model.GiftInfo GetItem(short gId)
        {
            return giftDal.GetItem(gId);
        }
        /// <summary>
        /// 获取符合条件的礼品
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="strOrderBy">排序</param>
        /// <returns>符合条件礼品的信息</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            return giftDal.GetDataTable(strWhere, strOrderBy);
        }
        #endregion
    }
}
