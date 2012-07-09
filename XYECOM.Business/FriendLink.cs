using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// 友情链接业务类
    /// </summary>
    public class FriendLink
    {
        private static readonly XYECOM.SQLServer.FriendLink DAL = new XYECOM.SQLServer.FriendLink();

        #region 添加友情链接
        /// <summary>
        /// 添加友情链接
        /// </summary>
        /// <param name="efl">友情链接属性类对象</param>
        /// <returns>数字。大于等于0表示添加成功</returns>
        public int Insert(XYECOM.Model.FriendLinkInfo efl,out short FL_ID)
        {
            return DAL.Insert(efl, out FL_ID);
        }
        #endregion

        #region 修改友情链接
        /// <summary>
        /// 修改友情链接
        /// </summary>
        /// <param name="efl">友情链接属性类对象</param>
        /// <returns>数字。大于等于0表示修改成功</returns>
        public int Update(XYECOM.Model.FriendLinkInfo efl)
        {
            return DAL.Update(efl);
        }
        /// <summary>
        /// 修改友情链接推荐状态
        /// </summary>
        /// <param name="FL_ID">友情链接编号</param>
        /// <param name="FL_Flag">推荐状态</param>
        /// <returns>数字。大于等于0表示修改成功</returns>
        public int UpdateForFlag(short FL_ID, bool FL_Flag)
        {
            return DAL.UpdateForFlag(FL_ID,FL_Flag);
        }
        /// <summary>
        /// 修改推荐
        /// </summary>
        /// <param name="FL_ID">友情链接编号</param>
        /// <param name="isCommend">是否推荐</param>
        /// <returns>影响行数</returns>
        public int UpdateIsCommend(short FL_ID, bool isCommend)
        {
            return DAL.UpdateIsCommend(FL_ID, isCommend);
        }

        #endregion

        #region 删除友情链接
        /// <summary>
        /// 删除友情链接
        /// </summary>
        /// <param name="FL_IDs">友情链接编号字符串</param>
        /// <returns>数字。大于等于0表示删除成功</returns>
        public int Delete(string FL_IDs)
        {
            return DAL.Delete(FL_IDs);
        }
        #endregion

        #region 获取友情链接
        /// <summary>
        /// 获取制定友情链接
        /// </summary>
        /// <param name="FL_ID">友情链接编号</param>
        /// <returns>友情链接属性类对象</returns>
        public XYECOM.Model.FriendLinkInfo GetItem(short FL_ID)
        {
            return DAL.GetItem(FL_ID);
        }
        /// <summary>
        /// 获取符合条件的友情链接
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="strOrderBy">排序</param>
        /// <returns>符合条件友情链接的信息</returns>
        public DataTable GetDataTable(string strWhere,string strOrderBy)
        {
            return DAL.GetDataTable(strWhere,strOrderBy);
        }
        #endregion
    }
}
