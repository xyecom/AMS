using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Model;


namespace XYECOM.Business
{
    /// <summary>
    /// 合作类别的商业业务类
    /// </summary>
    public class ShowType
    {
        // 根据DAL工厂生成满足要求的合作类别对象
        private XYECOM.SQLServer.ShowType DAL = new XYECOM.SQLServer.ShowType();

        /// <summary>
        /// 添加一条新的合作信息类别对象
        /// </summary>
        /// <param name="ct">要添加的合作信息类别对象</param>
        /// <returns>数字,大于或等于0表成功,否则表失败,-1表已有雷同类别</returns>
        public int Insert(ShowTypeInfo sht)
        {
            if (object.Equals(null, sht))
                return -2;

            return DAL.Insert(sht);
        }

        /// <summary>
        /// 更改指定的合作信息类别对象
        /// </summary>
        /// <param name="ct">要更改的合作信息类别对象</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int Update(ShowTypeInfo sht)
        {
            if (object.Equals(null, sht))
                return -2;

            return DAL.Update(sht);
        }

        /// <summary>
        /// 删除指定编号的合作类别
        /// </summary>
        /// <param name="ctids">要删除的合作类别编号集</param>
        /// <returns>数字,大于或等于0表成功</returns>
        public int Delete(string shtids)
        {
            if (string.IsNullOrEmpty(shtids))
                return -2;

            return DAL.Delete(shtids);
        }

        /// <summary>
        /// 获取指定编号的合作类别对象
        /// </summary>
        /// <param name="ctid">要获取的合作类别对象的编号</param>
        /// <returns>该编号下的合作类别对象</returns>
        public ShowTypeInfo GetItem(Int64 shtid)
        {
            ShowTypeInfo stinfo = null;
            if (shtid <= 0)
                return stinfo;

            return DAL.GetItem(shtid);
        }

        /// <summary>
        /// 获取满足指定条件的合作类别对象集
        /// </summary>
        /// <param name="strWhere">指定的where条件</param>
        /// <param name="strOrder">指定的order条件</param>
        /// <returns>满足指定条件的合作类别对象集</returns>
        public DataTable GetDataTable(string strWhere, string strOrder)
        {
            if (string.IsNullOrEmpty(strWhere))
                strWhere = "";

            if (string.IsNullOrEmpty(strOrder))
                strOrder = "";

            return DAL.GetDataTable(strWhere, strOrder);
        }

        public DataTable GetDataTable(long parentID, string modulename)
        {
            string where = " where 1=1 ";

            if (parentID >= 0)
            {
                where += " and SHT_ParentID=" + parentID.ToString();
            }

            if (!modulename.Equals(""))
            {
                where += " and moduleName='" + modulename + "'";
            }

            return GetDataTable(where, "");
        }
        /// <summary>
        /// 判断指定的类别下面是否还有子类别
        /// </summary>
        /// <param name="ctid">要判断是否还有子类别的类别编号</param>
        /// <returns>数字,大于0表有子类,否则无子类别</returns>
        public int IsHaveSonType(string shtid)
        {
            if (string.IsNullOrEmpty(shtid))
                return -2;

            return DAL.IsHaveSonType(shtid);
        }

        /// <summary>
        /// 根据合作信息的类别编号获取合作类别的名称
        /// </summary>
        /// <param name="infoid">要获取名称的合作类别的编号</param>
        /// <returns>该类别的名称</returns>
        public string GetShowTypeName(int infoid)
        {
            if (infoid <= 0)
                return "";

            return DAL.GetCooperateTypeName(infoid);
        }
    }
}
