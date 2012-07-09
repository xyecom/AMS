using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// 友情链接分类业务类
    /// </summary>
    public class FriendLinkSort
    {
        private static readonly XYECOM.SQLServer.FriendLinkSort DAL = new XYECOM.SQLServer.FriendLinkSort();

        #region 添加一个友情链接类别
         /// <summary>
         /// 添加友情链接类别对象
         /// </summary>
         /// <param name="fs">友情链接类别对象</param>
         /// <param name="fs_id">该友情链接类别对象的ID值</param>
         /// <returns>数字,大于0表示添加成功</returns>
        public int Insert(XYECOM.Model.FriendLinkSortInfo fs, out int fs_id)
        {
            return DAL.Insert(fs, out fs_id);
        }
        #endregion

        #region 修改一个友情链接类别信息
         /// <summary>
         /// 修改一个友情链接类别信息
         /// </summary>
         /// <param name="fs">要修改的友情链接类别对象</param>
         /// <returns>数字,大于0表示修改成功</returns>
        public int Update(XYECOM.Model.FriendLinkSortInfo fs)
        {
            return DAL.Update(fs);
        }
        #endregion

        #region 删除指定的友情链接类别信息
         /// <summary>
         /// 删除指定的友情链接类别信息
         /// </summary>
         /// <param name="fs_ids">要删除的友情链接类别ID串</param>
         /// <returns>数字，大于0表删除成功</returns>
        public int Delete(string fs_ids)
        {
            return DAL.Delete(fs_ids);
        }
        #endregion

        /// <summary>
        /// 得到所有友情链接分类
        /// </summary>
        /// <returns>所有友情链接分类</returns>
        public List<Model.FriendLinkSortInfo> GetItems()
        {
            return DAL.GetItems();
        }
         
        #region 获得指定的友情链接类别的DataTable
        /// <summary>
        /// 得到满足条件的DataTable类型的友情链接类别信息
        /// </summary>
        /// <param name="strWhere">查找友情链接类别信息的Where条件</param>
        /// <param name="strOrderBy">查找友情链接类别信息的OrderBy条件</param>
        /// <returns>DataTable类型的满足查询条件的友情链接类别信息</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            return DAL.GetDataTable(strWhere, strOrderBy);
        }
        #endregion

        #region 根据ID判断该类别下面是否还有子类别
        /// <summary>
        /// 根据指定ID值判断该类别下面是个还有子类别
        /// </summary>
        /// <param name="fs_ids">指定的类别ID值</param>
        /// <returns>数字,大于0表还有子类别,否则表无子类别</returns>
        public int GetSonType(string fs_ids)
        {
            return DAL.GetSonType(fs_ids);
        }
        #endregion

        #region 依据友情链接类别ID获取友情链接类别的名称
        /// <summary>
        /// 依据友情链接类别ID获取友情链接类别的名称
         /// </summary>
         /// <param name="fsid">要获取的友情链接类别的ID</param>
         /// <returns>该友情链接类别的名称</returns>
        public string GetFriendLinkName(int fsid)
        {
            return DAL.GetFriendLinkName(fsid);
        }
        #endregion
    }
}
