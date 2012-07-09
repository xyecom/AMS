using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{

    /// <summary>
    /// 新闻作者业务类
    /// </summary>
    public class NewsAuthor
    {
        private static readonly XYECOM.SQLServer.NewsAuthor DAL = new XYECOM.SQLServer.NewsAuthor();

        #region
         /// <summary>
         /// 添加新闻作者操作
         /// </summary>
         /// <param name="na">要添加的新闻作者对象</param>
         /// <param name="na_id">添加新闻作者后该对象的ID值</param>
         /// <returns>数字，大于或等于0表示添加成功</returns>
        public int Insert(XYECOM.Model.NewsAuthorInfo na , out int na_id)
        {
            return DAL.Insert(na,out na_id);
        }
        #endregion


        #region 修改新闻作者信息
        /// <summary>
        /// 修改新闻作者信息操作
        /// </summary>
        /// <param name="na">要修改的新闻信息对象</param>
        /// <returns>数字，大于或者等于0表示修改成功</returns>
        public int Update(XYECOM.Model.NewsAuthorInfo na)
        {
            return DAL.Update(na);
        }
        #endregion

        #region
        /// <summary>
        /// 得到满足指定条件的新闻作者DataTable
        /// </summary>
        /// <param name="strWhere">指定的查询条件</param>
        /// <param name="strOrderBy">指定的排序条件</param>
        /// <returns>满足条件的DataTable的新闻作者信息</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            return DAL.GetDataTable(strWhere, strOrderBy);
        }
        #endregion

        #region
        /// <summary>
        /// 删除指定的新闻作者信息
        /// </summary>
        /// <param name="na_ids">指定的新闻作者ID值</param>
        /// <returns>数字，大于或等于0表示删除成功</returns>
        public int Delete(string na_ids)
        {
            return DAL.Delete(na_ids);
        }
        #endregion
    }
}
