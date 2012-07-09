using System;
using System.Collections.Generic;
using System.Text;

using System.Data;


namespace XYECOM.Business
{
    /// <summary>
    /// 模板业务类
    /// </summary>
    public class Template
    {
        private static readonly XYECOM.SQLServer.Template DAL = new XYECOM.SQLServer.Template();

        #region 获取模板项
        /// <summary>
        /// 获取模板项
        /// </summary>
        /// <param name="templateid">模板编号</param>
        /// <returns>模板项实体对象</returns>
        public XYECOM.Model.TemplateInfo GetTemplateItem(int templateid)
        {
            return DAL.GetTemplateItem(templateid);
        }
        #endregion

        #region 获取模板信息
        /// <summary>
        ///  获取模板信息
        /// </summary>
        /// <param name="templatePath">指定的路径</param>
        /// <returns>模板信息</returns>
        public DataTable GetAllTemplateList(string templatePath)
        {
            return DAL.GetAllTemplateList(templatePath);
        }
        /// <summary>
        /// 得到所有模板的信息
        /// </summary>
        /// <returns>所有模板信息</returns>
        //public DataTable GetValidTemplateList()
        //{
        //    return DAL.GetValidTemplateList();
        //}


        public int SelectMaxID(string tablename, string maxid)
        {

            return DAL.SelectMaxID(tablename, maxid);
        }

        #endregion

        #region 删除模板信息
        /// <summary>
        /// 删除模板信息
        /// </summary>
        /// <param name="templateidlist">模板信息编号集合</param>
        /// <returns>影响行数</returns>
        public int DeleteTemplateItem(string templateidlist)
        {
            return DAL.DeleteTemplateItem(templateidlist);
        }

        /// <summary>
        /// 删除一个模板信息
        /// </summary>
        /// <param name="T_ID">模板信息编号</param>
        /// <returns>影响行数</returns>
        public int DeleteTemplateItem(int T_ID)
        {
            return DAL.DeleteTemplateItem(T_ID);
        }
        #endregion

        #region 修改启用状态
        /// <summary>
        /// 修改启用状态
        /// </summary>
        /// <param name="T_ID">模板编号</param>
        /// <returns>影响行数</returns>
        public int UpdateFlag(int T_ID)
        {
            return DAL.UpdateFlag(T_ID);
        }
        #endregion

    }
}
