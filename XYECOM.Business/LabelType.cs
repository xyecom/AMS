using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{

    /// <summary>
    /// 标签类别业务类
    /// </summary>
    public class LabelType
    {
        private static readonly XYECOM.SQLServer.LabelType DAL = new XYECOM.SQLServer.LabelType();

        #region 添加标签类别
        /// <summary>
        /// 添加标签类别
        /// </summary>
        /// <param name="elt">标签类别属性类对象</param>
        /// <returns>数字。大于0表示添加成功</returns>
        public int Insert(XYECOM.Model.LabelTypeInfo elt)
        {
            return DAL.Insert(elt);
        }
        #endregion

        #region 修改标签类别
        /// <summary>
        /// 修改标签类别
        /// </summary>
        /// <param name="elt">标签类别属性类对象</param>
        /// <returns>数字。大于0表示修改成功</returns>
        public int Update(XYECOM.Model.LabelTypeInfo elt)
        {
            return DAL.Update(elt);
        }
        #endregion

        #region 删除标签类别
        /// <summary>
        /// 删除标签类别
        /// </summary>
        /// <param name="LT_ID">标签类别编号</param>
        /// <returns>影响行数</returns>
        public int Delete(int LT_ID)
        {
            return DAL.Delete(LT_ID);
        }
        #endregion

        #region 获取标签类别
        /// <summary>
        /// 获取指定类别名称
        /// </summary>
        /// <param name="LT_ID">类别编号</param>
        /// <returns>类别名称</returns>
        public string GetLTName(int LT_ID)
        {
            return DAL.GetLTName(LT_ID);

        }

        /// <summary>
        /// 获取指定类别信息
        /// </summary>
        /// <param name="LT_ID">类别编号</param>
        /// <returns>类别信息</returns>
        public XYECOM.Model.LabelTypeInfo GetItem(int LT_ID)
        {
            return DAL.GetItem(LT_ID);
        }

        /// <summary>
        /// 获取指定条件的类别信息
        /// </summary>
        /// <param name="strWhere">筛选条件</param>
        /// <returns>类别信息集</returns>
        public DataTable GetDataTable(string strWhere)
        {
            return DAL.GetDataTable(strWhere);
        }
        #endregion
    }

}
