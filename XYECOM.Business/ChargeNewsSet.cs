using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using XYECOM.Model;

namespace XYECOM.Business
{
    /// <summary>
    /// 收费新闻设置接口业务类
    /// </summary>
    public class ChargeNewsSet
    {
        //通过抽象工厂获取满足要求的抽象类
        private static readonly XYECOM.SQLServer.ChargeNewsSet DAL = new XYECOM.SQLServer.ChargeNewsSet();

        /// <summary>
        /// 添加一条新的新闻设置对象
        /// </summary>
        /// <param name="ci">要添加的新闻设置对象</param>
        /// <returns>数字,大于或等于0表成功,等于-1表有雷同设置,其他表失败</returns>
        public int Insert(ChargeNewsSetInfo ci)
        {
            if (object.Equals(null, ci))
                return -2;

            return  DAL.Insert(ci);
        }

        /// <summary>
        /// 更改指定新闻设置对象
        /// </summary>
        /// <param name="ci">要修改的新闻设置对象</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int Update(ChargeNewsSetInfo ci)
        {
            if (object.Equals(null, ci))
                return -2;

            return DAL.Update(ci);
        }

        /// <summary>
        /// 删除指定编号集的收费新闻设置
        /// </summary>
        /// <param name="ciids">要删除的收费新闻编号集</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int Delete(string newsIds)
        {
            if (string.IsNullOrEmpty(newsIds))
                return -2;

            return DAL.Delete(newsIds);
        }

                /// <summary>
        /// 按会员等级删除收费新闻资费信息
        /// </summary>
        /// <param name="userGradeId"></param>
        /// <returns></returns>
        public int DeleteByUserGradeId(int userGradeId)
        {
            if (userGradeId <= 0) return 0;

            return DAL.DeleteByUserGradeId(userGradeId);
        }

        /// <summary>
        /// 获取满足指定条件的收费新闻设置对象集
        /// </summary>
        /// <param name="strWhere">指定的Where条件</param>
        /// <param name="Oder">指定的排序条件</param>
        /// <returns>满足指定条件的收费新闻设置对象集</returns>
        public DataTable GetDataTable(string strWhere, string Order)
        {
            DataTable dt = null;
            if (string.IsNullOrEmpty(strWhere))
                return dt;

            if (object.Equals(null, Order))
                Order = "";

            return DAL.GetDataTable(strWhere, Order);
        }

        /// <summary>
        /// 获取指定编号的收费新闻对象
        /// </summary>
        /// <param name="ciid">指定的收费新闻编号</param>
        /// <returns>该编号对应的收费新闻对象</returns>
        public ChargeNewsSetInfo GetItem(Int64 ciid)
        {
            ChargeNewsSetInfo cnsinfo = null;
            if (ciid <= 0)
                return cnsinfo;

            return DAL.GetItem(ciid);
        }
        /// <summary>
        /// 获取指定资讯编号和用户等级的收费新闻对象
        /// </summary>
        /// <param name="newsId">新闻id</param>
        /// <param name="userGradeId">等级id</param>
        /// <returns>收费新闻实体对象</returns>
        public ChargeNewsSetInfo GetItem(long newsId, int userGradeId)
        {
            if (newsId <= 0 || userGradeId <= 0) return null;

            return DAL.GetItem(newsId, userGradeId);
        }

        /// <summary>
        /// 获取满足指定条件的字段的集合
        /// </summary>
        /// <param name="strWhere">指定的Where条件</param>
        /// <param name="Field">要获取的字段</param>
        /// <returns>满足条件的字段的集合</returns>
        public DataTable GetDataTableForField(string strWhere, string Field)
        {
            DataTable dt = null;
            if (string.IsNullOrEmpty(strWhere) || string.IsNullOrEmpty(Field))
                return dt;

            return DAL.GetDataTable(strWhere, Field);
        }
        /// <summary>
        /// 获取满足指定条件的字段的集合
        /// </summary>
        /// <param name="newID">新闻编号</param>
        /// <returns>满足指定条件字段集合</returns>
        public string GetGreadIDByNewID(string newID)
        {
            DataTable dt = DAL.GetDataTableForField(" where NS_ID=" + newID.ToString(), "CN_VisitPopedom");
            string result = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result += result == "" ? "" : ",";
                result += dt.Rows[i]["CN_VisitPopedom"].ToString();
            }
            return result;
        }
    }
}
