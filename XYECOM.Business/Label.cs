using System;
using System.Collections.Generic;
using System.Text;

using System.Data;


namespace XYECOM.Business
{

    /// <summary>
    /// 内容标签业务类
    /// </summary>
    public class Label
    {
        private static readonly XYECOM.SQLServer.Label DAL = new XYECOM.SQLServer.Label();

        #region 添加标签信息
        /// <summary>
        /// 添加标签信息
        /// </summary>
        /// <param name="el">标签信息属性类对象</param>
        /// <returns>数字。大于0表示添加成功</returns>
        public int Insert(XYECOM.Model.LabelInfo el)
        {
            return DAL.Insert(el);
        }
        #endregion

        #region 修改标签信息
        /// <summary>
        /// 修改标签信息
        /// </summary>
        /// <param name="el">标签信息属性类对象</param>
        /// <returns>数字。大于0表示添加成功</returns>
        public int Update(XYECOM.Model.LabelInfo el)
        {
            return DAL.Update(el);
        }
        #endregion

        #region 删除标签信息
        /// <summary>
        /// 删除标签信息
        /// </summary>
        /// <param name="L_ID">标签编号</param>
        /// <returns>数字。大于0表示删除成功</returns>
        public int Delete(long L_ID)
        {
            return DAL.Delete(L_ID);
        }
        public int Delete(string L_IDs)
        {
            return DAL.Delete(L_IDs);
        }
        #endregion

        #region 获取标签信息
        /// <summary>
        /// 获取标签信息
        /// </summary>
        /// <param name="L_Name">标签名</param>
        /// <returns>内容标签实体对象</returns>
        public XYECOM.Model.LabelInfo GetItem(string L_Name)
        {
            return DAL.GetItem(L_Name);
        }

        /// <summary>
        /// 根据内容标签编号Id返回内容标签信息
        /// </summary>
        /// <param name="L_ID">编号id</param>
        /// <returns>内容标签实体对象</returns>
        public XYECOM.Model.LabelInfo GetItem(long L_ID)
        {
            return DAL.GetItem(L_ID);
        }
        #endregion
    }
}
