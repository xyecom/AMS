using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using XYECOM.Model;

namespace XYECOM.Business
{
    /// <summary>
    /// 关键字业务类
    /// </summary>
    public class FaithSet
    {
        /// <summary>
        /// 使用抽象工厂生成关键字的DAL
        /// </summary>
        private static readonly XYECOM.SQLServer.FaithSet DAL = new XYECOM.SQLServer.FaithSet();

        /// <summary>
        /// 添加新关键字的抽象方法
        /// </summary>
        /// <param name="ki">要添加的关键字对象</param>
        /// <returns>数字,大于或等于0表添加成功
        /// -1表已存在相同记录,-2表添加失败</returns>
        public int Insert(FaithSetInfo fsi)
        {
            return DAL.Insert(fsi);
        }

        /// <summary>
        /// 修改指定的关键字对象的抽象方法
        /// </summary>
        /// <param name="ki">要修改的关键字对象</param>
        /// <returns>数字,大于或等于0表成功
        /// -1表不允许修改(该关键字正在竞价),-2表修改失败</returns>
        public int Update(FaithSetInfo fsi)
        {
            return DAL.Update(fsi);
        }


        /// <summary>
        /// 删除指定关键字编号集的抽象方法
        /// </summary>
        /// <param name="kiids">要删除的关键字编号集</param>
        /// <returns>数字,大于或等于0表删除成功</returns>
        public int Delete(string kiids)
        {
            if (string.IsNullOrEmpty(kiids))
                return -2;

            return DAL.Delete(kiids);
        }

        /// <summary>
        /// 获取满足指定条件的诚信指数对象的抽象方法
        /// </summary>
        /// <param name="strWhere">指定的strWhere条件</param>
        /// <param name="strOrderBy">指定的OrderBy条件</param>
        /// <returns>满足给定条件的诚信指数对象的数据集</returns>
        public DataTable GetDataTable()
        {
            return DAL.GetDataTable();
        }
    }
}
