using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// 快速留言业务类
    /// </summary>
    public class ExpressMessage
    {
        private static readonly XYECOM.SQLServer.ExpressMessage DAL = new XYECOM.SQLServer.ExpressMessage();
        /// <summary>
        /// 添加快速留言
        /// </summary>
        /// <param name="info">快速留言实体对象</param>
        /// <returns>影响行数</returns>
        public int Insert(XYECOM.Model.ExpressMessageInfo info)
        {
            if (info == null) return 0;

            return DAL.Insert(info);
        }
        /// <summary>
        /// 修改快速留言
        /// </summary>
        /// <param name="info">快速留言实体对象</param>
        /// <returns>影响行数</returns>
        public int Update(XYECOM.Model.ExpressMessageInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }
        /// <summary>
        /// 删除快速留言
        /// </summary>
        /// <param name="ids">快速留言编号</param>
        /// <returns>影响行数</returns>
        public int Delete(string ids)
        {
            if (String.IsNullOrEmpty(ids) || ids.Trim().Equals("")) return 0;

            return DAL.Delete(ids);
        }
        /// <summary>
        /// 得到一条快速留言
        /// </summary>
        /// <param name="id">快速留言编号</param>
        /// <returns>快速留言信息实体对象</returns>
        public XYECOM.Model.ExpressMessageInfo GetItem(int id)
        {
            if (id <= 0) return null;

            return DAL.GetItem(id);
        }
        /// <summary>
        /// 获取指定模板的所有快速留言信息
        /// </summary>
        /// <param name="moduleName">模板名称</param>
        /// <returns>指定模板所有快速留言信息的集合</returns>
        public List<Model.ExpressMessageInfo> GetItems(string moduleName)
        {
            if (string.IsNullOrEmpty(moduleName) || moduleName.Equals("")) return new List<XYECOM.Model.ExpressMessageInfo>();

            return DAL.GetItems(moduleName);
        }
    }
}
