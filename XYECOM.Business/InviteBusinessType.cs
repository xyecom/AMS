using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using XYECOM.Model;

namespace XYECOM.Business
{
    /// <summary>
    /// 招商代理类别业务类
    /// </summary>
    public class InviteBusinessType
    {
        // 根据DAL工厂生成满足要求的招商代理类别对象
        private XYECOM.SQLServer.InviteBusinessType DAL = new XYECOM.SQLServer.InviteBusinessType();

        /// <summary>
        /// 添加一条新的招商代理类别对象
        /// </summary>
        /// <param name="ct">要添加的招商代理类别对象</param>
        /// <returns>数字,大于或等于0表成功,否则表失败,-1表已有雷同类别</returns>
        public int Insert(InviteBusinessTypeInfo it)
        {
            if (object.Equals(null, it))
                return -2;

            return DAL.Insert(it);
        }

        /// <summary>
        /// 更改指定的招商代理类别对象
        /// </summary>
        /// <param name="ct">要更改的招商代理类别对象</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int Update(InviteBusinessTypeInfo it)
        {
            if (object.Equals(null, it))
                return -2;

            return DAL.Update(it);
        }
        /// <summary>
        /// 删除指定编号的招商代理类别
        /// </summary>
        /// <param name="ctids">要删除的招商代理类别编号集</param>
        /// <returns>数字,大于或等于0表成功</returns>
        public int Delete(string itids)
        {
            if (string.IsNullOrEmpty(itids))
                return -2;

            return DAL.Delete(itids);
        }

        /// <summary>
        /// 获取指定编号的招商代理类别对象
        /// </summary>
        /// <param name="ctid">要获取的招商代理类别对象的编号</param>
        /// <returns>该编号下的招商代理类别对象</returns>
        public InviteBusinessTypeInfo GetItem(Int64 itid)
        {
            InviteBusinessTypeInfo ibtinfo = null;
            if (itid <= 0)
                return ibtinfo;

            return DAL.GetItem(itid);
        }

        /// <summary>
        /// 获取满足指定条件的招商代理类别对象集
        /// </summary>
        /// <param name="strWhere">指定的where条件</param>
        /// <param name="strOrder">指定的order条件</param>
        /// <returns>满足指定条件的招商代理类别对象集</returns>
        public DataTable GetDataTable(string strWhere, string strOrder)
        {
            if (string.IsNullOrEmpty(strWhere))
                strWhere = "";

            if (string.IsNullOrEmpty(strOrder))
                strOrder = "";

            return DAL.GetDataTable(strWhere, strOrder);
        }

        /// <summary>
        /// 获取满足指定条件的招商代理类别对象集
        /// </summary>
        /// <param name="parentID">父级类别Id</param>
        /// <param name="moduleName">模板名称</param>
        /// <returns>满足指定条件的招商代理类别对象集</returns>
        public DataTable GetDataTable(int parentID, string moduleName)
        {
            string where = " where 1=1 ";

            if (parentID >= 0)
            {
                where += " and IT_ParentID=" + parentID.ToString();
            }

            if (!moduleName.Equals(""))
            {
                where += " and moduleName='" + moduleName + "'";
            }

            return GetDataTable(where, "");
        }

        /// <summary>
        /// 判断指定的类别集下面是否还有子类别
        /// </summary>
        /// <param name="ctid">要判断是否还有子类别的类别编号集</param>
        /// <returns>数字,大于0表有子类,否则无子类别</returns>
        public int IsHaveSonType(string itid)
        {
            if (string.IsNullOrEmpty(itid))
                return 1;

            return DAL.IsHaveSonType(itid);
        }

        /// <summary>
        /// 根据招商代理的类别编号获取合作类别的名称
        /// </summary>
        /// <param name="ctid">要获取名称的招商代理类别的编号</param>
        /// <returns>该类别的名称</returns>
        public string GetInviteBusinessTypeName(Int64 itid)
        {
            if (itid <= 0)
                return "";

            return DAL.GetInviteBusinessTypeName(itid);
        }
    }
}
