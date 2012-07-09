using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// 广告位类别业务类
    /// </summary>
    public class AdPlaceType
    {
        private static readonly XYECOM.SQLServer.AdPlaceType DAL = new XYECOM.SQLServer.AdPlaceType();
         /// <summary>
         /// 添加广告位类别
         /// </summary>
         /// <param name="at">广告位类别实体类</param>
         /// <param name="at_id">所添加实体类的ID值</param>
         /// <returns>数字,大于0表示添加成功</returns>
        public int Insert(XYECOM.Model.AdPlaceTypeInfo at, out int at_id)
        {
            return DAL.Insert(at,out at_id);
        }        

        #region 修改指定广告位类别信息
         /// <summary>
         /// 修改指定广告位类别信息
         /// </summary>
         /// <param name="at">要修改的指定广告位对象</param>
        /// <returns>数字，大于或等于0表示修改成功</returns>
        public int Update(XYECOM.Model.AdPlaceTypeInfo at)
        {
            return DAL.Update(at);
        }
        #endregion

        #region 删除指定广告位类别信息
         /// <summary>
         /// 删除指定的广告位类别信息
         /// </summary>
         /// <param name="at_ids">要删除的广告位类别ID串</param>
         /// <returns>数字，大于或等于0表删除成功</returns>
        public int Delete(string at_ids)
        {
            return DAL.Delete(at_ids);
        }
        #endregion

        #region 判断该类别下面是否还有子类别
        /// <summary>
        /// 根据ID判断要删除的类别下是否还有子类别
        /// </summary>
        /// <param name="at_ids">指定的ID值</param>
        /// <returns>数字,大于0表示还有子类别,等于0表示无子类别</returns>
        public int GetSonType(string at_ids)
        {
            return DAL.GetSonType(at_ids);
        }
        #endregion

        #region 获得指定的广告位类别的DataTable
        /// <summary>
         /// 获得指定的DataTable类型的广告位类别
         /// </summary>
         /// <param name="strWhere">指定的广告位类别</param>
        /// <param name="strOrderBy">指定的广告位类别检索信息</param>
         /// <returns>DataTable类型的满足条件的广告位类别信息</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            return DAL.GetDataTable(strWhere, strOrderBy);
        }
        #endregion
        
        #region 依据广告位类别ID获取该广告位类别的名称
        /// <summary>
        /// 依据广告位ID获取该广告位的名称
         /// </summary>
         /// <param name="atid">广告位ID</param>
         /// <returns>该广告位ID对应的广告位名称</returns>
        public string GetAdPlaceTypeName(int atid)
        {
            return DAL.GetAdPlaceTypeName(atid);
        }
        #endregion

        #region 依据广告条类别ID获取该广告条类别的名称
        /// <summary>
        /// 依据广告位ID获取该广告位的名称
        /// </summary>
        /// <param name="atid">广告位ID</param>
        /// <returns>该广告位ID对应的广告位名称</returns>
        public string GetAdPlaceTypeNames(int atid)
        {
            return DAL.GetAdPlaceTypeNames(atid);
        }
        #endregion
    }

}
