using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using XYECOM.Model;

namespace XYECOM.Business
{
    /// <summary>
    /// 服务类别业务类
    /// </summary>
    public class ServiceType
    {
        // 根据DAL工厂生成满足要求的服务类别对象
        private static readonly XYECOM.SQLServer.ServiceType DAL = new XYECOM.SQLServer.ServiceType();

        /// <summary>
        /// 添加一条新的服务信息类别对象
        /// </summary>
        /// <param name="ct">要添加的服务信息类别对象</param>
        /// <returns>数字,大于或等于0表成功,否则表失败,-1表已有雷同类别</returns>
        public int Insert(ServiceTypeInfo st)
        {
            if (object.Equals(null, st))
                return -2;

            return DAL.Insert(st);
        }

        /// <summary>
        /// 更改指定的服务信息类别对象
        /// </summary>
        /// <param name="ct">要更改的服务信息类别对象</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int Update(ServiceTypeInfo st)
        {
            if (object.Equals(null, st))
                return -2;

            return DAL.Update(st);
        }

        /// <summary>
        /// 删除指定编号的服务类别
        /// </summary>
        /// <param name="ctids">要删除的服务类别编号集</param>
        /// <returns>数字,大于或等于0表成功</returns>
        public int Delete(string stids)
        {
            if (string.IsNullOrEmpty(stids))
                return -2;

            return DAL.Delete(stids);
        }

        /// <summary>
        /// 获取指定编号的服务类别对象
        /// </summary>
        /// <param name="ctid">要获取的服务类别对象的编号</param>
        /// <returns>该编号下的服务类别对象</returns>
        public ServiceTypeInfo GetItem(Int64 stid)
        {
            ServiceTypeInfo stifno = null;
            if (stid <= 0)
                return stifno;

            return DAL.GetItem(stid);
        }

        /// <summary>
        /// 获取满足指定条件的服务类别对象集
        /// </summary>
        /// <param name="strWhere">指定的where条件</param>
        /// <param name="strOrder">指定的order条件</param>
        /// <returns>满足指定条件的服务类别对象集</returns>
        public DataTable GetDataTable(string strWhere, string strOrder)
        {
            if (string.IsNullOrEmpty(strWhere))
                strWhere = "";

            if (string.IsNullOrEmpty(strOrder))
                strOrder = "";

            return DAL.GetDataTable(strWhere, strOrder);
        }

        public DataTable GetDataTable(int parentID, string moduleName)
        {
            string where = " where 1=1 ";

            if (parentID >= 0)
            {
                where += " and ST_ParentID=" + parentID.ToString();
            }

            if (!moduleName.Equals(""))
            {
                where += " and moduleName='" + moduleName + "'";
            }

            return GetDataTable(where, "");
        }

        /// <summary>
        /// 判断指定的服务类别集下面是否还有子类别
        /// </summary>
        /// <param name="ctid">要判断是否还有子类别的类别编号集</param>
        /// <returns>数字,大于0表有子类,否则无子类别</returns>
        public int IsHaveSonType(string stid)
        {
            if (string.IsNullOrEmpty(stid))
                return 1;

            return DAL.IsHaveSonType(stid);
        }

        /// <summary>
        /// 根据服务信息的类别编号获取合作类别的名称
        /// </summary>
        /// <param name="ctid">要获取名称的服务类别的编号</param>
        /// <returns>该类别的名称</returns>
        public string GetServiceTypeName(Int64 stid)
        {
            if (stid <= 0)
                return "";

            return DAL.GetServiceTypeName(stid);
        }
    }
}
