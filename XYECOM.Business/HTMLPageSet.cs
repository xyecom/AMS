using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{

    /// <summary>
    /// 静态页面业务类
    /// </summary>
    public class HTMLPageSet
    {
        private static readonly XYECOM.SQLServer.HTMLPageSet DAL = new XYECOM.SQLServer.HTMLPageSet();

        #region 添加静态页面设置信息
        /// <summary>
        /// 添加静态页面设置信息
        /// </summary>
        /// <param name="ehps">静态页面设置信息属性类对象</param>
        /// <returns>数字。大于0表示设置成功</returns>
        public int Insert(XYECOM.Model.HtmlPageSetInfo ehps)
        {
            return DAL.Insert(ehps);
        }
        #endregion

        #region 修改静态页面设置信息
        /// <summary>
        /// 修改静态页面设置信息
        /// </summary>
        /// <param name="ehps">静态页面设置信息属性类对象</param>
        /// <returns>数字。大于0表示修改成功</returns>
        public int Update(XYECOM.Model.HtmlPageSetInfo ehps)
        {

            return DAL.Update(ehps);
        }
        #endregion

        #region 获取静态页面设置信息
        /// <summary>
        /// 获取静态页面设置信息
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="strOrderBy">排序条件</param>
        /// <returns>DataTable数据集</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            return DAL.GetDataTable(strWhere, strOrderBy);
        }
        #endregion
    }
}
