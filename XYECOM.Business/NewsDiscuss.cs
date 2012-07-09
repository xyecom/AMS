using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using XYECOM.Model;

namespace XYECOM.Business
{
    /// <summary>
    /// 新闻评论的业务逻辑
    /// </summary>
    public class NewsDiscuss
    {
        /// <summary>
        /// 使用抽象工厂得到一个新闻评论的DAL
        /// </summary>
        private static readonly XYECOM.SQLServer.NewsDiscuss DAL = new XYECOM.SQLServer.NewsDiscuss();

        /// <summary>
        /// 插入新的评论对象
        /// </summary>
        /// <param name="nd">要插入的新闻评论对象</param>
        /// <param name="ndid">插入成功后该评论编号</param>
        /// <returns>数字,大于或等于0表插入成功,否则表失败</returns>
        public int Insert(NewsDiscussInfo nd)
        {
            return DAL.Insert(nd);
        }

        #region 更新指定的新闻评论
        /// <summary>
        /// 更新指定的新闻评论对象
        /// </summary>
        /// <param name="nd">要更新的新闻评论</param>
        /// <returns>数字,大于或等于0表更新成功,否则失败</returns>
        public int Update(NewsDiscussInfo nd)
        {
            return DAL.Update(nd);
        }
        #endregion

        #region 得到满足指定条件的DataTable类型的新闻评论
        /// <summary>
        /// 得到满足指定条件的DataTable类型的新闻评论
        /// </summary>
        /// <param name="strWhere">指定的Where条件</param>
        /// <param name="strOrderBy">指定的排序条件</param>
        /// <returns>满足条件的新闻评论</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            return DAL.GetDataTable(strWhere, strOrderBy);
        }
        #endregion

        #region 删除指定编号的新闻评论
        /// <summary>
        /// 删除指定编号的新闻评论
        /// </summary>
        /// <param name="ndids">指定的新闻评论编号</param>
        /// <returns>数字,大于或等于0表删除成功</returns>
        public int Delete(string ndids)
        {
            return DAL.Delete(ndids);
        }
        #endregion

        #region 根据指定编号获取一条新闻评论
        /// <summary>
        /// 根据指定编号获取一条新闻评论
        /// </summary>
        /// <param name="ndid">指定的新闻编号</param>
        /// <returns>该编号的新闻评论对象</returns>
        public NewsDiscussInfo GetItem(Int64 ndid)
        {
            return DAL.GetItem(ndid);
        }
        #endregion

        #region 更改新闻评论的显示状态
        /// <summary>
        /// 更改新闻评论的显示状态
        /// </summary>
        /// <param name="ndid">要更改的新闻评论编号</param>
        /// <param name="IsShow">要更改的评论状态</param>
        /// <returns>数字,大于等于0表更改成功,否则更改失败.</returns>
        public int SetIsShow(Int64 ndid, bool IsShow)
        {
            return DAL.SetIsShow(ndid, IsShow);
        }
        #endregion

        #region 获取前n条新闻评论
        /// <summary>
        /// 获取前n条新闻评论
        /// </summary>
        /// <param name="ndid"></param>
        /// <param name="strOrderBy">指定的排序条件</param>
        /// <param name="strColumuName">指定的字段</param>
        /// <param name="TopNum">要获取的前n条数目</param>
        /// <returns>满足条件的DataTable类型的记录</returns>
        public DataTable GetDataTable(string ndid, string strOrderBy, string strColumuName, int TopNum)
        {
            string strOrder = "";
            if (string.IsNullOrEmpty(strOrderBy))
                strOrder = " order by ND_ID desc ";

            string strWhere = " where ND_IsShow=1 ";
            if (ndid != "")
                strWhere += " and NS_ID =" + ndid;
            return DAL.GetDataTable(strWhere, strOrder, strColumuName, TopNum);
        }
        #endregion
    }
}
