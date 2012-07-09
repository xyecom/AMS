using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Business
{
    ///<summary>
    /// 用户资讯栏目业务层
    ///</summary>
    public class UserNewsTitle
    {
        private static readonly XYECOM.SQLServer.UserNewsTitle DAL = new SQLServer.UserNewsTitle();

        /// <summary>
        ///  添加新闻栏目信息
        /// </summary>
        /// <param name="nt">实体类NewsTitles</param>
        /// <param name="nt_id">所添加的新闻栏目的ID值</param>
        /// <returns>数字，大于或等于0表示添加成功</returns>
        public int Insert(XYECOM.Model.User.UserNewsTitleInfo info, out int nt_id)
        {
            if (info == null)
            {
                nt_id = 0;
                return 0;
            }

            return DAL.Insert(info, out nt_id);
        }

        /// <summary>
        /// 更新地区信息
        /// </summary>
        /// <param name="info">信息数据实体</param>
        /// <returns>大于 0 更新成功，小于等于0更新失败</returns>
        public int Update(XYECOM.Model.User.UserNewsTitleInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }
        /// <summary>
        /// 删除指定的新闻栏目信息
        /// </summary>
        /// <param name="nt_ids">指定的新闻栏目编号字符串</param>
        /// <returns>数字，大于或等于0表示删除成功</returns>
        public int Delete(string nt_ids)
        {
            if (String.IsNullOrEmpty(nt_ids) || nt_ids.Trim().Equals("")) return 0;

            return DAL.Delete(nt_ids);
        }

        /// <summary>
        /// 根据指定的ID值获得该项新闻栏目对象
        /// </summary>
        /// <param name="ntid">新闻栏目对象</param>
        /// <returns>该新闻栏目的名称</returns>
        public Model.User.UserNewsTitleInfo GetItem(int Id)
        {
            if (Id <= 0) return null;

            return DAL.GetItem(Id);
        }

        /// <summary>
        /// 获取一级栏目
        /// </summary>
        /// <returns>返回所有一级栏目信息</returns>
        public List<Model.User.UserNewsTitleInfo> GetPid()
        {
            return DAL.SelectPId();
        }
    }
}
