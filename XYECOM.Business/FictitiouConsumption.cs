using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using XYECOM.Model;

namespace XYECOM.Business
{
    /// <summary>
    /// 虚拟消费记录业务类
    /// </summary>
    public class FictitiouConsumption
    {
        /// <summary>
        /// 使用抽象工厂生成虚拟消费记录的DAL
        /// </summary>
        private static readonly XYECOM.SQLServer.FictitiouConsumption DAL = new XYECOM.SQLServer.FictitiouConsumption();

        /// <summary>
        /// 添加新的虚拟消费记录对象
        /// </summary>
        /// <param name="aci">要添加的新的虚拟消费记录对象</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int Insert(FictitiouConsumptionInfo fci)
        {
            if (object.Equals(null, fci))
                throw new Exception("The Object is Null");

            return DAL.Insert(fci);
        }

        /// <summary>
        /// 获取指定编号的虚拟消费记录对象
        /// </summary>
        /// <param name="acid">要获取的虚拟消费记录对象的编号</param>
        /// <returns>该编号下对应的消费对象</returns>
        public FictitiouConsumptionInfo GetItem(Int64 fcid)
        {
            if (fcid <= 0)
                throw new Exception("The ID is Error");

            return DAL.GetItem(fcid);
        }

        /// <summary>
        /// 获取满足指定条件的虚拟消费对象集
        /// </summary>
        /// <param name="strWhere">指定的where条件</param>
        /// <param name="Order">指定的order条件</param>
        /// <returns>满足指定条件的虚拟消费对象集</returns>
        public DataTable GetDataTable(string where, string order)
        {
            if (string.IsNullOrEmpty(where) || string.IsNullOrEmpty(order))
                throw new Exception("The where or order is Error");

            return DAL.GetDataTable(where, order);
        }
    }
}
