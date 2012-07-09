using System;
using System.Collections.Generic;
using System.Text;

using System.Data;


namespace XYECOM.Business
{

    /// <summary>
    /// 新闻来源业务类
    /// </summary>
    public class NewsOrigin
    {
        private static readonly XYECOM.SQLServer.NewsOrigin DAL = new XYECOM.SQLServer.NewsOrigin();

        #region 添加新闻来源
        /// <summary>
        /// 添加新闻来源信息
        /// </summary>
        /// <param name="no">要添加的新闻来源对象</param>
        /// <param name="no_id">添加成功后该新闻来源对象在表中的ID值</param>
        /// <returns>数字，大于或等于0表添加成功</returns>
        public int Insert(XYECOM.Model.NewsOriginInfo no, out int no_id)
        {
            return DAL.Insert(no, out no_id);
        }
        #endregion

        #region 修改指定的新闻来源
        /// <summary>
        /// 修改指定的新闻来源信息
        /// </summary>
        /// <param name="no">要修改的新闻来源信息对象</param>
        /// <returns>数字，大于或等于0表修改成功</returns>
        public int Update(XYECOM.Model.NewsOriginInfo no)
        {
            return DAL.Update(no);
        }
        #endregion

        #region 得到满足条件的新闻来源信息DataTable列表
        /// <summary>
        /// 得到满足条件的新闻来源信息对象
        /// </summary>
        /// <param name="strWhere">指定的Where查询条件</param>
        /// <param name="strOrderBy">指定的排序条件</param>
        /// <returns>满足条件的新闻来源信息对象</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            return DAL.GetDataTable(strWhere, strOrderBy);
        }
        #endregion

        #region 删除指定的新闻来源信息对象
        /// <summary>
        /// 删除指定的新闻来源信息
        /// </summary>
        /// <param name="no_ids">指定的新闻来源信息对象ID值</param>
        /// <returns>数字，大于或等于0表删除成功</returns>
        public int Delete(string no_ids)
        {
            return DAL.Delete(no_ids);
        }
        #endregion
    }
}
