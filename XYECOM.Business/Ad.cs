using System;
using System.Collections.Generic;
using System.Text;

using System.Data;


namespace XYECOM.Business
{
    /// <summary>
    /// 平台广告处理业务类
    /// </summary>
    public class Ad
    {
        private static readonly XYECOM.SQLServer.Ad DAL = new XYECOM.SQLServer.Ad();

        /// <summary>
        /// 添加广告条信息
        /// </summary>
        /// <param name="ad">要添加的广告条对象</param>
        /// <returns>数字，大于或等于0表添加成功</returns>
        public int Insert(XYECOM.Model.AdInfo ad, out int AD_ID)
        {
            return DAL.Insert(ad, out AD_ID);
        }
        /// <summary>
        /// 修改指定的广告条信息对象
        /// </summary>
        /// <param name="ad">需要修改的广告条对象</param>
        /// <returns>数字，大于或等于0表添加成功</returns>
        public int Update(XYECOM.Model.AdInfo ad)
        {
            return DAL.Update(ad);
        }
        /// <summary>
        /// 删除指定的广告
        /// </summary>
        /// <param name="adid">指定广告的编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(string adid)
        {
            return DAL.Delete(adid);
        }
        /// <summary>
        /// 得到指定条件的DataTable类型的广告
        /// </summary>
        /// <param name="strWhere">指定的where查询条件</param>
        /// <param name="strOrderBy">指定的排序条件</param>
        /// <returns>满足条件的DataTable类型的广告记录</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            return DAL.GetDataTable(strWhere, strOrderBy);   
        }
        /// <summary>
        /// 更改指定广告条的启用状态
        /// </summary>
        /// <param name="AP_ID">指定广告位的ID</param>
        /// <param name="AP_IsUse">要更改的广告位状态</param>
        /// <returns>数字，大于或等于0表更改成功</returns>
        public int UpdateForIsUse(string AD_IDs, bool AD_Isuse)
        {
            return DAL.UpdateForIsUse(AD_IDs, AD_Isuse);
        }
    }
}