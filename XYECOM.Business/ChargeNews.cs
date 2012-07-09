using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using XYECOM.Model;

namespace XYECOM.Business
{
    /// <summary>
    /// 收费新闻的收费信息逻辑类
    /// </summary>
    public class ChargeNews
    {
        // 通过接口工厂创建符合要求的收费信息类
        private static readonly XYECOM.SQLServer.ChargeNews DAL = new XYECOM.SQLServer.ChargeNews();

        /// <summary>
        /// 添加新的收费信息对象
        /// </summary>
        /// <param name="cn">要添加的收费信息对象</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int Insert(ChargeNewsInfo ci)
        {
            if (object.Equals(null, ci))
                return -2;

            return DAL.Insert(ci);
        }

        /// <summary>
        /// 删除指定的收费信息对象
        /// </summary>
        /// <param name="ids">要删除的收费信息对象编号集</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int Delete(string ciids)
        {
            if (string.IsNullOrEmpty(ciids))
                return -2;

            return DAL.Delete(ciids);
        }

        /// <summary>
        /// 获取满足指定条件的收费信息集
        /// </summary>
        /// <param name="strWhere">指定的Where条件</param>
        /// <param name="Order">指定的Order条件</param>
        /// <returns>满足条件的DataTable集</returns>
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
        /// 获取指定编号的收费信息对象
        /// </summary>
        /// <param name="cnid">指定的收费信息对象编号</param>
        /// <returns>该编号下的收费信息对象</returns>
        public ChargeNewsInfo GetItem(Int64 cnid)
        {
            ChargeNewsInfo cninfo = null;
            if (cnid <= 0)
                return cninfo;

            return DAL.GetItem(cnid);
        }

        /// <summary>
        /// 判断用户对某收费新闻是否付过费
        /// </summary>
        /// <param name="uid">指定的用户编号</param>
        /// <param name="nsid">指定的新闻编号</param>
        /// <returns>int型,大于0表已付费,其他表没有尚未付费</returns>
        public int GetIsCharged(Int64 uid, Int64 nsid, out int webmoney, out int money)
        {
            if (uid < 0 || nsid <= 0)
            {
                webmoney = 0;
                money = 0;
                return -5; // 表示查询出错
            }

            return DAL.GetIsCharged(uid, nsid, out webmoney, out money);
        }

        /// <summary>
        /// 指定的用户缴纳付费新闻操作,先进行扣费,然后添加消费记录(现金,虚拟)，最后添加新闻付费记录
        /// </summary>
        /// <param name="uid">指定的用户</param>
        /// <param name="nsid">要付费的新闻</param>
        /// <param name="webmoney">要缴纳的虚拟货币</param>
        /// <param name="money">要缴纳的现金货币</param>
        /// <returns>数字,大于或等于0表缴费操作成功,-1表余额不足,-2表缴费失败</returns>
        public int ConsumeUpdateMoney(Int64 uid, Int64 nsid, Decimal webmoney, Decimal money)
        {
            if (uid <= 0 || nsid <= 0)
                return -2;

            return DAL.ConsumeUpdateMoney(uid, nsid, webmoney, money);
        }
    }
}
